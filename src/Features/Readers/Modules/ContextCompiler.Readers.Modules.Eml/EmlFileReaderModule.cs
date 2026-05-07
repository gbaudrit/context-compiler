using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

using MimeKit;

namespace ContextCompiler.Readers.Modules.Eml;

public sealed class EmlFileReaderModule(
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartBuilder dataPartBuilder,
    ISourceRefBuilder sourceRefBuilder,
    ILogger<EmlFileReaderModule> logger) : IFileReaderModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("readers.eml", InputIngestionPipelineModuleKinds.ReadDocument, priority: 12);

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return Path.GetExtension(InputItemContext.FullPath).Equals(".eml", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogInformation("Reading EML file: {Path}", context.InputItem.FullPath);

        await using FileStream stream = File.OpenRead(context.InputItem.FullPath);
        MimeMessage message = await MimeMessage.LoadAsync(stream, ct);
        List<IDataPart> parts = [];

        AddTextPart(parts, context.InputItem, "subject", "Subject", message.Subject, DataPartType.Text);
        AddTextPart(parts, context.InputItem, "message-id", "Message-Id", message.MessageId, DataPartType.Metadata);
        AddTextPart(parts, context.InputItem, "in-reply-to", "In-Reply-To", message.InReplyTo, DataPartType.Metadata);
        AddTextPart(parts, context.InputItem, "date", "Date", message.Date == default ? null : message.Date.ToString("O"), DataPartType.Metadata);
        AddEmailAddresses(parts, context.InputItem, "from", "From", message.From.Mailboxes);
        AddEmailAddresses(parts, context.InputItem, "to", "To", message.To.Mailboxes);
        AddEmailAddresses(parts, context.InputItem, "cc", "Cc", message.Cc.Mailboxes);
        AddEmailAddresses(parts, context.InputItem, "bcc", "Bcc", message.Bcc.Mailboxes);
        AddEmailAddresses(parts, context.InputItem, "reply-to", "Reply-To", message.ReplyTo.Mailboxes);
        AddTextPart(parts, context.InputItem, "text-body", "Text Body", NormalizeBody(message.TextBody), DataPartType.Text);
        AddTextPart(parts, context.InputItem, "html-body", "Html Body", NormalizeBody(message.HtmlBody), DataPartType.Text);

        int attachmentIndex = 0;
        foreach (MimeEntity attachment in message.Attachments)
        {
            string attachmentPayload = FormatAttachmentPayload(attachment);

            AddTextPart(parts,
                        context.InputItem,
                        $"attachment-{attachmentIndex}",
                        $"Attachment {attachmentIndex + 1}",
                        attachmentPayload,
                        DataPartType.Metadata,
                        $"attachment:{attachmentIndex}");
            attachmentIndex++;
        }

        return await context.Patch(b => b.WithDataEnvelope(dataEnvelopeBuilder.InitNew()
                                  .WithDataShape(DataShape.Linear)
                                  .WithParts(parts)
                                  .Build()))
                      .Success();
    }

    private static string FormatAttachmentPayload(MimeEntity entity)
    {
        string? fileName = entity switch
        {
            MessagePart => null,
            MimePart mimePart => mimePart.FileName,
            _ => entity.ContentDisposition?.FileName
        };

        bool isEmbeddedMessage = entity is MessagePart;

        return $"FileName: {fileName ?? "(none)"}{Environment.NewLine}" +
               $"ContentType: {entity.ContentType.MimeType}{Environment.NewLine}" +
               $"IsEmbeddedMessage: {isEmbeddedMessage}";
    }

    private static string? NormalizeBody(string? body)
    {
        return string.IsNullOrWhiteSpace(body) ? null : body.Trim();
    }

    private void AddTextPart(List<IDataPart> parts,
                             IInputItemContext InputItemContext,
                             string id,
                             string label,
                             string? payload,
                             DataPartType type,
                             string? locator = null,
                             string? groupId = null)
    {
        if (string.IsNullOrWhiteSpace(payload))
        {
            return;
        }

        parts.Add(dataPartBuilder.InitNew()
                                 .WithId(id)
                                 .WithLabel(label)
                                 .WithType(type)
                                 .WithSource(sourceRefBuilder.InitNew()
                                                             .WithPath(InputItemContext.FullPath)
                                                             .WithLocator(locator ?? id)
                                                             .Build())
                                 .WithPayload(payload)
                                 .WithTags(InputItemContext.Data.Tags)
                                 .WithGroupId(groupId)
                                 .Build());
    }

    private void AddEmailAddresses(List<IDataPart> parts,
                                   IInputItemContext InputItemContext,
                                   string idPrefix,
                                   string labelPrefix,
                                   IEnumerable<MailboxAddress> mailboxes)
    {
        int index = 0;
        foreach (MailboxAddress mailbox in mailboxes)
        {
            string indexSuffix = index > 0 ? $"-{index}" : "";
            string groupId = $"{idPrefix}:{index}";

            // Add name as a separate part if present
            if (!string.IsNullOrWhiteSpace(mailbox.Name))
            {
                AddTextPart(parts,
                           InputItemContext,
                           $"{idPrefix}{indexSuffix}-name",
                           $"{labelPrefix} Name",
                           mailbox.Name,
                           DataPartType.PersonalDataName,
                           $"{idPrefix}:{index}:name",
                           groupId);
            }

            // Add email address as a separate part
            if (!string.IsNullOrWhiteSpace(mailbox.Address))
            {
                AddTextPart(parts,
                           InputItemContext,
                           $"{idPrefix}{indexSuffix}-email",
                           $"{labelPrefix} Email",
                           mailbox.Address,
                           DataPartType.PersonalDataEmail,
                           $"{idPrefix}:{index}:email",
                           groupId);
            }

            index++;
        }
    }
}

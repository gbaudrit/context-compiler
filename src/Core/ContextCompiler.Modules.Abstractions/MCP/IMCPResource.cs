namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPResource
{
    /// <inheritdoc />
    string Name { get; }

    /// <inheritdoc />
    string? Title { get; }

    /// <summary>
    /// Gets or sets the URI of this resource.
    /// </summary>
    string Uri { get; }

    /// <summary>
    /// Gets or sets a description of what this resource represents.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This can be used by clients to improve the LLM's understanding of available resources. It can be thought of like a \"hint\" to the model.
    /// </para>
    /// <para>
    /// The description should provide clear context about the resource's content, format, and purpose.
    /// This helps AI models make better decisions about when to access or reference the resource.
    /// </para>
    /// <para>
    /// Client applications can also use this description for display purposes in user interfaces
    /// or to help users understand the available resources.
    /// </para>
    /// </remarks>
    string? Description { get; }

    /// <summary>
    /// Gets or sets the MIME type of this resource.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="MimeType"/> specifies the format of the resource content, helping clients to properly interpret and display the data.
    /// Common MIME types include "text/plain" for plain text, "application/pdf" for PDF documents,
    /// "image/png" for PNG images, and "application/json" for JSON data.
    /// </para>
    /// <para>
    /// This property can be <see langword="null"/> if the MIME type is unknown or not applicable for the resource.
    /// </para>
    /// </remarks>
    string? MimeType { get; }

    ///// <summary>
    ///// Gets or sets optional annotations for the resource.
    ///// </summary>
    ///// <remarks>
    ///// These annotations can be used to specify the intended audience (<see cref="Role.User"/>, <see cref="Role.Assistant"/>, or both)
    ///// and the priority level of the resource. Clients can use this information to filter or prioritize resources for different roles.
    ///// </remarks>
    //public Annotations? Annotations { get; set; }

    /// <summary>
    /// Gets or sets the size of the raw resource content (before base64 encoding), in bytes, if known.
    /// </summary>
    /// <remarks>
    /// This can be used by applications to display file sizes and estimate context window usage.
    /// </remarks>
    long? Size { get; }

    ///// <summary>
    ///// Gets or sets an optional list of icons for this resource.
    ///// </summary>
    ///// <remarks>
    ///// This can be used by clients to display the resource's icon in a user interface.
    ///// </remarks>
    //public IList<Icon>? Icons { get; set; }

    ///// <summary>
    ///// Gets or sets metadata reserved by MCP for protocol-level metadata.
    ///// </summary>
    ///// <remarks>
    ///// Implementations must not make assumptions about its contents.
    ///// </remarks>
    //[JsonPropertyName("_meta")]
    //public JsonObject? Meta { get; set; }
}

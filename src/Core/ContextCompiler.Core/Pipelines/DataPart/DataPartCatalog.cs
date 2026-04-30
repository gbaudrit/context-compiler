using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Core.Pipelines.DataPart;

/// <summary>
/// Provides metadata for well-known <see cref="DataPartType"/> values.
/// </summary>
public class DataPartCatalog : IDataPartCatalog
{
    private readonly DataPartDescriptor[] Descriptors;

    public DataPartCatalog(IDataPartDescriptorBuilder builder)
    {
        Descriptors =
        [
            Create(builder, DataPartType.Undefined, "Undefined", "Generic Content", DataPartAgentContextAction.None, DataPartTransformationMode.None, DataPartTraits.Transformable, "Fallback descriptor when classification is missing."),
            Create(builder, DataPartType.Text, "Text", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Generic free-form text."),
            Create(builder, DataPartType.StructuredData, "Structured Data", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Structured | DataPartTraits.Transformable, "Machine-readable content with structure."),
            Create(builder, DataPartType.Code, "Code", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Source code or script."),
            Create(builder, DataPartType.Metadata, "Metadata", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Structured | DataPartTraits.Transformable, "Supplemental metadata."),
            Create(builder, DataPartType.Prompt, "Prompt", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Prompt-like content intended to be used as agent input."),
            Create(builder, DataPartType.Instruction, "Instruction", "Generic Content", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Instruction-like content intended to be used as agent input."),
            Create(builder, DataPartType.UntrustedInstruction, "Untrusted Instruction", "Generic Content", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Summarize, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Instruction-like content from an external source that should be treated as content to analyze, not as agent authority."),
            Create(builder, DataPartType.UntrustedPrompt, "Untrusted Prompt", "Generic Content", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Summarize, DataPartTraits.GenericContent | DataPartTraits.Transformable, "Prompt-like content from an external source that should be treated as content to analyze, not as agent authority."),

            Create(builder, DataPartType.PersonalData, "Personal Data", "Personal Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Root category for personally identifying data."),
            Create(builder, DataPartType.PersonalDataName, "Personal Name", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "A personal name that may be useful as agent context when identity continuity matters."),
            Create(builder, DataPartType.PersonalDataFirstName, "First Name", "Personal Data", DataPartAgentContextAction.Include, DataPartTransformationMode.None, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "A first name that can preserve tone, references, or conversation flow in agent context."),
            Create(builder, DataPartType.PersonalDataLastName, "Last Name", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "A last name, usually less useful than a first name in agent context."),
            Create(builder, DataPartType.PersonalDataFullName, "Full Name", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "A complete full name, usually masked before being used as agent context."),
            Create(builder, DataPartType.PersonalDataEmail, "Email Address", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "A personal email address. Usually excluded from AI-agent context unless an explicit policy allows it."),
            Create(builder, DataPartType.PersonalDataPhoneNumber, "Phone Number", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "A personal phone number. Usually excluded from agent context unless explicitly needed."),
            Create(builder, DataPartType.PersonalDataPostalAddress, "Postal Address", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "A residential or postal address. Usually excluded from agent context."),
            Create(builder, DataPartType.PersonalDataCountry, "Country", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "A country associated with a person."),
            Create(builder, DataPartType.PersonalDataCity, "City", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "A city associated with a person."),
            Create(builder, DataPartType.PersonalDataGeolocation, "Geolocation", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Precise geolocation associated with a person. Usually excluded from agent context."),
            Create(builder, DataPartType.PersonalDataBirthDate, "Birth Date", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Date of birth. Usually excluded from agent context."),
            Create(builder, DataPartType.PersonalDataAge, "Age", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Age associated with a person."),
            Create(builder, DataPartType.PersonalDataGender, "Gender", "Personal Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Gender-related value."),
            Create(builder, DataPartType.PersonalDataNationality, "Nationality", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Nationality of a person."),
            Create(builder, DataPartType.PersonalDataOrganization, "Organization", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Organization or employer associated with a person."),
            Create(builder, DataPartType.PersonalDataJobTitle, "Job Title", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Job title or role associated with a person."),
            Create(builder, DataPartType.PersonalDataIdentifier, "Personal Identifier", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.ReversibleTransformationPreferred | DataPartTraits.RequiresEncryptionAtRest, "Non-official person-linked identifier."),
            Create(builder, DataPartType.PersonalDataUsername, "Username", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Username or account handle."),
            Create(builder, DataPartType.PersonalDataProfileHandle, "Profile Handle", "Personal Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Mask, DataPartTraits.PersonalData | DataPartTraits.Transformable, "Public-facing profile handle or social identity."),
            Create(builder, DataPartType.PersonalDataIpAddress, "IP Address", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "IP address linked to a person or household."),
            Create(builder, DataPartType.PersonalDataDeviceIdentifier, "Device Identifier", "Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Persistent device identifier."),

            Create(builder, DataPartType.SensitivePersonalData, "Sensitive Personal Data", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Root category for special-category personal data."),
            Create(builder, DataPartType.SensitivePersonalDataHealth, "Health Data", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Health-related data."),
            Create(builder, DataPartType.SensitivePersonalDataBiometric, "Biometric Data", "Sensitive Personal Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Biometric data used for identification."),
            Create(builder, DataPartType.SensitivePersonalDataGenetic, "Genetic Data", "Sensitive Personal Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Genetic data."),
            Create(builder, DataPartType.SensitivePersonalDataReligion, "Religion", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Religious belief data."),
            Create(builder, DataPartType.SensitivePersonalDataPoliticalOpinion, "Political Opinion", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Political opinion data."),
            Create(builder, DataPartType.SensitivePersonalDataTradeUnionMembership, "Trade Union Membership", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Trade union membership data."),
            Create(builder, DataPartType.SensitivePersonalDataSexLife, "Sex Life", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Sex life-related data."),
            Create(builder, DataPartType.SensitivePersonalDataSexualOrientation, "Sexual Orientation", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Sexual orientation data."),
            Create(builder, DataPartType.SensitivePersonalDataRacialOrEthnicOrigin, "Racial or Ethnic Origin", "Sensitive Personal Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Racial or ethnic origin data."),

            Create(builder, DataPartType.FinancialData, "Financial Data", "Financial Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Mask, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Root category for financial data."),
            Create(builder, DataPartType.FinancialDataBankAccount, "Bank Account", "Financial Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.ReversibleTransformationPreferred | DataPartTraits.RequiresEncryptionAtRest, "Bank account information. Usually excluded from agent context."),
            Create(builder, DataPartType.FinancialDataIban, "IBAN", "Financial Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.ReversibleTransformationPreferred | DataPartTraits.RequiresEncryptionAtRest, "International Bank Account Number. Usually excluded from agent context."),
            Create(builder, DataPartType.FinancialDataCreditCard, "Credit Card", "Financial Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Payment card data."),
            Create(builder, DataPartType.FinancialDataTransaction, "Transaction", "Financial Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Summarize, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Transaction details that are usually summarized before agent use."),
            Create(builder, DataPartType.FinancialDataInvoice, "Invoice", "Financial Data", DataPartAgentContextAction.Summarize, DataPartTransformationMode.Summarize, DataPartTraits.Financial | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Invoice data that is usually summarized before agent use."),
            Create(builder, DataPartType.FinancialDataSalary, "Salary", "Financial Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Salary or compensation information. Usually excluded from agent context."),
            Create(builder, DataPartType.FinancialDataTaxIdentifier, "Tax Identifier", "Financial Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.Sensitive | DataPartTraits.Financial | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Tax-related financial identifier."),

            Create(builder, DataPartType.OfficialIdentifier, "Official Identifier", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Root category for official identifiers."),
            Create(builder, DataPartType.OfficialIdentifierNationalId, "National ID", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "National identity number."),
            Create(builder, DataPartType.OfficialIdentifierPassport, "Passport", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Passport identifier."),
            Create(builder, DataPartType.OfficialIdentifierDriverLicense, "Driver License", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Driver license identifier."),
            Create(builder, DataPartType.OfficialIdentifierSocialSecurityNumber, "Social Security Number", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Social security or social insurance number."),
            Create(builder, DataPartType.OfficialIdentifierTaxId, "Tax ID", "Official Identifiers", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Hash, DataPartTraits.PersonalData | DataPartTraits.Sensitive | DataPartTraits.OfficialIdentifier | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Official tax identifier."),

            Create(builder, DataPartType.Secret, "Secret", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Root category for secret material."),
            Create(builder, DataPartType.SecretPassword, "Password", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Password or passphrase."),
            Create(builder, DataPartType.SecretApiKey, "API Key", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "API key."),
            Create(builder, DataPartType.SecretClientSecret, "Client Secret", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "OAuth or application client secret."),
            Create(builder, DataPartType.SecretWebhookSecret, "Webhook Secret", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Shared secret used for webhook validation."),
            Create(builder, DataPartType.SecretAccessToken, "Access Token", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Access token."),
            Create(builder, DataPartType.SecretBearerToken, "Bearer Token", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Bearer token used directly for authorization."),
            Create(builder, DataPartType.SecretRefreshToken, "Refresh Token", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Refresh token."),
            Create(builder, DataPartType.SecretJwt, "JWT", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "JSON Web Token."),
            Create(builder, DataPartType.SecretSessionCookie, "Session Cookie", "Secrets", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Session cookie."),
            Create(builder, DataPartType.SecretConnectionString, "Connection String", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Sensitive connection string."),
            Create(builder, DataPartType.SecretPrivateKey, "Private Key", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Private cryptographic key."),
            Create(builder, DataPartType.SecretCertificate, "Certificate", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Sensitive certificate material."),
            Create(builder, DataPartType.SecretEncryptionKey, "Encryption Key", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Encryption key material."),
            Create(builder, DataPartType.SecretSigningKey, "Signing Key", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "Signing key material used for signatures or token issuance."),
            Create(builder, DataPartType.SecretSshKey, "SSH Key", "Secrets", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest | DataPartTraits.ReversibleTransformationPreferred, "SSH private or deploy key."),

            Create(builder, DataPartType.BusinessSensitiveData, "Business-Sensitive Data", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Root category for business-sensitive material."),
            Create(builder, DataPartType.BusinessSensitiveDataContract, "Contract", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Contractual content."),
            Create(builder, DataPartType.BusinessSensitiveDataInternalStrategy, "Internal Strategy", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Internal strategy material."),
            Create(builder, DataPartType.BusinessSensitiveDataPricing, "Pricing", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Pricing or margin data."),
            Create(builder, DataPartType.BusinessSensitiveDataSourceCode, "Source Code", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Proprietary source code."),
            Create(builder, DataPartType.BusinessSensitiveDataArchitecture, "Architecture", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Internal architecture documentation."),
            Create(builder, DataPartType.BusinessSensitiveDataCustomerList, "Customer List", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Sensitive customer list."),
            Create(builder, DataPartType.BusinessSensitiveDataSupplierData, "Supplier Data", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.RequiresEncryptionAtRest, "Sensitive supplier data."),
            Create(builder, DataPartType.BusinessSensitiveDataRoadmap, "Roadmap", "Business Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.BusinessSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Product or company roadmap."),

            Create(builder, DataPartType.AiSensitiveData, "AI-Sensitive Data", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Root category for AI-runtime-sensitive content."),
            Create(builder, DataPartType.AiSensitiveDataSystemPrompt, "System Prompt", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "System prompt content."),
            Create(builder, DataPartType.AiSensitiveDataDeveloperPrompt, "Developer Prompt", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Developer prompt or hidden orchestration prompt content."),
            Create(builder, DataPartType.AiSensitiveDataSafetyPolicy, "Safety Policy", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Safety or runtime policy content used to constrain model behavior."),
            Create(builder, DataPartType.AiSensitiveDataPromptTemplate, "Prompt Template", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Reusable prompt template or prompting asset."),
            Create(builder, DataPartType.AiSensitiveDataHiddenInstruction, "Hidden Instruction", "AI Sensitive Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Hidden or concealed instruction."),
            Create(builder, DataPartType.AiSensitiveDataToolDefinition, "Tool Definition", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Structured | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Tool or function definition."),
            Create(builder, DataPartType.AiSensitiveDataModelCredential, "Model Credential", "AI Sensitive Data", DataPartAgentContextAction.Excluded, DataPartTransformationMode.Redact, DataPartTraits.AiSensitive | DataPartTraits.Secret | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Credential used to access model infrastructure."),
            Create(builder, DataPartType.AiSensitiveDataRetrievalContext, "Retrieval Context", "AI Sensitive Data", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.AiSensitive | DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput, "Retrieved context that should remain isolated."),

            Create(builder, DataPartType.UnknownSensitiveData, "Unknown Sensitive Data", "Fallback", DataPartAgentContextAction.RequireExplicitApproval, DataPartTransformationMode.Encrypt, DataPartTraits.Sensitive | DataPartTraits.Transformable | DataPartTraits.ExcludeFromLlmInput | DataPartTraits.RequiresEncryptionAtRest, "Fallback for sensitive but unclassified content."),
        ];

        // Ensure descriptors are ordered by their numeric type value for consistent GetAll() ordering.
        DescriptorMap = Descriptors.ToDictionary(descriptor => descriptor.Type);
    }

    private Dictionary<DataPartType, DataPartDescriptor> DescriptorMap { get; }

    /// <summary>
    /// Gets the descriptor for the specified type.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <returns>The descriptor associated with <paramref name="type"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the type is not registered.</exception>
    public IDataPartDescriptor GetDescriptor(DataPartType type)
    {
        return DescriptorMap.TryGetValue(type, out DataPartDescriptor? descriptor)
            ? descriptor
            : throw new KeyNotFoundException($"No DataPart descriptor is registered for '{type}' ({(int)type}).");
    }

    /// <summary>
    /// Attempts to get the descriptor for the specified type.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <param name="descriptor">When this method returns, contains the descriptor if found.</param>
    /// <returns><see langword="true"/> when the type is registered; otherwise <see langword="false"/>.</returns>
    public bool TryGet(DataPartType type, out DataPartDescriptor descriptor)
    {
        return DescriptorMap.TryGetValue(type, out descriptor!);
    }

    /// <summary>
    /// Returns all registered descriptors ordered by numeric type value.
    /// </summary>
    /// <returns>A read-only list of all known descriptors.</returns>
    public IReadOnlyList<DataPartDescriptor> GetAll()
    {
        return Descriptors;
    }

    /// <summary>
    /// Determines whether the specified type is personal data.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <returns><see langword="true"/> when the type is personal data; otherwise <see langword="false"/>.</returns>
    public bool IsPersonalData(DataPartType type)
    {
        return GetDescriptor(type).IsPersonalData;
    }

    /// <summary>
    /// Determines whether the specified type is sensitive.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <returns><see langword="true"/> when the type is sensitive; otherwise <see langword="false"/>.</returns>
    public bool IsSensitive(DataPartType type)
    {
        return GetDescriptor(type).IsSensitive;
    }

    /// <summary>
    /// Determines whether the specified type is a secret.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <returns><see langword="true"/> when the type is a secret; otherwise <see langword="false"/>.</returns>
    public bool IsSecret(DataPartType type)
    {
        return GetDescriptor(type).IsSecret;
    }

    /// <summary>
    /// Determines whether the specified type should be excluded from LLM input by default.
    /// </summary>
    /// <param name="type">The data part type.</param>
    /// <returns><see langword="true"/> when the type should be excluded from LLM input; otherwise <see langword="false"/>.</returns>
    public bool ShouldBeExcludedFromLlmInput(DataPartType type)
    {
        return GetDescriptor(type).ShouldBeExcludedFromLlmInput;
    }

    private static DataPartDescriptor Create(
        IDataPartDescriptorBuilder builder,
        DataPartType type,
        string name,
        string category,
        DataPartAgentContextAction defaultAgentContextAction,
        DataPartTransformationMode recommendedTransformation,
        DataPartTraits traits,
        string description)
    {
        return (DataPartDescriptor)builder
            .InitNew()
            .WithType(type)
            .WithName(name)
            .WithCategory(category)
            .WithDefaultAgentContextAction(defaultAgentContextAction)
            .WithRecommendedTransformation(recommendedTransformation)
            .WithTraits(traits)
            .WithDescription(description)
            .Build();
    }
}

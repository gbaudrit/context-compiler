namespace ContextCompiler.Abstractions.Pipelines.DataPart;

/// <summary>
/// Identifies a well-known atomic or quasi-atomic data fragment.
/// </summary>
/// <remarks>
/// Numeric ranges are reserved by category to keep the enum stable over time.
/// Root category entries occupy the start of each range and concrete sub-types
/// use the subsequent values inside the same reserved block.
/// </remarks>
public enum DataPartType
{
    /// <summary>
    /// Undefined or not yet classified content.
    /// </summary>
    Undefined = 0,

    // 0 - 999: generic content

    /// <summary>
    /// Generic text with no stronger semantic classification.
    /// </summary>
    Text = 1,

    /// <summary>
    /// Structured content represented as key/value pairs, records, or tables.
    /// </summary>
    StructuredData = 100,

    /// <summary>
    /// Source code or executable code-like content.
    /// </summary>
    Code = 200,

    /// <summary>
    /// Generic metadata such as headers, attributes, or annotations.
    /// </summary>
    Metadata = 300,

    /// <summary>
    /// Prompt-like content intended to instruct an AI system.
    /// </summary>
    Prompt = 400,

    /// <summary>
    /// Instructional content intended to drive behavior or execution.
    /// </summary>
    Instruction = 401,

    /// <summary>
    /// Instruction-like content coming from an untrusted or external source.
    /// </summary>
    UntrustedInstruction = 402,

    /// <summary>
    /// Prompt-like content coming from an untrusted or external source.
    /// </summary>
    UntrustedPrompt = 403,

    // 100000 - 199999: personal data

    /// <summary>
    /// Root category for personal data.
    /// </summary>
    PersonalData = 100000,

    /// <summary>
    /// A personal name without further precision.
    /// </summary>
    PersonalDataName = 100100,

    /// <summary>
    /// A given name.
    /// </summary>
    PersonalDataFirstName = 100101,

    /// <summary>
    /// A family name.
    /// </summary>
    PersonalDataLastName = 100102,

    /// <summary>
    /// A complete person name.
    /// </summary>
    PersonalDataFullName = 100103,

    /// <summary>
    /// An email address belonging to an identified or identifiable person.
    /// </summary>
    PersonalDataEmail = 100200,

    /// <summary>
    /// A personal phone number.
    /// </summary>
    PersonalDataPhoneNumber = 100300,

    /// <summary>
    /// A postal or street address.
    /// </summary>
    PersonalDataPostalAddress = 100400,

    /// <summary>
    /// A country linked to a person.
    /// </summary>
    PersonalDataCountry = 100410,

    /// <summary>
    /// A city linked to a person.
    /// </summary>
    PersonalDataCity = 100411,

    /// <summary>
    /// A precise geolocation or location coordinate associated with a person.
    /// </summary>
    PersonalDataGeolocation = 100420,

    /// <summary>
    /// A date of birth.
    /// </summary>
    PersonalDataBirthDate = 100500,

    /// <summary>
    /// An age value associated with a person.
    /// </summary>
    PersonalDataAge = 100501,

    /// <summary>
    /// A gender value associated with a person.
    /// </summary>
    PersonalDataGender = 100600,

    /// <summary>
    /// A nationality linked to a person.
    /// </summary>
    PersonalDataNationality = 100700,

    /// <summary>
    /// An organization or employer associated with a person.
    /// </summary>
    PersonalDataOrganization = 100710,

    /// <summary>
    /// A job title or role associated with a person.
    /// </summary>
    PersonalDataJobTitle = 100720,

    /// <summary>
    /// A personal identifier outside official identifier-specific ranges.
    /// </summary>
    PersonalDataIdentifier = 100800,

    /// <summary>
    /// A username or account handle.
    /// </summary>
    PersonalDataUsername = 100810,

    /// <summary>
    /// A public-facing profile handle or social identity.
    /// </summary>
    PersonalDataProfileHandle = 100820,

    /// <summary>
    /// An IP address that can relate to a person or household.
    /// </summary>
    PersonalDataIpAddress = 100900,

    /// <summary>
    /// A device or installation identifier linked to a person.
    /// </summary>
    PersonalDataDeviceIdentifier = 100910,

    // 200000 - 299999: sensitive personal data

    /// <summary>
    /// Root category for sensitive personal data.
    /// </summary>
    SensitivePersonalData = 200000,

    /// <summary>
    /// Health-related data.
    /// </summary>
    SensitivePersonalDataHealth = 200100,

    /// <summary>
    /// Biometric data used to identify a person.
    /// </summary>
    SensitivePersonalDataBiometric = 200200,

    /// <summary>
    /// Genetic data.
    /// </summary>
    SensitivePersonalDataGenetic = 200300,

    /// <summary>
    /// Religious or philosophical beliefs.
    /// </summary>
    SensitivePersonalDataReligion = 200400,

    /// <summary>
    /// Political opinion data.
    /// </summary>
    SensitivePersonalDataPoliticalOpinion = 200500,

    /// <summary>
    /// Trade union membership data.
    /// </summary>
    SensitivePersonalDataTradeUnionMembership = 200600,

    /// <summary>
    /// Data about a person's sex life.
    /// </summary>
    SensitivePersonalDataSexLife = 200700,

    /// <summary>
    /// Sexual orientation data.
    /// </summary>
    SensitivePersonalDataSexualOrientation = 200710,

    /// <summary>
    /// Racial or ethnic origin data.
    /// </summary>
    SensitivePersonalDataRacialOrEthnicOrigin = 200800,

    // 300000 - 399999: financial data

    /// <summary>
    /// Root category for financial data.
    /// </summary>
    FinancialData = 300000,

    /// <summary>
    /// Bank account information.
    /// </summary>
    FinancialDataBankAccount = 300100,

    /// <summary>
    /// International Bank Account Number.
    /// </summary>
    FinancialDataIban = 300110,

    /// <summary>
    /// Credit or payment card data.
    /// </summary>
    FinancialDataCreditCard = 300200,

    /// <summary>
    /// Transaction data or payment event details.
    /// </summary>
    FinancialDataTransaction = 300300,

    /// <summary>
    /// Invoice data.
    /// </summary>
    FinancialDataInvoice = 300400,

    /// <summary>
    /// Salary or compensation data.
    /// </summary>
    FinancialDataSalary = 300500,

    /// <summary>
    /// Tax identifier used in financial contexts.
    /// </summary>
    FinancialDataTaxIdentifier = 300600,

    // 400000 - 499999: official identifiers

    /// <summary>
    /// Root category for official identifiers.
    /// </summary>
    OfficialIdentifier = 400000,

    /// <summary>
    /// National identity number or equivalent.
    /// </summary>
    OfficialIdentifierNationalId = 400100,

    /// <summary>
    /// Passport number or document data.
    /// </summary>
    OfficialIdentifierPassport = 400200,

    /// <summary>
    /// Driver license number or document data.
    /// </summary>
    OfficialIdentifierDriverLicense = 400300,

    /// <summary>
    /// Social security number or equivalent social insurance identifier.
    /// </summary>
    OfficialIdentifierSocialSecurityNumber = 400400,

    /// <summary>
    /// Official tax identifier.
    /// </summary>
    OfficialIdentifierTaxId = 400500,

    // 500000 - 599999: secrets

    /// <summary>
    /// Root category for secrets.
    /// </summary>
    Secret = 500000,

    /// <summary>
    /// Password or passphrase.
    /// </summary>
    SecretPassword = 500100,

    /// <summary>
    /// API key or static access credential.
    /// </summary>
    SecretApiKey = 500200,

    /// <summary>
    /// OAuth or application client secret.
    /// </summary>
    SecretClientSecret = 500210,

    /// <summary>
    /// Shared secret used to validate webhook calls.
    /// </summary>
    SecretWebhookSecret = 500220,

    /// <summary>
    /// Access token.
    /// </summary>
    SecretAccessToken = 500300,

    /// <summary>
    /// Bearer token used directly for authorization.
    /// </summary>
    SecretBearerToken = 500301,

    /// <summary>
    /// Refresh token.
    /// </summary>
    SecretRefreshToken = 500310,

    /// <summary>
    /// JSON Web Token.
    /// </summary>
    SecretJwt = 500320,

    /// <summary>
    /// Session cookie or equivalent bearer session material.
    /// </summary>
    SecretSessionCookie = 500330,

    /// <summary>
    /// Connection string containing secrets or privileged endpoints.
    /// </summary>
    SecretConnectionString = 500400,

    /// <summary>
    /// Private key.
    /// </summary>
    SecretPrivateKey = 500500,

    /// <summary>
    /// Certificate or certificate bundle containing sensitive material.
    /// </summary>
    SecretCertificate = 500510,

    /// <summary>
    /// Encryption key material.
    /// </summary>
    SecretEncryptionKey = 500520,

    /// <summary>
    /// Signing key material used for signatures or token issuance.
    /// </summary>
    SecretSigningKey = 500521,

    /// <summary>
    /// SSH private or deploy key material.
    /// </summary>
    SecretSshKey = 500530,

    // 600000 - 699999: business sensitive data

    /// <summary>
    /// Root category for business-sensitive data.
    /// </summary>
    BusinessSensitiveData = 600000,

    /// <summary>
    /// Contractual documents or clauses.
    /// </summary>
    BusinessSensitiveDataContract = 600100,

    /// <summary>
    /// Internal strategic material.
    /// </summary>
    BusinessSensitiveDataInternalStrategy = 600200,

    /// <summary>
    /// Pricing, margins, or discount strategy data.
    /// </summary>
    BusinessSensitiveDataPricing = 600300,

    /// <summary>
    /// Proprietary source code.
    /// </summary>
    BusinessSensitiveDataSourceCode = 600400,

    /// <summary>
    /// Internal architecture documentation.
    /// </summary>
    BusinessSensitiveDataArchitecture = 600500,

    /// <summary>
    /// Customer list or customer relationship intelligence.
    /// </summary>
    BusinessSensitiveDataCustomerList = 600600,

    /// <summary>
    /// Supplier-specific sensitive data.
    /// </summary>
    BusinessSensitiveDataSupplierData = 600700,

    /// <summary>
    /// Product or company roadmap information.
    /// </summary>
    BusinessSensitiveDataRoadmap = 600800,

    // 700000 - 799999: AI-sensitive data

    /// <summary>
    /// Root category for AI- and model-sensitive data.
    /// </summary>
    AiSensitiveData = 700000,

    /// <summary>
    /// System prompt content.
    /// </summary>
    AiSensitiveDataSystemPrompt = 700100,

    /// <summary>
    /// Developer prompt or hidden orchestration prompt content.
    /// </summary>
    AiSensitiveDataDeveloperPrompt = 700110,

    /// <summary>
    /// Safety policy or runtime policy content used to constrain model behavior.
    /// </summary>
    AiSensitiveDataSafetyPolicy = 700120,

    /// <summary>
    /// Prompt template or reusable prompting asset.
    /// </summary>
    AiSensitiveDataPromptTemplate = 700130,

    /// <summary>
    /// Hidden instruction or concealed control content.
    /// </summary>
    AiSensitiveDataHiddenInstruction = 700200,

    /// <summary>
    /// Tool or function definition exposed to a model runtime.
    /// </summary>
    AiSensitiveDataToolDefinition = 700300,

    /// <summary>
    /// AI or model credential.
    /// </summary>
    AiSensitiveDataModelCredential = 700400,

    /// <summary>
    /// Retrieved context that should remain isolated from general prompts.
    /// </summary>
    AiSensitiveDataRetrievalContext = 700500,

    // 900000+: fallback

    /// <summary>
    /// Fallback category for data believed to be sensitive but not classified more precisely.
    /// </summary>
    UnknownSensitiveData = 900000,
}

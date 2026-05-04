# Standard security pack

`ContextCompiler.Packs.Security.Standard` bundles the standard security modules for ContextCompiler.

## Included modules

- **`ContextCompiler.Modules.Security`** - Core security reporting and artifact generation
- **`ContextCompiler.Modules.Security.Guards.Email`** - Email address obfuscation guard
- **`ContextCompiler.Modules.Security.Guards.DataPart`** - Data part filtering based on descriptor properties

## Overview

Use this pack when you want comprehensive security capabilities including:
- Email address detection and obfuscation
- Fine-grained data part filtering based on type, traits, and sensitivity
- Security audit reporting

## Configuration Example

### Email Guard (default enabled)
Automatically detects and obfuscates email addresses in content.

### DataPart Guard (requires configuration)
Filter data parts based on their descriptor properties:

```csharp
services.AddDataPartGuardModule(config =>
{
    // Exclude all personal data
    config.ExcludePersonalData = true;

    // Or be more specific
    config.ExcludedTypes.Add(DataPartType.PersonalDataEmail);
    config.ExcludedTypes.Add(DataPartType.PersonalDataPhone);

    // Exclude sensitive categories
    config.ExcludedCategories.Add("Credentials");

    // Exclude by traits
    config.ExcludedTraits = DataPartTraits.Secret | DataPartTraits.Confidential;
});
```

## See Also

- [Email Guard Module Documentation](../../Modules/ContextCompiler.Modules.Security.Guards.Email/README.md)
- [DataPart Guard Module Documentation](../../Modules/ContextCompiler.Modules.Security.Guards.DataPart/README.md)

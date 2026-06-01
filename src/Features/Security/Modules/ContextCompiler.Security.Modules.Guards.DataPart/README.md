# ContextCompiler.Modules.Security.Guards.DataPart

Security guard module that filters data parts based on their descriptor properties.

## Overview

This module provides fine-grained control over which data parts are included in the compilation context based on their `DataPartType` and associated descriptor metadata (traits, categories, sensitivity levels).

## Features

- **Type-based filtering**: Exclude specific `DataPartType` values
- **Category-based filtering**: Exclude entire categories of data
- **Trait-based filtering**: Filter by traits like `PersonalData`, `Sensitive`, `Confidential`
- **Agent context action filtering**: Set minimum required action levels
- **Shortcuts for common scenarios**: Quick toggles for personal data and sensitive data

## Configuration

```csharp
services.AddDataPartGuardModule(config =>
{
    // Exclude specific types
    config.ExcludedTypes.Add(DataPartType.PersonalDataEmail);
    config.ExcludedTypes.Add(DataPartType.PersonalDataPhone);
    
    // Exclude entire categories
    config.ExcludedCategories.Add("Credentials");
    
    // Require minimum agent context action
    config.MinimumAgentContextAction = DataPartAgentContextAction.Include;
    
    // Exclude by traits
    config.ExcludedTraits = DataPartTraits.Confidential | DataPartTraits.Secret;
    
    // Quick toggles
    config.ExcludePersonalData = true;  // Excludes all personal data
    config.ExcludeSensitiveData = true; // Excludes all sensitive data
});
```

## Use Cases

### GDPR Compliance
Exclude all personal data from being sent to AI agents:
```csharp
config.ExcludePersonalData = true;
```

### Security-Sensitive Environments
Exclude credentials and secrets:
```csharp
config.ExcludedTraits = DataPartTraits.Secret | DataPartTraits.Confidential;
config.ExcludedCategories.Add("Credentials");
config.ExcludedCategories.Add("Authentication");
```

### Minimal Context Strategy
Only include parts explicitly marked for agent context:
```csharp
config.MinimumAgentContextAction = DataPartAgentContextAction.AlwaysInclude;
```

## How It Works

1. For each `IDataPart`, the module retrieves its `IDataPartDescriptor` from the catalog
2. Applies filtering rules based on configuration
3. Excluded parts are removed from the data envelope
4. A finding is logged indicating the number of excluded parts

## Module Metadata

- **Name**: `security.guard.datapart`
- **Kind**: `Guard`
- **Priority**: `10`
- **Stage**: `ContentGuards`

## See Also

- `DataPartType` enumeration for all available types
- `IDataPartCatalog` for descriptor metadata
- `DataPartTraits` for trait flags

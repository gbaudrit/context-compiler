# ContextCompiler.Blueprints.Agile.UserStory

`ContextCompiler.Blueprints.Agile.UserStory` bundles the standard ContextCompiler packs and modules needed to write high-quality Agile User Stories.

## Includes

- `ContextCompiler.Packs.Starter.Standard`
- `ContextCompiler.Modules.Personas.Analysts.Business`
- `ContextCompiler.Modules.Prompt.Templates.Scriban`

## Use when

Use this blueprint when you want AI assistance to write or review Agile User Stories with:
- Proper "As a... I want... So that..." format
- INVEST criteria (Independent, Negotiable, Valuable, Estimable, Small, Testable)
- Clear acceptance criteria (Given/When/Then)
- Definition of Ready and Definition of Done
- Proper sizing and estimation guidance

## Features

This blueprint guides you through:
1. Identifying the user role and persona
2. Defining the feature/capability clearly
3. Articulating the business value
4. Writing acceptance criteria in Gherkin format
5. Validating against INVEST principles
6. Ensuring completeness with DoR/DoD checklists
7. Adding technical notes and dependencies
8. Sizing and estimating the story

## Example

```markdown
# User Story

**As a** registered customer  
**I want** to reset my password via email  
**So that** I can regain access to my account if I forget my password

## Acceptance Criteria

**Given** I am on the login page  
**When** I click "Forgot password?" and enter my email  
**Then** I receive an email with a password reset link valid for 1 hour

**Given** I click the reset link in the email  
**When** I enter a new valid password  
**Then** my password is updated and I can log in with the new password

## INVEST Validation
- ✅ **Independent**: Can be developed without dependencies on other stories
- ✅ **Negotiable**: Implementation details are flexible
- ✅ **Valuable**: Provides clear value to users who forget passwords
- ✅ **Estimable**: Team can estimate effort (3 story points)
- ✅ **Small**: Can be completed in one sprint
- ✅ **Testable**: Clear acceptance criteria can be tested
```

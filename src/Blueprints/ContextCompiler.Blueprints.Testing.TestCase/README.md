# ContextCompiler.Blueprints.Testing.TestCase

Blueprint for writing comprehensive, traceable, and executable test cases with clear preconditions, test steps, expected results, and full traceability to requirements.

## Features

- **Structured test case writing** with preconditions, test steps, expected results, and post-conditions
- **Complete traceability** between test cases and requirements
- **Positive and negative testing** coverage with boundary value analysis
- **Test data management** with realistic and representative values
- **Execution tracking** with pass/fail status and defect reporting
- **Test coverage analysis** and traceability matrix maintenance
- **Best practices** from testing standards and QA methodologies

## Blueprint Structure

### Objectives
- Write clear, complete, and testable test cases
- Ensure full traceability to requirements
- Cover positive, negative, and boundary scenarios
- Facilitate repeatable execution and results documentation
- Maintain up-to-date and reusable test case repository

### Constraints

**MUST:**
- Define unique identifier and descriptive title
- Specify all preconditions and test data
- Write clear, numbered, sequential test steps
- Define expected result for each step
- Maintain traceability matrix to requirements
- Use consistent naming conventions
- Assign priority and severity
- Document test data with expected values
- Include post-conditions

**MUST NOT:**
- Write vague or ambiguous test steps
- Omit expected results or use "should work"
- Ignore error scenarios and boundary cases
- Mix multiple scenarios in one test case
- Create dependent test cases
- Use unrealistic test values without justification
- Forget to update test cases after requirement changes

### Test Case Steps

1. **Identify test objective and associated requirement** - Link to source requirement
2. **Define test case ID and title** - Unique identifier with descriptive title
3. **Determine priority and severity** - Assign based on business impact
4. **Specify preconditions** - Define all setup requirements
5. **Prepare test data** - Document all input values (valid, invalid, boundary)
6. **Write test steps** - Clear, numbered, sequential actions
7. **Define expected results** - Precise, observable, verifiable outcomes
8. **Define post-conditions** - Specify final system state
9. **Categorize and tag** - Organize by functional area and test type
10. **Establish traceability** - Link to all covered requirements
11. **Review and validate** - Peer review for completeness
12. **Execute and document results** - Run test and record pass/fail with evidence
13. **Maintain and update** - Keep synchronized with requirement changes

### Commands

- `write-testcase` - Write a new complete test case
- `review-testcase` - Review existing test case for completeness
- `execute-testcase` - Execute test case and document results
- `update-results` - Update execution results and create defects
- `link-to-requirement` - Establish traceability to requirement
- `generate-coverage-report` - Generate requirement coverage report

## Integration

This blueprint integrates with the **Test Analyst persona module** (`ContextCompiler.Modules.Personas.Testers.Analyst`) which provides:
- QA best practices and testing standards
- Test design techniques (equivalence partitioning, boundary value analysis)
- Defect reporting guidelines
- Test management workflows

## Usage

Use this blueprint when you need to:
- Write new test cases for requirements or user stories
- Review and improve existing test cases
- Establish traceability between tests and requirements
- Execute tests and document results
- Maintain test case repository
- Generate test coverage reports

## Key Concepts

- **Test Case**: Document describing inputs, actions, conditions, and expected results
- **Precondition**: State that must be established before test execution
- **Test Step**: Specific action with expected result
- **Expected Result**: Predicted behavior or output
- **Actual Result**: Observed behavior during execution
- **Post-condition**: System state after test completion
- **Test Data**: Input values for test execution
- **Traceability Matrix**: Mapping between requirements and test cases
- **Positive Test**: Verifies correct behavior with valid data
- **Negative Test**: Verifies error handling with invalid data
- **Boundary Case**: Input at the edge of valid/invalid domains

## Best Practices

✅ **DO:**
- Keep test cases independent and atomic
- Use realistic and representative test data
- Capture evidence (screenshots, logs) on failure
- Review test cases with peers
- Update traceability matrix regularly
- Archive obsolete tests instead of deleting

❌ **DON'T:**
- Create implicit dependencies between test cases
- Skip negative and boundary testing
- Use production data without anonymization
- Mark test as pass if any step failed
- Write test cases without requirement links

## Example Test Case

```
ID: TC-LOGIN-001
Title: Verify user login with valid credentials

Priority: High
Severity: Critical

Requirement: REQ-AUTH-001 (User Authentication)

Preconditions:
- Application is accessible and running
- User account exists: username="testuser", password="Test@1234"
- User is not currently logged in

Test Data:
- Username: testuser
- Password: Test@1234

Test Steps:
1. Navigate to login page
   Expected: Login page displays with username and password fields

2. Enter username "testuser"
   Expected: Username appears in username field

3. Enter password "Test@1234"
   Expected: Password appears masked (dots or asterisks)

4. Click "Login" button
   Expected: System validates credentials and redirects to dashboard

5. Verify dashboard displays user name "Test User"
   Expected: Dashboard shows welcome message with user's name

Post-conditions:
- User session is active
- User is logged in as "testuser"
- Session cookie is created

Tags: smoke, regression, positive, authentication
Category: User Authentication
```

## License

Part of the ContextCompiler framework.

# SciLeadsQATechAssessment
This project automates the tests outlined in the test plan submission for the QA Lead assessment.  There were 35 test cases outlined in the original submission and all have been automated except the 4 listed below.  The reason for not automating these has also been provided.  There are a total of 41 tests included in the suite.  This is higher than the overal count as some tests scenarios in the manual test cases had to be split up into their own tests e.g. the different types of invalid passwords. 39 of these tests cover the UI based scenarios where as the remainig 2 test the API endpoints.  All tests have been created with C# and NUNit with the UI automated via Selenium and the API tests automated with the help of RestSharp.

## Tests not automated
 - LoginPage_LoginWithRememberMeNotSelected_CredentialsNotRememberedWhenLogBackIn - 'Remember Me' functionality outlined in storyboard was not implemented.
 - LoginPage_LoginWithRememberMeSelected_CredentialsRememberedWhenLogBackIn - 'Remember Me' functionality outlined in storyboard was not implemented.
 - ManageAccountEmail_EnterValidEmailThenConfirm_EmailUpdated - Could not quickly identify a way to regenerate the confirm email link with a valid token.
 - ManageAccountPassword_OldPasswordValidAndNewPasswordMatchAndSameAsLastPassword_ErrorDisplayed - No functionality was implemented to prevent this.

## Potential improvements
As this framework was developed over a short period there is a lot of scope for improvement.  It was felt it was more important to automate as many scanerios as possible rather than potentially spend time investigating enhancements that may not necessarily result in a substantial improvement to the delivered tests.  Delivering a complete, readable and maintaible suite was the priority.  Some of these potential areas for improvement are listed below:

- Replace user creation workflow with API based actions rather than UI.  Ivestigated the possibility of this, but couldn't identify how the RequestVerificationToken was generated.
- Abstract common properties and methods out of Page Objects.
- Abstract out loactors that are common between pages.
- Avoid need to pass in WebDriver explicity from the tests either via some Page Object provider or using Dependency Injection.
- Introduce a settings file so that properties such the base URL can be more easily changed.
- Replacing logging class with a fully implemented library tht supports writing to multiple sources e.g. Log4Net.
- Remove Thread.Sleep in CounterPage.Open().
- If more test scenarios were required for the API tests additional wrapper classes or abstractions could be created to help readbility.
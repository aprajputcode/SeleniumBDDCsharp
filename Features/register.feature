Feature: User Registration

Scenario: 001 Successful Registration
    Given user on the 'register' page
    When user enter the 'FirstName':'Automation'
    And user enter the 'Lastname':'Demo'
    And user enter the random 'EmailAddress':'automationtest@demo.com'
    And user enter the 'Password':'Test@123'
    And user enter the 'ConfirmPassword':'Test@123'
    And user click the 'CreateAccount' button
    Then user should see an 'AlertMessages':'Thank you for registering with Main Website Store.'
    And user should see the page title:'My Account'

  Scenario: 002 Registration with existing email
    Given user on the 'register' page
    When user enter the 'FirstName':'Automation'
    And user enter the 'Lastname':'Demo'
    And user enter the 'EmailAddress':'automationtest@demo.com'
    And user enter the 'Password':'Test@123'
    And user enter the 'ConfirmPassword':'Test@123'
    And user click the 'CreateAccount' button
    Then user should see an 'AlertMessages':'There is already an account with this email address. If you are sure that it is your email address'
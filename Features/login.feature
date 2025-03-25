Feature: User Login

  Scenario: 001 Successful Login
    Given user on the 'login' page
    When user enter the 'UserName':'automationtest@demo.com'
    And user enter the 'Password':'Test@123'
    And user click the 'SignIn' button
    Then user should see the page title:'My Account'

  Scenario: 002 Login with incorrect password
    Given user on the 'login' page
    When user enter the 'UserName':'automationtest@demo.com'
    And user enter the 'Password':'wrongPassword'
    And user click the 'SignIn' button
    Then user should see an 'AlertMessages':'The account sign-in was incorrect or your account is disabled temporarily. Please wait and try again later.'
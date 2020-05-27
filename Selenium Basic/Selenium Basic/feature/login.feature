Feature: Login
         As a user
         I want to open the application 
Scenario: Login and create
       Given I open url "http://localhost:5000/Account/Login?ReturnUrl=%2F"
       When I input login "user" and password "user"
       And I click the button login
       Then Titel of home page should be "Home page"

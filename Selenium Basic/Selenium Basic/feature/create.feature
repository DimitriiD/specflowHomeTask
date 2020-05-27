Feature: Create
         As a user
         I want to  creat new product
Scenario: Login and create
       Given I open url "http://localhost:5000/Account/Login?ReturnUrl=%2F"
       When I input login "user" and password "user"
       And I click the button login
       When I click on the line All Product
       Then Titel of new page should be "All Products"
       When I click button create new
       And I specify the following values ProductName "addfortest" Category "3" Supplier "4" UnitPrice "300" QuantityPerUnit "35"  UnitsInStock "1" UnitsOnOrder "1321" ReorderLevel "1" Discontinued "true"
       And I click the button send
       Then The new added product have the name "addfortest"

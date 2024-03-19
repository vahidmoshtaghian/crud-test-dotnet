Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@customer
Scenario: Operator creates a customer
	When first name is test1, lastname is test2, date of birth is 1990/01/01, phone number is 123456890, email is aa@bb.cc and bank account number is 00000000
	Then customer should be creatd
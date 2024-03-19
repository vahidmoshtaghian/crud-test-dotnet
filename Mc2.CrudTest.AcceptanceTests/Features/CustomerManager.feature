Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@customer
Scenario: Operator creates a customer
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, phone number is <phoneNumber>, email is <email> and bank account number is <acocuntNumber>
	Then customer should be created

	Examples: 
		| firstName | lastName | dateOfBirth | phoneNumber | email    | accountNumber |
		| test1     | test2    | 1990-05-10  | 123456890   | aa@bb.cc | 00000000      |
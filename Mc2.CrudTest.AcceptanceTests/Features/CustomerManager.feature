Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@customer
Scenario: Operator creates a customer
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, phone number is <phoneNumber>, email is <email> and bank account number is <acocuntNumber>
	Then customer should be created

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber | email       | accountNumber |
	| test1     | test2    | 1990-05-10  | 123456890   | aa@bb.cc    | 00000000      |
	| john      | due      | 1900-05-10  | 98766553214 | aa@bsdff.cc | 11111111      |

@customer
Scenario: Operator creates a customer with invalid email
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, phone number is <phoneNumber>, email is wrong like <email> and bank account number is <acocuntNumber>
	Then should throws email validation error

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber | email      | accountNumber |
	| test1     | test2    | 1990-05-10  | 123456890   | hjftgyhjtg | 00000000      |
	| test1     | test2    | 1990-05-10  | 123456890   | 321312     | 00000000      |
	
@customer
Scenario: Operator creates a customer with invalid phone number
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, wrong phone number is <phoneNumber>, email is <email> and bank account number is <acocuntNumber>
	Then should throws phone validation error

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber | email       | accountNumber |
	| test1     | test2    | 1990-05-10  | qwerdasdas  | aa@bb.cc    | 00000000      |
	| test1     | test2    | 1990-05-10  | 564         | aa@bsdff.cc | 00000000      |
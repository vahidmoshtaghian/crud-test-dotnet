Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@correct_input
Scenario: Operator creates a customer
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, phone number is <phoneNumber>, email is <email> and bank account number is <accountNumber>
	Then customer should be created

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber | email                    | accountNumber |
	| test1     | test2    | 1990-05-10  | 9417867452  | SonyaAHerrera@dayrep.com | 00000000      |
	| john      | due      | 1900-05-10  | 7206228815  | BerthaAEllis@teleworm.us | 11111111      |

@invalid_email
Scenario: Operator creates a customer with invalid email
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, phone number is <phoneNumber>, email is wrong like <email> and bank account number is <accountNumber>
	Then should throws email validation error

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber | email       | accountNumber |
	| test1     | test2    | 1990-05-10  | 9417867452  | hjftgyhjtg  | 222222        |
	| test3     | test4    | 1990-12-20  | 7206228815  | sdfdsfdsfsd | 3333333       |
	
@invalid_phone
Scenario: Operator creates a customer with invalid phone number
	When first name is <firstName>, lastname is <lastName>, date of birth is <dateOfBirth>, wrong phone number is <phoneNumber>, email is <email> and bank account number is <accountNumber>
	Then should throws phone validation error

Examples:
	| firstName | lastName | dateOfBirth | phoneNumber  | email                    | accountNumber |
	| test1     | test2    | 1990-05-10  | 564564654564 | SonyaAHerrera@dayrep.com | 00000000      |
	| test1     | test2    | 1990-05-10  | 564          | BerthaAEllis@teleworm.us | 00000000      |
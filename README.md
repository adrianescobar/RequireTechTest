# RequireTech Test

## Description

This is a little test project for a Require Technology interview

## How to navigate this project

This project answers the next list of requirements. The "how to use" is implemented in the test cases. 

*1. Create an class called Person, create the properties name and date of birth. Then, create an object based on Person class, call the constructor, and assign some values to those properties (use C#, Java or any backend language)*

 - [Person Class ](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam/Models/Person.cs)
- [Person Class Test](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam.Tests/Models/PersonTest.cs)

*2. Based on the previous exercise, create a function that returns the person's current age. Provide an example of how to use it.*

- [Person Class ](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam/Models/Person.cs)
- [Person Class Test](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam.Tests/Models/PersonTest.cs)

*3. Provide an example of Hierarchy. Implement a base class, and then, at least two, derived classes.* 

- [DeliveryMan](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam/Models/DeliveryMan.cs)
- [DeliveryManTest](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam.Tests/Models/DeliveryManTest.cs)
- [SalesPerson](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam/Models/SalesPerson.cs)
- [SalesPersonTest](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam.Tests/Models/SalesPersonTest.cs)

*4. Define an interface for database operations, including methods like Insert, Update, and Delete. Implement this interface in classes that interact with different types of databases (e.g., SqlServerDatabase, MySqlDatabase)*

*5. Using Entity Framework, set up a data model (you can use Person from previous exercises), and provide an example of Add a new person to the database, retrieve a person based on their ID, update the information, deleting the person.*

*6. Using Linq, provide the code to get the persons that the date of birth is January 1, 2011.*

- [Customer](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam/Models/Customer.cs)
- [All repository implementation](https://github.com/adrianescobar/RequireTechTest/tree/main/RequireTechTest.TechExam/Repositories)
- [Repository Test Cases](https://github.com/adrianescobar/RequireTechTest/blob/main/RequireTechTest.TechExam.Tests/Repositories/Implementations/CustomerRepositoryTest.cs)

*7. SQL: Create Person table, with auto-increment id, name, and date of birth. Assign the data types that satisfies the most for name, date of birth, and id values:*

*8. Consider a database with the following tables: 
`person` table: Columns: id, name, date_of_birth
`health_insurance` table: Columns: id, name, description
`person_health_insurance` table: person_id, insurance_id.
Provide a query to retrieve the persons with healthcare 'Optima'*

*9. Based on the previous tables, provide some indexing to those tables.*

- [Sql Server based scripts ](https://github.com/adrianescobar/RequireTechTest/tree/main/Resources/SqlServer)

## Run Test
After you clone this project and navigate to the root project, you can run the `dotnet test` command.

## NOTES
All this applies if you are not using Visual Studio. If you do, just run the test cases using the graphic interface :-).
# AGLPets
AGL Pets Coding Exercise

Consumes a JSON web service and outputs a list of all the cats in alphabetical order under a heading of the gender of their owner.

I have used a C# console application as the presentation layer to view results.

- A data layer loads the JSON using HttpClient 
- A repository layer accesses the data model and converts, groups and sorts to a Dictionary using LINQ
- Autofac is used for dependency injection 
- Moq is used to create mocks to test the repository with test data
- A separate test project contains repository tests and loading the data into the model
- Note that the data load tests are specific to the JSON data provided and only valid for this data


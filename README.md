# Funda.Assignment

I used a .NET 6 console app with the Clean Architecture for this solution.

### Console Project

The entry point is in the Console project - Program.cs.

I've set up a dependency injection container in order for the applicaiton to be easily testable and compatible with any other kind of project.
File is DependencyInjection.cs - where you can find the container being initialized with a logger, the configuration, the http client and the two other projects: Application and Infrastructure. 

### Application

 - The Application project contains the entry points to the business logic - the Services(or Use Cases). 
It also defines the interfaces for repositories that it needs in order to execute the business logic. This way it is fully independently testable from the infrastructure. You do not need any reference to the Infrastructure project in order to test it.

### Infrastructure

- The Infrastructure project is used to implement the interfaces that the Application needs. It also takes control of what implementations the Application uses. 
For example in this project, the Application needs IListingRepository. The Infrastructure project is "plugged in" and with it's DependencyInjection.cs file, and defines what implementations it wants the Application to use.
This makes it so that the Application is totally independent and is not concerned with the implemenations at all.  

### Domain

-The domain project contains the domain objects driving the Application.


### HttpListingRepository Implementation

- I've created two ways of doing the API calls, one is doing them in parallel, it fires off all the requests at the same time and waits for the results. The other one is doing it sequentially, after one request is done the next one will be fired. 

Depending on the intended usage of this project, one or the other can be used.

For example, if it's an overnight sync job it can be done sequentially as it will not put as much instant load on the API. Or if it's something that needs to happen fast, in the scope of a request - the parallel method can be used.

I tried changing the PageSize, but the API still returned 25 results, so if that is fixed, that is another parameter that can be "played" with.

Before running this in production I would look into the intentions and then play with parallel/sequential, pageSize and retry policy timeouts in order to optimize it for it's purpose.

For error handling and retries  I used Polly, you can see the policy defined in: Funda.Assignment.Danilo.Infrastructure\PollyPolicies\RetryPolicies.cs
It handles basic http errors - like 5xx, timeouts, 429(TooManyRequests), and because I noticed that the API returns 401 in case of too many requests, I added that one in too.
It is configured for 6 retry attempts, each 10 seconds longer than the last one.
This can be also made configurable and "played" with in order to optimize for production.

### Tests

- I've created unit tests for the Application for testability demonstration purposes, you can find them in the Tests solution folder. 
I used Bogus for fake data, Moq for mocking, xUnit as the actual test runner and FluentAssertions for cleaner asserts.

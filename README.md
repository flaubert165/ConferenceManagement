# Conference Manager

# The Problem

I've identified that the "Conference Track Management" is a variant of the 
well-known 1D Bin Packing Problem[1] of computational theory.

There are several approaches to solving it and that are subdivided into two 
categories: Analysis of Approximate Algorithms and Exact algorithms (Martello and Toth[2]).

I chose to implement a simple approach, the BestFit greedy algorithm. 

More details: https://en.wikipedia.org/wiki/Bin_packing_problem

# Technologies

.NET Core 2.0 - Console Application

# Design, Architecture and Application Structure

Even with all the time limitation, I tried to implement the best development 
practices and the best way.

## DDD - (Domain-Drive-Design)

All the layers of the application were modeled on the best practices imposed by 
Eric Evans, with my Domain layer being the heart of the solution. 
I also tried to use Ubiquitous Language as much as I proposed.

## TDD - (Test Driven Development)

As I do not have much practice, but I've studied a lot about TDD, I tried to 
implement all my tests before the development process as I preach their own 
principles, but one hour became unfeasible and I focused on finding an algorithm
to solve the problem. But I've implemented the test classes for practically 
all my classes in the domain.

## Design Patterns

I have used several GoF practices, some of them:

### Repository Pattern

### Factory Pattern

### Singleton Pattern ...

## Structure

The application has the following layers:

### ConferenceManagement.Application

The application flow starts at the ConferenceManagement.Application layer, where you will find a console application that will display the result of the file processing. I also have the file Startup.cs, where dependency injection of the required modules was used.

### ConferenceManagement.Common

Layer where you can find the Resources and Validations modules.

The resources module has the Messages.resx file, which contains all the messages
used in the system, allowing the application to be scalable at the 
Internationalization/Globalization level.

The module validations, in turn, have the class Guard.cs, which basically does 
some basic validations in the system. (we have the famous Utils or Helpers as 
an example).


### ConferenceManagement.Common.Tests

Layer responsible for unary testing of the Common modules.

### ConferenceManagement.Domain

The domain layer is the most complex of the application, since it had abstraction
 of all the entities raised in the proposed problem.

They were subdivided into:

#### Entities

Here are all entities in the application domain, their methods and behaviors.

#### Repositories

Here we have all interfaces / contracts to be implemented for access / persistence
of the appropriate data sources.

Example: To read the data file I used the ITalkRepository interface, implemented
in the ConferenceManagement.Infra layer.

#### Services

Here we have all interfaces / contracts to be implemented for processing and 
business rules.

Example: For processing data extracted from the file with the BestFit greedy 
algorithm, I used the IConferencePlannerService interface, which implements the 
BestFit approach in the GreedyBestFitApproach () method of the 
ConferencePlannerService.cs class in ConferenceManagement.Services.

Thus, at the scalability level, if it is necessary to implement another approach,
just use the IConferencePlannerService interface to do so.

### ConferenceManagement.Domain.Tests

Layer responsible for unary testing of the Domain modules.

### ConferenceManagement.Infra

The infrastructure layer is responsible for implementing low-level data access 
and APIs.

Example: To read the data file I used the ITalkRepository interface, implemented
in the ConferenceManagement.Infra layer.

### ConferenceManagement.Infra.Tests

Layer responsible for unary testing of the Infrastructure modules.

### ConferenceManagement.Services

The service layer is responsible for implementing business rules processing algorithm capabilities.

Example: For processing data extracted from the file with the BestFit greedy 
algorithm, I used the IConferencePlannerService interface, which implements the 
BestFit approach in the GreedyBestFitApproach () method of the 
ConferencePlannerService.cs class in ConferenceManagement.Services.

### ConferenceManagement.Services.Tests

Layer responsible for unary testing of the Services modules.

# Instructions to run application

1 - After opening the solution file "ConferenceManagement.sln" in Visual Studio,
select "Build" -> "Build Solution" menu option or select "Debug" -> "Start Debugging"
menu option in Visual Studio Code.

2 -  To process different data, simply access the "InputData" folder and modify
the contents of the "TestInput.txt" file.


References:

1 - Wikipedia: https://en.wikipedia.org/wiki/Bin_packing_problem#cite_note-12;

2 - Martello, Silvano; Toth, Paolo (1990), "Bin-packing problem" (PDF), Knapsack
    Problems: Algorithms and Computer Implementations, Chichester, UK: John Wiley 
    and Sons, ISBN 0471924202;


Thank you for the opportunity! I hope you enjoy it!

Kind Regards,

Italo Santana




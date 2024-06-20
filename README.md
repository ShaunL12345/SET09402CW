# SET09402CW
Repository For SET09402 Coursework

Coursework assignment
This assignment is designed to assess all four learning outcomes of the module:

Construct models of the problem domain and develop appropriate applications.
Manage the software artefacts of a project that incorporates quality metrics and practices.
Design test strategies using current technologies.
Engineer software systems in the full life cycle, particularly at the evolution stage.
Haulage scenario
A small haulage company has commissioned you to build a cross-platform application to help manage its operations. The company's business model is based on servicing a network of customers who exchange goods with each other. A supplier will request a pickup and delivery from the haulage company who will deliver the goods to the receiver. The haulage company therefore offers a business-to-business (B2B) service.

The company maintains a fleet of vehicles and a pool of drivers. Customers place pickup requests with an administrator who compiles a trip manifest (vehicle contents). The vehicle may visit several customers in a single trip, picking up and delivering as required. Thus the manifest changes throughout the trip, and keeping track of pickups and deliveries is a vital function.

There are three categories of goods that can be transported. Fragile items require inspection and sign-off by the receiver and dangerous items can only be transported by drivers who are suitably qualified. The third category includes all other items with no special requirements.

An initial requirements elicitation session has identified the following user stories that the application should include:

As a customer I want to

Manage my account
Manage my billing
Request a pickup/delivery
Track an item
Confirm item pickup/delivery 
As a driver I want to

Manage my trips
Record trip expenses
Confirm pickup/delivery
Report delays/emergencies
As an administrator I want to

Manage employees
Manage vehicles
Manage customers
Manage customer bills
Manage trip manifests
Plan trip routes
Resource trips (assign vehicles and drivers)
Track trip progress 
Requirements
The app will be built in C# MAUI to enable cross-platform operation. A central MSSQL database will be provided for data storage. Example data is provided for vehicles, employees and customers.

You will be working in a small team of three or four. The project will be managed using GitHub for code control and task management.

Each member of the team is assessed individually according to their contribution to the project. There is no group element to the marking.

Each team member must complete three separate development tasks related to the user stories provided, one for each of the actors - customer, driver and administrator.

For each task, you must

Elaborate the requirement, possibly in consultation with the rest of the team, and document the elaboration in a GitHub issue. (LO4)
Produce an appropriate model in UML format. This may involve creating entirely new documentation or updating existing documentation. All documentation must be version controlled. (LO1)
Develop the code for the new features using .NET MAUI. (LO1)
Implement unit tests for your user stories. (LO3)
Document the quality of your code using appropriate metrics. (LO2)
Use an appropriate workflow that includes branching, pull requests and code reviews. (LO2)
Respond to any request for change as a result of a code review. (LO2)
In addition you must:

Document the team's branching strategy to explain how it can support urgent bug fixes as well as development work towards a new release of the application. (LO4)
Carry out three code reviews for other people on the team. (LO2)
Please note
The purpose of the project is not to deliver a fully-working system. Instead, it is to demonstrate your software engineering skills in the context of an ongoing project.

Submission
You must submit a single pdf file that documents your work on the three issues. The document should include descriptive text and diagrams where required with links to items in the team's GitHub repository where you need to refer to code. The recommended structure is as follows.

Introduction (400 - 500 words)
Brief overview of the application's purpose structure and any general conventions that the team has adopted.
List the members of your team.
Description of the team's workflow and branching strategy. Include a link to the team's GitHub project.
Issue 1 (400 - 1000 words excluding diagrams)
Summary of the issue, how it relates to the original user story and its elaboration. Include a link to the issue in GitHub.
Your UML diagrams related to the issue with any additional commentary needed to clarify the contents. Include links to the documentation in the repository.
Describe the purpose of each of the code files related to the issue and any pertinent detail such as whether it implements a recognised design pattern, how it adheres to good software engineering principles and what conventions you have adopted to optimise readability and maintainability. Include a link to each code file in the repository.
Summarise the unit tests that have been written. Provide links to each test in the repository.
Describe any changes that you made in response to a code review.
Issue 2
As above
Issue 3
As above
Code review 1 (400 - 500 words)
Summarise the strengths and weaknesses of the code that you reviewed. Include a link to the issue in GitHub.
Code review 2
As above
Code review 3
As above
Marking scheme
Construct models of the problem domain and develop appropriate applications.
25%

This element reflects the quality of your modelling and coding work. The application of good practices in their development will increase the mark. Obvious errors or missing aspects will decrease the mark.

Manage the software artefacts of a project that incorporates quality metrics and practices.
25%

This element reflects the quality of the processes you have adopted in your work including those agreed with the rest of the team and those you have adopted on your own initiative. It also reflects your understanding and application of quality metrics. Good attention to detail will increase the mark. Cutting corners or omitting expected activities will decrease the mark.

Design test strategies using current technologies.
20%

This element reflects the quality of your unit testing skills. Implementing important tests for your issue will increase the mark. Important features with missing tests and obvious errors in the implemented tests will decrease the mark.

Engineer software systems in the full life cycle, particularly at the evolution stage.
15%

This element reflects the quality of your skills in requirements engineering and your understanding of change control. Good attention to detail and clear explanations will increase the mark. Development that is not underpinned by thorough analysis and lack of clarity will decrease the mark.

Demonstration
15%

At the end of the module, you must demonstrate your contributions to the team's application using your coursework report as a structure. Your demonstration will last no longer than 20 minutes, so you must prepare well to cover all relevant details within the time available. The demonstration is mandatory - without it, your work will not be marked. There are 15 marks available for the demonstration itself reflecting the preparation and clarity of delivery.

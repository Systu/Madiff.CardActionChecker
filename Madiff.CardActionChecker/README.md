# Card Action Checker

A .NET 8 API service that determines allowed actions for payment cards based on card type and user information.

## Overview

This application provides a RESTful API endpoint that allows clients to check what actions are permitted for a specific payment card. The system uses a factory pattern to create appropriate card objects based on card details.

## Architecture

- **API Layer**: Minimal API built with ASP.NET Core 8
- **Application Layer**: Contains the business logic for card action determination
- **Factory Pattern**: Creates appropriate card objects based on card details

## Endpoints

### Get Allowed Actions

GET /allowed-actions/{userId}/{cardNumber}


Returns a list of actions that can be performed with the specified card.

**Parameters**:
- `userId`: The ID of the user who owns the card
- `cardNumber`: The card number to check

**Response**:
- 200 OK: Returns a list of allowed actions
- 404 Not Found: When the specified card cannot be found

## Development

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or other compatible IDE

### Running the Application

1. Clone the repository
2. Open the solution in Visual Studio
3. Press F5 to run the application

The API will be available at `https://localhost:<port>/` with Swagger documentation at `/swagger`.

## Implementation Details

The application uses a sample in-memory database of card details. In a production environment, this would be replaced with a real database connection.

Card actions are determined based on card type and other attributes using a polymorphic approach through the card factory pattern.

## Extensibility

The project can be extended by implementing additional card types and corresponding action determination logic. This can be achieved by creating new classes that inherit from the base card class
and updating the factory pattern to include these new card types.

To add a new card type:
1. Create a new class that inherits from `Card`
2. Implement the 'ModifyStatusAllowedActionsByCardKind' if needed to change StatusHandler allowed actions
3. Add new Card Type to CardType enum
3. Add a new case to the `CreateCard` method in the `CardFactory` class

To add a new card status:
1. Create a new class that implement  `ICardStatusHandler`
2. Add new Card Status to CardStatus enum


## Testing

The project includes unit tests to ensure the correctness of the card action determination logic. These tests can be run using the built-in test runner in Visual Studio or the `dotnet test` command.

### Running Tests

1. Open the solution in Visual Studio
2. Open the Test Explorer (Test > Test Explorer)
3. Click "Run All" to execute all tests
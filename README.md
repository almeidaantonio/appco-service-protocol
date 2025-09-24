# Appco.ServiceProtocol

A library for standardized service responses in .NET applications, providing consistent status and content handling for API and service layers.

## Installation

Install via NuGet Package Manager:
`Install-Package Appco.ServiceProtocol`

Or using the .NET CLI:
`dotnet add package Appco.ServiceProtocol`

## Requirements

- .NET 9 or later

## Usage

Import the namespace in your service or controller:
`using Appco.ServiceProtocol;`

## Exemples
```C#
	// Example 1: Internal error response without content
	var internalErrorResponse = InternalError("An unexpected error occurred.");
	// internalErrorResponse.Status is StatusInternalError, Message = "An unexpected error occurred."

	// Example 2: Internal error response with content
	var internalErrorWithContent = InternalError("Database failure.", "Error details here");
	// internalErrorWithContent.Status is StatusInternalError, Message = "Database failure."
	// internalErrorWithContent.Content = "Error details here"

	// Example 3: Not found response
	var notFoundResponse = NotFound("User not found.");
	// notFoundResponse.Status is StatusNotFound, Message = "User not found."

	// Example 4: Not found response with content
	var notFoundWithContent = NotFound("Order not found.", 12345);
	// notFoundWithContent.Status is StatusNotFound, Message = "Order not found."
	// notFoundWithContent.Content = 12345

	// Example 5: Success response (OK)
	var okResponse = Ok();
	// okResponse.Status is StatusOk, Message = "Ok."

	// Example 6: Success response (OK) with custom message
	var okWithMessage = Ok("Operation completed successfully.");
	// okWithMessage.Status is StatusOk, Message = "Operation completed successfully."

	// Example 7: Success response (OK) with content
	var okWithContent = Ok("Data loaded.", "Sample data");
	// okWithContent.Status is StatusOk, Message = "Data loaded."
	// okWithContent.Content = "Sample data"

	// Example 8: Created response
	var createdResponse = Created("Resource created.");
	// createdResponse.Status is StatusCreated, Message = "Resource created."

	// Example 9: Updated response with content
	var updatedWithContent = Updated("Resource updated.", "Updated value");
	// updatedWithContent.Status is StatusUpdated, Message = "Resource updated."
	// updatedWithContent.Content = "Updated value"

	// Example 10: Deleted response
	var deletedResponse = Deleted("Resource deleted.");
	// deletedResponse.Status is StatusDeleted, Message = "Resource deleted."
```

## License

This project is licensed under the MIT License.

## Support

For questions or issues, please open an issue on the repository or contact the maintainers.
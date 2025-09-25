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

### Service class
```C#
/// Represents a simple resource with a name property.
/// Used as an example entity for service operations.
public class ExempleResource
{
    public string Name { get; set; } = string.Empty;
}

/// Example service demonstrating basic resource management operations.
/// This class provides sample implementations for adding, retrieving, and checking resources.
public class ExempleService : BaseService
{
    // In-memory list to store example resources.
    private readonly List<ExempleResource> _resources = [];

    /// Adds a new resource to the service.
    /// Demonstrates validation and creation response.
    public ServiceResponse<int> AddResource(ExempleResource resource)
    {
        // Example of input validation: checks if the resource name is empty.
        if (string.IsNullOrWhiteSpace(resource.Name))
            return InvalidSchema<int>("Empty name.");

        _resources.Add(resource);

        // Returns a created response with the total number of resources.
        return Created("Resource added successfully.", _resources.Count);
    }

    /// Retrieves a resource by its index.
    /// Demonstrates not found and success responses.
    public ServiceResponse<ExempleResource> GetById(int id)
    {
        // Example of bounds checking: returns not found if the index is out of range.
        if (id > _resources.Count)
            return NotFound<ExempleResource>("Id not found.");

        // Returns the found resource.
        return Ok("Resource found successfully.", _resources[id]);
    }

    /// Checks if a resource exists by its index.
    /// Demonstrates not found and success responses without returning the resource.
    public ServiceResponse IdExists(int id)
    {
        // Example of existence check: returns not found if the index is out of range.
        if (id > _resources.Count)
            return NotFound("Id not found.");

        // Returns a success response if the resource exists.
        return Ok($"Resource number {id} found");
    }

    public ServiceResponse Update(int id, ExempleResource resource)
    {
        _resources[id] = resource;
        return Updated("Resource updated successfully.");
    }
}
```

### Controller adapter (based on `Microsoft.AspNetCore.Mvc`)
```c#

[ApiController]
public class ExempleController(ExempleService service) : ControllerBase
{
    private readonly ExempleService _service = service;

	[HttpPost("/exemple")]
	public ObjectResult AddResource([FromBody] ExempleResource resource) =>
		Adapt(_service.AddResource(resource));

	[HttpGet("/exemple/{id}/exists")]
	public ObjectResult IdExists(int id) => Adapt(_service.IdExists(id));

	[HttpGet("/exemple/{id}")]
	public ObjectResult GetById(int id) => Adapt(_service.GetById(id));

	[HttpPut("/exemple/{id}")]
	public ObjectResult Update(int id, [FromBody] ExempleResource resource)
	{
		var checkIdExistsResponse = _service.IdExists(id);

		if (!checkIdExistsResponse.Status.Success())
			return Adapt(checkIdExistsResponse);

		return Adapt(_service.Update(id, resource));
	}

	public ObjectResult Adapt<TContent>(ServiceResponse<TContent> serviceResponse)
	{
		return StatusCode(serviceResponse.Status.HttpStatusCode(), new
		{
			StatusMessage = serviceResponse.Status.Message,
			serviceResponse.Content,
		});
	}

	public ObjectResult Adapt(ServiceResponse serviceResponse)
	{
		return StatusCode(serviceResponse.Status.HttpStatusCode(), new
		{
			StatusMessage = serviceResponse.Status.Message,
		});
	}
}
```


## License

This project is licensed under the MIT License.

## Support

For questions or issues, please open an issue on the repository or contact the maintainers.
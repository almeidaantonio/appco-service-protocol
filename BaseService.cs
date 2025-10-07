namespace Appco.ServiceProtocol;

/// <summary>
/// Provides static helper methods to build standardized <see cref="ServiceResponse"/> and <see cref="ServiceResponse{TContent}"/>
/// objects for common service operation results, such as errors and success states.
/// </summary>
public class BaseService
{
    /// <summary>
    /// Builds a <see cref="ServiceResponse"/> with the specified <see cref="Status"/>.
    /// </summary>
    /// <param name="status">The status to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse"/> containing the given status.</returns>
    private static ServiceResponse BuildResponse(Status status) => new()
    {
        Status = status,
    };

    /// <summary>
    /// Builds a <see cref="ServiceResponse{TContent}"/> with the specified <see cref="Status"/>.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="status">The status to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> containing the given status and content.</returns>
    private static ServiceResponse<TContent> BuildResponse<TContent>(Status status) => new()
    {
        Status = status,
    };

    /// <summary>
    /// Builds a <see cref="ServiceResponse{TContent}"/> with the specified <see cref="Status"/> and content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="status">The status to include in the response.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> containing the given status and content.</returns>
    private static ServiceResponse<TContent> BuildResponse<TContent>(Status status, TContent content) => new()
    {
        Status = status,
        Content = content,
    };

    /// <summary>
    /// Builds a <see cref="ServiceResponse{TContent}"/> with the specified <see cref="Status"/> and content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="status">The status to include in the response.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <param name="count">Pagination count.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> containing the given status and content.</returns>
    private static ServiceResponse<TContent> BuildResponse<TContent>(Status status, TContent content, int count) => new()
    {
        Status = status,
        Content = content,
        Count = count,
    };

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing an internal error.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with internal error status.</returns>
    public static ServiceResponse InternalError(string message) =>
        BuildResponse(new StatusInternalError { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing an internal error with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with internal error status and content.</returns>
    public static ServiceResponse<TContent> InternalError<TContent>(string message) =>
        BuildResponse<TContent>(new StatusInternalError { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a not found error.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with not found status.</returns>
    public static ServiceResponse NotFound(string message) =>
        BuildResponse(new StatusNotFound { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a not found error with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with not found status and content.</returns>
    public static ServiceResponse<TContent> NotFound<TContent>(string message) =>
        BuildResponse<TContent>(new StatusNotFound { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing an invalid schema error.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with invalid schema status.</returns>
    public static ServiceResponse InvalidSchema(string message) =>
        BuildResponse(new StatusInvalidSchema { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing an invalid schema error with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with invalid schema status and content.</returns>
    public static ServiceResponse<TContent> InvalidSchema<TContent>(string message) =>
        BuildResponse<TContent>(new StatusInvalidSchema { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a forbidden error.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with forbidden status.</returns>
    public static ServiceResponse Forbidden(string message) =>
        BuildResponse(new StatusForbidden { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a forbidden error with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with forbidden status and content.</returns>
    public static ServiceResponse<TContent> Forbidden<TContent>(string message) =>
        BuildResponse<TContent>(new StatusForbidden { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a conflict error.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with conflict status.</returns>
    public static ServiceResponse Conflict(string message) =>
        BuildResponse(new StatusConflict { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a conflict error with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with conflict status and content.</returns>
    public static ServiceResponse<TContent> Conflict<TContent>(string message) =>
        BuildResponse<TContent>(new StatusConflict { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a successful operation.
    /// </summary>
    /// <returns>A <see cref="ServiceResponse"/> with OK status.</returns>
    public static ServiceResponse Ok() => BuildResponse(new StatusOk { Message = "Ok." });

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a successful operation with a custom message.
    /// </summary>
    /// <param name="message">The success message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with OK status and message.</returns>
    public static ServiceResponse Ok(string message) => BuildResponse(new StatusOk { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a successful operation with a custom message and content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The success message.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with OK status, message, and content.</returns>
    public static ServiceResponse<TContent> Ok<TContent>(string message, TContent content) =>
        BuildResponse(new StatusOk { Message = message }, content);

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a successful operation with a custom message and content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The success message.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <param name="count">Content pagination count.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with OK status, message, and content.</returns>
    public static ServiceResponse<TContent> Ok<TContent>(string message, TContent content, int count) =>
        BuildResponse(new StatusOk { Message = message }, content, count);

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a resource creation operation.
    /// </summary>
    /// <param name="message">The creation message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with created status and message.</returns>
    public static ServiceResponse Created(string message) => BuildResponse(new StatusCreated { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a resource creation operation with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The creation message.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with created status, message, and content.</returns>
    public static ServiceResponse<TContent> Created<TContent>(string message, TContent content) => BuildResponse(new StatusCreated { Message = message }, content);

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a resource update operation.
    /// </summary>
    /// <param name="message">The update message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with updated status and message.</returns>
    public static ServiceResponse Updated(string message) => BuildResponse(new StatusUpdated { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a resource update operation with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The update message.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with updated status, message, and content.</returns>
    public static ServiceResponse<TContent> Updated<TContent>(string message, TContent content) => BuildResponse(new StatusUpdated { Message = message }, content);

    /// <summary>
    /// Creates a <see cref="ServiceResponse"/> representing a resource deletion operation.
    /// </summary>
    /// <param name="message">The deletion message.</param>
    /// <returns>A <see cref="ServiceResponse"/> with deleted status and message.</returns>
    public static ServiceResponse Deleted(string message) => BuildResponse(new StatusDeleted { Message = message });

    /// <summary>
    /// Creates a <see cref="ServiceResponse{TContent}"/> representing a resource deletion operation with content.
    /// </summary>
    /// <typeparam name="TContent">The type of the content.</typeparam>
    /// <param name="message">The deletion message.</param>
    /// <param name="content">The content to include in the response.</param>
    /// <returns>A <see cref="ServiceResponse{TContent}"/> with deleted status, message, and content.</returns>
    public static ServiceResponse<TContent> Deleted<TContent>(string message, TContent content) => BuildResponse(new StatusDeleted { Message = message }, content);

}

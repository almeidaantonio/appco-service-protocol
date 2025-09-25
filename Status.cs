namespace Appco.ServiceProtocol;

/// <summary>
/// Represents the base status for service protocol responses.
/// Provides methods to retrieve status information, messages, and HTTP status codes.
/// </summary>
public class Status
{
    /// <summary>
    /// Gets the status code for the response.
    /// </summary>
    /// <returns>
    /// The <see cref="EStatus"/> value representing the status.
    /// Default is <see cref="EStatus.InternalError"/>.
    /// </returns>
    public virtual EStatus GetStatus() => EStatus.InternalError;

    /// <summary>
    /// Gets or sets the message associated with the status.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Determines whether the status is considered successful.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the status is greater than or equal to <see cref="EStatus.OK"/>; otherwise, <c>false</c>.
    /// </returns>
    public bool Success() => GetStatus() >= EStatus.OK;

    /// <summary>
    /// Gets the corresponding HTTP status code for the current status.
    /// </summary>
    /// <returns>
    /// An <see cref="int"/> representing the HTTP status code.
    /// </returns>
    public int HttpStatusCode() => GetStatus() switch
    {
        EStatus.InternalError => 500,
        EStatus.NotFound => 404,
        EStatus.InvalidSchema => 400,
        EStatus.Forbidden => 403,
        EStatus.Conflict => 409,
        EStatus.OK => 200,
        EStatus.Created => 201,
        EStatus.Updated => 204,
        EStatus.Deleted => 204,
        _ => 500,
    };
}

/// <summary>
/// Represents a status indicating an internal error.
/// </summary>
public class StatusInternalError : Status { }

/// <summary>
/// Represents a status indicating an invalid schema.
/// </summary>
public class StatusInvalidSchema : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.InvalidSchema;
}

/// <summary>
/// Represents a status indicating a successful operation.
/// </summary>
public class StatusOk : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.OK;
}

/// <summary>
/// Represents a status indicating a resource was created.
/// </summary>
public class StatusCreated : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.Created;
}

/// <summary>
/// Represents a status indicating a resource was updated.
/// </summary>
public class StatusUpdated : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.Updated;
}

/// <summary>
/// Represents a status indicating a resource was deleted.
/// </summary>
public class StatusDeleted : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.Deleted;
}

/// <summary>
/// Represents a status indicating a resource was not found.
/// </summary>
public class StatusNotFound : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.NotFound;
}

/// <summary>
/// Represents a status indicating access is forbidden.
/// </summary>
public class StatusForbidden : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.Forbidden;
}

/// <summary>
/// Represents a status indicating a conflict occurred.
/// </summary>
public class StatusConflict : Status
{
    /// <inheritdoc/>
    public override EStatus GetStatus() => EStatus.Conflict;
}

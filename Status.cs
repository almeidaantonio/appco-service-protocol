namespace Appco.ServiceProtocol;

public class Status
{
    public virtual EStatus GetStatus() => EStatus.InternalError;

    public string Message { get; set; } = string.Empty;

    public bool Success() => GetStatus() >= EStatus.OK;

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

public class StatusInternalError : Status { }

public class StatusInvalidSchema : Status
{
    public override EStatus GetStatus() => EStatus.InvalidSchema;
}

public class StatusOk : Status
{
    public override EStatus GetStatus() => EStatus.OK;
}

public class StatusCreated : Status
{
    public override EStatus GetStatus() => EStatus.Created;
}

public class StatusUpdated : Status
{
    public override EStatus GetStatus() => EStatus.Updated;
}

public class StatusDeleted : Status
{
    public override EStatus GetStatus() => EStatus.Deleted;
}

public class StatusNotFound : Status
{
    public override EStatus GetStatus() => EStatus.NotFound;
}

public class StatusForbidden : Status
{
    public override EStatus GetStatus() => EStatus.Forbidden;
}

public class StatusConflict : Status
{
    public override EStatus GetStatus() => EStatus.Conflict;
}

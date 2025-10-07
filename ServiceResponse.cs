namespace Appco.ServiceProtocol;

public class ServiceResponse
{
    public required Status Status { get; init; }
}

public class ServiceResponse<TContent> : ServiceResponse
{
    public TContent? Content { get; set; }
    public int Count { get; set; }
}

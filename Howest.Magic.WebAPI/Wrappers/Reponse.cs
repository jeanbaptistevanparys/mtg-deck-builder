namespace Howest.MagicCards.WebAPI.Wrappers;

public class Response<T>
{
    public Response() : this(default)
    {
    }

    public Response(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
    public bool Succeeded { get; set; } = true;
    public string[]? Errors { get; set; }
    public string Message { get; set; } = string.Empty;
}
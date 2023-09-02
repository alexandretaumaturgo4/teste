namespace Backoffice.Application.Services.Base;

public class BaseResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    private string Mensagem { get; set; }

    public BaseResponse(bool success, T data, string mensagem = null)
    {
        Success = success;
        Data = data;
        Mensagem = mensagem;
    }
}

public class BaseResponse
{
    public bool Success { get; set; }
    public string Mensagem { get; set; }

    public BaseResponse(bool success, string mensagem = null)
    {
        Success = success;
        Mensagem = mensagem;
    }
}
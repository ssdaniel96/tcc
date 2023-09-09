namespace Application.Shared.Dtos;

public record ResponseDto
{
    public bool IsSuccessfully { get; init; }
    public bool IsFailed => !IsSuccessfully;
    
    public object? Data { get; init; }
    public string? Error { get; init; }

    public ResponseDto()
    {
        
    }
    
    public ResponseDto(object data)
    {
        IsSuccessfully = true;
        Data = data;
    }

    public ResponseDto(Exception error)
    {
        IsSuccessfully = false;
        Error = error.Message;
    }
}

public record ResponseDto<T>
{
    public bool IsSuccessfully { get; init; }
    public bool IsFailed => !IsSuccessfully;
    
    public T? Data { get; init; }
    public string? Error { get; init; }

    public ResponseDto()
    {
        
    }
    
    public ResponseDto(T data)
    {
        IsSuccessfully = true;
        Data = data;
    }

    public ResponseDto(Exception error)
    {
        IsSuccessfully = false;
        Error = error.Message;
    }
}
namespace Domain.Repositories.Dtos;

public record PageRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public int GetRecordsCountToSkip() => (PageNumber - 1) * PageSize;

    public PageRequest()
    {
        
    }

    public PageRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
} 
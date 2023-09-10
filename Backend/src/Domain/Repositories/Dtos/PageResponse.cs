namespace Domain.Repositories.Dtos;

public record PageResponse<T>
{
    public int TotalRows { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int ItemsSize => Data.Count();
    public IEnumerable<T> Data { get; init; }

    public PageResponse(IEnumerable<T> data, int pageNumber, int totalRows, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        TotalRows = totalRows;
        PageSize = pageSize;
    }
}
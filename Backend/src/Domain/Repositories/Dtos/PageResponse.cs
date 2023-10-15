namespace Domain.Repositories.Dtos;

public record PageResponse<T>
{
    public int TotalRows { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int ItemsSize => Data.Count();
    public IEnumerable<T> Data { get; init; }

    public PageResponse(IEnumerable<T> data, PageRequest pageRequest, int totalRows)
    {
        Data = data;
        PageNumber = pageRequest.PageNumber;
        PageSize = pageRequest.PageSize;
        TotalRows = totalRows;
    } 
    
    public PageResponse(IEnumerable<T> data, int pageNumber, int totalRows, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        TotalRows = totalRows;
        PageSize = pageSize;
    }
}
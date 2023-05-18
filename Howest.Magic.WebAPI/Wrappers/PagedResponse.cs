namespace Howest.MagicCards.WebAPI.Wrappers;

public class PagedResponse<T> : Response<T>
{
    public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
        TotalRecords = totalRecords;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }

    public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

    
}
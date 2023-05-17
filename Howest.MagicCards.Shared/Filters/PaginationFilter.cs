namespace Howest.MagicCards.Shared.Filters;

public class PaginationFilter
{
    private const int _maxPageSize = 150;
    private int _pageNumber = 1;

    private int _pageSize = _maxPageSize;

    public int MaxPageSize { get; set; } = _maxPageSize;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize > MaxPageSize ? MaxPageSize : _pageSize;
        set => _pageSize = value > MaxPageSize || value < 1 ? MaxPageSize : value;
    }
}
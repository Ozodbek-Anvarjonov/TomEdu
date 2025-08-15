using TomEdu.Application.Common.Filters;

namespace TomEdu.Application.Common.Responses;

public class PaginationMetaData
{
    public PaginationMetaData(int totalCount, PaginationFilter filter)
    {
        TotalPages = Convert.ToInt32(Math.Ceiling(totalCount / (decimal)filter.PageSize));
        CurrentPage = filter.PageNumber;
    }

    public int TotalPages { get; set; }

    public int CurrentPage { get; set; }

    public bool HasPrevious => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;
}
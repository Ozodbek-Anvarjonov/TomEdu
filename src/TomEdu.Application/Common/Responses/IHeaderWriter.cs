namespace TomEdu.Application.Common.Responses;

public interface IHeaderWriter
{
    void WritePaginationMetaData(PaginationMetaData paginationMetaData);
}
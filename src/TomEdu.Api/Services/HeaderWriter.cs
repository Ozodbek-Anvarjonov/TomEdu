using Newtonsoft.Json;
using TomEdu.Application.Common.Responses;

namespace TomEdu.Api.Services;

public class HeaderWriter(IHttpContextAccessor contextAccessor) : IHeaderWriter
{
    public void WritePaginationMetaData(PaginationMetaData paginationMetaData)
    {
        if (paginationMetaData is null) return;

        var json = JsonConvert.SerializeObject(paginationMetaData);
        var headers = contextAccessor.HttpContext?.Response?.Headers;

        headers?.Remove("X-Pagination");
        headers?.Add("X-Pagination", json);
    }
}
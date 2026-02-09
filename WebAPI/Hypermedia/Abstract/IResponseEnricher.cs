using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext constext);
        Task Enrich(ResultExecutingContext constext);
    }
}

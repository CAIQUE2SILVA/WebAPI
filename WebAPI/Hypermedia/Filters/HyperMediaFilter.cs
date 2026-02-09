using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Hypermedia.Filters
{
    public class HyperMediaFilter (HyperMediaFilterOptions
        hyperMediaFilterOptions): ResultFilterAttribute

    {
        private readonly HyperMediaFilterOptions _hypermediaFilterOptions = hyperMediaFilterOptions;

        public void OnResultExecuted(ResultExecutingContext context)
        {
            TryErinchResult(context);
            base.OnResultExecuting(context);
        }

        private void TryErinchResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = _hypermediaFilterOptions
                    .ContentResponseEnricherList
                    .FirstOrDefault(options => options.CanEnrich(context));
                enricher?.Enrich(context).Wait();
            }
        }
    }
}

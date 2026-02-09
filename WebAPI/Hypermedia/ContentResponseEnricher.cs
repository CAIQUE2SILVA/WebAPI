using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using WebAPI.Hypermedia.Abstract;

namespace WebAPI.Hypermedia
{
    public abstract class ContentResponseEnricher<T>
        : IResponseEnricher where T : IsuportsHypermedia
    {
        public bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T)
                || contentType == typeof(List<T>);

        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult objectResult)
            {
                return CanEnrich(objectResult.Value.GetType());
            }
            return false;
        }
        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);

            if (response.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (okObjectResult.Value is List<T> listResult)
                {
                    foreach (var element in listResult)
                    {
                        await EnrichModel(element, urlHelper);
                    }
                }

            }
            await Task.CompletedTask;
        }

    }
}

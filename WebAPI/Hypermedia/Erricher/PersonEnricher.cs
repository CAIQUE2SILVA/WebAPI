using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO.V1;
using WebAPI.Hypermedia.Constants;

namespace WebAPI.Hypermedia.Erricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonDTO>
    {
        protected override Task EnrichModel(PersonDTO content,
            IUrlHelper urlHelper)
        {
            var resquest = urlHelper.ActionContext.HttpContext.Request;
            var baseUrl = $"{resquest.Scheme}://{resquest.Host.ToUriComponent()}{resquest.PathBase.ToUriComponent()}/api/person/v1";

            content.Links.AddRange(GenereteLinks(content.Id, baseUrl));
            return Task.CompletedTask;

        }

        private IEnumerable<HypermediaLink> GenereteLinks(long id, string baseUrl)
        {
            return
                [
                new()
                {
                    Rel = RealtionType.COLLECTION,
                    Href = $"{baseUrl}",
                    Type = ResponseTypeFormate.DefaultGet,
                    Action = HttpActionVerb.GET
                },
                new()
                {
                    Rel = RealtionType.SELF,
                    Href = $"{baseUrl}/{id}",
                    Type = ResponseTypeFormate.DefaultGet,
                    Action = HttpActionVerb.GET
                },
                new()
                {
                    Rel = RealtionType.CREATE,
                    Href = $"{baseUrl}",
                    Type = ResponseTypeFormate.DefaultPost,
                    Action = HttpActionVerb.POST
                },
                new()
                {
                    Rel = RealtionType.UPDATE,
                    Href = $"{baseUrl}",
                    Type = ResponseTypeFormate.DefaultPut,
                    Action = HttpActionVerb.PUT
                },
                new()
                {
                    Rel = RealtionType.PATCH,
                    Href = $"{baseUrl}/{id}",
                    Type = ResponseTypeFormate.DefaultPatch,
                    Action = HttpActionVerb.PATCH
                },
                new()
                {
                    Rel = RealtionType.DELETE,
                    Href = $"{baseUrl}/{id}",
                    Type = ResponseTypeFormate.DefaultDelete,
                    Action = HttpActionVerb.DELETE
                },
            ];

        }
    }
}

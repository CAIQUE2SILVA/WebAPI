using WebAPI.Hypermedia.Abstract;

namespace WebAPI.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList
        { get; set; } = [];
        }
}

namespace Presentation.WebAPI.Package.Wrappers
{
    public class Link
    {
        public readonly string Href;
        public readonly string Rel;
        public readonly string Method;

        public Link(string? href, string rel, string method)
        {
            Href = href ?? "https://";
            Rel = rel;
            Method = method;
        }
    }
}

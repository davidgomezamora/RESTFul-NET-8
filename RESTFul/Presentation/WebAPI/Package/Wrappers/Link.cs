namespace Presentation.WebAPI.Package.Wrappers
{
    public class Link(string? href, string rel, string method)
    {
        public readonly string Href = href ?? "https://";
        public readonly string Rel = rel;
        public readonly string Method = method;
    }
}

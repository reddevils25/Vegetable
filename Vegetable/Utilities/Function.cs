namespace Vegetable.Utilities
{
    public class Function
    {
        public static string TitleSlugenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
    }
}

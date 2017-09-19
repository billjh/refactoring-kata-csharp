using RefactoringKata.Enums;

namespace RefactoringKata.Extensions
{
    public static class ProductSizeExtensions
    {
        public static string ToString(this ProductSize size)
        {
            return size.ToString().SplitCamelCase();
        }
    }
}
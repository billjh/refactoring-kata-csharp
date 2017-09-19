using System.Text.RegularExpressions;
using RefactoringKata.Enums;

namespace RefactoringKata.Extensions
{
    public static class StringExtensions
    {
        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }

        public static string Display(this ProductSize size)
        {
            return size.ToString().SplitCamelCase();
        }

        public static string Display(this ProductColor color)
        {
            return color.ToString().SplitCamelCase().ToLower();
        }
    }
}
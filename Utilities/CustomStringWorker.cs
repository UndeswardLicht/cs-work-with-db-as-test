using System.Text;
using System.Text.RegularExpressions;

namespace SQLQueries_Test.Utilities
{
    internal class CustomStringWorker
    {
        public static string BuildPath(string relPath)
        {
            return $@"{Directory.GetParent(Environment.CurrentDirectory)?
                .Parent?.Parent?.FullName}\Resources\{relPath}";
        }

        public static string InsertStringOnFirstQuatMarks(string source, string toInsert)
        {
            var matches = Regex.Matches(source, @"\'(.?)\'");
            StringBuilder sb = new StringBuilder(source);
            return sb.Insert(matches[0].Index + 1, $"{toInsert}").ToString();
        }
    }
}

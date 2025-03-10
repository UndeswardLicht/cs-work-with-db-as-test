using System.Text;

namespace SQLQueries_Test.Utilities
{
    internal static class CustomFileReader
    {
        public static IEnumerable<string> ReadAllQueriesInSqlFile()
        {
            throw new NotImplementedException();
        }

        public static string ReadSpecificFileWithOneQuery(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File cannot be written to: " + e.Message);
            }
            return sb.ToString();
        }
    }
}

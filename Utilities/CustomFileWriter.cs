using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLQueries_Test.Utilities
{
    internal static class CustomFileWriter
    {
        public static void WriteResultToFile(DataTable dt, string filePath)
        {

            int cols = dt.Columns.Count;
            int rows = dt.Rows.Count;

            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        StringBuilder str = new();

                        for (int i = 0; i < cols; i++)
                        {
                            str.Append(row[i].ToString()).Append(";");
                        }
                        file.WriteLine(str);
                    }
                    file.WriteLine('\n');
                }
            } catch(FileNotFoundException e)
            {
                Console.WriteLine("File cannot be written to: " + e.Message);
            }
        }
    }
}

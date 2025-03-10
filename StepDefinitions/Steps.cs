using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using NUnit.Framework.Legacy;
using SQLQueries_Test.Utilities;
using TechTalk.SpecFlow;

namespace SQLQueries_Test.StepDefinitions
{
    [Binding]
    public class Steps
    {

        [When(@"I read the SQL query from '(.*)'")]
        public void ReadSqlFile(string relPath)
        {
            string path = CustomStringWorker.BuildPath(relPath);
            string query = CustomFileReader.ReadSpecificFileWithOneQuery(path);
            Store.Put("query", ref query);
        }

        [When(@"I execute this SQL query for the parameters '(.*)' and '(.*)' in MySQL and the result is saved in the store")]
        public void ExecuteSqlQueryWithTwoParams(string param1, string param2)
        {
            var query = Store.Get<string>("query");

            query = CustomStringWorker.InsertStringOnFirstQuatMarks(query, param1);
            query = CustomStringWorker.InsertStringOnFirstQuatMarks(query, param2);

            DataTable dt = CustomDataRetriever.GetData(Store.Get<MySqlConnection>("connection"), query);
            Store.Put<DataTable>("result", ref dt);
        }

        [When(@"I execute this SQL query for the parameter '(.*)' in MySQL and the result is saved in the store")]
        public void ExecuteSqlQueryWithOneParam(string param)
        {
            var query = Store.Get<string>("query").Replace(@"''", param);
            DataTable dt = CustomDataRetriever.GetData(Store.Get<MySqlConnection>("connection"), query);
            Store.Put<DataTable>("result", ref dt);
        }

        [When("I execute this SQL query in MySQL and the result is saved in the store")]
        public void ExecuteSqlQueryWithoutParams()
        {
            DataTable dt = CustomDataRetriever.GetData(Store.Get<MySqlConnection>("connection"), Store.Get<string>("query"));
            Store.Put<DataTable>("result", ref dt);
        }

        [When(@"The result is appended to the '(.*)'")]
        public void WriteResultToFile(string relPath)
        {
            string path = CustomStringWorker.BuildPath(relPath);
            CustomFileWriter.WriteResultToFile(Store.Get<DataTable>("result"), path);

        }

        [Then(@"The '(.*)' is not blank")]
        public void IsFileBlank(string relPath)
        {
            string path = CustomStringWorker.BuildPath(relPath);
            ClassicAssert.IsTrue(new FileInfo(path).Length != 0);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SQLQueries_Test.Utilities;
using TechTalk.SpecFlow;

namespace SQLQueries_Test.Hook
{
    [Binding]
    internal class Hook
    {
        [BeforeScenario]
        public void Setup()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=union_reporting;");
            Store.Put("connection", ref con);
        }

        [AfterScenario]
        public void TearDown()
        {
            Store.CleanStore();
        }

        [BeforeScenario]
        public void DeleteFile()
        {
            string path = CustomStringWorker.BuildPath("results.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}

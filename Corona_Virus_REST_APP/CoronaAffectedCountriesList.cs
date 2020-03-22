using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Corona_Virus_REST_APP
{
    class CoronaAffectedCountriesList
    {
        private const String URL = "https://corona.lmao.ninja/countries";
        private const String connectionString = "Data Source=dataplatformdemodata.syncfusion.com; Integrated Security=false;Initial Catalog = development;User ID = development@data-platform-demo;Password = KW9&ueC$24M4WT";


        public void getDetailsOfInfectedCountries()
        {
            JArray jArray = getJsonArray();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String deleteQuery = "Truncate Table CORONA_APi.[Affected Countries]";
            adapter.InsertCommand = new SqlCommand(deleteQuery, connection);
            adapter.InsertCommand.ExecuteNonQuery();
       
            foreach (JObject jObject in jArray)
            {
                JToken country = jObject.GetValue("country");
                JToken totalCases = jObject.GetValue("cases");
                JToken todayCases = jObject.GetValue("todayCases");
                JToken deaths = jObject.GetValue("deaths");
                JToken todayDeaths = jObject.GetValue("todayDeaths");
                JToken recovered = jObject.GetValue("recovered");
                
                String sqlCommand = "insert into CORONA_APi.[Affected Countries] values("+"'"+country.ToString()+"'"+","+int.Parse(totalCases.ToString())+","+int.Parse(todayCases.ToString())+","+int.Parse(deaths.ToString())+","+int.Parse(todayDeaths.ToString())+","+int.Parse(recovered.ToString())+")";
                adapter.InsertCommand = new SqlCommand(sqlCommand, connection);
                
                adapter.InsertCommand.ExecuteNonQuery();
                

            }
            Console.WriteLine("Successfully Moved all Values");
            connection.Close();

        }

        internal JArray getJsonArray()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    content = streamReader.ReadToEnd();
                }
            }
            JArray jArray = JArray.Parse(content);
            

            return jArray;
        }


    }
}

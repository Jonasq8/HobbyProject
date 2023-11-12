using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using HobbyProject.Manager.StockProgram.API;



namespace HobbyProject.Manager.StockProgram.API
{
    public  class StockApi
    {
        public async Task<Root> getStocks(string ticker)
        {
            string QUERY_URL = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={ticker}&apikey=USIBWO56S5FPQJ8J";
            Uri queryUri = new Uri(QUERY_URL);
            string query = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={ticker}&apikey=USIBWO56S5FPQJ8J";
            using (HttpClient client = new HttpClient())
            {
                
                
                // -------------------------------------------------------------------------
                // if using .NET Core (System.Text.Json)
                // using .NET Core libraries to parse JSON is more complicated. For an informative blog post
                // https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/
                var response = await client.GetAsync(query);
                //dynamic json_data = JsonSerializer.Deserialize<ListOfStock>(client.DownloadString(query));
                var json = await response.Content.ReadAsStringAsync();
                Root s =  JsonConvert.DeserializeObject<Root>(json);
                // -------------------------------------------------------------------------
                return s; 
                // do something with the json_data
            }
        }

    }
}

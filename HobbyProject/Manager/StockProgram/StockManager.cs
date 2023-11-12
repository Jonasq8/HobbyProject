using HobbyProject.Manager.StockProgram.API;
using HobbyProject.Manager.StockProgram.Interface;
using HobbyProject.Model.StockProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Manager.StockProgram
{
    internal class StockManager : IStockManager
    {
        private StockApi _stockApi;
        public StockManager(StockApi stockApi)
        {
            _stockApi = stockApi;
        }


        // USIBWO56S5FPQJ8J API KEY
        public Portfolio GetPortfolio()
        {
            Console.WriteLine("NOT WORKING");
            return null; 
        }

        public async Task<List<Stock>> SearchStocks(string searchWord)
        {
           Root list = await _stockApi.getStocks(searchWord);
           List<Stock> stocks = new List<Stock>();
            foreach (var stock in list.bestMatches)
            {
                stocks.Add(new Stock()
                {
                    Name = stock._2name,
                    Ticker = stock._1symbol,
                });
            }
            return stocks;
        }


        

        

    }
}

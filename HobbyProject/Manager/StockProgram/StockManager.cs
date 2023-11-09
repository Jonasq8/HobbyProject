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


        public Portfolio GetPortfolio()
        {
            Portfolio portfolio = new Portfolio();
            List<Stock> stocks = GetStocks();
            portfolio.Stocks = stocks;
            return portfolio;
        }

        private List<Stock> GetStocks()
        {
            List<Stock> list = new List<Stock>()
            {
                new Stock() {Name = "Ford", Ticker = "F", Price = 23},
                new Stock() {Name = "Apple", Ticker = "A", Price = 23},
                new Stock() {Name = "Meta", Ticker = "META", Price = 23},
                new Stock() {Name = "Alphabete", Ticker = "ALPHA", Price = 23}
            };
            return list;
        }


        

        

    }
}

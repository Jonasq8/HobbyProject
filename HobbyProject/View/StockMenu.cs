using HobbyProject.Manager.StockProgram.API;
using HobbyProject.Manager.StockProgram.Interface;
using HobbyProject.Model.StockProgram;
using HobbyProject.Utils;
using HobbyProject.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.View
{
    internal class StockMenu : IStockMenu
    {
        private IStockManager _StockManager;
        public StockMenu(IStockManager stockManager)
        {
            this._StockManager = stockManager;
        }

        public void OpenStockMenu()
        {
             DisplayStockMenu();
        }

        private async Task DisplayStockMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Stock Menu\r\n\r\nWhat do you wannt to do? \r\n\r\n1. See stocks in portfolio. \r\n2. Look up price of ticker.\r\n3. Add stock to wishlist\r\n4. See wishlist\r\n5. Get bitcoin price\r\n\r\nType the number of the command: ");
            
            int anwser =  InputHandler.CheckStringForNumber(Console.ReadLine());

            switch (anwser)
            {
                case 1:
                    GetPorfolio();
                    break;
                case 2:
                     SeachStocks().Wait();
                    break;
            }
        }

        private async Task SeachStocks()
        {
            Console.Clear();
            await Console.Out.WriteLineAsync("Type the Name of the Stock: ");
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync("Press Enter to Search ");
            string SearchString = Console.ReadLine();
            var isNumeric = int.TryParse(SearchString, out _);
            if (SearchString != null && !isNumeric )
            {
                List<Stock> stocks = await  _StockManager.SearchStocks(SearchString);
                Console.Clear();
                foreach (var stock in stocks)
                {
                    await Console.Out.WriteLineAsync($"Ticker: {stock.Ticker}: Name: {stock.Name}");
                }
                await Console.Out.WriteLineAsync();
                await Console.Out.WriteLineAsync("Press Enter to leave");
                Console.ReadLine();
            }

        }

        private void GetPorfolio()
        {
            Portfolio portfolio = _StockManager.GetPortfolio();

            DisplayPortfolio(portfolio);
        }

        private void DisplayPortfolio(Portfolio portfolio)
        {
            Console.Clear();
            foreach (var stock in portfolio.Stocks) {

                Console.WriteLine($"{stock.Ticker}:  {stock.Name} selling at {stock.Price} ");
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
        }
    }
}

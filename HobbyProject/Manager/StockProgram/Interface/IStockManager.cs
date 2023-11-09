using HobbyProject.Model.StockProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Manager.StockProgram.Interface
{
    internal interface IStockManager
    {
        public Portfolio GetPortfolio();
    }
}

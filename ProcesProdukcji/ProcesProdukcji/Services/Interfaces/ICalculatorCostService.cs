using ProcesProdukcji.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesProdukcji.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}

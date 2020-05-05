using ProcesProdukcji.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesProdukcji.Services.Interfaces
{
    public interface IShowResultService
    {
        ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO);
    }
}

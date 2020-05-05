using ProcesProdukcji.Models;
using ProcesProdukcji.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesProdukcji.Services.Interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO GetSearchHistory(String cityName, ModuleListDTO moduleListDTO);
        OperationSuccessDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);
    }
}

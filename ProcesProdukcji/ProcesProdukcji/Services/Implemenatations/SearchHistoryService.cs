using ProcesProdukcji.Models;
using ProcesProdukcji.ModelsDTO;
using ProcesProdukcji.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesProdukcji.Services.Implemenatations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;

        public SearchHistoryService(CalculatorContext context, IModuleService moduleService, ICityService cityService)
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
        }
        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccessDTO<Module> { Message = "Success" };
        }
        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            var searchHistoryList = context.SearchHistory.Where(sh => sh.CityId == city.Id);

            if (searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            if(searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }
            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryList) 
            {
                counterModule = 0; 

                foreach(string searchHistoryPair in moduleListDTO.ModuleList)
                {
                    if(searchHistory.ModuleName1 == searchHistoryPair || searchHistory.ModuleName2 == searchHistoryPair || searchHistory.ModuleName3 == searchHistoryPair || searchHistory.ModuleName4 == searchHistoryPair)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) && moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO { InSearchHistory = true, Cost = searchHistory.ProductionCost };
                }

            }

            return new ResultCostDTO { InSearchHistory = false };


        }
        public OperationSuccessDTO<IList<SearchHistory>> GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();

            return new OperationSuccessDTO<IList<SearchHistory>> { Message = "Success", Result = searchHistories };
        }

        private int ModuleHasValue(SearchHistory SearchHistory)
        {

            int counter = 0;

            if (!(SearchHistory.ModuleName1 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName2 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName3 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName4 == string.Empty))
                counter++;

            return counter;

        }

      
    }
}
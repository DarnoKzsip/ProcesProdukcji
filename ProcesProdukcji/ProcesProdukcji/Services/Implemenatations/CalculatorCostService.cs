using Microsoft.Ajax.Utilities;
using ProcesProdukcji.Models;
using ProcesProdukcji.ModelsDTO;
using ProcesProdukcji.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace ProcesProdukcji.Services.Implemenatations
{
    public class CalculatorCostService : ICalculatorCostService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;
        private readonly ISearchHistoryService searchHistoryService;

        public CalculatorCostService(
            CalculatorContext context,
            ICityService cityService,
            IModuleService moduleService,
            ISearchHistoryService searchHistoryService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
            this.searchHistoryService = searchHistoryService;
        }
        public OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }
            var modulesCost = city.TransportCost;
            
            foreach (String moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);

                if (module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {moduleName} doesn't exist" };
                }
                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            modulesCost = modulesCost * 1.3;

            return new OperationSuccessDTO<ResultCostDTO> { Message = "Success", Result = new ResultCostDTO { Cost = modulesCost, InSearchHistory = false } };
        }
    }
}
using ProcesProdukcji.Models;
using ProcesProdukcji.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesProdukcji.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccessDTO<IList<City>> GetCities();
        OperationResultDTO UpdatCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(String cityName);
    }
}

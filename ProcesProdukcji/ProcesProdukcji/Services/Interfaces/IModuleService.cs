using ProcesProdukcji.Models;
using ProcesProdukcji.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesProdukcji.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccessDTO<List<Module>> GetModules();
        OperationSuccessDTO<Module> AddModule(Module module);
        OperationSuccessDTO<Module> UpdateModule(Module module);
        OperationSuccessDTO<Module> DeleteModule(string name);
    }
}
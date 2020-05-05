using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcesProdukcji.ModelsDTO
{
    public class OperationSuccessDTO<T> :OperationResultDTO
        where T:class
    {
        public T Result { get; set; }
    }
}
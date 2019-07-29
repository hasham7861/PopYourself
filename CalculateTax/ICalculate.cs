using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CalculateTax
{
    [ServiceContract]
    public interface ICalculate
    {
        [OperationContract]
        double CalculateTax(double value);

    }
}

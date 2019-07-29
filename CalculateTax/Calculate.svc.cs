using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CalculateTax
{
    public class Calculate : ICalculate
    {
        public double CalculateTax(double value)
        {
            return value * 1.13;
        }

    }
}

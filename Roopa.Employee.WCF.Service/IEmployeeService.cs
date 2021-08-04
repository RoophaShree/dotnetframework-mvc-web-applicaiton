using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Roopa.Employee.WCF.Service
{
    
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        String Message();
    }
}

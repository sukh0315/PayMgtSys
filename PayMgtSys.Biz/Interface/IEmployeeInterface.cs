using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Interface
{
    public interface IEmployeeInterface//Employee interface
    {
        //functions without definition
        List<EmployeeVMModel> GetEmployeeDataFunc();
        List<EmployeeVMModel> GetEmployeeDataByIDFunc(int id);
        EmployeeVMModel AddAndUpdateEmployeeDataFunc(EmployeeVMModel model);
        bool DeleteEmployeeDataFunc(int id);

    }
}

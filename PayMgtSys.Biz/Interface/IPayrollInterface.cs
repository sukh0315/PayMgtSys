using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Interface
{
    public interface IPayrollInterface//Payroll interface
    {
        //methods without implementation
        List<PayrollVMModel> GetPayrollListFunc();
        List<PayrollVMModel> GetPayrollByIDFunc(int id);
        PayrollVMModel AddAndUpdatePayrollFunc(PayrollVMModel model);
        bool DeletePayrollFunc(int id);
    }
}

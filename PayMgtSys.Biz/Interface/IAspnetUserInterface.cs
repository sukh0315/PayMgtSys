using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Interface
{
    public interface IAspnetUserInterface//User interface
    {
        bool SignInFunction(AspnetUserVMModel vmModel);
    }
}

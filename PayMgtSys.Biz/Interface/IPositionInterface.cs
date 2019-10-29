using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Interface
{
    public interface IPositionInterface//Position interface
    {
        //methods without implementation 
        List<PositionVMModel> GetPositionListFunc();
        List<PositionVMModel> GetPositionByIDFunc(int id);
        PositionVMModel AddAndUpdatePositionFunc(PositionVMModel model);
        bool DeletePositionFunc(int id);
    }
}

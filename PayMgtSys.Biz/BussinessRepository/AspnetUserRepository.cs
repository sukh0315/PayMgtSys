using PayMgtSys.DB;
using PayrollManagementBiz.Interface;
using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementBiz.Repository
{
    public class AspnetUserRepository: IAspnetUserInterface
    {
        PayrollManagementEntities _db = new PayrollManagementEntities();
        public bool SignInFunction(AspnetUserVMModel vmModel)//sign in method
        {
            bool isSignIn = false;
            try
            {
                var record = (from a in _db.AspNetUsers
                              where a.Name == vmModel.Name && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isSignIn = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSignIn;
        }
    }
}

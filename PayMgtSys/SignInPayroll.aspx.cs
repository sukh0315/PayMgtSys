using PayrollManagementBiz.Interface;
using PayrollManagementBiz.Repository;
using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayMgtSys
{
    public partial class SignInPayroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signInBtn_Click(object sender, EventArgs e)//This is login method for login in the application
        {
            AspnetUserVMModel _viewModel = new AspnetUserVMModel();//View model instance
            IAspnetUserInterface _service = new AspnetUserRepository();//Service class instance
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            _viewModel.Name = Username.Text.Trim();
            _viewModel.Password = password.Text.Trim();
            bool msg = _service.SignInFunction(_viewModel);//Sign in method calling
            if (msg)
            {

                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}
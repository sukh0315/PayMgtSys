using PayrollManagementBiz.Interface;
using PayrollManagementBiz.Repository;
using PayrollManagementBiz.VMModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayMgtSys
{
    public partial class PayrollPMS : System.Web.UI.Page
    {
        IPayrollInterface iPayrollInterface = new PayrollRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindEmployeeList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update
        {
            PayrollVMModel vmModel = new PayrollVMModel();
            vmModel.EmployeeID = Convert.ToInt32(EmployeeID.Text);
            vmModel.NoOfLeaves = Convert.ToDecimal(NoOfLeaves.Text);
            vmModel.GrossSalary = Convert.ToDecimal(GrossSalary.Text);
            vmModel.TotalDeduction = Convert.ToDecimal(TotalDeduction.Text);
            vmModel.NetPay = Convert.ToDecimal(NetPay.Text);
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iPayrollInterface.AddAndUpdatePayrollFunc(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Payroll.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Grid command row function
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iPayrollInterface.GetPayrollByIDFunc(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    EmployeeID.Text = dt.Rows[0]["EmployeeID"].ToString();
                    NoOfLeaves.Text = dt.Rows[0]["NoOfLeaves"].ToString();
                    GrossSalary.Text = dt.Rows[0]["GrossSalary"].ToString();
                    TotalDeduction.Text = dt.Rows[0]["TotalDeduction"].ToString();
                    NetPay.Text = dt.Rows[0]["NetPay"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = iPayrollInterface.DeletePayrollFunc(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//grid view binding method
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iPayrollInterface.GetPayrollListFunc();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }

        protected void bindEmployeeList()//binding the employee dropdown
        {
            DataTableConversion lsttodt = new DataTableConversion();

            IEmployeeInterface service = new EmployeeRepository();
            var lst = service.GetEmployeeDataFunc().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                EmployeeID.DataSource = dt;
                EmployeeID.DataTextField = "Name";
                EmployeeID.DataValueField = "ID";
                EmployeeID.DataBind();

            }
            else
            {
                EmployeeID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)//Reset method
        {
            Response.Redirect("PayrollPMS.aspx");
        }
    }
}
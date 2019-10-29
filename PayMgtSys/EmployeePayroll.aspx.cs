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
    public partial class EmployeePayroll : System.Web.UI.Page
    {
        IEmployeeInterface _empService = new EmployeeRepository();//Repository instance
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();//Calling methods
                bindPositionList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update method
        {
            EmployeeVMModel vmModel = new EmployeeVMModel();
            vmModel.PositionID = Convert.ToInt32(PositionID.Text);
            vmModel.Name = Name.Text;
            vmModel.FatherName = FatherName.Text;
            vmModel.Address = Address.InnerText;
            vmModel.Gender = GenderList.Text;
            vmModel.PhoneNo = PhoneNumber.Text;
            vmModel.Email = Email.Text;
            vmModel.DOB = Convert.ToDateTime(DOBDate.Text);
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = _empService.AddAndUpdateEmployeeDataFunc(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("EmployeePayroll.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //row command method
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = _empService.GetEmployeeDataByIDFunc(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    PositionID.Text = dt.Rows[0]["PositionID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    PhoneNumber.Text = dt.Rows[0]["PhoneNo"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    DOBDate.Text = dt.Rows[0]["DOB"].ToString();
                    FatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    Address.InnerText = dt.Rows[0]["Address"].ToString();
                    GenderList.Text = dt.Rows[0]["Gender"].ToString();
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
                bool result = _empService.DeleteEmployeeDataFunc(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//bind grid method for binding the gridview
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = _empService.GetEmployeeDataFunc();
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

        protected void bindPositionList()//binding the position dropdown
        {
            DataTableConversion lsttodt = new DataTableConversion();

            IPositionInterface service = new PositionRepository();
            var lst = service.GetPositionListFunc().Select(x => new { x.PositionName, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                PositionID.DataSource = dt;
                PositionID.DataTextField = "PositionName";
                PositionID.DataValueField = "ID";
                PositionID.DataBind();

            }
            else
            {
                PositionID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeePayroll.aspx");
        }
    }
}
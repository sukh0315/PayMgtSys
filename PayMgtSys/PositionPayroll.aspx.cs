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
    public partial class PositionPayroll : System.Web.UI.Page
    {
        IPositionInterface iPositionInterface = new PositionRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update here
        {
            PositionVMModel vmModel = new PositionVMModel();
            vmModel.PositionName = PositionName.Text;
            vmModel.DailyRate = Convert.ToDecimal(DailyRate.Text);
            vmModel.MonthlyRate = Convert.ToDecimal(MonthlyRate.Text);

            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iPositionInterface.AddAndUpdatePositionFunc(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("PositionPayroll.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //rowcommand for grid view function performing
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iPositionInterface.GetPositionByIDFunc(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    PositionName.Text = dt.Rows[0]["PositionName"].ToString();
                    DailyRate.Text = dt.Rows[0]["DailyRate"].ToString();
                    MonthlyRate.Text = dt.Rows[0]["MonthlyRate"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();//datatable instance
                bool result = iPositionInterface.DeletePositionFunc(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//gridview binding
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iPositionInterface.GetPositionListFunc();
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

        protected void Reset_Click(object sender, EventArgs e)//reset method
        {
            Response.Redirect("PositionPayroll.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayMgtSys
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignOut_ServerClick(object sender, EventArgs e)//Signmout methdod
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Clear();
            Session["LoginId"] = null;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1000;
            Response.CacheControl = "no-cache";
            Response.Redirect("SignInPayroll.aspx?status=logout", true);
        }
    }
}
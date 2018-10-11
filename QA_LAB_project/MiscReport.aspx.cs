using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class MiscReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["report_date"] != null && HttpContext.Current.Session["report_date"].ToString().Length > 10)
                {
                    report_date.Value = HttpContext.Current.Session["report_date"].ToString().Substring(0, 10);
                }
                else
                    report_date.Value = HttpContext.Current.Session["report_date"].ToString();

                gv_reportMisc.DataSource = (DataTable)Session["Misctbl"];
                gv_reportMisc.DataBind();

            
            }
            catch (Exception ex)
            {

            }

        }
    }
}
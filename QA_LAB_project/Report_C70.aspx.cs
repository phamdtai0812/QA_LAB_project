using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Report_C70 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["report_date"] != null && HttpContext.Current.Session["report_date"].ToString().Length > 10)
            {
                report_date.Value = HttpContext.Current.Session["report_date"].ToString().Substring(0, 10);
            }
            else
                report_date.Value = HttpContext.Current.Session["report_date"].ToString();


            // Access dt back from viewstate
            DataTable c70_datatable = (DataTable)Session["c70tbl"];
            gv_reportC70.DataSource = c70_datatable;
            gv_reportC70.DataBind();
        }

        protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in gv_reportC70.Rows)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Enabled = false;
                    e.Row.BackColor = Color.FromName("#FFFFFF");
                }
            }

        }
    }
}
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
    public partial class Page5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Session["report_date"] != null)
            //{
            //    report_date.Value = HttpContext.Current.Session["report_date"].ToString();
            //}
            //else
            //    report_date.Value = DateTime.Today.ToShortDateString().Substring(0, 10);
            // Access dt back from viewstate

            DataTable page_datatable = (DataTable)Session["Page5"];
            gv_page5.DataSource = page_datatable;
            gv_page5.DataBind();
        }

        //protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    foreach (GridViewRow row in gv_reportC70.Rows)
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            e.Row.Enabled = false;
        //            e.Row.BackColor = Color.FromName("#FFFFFF");
        //        }
        //    }

        //}
    }
}
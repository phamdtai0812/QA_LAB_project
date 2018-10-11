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
    public partial class H30 : System.Web.UI.Page
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

                // Access dt back from viewstate
                //DataTable h30_datatable = (DataTable)Session["h30tbl_1"];
                gv_reportH30.DataSource = (DataTable)Session["h30tbl_1"];
                gv_reportH30.DataBind();

                gv_reportH30_2.DataSource = (DataTable)Session["h30tbl_2"];
                gv_reportH30_2.DataBind();

            

                gv_reportH30_3.DataSource = (DataTable)Session["h30tbl_3"];
                gv_reportH30_3.DataBind();
            }
            catch
            {

            }
        }

        protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int rowcount = gv_reportH30_3.Rows.Count;
            //for (int i = 0; i < gv_reportH30_3.Rows.Count ; i++)
            //{
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    if( Convert.ToDouble(e.Row.Cells[2].Text) > 0.0204)
                //    {
                //        e.Row.Cells[2].Text = e.Row.Cells[2].Text + "*";
                //    }
                //}

            //    if (string.IsNullOrEmpty(gv_reportH30_3.Rows[i].ToString()) )
            //    {
            //        gv_reportH30_3.Rows[i].Visible = false;

            //    }



            //}

        

        }
    }
}

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
    public partial class WH30 : System.Web.UI.Page
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
                gv_reportWH30.DataSource = (DataTable)Session["wh30tbl_1"];
                gv_reportWH30.DataBind();

                gv_reportWH30_2.DataSource = (DataTable)Session["wh30tbl_2"];
                gv_reportWH30_2.DataBind();

                gv_reportWH30_3.DataSource = (DataTable)Session["wh30tbl_3"];
                gv_reportWH30_3.DataBind();
            }
            catch
            {

            }

        }
        protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= gv_reportWH30_3.Rows.Count - 1; i++)
            {
                TextBox txb = (TextBox)gv_reportWH30_3.Rows[i].FindControl("Wh30_3");
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    gv_reportWH30_3.Rows[i].Cells[2].ForeColor = Color.Yellow;
                }

                //if (txb.Text == "1")
                //{
                //    GridView1.Rows[i].Cells[6].BackColor = Color.Yellow;
                //    lblparent.ForeColor = Color.Black;
                //}
                //else
                //{
                //    GridView1.Rows[i].Cells[6].BackColor = Color.Green;
                //    lblparent.ForeColor = Color.Yellow;
                //}

            }

            //foreach (GridViewRow row in gv_reportWH30_3.Rows)
            //{
            //    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            //    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            //    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        //if (Convert.ToDouble(e.Row.Cells[2].Text) > 0.0204)
            //        //{
            //        //    e.Row.Cells[2].Text = e.Row.Cells[2].Text + "*";
            //        //}
            //    }
            //}

        }
    }
}
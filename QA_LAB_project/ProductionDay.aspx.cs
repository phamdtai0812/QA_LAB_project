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
    public partial class ProductionDay : System.Web.UI.Page
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
            LoadData();

        }
        protected void LoadData()
        {
            DataSet ds = (DataSet)Session["ProductionDay"];
            Production_Day1.DataSource = ds.Tables[0];
            Production_Day1.DataBind();
            Production_Day2.DataSource = ds.Tables[1];
            Production_Day2.DataBind();
            Production_Day3.DataSource = ds.Tables[2];
            Production_Day3.DataBind();
            Production_Day4.DataSource = ds.Tables[3];
            Production_Day4.DataBind();
            Production_Day5.DataSource = ds.Tables[4];
            Production_Day5.DataBind();
            Production_Day6.DataSource = ds.Tables[5];
            Production_Day6.DataBind();
            Production_Day7.DataSource = ds.Tables[6];
            Production_Day7.DataBind();
            Production_Day8.DataSource = ds.Tables[7];
            Production_Day8.DataBind();
            Production_Day9.DataSource = ds.Tables[8];
            Production_Day9.DataBind();
            Production_Day10.DataSource = ds.Tables[9];
            Production_Day10.DataBind();
            Production_Day11.DataSource = ds.Tables[10];
            Production_Day11.DataBind();
            Production_Day12.DataSource = ds.Tables[11];
            Production_Day12.DataBind();
            Production_Day13.DataSource = ds.Tables[12];
            Production_Day13.DataBind();
            Production_Day14.DataSource = ds.Tables[13];
            Production_Day14.DataBind();
            Production_Day15.DataSource = ds.Tables[14];
            Production_Day15.DataBind();
            Production_Day16.DataSource = ds.Tables[15];
            Production_Day16.DataBind();
            Production_Day17.DataSource = ds.Tables[16];
            Production_Day17.DataBind();
            Production_Day18.DataSource = ds.Tables[17];
            Production_Day18.DataBind();
            Production_Day19.DataSource = ds.Tables[18];
            Production_Day19.DataBind();
            Production_Day20.DataSource = ds.Tables[19];
            Production_Day20.DataBind();
            Production_Day21.DataSource = ds.Tables[20];
            Production_Day21.DataBind();
            Production_Day22.DataSource = ds.Tables[21];
            Production_Day22.DataBind();
            Production_Day23.DataSource = ds.Tables[22];
            Production_Day23.DataBind();
            Production_Day24.DataSource = ds.Tables[23];
            Production_Day24.DataBind();
            Production_Day25.DataSource = ds.Tables[24];
            Production_Day25.DataBind();
            Production_Day26.DataSource = ds.Tables[25];
            Production_Day26.DataBind();
            Production_Day27.DataSource = ds.Tables[26];
            Production_Day27.DataBind();
            Production_Day28.DataSource = ds.Tables[27];
            Production_Day28.DataBind();



        }
        protected void gv_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow row in gv_reportC70.Rows)
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        e.Row.Enabled = false;
            //        e.Row.BackColor = Color.FromName("#FFFFFF");
            //    }
            //}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Specs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //insertNewRow();
                gvBind();
            }
        }
        public void gvBind()
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                //if (string.IsNullOrEmpty(HttpContext.Current.Session["sec12_date"] as string))
                //{
                //    date = DateTime.Today.ToShortDateString();
                //    Session["sec12_date"] = date;
                //}
                //else
                //{ date = Session["sec12_date"].ToString(); }
                //date_max.Value = date;

                query = " select * FROM LAB_SPECS where report_name = 'C70' ORDER BY ITEM_NAME  ";
                query += " select * FROM LAB_SPECS where report_name = 'H30' ORDER BY ITEM_NAME   ";
                query += " select * FROM LAB_SPECS where report_name = 'WH30' ORDER BY ITEM_NAME   ";
                query += " select * from pitaglist ";



                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand(query);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv_c70.DataSource = ds.Tables[0];
                        gv_c70.DataBind();

                        gv_h30.DataSource = ds.Tables[1];
                        gv_h30.DataBind();

                        gv_wh30.DataSource = ds.Tables[2];
                        gv_wh30.DataBind();

                        gv_PiTagList.DataSource = ds.Tables[3];
                        gv_PiTagList.DataBind();
                        

                    }
                 


                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
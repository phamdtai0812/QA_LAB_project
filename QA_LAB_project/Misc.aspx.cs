using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Misc : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                    insertNewRow();
                    gvBind();
                
            }
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            HttpContext.Current.Session["misc_date"] = selDate;
            return selDate;
        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["misc_date"] != null)
                dt = HttpContext.Current.Session["misc_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT MMISCDATE   FROM [Lab].[dbo].[LAB_MISC] WHERE MMISCDATE = '" + dt + "'";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                SqlCommand cmd = new SqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    createNewRow(dt);
                }
            }
        }
        public void createNewRow(string dt)
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_misc", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void gvBind()
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                if (string.IsNullOrEmpty(HttpContext.Current.Session["misc_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["misc_date"] = date;
                }
                else
                { date = Session["misc_date"].ToString(); }
                DateTime date_ = Convert.ToDateTime(date);
                //string date_ = "2018-03-10";
                // DateTime date_ =  DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                date_max.Value = date;

                //PH Analysis
                query = "  select * from lab_misc where mmiscdate = '" + date_ + "'";
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
                        gv_misc.DataSource = ds.Tables[0];
                        gv_misc.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static DataTable GenerateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MMISCDESCR", typeof(string));
            dt.Columns.Add("MMISCQTY", typeof(string));
            dt.Columns.Add("MMISCSIZE", typeof(string));
          
            dt.Columns.Add("MD_ID", typeof(string));
            dt.Columns.Add("CCROUND", typeof(string));

            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = GenerateTable();
             
 
                foreach (GridViewRow rows in gv_misc.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_misc_desc");
                    string a = txtbox.Text;
                    if (a != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_misc_desc");
                        string a1 = txtbox1.Text;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_misc_amt");
                        string a2 = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_misc_size");
                        string a3 = txtbox3.Text;
                        System.Web.UI.WebControls.HiddenField txtbox4 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("gv_misc_id");
                        string a4 = txtbox4.Value;
                        System.Web.UI.WebControls.DropDownList txtbox5= (System.Web.UI.WebControls.DropDownList)rows.FindControl("gv_misc_ddlccround");
                        string a5 = txtbox5.SelectedValue;

                        row["MMISCDESCR"] = a1;
                        row["MMISCQTY"] = a2;
                        row["MMISCSIZE"] = a3;
                        row["MD_ID"] = a4.TrimEnd();
                        row["CCROUND"] = a5;
                    }
                   
                }
        


                Update(dt);

                gvBind();
                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {
            }
        }
        public void Update(DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 using (SqlConnection con = new SqlConnection(strConnString))
                 {
                SqlCommand cmd = new SqlCommand("LAB_sp_misc", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@DATE", SqlDbType.VarChar).Value = Session["env_date"].ToString();
                cmd.Parameters.AddWithValue("@MMISCDESCR", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["MMISCDESCR"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["MMISCDESCR"].ToString();
                cmd.Parameters.AddWithValue("@MMISCQTY", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["MMISCQTY"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["MMISCQTY"].ToString();
                cmd.Parameters.AddWithValue("@MMISCSIZE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["MMISCSIZE"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["MMISCSIZE"].ToString();
                cmd.Parameters.AddWithValue("@MD_ID", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["MD_ID"].ToString()) ? (object)DBNull.Value : (dt.Rows[i]["MD_ID"].ToString());
                    cmd.Parameters.AddWithValue("@CCROUND", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["CCROUND"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["CCROUND"].ToString();

                    con.Open();
                cmd.ExecuteNonQuery();
                }
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                DropDownList ddlCategories = e.Row.FindControl("ddlccround") as DropDownList;
                //if (ddlCategories != null)
                {
                    DataTable dt = getData();
                    ddlCategories.SelectedValue = dt.Columns[4].ToString();
                }
            }
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                if (string.IsNullOrEmpty(HttpContext.Current.Session["misc_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["misc_date"] = date;
                }
                else
                { date = Session["misc_date"].ToString(); }
                DateTime date_ = Convert.ToDateTime(date);
                //string date_ = "2018-03-10";
                // DateTime date_ =  DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                date_max.Value = date;

                //PH Analysis
                query = "  select ccround from lab_misc where mmiscdate = '" + date_ + "'";
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
                        dt = ds.Tables[0];
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}
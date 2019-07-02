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
    public partial class Inventory : System.Web.UI.Page
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
            query = "SELECT date FROM [Lab].[dbo].[Inv_lab] WHERE date = '" + dt + "'";
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
            SqlCommand cmd = new SqlCommand("LAB_sp_Inv_lab", con);
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



                SqlConnection con = new SqlConnection(strConnString);
                
                using (con)
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("date", SqlDbType.Date).Value = date_;
                    //con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("LAB_sp_Inv_lab_Select", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("date", SqlDbType.Date).Value = date_;
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string s = "";
                        gv_inventory.DataSource = ds.Tables[0];
                        gv_inventory.DataBind();

                        gv_invt2.DataSource = ds.Tables[1];
                        gv_invt2.DataBind();

                        gv_invt3.DataSource = ds.Tables[2];
                        gv_invt3.DataBind();
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

            dt.Columns.Add("EmergencyBasinA", typeof(string));
            dt.Columns.Add("EmergencyBasinC", typeof(string));
            dt.Columns.Add("EmergencyBasinS", typeof(string));

            dt.Columns.Add("WOF0_A", typeof(string));
            dt.Columns.Add("WOF0_C", typeof(string));
            dt.Columns.Add("WOF0_S", typeof(string));

            dt.Columns.Add("WOF1_A", typeof(string));
            dt.Columns.Add("WOF1_C", typeof(string));
            dt.Columns.Add("WOF1_S", typeof(string));

            dt.Columns.Add("WOF2_A", typeof(string));
            dt.Columns.Add("WOF2_C", typeof(string));
            dt.Columns.Add("WOF2_S", typeof(string));

            dt.Columns.Add("WOF3_A", typeof(string));
            dt.Columns.Add("WOF3_C", typeof(string));
            dt.Columns.Add("WOF3_S", typeof(string));

            dt.Columns.Add("WOF4_A", typeof(string));
            dt.Columns.Add("WOF4_C", typeof(string));
            dt.Columns.Add("WOF4_S", typeof(string));

            dt.Columns.Add("WOF5_A", typeof(string));
            dt.Columns.Add("WOF5_C", typeof(string));
            dt.Columns.Add("WOF5_S", typeof(string));

            dt.Columns.Add("WOF6_A", typeof(string));
            dt.Columns.Add("WOF6_C", typeof(string));
            dt.Columns.Add("WOF6_S", typeof(string));

            dt.Columns.Add("WOF7_A", typeof(string));
            dt.Columns.Add("WOF7_C", typeof(string));
            dt.Columns.Add("WOF7_S", typeof(string));

            dt.Columns.Add("WOF8_A", typeof(string));
            dt.Columns.Add("WOF8_C", typeof(string));
            dt.Columns.Add("WOF8_S", typeof(string));

            dt.Columns.Add("WOF_DT_A", typeof(string));
            dt.Columns.Add("WOF_DT_C", typeof(string));
            dt.Columns.Add("WOF_DT_S", typeof(string));

            dt.Columns.Add("FAST_A", typeof(string));
            dt.Columns.Add("FAST_C", typeof(string));
            dt.Columns.Add("FAST_S", typeof(string));

            dt.Columns.Add("ECMT_A", typeof(string));
            dt.Columns.Add("ECMT_C", typeof(string));
            dt.Columns.Add("ECMT_S", typeof(string));

            dt.Columns.Add("NO2ECCT_A", typeof(string));
            dt.Columns.Add("NO2ECCT_C", typeof(string));
            dt.Columns.Add("NO2ECCT_S", typeof(string));

            dt.Columns.Add("NA2SDAY_A", typeof(string));
            dt.Columns.Add("NA2SDAY_C", typeof(string));
            dt.Columns.Add("NA2SDAY_S", typeof(string));

            dt.Columns.Add("OXS_A", typeof(string));
            dt.Columns.Add("OXS_C", typeof(string));
            dt.Columns.Add("OXS_S", typeof(string));


            dt.Columns.Add("SOF_A", typeof(string));
            dt.Columns.Add("SOF_C", typeof(string));
            dt.Columns.Add("SOF_S", typeof(string));

            dt.Columns.Add("PFT_A", typeof(string));
            dt.Columns.Add("PFT_C", typeof(string));
            dt.Columns.Add("PFT_S", typeof(string));

            dt.Columns.Add("FILT_A", typeof(string));
            dt.Columns.Add("FILT_C", typeof(string));
            dt.Columns.Add("FILT_S", typeof(string));

            dt.Columns.Add("PRET_A", typeof(string));
            dt.Columns.Add("PRET_C", typeof(string));
            dt.Columns.Add("PRET_S", typeof(string));

            dt.Columns.Add("PFTNORTH_A", typeof(string));
            dt.Columns.Add("PFTNORTH_C", typeof(string));
            dt.Columns.Add("PFTNORTH_S", typeof(string));

            dt.Columns.Add("PT78_A", typeof(string));
            dt.Columns.Add("PT78_C", typeof(string));
            dt.Columns.Add("PT78_S", typeof(string));

            dt.Columns.Add("SECT4_A", typeof(string));
            dt.Columns.Add("SECT4_C", typeof(string));
            dt.Columns.Add("SECT4_S", typeof(string));

            dt.Columns.Add("TERT1_A", typeof(string));
            dt.Columns.Add("TERT1_C", typeof(string));
            dt.Columns.Add("TERT1_S", typeof(string));

            dt.Columns.Add("WT77_A", typeof(string));
            dt.Columns.Add("WT77_C", typeof(string));
            dt.Columns.Add("WT77_S", typeof(string));

            dt.Columns.Add("PMT_A", typeof(string));
            dt.Columns.Add("PMT_C", typeof(string));
            dt.Columns.Add("PMT_S", typeof(string));

            dt.Columns.Add("SLT_A", typeof(string));
            dt.Columns.Add("SLT_C", typeof(string));
            dt.Columns.Add("SLT_S", typeof(string));

            dt.Columns.Add("WLTNORTH_A", typeof(string));
            dt.Columns.Add("WLTNORTH_C", typeof(string));
            dt.Columns.Add("WLTNORTH_S", typeof(string));

            dt.Columns.Add("WLTSOUTH_A", typeof(string));
            dt.Columns.Add("WLTSOUTH_C", typeof(string));
            dt.Columns.Add("WLTSOUTH_S", typeof(string));

            dt.Columns.Add("SAT51_A", typeof(string));
            dt.Columns.Add("SAT51_C", typeof(string));
            dt.Columns.Add("SAT51_S", typeof(string));

            dt.Columns.Add("LICTANK_A", typeof(string));
            dt.Columns.Add("LICTANK_C", typeof(string));
            dt.Columns.Add("LICTANK_S", typeof(string));

            dt.Columns.Add("NA2SBULK_A", typeof(string));
            dt.Columns.Add("NA2SBULK_C", typeof(string));
            dt.Columns.Add("NA2SBULK_S", typeof(string));

            dt.Columns.Add("DIGPDS1_A", typeof(string));
            dt.Columns.Add("DIGPDS1_C", typeof(string));
            dt.Columns.Add("DIGPDS1_S", typeof(string));

            dt.Columns.Add("DIGPDS4_A", typeof(string));
            dt.Columns.Add("DIGPDS4_C", typeof(string));
            dt.Columns.Add("DIGPDS4_S", typeof(string));

            dt.Columns.Add("WTA64_PS", typeof(string));
            dt.Columns.Add("WTA77_PS", typeof(string));
            dt.Columns.Add("WTA90_PS", typeof(string));

            dt.Columns.Add("SEEDS_TT", typeof(string));
            dt.Columns.Add("SEEDS_ST", typeof(string));
            dt.Columns.Add("SEEDS_PT", typeof(string));

            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = GenerateTable();
                var row = dt.NewRow();
                dt.Rows.Add(row);

                foreach (GridViewRow rows in gv_inventory.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt_a");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt_b");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt_c");
                    string a3 = txtbox3.Text;

                    if (rows.RowIndex == 0)
                    {
                        row["EmergencyBasinA"] = a1;
                        row["EmergencyBasinC"] = a2;
                        row["EmergencyBasinS"] = a3;
                    }
                    if (rows.RowIndex == 1)
                    {
                        row["WOF0_A"] = a1;
                        row["WOF0_C"] = a2;
                        row["WOF0_S"] = a3;
                    }
                    if (rows.RowIndex == 2)
                    {
                        row["WOF1_A"] = a1;
                        row["WOF1_C"] = a2;
                        row["WOF1_S"] = a3;
                    }
                    if (rows.RowIndex == 3)
                    {
                        row["WOF2_A"] = a1;
                        row["WOF2_C"] = a2;
                        row["WOF2_S"] = a3;
                    }
                    if (rows.RowIndex == 4)
                    {
                        row["WOF3_A"] = a1;
                        row["WOF3_C"] = a2;
                        row["WOF3_S"] = a3;
                    }
                    if (rows.RowIndex == 5)
                    {
                        row["WOF4_A"] = a1;
                        row["WOF4_C"] = a2;
                        row["WOF4_S"] = a3;
                    }
                    if (rows.RowIndex == 6)
                    {
                        row["WOF5_A"] = a1;
                        row["WOF5_C"] = a2;
                        row["WOF5_S"] = a3;
                    }
                    if (rows.RowIndex == 7)
                    {
                        row["WOF6_A"] = a1;
                        row["WOF6_C"] = a2;
                        row["WOF6_S"] = a3;
                    }
                    if (rows.RowIndex == 8)
                    {
                        row["WOF7_A"] = a1;
                        row["WOF7_C"] = a2;
                        row["WOF7_S"] = a3;
                    }
                    if (rows.RowIndex == 9)
                    {
                        row["WOF8_A"] = a1;
                        row["WOF8_C"] = a2;
                        row["WOF8_S"] = a3;
                    }
                    if (rows.RowIndex == 10)
                    {
                        row["WOF_DT_A"] = a1;
                        row["WOF_DT_C"] = a2;
                        row["WOF_DT_S"] = a3;
                    }
                    if (rows.RowIndex == 11)
                    {
                        row["FAST_A"] = a1;
                        row["FAST_C"] = a2;
                        row["FAST_S"] = a3;
                    }
                    if (rows.RowIndex == 12)
                    {
                        row["ECMT_A"] = a1;
                        row["ECMT_C"] = a2;
                        row["ECMT_S"] = a3;
                    }
                    if (rows.RowIndex == 13)
                    {
                        row["NO2ECCT_A"] = a1;
                        row["NO2ECCT_C"] = a2;
                        row["NO2ECCT_S"] = a3;
                    }
                    if (rows.RowIndex == 14)
                    {
                        row["NA2SDAY_A"] = a1;
                        row["NA2SDAY_C"] = a2;
                        row["NA2SDAY_S"] = a3;
                    }
                    if (rows.RowIndex == 15)
                    {
                        row["OXS_A"] = a1;
                        row["OXS_C"] = a2;
                        row["OXS_S"] = a3;
                    }
                    if (rows.RowIndex == 16)
                    {
                        row["SOF_A"] = a1;
                        row["SOF_C"] = a2;
                        row["SOF_S"] = a3;
                    }
                    if (rows.RowIndex == 17)
                    {
                        row["PFT_A"] = a1;
                        row["PFT_C"] = a2;
                        row["PFT_S"] = a3;
                    }
                    if (rows.RowIndex == 18)
                    {
                        row["FILT_A"] = a1;
                        row["FILT_C"] = a2;
                        row["FILT_S"] = a3;
                    }
                    if (rows.RowIndex == 19)
                    {
                        row["PRET_A"] = a1;
                        row["PRET_C"] = a2;
                        row["PRET_S"] = a3;
                    }
                    if (rows.RowIndex == 20)
                    {
                        row["PFTNORTH_A"] = a1;
                        row["PFTNORTH_C"] = a2;
                        row["PFTNORTH_S"] = a3;
                    }
                    if (rows.RowIndex == 21)
                    {
                        row["PT78_A"] = a1;
                        row["PT78_C"] = a2;
                        row["PT78_S"] = a3;
                    }
                    if (rows.RowIndex == 22)
                    {
                        row["SECT4_A"] = a1;
                        row["SECT4_C"] = a2;
                        row["SECT4_S"] = a3;
                    }
                    if (rows.RowIndex == 23)
                    {
                        row["TERT1_A"] = a1;
                        row["TERT1_C"] = a2;
                        row["TERT1_S"] = a3;
                    }
                    if (rows.RowIndex == 24)
                    {
                        row["WT77_A"] = a1;
                        row["WT77_C"] = a2;
                        row["WT77_S"] = a3;
                    }
                    if (rows.RowIndex == 25)
                    {
                        row["PMT_A"] = a1;
                        row["PMT_C"] = a2;
                        row["PMT_S"] = a3;
                    }
                    if (rows.RowIndex == 26)
                    {
                        row["SLT_A"] = a1;
                        row["SLT_C"] = a2;
                        row["SLT_S"] = a3;
                    }
                    if (rows.RowIndex == 27)
                    {
                        row["WLTNORTH_A"] = a1;
                        row["WLTNORTH_C"] = a2;
                        row["WLTNORTH_S"] = a3;
                    }
                    if (rows.RowIndex == 28)
                    {
                        row["WLTSOUTH_A"] = a1;
                        row["WLTSOUTH_C"] = a2;
                        row["WLTSOUTH_S"] = a3;
                    }
                    if (rows.RowIndex == 29)
                    {
                        row["SAT51_A"] = a1;
                        row["SAT51_C"] = a2;
                        row["SAT51_S"] = a3;
                    }
                    if (rows.RowIndex == 30)
                    {
                        row["LICTANK_A"] = a1;
                        row["LICTANK_C"] = a2;
                        row["LICTANK_S"] = a3;
                    }
                    if (rows.RowIndex == 31)
                    {
                        row["NA2SBULK_A"] = a1;
                        row["NA2SBULK_C"] = a2;
                        row["NA2SBULK_S"] = a3;
                    }
                    if (rows.RowIndex == 32)
                    {
                        row["DIGPDS1_A"] = a1;
                        row["DIGPDS1_C"] = a2;
                        row["DIGPDS1_S"] = a3;
                    }
                    if (rows.RowIndex == 33)
                    {
                        row["DIGPDS4_A"] = a1;
                        row["DIGPDS4_C"] = a2;
                        row["DIGPDS4_S"] = a3;
                    }

                }


                foreach (GridViewRow rows in gv_invt2.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt2_a");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt2_b");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt2_c");
                    string a3 = txtbox3.Text;

                    {
                        row["WTA64_PS"] = a1;
                        row["WTA77_PS"] = a2;
                        row["WTA90_PS"] = a3;
                    }
                }

                foreach (GridViewRow rows in gv_invt3.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt3_a");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt3_b");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_invt3_c");
                    string a3 = txtbox3.Text;

                    {
                        row["SEEDS_TT"] = a1;
                        row["SEEDS_ST"] = a2;
                        row["SEEDS_PT"] = a3;
                    }
                }


                if (dt.Rows.Count > 0)
                {
                    Update(dt);
                }


                  

                 gvBind();
                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {
            }
        }
        public void Update(DataTable dt)
        {

            try
            {
              
                DateTime datetime;
                //TimeSpan ts;
                //if (time == 24)
                //{
                //    ts = new TimeSpan(23, 59, 59);
                //}
                //else ts = new TimeSpan(time, 0, 0);

                //var date = Convert.ToDateTime(Session["ccontrol_date"].ToString());
                //datetime = date + ts;

                var date = Convert.ToDateTime(Session["misc_date"].ToString());
                var today = DateTime.Now.Date;

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand("LAB_sp_Inv_lab_Update", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = date;
                    //cmd.Parameters.AddWithValue("@type", SqlDbType.Int).Value = type;

                    cmd.Parameters.AddWithValue("@EmergencyBasinA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EmergencyBasinA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EmergencyBasinA"].ToString();
                    cmd.Parameters.AddWithValue("@EmergencyBasinC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EmergencyBasinC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EmergencyBasinC"].ToString();
                    cmd.Parameters.AddWithValue("@EmergencyBasinS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EmergencyBasinS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EmergencyBasinS"].ToString();

                    cmd.Parameters.AddWithValue("@WOF0_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF0_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF0_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF0_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF0_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF0_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF0_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF0_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF0_A"].ToString();

                    cmd.Parameters.AddWithValue("@WOF1_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF1_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF1_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF1_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF1_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF1_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF1_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF1_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF1_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF2_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF2_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF2_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF2_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF2_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF2_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF2_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF2_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF2_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF3_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF3_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF3_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF3_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF3_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF3_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF3_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF3_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF3_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF4_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF4_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF4_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF4_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF4_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF4_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF4_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF4_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF4_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF5_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF5_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF5_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF5_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF5_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF5_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF5_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF5_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF5_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF6_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF6_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF6_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF6_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF6_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF6_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF6_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF6_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF6_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF7_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF7_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF7_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF7_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF7_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF7_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF7_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF7_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF7_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF8_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF8_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF8_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF8_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF8_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF8_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF8_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF8_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF8_S"].ToString();

                    cmd.Parameters.AddWithValue("@WOF_DT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF_DT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF_DT_A"].ToString();
                    cmd.Parameters.AddWithValue("@WOF_DT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF_DT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF_DT_C"].ToString();
                    cmd.Parameters.AddWithValue("@WOF_DT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF_DT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF_DT_S"].ToString();

                    cmd.Parameters.AddWithValue("@FAST_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FAST_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FAST_A"].ToString();
                    cmd.Parameters.AddWithValue("@FAST_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FAST_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FAST_C"].ToString();
                    cmd.Parameters.AddWithValue("@FAST_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FAST_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FAST_S"].ToString();

                    cmd.Parameters.AddWithValue("@ECMT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ECMT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ECMT_A"].ToString();
                    cmd.Parameters.AddWithValue("@ECMT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ECMT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ECMT_C"].ToString();
                    cmd.Parameters.AddWithValue("@ECMT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ECMT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ECMT_S"].ToString();

                    cmd.Parameters.AddWithValue("@NO2ECCT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NO2ECCT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NO2ECCT_A"].ToString();
                    cmd.Parameters.AddWithValue("@NO2ECCT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NO2ECCT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NO2ECCT_C"].ToString();
                    cmd.Parameters.AddWithValue("@NO2ECCT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NO2ECCT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NO2ECCT_S"].ToString();

                    cmd.Parameters.AddWithValue("@NA2SDAY_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SDAY_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SDAY_A"].ToString();
                    cmd.Parameters.AddWithValue("@NA2SDAY_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SDAY_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SDAY_A"].ToString();
                    cmd.Parameters.AddWithValue("@NA2SDAY_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SDAY_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SDAY_S"].ToString();

                    cmd.Parameters.AddWithValue("@OXS_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OXS_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OXS_A"].ToString();
                    cmd.Parameters.AddWithValue("@OXS_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OXS_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OXS_C"].ToString();
                    cmd.Parameters.AddWithValue("@OXS_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OXS_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OXS_S"].ToString();

                    cmd.Parameters.AddWithValue("@SOF_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SOF_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SOF_A"].ToString();
                    cmd.Parameters.AddWithValue("@SOF_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SOF_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SOF_C"].ToString();
                    cmd.Parameters.AddWithValue("@SOF_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SOF_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SOF_S"].ToString();

                    cmd.Parameters.AddWithValue("@PFT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFT_A"].ToString();
                    cmd.Parameters.AddWithValue("@PFT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFT_C"].ToString();
                    cmd.Parameters.AddWithValue("@PFT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFT_S"].ToString();

                    cmd.Parameters.AddWithValue("@FILT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FILT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FILT_A"].ToString();
                    cmd.Parameters.AddWithValue("@FILT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FILT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FILT_C"].ToString();
                    cmd.Parameters.AddWithValue("@FILT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FILT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FILT_S"].ToString();

                    cmd.Parameters.AddWithValue("@PRET_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRET_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRET_A"].ToString();
                    cmd.Parameters.AddWithValue("@PRET_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRET_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRET_C"].ToString();
                    cmd.Parameters.AddWithValue("@PRET_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRET_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRET_S"].ToString();

                    cmd.Parameters.AddWithValue("@PFTNORTH_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFTNORTH_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFTNORTH_A"].ToString();
                    cmd.Parameters.AddWithValue("@PFTNORTH_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFTNORTH_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFTNORTH_C"].ToString();
                    cmd.Parameters.AddWithValue("@PFTNORTH_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFTNORTH_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFTNORTH_S"].ToString();

             
                    cmd.Parameters.AddWithValue("@PT78_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PT78_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PT78_A"].ToString();
                    cmd.Parameters.AddWithValue("@PT78_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PT78_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PT78_C"].ToString();
                    cmd.Parameters.AddWithValue("@PT78_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PT78_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PT78_S"].ToString();


                    cmd.Parameters.AddWithValue("@SECT4_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SECT4_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SECT4_A"].ToString();
                    cmd.Parameters.AddWithValue("@SECT4_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SECT4_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SECT4_C"].ToString();
                    cmd.Parameters.AddWithValue("@SECT4_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SECT4_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SECT4_S"].ToString();

                    cmd.Parameters.AddWithValue("@TERT1_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TERT1_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TERT1_A"].ToString();
                    cmd.Parameters.AddWithValue("@TERT1_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TERT1_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TERT1_C"].ToString();
                    cmd.Parameters.AddWithValue("@TERT1_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TERT1_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TERT1_S"].ToString();

                    cmd.Parameters.AddWithValue("@WT77_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WT77_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WT77_A"].ToString();
                    cmd.Parameters.AddWithValue("@WT77_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WT77_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WT77_C"].ToString();
                    cmd.Parameters.AddWithValue("@WT77_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WT77_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WT77_S"].ToString();

                    cmd.Parameters.AddWithValue("@PMT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PMT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PMT_A"].ToString();
                    cmd.Parameters.AddWithValue("@PMT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PMT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PMT_C"].ToString();
                    cmd.Parameters.AddWithValue("@PMT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PMT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PMT_S"].ToString();

                    cmd.Parameters.AddWithValue("@SLT_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SLT_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SLT_A"].ToString();
                    cmd.Parameters.AddWithValue("@SLT_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SLT_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SLT_C"].ToString();
                    cmd.Parameters.AddWithValue("@SLT_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SLT_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SLT_S"].ToString();

                    cmd.Parameters.AddWithValue("@WLTNORTH_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTNORTH_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTNORTH_A"].ToString();
                    cmd.Parameters.AddWithValue("@WLTNORTH_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTNORTH_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTNORTH_C"].ToString();
                    cmd.Parameters.AddWithValue("@WLTNORTH_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTNORTH_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTNORTH_S"].ToString();

                    cmd.Parameters.AddWithValue("@WLTSOUTH_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTSOUTH_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTSOUTH_A"].ToString();
                    cmd.Parameters.AddWithValue("@WLTSOUTH_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTSOUTH_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTSOUTH_C"].ToString();
                    cmd.Parameters.AddWithValue("@WLTSOUTH_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WLTSOUTH_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WLTSOUTH_S"].ToString();

                    cmd.Parameters.AddWithValue("@SAT51_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAT51_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAT51_A"].ToString();
                    cmd.Parameters.AddWithValue("@SAT51_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAT51_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAT51_C"].ToString();
                    cmd.Parameters.AddWithValue("@SAT51_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAT51_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAT51_S"].ToString();

                    cmd.Parameters.AddWithValue("@LICTANK_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LICTANK_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LICTANK_A"].ToString();
                    cmd.Parameters.AddWithValue("@LICTANK_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LICTANK_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LICTANK_C"].ToString();
                    cmd.Parameters.AddWithValue("@LICTANK_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LICTANK_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LICTANK_S"].ToString();

                    cmd.Parameters.AddWithValue("@NA2SBULK_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SBULK_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SBULK_A"].ToString();
                    cmd.Parameters.AddWithValue("@NA2SBULK_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SBULK_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SBULK_C"].ToString();
                    cmd.Parameters.AddWithValue("@NA2SBULK_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["NA2SBULK_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["NA2SBULK_S"].ToString();

                    cmd.Parameters.AddWithValue("@DIGPDS1_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS1_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS1_A"].ToString();
                    cmd.Parameters.AddWithValue("@DIGPDS1_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS1_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS1_C"].ToString();
                    cmd.Parameters.AddWithValue("@DIGPDS1_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS1_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS1_S"].ToString();

                    cmd.Parameters.AddWithValue("@DIGPDS4_A", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS4_A"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS4_A"].ToString();
                    cmd.Parameters.AddWithValue("@DIGPDS4_C", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS4_C"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS4_C"].ToString();
                    cmd.Parameters.AddWithValue("@DIGPDS4_S", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGPDS4_S"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGPDS4_S"].ToString();

                    cmd.Parameters.AddWithValue("@WTA64_PS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WTA64_PS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WTA64_PS"].ToString();
           

                    cmd.Parameters.AddWithValue("@WTA77_PS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WTA77_PS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WTA77_PS"].ToString();
           

                    cmd.Parameters.AddWithValue("@WTA90_PS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WTA90_PS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WTA90_PS"].ToString();
                ;

                    cmd.Parameters.AddWithValue("@SEEDS_TT", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEEDS_TT"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEEDS_TT"].ToString();
             
                    cmd.Parameters.AddWithValue("@SEEDS_ST", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEEDS_ST"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEEDS_ST"].ToString();
      

                    cmd.Parameters.AddWithValue("@SEEDS_PT", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEEDS_PT"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEEDS_PT"].ToString();




                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception s)
            {

            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataRowView drv = e.Row.DataItem as DataRowView;
            //    DropDownList ddlCategories = e.Row.FindControl("ddlccround") as DropDownList;
            //    //if (ddlCategories != null)
            //    {
            //        DataTable dt = getData();
            //        ddlCategories.SelectedValue = dt.Columns[4].ToString();
            //    }
            //}
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            //try
            //{
            //    String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            //    string query;
            //    string date;
            //    if (string.IsNullOrEmpty(HttpContext.Current.Session["misc_date"] as string))
            //    {
            //        date = DateTime.Today.ToShortDateString();
            //        Session["misc_date"] = date;
            //    }
            //    else
            //    { date = Session["misc_date"].ToString(); }
            //    DateTime date_ = Convert.ToDateTime(date);
            //    //string date_ = "2018-03-10";
            //    // DateTime date_ =  DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
            //    date_max.Value = date;

            //    //PH Analysis
            //    query = "  select ccround from lab_misc where mmiscdate = '" + date_ + "'";
            //    using (SqlConnection con = new SqlConnection(strConnString))
            //    {
            //        SqlCommand cmd = new SqlCommand(query);
            //        SqlDataAdapter sda = new SqlDataAdapter();
            //        cmd.Connection = con;
            //        sda.SelectCommand = cmd;
            //        DataSet ds = new DataSet();
            //        sda.Fill(ds);
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            dt = ds.Tables[0];

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            return dt;
        }
    }
}
using QA_LAB_project.Models;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace QA_LAB_project
{
    public partial class SampleInventory : System.Web.UI.Page
    {
        string hkdate_;
        string hkshift_;
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            insertNewRow();
            if (!IsPostBack)
            {
                HttpCookie _userRole = Request.Cookies["UserRole"];
                if (_userRole != null)
                {
                    role.Value = _userRole["role"];


                }

                bindData();
            }

        }

        public string GetName()
        {
            return "hello";
        }
        public void insertNewRow()
        {
            try
            {

                string dt;
                if (HttpContext.Current.Session["misc_date"] != null)
                    dt = HttpContext.Current.Session["misc_date"].ToString();
                else
                    dt = DateTime.Today.ToShortDateString();

                string query = "SELECT Date   FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + dt + "'";
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
            catch (Exception x)
            {
            }
        }
        public void createNewRow(string dt)
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("LAB_sp_Op_Sample_Inventory_Insert", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        protected void shift_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            clearData();
            bindData();
        }
        //protected void tech_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    clearData();
        //    ddlShift.SelectedItem.Value = "0";

        //}

        protected void clearData()
        {

            //        CheckBox1.Checked = false;

            //        CheckBox1.Checked = false;

            //        CheckBox3.Checked = false;

            //        CheckBox5.Checked = false;

            //        CheckBox7.Checked = false;

            //        CheckBox9.Checked = false;

            //        CheckBox10.Checked = false;

            //        CheckBoxSumpPump1.Checked = false;
            //        CheckBoxSumpPump2.Checked = false;

            //    //CheckBox11.Checked = false;



            //    TextBox1.Text = "";
            //    TextBox2.Text = "";
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
                    SqlCommand cmd = new SqlCommand("LAB_sp_Op_Sample_Inventory_Update", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = date;
                    //cmd.Parameters.AddWithValue("@type", SqlDbType.Int).Value = type;

                    //Convert.ToInt16(dt.Rows[0]["WOF"].ToString());
                    cmd.Parameters.AddWithValue("@WOF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["WOF"].ToString());
                    cmd.Parameters.AddWithValue("@WOF_comments", SqlDbType.VarChar).Value = dt.Rows[0]["WOF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@SOF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SOF"].ToString());
                    cmd.Parameters.AddWithValue("@SOF_comments", SqlDbType.VarChar).Value = dt.Rows[0]["SOF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@SUF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SUF"].ToString());
                    cmd.Parameters.AddWithValue("@SUF_comments", SqlDbType.VarChar).Value = dt.Rows[0]["SUF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@WUF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["WUF"].ToString());
                    cmd.Parameters.AddWithValue("@WUF_comments", SqlDbType.VarChar).Value = dt.Rows[0]["WUF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@MTL", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["MTL"].ToString());
                    cmd.Parameters.AddWithValue("@MTL_comments", SqlDbType.VarChar).Value = dt.Rows[0]["MTL_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@SRT", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SRT"].ToString());
                    cmd.Parameters.AddWithValue("@SRT_comments", SqlDbType.VarChar).Value = dt.Rows[0]["SRT_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Washer_Profile", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["WP"].ToString());
                    cmd.Parameters.AddWithValue("@WP_comments", SqlDbType.VarChar).Value = dt.Rows[0]["WP_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Sulfide_Tank", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SUL"].ToString());
                    cmd.Parameters.AddWithValue("@Sulfide_Tank_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["SUL_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Lime_Recovery", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["LIME"].ToString());
                    cmd.Parameters.AddWithValue("@Lime_Recovery_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["LIME_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Filter_Aid", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["FILTER"].ToString());
                    cmd.Parameters.AddWithValue("@Filter_Aid_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["FILTER_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Dilution_Floc", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["DILU"].ToString());
                    cmd.Parameters.AddWithValue("@Dilution_Floc_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["DILU_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Sand_Trap", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SAND"].ToString());
                    cmd.Parameters.AddWithValue("@Sand_Trap_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["SAND_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@TT_Tops", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["TT_TOPS"].ToString());
                    cmd.Parameters.AddWithValue("@TT_Tops_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["TT_TOPS_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@ST_Tops", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["ST_TOPS"].ToString());
                    cmd.Parameters.AddWithValue("@ST_Tops_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["ST_TOPS_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@ST_38", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["ST_38"].ToString());
                    cmd.Parameters.AddWithValue("@ST_38_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["ST_38_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@TT_52", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["TT_52"].ToString());
                    cmd.Parameters.AddWithValue("@TT_52_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["TT_52_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@A6_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["A6_UF"].ToString());
                    cmd.Parameters.AddWithValue("@A6_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["A6_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@B6_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["B6_UF"].ToString());
                    cmd.Parameters.AddWithValue("@B6_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["B6_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@A7_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["A7_UF"].ToString());
                    cmd.Parameters.AddWithValue("@A7_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["A7_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@B7_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["B7_UF"].ToString());
                    cmd.Parameters.AddWithValue("@B7_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["B7_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@A7_OF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["A7_OF"].ToString());
                    cmd.Parameters.AddWithValue("@A7_OF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["A7_OF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@B7_OF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["B7_OF"].ToString());
                    cmd.Parameters.AddWithValue("@B7_OF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["B7_OF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Y15_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["Y15_UF"].ToString());
                    cmd.Parameters.AddWithValue("@Y15_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["Y15_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Y16_UF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["Y16_UF"].ToString());
                    cmd.Parameters.AddWithValue("@Y16_UF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["Y16_UF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Y15_OF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["Y15_OF"].ToString());
                    cmd.Parameters.AddWithValue("@Y15_OF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["Y15_OF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Y16_OF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["Y16_OF"].ToString());
                    cmd.Parameters.AddWithValue("@Y16_OF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["Y16_OF_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@_1b_Cake", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["1BCAKE"].ToString());
                    cmd.Parameters.AddWithValue("@_1b_Cake_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["1BCAKE_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@_2b_Cake", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["2BCAKE"].ToString());
                    cmd.Parameters.AddWithValue("@_2b_Cake_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["2BCAKE_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@B_Filtrate_Cyc", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["BFILT"].ToString());
                    cmd.Parameters.AddWithValue("@B_Filtrate_Cyc_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["BFILT_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Tray_OF", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["TRAY"].ToString());
                    cmd.Parameters.AddWithValue("@Tray_OF_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["TRAY_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Kiln_Feed", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["KILNFEED"].ToString());
                    cmd.Parameters.AddWithValue("@Kiln_Feed_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["KILNFEED_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Dryer_Feed", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["DRYERFEED"].ToString());
                    cmd.Parameters.AddWithValue("@Dryer_Feed_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["DRYERFEED_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Kiln_Discharge", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["KILNDISC"].ToString());
                    cmd.Parameters.AddWithValue("@Kiln_Discharge_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["KILNDISC_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@Dryer_Discharge", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["DRYERDISC"].ToString());
                    cmd.Parameters.AddWithValue("@Dryer_Discharge_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["DRYERDISC_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@North_Fresh", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["NORTHFRE"].ToString());
                    cmd.Parameters.AddWithValue("@North_Fresh_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["NORTHFRE_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@South_Fresh", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["SOUTHFRE"].ToString());
                    cmd.Parameters.AddWithValue("@South_Fresh_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["SOUTHFRE_CMT"].ToString();

                    cmd.Parameters.AddWithValue("@No5", SqlDbType.Int).Value = Convert.ToInt16(dt.Rows[0]["NO5"].ToString());
                    cmd.Parameters.AddWithValue("@No5_Cmt", SqlDbType.VarChar).Value = dt.Rows[0]["NO5_CMT"].ToString();


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception s)
            {

            }
        }

        public static DataTable GenerateTable()
        {
            DataTable dt = new DataTable();

            dt.Clear();

            dt.Columns.Add("WOF", typeof(string));
            dt.Columns.Add("WOF_CMT", typeof(string));

            dt.Columns.Add("SOF", typeof(string));
            dt.Columns.Add("SOF_CMT", typeof(string));

            dt.Columns.Add("SUF", typeof(string));
            dt.Columns.Add("SUF_CMT", typeof(string));

            dt.Columns.Add("WUF", typeof(string));
            dt.Columns.Add("WUF_CMT", typeof(string));

            dt.Columns.Add("MTL", typeof(string));
            dt.Columns.Add("MTL_CMT", typeof(string));

            dt.Columns.Add("SRT", typeof(string));
            dt.Columns.Add("SRT_CMT", typeof(string));


            dt.Columns.Add("WP", typeof(string));
            dt.Columns.Add("WP_CMT", typeof(string));

            dt.Columns.Add("SUL", typeof(string));
            dt.Columns.Add("SUL_CMT", typeof(string));

            dt.Columns.Add("LIME", typeof(string));
            dt.Columns.Add("LIME_CMT", typeof(string));

            dt.Columns.Add("FILTER", typeof(string));
            dt.Columns.Add("FILTER_CMT", typeof(string));

            dt.Columns.Add("DILU", typeof(string));
            dt.Columns.Add("DILU_CMT", typeof(string));

            dt.Columns.Add("SAND", typeof(string));
            dt.Columns.Add("SAND_CMT", typeof(string));

            dt.Columns.Add("TT_TOPS", typeof(string));
            dt.Columns.Add("TT_TOPS_CMT", typeof(string));

            dt.Columns.Add("ST_TOPS", typeof(string));
            dt.Columns.Add("ST_TOPS_CMT", typeof(string));


            dt.Columns.Add("ST_38", typeof(string));
            dt.Columns.Add("ST_38_CMT", typeof(string));

            dt.Columns.Add("TT_52", typeof(string));
            dt.Columns.Add("TT_52_CMT", typeof(string));

            dt.Columns.Add("A6_UF", typeof(string));
            dt.Columns.Add("A6_UF_CMT", typeof(string));


            dt.Columns.Add("B6_UF", typeof(string));
            dt.Columns.Add("B6_UF_CMT", typeof(string));


            dt.Columns.Add("A7_UF", typeof(string));
            dt.Columns.Add("A7_UF_CMT", typeof(string));


            dt.Columns.Add("B7_UF", typeof(string));
            dt.Columns.Add("B7_UF_CMT", typeof(string));


            dt.Columns.Add("A7_OF", typeof(string));
            dt.Columns.Add("A7_OF_CMT", typeof(string));


            dt.Columns.Add("B7_OF", typeof(string));
            dt.Columns.Add("B7_OF_CMT", typeof(string));


            dt.Columns.Add("Y15_UF", typeof(string));
            dt.Columns.Add("Y15_UF_CMT", typeof(string));


            dt.Columns.Add("Y16_UF", typeof(string));
            dt.Columns.Add("Y16_UF_CMT", typeof(string));

            dt.Columns.Add("Y15_OF", typeof(string));
            dt.Columns.Add("Y15_OF_CMT", typeof(string));

            dt.Columns.Add("Y16_OF", typeof(string));
            dt.Columns.Add("Y16_OF_CMT", typeof(string));

            dt.Columns.Add("1BCAKE", typeof(string));
            dt.Columns.Add("1BCAKE_CMT", typeof(string));

            dt.Columns.Add("2BCAKE", typeof(string));
            dt.Columns.Add("2BCAKE_CMT", typeof(string));

            dt.Columns.Add("BFILT", typeof(string));
            dt.Columns.Add("BFILT_CMT", typeof(string));

            dt.Columns.Add("TRAY", typeof(string));
            dt.Columns.Add("TRAY_CMT", typeof(string));

            dt.Columns.Add("KILNFEED", typeof(string));
            dt.Columns.Add("KILNFEED_CMT", typeof(string));

            dt.Columns.Add("DRYERFEED", typeof(string));
            dt.Columns.Add("DRYERFEED_CMT", typeof(string));

            dt.Columns.Add("KILNDISC", typeof(string));
            dt.Columns.Add("KILNDISC_CMT", typeof(string));

            dt.Columns.Add("DRYERDISC", typeof(string));
            dt.Columns.Add("DRYERDISC_CMT", typeof(string));

            dt.Columns.Add("NORTHFRE", typeof(string));
            dt.Columns.Add("NORTHFRE_CMT", typeof(string));

            dt.Columns.Add("SOUTHFRE", typeof(string));
            dt.Columns.Add("SOUTHFRE_CMT", typeof(string));

            dt.Columns.Add("NO5", typeof(string));
            dt.Columns.Add("NO5_CMT", typeof(string));


            return dt;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            
               
                DateTime HKDate;
                //string HKShift = ddlShift.SelectedItem.Text;

                if (Session["misc_date"] != null)
                {
                    HKDate = DateTime.Parse(Session["misc_date"].ToString());
                }
                else
                {
                    HKDate = DateTime.Today;
                }

              



                //}


                try
                {
                    DataTable dt = GenerateTable();
                    var row = dt.NewRow();
                    dt.Rows.Add(row);



                    foreach (GridViewRow rows in gv_section2.Rows)
                    {

                        System.Web.UI.WebControls.CheckBox chkbox1 = (System.Web.UI.WebControls.CheckBox)rows.FindControl("gv_sec2_c3");
                        string a1 = chkbox1.Checked ? "1" : "0";
                        //int a1 = (chkbox1.Checked.ToString());
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_sec2_c4");
                        string a2 = txtbox2.Text;
                      

                        if (rows.RowIndex == 0)
                        {
                            row["WOF"] = a1;
                            row["WOF_CMT"] = a2;
                          
                        }
                        if (rows.RowIndex == 1)
                        {
                            row["SOF"] = a1;
                            row["SOF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 2)
                        {
                            row["SUF"] = a1;
                            row["SUF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 3)
                        {
                            row["WUF"] = a1;
                            row["WUF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 4)
                        {
                            row["MTL"] = a1;
                            row["MTL_CMT"] = a2;
                        }
                        if (rows.RowIndex == 5)
                        {
                            row["SRT"] = a1;
                            row["SRT_CMT"] = a2;
                        }
                        if (rows.RowIndex == 6)
                        {
                            row["WP"] = a1;
                            row["WP_CMT"] = a2;
                        }
                        if (rows.RowIndex == 7)
                        {
                            row["SUL"] = a1;
                            row["SUL_CMT"] = a2;
                        }
                        if (rows.RowIndex == 8)
                        {
                            row["LIME"] = a1;
                            row["LIME_CMT"] = a2;
                        }
                        if (rows.RowIndex == 9)
                        {
                            row["FILTER"] = a1;
                            row["FILTER_CMT"] = a2;
                        }
                        if (rows.RowIndex == 10)
                        {
                            row["DILU"] = a1;
                            row["DILU_CMT"] = a2;
                        }
                        if (rows.RowIndex == 11)
                        {
                            row["SAND"] = a1;
                            row["SAND_CMT"] = a2;
                        }
                        
                      

                    }


                    foreach (GridViewRow rows in gv_section3.Rows)
                    {

                        System.Web.UI.WebControls.CheckBox chkbox1 = (System.Web.UI.WebControls.CheckBox)rows.FindControl("gv_sec3_c3");
                    string a1 = chkbox1.Checked ? "1" : "0";
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_sec3_c4");
                        string a2 = txtbox2.Text;


                        if (rows.RowIndex == 0)
                        {
                            row["TT_TOPS"] = a1;
                            row["TT_TOPS_CMT"] = a2;

                        }
                        if (rows.RowIndex == 1)
                        {
                            row["ST_TOPS"] = a1;
                            row["ST_TOPS_CMT"] = a2;
                        }
                        if (rows.RowIndex == 2)
                        {
                            row["ST_38"] = a1;
                            row["ST_38_CMT"] = a2;
                        }
                        if (rows.RowIndex == 3)
                        {
                            row["TT_52"] = a1;
                            row["TT_52_CMT"] = a2;
                        }
                        if (rows.RowIndex == 4)
                        {
                            row["A6_UF"] = a1;
                            row["A6_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 5)
                        {
                            row["B6_UF"] = a1;
                            row["B6_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 6)
                        {
                            row["A7_UF"] = a1;
                            row["A7_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 7)
                        {
                            row["B7_UF"] = a1;
                            row["B7_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 8)
                        {
                            row["A7_OF"] = a1;
                            row["A7_OF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 9)
                        {
                            row["B7_OF"] = a1;
                            row["B7_OF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 10)
                        {
                            row["Y15_UF"] = a1;
                            row["Y15_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 11)
                        {
                            row["Y16_UF"] = a1;
                            row["Y16_UF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 12)
                        {
                            row["Y15_OF"] = a1;
                            row["Y15_OF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 13)
                        {
                            row["Y16_OF"] = a1;
                            row["Y16_OF_CMT"] = a2;
                        }
                        if (rows.RowIndex == 14)
                        {
                            row["1BCAKE"] = a1;
                            row["1BCAKE_CMT"] = a2;
                        }
                        if (rows.RowIndex == 15)
                        {
                            row["2BCAKE"] = a1;
                            row["2BCAKE_CMT"] = a2;
                        }
                        if (rows.RowIndex == 16)
                        {
                            row["BFILT"] = a1;
                            row["BFILT_CMT"] = a2;
                        }
                        if (rows.RowIndex == 17)
                        {
                            row["TRAY"] = a1;
                            row["TRAY_CMT"] = a2;
                        }
                        if (rows.RowIndex == 18)
                        {
                            row["KILNFEED"] = a1;
                            row["KILNFEED_CMT"] = a2;
                        }
                        if (rows.RowIndex == 19)
                        {
                            row["DRYERFEED"] = a1;
                            row["DRYERFEED_CMT"] = a2;
                        }
                        if (rows.RowIndex == 20)
                        {
                            row["KILNDISC"] = a1;
                            row["KILNDISC_CMT"] = a2;
                        }
                        if (rows.RowIndex == 21)
                        {
                            row["DRYERDISC"] = a1;
                            row["DRYERDISC_CMT"] = a2;

                        }

                        if (rows.RowIndex == 22)
                        {
                            row["NORTHFRE"] = a1;
                            row["NORTHFRE_CMT"] = a2;

                        }
                        if (rows.RowIndex == 23)
                        {
                            row["SOUTHFRE"] = a1;
                            row["SOUTHFRE_CMT"] = a2;


                        }
                        if (rows.RowIndex == 24)
                        {
                            row["NO5"] = a1;
                            row["NO5_CMT"] = a2;
                        }

                    }

                    if (dt.Rows.Count > 0)
                    {
                        Update(dt);
                    }




                    bindData();
                    this.Response.Redirect(this.Request.Url.ToString());


            }
            catch (Exception exs)
            {
                string filePath = @"C:\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + exs.Message + "<br/>" + Environment.NewLine + "StackTrace :" + exs.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }


        
}
    
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {

            HttpContext.Current.Session["misc_date"] = selDate;
            //HttpContext.Current.Session["hk_shift"] = hkShift;

            //hkdate_ = hkDate.Substring(0, 10);
            // hkshift_ = hkShift;
            //bindData();


            return HttpContext.Current.Session["misc_date"].ToString();

        }


        public void bindData()
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

            //query = " select * FROM [Lab].[dbo].[LAB_HOUSEKEEPING] h inner join LAB_TECHNICIAN t on t.TechId = h.Tech WHERE Date = '" + hkdate_ + "' and Shift = '" + hkshift_ + "' and Tech = '" + tech + "' ";
            //SECTION 2
            query = " select 'WOF' as [a], '1/round' as [b], WOF as [c], WOF_comments as [d] FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all" +
                  " select 'SOF', '1/shift', SOF, SOF_comments FROM[Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all" +
                  " select 'SUF', '1/shift', SUF, SUF_comments FROM[Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "'  union all " +
                  " select 'WUF', '1/round', WUF, WUF_comments FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
                  "select 'MTL', '1/round', MTL, MTL_comments FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
                  "select 'SRT', '1/round', SRT, SRT_comments FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory]  WHERE Date = '" + date_ + "' union all " +
                  " select 'WASHER PROFILE', '2/week', Washer_Profile, WP_comments FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
                  " select 'Sulfide Tank', '2/day', Sulfide_Tank, Sulfide_Tank_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
                  " select 'Lime Recovery', '1/day', Lime_Recovery, Lime_Recovery_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
                  " select 'Filter Aid', '1/day', Filter_Aid, Filter_Aid_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' UNION ALL " +
                  " select 'Dilution Floc', '1/day', Dilution_Floc, Dilution_Floc_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "'  UNION ALL " +
                  " select 'Sand Trap', '1/day', Sand_Trap, Sand_Trap_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "'";

            //Section 3
            query += " select 'TT Tops' as [a], '2/day' as [b],TT_Tops as [c], TT_Tops_Cmt as [d] FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'ST Tops', '2/day', ST_Tops, ST_Tops_Cmt FROM[Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'ST 38', '1/day', ST_38,ST_38_Cmt FROM[Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'TT52', '1/day', TT_52, TT_52_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'A6 UF', '1/day', A6_UF, A6_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'B6 UF', '1/day', B6_UF, B6_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all  " +
               " select 'A7 UF', '1/day', A7_UF, A7_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'B7 UF', '1/day', B7_UF, B7_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'A7 OF', '2/day', A7_OF, A7_OF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'B7 OF', '2/day', B7_OF, B7_OF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Y15 UF', '1/day', Y15_UF, Y15_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Y16 UF', '1/day', Y16_UF, Y16_UF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Y15 OF', '2/day', Y15_OF, Y15_OF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Y16 OF', '2/day', Y16_OF, Y16_OF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select '1B Cake', '1/day', _1b_Cake, _1b_Cake_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select '2B Cake', '1/day', _2b_Cake, _2b_Cake_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'B Filtrate Cyc. OF', '1/day', B_Filtrate_Cyc, B_Filtrate_Cyc_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Tray OFs', '1/day', Tray_OF, Tray_OF_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "'union all " +
               " select 'Kiln Feed', '2/day', Kiln_Feed, Kiln_Feed_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Dryer Feed', '1/day', Dryer_Feed, Dryer_Feed_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Kiln Discharge', '2/day', Kiln_Discharge, Kiln_Discharge_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'Dryer Discharge', '2/day', Dryer_Discharge, Dryer_Discharge_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'North Fresh W Tk', '2/day', North_Fresh, North_Fresh_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select 'South Fresh W Tk', '2/day', South_Fresh, South_Fresh_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' union all " +
               " select '#5 W Tk', '2/day', No5, No5_Cmt FROM [Lab].[dbo].[LAB_DAILY_OP_Sample_Inventory] WHERE Date = '" + date_ + "' ";


            using (SqlConnection con = new SqlConnection(strConnString))
            {
                SqlCommand cmd = new SqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                sda.SelectCommand = cmd;

                sda.Fill(ds);
                string s = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_section2.DataSource = ds.Tables[0];
                    gv_section2.DataBind();


                    gv_section3.DataSource = ds.Tables[1];
                    gv_section3.DataBind();
                }



            }
            //validateReceived(ds.Tables[0]);


        
    
}

        protected void gv_sec2_onrowdatabound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //System.Web.UI.WebControls.CheckBox chkRow = (r.FindControl("MainContent_gv_section2_ctl00_" + ) as System.Web.UI.WebControls.CheckBox);
            // chkRow.Checked = true;
            foreach (GridViewRow r in gv_section2.Rows)
            {
                int count = r.RowIndex;
                if (r.RowType == DataControlRowType.DataRow)
                {

                    //for (int i = 0; i < 12; i++)
                    //{
                        if ( ds.Tables[0].Rows[count][2].ToString() == "1")
                        {
                            System.Web.UI.WebControls.CheckBox chkRow = (r.Cells[0].FindControl("gv_sec2_c3") as System.Web.UI.WebControls.CheckBox);

                            chkRow.Checked = true;


                        }

                    else
                    {
                        System.Web.UI.WebControls.CheckBox chkRow = (r.Cells[0].FindControl("gv_sec2_c3") as System.Web.UI.WebControls.CheckBox);

                        chkRow.Checked = false;
                    }
                 

                    // }
                    //if (chkRow.Checked)
                    //{
                    //    //if checked do something
                    //}
                }


                //string rowIndex = r.RowIndex.ToString();
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{


                //    for (int i = 0; i < 12; i++)
                //    {
                //        if (ds.Tables[0].Rows[i][2].ToString() == "1")

                //        {
                //            if ((rowIndex != "0") )
                //            {
                //                string s = "";
                             
                //                System.Web.UI.WebControls.CheckBox chkRow = (r.FindControl("MainContent_gv_section2_ctl00_" + rowIndex) as System.Web.UI.WebControls.CheckBox);
                //                chkRow.Checked = true;
                //            }
                //        }
                //        else
                //        {
                //            if ((rowIndex != "0"))
                //            {
                //                string t = "";
                //                System.Web.UI.WebControls.CheckBox chkRow = (r.FindControl("MainContent_gv_section2_ctl00_" + rowIndex) as System.Web.UI.WebControls.CheckBox);
                //                chkRow.Checked = false;
                //            }
                //        }

                //    }
                //}

            }


 

    }
        protected void gv_sec3_onrowdatabound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {



            foreach (GridViewRow r in gv_section3.Rows)
            {
                int count = r.RowIndex;
                if (r.RowType == DataControlRowType.DataRow)
                {

                    //for (int i = 0; i < 12; i++)
                    //{
                    if (ds.Tables[1].Rows[count][2].ToString() == "1")
                    {
                        System.Web.UI.WebControls.CheckBox chkRow = (r.Cells[0].FindControl("gv_sec3_c3") as System.Web.UI.WebControls.CheckBox);

                        chkRow.Checked = true;


                    }
                    else
                    {

                        System.Web.UI.WebControls.CheckBox chkRow = (r.Cells[0].FindControl("gv_sec3_c3") as System.Web.UI.WebControls.CheckBox);

                        chkRow.Checked = false;
                    }


                    // }
                    //if (chkRow.Checked)
                    //{
                    //    //if checked do something
                    //}
                }


            }
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            //try
            //{
            //    string Ques = ((TextBox)gv_ccontrol.Rows[1].FindControl("gv_ccontrol_caustic")).Text;
            //    string Ques_ = ((TextBox)gv_ccontrol.Rows[1].FindControl("gv_ccontrol_ac")).Text;
            //    DataTable dt = GenerateTable();
            //    var row = dt.NewRow();
            //    dt.Rows.Add(row);
            //    int pressSolidColor = 0;
            //    foreach (GridViewRow rows in gv_ccontrol.Rows)
            //    {

            //        System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_caustic");
            //        string a1 = txtbox1.Text;
            //        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_ac");
            //        string a2 = txtbox2.Text;
            //        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_cs");
            //        string a3 = txtbox3.Text;
            //        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_aim");
            //        string a4 = txtbox4.Text;



            //        //CCROUND 0300
            //        if (Session["ccround"].ToString() == "0300" || Session["ccround"].ToString() == "0900")

            //        {

            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;
            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;
            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;
            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 19)
            //            {
            //                row["A7OVERFLOWCAUSTIC"] = a1;
            //                row["A7OVERFLOWAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 20)
            //            {
            //                row["B7OVERFLOWCAUSTIC"] = a1;
            //                row["B7OVERFLOWAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 21)
            //            {
            //                row["CY15OVERFLOW"] = a1;
            //                row["ACY15OVERFLOW"] = a2;
            //            }
            //            else if (rows.RowIndex == 22)
            //            {
            //                row["CY16OVERFLOW"] = a1;
            //                row["ACY16OVERFLOW"] = a2;
            //            }
            //        }

            //        //CCROUND 0600
            //        else if (Session["ccround"].ToString() == "0600")
            //        {
            //            pressSolidColor = ddlcolor.SelectedIndex;
            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 10)
            //            {
            //                row["SUFCAUSTIC"] = a1;
            //                row["SUFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 11)
            //            {
            //                row["T1CAUSTIC"] = a1;
            //                row["T1AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 12)
            //            {
            //                row["T3CAUSTIC"] = a1;
            //                row["T3AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 13)
            //            {
            //                row["T7CAUSTIC"] = a1;
            //                row["T7AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 16)
            //            {
            //                row["CAG1"] = a1;
            //                row["ACAG1"] = a2;
            //            }
            //            else if (rows.RowIndex == 17)
            //            {
            //                row["CAG3"] = a1;
            //                row["ACAG3"] = a2;
            //            }
            //            else if (rows.RowIndex == 18)
            //            {
            //                row["CAG7"] = a1;
            //                row["ACAG7"] = a2;
            //            }
            //        }

            //        //ccround 1200
            //        else if (Session["ccround"].ToString() == "1200" || Session["ccround"].ToString() == "2400")
            //        {
            //            pressSolidColor = ddlcolor.SelectedIndex;
            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }

            //        }

            //        //ccround 1500
            //        else if (Session["ccround"].ToString() == "1500")
            //        {
            //            pressSolidColor = 0;
            //            ddlcolor.Visible = false;
            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 11)
            //            {
            //                row["T1CAUSTIC"] = a1;
            //                row["T1AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 13)
            //            {
            //                row["T7CAUSTIC"] = a1;
            //                row["T7AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 16)
            //            {
            //                row["CAG1"] = a1;
            //                row["ACAG1"] = a2;
            //            }
            //            else if (rows.RowIndex == 17)
            //            {
            //                row["CAG3"] = a1;
            //                row["ACAG3"] = a2;
            //            }
            //            else if (rows.RowIndex == 18)
            //            {
            //                row["CAG7"] = a1;
            //                row["ACAG7"] = a2;
            //            }
            //        }

            //        //CCROUND 1800
            //        else if (Session["ccround"].ToString() == "1800")
            //        {
            //            pressSolidColor = ddlcolor.SelectedIndex;
            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 10)
            //            {
            //                row["SUFCAUSTIC"] = a1;
            //                row["SUFAC"] = a2;
            //            }

            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 19)
            //            {
            //                row["A7OVERFLOWCAUSTIC"] = a1;
            //                row["A7OVERFLOWAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 20)
            //            {
            //                row["B7OVERFLOWCAUSTIC"] = a1;
            //                row["B7OVERFLOWAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 21)
            //            {
            //                row["CY15OVERFLOW"] = a1;
            //                row["ACY15OVERFLOW"] = a2;
            //            }
            //            else if (rows.RowIndex == 22)
            //            {
            //                row["CY16OVERFLOW"] = a1;
            //                row["ACY16OVERFLOW"] = a2;
            //            }
            //        }

            //        //ccround 2100
            //        else if (Session["ccround"].ToString() == "2100")
            //        {
            //            ddlcolor.Visible = false;
            //            //pressSolidColor = ddlcolor.SelectedIndex;
            //            if (rows.RowIndex == 0)
            //            {
            //                row["TESTTANKCAUSTIC"] = a1;
            //                row["TESTTANKAC"] = a2;
            //                row["TESTTANKCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 1)
            //            {
            //                row["CTRIDIGESTOR"] = a1;
            //                row["ACTRIDIGESTOR"] = a2;
            //                row["TRIDIGESTORCS"] = a3;
            //                row["TRIDIGESTORAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 2)
            //            {
            //                row["CFT5"] = a1;
            //                row["ACFT5"] = a2;
            //                row["FT5CS"] = a3;
            //                row["FT5AIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 3)
            //            {
            //                row["CDIGDISCH"] = a1;
            //                row["ACDIGDISCH"] = a2;
            //                row["DIGDISCHCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 4)
            //            {
            //                row["SETTLERFEEDCAUSTIC"] = a1;
            //                row["SETTLERFEEDAC"] = a2;
            //                row["SETTLERFEEDCS"] = a3;

            //            }
            //            else if (rows.RowIndex == 5)
            //            {
            //                row["PRESSFEEDCAUSTIC"] = a1;
            //                row["PRESSFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 6)
            //            {
            //                row["LTPCAUSTIC"] = a1;
            //                row["LTPAC"] = a2;
            //                row["LTPAIM"] = a4;
            //            }
            //            else if (rows.RowIndex == 7)
            //            {
            //                row["EVAPFEEDCAUSTIC"] = a1;
            //                row["EVAPFEEDAC"] = a2;

            //            }
            //            else if (rows.RowIndex == 8)
            //            {
            //                row["CEVAPDISCH"] = a1;
            //                row["ACEVAPDISCH"] = a2;
            //            }
            //            else if (rows.RowIndex == 9)
            //            {
            //                row["WOFCAUSTIC"] = a1;
            //                row["WOFAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 11)
            //            {
            //                row["T1CAUSTIC"] = a1;
            //                row["T1AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 13)
            //            {
            //                row["T7CAUSTIC"] = a1;
            //                row["T7AC"] = a2;
            //            }
            //            else if (rows.RowIndex == 14)
            //            {
            //                row["EVAPCCCAUSTIC"] = a1;
            //                row["EVAPCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 15)
            //            {
            //                row["PRESSCCCAUSTIC"] = a1;
            //                row["PRESSCCAC"] = a2;
            //            }
            //            else if (rows.RowIndex == 16)
            //            {
            //                row["CAG1"] = a1;
            //                row["ACAG1"] = a2;
            //            }

            //            else if (rows.RowIndex == 18)
            //            {
            //                row["CAG7"] = a1;
            //                row["ACAG7"] = a2;
            //            }

            //        }

            //    }

            //    foreach (GridViewRow rows in gv_soda.Rows)
            //    {
            //        System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_soda_gpl");
            //        string a1 = txtbox1.Text;
            //        if (rows.RowIndex == 0)
            //            row["LKD4SODA"] = a1;
            //        else if (rows.RowIndex == 1)
            //            row["WUFSODA"] = a1;
            //        else if (rows.RowIndex == 2)
            //            row["MTLSODA"] = a1;
            //        else if (rows.RowIndex == 3)
            //            row["SRTSODA"] = a1;
            //        else if (rows.RowIndex == 4)
            //            row["PFMG"] = a1;
            //        else if (rows.RowIndex == 5)
            //            row["BADCOND"] = a1;

            //    }


            //    row["PSCOLOR"] = pressSolidColor;
            //    if (dt.Rows.Count > 0)
            //    {
            //        Update(dt);
            //    }

            //    gvBind();
            //    this.Response.Redirect(this.Request.Url.ToString());

            //}
            //catch (Exception exs)
            //{
            //    string filePath = @"C:\Error.txt";

            //    using (StreamWriter writer = new StreamWriter(filePath, true))
            //    {
            //        writer.WriteLine("Message :" + exs.Message + "<br/>" + Environment.NewLine + "StackTrace :" + exs.StackTrace +
            //           "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
            //        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            //    }
            //}
        }


    }
}
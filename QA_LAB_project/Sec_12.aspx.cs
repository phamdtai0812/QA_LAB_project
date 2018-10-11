using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using QA_LAB_project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Sec_12 : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        int rowIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!this.IsPostBack)
            {
                //role.Value = Session["Role"].ToString();
                HttpCookie _userRole = Request.Cookies["UserRole"];
                if (_userRole != null)
                {
                    role.Value = _userRole["role"];
                }
                insertNewRow();
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
                if (string.IsNullOrEmpty(HttpContext.Current.Session["sec12_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["sec12_date"] = date;
                }
                else
                { date = Session["sec12_date"].ToString(); }
                date_max.Value = date;

                query = "select * FROM LAB_SEC1_DATA where  SDDATE = '" + date + "'";

                //washer profile
                query += "SELECT wp0 as [wp0], wp1 as [wp1], wp2 as [wp2]  FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "' union all " +
                        " select wp3  as [wp0] , wp4 as [wp1], wp5 as [wp2] FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "' union all " +
                        " select wp6  as [wp0], wp7 as [wp1], wp8 as [wp2] FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "'";


                //pds no=
                query += "SELECT 'No1' as 'PDS No', CPDS1 , APDS1, SPDS1, D1PDS FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "'" +
                    " union all select 'No2', CPDS2, APDS2, SPDS2, D2PDS FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "' " +
                    " union all select 'No3', CPDS3, APDS3, SPDS3, D3PDS FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "'" +
                    " union all select 'No4', CPDS4, APDS4, SPDS4, D4PDS FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "'" +
                    " union all select 'Ret Tank', CRETTANK, ARETTANK, SRETTANK, DRETTANK FROM LAB_SEC1_DATA WHERE SDDATE = '" + date + "'  ";


                //sof/wof
                query += " select * from Lab_mgLSolids where mgLSolids_DATE = '" + date + "' ";
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
                        gv_psa.DataSource = ds.Tables[0];
                        gv_psa.DataBind();

                        gv_gpl.DataSource = ds.Tables[0];
                        gv_gpl.DataBind();

                        gv_gpls.DataSource = ds.Tables[0];
                        gv_gpls.DataBind();

                        gv_sa.DataSource = ds.Tables[0];
                        gv_sa.DataBind();

                        gv_soda.DataSource = ds.Tables[0];
                        gv_soda.DataBind();

                        gv_sr.DataSource = ds.Tables[0];
                        gv_sr.DataBind();

                        gv_loa.DataSource = ds.Tables[0];
                        gv_loa.DataBind();

                        gv_spo.DataSource = ds.Tables[0];
                        gv_spo.DataBind();

                        gv_taa.DataSource = ds.Tables[0];
                        gv_taa.DataBind();

                        gv_ltpca.DataSource = ds.Tables[0];
                        gv_ltpca.DataBind();

                    }
                    //WASHER PROFILE
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_wp.DataSource = ds.Tables[1];
                        gv_wp.DataBind();
                    }

                    //pds
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gv_pds.DataSource = ds.Tables[2];
                        gv_pds.DataBind();
                    }

                    gv_solids.DataSource = ds.Tables[3];
                    gv_solids.DataBind();
          


                }

            }
            catch (Exception ex)
            {

            }
        }
        public static DataTable GenerateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SASUF", typeof(string));
            dt.Columns.Add("SAWUF", typeof(string));
            dt.Columns.Add("SAMTL", typeof(string));
            dt.Columns.Add("SAFA", typeof(string));
            dt.Columns.Add("TRIDIGEST", typeof(string));
            dt.Columns.Add("FT5", typeof(string));
            dt.Columns.Add("DIGDISCH", typeof(string));
            dt.Columns.Add("SALR", typeof(string));
            dt.Columns.Add("GPLS1", typeof(string));
            dt.Columns.Add("GPLS2", typeof(string));
            dt.Columns.Add("GPLS3", typeof(string));
            dt.Columns.Add("GPLS4", typeof(string));
            dt.Columns.Add("GPLSBF", typeof(string));
            dt.Columns.Add("GPLSOXSET", typeof(string));
            dt.Columns.Add("SABF", typeof(string));
            dt.Columns.Add("SAOXSET", typeof(string));
            dt.Columns.Add("SALIMEREC", typeof(string));
            dt.Columns.Add("SALP", typeof(string));
            dt.Columns.Add("OAOXSET", typeof(string));
            dt.Columns.Add("OABF", typeof(string));
            dt.Columns.Add("OA1CAKE", typeof(string));
            dt.Columns.Add("OA2CAKE", typeof(string));
            dt.Columns.Add("OASTSEED", typeof(string));
            dt.Columns.Add("OA6AB", typeof(string));
            dt.Columns.Add("OAPF", typeof(string));
            dt.Columns.Add("SRS", typeof(string));
            dt.Columns.Add("SRSTARCHI", typeof(string));
            dt.Columns.Add("SRSTARCHS", typeof(string));
            dt.Columns.Add("SRPF", typeof(string));
            dt.Columns.Add("TAAA4FT", typeof(string));
            dt.Columns.Add("TAAASF", typeof(string));
            dt.Columns.Add("TAAASUF", typeof(string));
            dt.Columns.Add("TAAAWUF", typeof(string));
            dt.Columns.Add("TAAAMTL", typeof(string));
            dt.Columns.Add("LTPCA", typeof(string));
            dt.Columns.Add("LTP", typeof(string));
            dt.Columns.Add("SPENTLIQ", typeof(string));
            dt.Columns.Add("Y1516", typeof(string));
            dt.Columns.Add("WP0", typeof(string));
            dt.Columns.Add("WP1", typeof(string));
            dt.Columns.Add("WP2", typeof(string));
            dt.Columns.Add("WP3", typeof(string));
            dt.Columns.Add("WP4", typeof(string));
            dt.Columns.Add("WP5", typeof(string));
            dt.Columns.Add("WP6", typeof(string));
            dt.Columns.Add("WP7", typeof(string));
            dt.Columns.Add("WP8", typeof(string));
            dt.Columns.Add("TD", typeof(string));
            dt.Columns.Add("SAST", typeof(string));

            //PDS
            dt.Columns.Add("CPDS1", typeof(string));
            dt.Columns.Add("CPDS2", typeof(string));
            dt.Columns.Add("CPDS3", typeof(string));
            dt.Columns.Add("CPDS4", typeof(string));
            dt.Columns.Add("CRETTANK", typeof(string));
            dt.Columns.Add("APDS1", typeof(string));
            dt.Columns.Add("APDS2", typeof(string));
            dt.Columns.Add("APDS3", typeof(string));
            dt.Columns.Add("APDS4", typeof(string));
            dt.Columns.Add("ARETTANK", typeof(string));
            dt.Columns.Add("SPDS1", typeof(string));
            dt.Columns.Add("SPDS2", typeof(string));
            dt.Columns.Add("SPDS3", typeof(string));
            dt.Columns.Add("SPDS4", typeof(string));
            dt.Columns.Add("SRETTANK", typeof(string));
            dt.Columns.Add("DRETTANK", typeof(string));
            dt.Columns.Add("D1PDS", typeof(string));
            dt.Columns.Add("D2PDS", typeof(string));
            dt.Columns.Add("D3PDS", typeof(string));
            dt.Columns.Add("D4PDS", typeof(string));
           

            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {
           
            try
            {
                DataTable dt = GenerateTable();
                var row = dt.NewRow();
                dt.Rows.Add(row);
                foreach (GridViewRow rows in gv_psa.Rows)
                {
                        System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_suf");
                        string a1 = txtbox1.Text;
                            System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_wuf");
                        string a2 = txtbox2.Text;
                            System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_mtl");
                        string a3 = txtbox3.Text;
                                System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_faid");
                        string a4 = txtbox4.Text;
                            System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_lrec");
                        string a5 = txtbox5.Text;
                        row["SASUF"] = a1;
                        row["SAWUF"] = a2;
                        row["SAMTL"] = a3;
                        row["SAFA"] = a4;
                        row["SALR"] = a5;
                }
                foreach (GridViewRow rows in gv_gpl.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpl_tri");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpl_no5ft");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpl_ddisch");
                    string a3 = txtbox3.Text;
              
                    row["TRIDIGEST"] = a1;
                    row["FT5"] = a2;
                    row["DIGDISCH"] = a3;
                }
                foreach (GridViewRow rows in gv_gpls.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_gpls1");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_gpls2");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_gpls3");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_gpls4");
                    string a4 = txtbox4.Text;
                    System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_bf");
                    string a5 = txtbox5.Text;
                    System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_gpls_oxset");
                    string a6 = txtbox6.Text;

                    row["GPLS1"] = a1;
                    row["GPLS2"] = a2;
                    row["GPLS3"] = a3;
                    row["GPLS4"] = a4;
                    row["GPLSBF"] = a5;
                    row["GPLSOXSET"] = a6;
                }
                foreach (GridViewRow rows in gv_soda.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_soda_bf");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_soda_oxset");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_soda_lrec");
                    string a3 = txtbox3.Text;

                    row["SABF"] = a1;
                    row["SAOXSET"] = a2;
                    row["SALIMEREC"] = a3;
                }
                foreach (GridViewRow rows in gv_sa.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sa_st");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sa_lp");
                    string a2 = txtbox2.Text;
                    
                    row["SAST"] = a1;
                    row["SALP"] = a2;
                }
                foreach (GridViewRow rows in gv_sr.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sr_rf");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sr_srs");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sr_is");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sr_ss");
                    string a4 = txtbox4.Text;
                    row["SRPF"] = a1;
                    row["SRS"] = a2;
                    row["SRSTARCHI"] = a3;
                    row["SRSTARCHS"] = a4;
                }
                foreach (GridViewRow rows in gv_loa.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_loa_ltp");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_loa_sl");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_loa_bf");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_loa_oxs");
                    string a4 = txtbox4.Text;
                    row["LTP"] = a1;
                    row["SPENTLIQ"] = a2;
                    row["OABF"] = a3;
                    row["OAOXSET"] = a4;
                }
                foreach (GridViewRow rows in gv_spo.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_1bc");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_2bc");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_sts");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_6ab");
                    string a4 = txtbox4.Text;
                    System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_y15");
                    string a5 = txtbox5.Text;
                    System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_spo_pf");
                    string a6 = txtbox6.Text;

                    row["OA1CAKE"] = a1;
                    row["OA2CAKE"] = a2;
                    row["OASTSEED"] = a3;
                    row["OA6AB"] = a4;
                    row["Y1516"] = a5;
                    row["OAPF"] = a6;
                }
                foreach (GridViewRow rows in gv_taa.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_td");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_n5ft");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_sf");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_suf");
                    string a4 = txtbox4.Text;
                    System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_wuf");
                    string a5 = txtbox5.Text;
                    System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_taa_mtl");
                    string a6 = txtbox6.Text;

                    row["TD"] = a1;
                    row["TAAA4FT"] = a2;
                    row["TAAASF"] = a3;
                    row["TAAASUF"] = a4;
                    row["TAAAWUF"] = a5;
                    row["TAAAMTL"] = a6;
                }
                foreach (GridViewRow rows in gv_ltpca.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ltpca_ltpca");
                    string a1 = txtbox1.Text;
                

                    row["LTPCA"] = a1;
                  
                }
                foreach (GridViewRow rows in gv_wp.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wp_wp0");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wp_wp1");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wp_wp2");
                    string a3 = txtbox3.Text;
                   if(rows.RowIndex == 0)
                    {
                        row["WP0"] = a1;
                        row["WP1"] = a2;
                        row["WP2"] = a3;
                    }
                    if (rows.RowIndex == 1)
                    {
                        row["WP3"] = a1;
                        row["WP4"] = a2;
                        row["WP5"] = a3;
                    }
                    if (rows.RowIndex == 2)
                    {
                        row["WP6"] = a1;
                        row["WP7"] = a2;
                        row["WP8"] = a3;
                    }

                }
                foreach (GridViewRow rows in gv_pds.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pds_cpds");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pds_apds");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pds_spds");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pds_d1pds");
                    string a4 = txtbox4.Text;
                    if (rows.RowIndex == 0)
                    {
                        row["CPDS1"] = a1;
                        row["APDS1"] = a2;
                        row["SPDS1"] = a3;
                        row["D1PDS"] = a4;
                    }
                    if (rows.RowIndex == 1)
                    {
                        row["CPDS2"] = a1;
                        row["APDS2"] = a2;
                        row["SPDS2"] = a3;
                        row["D2PDS"] = a4;
                    }
                    if (rows.RowIndex == 2)
                    {
                        row["CPDS3"] = a1;
                        row["APDS3"] = a2;
                        row["SPDS3"] = a3;
                        row["D3PDS"] = a4;
                    }
                    if (rows.RowIndex == 3)
                    {
                        row["CPDS4"] = a1;
                        row["APDS4"] = a2;
                        row["SPDS4"] = a3;
                        row["D4PDS"] = a4;
                    }
                    if (rows.RowIndex == 4)
                    {
                        row["CRETTANK"] = a1;
                        row["ARETTANK"] = a2;
                        row["SRETTANK"] = a3;
                        row["DRETTANK"] = a4;
                    }

                }

                if (dt.Rows.Count > 0)
                {
                    Update(dt);
                }

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                dt2.Columns.Add("TIME", typeof(string));
                dt2.Columns.Add("SOF", typeof(string));
                dt2.Columns.Add("WOF", typeof(string));
                dt2.Columns.Add("SULFIDE", typeof(string));
                
                foreach (GridViewRow rows in gv_solids.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_solids_time");
                    string a = txtbox.Text;
                    if (a != "")
                    {
                        var row2 = dt2.NewRow();
                        dt2.Rows.Add(row2);
                        System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_solids_time");
                        string a1 = txtbox1.Text;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_solids_sof");
                        string a2 = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_solids_wof");
                        string a3 = txtbox3.Text;

                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_solids_sulfide");
                        string a4 = txtbox4.Text;
                        System.Web.UI.WebControls.HiddenField txtbox5 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_solids_id");
                        string a5 = txtbox5.Value;

                        row2["TIME"] = a1;
                        row2["SOF"] = a2;
                        row2["WOF"] = a3;
                        row2["SULFIDE"] = a4;
                        row2["ID"] = a5;
                    }
                }
                if(dt.Rows.Count > 0)
                {
                    UpdateSolids(dt2);
                }
               
                gvBind();
                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateSolids(DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand("LAB_sp_solids", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ID"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ID"].ToString();
                cmd.Parameters.AddWithValue("@TIME", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TIME"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TIME"].ToString();
                cmd.Parameters.AddWithValue("@SOF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SOF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SOF"].ToString();
                cmd.Parameters.AddWithValue("@WOF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOF"].ToString();
                cmd.Parameters.AddWithValue("@SULFIDE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SULFIDE"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SULFIDE"].ToString();
              
                con.Open();
                cmd.ExecuteNonQuery();
                }
           }
            PiInsertSolids(dt);
        }
        public void Update(DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand("LAB_sp_sec12", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DATE", SqlDbType.VarChar).Value = Session["sec12_date"].ToString();
                    cmd.Parameters.AddWithValue("@SASUF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SASUF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SASUF"].ToString();
                    cmd.Parameters.AddWithValue("@SAWUF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAWUF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAWUF"].ToString();
                    cmd.Parameters.AddWithValue("@SAMTL", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAMTL"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAMTL"].ToString();
                    cmd.Parameters.AddWithValue("@SAFA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAFA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAFA"].ToString();
                    cmd.Parameters.AddWithValue("@SALR", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SALR"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SALR"].ToString();
                    cmd.Parameters.AddWithValue("@GPLS1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLS1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLS1"].ToString();
                    cmd.Parameters.AddWithValue("@GPLS2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLS2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLS2"].ToString();
                    cmd.Parameters.AddWithValue("@GPLS3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLS3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLS3"].ToString();
                    cmd.Parameters.AddWithValue("@GPLS4", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLS4"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLS4"].ToString();
                    cmd.Parameters.AddWithValue("@GPLSBF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLSBF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLSBF"].ToString();
                    cmd.Parameters.AddWithValue("@GPLSOXSET", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["GPLSOXSET"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["GPLSOXSET"].ToString();
                    cmd.Parameters.AddWithValue("@SABF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SABF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SABF"].ToString();
                    cmd.Parameters.AddWithValue("@SAOXSET", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAOXSET"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAOXSET"].ToString();
                    cmd.Parameters.AddWithValue("@SALIMEREC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SALIMEREC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SALIMEREC"].ToString();
                    cmd.Parameters.AddWithValue("@SAST", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAST"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAST"].ToString();
                    cmd.Parameters.AddWithValue("@SALP", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SALP"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SALP"].ToString();
                    cmd.Parameters.AddWithValue("@OAOXSET", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OAOXSET"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OAOXSET"].ToString();
                    cmd.Parameters.AddWithValue("@OABF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OABF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OABF"].ToString();
                    cmd.Parameters.AddWithValue("@OA1CAKE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OA1CAKE"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OA1CAKE"].ToString();
                    cmd.Parameters.AddWithValue("@OA2CAKE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OA2CAKE"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OA2CAKE"].ToString();
                    cmd.Parameters.AddWithValue("@OASTSEED", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OASTSEED"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OASTSEED"].ToString();
                    cmd.Parameters.AddWithValue("@OA6AB", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OA6AB"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OA6AB"].ToString();
                    cmd.Parameters.AddWithValue("@OAPF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["OAPF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["OAPF"].ToString();
                    cmd.Parameters.AddWithValue("@SRS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRS"].ToString();
                    cmd.Parameters.AddWithValue("@SRSTARCHI", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRSTARCHI"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRSTARCHI"].ToString();
                    cmd.Parameters.AddWithValue("@SRSTARCHS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRSTARCHS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRSTARCHS"].ToString();
                    cmd.Parameters.AddWithValue("@SRPF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRPF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRPF"].ToString();
                    cmd.Parameters.AddWithValue("@TAAA4FT", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TAAA4FT"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TAAA4FT"].ToString();
                    cmd.Parameters.AddWithValue("@TAAASF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TAAASF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TAAASF"].ToString();
                    cmd.Parameters.AddWithValue("@TAAASUF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TAAASUF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TAAASUF"].ToString();

                    cmd.Parameters.AddWithValue("@TAAAWUF", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TAAAWUF"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TAAAWUF"].ToString();
                    cmd.Parameters.AddWithValue("@TAAAMTL", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TAAAMTL"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TAAAMTL"].ToString();
                    cmd.Parameters.AddWithValue("@LTPCA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LTPCA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LTPCA"].ToString();
                    cmd.Parameters.AddWithValue("@LTP", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LTP"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LTP"].ToString();
                    cmd.Parameters.AddWithValue("@SPENTLIQ", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SPENTLIQ"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SPENTLIQ"].ToString();
                    cmd.Parameters.AddWithValue("@Y1516", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["Y1516"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["Y1516"].ToString();
                    cmd.Parameters.AddWithValue("@TRIDIGEST", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TRIDIGEST"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TRIDIGEST"].ToString();
                    cmd.Parameters.AddWithValue("@FT5", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FT5"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FT5"].ToString();
                    cmd.Parameters.AddWithValue("@DIGDISCH", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGDISCH"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGDISCH"].ToString();
                    cmd.Parameters.AddWithValue("@TD", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TD"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TD"].ToString();

                    cmd.Parameters.AddWithValue("@WP0", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP0"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP0"].ToString();
                    cmd.Parameters.AddWithValue("@WP1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP1"].ToString();
                    cmd.Parameters.AddWithValue("@WP2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP2"].ToString();
                    cmd.Parameters.AddWithValue("@WP3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP3"].ToString();
                    cmd.Parameters.AddWithValue("@WP4", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP4"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP4"].ToString();
                    cmd.Parameters.AddWithValue("@WP5", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP5"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP5"].ToString();
                    cmd.Parameters.AddWithValue("@WP6", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP6"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP6"].ToString();
                    cmd.Parameters.AddWithValue("@WP7", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP7"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP7"].ToString();
                    cmd.Parameters.AddWithValue("@WP8", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WP8"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WP8"].ToString();

                cmd.Parameters.AddWithValue("@CPDS1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CPDS1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CPDS1"].ToString();
                cmd.Parameters.AddWithValue("@CPDS2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CPDS2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CPDS2"].ToString();
                cmd.Parameters.AddWithValue("@CPDS3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CPDS3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CPDS3"].ToString();
                cmd.Parameters.AddWithValue("@CPDS4", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CPDS4"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CPDS4"].ToString();
                cmd.Parameters.AddWithValue("@CRETTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CRETTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CPDS1"].ToString();
                cmd.Parameters.AddWithValue("@APDS1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["APDS1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["APDS1"].ToString();
                cmd.Parameters.AddWithValue("@APDS2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["APDS2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["APDS2"].ToString();
                cmd.Parameters.AddWithValue("@APDS3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["APDS3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["APDS3"].ToString();
                cmd.Parameters.AddWithValue("@APDS4", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["APDS4"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["APDS4"].ToString();
                cmd.Parameters.AddWithValue("@ARETTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ARETTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ARETTANK"].ToString();
                cmd.Parameters.AddWithValue("@SPDS1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SPDS1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SPDS1"].ToString();
                cmd.Parameters.AddWithValue("@SPDS2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SPDS2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SPDS2"].ToString();
                cmd.Parameters.AddWithValue("@SPDS3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SPDS3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SPDS3"].ToString();
                cmd.Parameters.AddWithValue("@SPDS4", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SPDS4"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SPDS4"].ToString();
                cmd.Parameters.AddWithValue("@SRETTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRETTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRETTANK"].ToString();
                cmd.Parameters.AddWithValue("@D1PDS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["D1PDS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["D1PDS"].ToString();
                cmd.Parameters.AddWithValue("@D2PDS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["D2PDS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["D2PDS"].ToString();
                cmd.Parameters.AddWithValue("@D3PDS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["D3PDS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["D3PDS"].ToString();
                cmd.Parameters.AddWithValue("@D4PDS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["D4PDS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["D4PDS"].ToString();
                cmd.Parameters.AddWithValue("@DRETTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DRETTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DRETTANK"].ToString();

                con.Open();
                cmd.ExecuteNonQuery();

        
                PiInsert(dt);
                }
            //}
        }
        public static bool DSTcheck()
        {
            bool dst = false;
            DateTime date = DateTime.Today;
            int yr = DateTime.Now.Year;


            if ((yr == 2018) && (date > Convert.ToDateTime("03-11-2018") && date < Convert.ToDateTime("11-04-2018")))
                dst = true;
            else if ((yr == 2019) && (date > Convert.ToDateTime("03-10-2019") && date < Convert.ToDateTime("11-03-2019")))
                dst = true;
            else if ((yr == 2020) && (date > Convert.ToDateTime("03-08-2020") && date < Convert.ToDateTime("11-01-2020")))
                dst = true;
            else
                dst = false;

            return dst;
        }
        public void PiInsertSolids(DataTable dt)
        {
            //**********************Insert records into pi********************************************
            try
            {
                LabEntities db = new LabEntities();
                PIServers myPIServers = new PIServers();
                PIServer myPIServer = myPIServers.DefaultPIServer;
                NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
                myPIServer.Connect(credential);

                //Dictionary<string, decimal?> piTagValues = new Dictionary<string, decimal?>();
                //var PiTaglist = (from v in db.Lab_TagTable
                //                     //orderby v.Id 
                //                 where v.Tag_Name == "SEC 1_2"
                //                 select v).ToList();
                var date = Convert.ToDateTime(Session["sec12_date"].ToString());

                int utc = DateTime.UtcNow.Hour;
                int dt_ = DateTime.Now.Hour;
         
                    int diff = utc - dt_;
      

                dt.Columns.RemoveAt(0);
      

                DataTable PITag_Solids = new DataTable();
                //PITag_Solids.Columns.Add("TIME", typeof(string));
                PITag_Solids.Columns.Add("SOF", typeof(string));
                PITag_Solids.Columns.Add("WOF", typeof(string));
                PITag_Solids.Columns.Add("SULFIDE", typeof(string));
                var row_ = PITag_Solids.NewRow();
                PITag_Solids.Rows.Add(row_);
                //row_["TIME"] = "mglSolids_Time";
                row_["SOF"] = "LAB_SOF";
                row_["WOF"] = "LAB_WOF";
                row_["SULFIDE"] = "LAB_Sulfide";

                string TagName;
                string TagName_test;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int time = Convert.ToInt32(dt.Rows[i][0].ToString().Replace(":","").Replace("0",""));
                    for (int j = 0; j < PITag_Solids.Columns.Count; j++)
                    {
                     
                       //TagName_test = PITag_Solids.Rows[0][j].ToString();
                        TagName = PITag_Solids.Rows[0][j].ToString();

                        //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                        PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                        AFValue currentTag = myPIPoint.CurrentValue();
                        string ct = currentTag.Value.ToString();
                        currentTag.Value = Convert.ToString(dt.Rows[i][j+1]);
                        currentTag.Timestamp = date.AddHours(diff+time);

                        if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                        {
                            myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                        }

                    }
                }


                myPIServer.Disconnect();
            }
            catch (Exception ex)
            {

            }

            //*************************End*******************************

        }
        public void PiInsert(DataTable dt)
        {
            //**********************Insert records into pi********************************************
            try
            {
                LabEntities db = new LabEntities();
                PIServers myPIServers = new PIServers();
                PIServer myPIServer = myPIServers.DefaultPIServer;
                NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
                myPIServer.Connect(credential);

                Dictionary<string, decimal?> piTagValues = new Dictionary<string, decimal?>();
                var PiTaglist = (from v in db.Lab_TagTable
                                     //orderby v.Id 
                                 where v.Tag_Name == "SEC 1_2"
                                 select v).ToList();
                var date = Convert.ToDateTime(Session["sec12_date"].ToString());

                int utc = DateTime.UtcNow.Hour;
                int dt_ = DateTime.Now.Hour;

                bool dst = DSTcheck();
                if (dst)
                {
                    dt_ = dt_ - 1;
                }
                int diff;
                if (utc > dt_)
                    diff = utc - dt_;
                else
                    diff = utc + 24 - dt_;
                {
                    piTagValues.Add("LABACPDS1", string.IsNullOrEmpty(dt.Rows[0]["APDS1"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["APDS1"].ToString()));
                    piTagValues.Add("LABACPDS2", string.IsNullOrEmpty(dt.Rows[0]["APDS2"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["APDS2"].ToString()));
                    piTagValues.Add("LABACPDS3", string.IsNullOrEmpty(dt.Rows[0]["APDS3"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["APDS3"].ToString()));
                    piTagValues.Add("LABACPDS4", string.IsNullOrEmpty(dt.Rows[0]["APDS4"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["APDS4"].ToString()));
                    piTagValues.Add("LABCPDS1", string.IsNullOrEmpty(dt.Rows[0]["CPDS1"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CPDS1"].ToString()));
                    piTagValues.Add("LABCPDS2", string.IsNullOrEmpty(dt.Rows[0]["CPDS2"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CPDS2"].ToString()));
                    piTagValues.Add("LABCPDS3", string.IsNullOrEmpty(dt.Rows[0]["CPDS3"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CPDS3"].ToString()));
                    piTagValues.Add("LABCPDS4", string.IsNullOrEmpty(dt.Rows[0]["CPDS4"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CPDS4"].ToString()));
                    piTagValues.Add("LABFT5SOL", string.IsNullOrEmpty(dt.Rows[0]["FT5"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["FT5"].ToString()));

   
                    piTagValues.Add("LABLTPCA", string.IsNullOrEmpty(dt.Rows[0]["LTPCA"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["LTPCA"].ToString()));

                    //decimal? s = string.IsNullOrEmpty(dt.Rows[0]["SALP"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SALP"].ToString());
                    piTagValues.Add("LABLTPNa2S", string.IsNullOrEmpty(dt.Rows[0]["SALP"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SALP"].ToString()));

                    piTagValues.Add("LABMTLSol", string.IsNullOrEmpty(dt.Rows[0]["SAMTL"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SAMTL"].ToString()));
                    piTagValues.Add("LABNa2STANK", string.IsNullOrEmpty(dt.Rows[0]["SAST"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SAST"].ToString()));
                    piTagValues.Add("LABOA1CAKE", string.IsNullOrEmpty(dt.Rows[0]["OA1CAKE"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OA1CAKE"].ToString()));
                    piTagValues.Add("LABOA2CAKE", string.IsNullOrEmpty(dt.Rows[0]["OA2CAKE"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OA2CAKE"].ToString()));
                    piTagValues.Add("LABOA6AB", string.IsNullOrEmpty(dt.Rows[0]["OA6AB"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OA6AB"].ToString()));
                    piTagValues.Add("LABOABF", string.IsNullOrEmpty(dt.Rows[0]["OABF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OABF"].ToString()));
                    piTagValues.Add("LABOAPF", string.IsNullOrEmpty(dt.Rows[0]["OAPF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OAPF"].ToString()));
                    piTagValues.Add("LABOASTSEED", string.IsNullOrEmpty(dt.Rows[0]["OASTSEED"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["OASTSEED"].ToString()));
                    piTagValues.Add("LABSABF", string.IsNullOrEmpty(dt.Rows[0]["SABF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SABF"].ToString()));

                    piTagValues.Add("LABSAFA", string.IsNullOrEmpty(dt.Rows[0]["SAFA"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SAFA"].ToString()));
                    piTagValues.Add("LABSPDS1", string.IsNullOrEmpty(dt.Rows[0]["SPDS1"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SPDS1"].ToString()));
                    piTagValues.Add("LABSPDS2", string.IsNullOrEmpty(dt.Rows[0]["SPDS2"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SPDS2"].ToString()));
                    piTagValues.Add("LABSPDS3", string.IsNullOrEmpty(dt.Rows[0]["SPDS3"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SPDS3"].ToString()));
                    piTagValues.Add("LABSPDS4", string.IsNullOrEmpty(dt.Rows[0]["SPDS4"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SPDS4"].ToString()));
                    piTagValues.Add("LABSUFSol", string.IsNullOrEmpty(dt.Rows[0]["SASUF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SASUF"].ToString()));
                    piTagValues.Add("LABTAA4FT", string.IsNullOrEmpty(dt.Rows[0]["TAAA4FT"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TAAA4FT"].ToString()));
                    piTagValues.Add("LABTAAMTL", string.IsNullOrEmpty(dt.Rows[0]["TAAAMTL"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TAAAMTL"].ToString()));
                    piTagValues.Add("LABTAASF", string.IsNullOrEmpty(dt.Rows[0]["TAAASF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TAAASF"].ToString()));
                    piTagValues.Add("LABTAASUF", string.IsNullOrEmpty(dt.Rows[0]["TAAASUF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TAAASUF"].ToString()));

                    piTagValues.Add("LABTAAWUF", string.IsNullOrEmpty(dt.Rows[0]["TAAAWUF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TAAAWUF"].ToString()));
                    piTagValues.Add("LABTHDSOL", string.IsNullOrEmpty(dt.Rows[0]["TRIDIGEST"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TRIDIGEST"].ToString()));
                    piTagValues.Add("LABWUFSol", string.IsNullOrEmpty(dt.Rows[0]["SAWUF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SAWUF"].ToString()));

                    piTagValues.Add("WP0", string.IsNullOrEmpty(dt.Rows[0]["WP0"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP0"].ToString()));
                    piTagValues.Add("WP1", string.IsNullOrEmpty(dt.Rows[0]["WP1"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP1"].ToString()));
                    piTagValues.Add("WP2", string.IsNullOrEmpty(dt.Rows[0]["WP2"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP2"].ToString()));
                    piTagValues.Add("WP3", string.IsNullOrEmpty(dt.Rows[0]["WP3"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP3"].ToString()));
                    piTagValues.Add("WP4", string.IsNullOrEmpty(dt.Rows[0]["WP4"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP4"].ToString()));
                    piTagValues.Add("WP5", string.IsNullOrEmpty(dt.Rows[0]["WP5"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP5"].ToString()));
                    piTagValues.Add("WP6", string.IsNullOrEmpty(dt.Rows[0]["WP6"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP6"].ToString()));
                    piTagValues.Add("WP7", string.IsNullOrEmpty(dt.Rows[0]["WP7"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP7"].ToString()));
                    piTagValues.Add("WP8", string.IsNullOrEmpty(dt.Rows[0]["WP8"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WP8"].ToString()));

                    piTagValues.Add("LABLRSol", string.IsNullOrEmpty(dt.Rows[0]["SALR"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SALR"].ToString()));
                    piTagValues.Add("LABGPLSTRAY1", string.IsNullOrEmpty(dt.Rows[0]["GPLS1"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["GPLS1"].ToString()));
                    piTagValues.Add("LABGPLSTRAY2", string.IsNullOrEmpty(dt.Rows[0]["GPLS2"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["GPLS2"].ToString()));
                    piTagValues.Add("LABGPLSTRAY3", string.IsNullOrEmpty(dt.Rows[0]["GPLS3"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["GPLS3"].ToString()));
                    piTagValues.Add("LABGPLSTRAY4", string.IsNullOrEmpty(dt.Rows[0]["GPLS4"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["GPLS4"].ToString()));

                    piTagValues.Add("LABGPLSBFILTRATE", string.IsNullOrEmpty(dt.Rows[0]["GPLSBF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["GPLSBF"].ToString()));
                    piTagValues.Add("LABSODAABF", string.IsNullOrEmpty(dt.Rows[0]["SABF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SABF"].ToString()));
                    piTagValues.Add("LABSODAALR", string.IsNullOrEmpty(dt.Rows[0]["SALIMEREC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SALIMEREC"].ToString()));
                    piTagValues.Add("LABSULFIDEASTANK", string.IsNullOrEmpty(dt.Rows[0]["SAST"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SAST"].ToString()));
                    piTagValues.Add("LABSULFIDEALTP", string.IsNullOrEmpty(dt.Rows[0]["SALP"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SALP"].ToString()));
                    piTagValues.Add("LABSRPFLOC", string.IsNullOrEmpty(dt.Rows[0]["SRPF"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SRPF"].ToString()));
                    piTagValues.Add("LABSFSOLID", string.IsNullOrEmpty(dt.Rows[0]["SRS"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SRS"].ToString()));
                    piTagValues.Add("LABOAY1516", string.IsNullOrEmpty(dt.Rows[0]["Y1516"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["Y1516"].ToString()));
                    piTagValues.Add("LABTAAV4", string.IsNullOrEmpty(dt.Rows[0]["TD"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TD"].ToString()));


                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {
                            string TagName;
                            string TagName_test;
                            if (item.Pi_Tags == item.Pi_Tags_Test)
                            {
                                TagName = item.Pi_Tags;
                                TagName_test = item.Pi_Tags_Test;
                            }
                            else
                            {
                                TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                                TagName_test = item.Pi_Tags_Test;
                            }
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                string ct = currentTag.Value.ToString();
                                currentTag.Value = Convert.ToString(entry.Value);
                                currentTag.Timestamp = date.AddHours(diff);
                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                }
                            }
                        }
                    }
                }
                myPIServer.Disconnect();
            }
            catch (Exception ex)
            {
            }
            //*************************End*******************************
        }
        protected void gv_WasherProfile_RowCreated(object sender, GridViewRowEventArgs e)
        {
           
            try
            {
                //the amount of rows in between the inserted rows
                int rowsInBetween = 1;

                //check if the row is a datarow
                //if (e.Row.RowType == DataControlRowType.DataRow && rowIndex % (rowsInBetween + 1) == 0 && rowIndex > 0)
                if(e.Row.RowType == DataControlRowType.DataRow & rowIndex == 2 )
                {
                    
                    //create a new row
                    GridViewRow extraRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                  
                    TableCell cell1 = new TableCell();
                    cell1.Text = "-3-";
                    extraRow.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "-4-";
                     extraRow.Cells.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "-5-";
                    extraRow.Cells.Add(cell3);
                    gv_wp.Controls[0].Controls.AddAt(2, extraRow);

                    //extra increment the row count
                    rowIndex++;
                }
                if (e.Row.RowType == DataControlRowType.DataRow & rowIndex == 4)
                {

                    //create a new row
                    GridViewRow extraRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    extraRow.Height.Equals(10);
                    TableCell cell1 = new TableCell();
                    cell1.Text = "-6-";
                    extraRow.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "-7-";
                    extraRow.Cells.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "-8-";
                    extraRow.Cells.Add(cell3);
                    gv_wp.Controls[0].Controls.AddAt(4, extraRow);

                    //extra increment the row count
                    rowIndex++;
                }



                rowIndex++;
            }
            catch(Exception ex)
            {

            }
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            HttpContext.Current.Session["sec12_date"] = selDate;
            return selDate;
        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["sec12_date"] != null)
                dt = HttpContext.Current.Session["sec12_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT SDDATE   FROM [Lab].[dbo].[LAB_SEC1_DATA] WHERE SDDATE = '" + dt + "'";
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
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_sec12", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
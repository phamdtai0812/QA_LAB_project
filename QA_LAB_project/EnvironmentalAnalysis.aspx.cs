using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class EnvironmentalAnalysis : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
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
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            HttpContext.Current.Session["env_date"] = selDate;
            return selDate;
        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["env_date"] != null)
                dt = HttpContext.Current.Session["env_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT EADATE   FROM [Lab].[dbo].[LAB_ENVIRONMENTAL] WHERE EADATE = '" + dt + "'";
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
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_environmental", con);
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
                if (string.IsNullOrEmpty(HttpContext.Current.Session["env_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["env_date"] = date;
                }
                else
                { date = Session["env_date"].ToString(); }
                DateTime date_ = Convert.ToDateTime(date);
                //string date_ = "2018-03-10";
               // DateTime date_ =  DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));

                date_max.Value = date;

                //PH Analysis
                query = "  select 'pH' as [name], rwrph,edph,wdph, fedph, cdph, oxpond from LAB_ENVIRONMENTAL where eadate = '" + date_ + "' union all "+
                    "select 'Flow' as [name], null,edflow, wdflow, fedflow, cdflow, null from LAB_ENVIRONMENTAL where eadate = '" + date_ + "'";

                //P205 CAUSTIC
                query += " select 'Test Tank' as [name], P2O5CATESTTANK as [data] from LAB_ENVIRONMENTAL where eadate = '" + date_ + "' union all " +
                            " select 'Settler Feed' as [name], P2O5CASETTLERFEED from LAB_ENVIRONMENTAL where eadate = '" + date_ + "' ";

                //abs caustic
                query += "  select 'Test Tank' as [name], ABSCATESTTANK as [data] from LAB_ENVIRONMENTAL where eadate = '" + date_ + "' union all " +
                        " select 'LTP' as [name], ABSCALTP as [data] from LAB_ENVIRONMENTAL where eadate = '" + date_ + "'  ";

                query += " select * from LAB_ENVIRONMENTAL where eadate = '" + date_ + "' ";

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
                        gv_pha.DataSource = ds.Tables[0];
                        gv_pha.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                 
                        gv_p205.DataSource = ds.Tables[1];
                        gv_p205.DataBind();
                    }
                    
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        //gv_abs.DataSource = null;
                        //gv_abs.DataBind();
                        gv_abs.DataSource = ds.Tables[2];
                        gv_abs.DataBind();
                    }
                    //gv_sad.DataSource = null;
                    //gv_sad.DataBind();
                    gv_sad.DataSource = ds.Tables[3];
                    gv_sad.DataBind();

                    //gv_soda.DataSource = null;
                    //gv_soda.DataBind();
                    gv_soda.DataSource = ds.Tables[3];
                    gv_soda.DataBind();

                    //gv_silica.DataSource = null;
                    //gv_silica.DataBind();
                    gv_silica.DataSource = ds.Tables[3];
                    gv_silica.DataBind();


                    //gv_floc.DataSource = null;
                    //gv_floc.DataBind();
                    gv_floc.DataSource = ds.Tables[3];
                    gv_floc.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static DataTable GenerateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SEWERPH1", typeof(string));
            dt.Columns.Add("SEWERPH2", typeof(string));
            dt.Columns.Add("SEWERPH3", typeof(string));
            dt.Columns.Add("SEWERPH5", typeof(string));
            dt.Columns.Add("DAMPH1", typeof(string));
            dt.Columns.Add("SAHOTWELL", typeof(string));
            dt.Columns.Add("SAPLANTDRAIN", typeof(string));
            dt.Columns.Add("SALIFTSTATION", typeof(string));
            dt.Columns.Add("SASURGEBASIN", typeof(string));
            dt.Columns.Add("P2O5CATESTTANK", typeof(string));
            dt.Columns.Add("P2O5CASETTLERFEED", typeof(string));
            dt.Columns.Add("ABSCATESTTANK", typeof(string));
            dt.Columns.Add("ABSCALTP", typeof(string));
            dt.Columns.Add("SCATESTTANK", typeof(string));
            dt.Columns.Add("SCA4FT", typeof(string));
            dt.Columns.Add("SCASETTLERFD", typeof(string));
            dt.Columns.Add("SCALTP", typeof(string));
            dt.Columns.Add("FASETTLER", typeof(string));
            dt.Columns.Add("FAWASHER", typeof(string));
            dt.Columns.Add("FAMIDDLE", typeof(string));
           
            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            try
            {
            DataTable dt = GenerateTable();
            var row = dt.NewRow();
            dt.Rows.Add(row);
                //foreach (GridViewRow rows in gv_pha.Rows)
                //{
                //    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_suf");
                //    string a1 = txtbox1.Text;
                //    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_wuf");
                //    string a2 = txtbox2.Text;
                //    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_mtl");
                //    string a3 = txtbox3.Text;
                //    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_faid");
                //    string a4 = txtbox4.Text;
                //    System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psa_mtl");
                //    string a5 = txtbox5.Text;
                //    row["SASUF"] = a1;
                //    row["SAWUF"] = a2;
                //    row["SAMTL"] = a3;
                //    row["SAFA"] = a4;
                //    row["SALR"] = a5;
                //}
                foreach (GridViewRow rows in gv_sad.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sad_sph1");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sad_sph2");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sad_sph3");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sad_sph5");
                    string a4 = txtbox4.Text;
                    System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sad_dam1");
                    string a5 = txtbox5.Text;

                    row["SEWERPH1"] = a1;
                    row["SEWERPH2"] = a2;
                    row["SEWERPH3"] = a3;
                    row["SEWERPH5"] = a4;
                    row["DAMPH1"] = a5;
                }
                foreach (GridViewRow rows in gv_soda.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_htw");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_plant");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_lift");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_surge");
                    string a4 = txtbox4.Text;

                    row["SAHOTWELL"] = a1;
                    row["SAPLANTDRAIN"] = a2;
                    row["SALIFTSTATION"] = a3;
                    row["SASURGEBASIN"] = a4;
                   
                }
                foreach (GridViewRow rows in gv_p205.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_p205_data");
                    string a1 = txtbox1.Text;
                    if (rows.RowIndex == 0)
                    { row["P2O5CATESTTANK"] = a1; }
                    else

                    { row["P2O5CASETTLERFEED"] = a1; }
                }
                foreach (GridViewRow rows in gv_abs.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_abs_data");
                    string a1 = txtbox1.Text;
                    if (rows.RowIndex == 0)
                    { row["ABSCATESTTANK"] = a1; }
                    else

                    { row["ABSCALTP"] = a1; }
                }
                foreach (GridViewRow rows in gv_silica.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_scatt");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_sca4ft");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_scasf");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_scaltp");
                    string a4 = txtbox4.Text;

                    row["SCATESTTANK"] = a1;
                    row["SCA4FT"] = a2;
                    row["SCASETTLERFD"] = a3;
                    row["SCALTP"] = a4;

                }
                foreach (GridViewRow rows in gv_floc.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_floc_settler");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_floc_washer");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_floc_middle");
                    string a3 = txtbox3.Text;
                
                    row["FASETTLER"] = a1;
                    row["FAWASHER"] = a2;
                    row["FAMIDDLE"] = a3;

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
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                SqlCommand cmd = new SqlCommand("LAB_sp_environmental", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DATE", SqlDbType.VarChar).Value = Session["env_date"].ToString();
                cmd.Parameters.AddWithValue("@SEWERPH1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEWERPH1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEWERPH1"].ToString();
                cmd.Parameters.AddWithValue("@SEWERPH2", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEWERPH2"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEWERPH2"].ToString();
                cmd.Parameters.AddWithValue("@SEWERPH3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEWERPH3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEWERPH3"].ToString();
                cmd.Parameters.AddWithValue("@SEWERPH5", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SEWERPH5"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SEWERPH5"].ToString();
                cmd.Parameters.AddWithValue("@DAMPH1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DAMPH1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DAMPH1"].ToString();
                cmd.Parameters.AddWithValue("@SAHOTWELL", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAHOTWELL"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAHOTWELL"].ToString();
                cmd.Parameters.AddWithValue("@SAPLANTDRAIN", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SAPLANTDRAIN"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SAPLANTDRAIN"].ToString();
                cmd.Parameters.AddWithValue("@SALIFTSTATION", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SALIFTSTATION"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SALIFTSTATION"].ToString();
                cmd.Parameters.AddWithValue("@SASURGEBASIN", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SASURGEBASIN"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SASURGEBASIN"].ToString();
                cmd.Parameters.AddWithValue("@P2O5CATESTTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["P2O5CATESTTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["P2O5CATESTTANK"].ToString();

                cmd.Parameters.AddWithValue("@P2O5CASETTLERFEED", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["P2O5CASETTLERFEED"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["P2O5CASETTLERFEED"].ToString();
                cmd.Parameters.AddWithValue("@ABSCATESTTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ABSCATESTTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ABSCATESTTANK"].ToString();
                cmd.Parameters.AddWithValue("@ABSCALTP", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ABSCALTP"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ABSCALTP"].ToString();
                cmd.Parameters.AddWithValue("@SCATESTTANK", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SCATESTTANK"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SCATESTTANK"].ToString();
                cmd.Parameters.AddWithValue("@SCA4FT", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SCA4FT"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SCA4FT"].ToString();
                cmd.Parameters.AddWithValue("@SCASETTLERFD", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SCASETTLERFD"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SCASETTLERFD"].ToString();
                cmd.Parameters.AddWithValue("@SCALTP", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SCALTP"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SCALTP"].ToString();
                cmd.Parameters.AddWithValue("@FASETTLER", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FASETTLER"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FASETTLER"].ToString();
                cmd.Parameters.AddWithValue("@FAWASHER", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FAWASHER"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FAWASHER"].ToString();
                cmd.Parameters.AddWithValue("@FAMIDDLE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FAMIDDLE"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FAMIDDLE"].ToString();

                con.Open();
                cmd.ExecuteNonQuery();
            }
            //}
        }
        //public void ClearFields()
        //{
        //    riverwrph.Value = ""; editchph.Value = ""; wditchph.Value = ""; fedph.Value = ""; cfditchph.Value = ""; opph.Value = ""; editchflow.Value = ""; wditchflow.Value = ""; feditchflow.Value = "";
        //    cfditchflow.Value = ""; no1ph.Value = ""; no2ph.Value = ""; no3ph.Value = ""; no4ph.Value = ""; no1damph.Value = ""; hotwell.Value = ""; pdrain.Value = ""; lstation.Value = ""; sbasin.Value = "";
        //    p205tt.Value = "";p205sf.Value = ""; abstt.Value = ""; absltp.Value = ""; silicatt.Value = ""; no4ft.Value = ""; silicasf.Value = ""; silicaltp.Value = ""; flocsettler.Value = ""; flocw.Value = "";
        //    flocm.Value = "";

        //}
        //public void SQLDbConnection2(DateTime date)
        //{
            
        //    String strQuery = "SELECT * FROM LAB_ENVIRONMENTAL WHERE EADATE = '" + date + "'";
        //    //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = '" + ccround_ + "' and  Date_ =  '" + date_ + "' ";
        //    //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = 1 and  Date_ = '" + now + "'";
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlCommand cmd = new SqlCommand();
        //    //cmd.Parameters.Add("@Id", ddlCCROUND.SelectedItem.Value);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();

        //        if (sdr.HasRows)
        //        {
                 
        //            while (sdr.Read())
        //            {
        //                riverwrph.Value = sdr["RWRPH"].ToString();
        //                editchph.Value = sdr["EDPH"].ToString();
        //                wditchph.Value = sdr["WDPH"].ToString();
        //                fedph.Value = sdr["FEDPH"].ToString();
        //                cfditchph.Value = sdr["CDPH"].ToString();
        //                opph.Value = sdr["OXPOND"].ToString();
        //                editchflow.Value = sdr["EDFLOW"].ToString();
        //                wditchflow.Value = sdr["WDFLOW"].ToString();
        //                feditchflow.Value = sdr["FEDFLOW"].ToString();
        //                cfditchflow.Value = sdr["CDFLOW"].ToString();

        //                no1ph.Value = sdr["SEWERPH1"].ToString();
        //                no2ph.Value = sdr["SEWERPH2"].ToString();
        //                no3ph.Value = sdr["SEWERPH3"].ToString();
        //                no4ph.Value = sdr["SEWERPH5"].ToString();
        //                no1damph.Value = sdr["DAMPH1"].ToString();
        //                hotwell.Value = sdr["SAHOTWELL"].ToString();
        //                pdrain.Value = sdr["SAPLANTDRAIN"].ToString();
        //                lstation.Value = sdr["SALIFTSTATION"].ToString();
        //                sbasin.Value = sdr["SASURGEBASIN"].ToString();
        //                p205tt.Value = sdr["P2O5CATESTTANK"].ToString();

        //                p205sf.Value = sdr["P2O5CASETTLERFEED"].ToString();
        //                abstt.Value = sdr["ABSCATESTTANK"].ToString();
        //                absltp.Value = sdr["ABSCALTP"].ToString();
        //                silicatt.Value = sdr["SCATESTTANK"].ToString();
        //                no4ft.Value = sdr["SCA4FT"].ToString();
        //                silicasf.Value = sdr["SCASETTLERFD"].ToString();
        //                silicaltp.Value = sdr["SCALTP"].ToString();
        //                flocsettler.Value = sdr["FASETTLER"].ToString();
        //                flocw.Value = sdr["FAWASHER"].ToString();
        //                flocm.Value = sdr["FAMIDDLE"].ToString();

        //                label_date.Text = (Convert.ToDateTime(sdr["EADATE"].ToString())).ToShortDateString();
        //                Session["ea_date_max"] = (sdr["EADATE"].ToString());

        //                ea_date_max.Value = (sdr["EADATE"].ToString());

        //            }
        //        }
        //        con.Close();
        //        con.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        string filePath = @"C:\QA_LAB_project\Error.txt";
        //        //string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
        //               "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
        //            writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
        //        }


        //    }
       


        //}
        //public void SQLDbConnection(string d)
        //{
        //    //2018-02-15T06:00:00.000Z;
        //    String strQuery;
        //    //DateTime date = DateTime.Today;
        //    //if( Request.Form["date_select"] != null)
        //    //{ string s = Request.Form["date_select"].ToString(); }
         
        //    //DateTime date = Convert.ToDateTime(Request.Form["date_select"]);
        //    if (d == " ")
        //    {
        //        strQuery = "SELECT TOP(1) * FROM LAB_ENVIRONMENTAL WHERE ENV_ID = (SELECT  MAX(ENV_ID) FROM LAB_ENVIRONMENTAL)";
               
        //    }
        //    else
        //    {
        //        strQuery = "SELECT * FROM LAB_ENVIRONMENTAL WHERE EADATE = '" + d + "'";
        //    }

        //     SqlConnection con = new SqlConnection(strConnString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();

        //        if (sdr.HasRows)
        //        {
        //            while (sdr.Read())
        //            {
        //                riverwrph.Value = sdr["RWRPH"].ToString();
        //                editchph.Value = sdr["EDPH"].ToString();
        //                wditchph.Value = sdr["WDPH"].ToString();
        //                fedph.Value = sdr["FEDPH"].ToString();
        //                cfditchph.Value = sdr["CDPH"].ToString();
        //                opph.Value = sdr["OXPOND"].ToString();
        //                editchflow.Value = sdr["EDFLOW"].ToString();
        //                wditchflow.Value = sdr["WDFLOW"].ToString();
        //                feditchflow.Value = sdr["FEDFLOW"].ToString();
        //                cfditchflow.Value = sdr["CDFLOW"].ToString();

        //                no1ph.Value = sdr["SEWERPH1"].ToString();
        //                no2ph.Value = sdr["SEWERPH2"].ToString();
        //                no3ph.Value = sdr["SEWERPH3"].ToString();
        //                no4ph.Value = sdr["SEWERPH5"].ToString();
        //                no1damph.Value = sdr["DAMPH1"].ToString();
        //                hotwell.Value = sdr["SAHOTWELL"].ToString();
        //                pdrain.Value = sdr["SAPLANTDRAIN"].ToString();
        //                lstation.Value = sdr["SALIFTSTATION"].ToString();
        //                sbasin.Value = sdr["SASURGEBASIN"].ToString();
        //                p205tt.Value = sdr["P2O5CATESTTANK"].ToString();

        //                p205sf.Value = sdr["P2O5CASETTLERFEED"].ToString();
        //                abstt.Value = sdr["ABSCATESTTANK"].ToString();
        //                absltp.Value = sdr["ABSCALTP"].ToString();
        //                silicatt.Value = sdr["SCATESTTANK"].ToString();
        //                no4ft.Value = sdr["SCA4FT"].ToString();
        //                silicasf.Value = sdr["SCASETTLERFD"].ToString();
        //                silicaltp.Value = sdr["SCALTP"].ToString();
        //                flocsettler.Value = sdr["FASETTLER"].ToString();
        //                flocw.Value = sdr["FAWASHER"].ToString();
        //                flocm.Value = sdr["FAMIDDLE"].ToString();

        //                label_date.Text = (Convert.ToDateTime(sdr["EADATE"].ToString())).ToShortDateString();
        //                if (d == " ")
        //                {
        //                    Session["ea_date_max"] = (sdr["EADATE"].ToString());
        //                    ea_date_max.Value = Session["ea_date_max"].ToString();
        //                }
        //                //else

        //                //    date_max.Value = d;
        //                if (Session["ea_savedt"] == null)
        //                {
        //                    ea_date_max.Value = Session["ea_date_max"].ToString();
        //                }
        //                else
        //                {
        //                    ea_date_max.Value = Session["ea_savedt"].ToString();
        //                }

        //            }
        //        }
        //        con.Close();
        //        con.Dispose();

               
        //    }
        //    catch (Exception ex)
        //    {
        //        string filePath = @"C:\QA_LAB_project\Error.txt";
        //        //string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
        //               "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
        //            writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
        //        }


        //    }
           
        //}

        //protected void SaveButtonClick(object sender, EventArgs e)
        //{
           
        //    try
        //    {
                
        //            string strdate = Page.Request.Form["ea_dateSave"];
        //            var subs = strdate.Split(' ');
        //            var index = subs.Count() > 4 ? subs[0].Length + subs[1].Length + 1 + subs[2].Length + 1 + subs[3].Length + 1 : 0;
        //            strdate = strdate.Substring(0, index);
        //            var date = DateTime.ParseExact(strdate,
        //                      "ddd MMM dd yyyy",
        //                       CultureInfo.InvariantCulture);

        //            Session["ea_savedt"] = date.ToShortDateString();

        //            string strQuery = "select * from LAB_ENVIRONMENTAL WHERE EADATE = '" + Session["ea_savedt"].ToString() + "'";
        //            SqlConnection conn = new SqlConnection(strConnString);
        //            SqlCommand cmmd = new SqlCommand();
        //            cmmd.CommandType = CommandType.Text;
        //            cmmd.CommandText = strQuery;
        //            cmmd.Connection = conn;
        //          conn.Open();
        //          SqlDataReader sdr = cmmd.ExecuteReader();

        //          if (sdr.HasRows)
        //          {
        //            Page_Load(this, null);
        //            conn.Close();
        //          }
        //          else
        //          {
        //            conn.Close();
        //            SqlConnection con = new SqlConnection(strConnString);
        //            SqlCommand cmd = new SqlCommand("LAB_sp_environmental_insert", con);
        //            using (con)
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
                       
        //                cmd.Parameters.Add("date", SqlDbType.Date).Value = date;
        //                cmd.Parameters.Add("RWRPH", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(riverwrph2.Value) ? (object)DBNull.Value : riverwrph2.Value;
        //                cmd.Parameters.Add("EDPH", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(editchph2.Value) ? (object)DBNull.Value : editchph2.Value;
        //                cmd.Parameters.Add("WDPH", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(wditchph2.Value) ? (object)DBNull.Value : wditchph2.Value;
        //                cmd.Parameters.Add("FEDPH", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(feditchph2.Value) ? (object)DBNull.Value : feditchph2.Value;
        //                cmd.Parameters.Add("CDPH", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(cfditchph2.Value) ? (object)DBNull.Value : cfditchph2.Value;
        //                cmd.Parameters.Add("OXPOND", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(opph2.Value) ? (object)DBNull.Value : opph2.Value;
        //                cmd.Parameters.Add("EDFLOW", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(editchflow2.Value) ? (object)DBNull.Value : editchflow2.Value;
        //                cmd.Parameters.Add("WDFLOW", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(wditchflow2.Value) ? (object)DBNull.Value : wditchflow2.Value;
        //                cmd.Parameters.Add("FEDFLOW", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(feditchflow2.Value) ? (object)DBNull.Value : feditchflow2.Value;
        //                cmd.Parameters.Add("CDFLOW", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(cfditchflow2.Value) ? (object)DBNull.Value : cfditchflow2.Value;

        //                cmd.Parameters.Add("SEWERPH1", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no1ph2.Value) ? (object)DBNull.Value : no1ph2.Value;
        //                cmd.Parameters.Add("SEWERPH2", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no2ph2.Value) ? (object)DBNull.Value : no2ph2.Value;
        //                cmd.Parameters.Add("SEWERPH3", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no3ph2.Value) ? (object)DBNull.Value : no3ph2.Value;
        //                cmd.Parameters.Add("SEWERPH5", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no4ph2.Value) ? (object)DBNull.Value : no4ph2.Value;
        //                cmd.Parameters.Add("DAMPH1", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no1damph2.Value) ? (object)DBNull.Value : no1damph2.Value;

        //                cmd.Parameters.Add("SAHOTWELL", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(hotwell2.Value) ? (object)DBNull.Value : hotwell2.Value;
        //                cmd.Parameters.Add("SAPLANTDRAIN", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(pdrain2.Value) ? (object)DBNull.Value : pdrain2.Value;
        //                cmd.Parameters.Add("SALIFTSTATION", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(lstation2.Value) ? (object)DBNull.Value : lstation2.Value;
        //                cmd.Parameters.Add("SASURGEBASIN", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sbasin2.Value) ? (object)DBNull.Value : sbasin2.Value;
        //                cmd.Parameters.Add("P2O5CATESTTANK", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(p205tt2.Value) ? (object)DBNull.Value : p205tt2.Value;
        //                cmd.Parameters.Add("P2O5CASETTLERFEED", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(p205sf2.Value) ? (object)DBNull.Value : p205sf2.Value;
        //                cmd.Parameters.Add("ABSCATESTTANK", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(abstt2.Value) ? (object)DBNull.Value : abstt2.Value;
        //                cmd.Parameters.Add("ABSCALTP", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(absltp2.Value) ? (object)DBNull.Value : absltp2.Value;
        //                cmd.Parameters.Add("SCATESTTANK", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(silicatt2.Value) ? (object)DBNull.Value : silicatt2.Value;
        //                cmd.Parameters.Add("SCA4FT", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no4ft2.Value) ? (object)DBNull.Value : no4ft2.Value;
        //                cmd.Parameters.Add("SCASETTLERFD", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(silicasf2.Value) ? (object)DBNull.Value : silicasf2.Value;
        //                cmd.Parameters.Add("SCALTP", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(silicaltp2.Value) ? (object)DBNull.Value : silicaltp2.Value;
        //                cmd.Parameters.Add("FASETTLER", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(flocsettler2.Value) ? (object)DBNull.Value : flocsettler2.Value;
        //                cmd.Parameters.Add("FAWASHER", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(flocw2.Value) ? (object)DBNull.Value : flocw2.Value;
        //                cmd.Parameters.Add("FAMIDDLE", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(flocm2.Value) ? (object)DBNull.Value : flocm2.Value;
               

        //                con.Open();
        //                cmd.ExecuteNonQuery();

        //            }
        //            //GetDataForPI(date, ccround);
        //            //UpdateForm();

        //            string sdate = Page.Request.Form["ea_dateSave"];

        //            ea_date_max.Value = Session["ea_savedt"].ToString();

        //            SQLDbConnection(Session["ea_savedt"].ToString());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //string filePath = @"C:\QA_LAB_project\Error.txt";
        //        string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";

        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
        //               "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
        //            writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
        //        }
        //    }
           
        //}
    }
}
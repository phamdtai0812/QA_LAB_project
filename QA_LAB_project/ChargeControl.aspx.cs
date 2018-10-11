using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.Services;

using System.Data;

using System.Data.SqlClient;

using System.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using OSIsoft.AF.PI;
using System.Net;
using QA_LAB_project.Models;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using System.DirectoryServices;

namespace QA_LAB_project
{
    public partial class ChargeControl : System.Web.UI.Page
    {
        string d;
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        string month;
        string day;
        string year;
        string strMonth;
        decimal LABEDC;
        decimal LABEDAC;
        decimal LABWOFCS;
        decimal LABWOFAC;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString(); //Domain/Windows Account Name
            string userName = System.Environment.UserName; //Windows Account Name
            userName_.Value = userName;
            //ViewData["Role"] = "";
            DirectoryEntry rootEntry = new DirectoryEntry("LDAP://OU=Users,OU=Gramercy,OU=Noralinc,DC=noranda,DC=NORINC,DC=NET", @"NORANDA\gramercy_adm", "Th3Aby$$");
            //DirectoryEntry rootEntry = new DirectoryEntry("LDAP://OU=Users,OU=Gramercy,OU=Noralinc,DC=noranda,DC=NORINC,DC=NET", @"NORANDA\tai.pham", "Seo092011!@");
            try
            {
                Object obj = rootEntry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(rootEntry);

                search.Filter = "(SAMAccountName=" + userName + ")";
                search.PropertiesToLoad.Add("memberOf");
                SearchResult result = search.FindOne();

                foreach (string GroupPath in result.Properties["memberOf"])
                {
                    if (GroupPath.Contains("GR-LAB-Update"))
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie(userName, true);
                        displayRole.Value = "Admin";
                        role.Value = "Admin";
                        break;
                    }
                    else
                    {
                        Session["Role"] = "ReadOnly";
                    }
                }

            }
            catch (Exception ex)
            {
            }

            if (!IsPostBack)
            {
                loadData();
            }
            else
            {
                //GetLabData();
            }
        }

        //public string selectRecord()
        //{
        //    DateTime now = DateTime.Today;

        //    //String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        //    String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = 1 and  Date_ = '2017-12-01'";
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

        //        //if (sdr.HasRows)
        //        //{
        //        //    while (sdr.Read())

        //        //    {

        //        //        oxsettler.Value = sdr["OxSettler"].ToString();
        //        //        wuf.Value = sdr["Num8WasherUF_C"].ToString();
        //        //        mtl.Value = sdr["MudToLake_C"].ToString();
        //        //        srt.Value = sdr["SRT"].ToString();

        //        //        ttcaustic.Value = sdr["TestTank_C"].ToString();
        //        //        ttac.Value = sdr["TestTank_AC"].ToString();
        //        //        ttcs.Value = sdr["TestTank_C_by_S"].ToString();

        //        //        tridcaustic.Value = sdr["TriHyDigstr_C"].ToString();
        //        //        tridac.Value = sdr["TriHyDigstr_AC"].ToString();
        //        //        tridcs.Value = sdr["TriHyDigstr_CS"].ToString();
        //        //        tridaim.Value = sdr["TriHyDigstr_Aim"].ToString();

        //        //        no5caustic.Value = sdr["Num5FlashTnk_C"].ToString();
        //        //        no5ac.Value = sdr["Num5FlashTnk_AC"].ToString();
        //        //        no5cs.Value = sdr["Num5FlashTnk_CS"].ToString();
        //        //        no5aim.Value = sdr["Num5FlashTnk_Aim"].ToString();

        //        //        ddcaustic.Value = sdr["DigstnDisc_C"].ToString();
        //        //        ddac.Value = sdr["DigstnDisc_AC"].ToString();
        //        //        ddcs.Value = sdr["DigstnDisc_CS"].ToString();

        //        //        sfcaustic.Value = sdr["SettlerFeed_C"].ToString();
        //        //        sfcaustic.Value = sdr["SettlerFeed_AC"].ToString();
        //        //        sfcs.Value = sdr["SettlerFeed_CS"].ToString();

        //        //        pfcaustic.Value = sdr["PressFeed_C"].ToString();
        //        //        pfac.Value = sdr["PressFeed_AC"].ToString();

        //        //        ltpcaustic.Value = sdr["LTP_C"].ToString();
        //        //        ltpac.Value = sdr["LTP_AC"].ToString();
        //        //        ltpaim.Value = sdr["LTP_Aim"].ToString();

        //        //        efcaustic.Value = sdr["EvapFeed_C"].ToString();
        //        //        efac.Value = sdr["EvapFeed_AC"].ToString();

        //        //        edcaustic.Value = sdr["EvapDischrge_C"].ToString();
        //        //        edac.Value = sdr["EvapDischge_AC"].ToString();

        //        //        wofcaustic.Value = sdr["WasherOverflow_C"].ToString();
        //        //        wofac.Value = sdr["WasherOverflow_AC"].ToString();

        //        //        a7caustic.Value = sdr["A7_Overflow_C"].ToString();
        //        //        a7ac.Value = sdr["A7_Overflow_AC"].ToString();

        //        //        b7caustic.Value = sdr["B7_Overflow_C"].ToString();
        //        //        b7ac.Value = sdr["B7_Overflow_AC"].ToString();

        //        //        y15caustic.Value = sdr["Y15_Overflow_C"].ToString();
        //        //        y15ac.Value = sdr["Y15_Overflow_AC"].ToString();

        //        //        y16caustic.Value = sdr["Y16_Overflow_C"].ToString();
        //        //        y16ac.Value = sdr["Y16_Overflow_AC"].ToString();

        //        //    }
        //        //}

        //    }

        //    catch (Exception ex)

        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //    return "";
        //}
        public void loadData()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            try
            {
            ddlCCROUND.Items.Clear();
            //ddlCCROUND.Items.Add(new ListItem("--Round--", ""));
            //ddlCCROUND.AppendDataBoundItems = true;
            //String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            String strQuery = "select Id, ScheduleTime from [Lab_ScheduleTime]";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
           
                con.Open();
                ddlCCROUND.DataSource = cmd.ExecuteReader();
                ddlCCROUND.DataTextField = "ScheduleTime";
                ddlCCROUND.DataValueField = "Id";
                ddlCCROUND.DataBind();
                ddlCCROUND.SelectedValue = "1";
                pf.Visible = false;
                GetLabData();
                con.Close();
                con.Dispose();
            }

            catch (Exception ex)
            {
                string filePath = @"C:\QA_LAB_project\Error.txt";
                //string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
        }
        public  string monthConvert(string m)
        {
            string n;
            if (m == "Jan")
                n = "01";
            else if (m == "Feb")
                n = "02";
            else if (m == "Mar")
                n = "03";
            else if (m == "Apr")
                n = "04";
            else if (m == "May")
                n = "05";
            else if (m == "Jun")
                n = "06";
            else if (m == "Jul")
                n = "07";
            else if (m == "Aug")
                n = "08";
            else if (m == "Sep")
                n = "09";
            else if (m == "Oct")
                n = "10";
            else if (m == "Nov")
                n = "11";
            else n = "12";

            return n;
        }
        public void ClearFields()
        {
            oxsettler.Value = "";
            wuf.Value = "";
            mtl.Value = "";
            srt.Value = "";
            pressfiltrate.Value = "";
            ttcaustic.Value = "";
            ttac.Value = "";
            ttcs.Value = "";
            tridcaustic.Value = "";
            tridac.Value = "";
            tridcs.Value = "";
            tridaim.Value = "";
            no5caustic.Value = "";
            no5ac.Value = "";
            no5cs.Value = "";
            no5aim.Value = "";
            ddcaustic.Value = "";
            ddac.Value = "";
            ddcs.Value = "";
            sfcaustic.Value = "";
            sfac.Value = "";
            sfcs.Value = "";
            pfcaustic.Value = "";
            pfac.Value = "";

            ltpcaustic.Value = "";
            ltpac.Value = "";
            ltpaim.Value = "";

            efcaustic.Value = "";
            efac.Value = "";

            edcaustic.Value = "";
            edac.Value = "";

            wofcaustic.Value = "";
            wofac.Value = "";

            a7caustic.Value = "";
            a7ac.Value = "";

            b7caustic.Value = "";
            b7ac.Value = "";

            y15caustic.Value = "";
            y15ac.Value = "";

            y16caustic.Value = "";
            y16ac.Value = "";
            sufcaustic.Value = "";
            sufac.Value = "";
            t1caustic.Value = "";
            t1ac.Value = "";
            t3caustic.Value = "";
            t3ac.Value = "";
            t7caustic.Value = "";
            t7ac.Value = "";
            ag1caustic.Value = "";
            ag1ac.Value = "";
            ag4caustic.Value = "";
            ag4ac.Value = "";
            ag7caustic.Value = "";
            ag7ac.Value = "";
            evapcccaustic.Value = "";
            evapccac.Value = "";
            presscccaustic.Value = "";
            pressccac.Value = "";



        }
        public void GetLabData()
        {
            try
            {
                int ccround_;
                string date_;
                if (Session["ccround"] == null || Session["date"] == null)
                {
                    ccround_ = 1;
                    date_ = DateTime.Today.ToString();
                }
                else
                {
                    ccround_ = Convert.ToInt16(Session["ccround"].ToString());
                    if (d == null)
                    {
                        date_ = DateTime.Now.ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        month = d.Substring(4, 3);
                        day = d.Substring(8, 2);
                        year = d.Substring(11, 4);
                        strMonth = monthConvert(month);
                        //date_ = Convert.ToString(DateTime.ParseExact(Session["date"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture));
                        date_ = year + "-" + strMonth + "-" + day;
                    }

                }
                SQLDbConnection(ccround_, date_);
            }
            catch(Exception ex)
            {
                string filePath = @"C:\QA_LAB_project\Error.txt";
                //string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }

        }

        public void SQLDbConnection(int ccround_, string date_)
        {
            string ccr;
            string Strccround;
            if (ccround_ >= 1 && ccround_ <= 8)
            {
                ccr = getCCROUND(ccround_);
          
            }
            else
            {
                ccr = Convert.ToString(ccround_);
             
            }
            if(ccr.Length <= 3)
            {
                ccr = "0" + ccr;
            }
            Strccround = ccr;

            //DateTime.ParseExact(date_, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //date.Text = "Date: " + DateTime.Parse(date_).ToShortDateString() + "; CCRound: " + ccr;

            
            int index = date_.IndexOf(" ");
            if (index > 0)
                date_ = date_.Substring(0, index);
            date.Text = "Date: " + date_ + "; CCRound: " + ccr;
            String strQuery = "select * from LAB_CHARGECONTROL where CCROUND = '" + Strccround + "'  and  CCDATE =  '" + date_ + "' ";
            //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = '" + ccround_ + "' and  Date_ =  '" + date_ + "' ";
            //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = 1 and  Date_ = '" + now + "'";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add("@Id", ddlCCROUND.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                ClearFields();
               
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        oxsettler.Value = sdr["LKD4SODA"].ToString();
                        wuf.Value = sdr["WUFSODA"].ToString();
                        mtl.Value = sdr["MTLSODA"].ToString();
                        srt.Value = sdr["SRTSODA"].ToString();
                        pressfiltrate.Value = sdr["PFMG"].ToString();

                        ttcaustic.Value = sdr["TESTTANKCAUSTIC"].ToString();
                        ttac.Value = sdr["TESTTANKAC"].ToString();
                        ttcs.Value = sdr["TESTTANKCS"].ToString();

                        tridcaustic.Value = sdr["CTRIDIGESTOR"].ToString();
                        tridac.Value = sdr["ACTRIDIGESTOR"].ToString();
                        tridcs.Value = sdr["TRIDIGESTORCS"].ToString();
                        tridaim.Value = sdr["TRIDIGESTORAIM"].ToString();

                        no5caustic.Value = sdr["CFT5"].ToString();
                        no5ac.Value = sdr["ACFT5"].ToString();
                        no5cs.Value = sdr["FT5CS"].ToString();
                        no5aim.Value = sdr["FT5AIM"].ToString();

                        ddcaustic.Value = sdr["CDIGDISCH"].ToString();
                        ddac.Value = sdr["ACDIGDISCH"].ToString();
                        ddcs.Value = sdr["DIGDISCHCS"].ToString();

                        sfcaustic.Value = sdr["SETTLERFEEDCAUSTIC"].ToString();
                        sfac.Value = sdr["SETTLERFEEDAC"].ToString();
                        sfcs.Value = sdr["SETTLERFEEDCS"].ToString();

                        pfcaustic.Value = sdr["PRESSFEEDCAUSTIC"].ToString();
                        pfac.Value = sdr["PRESSFEEDAC"].ToString();

                        ltpcaustic.Value = sdr["LTPCAUSTIC"].ToString();
                        ltpac.Value = sdr["LTPAC"].ToString();
                        ltpaim.Value = sdr["LTPAIM"].ToString();

                        efcaustic.Value = sdr["EVAPFEEDCAUSTIC"].ToString();
                        efac.Value = sdr["EVAPFEEDAC"].ToString();

                        edcaustic.Value = sdr["CEVAPDISCH"].ToString();
                        edac.Value = sdr["ACEVAPDISCH"].ToString();

                        wofcaustic.Value = sdr["WOFCAUSTIC"].ToString();
                        wofac.Value = sdr["WOFAC"].ToString();

                        a7caustic.Value = sdr["A7OVERFLOWCAUSTIC"].ToString();
                        a7ac.Value = sdr["A7OVERFLOWAC"].ToString();

                        b7caustic.Value = sdr["B7OVERFLOWCAUSTIC"].ToString();
                        b7ac.Value = sdr["B7OVERFLOWAC"].ToString();

                        y15caustic.Value = sdr["CY15OVERFLOW"].ToString();
                        y15ac.Value = sdr["ACY15OVERFLOW"].ToString();

                        y16caustic.Value = sdr["CY16OVERFLOW"].ToString();
                        y16ac.Value = sdr["ACY16OVERFLOW"].ToString();
                        //
                        sufcaustic.Value = sdr["SUFCAUSTIC"].ToString();
                        sufac.Value = sdr["SUFAC"].ToString();

                        t1caustic.Value = sdr["T1CAUSTIC"].ToString();
                        t1ac.Value = sdr["T1AC"].ToString();

                        t3caustic.Value = sdr["T3CAUSTIC"].ToString();
                        t3ac.Value = sdr["T3AC"].ToString();

                        t7caustic.Value = sdr["T7CAUSTIC"].ToString();
                        t7ac.Value = sdr["T7AC"].ToString();

                        ag1caustic.Value = sdr["CAG1"].ToString();
                        ag1ac.Value = sdr["ACAG1"].ToString();

                        ag4caustic.Value = sdr["CAG3"].ToString();
                        ag4ac.Value = sdr["ACAG3"].ToString();

                        ag7caustic.Value = sdr["CAG7"].ToString();
                        ag7ac.Value = sdr["ACAG7"].ToString();

                        evapcccaustic.Value = sdr["EVAPCCCAUSTIC"].ToString();
                        evapccac.Value = sdr["EVAPCCAC"].ToString();

                        presscccaustic.Value = sdr["PRESSCCCAUSTIC"].ToString();
                        pressccac.Value = sdr["PRESSCCAC"].ToString();
                    }
                }
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                //string filePath = @"C:\QA_LAB_project\Error.txt";
                string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }


            }

        }

        public static string  getCCROUND(int val)
        {
            string ccround_;
            if (val == 1)
                ccround_ = "0300";
            else if (val == 2)
                ccround_ = "0600";
            else if (val == 3)
                ccround_ = "0900";
            else if (val == 4)
                ccround_ = "1200";
            else if (val == 5)
                ccround_ = "1500";
            else if (val == 6)
                ccround_ = "1800";
            else if (val == 7)
                ccround_ = "2100";
            else
                ccround_ = "2400";
         



            return ccround_;


        }
        protected void SelectButtonClick(object sender, EventArgs e)
        {
            pf.Visible = true;
            if (ddlCCROUND.SelectedValue == "")
                ddlCCROUND.SelectedValue = "1";
            
            Session["ccround"] = getCCROUND(Convert.ToInt16(ddlCCROUND.SelectedValue.ToString()));
            if(ddlCCROUND.SelectedValue.ToString() == "1" || ddlCCROUND.SelectedValue.ToString() == "3" || ddlCCROUND.SelectedValue.ToString() == "5" || ddlCCROUND.SelectedValue.ToString() == "7")
            {
                pf.Style["display"] = "none";
            }
            else
            {
                pf.Style["display"] = "block";
            }
            Session["date"] = Request.Form["dueDate"].ToString();
            d = Session["date"].ToString();

            GetLabData();
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                string ScheduleTimeId = ddlCCROUND.SelectedValue;
                string ScheduleTime = Convert.ToString(ddlCCROUND.SelectedItem.Text);

                //CHECK IF RECORD EXISTED
                string ccround = (Convert.ToString(ddlCCROUND.SelectedItem.Text)).Replace(":", "");

                string  strdate = Page.Request.Form["dueDate"];
                var subs = strdate.Split(' ');
                var index = subs.Count() > 4 ? subs[0].Length + subs[1].Length + 1 + subs[2].Length + 1 + subs[3].Length + 1  : 0;

                strdate = strdate.Substring(0, index);

                var date = DateTime.ParseExact(strdate,
                          "ddd MMM dd yyyy",
                           CultureInfo.InvariantCulture);
           
                date.ToShortDateString();

                String strQuery = "select * from LAB_CHARGECONTROL where CCROUND = '" + ccround + "'  and  CCDATE =  '" + date + "' ";
                //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = '" + ccround_ + "' and  Date_ =  '" + date_ + "' ";
                //String strQuery = "select * from Lab_DailyLabReport where ScheduleTimeId = 1 and  Date_ = '" + now + "'";
                SqlConnection conn = new SqlConnection(strConnString);
                SqlCommand cmd_ = new SqlCommand();
                cmd_.CommandType = CommandType.Text;
                cmd_.CommandText = strQuery;
                cmd_.Connection = conn;
                conn.Open();
                SqlDataReader sdr = cmd_.ExecuteReader();


                    if (sdr.HasRows)
                    {
                    Response.Write("<script>alert('ERROR: Date/CCRound already existed.');</script>");
                    return;
                    }
                    else
                    {
                   
                    SqlConnection con = new SqlConnection(strConnString);
                        SqlCommand cmd = new SqlCommand("LAB_sp_chargecontrol_insert", con);

                        using (con)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("stid", SqlDbType.VarChar, 2).Value = ddlCCROUND.SelectedValue;
                            cmd.Parameters.Add("st", SqlDbType.VarChar, 5).Value = (Convert.ToString(ddlCCROUND.SelectedItem.Text)).Replace(":", "");
                            cmd.Parameters.Add("date", SqlDbType.Date).Value = date;
                            cmd.Parameters.Add("ttcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ttcaustic2.Value) ? (object)DBNull.Value : ttcaustic2.Value;
                            cmd.Parameters.Add("ttac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ttac2.Value) ? (object)DBNull.Value : ttac2.Value;
                            cmd.Parameters.Add("ttcs", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ttcs2.Value) ? (object)DBNull.Value : ttcs2.Value;
                            cmd.Parameters.Add("tridcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(tridcaustic2.Value) ? (object)DBNull.Value : tridcaustic2.Value;
                            cmd.Parameters.Add("tridac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(tridac2.Value) ? (object)DBNull.Value : tridac2.Value;
                            cmd.Parameters.Add("tridcs", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(tridcs2.Value) ? (object)DBNull.Value : tridcs2.Value;
                            cmd.Parameters.Add("tridaim", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(tridaim2.Value) ? (object)DBNull.Value : tridaim2.Value;
                            cmd.Parameters.Add("no5caustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no5caustic2.Value) ? (object)DBNull.Value : no5caustic2.Value;
                            cmd.Parameters.Add("no5ac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no5ac2.Value) ? (object)DBNull.Value : no5ac2.Value;
                            cmd.Parameters.Add("no5cs", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no5cs2.Value) ? (object)DBNull.Value : no5cs2.Value;
                            cmd.Parameters.Add("no5aim", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(no5aim2.Value) ? (object)DBNull.Value : no5aim2.Value;
                            cmd.Parameters.Add("ddcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ddcaustic2.Value) ? (object)DBNull.Value : ddcaustic2.Value;
                            cmd.Parameters.Add("ddac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ddac2.Value) ? (object)DBNull.Value : ddac2.Value;
                            cmd.Parameters.Add("ddcs", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ddcs2.Value) ? (object)DBNull.Value : ddcs2.Value;
                            cmd.Parameters.Add("sfcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sfcaustic2.Value) ? (object)DBNull.Value : sfcaustic2.Value;
                            cmd.Parameters.Add("sfac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sfac2.Value) ? (object)DBNull.Value : sfac2.Value; ;
                            cmd.Parameters.Add("sfcs", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sfcs2.Value) ? (object)DBNull.Value : sfcs2.Value;
                            cmd.Parameters.Add("pfcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(pfcaustic2.Value) ? (object)DBNull.Value : pfcaustic2.Value;
                            cmd.Parameters.Add("pfac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(pfac2.Value) ? (object)DBNull.Value : pfac2.Value;
                            cmd.Parameters.Add("ltpcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ltpcaustic2.Value) ? (object)DBNull.Value : ltpcaustic2.Value;
                            cmd.Parameters.Add("ltpac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ltpac2.Value) ? (object)DBNull.Value : ltpac2.Value;
                            cmd.Parameters.Add("ltpaim", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ltpaim2.Value) ? (object)DBNull.Value : ltpaim2.Value;
                            cmd.Parameters.Add("efcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(efcaustic2.Value) ? (object)DBNull.Value : efcaustic2.Value;
                            cmd.Parameters.Add("efac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(efac2.Value) ? (object)DBNull.Value : efac2.Value;
                            cmd.Parameters.Add("edcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(edcaustic2.Value) ? (object)DBNull.Value : edcaustic2.Value;
                            cmd.Parameters.Add("edac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(edac2.Value) ? (object)DBNull.Value : edac2.Value;
                            cmd.Parameters.Add("wofcaustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(wofcaustic2.Value) ? (object)DBNull.Value : wofcaustic2.Value;
                            cmd.Parameters.Add("wofac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(wofac2.Value) ? (object)DBNull.Value : wofac2.Value;
                            cmd.Parameters.Add("a7caustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(a7caustic2.Value) ? (object)DBNull.Value : a7caustic2.Value;
                            cmd.Parameters.Add("a7ac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(a7ac2.Value) ? (object)DBNull.Value : a7ac2.Value;
                            cmd.Parameters.Add("b7caustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(b7caustic2.Value) ? (object)DBNull.Value : b7caustic2.Value;
                            cmd.Parameters.Add("b7ac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(b7ac2.Value) ? (object)DBNull.Value : b7ac2.Value;
                            cmd.Parameters.Add("y15caustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(y15caustic2.Value) ? (object)DBNull.Value : y15caustic2.Value;
                            cmd.Parameters.Add("y15ac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(y15ac2.Value) ? (object)DBNull.Value : y15ac2.Value;
                            cmd.Parameters.Add("y16caustic", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(y16caustic2.Value) ? (object)DBNull.Value : y16caustic2.Value;
                            cmd.Parameters.Add("y16ac", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(y16ac2.Value) ? (object)DBNull.Value : y16ac2.Value;
                            cmd.Parameters.Add("oxsettler", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(oxsettler2.Value) ? (object)DBNull.Value : oxsettler2.Value;
                            cmd.Parameters.Add("wuf", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(wuf2.Value) ? (object)DBNull.Value : wuf2.Value;
                            cmd.Parameters.Add("mtl", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(mtl2.Value) ? (object)DBNull.Value : mtl2.Value;
                            cmd.Parameters.Add("srt", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(srt2.Value) ? (object)DBNull.Value : srt2.Value;
                            cmd.Parameters.Add("PressFiltrate", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(pressfiltrate2.Value) ? (object)DBNull.Value : pressfiltrate2.Value;
                            cmd.Parameters.Add("SUF_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sufcaustic2.Value) ? (object)DBNull.Value : sufcaustic2.Value;
                            cmd.Parameters.Add("SUF_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(sufac2.Value) ? (object)DBNull.Value : sufac2.Value;
                            cmd.Parameters.Add("T1_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t1caustic2.Value) ? (object)DBNull.Value : t1caustic2.Value;
                            cmd.Parameters.Add("T1_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t1ac2.Value) ? (object)DBNull.Value : t1ac2.Value;
                            cmd.Parameters.Add("T3_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t3caustic2.Value) ? (object)DBNull.Value : t3caustic2.Value;
                            cmd.Parameters.Add("T3_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t3ac2.Value) ? (object)DBNull.Value : t3ac2.Value;
                            cmd.Parameters.Add("T7_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t7caustic2.Value) ? (object)DBNull.Value : t7caustic2.Value;
                            cmd.Parameters.Add("T7_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(t7ac2.Value) ? (object)DBNull.Value : t7ac2.Value;
                            cmd.Parameters.Add("AG1_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag1caustic2.Value) ? (object)DBNull.Value : ag1caustic2.Value;
                            cmd.Parameters.Add("AG1_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag1ac2.Value) ? (object)DBNull.Value : ag1ac2.Value;
                            cmd.Parameters.Add("AG4_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag4caustic2.Value) ? (object)DBNull.Value : ag4caustic2.Value;
                            cmd.Parameters.Add("AG4_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag4ac2.Value) ? (object)DBNull.Value : ag4ac2.Value;
                            cmd.Parameters.Add("AG7_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag7caustic2.Value) ? (object)DBNull.Value : ag7caustic2.Value;
                            cmd.Parameters.Add("AG7_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(ag7ac2.Value) ? (object)DBNull.Value : ag7ac2.Value;
                            cmd.Parameters.Add("EvapCC_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(evapcccaustic2.Value) ? (object)DBNull.Value : evapcccaustic2.Value;
                            cmd.Parameters.Add("EvapCC_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(evapccac2.Value) ? (object)DBNull.Value : evapccac2.Value;
                            cmd.Parameters.Add("PressCC_C", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(presscccaustic2.Value) ? (object)DBNull.Value : presscccaustic2.Value;
                            cmd.Parameters.Add("PressCC_AC", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(pressccac2.Value) ? (object)DBNull.Value : pressccac2.Value;
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        GetDataForPI(date, ccround);
                        UpdateForm();
                       
                    }
            }
            catch(Exception ex)
            {
                //string filePath = @"C:\QA_LAB_project\Error.txt";
                string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
        }
        public void GetDataForPI(DateTime date, string ccround)
        {
            int time = Convert.ToInt16(ddlCCROUND.SelectedItem.Text.Substring(0, 2));
            DateTime datetime;
            TimeSpan ts;
            if (time == 24)
            {
                ts = new TimeSpan(23, 59, 59);
            }
            else ts = new TimeSpan(time, 0, 0);
            datetime = date + ts;
            List<decimal?> piTagValues = new List<decimal?>();
            try
            {
                //while (1 == 1)
                {
                    //testtankcaustic
                    if (!string.IsNullOrEmpty(ttcaustic2.Value))
                    {
                        decimal LABTTC = Convert.ToDecimal(ttcaustic2.Value);
                        piTagValues.Add(LABTTC);
                    }
                    else
                        piTagValues.Add(null);
                    //testtankac
                    if (!string.IsNullOrEmpty(ttac2.Value))
                    {
                        decimal LABTTAC = Convert.ToDecimal(ttac2.Value);
                        piTagValues.Add(LABTTAC);
                    }
                    else
                        piTagValues.Add(null);
                    //tridigestor caustic
                    if (!string.IsNullOrEmpty(tridcaustic2.Value))
                    {
                        decimal LABTHDC = Convert.ToDecimal(tridcaustic2.Value);
                        piTagValues.Add(LABTHDC);
                    }
                    else
                        piTagValues.Add(null);
                    //tridigestor ac
                    if (!string.IsNullOrEmpty(tridac2.Value))
                    {
                        decimal LABTHDAC = Convert.ToDecimal(tridac2.Value);
                        piTagValues.Add(LABTHDAC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(no5caustic2.Value))
                    {
                        decimal LABMHDC = Convert.ToDecimal(no5caustic2.Value);
                        piTagValues.Add(LABMHDC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(no5ac2.Value))
                    {
                        decimal LABMHDAC = Convert.ToDecimal(no5ac2.Value);
                        piTagValues.Add(LABMHDAC);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(efcaustic2.Value))
                    {
                        decimal LABEFC = Convert.ToDecimal(efcaustic2.Value);
                        piTagValues.Add(LABEFC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(efac2.Value))
                    {
                        decimal LABEFAC = Convert.ToDecimal(efac2.Value);
                        piTagValues.Add(LABEFAC);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(ttcs2.Value))
                    {
                        decimal LABTTCBYS = Convert.ToDecimal(ttcs2.Value);
                        piTagValues.Add(LABTTCBYS);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(edcaustic2.Value))
                    {
                        LABEDC = Convert.ToDecimal(edcaustic2.Value); piTagValues.Add(LABEDC);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(edac2.Value))
                    {
                        LABEDAC = Convert.ToDecimal(edac2.Value); piTagValues.Add(LABEDAC);

                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(ddcaustic2.Value))
                    {
                        decimal LABDDC = Convert.ToDecimal(ddcaustic2.Value); piTagValues.Add(LABDDC);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(ddac2.Value))
                    {
                        decimal LABDDAC = Convert.ToDecimal(ddac2.Value); piTagValues.Add(LABDDAC);
                    }
                    else
                        piTagValues.Add(null);



                    if (!string.IsNullOrEmpty(sfcaustic2.Value))
                    {
                        decimal LABBOTC = Convert.ToDecimal(sfcaustic2.Value); piTagValues.Add(LABBOTC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(sfac2.Value))
                    {
                        decimal LABBOTAC = Convert.ToDecimal(sfac2.Value); piTagValues.Add(LABBOTAC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(wofcaustic2.Value))
                    {
                        decimal LABWOFC = Convert.ToDecimal(wofcaustic2.Value); piTagValues.Add(LABWOFC);

                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(wofac2.Value))
                    {
                        LABWOFAC = Convert.ToDecimal(wofac2.Value); piTagValues.Add(LABWOFAC);

                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(ltpcaustic2.Value))
                    {
                        decimal LABLTPC = Convert.ToDecimal(ltpcaustic2.Value); piTagValues.Add(LABLTPC);

                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(ltpac2.Value))
                    {
                        decimal LABLTPAC = Convert.ToDecimal(ltpac2.Value); piTagValues.Add(LABLTPAC);

                    }
                    else
                        piTagValues.Add(null);

               
                    if (!string.IsNullOrEmpty(pfcaustic2.Value))
                    {
                        decimal LABPFC = Convert.ToDecimal(pfcaustic2.Value); piTagValues.Add(LABPFC);
                    }
                    else
                        piTagValues.Add(null);
                    if (!string.IsNullOrEmpty(ltpaim2.Value))
                    {
                        decimal LABLTPAIM = Convert.ToDecimal(ltpaim2.Value); piTagValues.Add(LABLTPAIM);
                    }
                    else
                        piTagValues.Add(null);
               

                    if (!string.IsNullOrEmpty(wuf2.Value))
                    {
                        decimal LABW8UFC = Convert.ToDecimal(wuf2.Value); piTagValues.Add(LABW8UFC);
                    }
                    else
                        piTagValues.Add(null);

                    if (!string.IsNullOrEmpty(mtl2.Value))
                    {
                        decimal LABMTLC = Convert.ToDecimal(mtl2.Value); piTagValues.Add(LABMTLC);
                    }
                    else
                        piTagValues.Add(null);

                    PiInsert(piTagValues, datetime, date, ccround);
                }
             
            }
                catch (Exception ex)
                {
                    //string filePath = @"C:\QA_LAB_project\Error.txt";
                string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                           "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }
        }
        public void PiInsert(List<decimal?> piTagValues, DateTime dateTime, DateTime date, string ccround)
        {
           
            try
            {
                //Lab_TagTable piTags = new Lab_TagTable();
                PIServers myPIServers = new PIServers();
                PIServer myPIServer = myPIServers.DefaultPIServer;
                NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
                myPIServer.Connect(credential);
                LabEntities db = new LabEntities();

                var list = (from v in db.Lab_TagTable
                            orderby v.Id
                            select v);

                //var list = (from v in db.Lab_PhamTag
                //            orderby v.Id
                //            select v);

                int utc = DateTime.UtcNow.Hour;
                int dt = DateTime.Now.Hour;
                int diff;
                if (utc > dt)
                    diff = utc - dt;
                else
                    diff = utc + 24 - dt;
                foreach (var item in list)
                {
                    string TagName = item.Pi_Tags_Test;
                    //string TagName = item.TagName;

                    int _index = (item.Indx) - 1;
                    //int _index = (item.Id) - 1;

                    PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);
                    AFValue currentTag = myPIPoint.CurrentValue();

                    currentTag.Value = Convert.ToString(piTagValues[_index]);
                    currentTag.Timestamp = dateTime;

                    if (DateTime.Now > dateTime)
                    {
                        if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                        {
                            myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('ERROR: Target Date/Time cannot be in future.');</script>");
                        return;
                    }

                    //if (action == "delete")
                    //{
                    //    myPIPoint.UpdateValue(currentTag, AFUpdateOption.Remove);
                    //}

                    //if (action == "replace")
                    //{
                    //    //if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                    //    {
                    //        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);
                    //    }
                    //}
                }
                Response.Write("<script>alert('Record has been saved and sent to PI.');</script>");
                myPIServer.Disconnect();
            }
            catch (Exception ex)
            {

                //string filePath = @"C:\QA_LAB_project\Error.txt";
                string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }



            }

        }
        public void UpdateForm()
        {
            try
            {
                if (ddlCCROUND.SelectedValue == "")
                    ddlCCROUND.SelectedValue = "1";
                Session["ccround"] = ddlCCROUND.SelectedValue.ToString();
                pf.Style["display"] = "block";
                if (ddlCCROUND.SelectedValue.ToString() == "1" || ddlCCROUND.SelectedValue.ToString() == "3" || ddlCCROUND.SelectedValue.ToString() == "5" || ddlCCROUND.SelectedValue.ToString() == "7")
                {
                    pf.Style["display"] = "none";
                }
                else
                {
                    pf.Style["display"] = "block";
                }
                Session["date"] = Request.Form["dueDate"].ToString();
                d = Session["date"].ToString();
            }
            catch(Exception ex)
            {

                //string filePath = @"C:\QA_LAB_project\Error.txt";
                string filePath = @"C:\inetpub\wwwroot\QA_LAB_ChargeControl\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }


            }

            //GetLabData();
            loadData();
        }


    }
}
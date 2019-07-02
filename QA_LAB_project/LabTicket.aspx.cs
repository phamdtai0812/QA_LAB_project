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

using OSIsoft.AF.PI;
using OSIsoft.AF;
using OSIsoft.AF.Time;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;

using System.DirectoryServices;
using System.Net;
using QA_LAB_project.Models;

using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;
using iTextSharp.tool.xml;
using SelectPdf;
using System.Drawing;

namespace QA_LAB_project
{
    public partial class LabTicket : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                //role.Value = Session["Role"].ToString();
                //Session.Clear();

                HttpCookie _userRole = Request.Cookies["UserRole"];
                if (_userRole != null)
                {
                    role.Value = _userRole["role"];
                }


                //insertNewRow();
             
                gvBind();
                //this.Response.Redirect(this.Request.Url.ToString());
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            return;
        }

        protected void HelloProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"\\ga-fs1\shared\Everyone\Tai_Pham\Lab\LabTicket\HelloWorldConsoleApp.exe";
            startInfo.Verb = "runas";
            Process.Start(startInfo);
            Thread.Sleep(4000);

        }
        protected void startProcess(string round, DateTime date_)
        {
            //getPitagValues("TAKEOUT_incl_wetcake");
            string arg1 = round;
            string arg2 = date_.ToShortDateString();
            string genArgs = arg1 + " " + arg2;
            //Extract excel file
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //startInfo.FileName = @"D:\PROJECTS\LAB\LabTicketConsole\Settler_UFSolids\bin\Debug\Settler_UFSolids.exe";

            //startInfo.FileName = @"\\ga-fs1\shared\Everyone\Tai_Pham\Lab\LabTicket\Settler_UFSolids.exe";

            startInfo.FileName = @"\\ga-fs1\shared\Everyone\Tai_Pham\Lab\LabTicket\Settler_UFSolids.exe";

            startInfo.Arguments = genArgs;
            startInfo.Verb = "runas";

            Process.Start(startInfo);
            Thread.Sleep(1000);
        }

      
        protected void gvccontrol_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ccround"] = ddlCCROUND.SelectedItem;
            Session["selectedCCROUND"] = ddlCCROUND.SelectedValue;

            //HelloProcess();

            //if (Convert.ToInt16(Session["ccround"].ToString().Substring(0, 2)) == 24)
            //{
            //    Session["ccontrol_date"] = DateTime.Today.AddDays(-1).ToShortDateString();
            //}
            gvBind();
            //Thread.Sleep(3000);
            ddlCCROUND.SelectedIndex = Convert.ToInt16(HttpContext.Current.Session["selectedCCROUND"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected decimal getPitagValues(string tagname)
        {
            //get AVERAGE OF PI POINTS
            PIServer myPIServer = new PIServers().DefaultPIServer;
            NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
            myPIServer.Connect(credential);
            PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, tagname);
            AFTime sTime = DateTime.Now.Date.AddDays(-2).AddHours(23);
            AFTime eTime = DateTime.Now.Date.AddDays(-1).AddHours(23);

            //AFTime sTime = DateTime.Now.Date.AddDays(-7).AddHours(23);
            //AFTime eTime = DateTime.Now.Date.AddDays(-6).AddHours(23);

            AFTimeRange tr = new AFTimeRange(sTime, eTime);
            IDictionary<AFSummaryTypes, AFValue> sumS = myPIPoint.Summary(tr, OSIsoft.AF.Data.AFSummaryTypes.Average, OSIsoft.AF.Data.AFCalculationBasis.TimeWeighted, AFTimestampCalculation.EarliestTime);
            AFValue sumAvg = sumS[AFSummaryTypes.Average];

            decimal Avg = decimal.Parse((sumAvg.Value).ToString());
            //if(Avg == null  )
            //{
            //    Avg = 0;

            //}

            return Avg;
        }
        [WebMethod]
        public static List<TagMinMax> GetNames()
        {


            List<TagMinMax> tagList = new List<TagMinMax>();

            Lab_TagTable Tagtbl = new Lab_TagTable();
            LabEntities db = new LabEntities();
            var list = (from t in db.Lab_TagTable
                        orderby t.Id
                        select t).Take(23).ToList();

            foreach (var l in list)
            {
                tagList.Add(new TagMinMax
                {
                    Gv_ControlName = l.gv_control_name,
                    Min =  Convert.ToDecimal(l.Min),
                    Max = Convert.ToDecimal(l.Max)
                });
            }




            return tagList;

      

        }
        public class TagMinMax
        {
            public string Gv_ControlName { get; set; } = string.Empty;
            public decimal Min { get; set; }
            public decimal Max { get; set; }
        }
        [WebMethod]
        public static string getTagMinMax()
        {
            Lab_TagTable Tagtbl = new Lab_TagTable();
            LabEntities db = new LabEntities();
            var list = (from t in db.Lab_TagTable
                        orderby t.Id
                        select t).Take(23).ToList();

            //return //Json(list, JsonRequestBehavior.AllowGet);

            return null;
        }
        [WebMethod]
        public static string callCodeBehind(string selDate, int selRound)
        {
            HttpContext.Current.Session["ccontrol_date"] = selDate;

            return selDate;
        }
        public static string getCCROUND(int val)
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
        public void insertNewRow()
        {
            try
            {
                string dt;
                if (HttpContext.Current.Session["ccontrol_date"] != null)
                    dt = HttpContext.Current.Session["ccontrol_date"].ToString();
                else
                    dt = DateTime.Today.ToShortDateString();
                string query;
                query = "SELECT reportdate   FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + dt + "'";
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
            catch(Exception x)
            {

            }
        }
        protected string ccround_
        {
            get; set;
        }
        public void createNewRow(string dt)
        {
            try
            {
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand("LAB_sp_CreatRow_lab_ticket", con);
                using (con)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
        public void gvBind()
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                string ccround;
                if (string.IsNullOrEmpty(Session["ccontrol_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["ccontrol_date"] = date;
                    ccround = "0300";
                    Session["ccround"] = ccround;
                    this.ccround_ = ccround;
                }
                else
                { date = Session["ccontrol_date"].ToString();
                    ccround = Session["ccround"].ToString();
                    this.ccround_ = ccround;
                }
                DateTime date_ = Convert.ToDateTime(date);
                //string date_ = "2018-03-10";
                // DateTime date_ =  DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                date_max.Value = date;

                query = "select 'Time Sampled' as [s], [TimeSampled] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Takeout' as s, [Takeout] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Sly' as s, [Sly] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Run Time' as [s], [Run Time] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Plant Flow' as [s], [Plant Flow] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select  'Booster Flow:' as [s], [Booster Flow] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Production' as [s], [Production] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Bauxite:' as [s], [Bauxite] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "'";

                query += " select  'MHD Liquor' as [s], [MHD Liquor] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Tri Liquor' as [s], [Tri Liquor] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'Mud Load' as [s], [Mud Load] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                //" select 'Process Control' as [s], 1 as a union all " +
                " select  'MHD. Aim' as [s], [MHD Aim] as a FROM[Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                //" select 'West' as [s], 1 as a union all " +
                " select 'THD Aim' as [s], [THD Aim] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
       
                " select 'Dilution' as [s], [Dilution] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +
                " select 'TT Seed' as s, [TT Seed] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "' union all " +

                 " select 'Lime Rate:' as [s], [Lime Rate] as a FROM [Lab].[dbo].[LAB_TICKET] WHERE reportdate = '" + date_ + "' and timesampled = '" + ccround + "'";

                query += "select 'Test Tank' as [s], [TESTTANKCAUSTIC] as a, [TESTTANKAC] as b, [TESTTANKCS] as c, null as [AIM] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Tri Digestor', [CTRIDIGESTOR] as a,[ACTRIDIGESTOR] as b,  [TRIDIGESTORCS] as c, [TRIDIGESTORAIM] as [AIM]  FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'No.5 Flash Tank', [CFT5] as a,[ACFT5] as b,  [FT5CS] as c, [FT5AIM] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Dig Disch', [CDIGDISCH] as a, [ACDIGDISCH],[DIGDISCHCS] as b, null   FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Settler Feed', [SETTLERFEEDCAUSTIC] as a,[SETTLERFEEDAC] as b,[SETTLERFEEDCS] , null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Press Feed', [PRESSFEEDCAUSTIC] as a,[PRESSFEEDAC] as b ,null , null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'LTP', [LTPCAUSTIC] as a,[LTPAC] as b,null , [LTPAIM] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Evap Feed', [EVAPFEEDCAUSTIC] as a, [EVAPFEEDAC] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Evap Disch', [CEVAPDISCH] as a, [ACEVAPDISCH] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'WOF', [WOFCAUSTIC] as a, [WOFAC] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'SUF Overflow', [SUFCAUSTIC] as a, [SUFAC] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'T1 Overflow', t1caustic as a, t1ac as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'T3 Overflow', t3caustic as a, t3ac as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'T7 Overflow', t7caustic as a, t7ac as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Evap C/C', [EVAPCCCAUSTIC] as a,[EVAPCCAC] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Press C/C', [PRESSCCCAUSTIC] as a,[PRESSCCAC] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'AG1', [CAG1] as a, [ACAG1] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'AG4', [CAG3] as a, [ACAG3] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'AG7', [CAG7] as a, [ACAG7] as b, null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'A7 Overflow' as a, [A7OVERFLOWCAUSTIC] as b, [A7OVERFLOWAC], null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'B7 Overflow' as a, [B7OVERFLOWCAUSTIC] as b, [B7OVERFLOWAC], null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Y15 Overflow' as a, [CY15OVERFLOW] as b, [ACY15OVERFLOW], null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       "select 'Y16 Overflow' as a, [CY16OVERFLOW] as b, [ACY16OVERFLOW], null, null FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "' and ccround = '" + ccround + "' ";

                //query += "select 'Ox Settler' as [s], [LKD4SODA] as a FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "' union all " +
                query += " select 'WUF'  as [s], [WUFSODA] as a FROM [Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       " select 'MTL'  as [s],  [MTLSODA] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       " select 'SRT', [SRTSODA] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "'union all " +
                       //" select 'Press Filtrate(MG/L)', [PFMG] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "' union all " +
                       " select 'Bad Cond', [BadCond] FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "'";

                if (ccround == "0600" )
                {

                    query +=    " select '#1 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                                "   select '#2 KD'  as [s],null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                                " select '#3 KD'  as [s],  null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +

                                " select '#1 KF'  as [s], null as a, [kfls0600_1] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                                " select '#2 KF'  as [s], null as a, [kfls0600_2] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                                " select '#3 KF' as [s],  null as a, [kfls0600_3] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE = '" + date_ + "' ";
                }
                else if (ccround == "0900" && DateTime.Now.Hour >= 9)
                {
                    query += " select '#1 KD'  as [s], [kdloi1000_1] as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                             "   select '#2 KD'  as [s], [kdloi1000_2] as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                             " select '#3 KD'  as [s], [kdloi1000_3] as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +

                             " select '#1 KF'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#2 KF'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#3 KF' as [s],  null as a,  null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE = '" + date_ + "' ";

                }
                else if (ccround == "1800" && DateTime.Now.Hour >= 18)
                {
                    query += " select '#1 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                  " select '#2 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                  " select '#3 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +

                  " select '#1 KF'  as [s], null as a, [kfls1800_1] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                  " select '#2 KF'  as [s], null as a, [kfls1800_2] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                  " select '#3 KF' as [s],  null as a, [kfls1800_3] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE = '" + date_ + "' ";

                }
                else 
                {
                    query += " select '#1 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#2 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#3 KD'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +

                            " select '#1 KF'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#2 KF'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' union all " +
                            " select '#3 KF' as [s],  null as a,  null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE = '" + date_ + "' ";
                }

                if (ccround == "0600")
                {
                    query += " select 'Dryer Disch.'  as [s], [hd0600RF] as a, [hd0600ls] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' ";
                }
                else if (ccround == "1800")
                {
                    query += " select 'Dryer Disch.'  as [s], [hd1800RF] as a, [hd1800ls] as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' ";
                }
                else
                    query += " select 'Dryer Disch.'  as [s], null as a, null as b FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE =  '" + date_ + "' ";

                query += " select MMISCDESCR as s, cast(MMISCQTY as decimal (6,3)) as a, Cast(MMISCSIZE as decimal (6,4)) as b from LAB_MISC where ccround =  '" + ccround + "'  and MMISCDATE =  '" + date_ + "' " +
                       " and MMISCDESCR not like 'BAD COND @%'  ";

                query += " select cctruck as s, cccaustic as a, ccac as b, ccround as c  from LAB_caustic_clean where ccround =  '" + ccround + "'  and ccdate =  '" + date_ + "'  ";

                if ( ccround == "0600" || ccround == "1200" || ccround == "1800" || ccround == "2400")
                {
                    query += " select 'Press Solids' as [s], " +
                             " [PFMG] as a, " +
                             " CASE WHEN pscolor = '0' THEN '-' WHEN pscolor = '1' THEN 'White'  When pscolor = '2' then 'Tan' " +
                             " When pscolor = '3' then 'Other' end as pscolor FROM[Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE = '" + date_ + "'  and ccround = '" + ccround + "' ";
                }

           

                //query += "select CC_ID as [CC_ID] FROM [Lab].[dbo].[LAB_CHARGECONTROL] WHERE CCDATE =  '" + date_ + "' and ccround = '" + ccround + "' ";
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
                        gv_labticket1.DataSource = ds.Tables[0];
                        gv_labticket1.DataBind();

                        gv_labticket2.DataSource = ds.Tables[1];
                        gv_labticket2.DataBind();

                        gv_labticket3.DataSource = ds.Tables[2];
                        gv_labticket3.DataBind();

                        gv_labticket4.DataSource = ds.Tables[3];
                        gv_labticket4.DataBind();

                        gv_labticket5.DataSource = ds.Tables[4];
                        gv_labticket5.DataBind();

                        gv_labticket6.DataSource = ds.Tables[5];
                        gv_labticket6.DataBind();


                    
                    
                        gv_labticket7.DataSource = ds.Tables[6];
                        gv_labticket7.DataBind();

                        gv_labticket8.DataSource = ds.Tables[7];
                        gv_labticket8.DataBind();

                        if (ccround == "0600" || ccround == "1200" || ccround == "1800" || ccround == "2400")
                        {
                            gv_pfcolor.DataSource = ds.Tables[8];
                            gv_pfcolor.DataBind();
                        }

                        //Session["CC_ID"] = ds.Tables[2].Rows[0]["CC_ID"];
                        //string s = Session["CC_ID"].ToString();
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
            try
            {
                dt.Columns.Add("TESTTANKCAUSTIC", typeof(string));
                dt.Columns.Add("TESTTANKAC", typeof(string));
                dt.Columns.Add("TESTTANKCS", typeof(string));
                dt.Columns.Add("CTRIDIGESTOR", typeof(string));
                dt.Columns.Add("ACTRIDIGESTOR", typeof(string));
                dt.Columns.Add("TRIDIGESTORCS", typeof(string));
                dt.Columns.Add("TRIDIGESTORAIM", typeof(string));
                dt.Columns.Add("CFT5", typeof(string));
                dt.Columns.Add("ACFT5", typeof(string));
                dt.Columns.Add("FT5CS", typeof(string));
                dt.Columns.Add("FT5AIM", typeof(string));

                dt.Columns.Add("CDIGDISCH", typeof(string));
                dt.Columns.Add("ACDIGDISCH", typeof(string));
                dt.Columns.Add("DIGDISCHCS", typeof(string));
                dt.Columns.Add("SETTLERFEEDCS", typeof(string));
                dt.Columns.Add("SETTLERFEEDAIM", typeof(string));
                dt.Columns.Add("SETTLERFEEDCAUSTIC", typeof(string));
                dt.Columns.Add("SETTLERFEEDAC", typeof(string));
                dt.Columns.Add("PRESSFEEDCAUSTIC", typeof(string));
                dt.Columns.Add("PRESSFEEDAC", typeof(string));
                dt.Columns.Add("LTPAIM", typeof(string));
                dt.Columns.Add("LTPCAUSTIC", typeof(string));
                dt.Columns.Add("LTPAC", typeof(string));
                dt.Columns.Add("EVAPFEEDCAUSTIC", typeof(string));
                dt.Columns.Add("EVAPFEEDAC", typeof(string));
                dt.Columns.Add("CEVAPDISCH", typeof(string));
                dt.Columns.Add("ACEVAPDISCH", typeof(string));
                dt.Columns.Add("WOFAC", typeof(string));
                dt.Columns.Add("WOFCAUSTIC", typeof(string));
                dt.Columns.Add("A7OVERFLOWCAUSTIC", typeof(string));
                dt.Columns.Add("A7OVERFLOWAC", typeof(string));
                dt.Columns.Add("B7OVERFLOWCAUSTIC", typeof(string));
                dt.Columns.Add("B7OVERFLOWAC", typeof(string));
                dt.Columns.Add("CY15OVERFLOW", typeof(string));
                dt.Columns.Add("ACY15OVERFLOW", typeof(string));
                dt.Columns.Add("CY16OVERFLOW", typeof(string));
                dt.Columns.Add("ACY16OVERFLOW", typeof(string));
                dt.Columns.Add("SUFCAUSTIC", typeof(string));
                dt.Columns.Add("SUFAC", typeof(string));
                dt.Columns.Add("T1CAUSTIC", typeof(string));
                dt.Columns.Add("T1AC", typeof(string));
                dt.Columns.Add("T3CAUSTIC", typeof(string));
                dt.Columns.Add("T3AC", typeof(string));
                dt.Columns.Add("T7CAUSTIC", typeof(string));
                dt.Columns.Add("T7AC", typeof(string));
                dt.Columns.Add("EVAPCCCAUSTIC", typeof(string));
                dt.Columns.Add("EVAPCCAC", typeof(string));
                dt.Columns.Add("PRESSCCCAUSTIC", typeof(string));
                dt.Columns.Add("PRESSCCAC", typeof(string));
                dt.Columns.Add("CAG1", typeof(string));
                dt.Columns.Add("CAG3", typeof(string));
                dt.Columns.Add("CAG7", typeof(string));
                dt.Columns.Add("ACAG1", typeof(string));
                dt.Columns.Add("ACAG3", typeof(string));
                dt.Columns.Add("ACAG7", typeof(string));

                dt.Columns.Add("LKD4SODA", typeof(string));
                dt.Columns.Add("WUFSODA", typeof(string));
                dt.Columns.Add("MTLSODA", typeof(string));
                dt.Columns.Add("SRTSODA", typeof(string));
                dt.Columns.Add("PFMG", typeof(string));
            }
            catch
            {

            }
            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            try
            {
                string Ques = ((TextBox)gv_labticket3.Rows[1].FindControl("gv_ccontrol_caustic")).Text;
                string Ques_ = ((TextBox)gv_labticket3.Rows[1].FindControl("gv_ccontrol_ac")).Text;
                DataTable dt = GenerateTable();
                var row = dt.NewRow();
                dt.Rows.Add(row);
                foreach (GridViewRow rows in gv_labticket3.Rows)
                {

                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_caustic");
                    string a1 = txtbox1.Text;
                    System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_ac");
                    string a2 = txtbox2.Text;
                    System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_cs");
                    string a3 = txtbox3.Text;
                    System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_ccontrol_aim");
                    string a4 = txtbox4.Text;


                    //CCROUND 0300
                    if (Session["ccround"].ToString() == "0300" || Session["ccround"].ToString() == "0900")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;
                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;
                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;
                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;
                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }
                        else if (rows.RowIndex == 19)
                        {
                            row["A7OVERFLOWCAUSTIC"] = a1;
                            row["A7OVERFLOWAC"] = a2;
                        }
                        else if (rows.RowIndex == 20)
                        {
                            row["B7OVERFLOWCAUSTIC"] = a1;
                            row["B7OVERFLOWAC"] = a2;
                        }
                        else if (rows.RowIndex == 21)
                        {
                            row["CY15OVERFLOW"] = a1;
                            row["ACY15OVERFLOW"] = a2;
                        }
                        else if (rows.RowIndex == 22)
                        {
                            row["CY16OVERFLOW"] = a1;
                            row["ACY16OVERFLOW"] = a2;
                        }
                    }

                    //CCROUND 0600
                    else if (Session["ccround"].ToString() == "0600")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;

                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;

                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;

                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }
                        else if (rows.RowIndex == 10)
                        {
                            row["SUFCAUSTIC"] = a1;
                            row["SUFAC"] = a2;
                        }
                        else if (rows.RowIndex == 11)
                        {
                            row["T1CAUSTIC"] = a1;
                            row["T1AC"] = a2;
                        }
                        else if (rows.RowIndex == 12)
                        {
                            row["T3CAUSTIC"] = a1;
                            row["T3AC"] = a2;
                        }
                        else if (rows.RowIndex == 13)
                        {
                            row["T7CAUSTIC"] = a1;
                            row["T7AC"] = a2;
                        }
                        else if (rows.RowIndex == 14)
                        {
                            row["EVAPCCCAUSTIC"] = a1;
                            row["EVAPCCAC"] = a2;
                        }
                        else if (rows.RowIndex == 15)
                        {
                            row["PRESSCCCAUSTIC"] = a1;
                            row["PRESSCCAC"] = a2;
                        }
                        else if (rows.RowIndex == 16)
                        {
                            row["CAG1"] = a1;
                            row["ACAG1"] = a2;
                        }
                        else if (rows.RowIndex == 17)
                        {
                            row["CAG3"] = a1;
                            row["ACAG3"] = a2;
                        }
                        else if (rows.RowIndex == 18)
                        {
                            row["CAG7"] = a1;
                            row["ACAG7"] = a2;
                        }
                    }

                    //ccround 1200 && 2400
                    else if (Session["ccround"].ToString() == "1200" || Session["ccround"].ToString() == "2400")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;

                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;

                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;

                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }

                    }

                    //ccround 1500
                    else if (Session["ccround"].ToString() == "1500")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;

                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;

                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;

                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }
                        else if (rows.RowIndex == 11)
                        {
                            row["T1CAUSTIC"] = a1;
                            row["T1AC"] = a2;
                        }
                        else if (rows.RowIndex == 13)
                        {
                            row["T7CAUSTIC"] = a1;
                            row["T7AC"] = a2;
                        }
                        else if (rows.RowIndex == 16)
                        {
                            row["CAG1"] = a1;
                            row["ACAG1"] = a2;
                        }
                        else if (rows.RowIndex == 17)
                        {
                            row["CAG3"] = a1;
                            row["ACAG3"] = a2;
                        }
                        else if (rows.RowIndex == 18)
                        {
                            row["CAG7"] = a1;
                            row["ACAG7"] = a2;
                        }
                    }

                    //CCROUND 1800
                    else if (Session["ccround"].ToString() == "1800")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;

                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;

                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;

                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;
                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;
                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }
                        else if (rows.RowIndex == 10)
                        {
                            row["SUFCAUSTIC"] = a1;
                            row["SUFAC"] = a2;
                        }

                        else if (rows.RowIndex == 14)
                        {
                            row["EVAPCCCAUSTIC"] = a1;
                            row["EVAPCCAC"] = a2;
                        }
                        else if (rows.RowIndex == 15)
                        {
                            row["PRESSCCCAUSTIC"] = a1;
                            row["PRESSCCAC"] = a2;
                        }
                        else if (rows.RowIndex == 19)
                        {
                            row["A7OVERFLOWCAUSTIC"] = a1;
                            row["A7OVERFLOWAC"] = a2;
                        }
                        else if (rows.RowIndex == 20)
                        {
                            row["B7OVERFLOWCAUSTIC"] = a1;
                            row["B7OVERFLOWAC"] = a2;
                        }
                        else if (rows.RowIndex == 21)
                        {
                            row["CY15OVERFLOW"] = a1;
                            row["ACY15OVERFLOW"] = a2;
                        }
                        else if (rows.RowIndex == 22)
                        {
                            row["CY16OVERFLOW"] = a1;
                            row["ACY16OVERFLOW"] = a2;
                        }
                    }

                    //ccround 2100
                    else if (Session["ccround"].ToString() == "2100")
                    {
                        if (rows.RowIndex == 0)
                        {
                            row["TESTTANKCAUSTIC"] = a1;
                            row["TESTTANKAC"] = a2;
                            row["TESTTANKCS"] = a3;

                        }
                        else if (rows.RowIndex == 1)
                        {
                            row["CTRIDIGESTOR"] = a1;
                            row["ACTRIDIGESTOR"] = a2;
                            row["TRIDIGESTORCS"] = a3;
                            row["TRIDIGESTORAIM"] = a4;
                        }
                        else if (rows.RowIndex == 2)
                        {
                            row["CFT5"] = a1;
                            row["ACFT5"] = a2;
                            row["FT5CS"] = a3;
                            row["FT5AIM"] = a4;
                        }
                        else if (rows.RowIndex == 3)
                        {
                            row["CDIGDISCH"] = a1;
                            row["ACDIGDISCH"] = a2;
                            row["DIGDISCHCS"] = a3;

                        }
                        else if (rows.RowIndex == 4)
                        {
                            row["SETTLERFEEDCAUSTIC"] = a1;
                            row["SETTLERFEEDAC"] = a2;
                            row["SETTLERFEEDCS"] = a3;

                        }
                        else if (rows.RowIndex == 5)
                        {
                            row["PRESSFEEDCAUSTIC"] = a1;
                            row["PRESSFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 6)
                        {
                            row["LTPCAUSTIC"] = a1;
                            row["LTPAC"] = a2;
                            row["LTPAIM"] = a4;
                        }
                        else if (rows.RowIndex == 7)
                        {
                            row["EVAPFEEDCAUSTIC"] = a1;
                            row["EVAPFEEDAC"] = a2;

                        }
                        else if (rows.RowIndex == 8)
                        {
                            row["CEVAPDISCH"] = a1;
                            row["ACEVAPDISCH"] = a2;
                        }
                        else if (rows.RowIndex == 9)
                        {
                            row["WOFCAUSTIC"] = a1;
                            row["WOFAC"] = a2;
                        }
                        else if (rows.RowIndex == 11)
                        {
                            row["T1CAUSTIC"] = a1;
                            row["T1AC"] = a2;
                        }
                        else if (rows.RowIndex == 13)
                        {
                            row["T7CAUSTIC"] = a1;
                            row["T7AC"] = a2;
                        }
                        else if (rows.RowIndex == 16)
                        {
                            row["CAG1"] = a1;
                            row["ACAG1"] = a2;
                        }

                        else if (rows.RowIndex == 18)
                        {
                            row["CAG7"] = a1;
                            row["ACAG7"] = a2;
                        }

                    }

                }

                foreach (GridViewRow rows in gv_labticket4.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("gv_soda_gpl");
                    string a1 = txtbox1.Text;
                    if (rows.RowIndex == 0)
                        row["LKD4SODA"] = a1;
                    else if (rows.RowIndex == 1)
                        row["WUFSODA"] = a1;
                    else if (rows.RowIndex == 2)
                        row["MTLSODA"] = a1;
                    else if (rows.RowIndex == 3)
                        row["SRTSODA"] = a1;
                    else if (rows.RowIndex == 4)
                        row["PFMG"] = a1;

                }


                Update(dt);

                gvBind();
                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {
            }
        }
   
        protected void SendPDF_Click(object sender, EventArgs e)
        {

          
            try
            {
                // instantiate the html to pdf converter
                HtmlToPdf converter = new HtmlToPdf();
                // convert the url to pdf
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);
                // save pdf document
                doc.Save(@"\\ga-fs1\shared\Everyone\Lab\gr-tech_QA_LAB_LabTicket.aspx.pdf");
                // close pdf document
                doc.Close();


                ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = @"C:\Lab\Test_SendingEmailViaOutlook.exe";
                startInfo.FileName = @"\\ga -fs1\shared\Everyone\Tai_Pham\Lab\EmailLabTicket\Test_SendingEmailViaOutlook.exe";
                startInfo.Arguments = "labticket";
                startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                Thread.Sleep(4000);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
            }
            catch (Exception) { }
        }
        public void Update(DataTable dt)
        {
    
            try
            {
                int time = Convert.ToInt16(Session["ccround"].ToString().Substring(0, 2));
                DateTime datetime;
                TimeSpan ts;
                if (time == 24)
                {
                    ts = new TimeSpan(23, 59, 59);
                }
                else ts = new TimeSpan(time, 0, 0);

                var date = Convert.ToDateTime(Session["ccontrol_date"].ToString());
                datetime = date + ts;

                var today = DateTime.Now.Date;

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand("LAB_sp_ccontrol", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CC_ID", SqlDbType.Int).Value = Convert.ToInt16(Session["CC_ID"].ToString());

                    //THESE GO INTO PI
                    cmd.Parameters.AddWithValue("@TESTTANKCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TESTTANKCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TESTTANKCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@TESTTANKAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TESTTANKAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TESTTANKAC"].ToString();
                    cmd.Parameters.AddWithValue("@CTRIDIGESTOR", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CTRIDIGESTOR"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CTRIDIGESTOR"].ToString();
                    cmd.Parameters.AddWithValue("@ACTRIDIGESTOR", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACTRIDIGESTOR"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACTRIDIGESTOR"].ToString();
                    cmd.Parameters.AddWithValue("@CFT5", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CFT5"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CFT5"].ToString();
                    cmd.Parameters.AddWithValue("@ACFT5", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACFT5"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACFT5"].ToString();
                    cmd.Parameters.AddWithValue("@EVAPFEEDCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EVAPFEEDCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EVAPFEEDCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@EVAPFEEDAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EVAPFEEDAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EVAPFEEDAC"].ToString();
                    cmd.Parameters.AddWithValue("@TESTTANKCS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TESTTANKCS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TESTTANKCS"].ToString();
                    cmd.Parameters.AddWithValue("@CEVAPDISCH", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CEVAPDISCH"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CEVAPDISCH"].ToString();
                    cmd.Parameters.AddWithValue("@ACEVAPDISCH", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACEVAPDISCH"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACEVAPDISCH"].ToString();
                    cmd.Parameters.AddWithValue("@CDIGDISCH", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CDIGDISCH"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CDIGDISCH"].ToString();
                    cmd.Parameters.AddWithValue("@ACDIGDISCH", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACDIGDISCH"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACDIGDISCH"].ToString();
                    cmd.Parameters.AddWithValue("@SETTLERFEEDCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SETTLERFEEDCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@SETTLERFEEDAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SETTLERFEEDAC"].ToString();

                    cmd.Parameters.AddWithValue("@WOFCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOFCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOFCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@WOFAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WOFAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WOFAC"].ToString();
                    cmd.Parameters.AddWithValue("@LTPCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LTPCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LTPCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@LTPAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LTPAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LTPAC"].ToString();
                    cmd.Parameters.AddWithValue("@LTPAIM", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LTPAIM"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LTPAIM"].ToString();
                    cmd.Parameters.AddWithValue("@PRESSFEEDCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRESSFEEDCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRESSFEEDCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@WUFSODA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["WUFSODA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["WUFSODA"].ToString();
                    cmd.Parameters.AddWithValue("@MTLSODA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["MTLSODA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["MTLSODA"].ToString();
                    /*************************/

                    cmd.Parameters.AddWithValue("@FT5AIM", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FT5AIM"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FT5AIM"].ToString();
                    cmd.Parameters.AddWithValue("@TRIDIGESTORAIM", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TRIDIGESTORAIM"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TRIDIGESTORAIM"].ToString();
                    cmd.Parameters.AddWithValue("@TRIDIGESTORCS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["TRIDIGESTORCS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["TRIDIGESTORCS"].ToString();
                    cmd.Parameters.AddWithValue("@FT5CS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["FT5CS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["FT5CS"].ToString();
                    cmd.Parameters.AddWithValue("@DIGDISCHCS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["DIGDISCHCS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["DIGDISCHCS"].ToString();
                    cmd.Parameters.AddWithValue("@SETTLERFEEDCS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDCS"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SETTLERFEEDCS"].ToString();
                    cmd.Parameters.AddWithValue("@SETTLERFEEDAIM", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDAIM"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SETTLERFEEDAIM"].ToString();
                    cmd.Parameters.AddWithValue("@PRESSFEEDAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRESSFEEDAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRESSFEEDAC"].ToString();
                    cmd.Parameters.AddWithValue("@A7OVERFLOWCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["A7OVERFLOWCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["A7OVERFLOWCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@A7OVERFLOWAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["A7OVERFLOWAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["A7OVERFLOWAC"].ToString();
                    cmd.Parameters.AddWithValue("@B7OVERFLOWCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["B7OVERFLOWCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["B7OVERFLOWCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@B7OVERFLOWAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["B7OVERFLOWAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["B7OVERFLOWAC"].ToString();
                    cmd.Parameters.AddWithValue("@CY15OVERFLOW", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CY15OVERFLOW"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CY15OVERFLOW"].ToString();
                    cmd.Parameters.AddWithValue("@ACY15OVERFLOW", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACY15OVERFLOW"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACY15OVERFLOW"].ToString();
                    cmd.Parameters.AddWithValue("@CY16OVERFLOW", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CY16OVERFLOW"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CY16OVERFLOW"].ToString();
                    cmd.Parameters.AddWithValue("@ACY16OVERFLOW", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACY16OVERFLOW"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACY16OVERFLOW"].ToString();
                    cmd.Parameters.AddWithValue("@SUFCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SUFCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SUFCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@SUFAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SUFAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SUFAC"].ToString();
                    cmd.Parameters.AddWithValue("@T1CAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T1CAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T1CAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@T1AC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T1AC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T1AC"].ToString();
                    cmd.Parameters.AddWithValue("@T3CAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T3CAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T3CAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@T3AC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T3AC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T3AC"].ToString();
                    cmd.Parameters.AddWithValue("@T7CAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T7CAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T7CAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@T7AC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["T7AC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["T7AC"].ToString();
                    cmd.Parameters.AddWithValue("@EVAPCCCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EVAPCCCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EVAPCCCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@EVAPCCAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["EVAPCCAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["EVAPCCAC"].ToString();
                    cmd.Parameters.AddWithValue("@PRESSCCCAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRESSCCCAUSTIC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRESSCCCAUSTIC"].ToString();
                    cmd.Parameters.AddWithValue("@PRESSCCAC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PRESSCCAC"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PRESSCCAC"].ToString();
                    cmd.Parameters.AddWithValue("@CAG1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CAG1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CAG1"].ToString();
                    cmd.Parameters.AddWithValue("@CAG3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CAG3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CAG3"].ToString();
                    cmd.Parameters.AddWithValue("@CAG7", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["CAG7"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["CAG7"].ToString();
                    cmd.Parameters.AddWithValue("@ACAG1", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACAG1"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACAG1"].ToString();
                    cmd.Parameters.AddWithValue("@ACAG3", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACAG3"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACAG3"].ToString();
                    cmd.Parameters.AddWithValue("@ACAG7", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["ACAG7"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["ACAG7"].ToString();
                    //cmd.Parameters.AddWithValue("@LKD4SODA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["LKD4SODA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["LKD4SODA"].ToString();

                    cmd.Parameters.AddWithValue("@SRTSODA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["SRTSODA"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["SRTSODA"].ToString();
                    cmd.Parameters.AddWithValue("@PFMG", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[0]["PFMG"].ToString()) ? (object)DBNull.Value : dt.Rows[0]["PFMG"].ToString();

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                List<decimal?> piTagValue = new List<decimal?>();
                
                    //list for Pi update
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["TESTTANKCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TESTTANKCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["TESTTANKAC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TESTTANKAC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["CTRIDIGESTOR"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CTRIDIGESTOR"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["ACTRIDIGESTOR"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["ACTRIDIGESTOR"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["CFT5"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CFT5"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["ACFT5"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["ACFT5"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["EVAPFEEDCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["EVAPFEEDCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["EVAPFEEDAC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["EVAPFEEDAC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["TESTTANKCS"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["TESTTANKCS"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["CEVAPDISCH"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CEVAPDISCH"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["ACEVAPDISCH"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["ACEVAPDISCH"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["CDIGDISCH"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["CDIGDISCH"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["ACDIGDISCH"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["ACDIGDISCH"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SETTLERFEEDCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["SETTLERFEEDAC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["SETTLERFEEDAC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["WOFCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WOFCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["WOFAC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WOFAC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["LTPCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["LTPCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["LTPAC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["LTPAC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["LTPAIM"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["LTPAIM"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["PRESSFEEDCAUSTIC"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["PRESSFEEDCAUSTIC"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["WUFSODA"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["WUFSODA"].ToString()));
                    piTagValue.Add(string.IsNullOrEmpty(dt.Rows[0]["MTLSODA"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["MTLSODA"].ToString()));

                if ((date < today) || (date == today && time <= DateTime.Now.Hour))
                
                {
                    PiInsert(piTagValue, datetime);
                }

                else
                {
                    String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strConnString);
                    for (int i = 0; i <= piTagValue.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("insert into LAB_TEMPTABLE (CCDATE, VALUE_, CCROUND, INDEX_) values " +
                            " ('" + date + "','" + piTagValue[i] + "','" + Session["ccround"].ToString().Substring(0, 2) + "','" + (i+1) + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            }
            catch (Exception e)
            {

            }
        }
        public void PiInsert(List<decimal?> piTagValues, DateTime _datetime )
        {
            //**********************Insert records into pi********************************************
            try
            {
                LabEntities db = new LabEntities();
                PIServers myPIServers = new PIServers();
                PIServer myPIServer = myPIServers.DefaultPIServer;
                NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
                myPIServer.Connect(credential);

                var PiTaglist = (from v in db.Lab_TagTable
                                 orderby v.Id
                                 select v).Take(23);
             
                int utc = DateTime.UtcNow.Hour;
                int dt_ = DateTime.Now.Hour;
                int diff;

                bool dst = DSTcheck();
                if (!dst)
                {
                    dt_ = dt_ + 1;
                }
           
                
                if (utc > dt_)
                    diff = utc - dt_;
                else
                    diff = utc + 24 - dt_;

                foreach (var item in PiTaglist)
                {

                    string TagName = item.Pi_Tags_Test;
                    //string TagName = item.TagName;

                    int _index = (item.Indx) - 1;
                    //int _index = (item.Id) - 1;

                    PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);
                    AFValue currentTag = myPIPoint.CurrentValue();

                    currentTag.Value = Convert.ToString(piTagValues[_index]);
                 
                    currentTag.Timestamp = _datetime.AddHours(diff);

                    //if (action == "add")
                    //{
                    if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                    {
                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                    }
                    //}
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
                myPIServer.Disconnect();
            }
            catch (Exception ex)
            {

            }
           
            //*************************End*******************************

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
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string message = ddlFruits.SelectedItem.Text + " - " + ddlFruits.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }
        protected void gv_ccontrol_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            string ccround;

            foreach (GridViewRow rw in gv_labticket3.Rows)
            {
                Label txt = (Label)rw.FindControl("gv_ccontrol_s");
                if (txt.Text == "Test Tank" || txt.Text == "Dig Disch" || txt.Text == "Settler Feed" || txt.Text == "" )
                {
                    //TextBox tbox = (TextBox)rw.FindControl("gv_ccontrol_aim");
                    //tbox.Visible= false;
                }
                if(txt.Text == "Press Feed" || txt.Text == "Evap Feed" || txt.Text == "Evap Disch" ||
                    txt.Text == "WOF" || txt.Text == "SUF Overflow" || txt.Text == "T1 Overflow" || txt.Text == "T3 Overflow" || txt.Text == "T7 Overflow" || txt.Text == "Evap C/C" ||
                      txt.Text == "AG1" || txt.Text == "AG4" || txt.Text == "AG7" || txt.Text == "Y15 Overflow" || txt.Text == "Y16 Overflow" ||
                        txt.Text == "A7 Overflow" || txt.Text == "B7 Overflow" || txt.Text == "Press C/C")
                {
                    //TextBox tbox = (TextBox)rw.FindControl("gv_ccontrol_aim");
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_ccontrol_cs");
                    //tbox.Visible = false;
                    tbox2.Visible = false;
                }
                if(txt.Text == "LTP")
                {
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_ccontrol_cs");
                    tbox2.Visible = false;
                }
                if(txt.Text == "Tri Digestor")
                {
                    //TextBox tboxaim = (TextBox)rw.FindControl("gv_ccontrol_aim");
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_ccontrol_cs");
                    if (tbox2.Text == "")
                    { //tboxaim.Text = ".76"; 
                    }

                }
                if (txt.Text == "No.5 Flash Tank")
                {
                    //TextBox tboxNo5 = (TextBox)rw.FindControl("gv_ccontrol_aim");
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_ccontrol_cs");
                    if (tbox2.Text == "")
                    { //tboxNo5.Text = ".69";
                    }
                        
                   
                }
                if (txt.Text == "LTP")
                {
                    //TextBox tboxLTP = (TextBox)rw.FindControl("gv_ccontrol_aim");
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_ccontrol_ac");
                    if (tbox2.Text == "")
                    {//tboxLTP.Text = "213"; 
                    }


                }
            }


            if (!string.IsNullOrEmpty(HttpContext.Current.Session["ccontrol_date"] as string))
            {


                if (HttpContext.Current.Session["ccround"].ToString() == "0300" || HttpContext.Current.Session["ccround"].ToString() == "0900")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "SUF Overflow" || txt.Text == "T1 Overflow" || txt.Text == "T7 Overflow" || txt.Text == "T3 Overflow" ||  txt.Text == "AG1" || txt.Text == "AG4" || txt.Text == "AG7")
                        { rw.Visible = false; }

                    }


                }
                else if (HttpContext.Current.Session["ccround"].ToString() == "0600")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "Y15 Overflow" || txt.Text == "Y16 Overflow" || txt.Text == "A7 Overflow" || txt.Text == "B7 Overflow" )
                            rw.Visible = false;

                    }
                }
                else if (HttpContext.Current.Session["ccround"].ToString() == "1200" || HttpContext.Current.Session["ccround"].ToString() == "2400")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "SUF Overflow" || txt.Text == "T1 Overflow" || txt.Text == "T7 Overflow" || txt.Text == "T3 Overflow" || txt.Text == "AG1" || txt.Text == "AG4" || txt.Text == "AG7"
                          ||  txt.Text == "Y15 Overflow" || txt.Text == "Y16 Overflow" || txt.Text == "A7 Overflow" || txt.Text == "B7 Overflow")
                            rw.Visible = false;

                    }
                }
                else if (HttpContext.Current.Session["ccround"].ToString() == "1500" )
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "SUF Overflow" || txt.Text == "T3 Overflow" 
                          || txt.Text == "Y15 Overflow" || txt.Text == "Y16 Overflow" || txt.Text == "A7 Overflow" || txt.Text == "B7 Overflow")
                            rw.Visible = false;

                    }
                    foreach (GridViewRow rw in gv_labticket4.Rows)
                    {
                        Label tx = (Label)rw.FindControl("gv_soda_s");
                        if (tx.Text == "Press Filtrate(MG/L)")
                        {
                            rw.Visible = false;

                        }
                    }
                }
                else if (HttpContext.Current.Session["ccround"].ToString() == "1800")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");
                        if (txt.Text == "T1 Overflow" || txt.Text == "T3 Overflow" || txt.Text == "T7 Overflow" || txt.Text == "AG1" || txt.Text == "AG4" || txt.Text == "AG7")
                            rw.Visible = false;

                    }
                }
                else if (HttpContext.Current.Session["ccround"].ToString() == "2100")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "SUF Overflow" || txt.Text == "T3 Overflow" || txt.Text == "AG4"
                          ||txt.Text == "Y15 Overflow" || txt.Text == "Y16 Overflow" || txt.Text == "A7 Overflow" || txt.Text == "B7 Overflow")
                            rw.Visible = false;

                    }
                    foreach (GridViewRow rw in gv_labticket4.Rows)
                    {
                        Label tx = (Label)rw.FindControl("gv_soda_s");
                        if (tx.Text == "Press Filtrate(MG/L)")
                        {
                            rw.Visible = false;

                        }
                    }
                }


            }
            else
            {
                HttpContext.Current.Session["ccround"] = "0300";
                if (HttpContext.Current.Session["ccround"].ToString() == "0300" || HttpContext.Current.Session["ccround"].ToString() == "0900")
                {

                    foreach (GridViewRow rw in gv_labticket3.Rows)
                    {
                        Label txt = (Label)rw.FindControl("gv_ccontrol_s");

                        if (txt.Text == "SUF Overflow" || txt.Text == "T1 Overflow" || txt.Text == "T7 Overflow" || txt.Text == "T3 Overflow"
                            || txt.Text == "AG1" || txt.Text == "AG4" || txt.Text == "AG7")
                            rw.Visible = false;

                    }
               
                }
            }

            //}
        }
        protected void gv_mhdliquor_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            string ccround;

            foreach (GridViewRow rw in gv_labticket2.Rows)
            {
                Label txt = (Label)rw.FindControl("gv_labticket_s");
                if (txt.Text == "MHD. Aim")
                {
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_labticket2_");
                    tbox2.Text = float.Parse(tbox2.Text).ToString("0.000");
                }
                if (txt.Text == "THD Aim")
                {
                    TextBox tbox2 = (TextBox)rw.FindControl("gv_labticket2_");
                    tbox2.Text = float.Parse(tbox2.Text).ToString("0.000");
                }

            }

            
        }
        protected void gv_soda_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

          
            string ccround;

            if (!string.IsNullOrEmpty(HttpContext.Current.Session["ccontrol_date"] as string))
            {
                if (HttpContext.Current.Session["ccround"].ToString() == "0300" || HttpContext.Current.Session["ccround"].ToString() == "0900")
                {

                    
                    foreach (GridViewRow rw in gv_labticket4.Rows)
                    {
                        Label tx = (Label)rw.FindControl("gv_soda_s");
                        if (tx.Text == "Press Filtrate(MG/L)")
                        {
                            rw.Visible = false;

                        }
                    }
                }
          
                else if (HttpContext.Current.Session["ccround"].ToString() == "1500")
                {

                    foreach (GridViewRow rw in gv_labticket4.Rows)
                    {
                        Label tx = (Label)rw.FindControl("gv_soda_s");
                        if (tx.Text == "Press Filtrate(MG/L)")
                        {
                            rw.Visible = false;

                        }
                    }
                }
        
                else if (HttpContext.Current.Session["ccround"].ToString() == "2100")
                {
                    foreach (GridViewRow rw in gv_labticket4.Rows)
                    {
                        Label tx = (Label)rw.FindControl("gv_soda_s");
                        if (tx.Text == "Press Filtrate(MG/L)")
                        {
                            rw.Visible = false;

                        }
                    }


                }


            }
            else
            {
              
                foreach (GridViewRow rw in gv_labticket4.Rows)
                {
                    Label tx = (Label)rw.FindControl("gv_soda_s");
                    if (tx.Text == "Press Filtrate(MG/L)")
                    {
                        rw.Visible = false;

                    }
                }
            }

        }
    }
    
}
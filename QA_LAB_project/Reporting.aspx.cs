using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Reporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string date;
            int report;
            HttpCookie _userRole = Request.Cookies["UserRole"];
            if (_userRole != null)
            {
                role.Value = _userRole["role"];
            }
            try
            {
                if (string.IsNullOrEmpty(HttpContext.Current.Session["report_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["report_date"] = date;
                    panelID.Value = "nothing";
                    report_date.Value = date;
                }
                else
                {
                    date = Session["report_date"].ToString();
                    report = ddlReport.SelectedIndex;
                    panelID.Value = report.ToString();
                    if (date.Length > 10)
                    {
                        report_date.Value = date.Substring(0, 10);
                    }
                    else
                        report_date.Value = date;
                }
                date_max.Value = date;
            }
            catch (Exception t)
            {
            }
        }
        protected void getAllReports(int reportnumber)
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                date = (Session["report_date"].ToString());
                date_max.Value = date;
                string month;
                string year;
                string reportDate;
                if (date.Contains("Z"))
                {
                    DateTime date_ = DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                    month = date_.Month.ToString();
                    year = date_.Year.ToString();
                    reportDate = String.Format("{0:MMMM}", date_) + " " + year;
                    //P3reportMonthYear.Value = reportDate;
                    //P4reportMonthYear.Value = reportDate;
                }
                else
                {
                    //input.Split('(', ')')[1]
                    month = date.Substring(0, date.IndexOf('/'));
                    int index = date.IndexOf('/', date.IndexOf('/') + 1);
                    year = date.Substring(index + 1, 4);
                    reportDate = month + "/" + year;
                    //P3reportMonthYear.Value = reportDate;
                    //P4reportMonthYear.Value = reportDate;
                }
                ////////////Report 99/////////
                //if (reportnumber == 15)
                {
                    query = " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5] " +
                     ",[ACFT5]  ,[FT5AIM],FT5CS, [CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC] " +
                     ",[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and (ccround = '0300' or ccround = '300') union all " +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     ",[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     ",[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and (ccround = '0600' or ccround = '600') union all" +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and (ccround = '0900' or ccround = '900') union all " +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and ccround = '1200' union all" +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     ",[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and ccround = '1500' union all" +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and ccround = '1800' union all" +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     " where ccdate = '" + date + "' and ccround = '2100' union all" +
                     " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                     " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                     " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                     "  where ccdate = '" + date + "' and ccround = '2400' union all" +
                     " select 'AVG', AVG([TESTTANKCS]) , AVG([TESTTANKCAUSTIC]),AVG([TESTTANKAC]),AVG([CTRIDIGESTOR]),AVG([ACTRIDIGESTOR]),AVG([TRIDIGESTORAIM]),AVG([CFT5])" +
                     " ,AVG([ACFT5])  ,AVG([FT5AIM]), AVG([FT5CS]), AVG([CDIGDISCH]) ,AVG([ACDIGDISCH]),AVG([SETTLERFEEDCAUSTIC]) ,AVG([SETTLERFEEDAC]) ,AVG([PRESSFEEDCAUSTIC]) ,AVG([PRESSFEEDAC])" +
                     " ,AVG([LTPCAUSTIC]) ,AVG([LTPAC]),AVG([LTPAIM]),AVG([EVAPFEEDCAUSTIC]) ,AVG([EVAPFEEDAC]) ,AVG([CEVAPDISCH]),AVG([ACEVAPDISCH]) ,AVG([WOFCAUSTIC]),AVG([WOFAC]) ,AVG([SUFCAUSTIC]),AVG([SUFAC])" +
                     " from[Lab].[dbo].[LAB_CHARGECONTROL] where ccdate = '" + date + "' ";
                    //precip yield
                    query += "select AVG(LTPCAUSTIC *(LTPAC - TESTTANKAC  )) as yield from LAB_CHARGECONTROL where CCDATE = '" + date + "' ";
                    //tt free caustic
                    query += "select AVG(TESTTANKCAUSTIC *(1-(106/102)*TESTTANKAC  )) as free_caus from LAB_CHARGECONTROL where CCDATE = '" + date + "'";

                    ////precip yield
                    //query += "select AVG(LTPCAUSTIC *(LTPAC - TESTTANKAC  )) as yield from LAB_CHARGECONTROL where CCDATE = '" + date + "' ";
                    ////tt free caustic
                    //query += "select AVG(TESTTANKCAUSTIC *(1-(106/102)*TESTTANKAC  )) as free_caus from LAB_CHARGECONTROL where CCDATE = '" + date + "'";

                    //cont precip north
                    query += "SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND='0300' or ccround = '300') UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600'  or ccround = '600') UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1500' UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2100' UNION ALL" +
                            " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL" +
                            " select 'AVG', AVG([t1c]) , AVG([t1ac]), AVG([t7c]) , AVG([t7ac]), AVG([a7c]) , AVG([a7ac]),AVG([b7c]) , AVG([b7ac]) FROM(SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0300' or ccround = '300') UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1200' UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1500' UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1800' UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2100' UNION ALL" +
                            " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                            " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2400') x ";
                    //cont prec south
                    query += " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND='0300' or ccround = '300') UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1500' UNION ALL" +
                           " SELECT  CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2100' UNION ALL" +
                           " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL" +
                           " select 'AVG', AVG([ag1c]) , AVG([ag1ac]), AVG([ag7c]) , AVG([ag7ac]), AVG([y15c]) , AVG([y15ac]),AVG([y16c]) , AVG([y16ac]) FROM(" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0300' or ccround = '300') UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0600' or ccround = '600' ) UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1200' UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1500' UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1800' UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2100' UNION ALL" +
                           " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                           " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2400' ) t ";
                    //pfmg
                    query += " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                           " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL " +
                           " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL " +
                           " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL " +
                           " SELECT 'AVG', AVG([pfmg])  FROM(select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' " +
                           " AND (CCROUND = '0600' or ccround = '600') union all " +
                           " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' union all " +
                           " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' union all " +
                           " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400')x ";
                    query += " select 'C' as [name], CRETTANK as [RETTANK], CPDS1 AS CPDS1, CPDS2 AS CPDS2, CPDS3 AS CPDS3, CPDS4 AS CPDS4 " +
                               " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL " +
                               " select 'A/C' as [name], ARETTANK as [RETTANK], APDS1 AS CPDS1, APDS2 AS CPDS2, APDS3 AS CPDS3, APDS4 AS CPDS4" +
                               " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL" +
                               " select '%Solids' as [name], SRETTANK as [RETTANK], SPDS1 AS CPDS1, SPDS2 AS CPDS2, SPDS3 AS CPDS3, SPDS4 AS CPDS4" +
                               " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL" +
                               " select 'Density' as [name], DRETTANK as [RETTANK], D1PDS AS CPDS1, D2PDS AS CPDS2, D3PDS AS CPDS3, D4PDS AS CPDS4" +
                               " from LAB_SEC1_DATA where sddate = '" + date + "' ";

                    query += " select '0300' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                             " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0300' union all " +
                             " select '0600' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                             " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0600' union all " +
                             " select '0900' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                             " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0900' union all " +
                             " select '1200' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                             " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1200' union all " +
                             " select '1500' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                             " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1500' union all " +
                             " select '1800' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                            " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1800' union all " +


                       " select '2100' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                   " from LAB_CHARGECONTROL where ccdate = '" + date + "' and ccround = '2100' union all " +

                   " select '2400' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                   " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '2400' union all " +

                   " select 'AVG', AVG([evapc]), AVG([evapac]), AVG([pressc]), AVG([pressac]) " +
                   " FROM(select EVAPCCCAUSTIC as [evapc], EVAPCCAC as [evapac], PRESSCCCAUSTIC as [pressc], PRESSCCAC as [pressac] " +
                   "  from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' )x ";

                    //sec ii process vars
                    query += " select CCROUND as [Time], LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0300' or ccround = '300') union all" +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0600' or ccround = '600') union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0900' or ccround = '900') union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1200' union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1500' union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1800' union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '2100' union all " +
                            " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '2400' union all " +
                            " select 'AVG' as [Time], AVG(LKD4SODA), AVG(WUFSODA), AVG(MTLSODA), AVG(SRTSODA) from LAB_CHARGECONTROL  where CCDATE = '" + date + "' ";
                    //hydrate dryer discharge
                    query += " select '0600' as [Time], HD0600LS as [L-SODA], HD0600RF AS [REFLECT] from LAB_KILN_DRYER  where KDDATE = '" + date + "'  union all" +
                                " select '1000' , HD1100LS , HD1100RF from LAB_KILN_DRYER where KDDATE = '" + date + "'  union all " +
                                " select '1800' , HD1800LS , HD1800RF from LAB_KILN_DRYER where KDDATE = '" + date + "'  union all " +
                                " select '2200', HD2200LS , HD2200RF as WUF from LAB_KILN_DRYER   where KDDATE = '" + date + "'  union all " +
                                " select 'AVG', AVG([L-SODA]) AS[L-SODA], AVG([Reflectance]) as [REFLECT] FROM(SELECT HD0600LS AS [L-SODA], HD0600RF AS 'Reflectance'" +
                                " from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                " SELECT HD1100LS AS [L-SODA], HD1100RF AS 'Reflectance' from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                " SELECT HD1800LS AS [L-SODA], HD1800RF from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                " SELECT HD2200LS AS [L-SODA], HD2200RF from LAB_KILN_DRYER  where KDDATE = '" + date + "' ) x ";
                    //sec 3 process vars
                    query += " select 'Primary Feed' as [-] , [PSMAPFNA] as [Na],[PSMAPFCA] as [Ca]  ,[PSMAPFZN] as [Zn], null as [CaO] FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                              " where kddate = '" + date + "'   union all select 'CPN' as [-], [CPNNA] ,[CPNCA] , [CPNZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                              " where kddate = '" + date + "'  union all select 'CPS' as [-], [CPSNA] ,[CPSCA] ,[CPSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                              " where kddate = '" + date + "'  union all select 'TT Seed' as [-], [PSMATTSNA] ,[PSMATTSCA] ,[PSMATTSZN], " +
                              " null FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  union all " +
                              " select 'ST Seed' as [-], [PSMASTSNA]  ,[PSMASTSCA] ,[PSMASTSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                              " where kddate = '" + date + "'  " +
                              " union all select '6FT' as [-], KFM0600_1, KFM0600_2, KFM0600_3, FT6 FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' ";
                    //kiln feed moisture
                    query += "select kfm as [1], kfm2 as [2], kfm3 as [3] from lab_kiln_dryer where kddate = '" + date + "' ";

                    //kiln feed leachable soda
                    query += " select '0600' as [Time], kfls0600_1 as [1], kfls0600_2 as [2], kfls0600_3 as [3] from lab_kiln_dryer " +
                        " where kddate = '" + date + "' union all " +
                        " select '1800' as [Time], kfls1800_1 as [1], kfls1800_2 as [2], kfls1800_3 as [3] from lab_kiln_dryer " +
                        " where kddate = '" + date + "' union all select 'AVG' as [AVG], AVG([kfls1]), AVG([kfls2]), AVG([kfls3]) from(" +
                        " select kfls0600_1 as [kfls1], kfls0600_2 as [kfls2], kfls0600_3 as [kfls3] from lab_kiln_dryer " +
                       " where kddate = '" + date + "' union all " +
                        " select kfls1800_1 as [kfls1], kfls1800_2 as [kfls2], kfls1800_3 as [kfls3] from lab_kiln_dryer " +
                        " where kddate = '" + date + "' )x ";

                    //kiln discharge
                    query += "  select '2400' as [Time], KDLOI2200_1 , KDLOI2200_2, KDLOI2200_3, KDCA2200_1, KDCA2200_2, KDCA2200_3 ," +
                             " KDNA2200_1, KDNA2200_2, KDNA2200_3, KDZN2200_1, KDZN2200_2, KDZN2200_3 from LAB_KILN_DRYER where kddate = '" + date + "'  union all " +
                              " select '0600' as [Time], KDLOI1000_1 , KDLOI1000_2 , KDLOI1000_3, KDCA1000_1, KDCA1000_2, KDCA1000_3 ," +
                             " KDNA1000_1, KDNA1000_2, KDNA1000_3, KDZN1000_1, KDZN1000_2, KDZN1000_3 from lab_kiln_dryer where kddate = '" + date + "' union all " +
                            " select 'AVG', AVG([loi1]), AVG([loi2]), AVG([loi3]), AVG([ca1]), AVG([ca2]), AVG([ca3]), " +
                            " AVG([na1]), AVG([na2]), AVG([na3]), AVG([zn1]), AVG([zn2]), AVG([zn3]) " +
                            " from(select KDLOI2200_1 as [loi1], KDLOI2200_2 as [loi2], KDLOI2200_3 as [loi3], KDCA2200_1 as [ca1], KDCA2200_2 as [ca2], KDCA2200_3 as [ca3], " +
                             " KDNA2200_1 as [na1], KDNA2200_2 as [na2], KDNA2200_3 as [na3], " +
                             " KDZN2200_1 as [zn1], KDZN2200_2 as [zn2], KDZN2200_3 as [zn3] from lab_kiln_dryer where kddate = '" + date + "' UNION ALL " +
                             " select KDLOI1000_1, KDLOI1000_2, KDLOI1000_3, KDCA1000_1, KDCA1000_2, KDCA1000_3, KDNA1000_1, KDNA1000_2, KDNA1000_3, " +
                            "  KDZN1000_1, KDZN1000_2, KDZN1000_3 from lab_kiln_dryer where kddate = '" + date + "') X ";

                    //mudd taa
                    query += " select td as [THA DIG], TAAA4FT, TAAASF, TAAASUF, TAAAWUF, TAAAMTL from LAB_SEC1_DATA where sddate = '" + date + "' ";
                    //%solids
                    query += " select SASUF, SAWUF, SAMTL from LAB_SEC1_DATA where sddate = '" + date + "' ";
                    //silica caustic
                    query += " select SCATESTTANK, SCA4FT, SCASETTLERFD, SCALTP   from LAB_ENVIRONMENTAL where EADATE = '" + date + "' ";
                    //soda oxalate solids
                    query += " select 'LTP' as [name], null as [Soda], null as [Oxalate], null as [Solids],   SALP as [Na2S], LTPCA as [Ca] from LAB_SEC1_DATA " +
                        " where sddate = '" + date + "' union all select 'B Filt Cyc' as [name], SABF, OABF, GPLSBF,  null, null from LAB_SEC1_DATA where " +
                        " sddate = '" + date + "' union all select 'Ox Settler' as [name], SAOXSET, OAOXSET, null, null, null from LAB_SEC1_DATA where " +
                        " sddate = '" + date + "' union all select 'Filter Aid' as [name], null, null, safa, null, null from LAB_SEC1_DATA where " +
                        " sddate = '" + date + "' union all select 'Lime' as [name], SALIMEREC, null, SALR, null, null from LAB_SEC1_DATA where " +
                        " sddate = '" + date + "' union all select 'Sulfide' as [name], null, null, null, sast, null  from LAB_SEC1_DATA where sddate = '" + date + "' ";
                    //washer profile
                    query += " select WP0 as [0], WP1 as [1], WP2 AS [2], WP3 AS [3], WP4 AS [4], WP5 AS [5], WP6 AS [6], WP7 AS [7], WP8 AS [8] from LAB_SEC1_DATA  WHERE sddate = '" + date + "' ";


                    //dryer feed moisture
                    query += " select hdfm0600 as [dfm]  from lab.dbo.LAB_KILN_DRYER where kddate = '" + date + "'";

                    //cont precip north
                    query += " select 'T1' AS [TK No], P100 AS [+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA  from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T1' union all " +
                                    " select 'T3',  P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T3' union all " +
                                    " select 'T7', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T7' union all " +
                                    " select 'A7 O''F' ,P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A7 O''F' union all " +
                                    " select 'B7 O''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B7 O''F'  union all " +
                                    " select 'A7 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A7 U''F'  union all " +
                                    " select 'B7 U''F' , P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B7 U''F' union all " +
                                    " select 'A6 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A6 U''F'  union all " +
                                    " select 'B6 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B6 U''F' ";
                    //cont precip south
                    query += " select 'AG1' AS [TK No], P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA  from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG1' union all " +
    " select 'AG3',  P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG3' union all " +
    " select 'AG7', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG7' union all " +
    " select 'Y15 O''F' ,P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y15 O''F' union all " +
    " select 'Y16 O''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y16 O''F'  union all " +
    " select 'Y15 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y15 U''F'  union all " +
    " select 'Y16 U''F' , P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y16 U''F'";
                    //st tops samples
                    query += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                        " and SECRECORD = 'PTS' UNION ALL SELECT 'AVG' AS[AVG], AVG(P100),  AVG(P200), AVG(P325), AVG(UM20), AVG(CAUS), AVG(AC), AVG(GPLSOL), AVG(SA) from LAB_SEC_III_DATA " +
                        " where SECDATE = '" + date + "' and SECRECORD = 'PTS' ";
                    //caus clean
                    query += " select CCTRUCK AS [Tank], CCCAUSTIC as C, CCAC as [A/C]  FROM LAB_CAUSTIC_CLEAN where CCDATE = '" + date + "' and cctruck != '' ";
                    //tt tops samples
                    query += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                        " and SECRECORD = 'TTS' UNION ALL SELECT 'AVG' AS[AVG], AVG(P100),  AVG(P200), AVG(P325), AVG(UM20), AVG(CAUS), AVG(AC), AVG(GPLSOL), AVG(SA) from LAB_SEC_III_DATA " +
                        " where SECDATE = '" + date + "' and SECRECORD = 'TTS' ";
                    //primary feed
                    query += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                        " and SECRECORD = 'FST' ";
                    //h20
                    query += " SELECT '0000' AS [TANK], H2ONORTH0000 AS [North], H2OSOUTH0000 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                            " SELECT '0600' AS[TANK], H2ONORTH0600 AS[North], H2OSOUTH0600 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                            " SELECT '1200' AS[TANK], H2ONORTH1200 AS[North], H2OSOUTH1200 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                            " SELECT '1800' AS[TANK], H2ONORTH1800 AS[North], H2OSOUTH1800 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                            " Select 'AVG', AVG([north]), AVG([south]) from(" +
                            " select H2ONORTH0000 as [north], H2OSOUTH0000 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                            " select H2ONORTH0600 as [north], H2OSOUTH0600 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                            " select H2ONORTH1200 as [north], H2OSOUTH1200 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                            " select H2ONORTH1800 as [north], H2OSOUTH1800 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' )x";
                    //% oxalate
                    query += " SELECT '1B Cake' as [name], OA1CAKE as [v] FROM LAB_SEC1_DATA  WHERE sddate = '" + date + "' union all SELECT '2B Cake', OA2CAKE FROM" +
                        " LAB_SEC1_DATA WHERE sddate = '" + date + "' union all SELECT 'ST Seed', OASTSEED FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' union all " +
                        " SELECT '6A/B', OA6AB FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' union all SELECT 'Y15/16', Y1516 FROM LAB_SEC1_DATA WHERE " +
                        " sddate = '" + date + "' union all SELECT 'PRIM FD', OAPF FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' ";
                    //tray o'f solids
                    query += " select GPLS1 as #1, GPLS2 as #2, GPLS3 as #3, GPLS4 as #4 from LAB_SEC1_DATA WHERE sddate = '" + date + "' ";

                    query += " select CONVERT(VARCHAR(10), eadate) as [Date], Round(FASETTLER, 2) as SETTLR, FAWASHER AS WASHR, FAMIDDLE as CYTEC, Round(s.SRPF, 2) as [Plant Floc], " +
                       " s.SRS as [Solids GPL],s.SRSTARCHI as [STRCH IND TIME], s.SRSTARCHS as [STRCH SET TIME],s.TRIDIGEST as [TRI DIG], s.FT5,e.SAHOTWELL as [Hot Well Ditch], " +
                       " e.SAPLANTDRAIN as [Plant Drain Ditch], e.SALIFTSTATION as [Lift STN North], e.SASURGEBASIN as [Surge Basin], e.P2O5CATESTTANK as [TT],e.P2O5CASETTLERFEED as SF," +
                       " e.ABSCATESTTANK as [ABSTT], ABSCALTP as LTP from LAB_ENVIRONMENTAL e join LAB_SEC1_DATA s on s.SDDATE = e.EADATE where Datepart(Month, eadate) = '" + month + "' " +
                       " and DATEPART(Year, eadate) = '" + year + "' UNION ALL select 'AVG', avg(x.fasettler), AVG(x.WASHR), AVG(x.CYTEC), AVG(Convert(decimal(6, 2), x.[Plant Floc]))," +
                       " avg(x.[Solids GPL]), avg(x.[STRCH IND TIME]), avg(x.[STRCH SET TIME]), avg(x.[TRI DIG]), AVG(x.FT5), avg(x.[Hot Well Ditch]), avg(x.[Plant Drain Ditch]) " +
                       " ,avg(x.[Lift STN North]), avg(x.[Surge Basin]), avg(x.TT), avg(x.SF), avg(x.ABSTT), avg(x.LTP) from ( select e.FASETTLER, FAWASHER AS WASHR,FAMIDDLE as CYTEC, " +
                       " Round(s.SRPF, 2) as [Plant Floc],s.SRS as [Solids GPL], s.SRSTARCHI as [STRCH IND TIME], s.SRSTARCHS as [STRCH SET TIME], s.TRIDIGEST as [TRI DIG], s.FT5, " +
                       " e.SAHOTWELL as [Hot Well Ditch], e.SAPLANTDRAIN as [Plant Drain Ditch], e.SALIFTSTATION as [Lift STN North], e.SASURGEBASIN as [Surge Basin], e.P2O5CATESTTANK " +
                       " as [TT], e.P2O5CASETTLERFEED as SF, e.ABSCATESTTANK as [ABSTT], ABSCALTP as LTP from LAB_ENVIRONMENTAL e join LAB_SEC1_DATA s on s.SDDATE = e.EADATE " +
                       " where Datepart(Month, eadate) = '" + month + "' and DATEPART(Year, eadate) = '" + year + "') x ORDER BY[Date] ";

                    query += " select  LEFT(CONVERT(VARCHAR, eadate, 120), 10) as [date],[RWRPH],[EDFLOW], [EDPH], [FEDFLOW],[FEDPH],[WDFLOW],[WDPH],[CDFLOW], " +
                              " [CDPH],[OXPOND], [SEWERPH1],[SEWERPH2],[SEWERPH3],[SEWERPH5], [DAMPH1] from LAB_ENVIRONMENTAL  where Datepart(Month, eadate) = '" + month + "' and " +
                              " DATEPART(Year, eadate) = '" + year + "' union all select 'AVG',AVG(rwrph),AVG(edflow), AVG(edph), AVG(fedflow),AVG(fedph),AVG(wdflow),AVG(wdph),AVG(cdflow)," +
                              " AVG(cdph),AVG(oxpond), AVG(sewerph1)  ,AVG(sewerph2) ,AVG(sewerph3),AVG(sewerph5), AVG(damph1) FROM( SELECT[RWRPH] as rwrph, [EDFLOW] as edflow, " +
                              " [EDPH] as edph, [FEDFLOW] as fedflow, [FEDPH] as fedph,[WDFLOW] as wdflow,[WDPH] as wdph,[CDFLOW] as cdflow, [CDPH] as cdph,[OXPOND] as oxpond, " +
                              " [SEWERPH1] as sewerph1,[SEWERPH2] as sewerph2,[SEWERPH3] as sewerph3,[SEWERPH5] as sewerph5, [DAMPH1] as damph1 FROM  LAB_ENVIRONMENTAL where " +
                              " Datepart(Month, eadate) = '" + month + "' and DATEPART(Year, eadate) = '" + year + "' ) x ORDER BY [date]  ";

                    //page5
                    DataTable dt = new DataTable();
                    dt = AluminaShipment(month, year, "ALUMINA");
                    gv_page5.DataSource = dt;
                    gv_page5.DataBind();
                    //query = "";

                    //page6
                    DataTable dt2 = new DataTable();
                    dt2 = AluminaShipment(month, year, "HYDRATE");
                    gv_page6.DataSource = dt2;
                    gv_page6.DataBind();
                    //query = "";

                    //page7
                    DataTable dt3 = new DataTable();
                    dt3 = AluminaShipment(month, year, "WETHYDRATE");
                    gv_page7.DataSource = dt3;
                    gv_page7.DataBind();
                    //query = "";

                    //page9
                    DataTable dt4 = new DataTable();
                    dt4 = HydrateAnalysis(Convert.ToDateTime(date), "WETCAKE");
                    gv_page9_a.DataSource = dt4;
                    gv_page9_a.DataBind();

                    DataTable dt5 = new DataTable();
                    dt5 = HydrateAnalysis(Convert.ToDateTime(date), "DRY");
                    gv_page9_b.DataSource = dt5;
                    gv_page9_b.DataBind();

                    //h30
                    query += " select '% SiO₂' as [name], (Si * 1.40) as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                          " select '% Fe₂O₃' as [name], (FE * 0.935) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                          " select '% Na₂O' as [name], round((Na * 0.881),2) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                          " select '% CaO' as [name], (Ca * .9) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                          " select '% Free Moisture' as [name], FREEMOIST from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                          " select 'Bulk Density' as [name], BULKDENS from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' ";

                    query += " select '% Caustic Sedimentation' as [name], cseds as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select '% Acid Insolubles' as [name], INSOLS from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select '% Retained on 100 Mesh',  p100 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select '% Retained on 200 Mesh',  p200 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select '% Retained on 325 Mesh',  p325 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select 'Hunter L Value',  HUNTERL from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select 'Hunter a Value',  HUNTERA from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                            " select 'Hunter b Value',  HUNTERB from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'HYDRATE' ";

                    query += " select CONTAINERID AS [name], REFLECTANCE as reflectance, LEACHSODA as lsoda FROM[Lab].[dbo].[LAB_HYDRATE_ANALYSIS] " +
                               " where HA_TYPE = 'DRY' AND SADATE = '" + date + "'  and containerid is not null ";

                    //wh30
                    query += " select '% SiO₂' as [name], (Si * 1.40) as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                           " select '% Fe₂O₃' as [name], (FE * 0.935) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                           " select '% Na₂O' as [name], (Na * 0.881) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                           " select '% CaO' as [name], (Ca * .9) from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'WETHYDRATE'  ";

                    query += " select '% Caustic Sedimentation' as [name], cseds as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                                " select '% Acid Insolubles' as [name], INSOLS from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'wethydrate' UNION ALL " +
                                " select '% Retained on 100 Mesh',  p100 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                                " select '% Retained on 200 Mesh',  p200 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                                " select '% Retained on 325 Mesh',  p325 from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'WETHYDRATE' ";

                    query += " select CONTAINERID AS [name], REFLECTANCE as reflectance, LEACHSODA as lsoda, Moisture as  psolid FROM[Lab].[dbo].[LAB_HYDRATE_ANALYSIS] " +
                             " where HA_TYPE = 'WET' AND SADATE = '" + date + "'  and containerid is not null ";
                    //c70
                    query += " select 'SiO₂' as [name], '%' as [label], '-.021' as [specs], si * (2.14) as [analysis] from LAB_DAILYANALYSIS where DADATE = '" + date + "'" +
                             " and PRODUCT = 'ALUMINA' UNION ALL " +
                             " select 'Fe₂O₃', '%', '-.016', FE * (1.4297) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL " +
                            " select 'Na₂O', '%', '-.674', NA * (1.348) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'MnO', '%', '-.0026', Mn * (1.2912) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'ZnO', '%', '-.019', Zn * (1.2447) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'CaO', '%', '-.063', Ca * (1.3995) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'Bulk Density', 'Lbs/Cu ft.', '-', BULKDENS FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'Loss on Ignition', '%Max', '-1', LOI FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '100 Mesh', '% Retained', '-10', P100 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "'and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '200 Mesh', '% Retained', '-', P200 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '325 Mesh', '% Retained', '90-', P325 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA'  ";
                    //misc
                    query += "SELECT [MMISCDESCR],[MMISCQTY],[MMISCSIZE] FROM[Lab].[dbo].[LAB_MISC] where mmiscdescr is not null and  mmiscdate = '" + date + "' ";

                    using (SqlConnection con = new SqlConnection(strConnString))
                    {
                        SqlCommand cmd = new SqlCommand(query);
                        SqlDataAdapter sda = new SqlDataAdapter();
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);

                  
                            gv_report1a.DataSource = ds.Tables[0];
                            gv_report1a.DataBind();

                               gv_report1a_.DataSource = ds.Tables[0];
                             gv_report1a_.DataBind();
                        string yield = ds.Tables[1].Rows[0]["yield"].ToString().Substring(0, 5);
                            string free_caus = ds.Tables[2].Rows[0]["free_caus"].ToString().Substring(0, 5);

                            precip_yield.Value = yield;
                            free_c.Value = free_caus;
                        
                        //else if (report == 2)
                        //{
                            gv_cpn.DataSource = ds.Tables[3];
                            gv_cpn.DataBind();

                            gv_cps.DataSource = ds.Tables[4];
                            gv_cps.DataBind();

                            gv_pfmg.DataSource = ds.Tables[5];
                            gv_pfmg.DataBind();

                            gv_smix.DataSource = ds.Tables[6];
                            gv_smix.DataBind();

                            gv_evapcc.DataSource = ds.Tables[7];
                            gv_evapcc.DataBind();

                        //}

                        //else if (report == 3)
                        //{
                            gv_sec2pv.DataSource = ds.Tables[8];
                            gv_sec2pv.DataBind();

                            gv_hydratedryer.DataSource = ds.Tables[9];
                            gv_hydratedryer.DataBind();

                            gv_sec3pv.DataSource = ds.Tables[10];
                            gv_sec3pv.DataBind();

                            gv_kfm.DataSource = ds.Tables[11];
                            gv_kfm.DataBind();

                            gv_lsoda.DataSource = ds.Tables[12];
                            gv_lsoda.DataBind();

                            gv_kdischarge.DataSource = ds.Tables[13];
                            gv_kdischarge.DataBind();


                            gv_mudd.DataSource = ds.Tables[14];
                            gv_mudd.DataBind();


                            gv_psolids.DataSource = ds.Tables[15];
                            gv_psolids.DataBind();


                            gv_scaustic.DataSource = ds.Tables[16];
                            gv_scaustic.DataBind();


                            gv_soxalate.DataSource = ds.Tables[17];
                            gv_soxalate.DataBind();


                            gv_wprofile.DataSource = ds.Tables[18];
                            gv_wprofile.DataBind();

                            gv_dryerfm.DataSource = ds.Tables[19];
                            gv_dryerfm.DataBind();



                        //}
                        //else if (report == 4)
                        //{
                            gv_precnorth.DataSource = ds.Tables[20];
                            gv_precnorth.DataBind();

                            gv_precsouth.DataSource = ds.Tables[21];
                            gv_precsouth.DataBind();

                            gv_sttops.DataSource = ds.Tables[22];
                            gv_sttops.DataBind();

                            gv_cclean.DataSource = ds.Tables[23];
                            gv_cclean.DataBind();

                            gv_tttops.DataSource = ds.Tables[24];
                            gv_tttops.DataBind();

                            gv_pfeed.DataSource = ds.Tables[25];
                            gv_pfeed.DataBind();

                            gv_water.DataSource = ds.Tables[26];
                            gv_water.DataBind();

                            gv_poxalate.DataSource = ds.Tables[27];
                            gv_poxalate.DataBind();

                            gv_trayo.DataSource = ds.Tables[28];
                            gv_trayo.DataBind();


                        //}
                        //else if (report == 5)
                        //{
                            gv_page3report.DataSource = ds.Tables[29];
                            gv_page3report.DataBind();
                        //}
                        //else if (report == 6)
                        //{
                            gv_page4report.DataSource = ds.Tables[30];
                            gv_page4report.DataBind();

                        gv_misc.DataSource = ds.Tables[38];
                        gv_misc.DataBind();
                        //}

                        //else if (report == 11)
                        //{
                        //    DataTable dt1 = new DataTable();
                        //    DataTable dt2 = new DataTable();
                        //    DataTable dt3 = new DataTable();
                        //    dt1 = ds.Tables[0];
                        //    dt2 = ds.Tables[1];
                        //    dt3 = ds.Tables[2];
                        //    //Store dt in Viewstate
                        //    Session["h30tbl_1"] = dt1;
                        //    Session["h30tbl_2"] = dt2;
                        //    Session["h30tbl_3"] = dt3;

                        //    Response.Redirect("H30.aspx");
                        //}
                        //else if (report == 12)
                        //{
                        //    DataTable dt1 = new DataTable();
                        //    DataTable dt2 = new DataTable();
                        //    DataTable dt3 = new DataTable();
                        //    dt1 = ds.Tables[0];
                        //    dt2 = ds.Tables[1];
                        //    dt3 = ds.Tables[2];
                        //    //Store dt in Viewstate
                        //    Session["wh30tbl_1"] = dt1;
                        //    Session["wh30tbl_2"] = dt2;
                        //    Session["wh30tbl_3"] = dt3;

                        //    Response.Redirect("WH30.aspx");

                        //}

                        //else if (report == 13)
                        //{
                        //    DataTable dt = new DataTable();
                        //    // Fill dt
                        //    dt = ds.Tables[0];
                        //    //Store dt in Viewstate
                        //    Session["c70tbl"] = dt;

                        //    Response.Redirect("Report_C70.aspx");
                        //}
                        //else if (report == 14)
                        //{
                        //    DataTable dt = new DataTable();
                        //    // Fill dt
                        //    dt = ds.Tables[0];
                        //    //Store dt in Viewstate
                        //    Session["Misctbl"] = dt;

                        //    Response.Redirect("MiscReport.aspx");

                        //}

                        //else
                        //    query = "";

                    }
                    //////////////////////////////
                }
            }
            catch
            {

            }
        }
        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                string date;
                int report = ddlReport.SelectedIndex;
                //if (string.IsNullOrEmpty(HttpContext.Current.Session["report_date"] as string))
                //{
                //    date = DateTime.Today.ToShortDateString();
                //    Session["report_date"] = date;
                //}
                //else
                //{
                    date = (Session["report_date"].ToString());
                //}
                date_max.Value = date;
                string month;
                string year;
                string reportDate;
                if (date.Contains("Z"))
                {
                    DateTime date_ = DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                    month = date_.Month.ToString();
                    year = date_.Year.ToString();
                    reportDate = String.Format("{0:MMMM}", date_) + " " + year;
                    //P3reportMonthYear.Value = reportDate;
                    //P4reportMonthYear.Value = reportDate;
                }
                else
                {
                    //input.Split('(', ')')[1]
                    month = date.Substring(0,date.IndexOf('/'));
                    int index = date.IndexOf('/', date.IndexOf('/') + 1);
                    year = date.Substring(index+1, 4);
                    reportDate = month + "/" + year;
                    //P3reportMonthYear.Value = reportDate;
                    //P4reportMonthYear.Value = reportDate;
                }

                if (report == 15)
                {
                    getAllReports(15);
                }
                else if (report == 16)
                {

                    DataSet dataset = new DataSet();
                    dataset = ProductionDay(Convert.ToDateTime(date));
                    Session["ProductionDay"] = dataset;
                    Response.Redirect("ProductionDay.aspx");
                    query = "";

                }
                else
                {
                    //1a
                    if (report == 1)
                    {
                        string query1 = " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5] " +
                                ",[ACFT5]  ,[FT5AIM],FT5CS, [CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC] " +
                                ",[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and (ccround = '0300' or ccround = '300') union all " +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                ",[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                ",[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and (ccround = '0600' or ccround = '600') union all" +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and (ccround = '0900' or ccround = '900') union all " +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and ccround = '1200' union all" +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                ",[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and ccround = '1500' union all" +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and ccround = '1800' union all" +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                " where ccdate = '" + date + "' and ccround = '2100' union all" +
                                " SELECT[CCROUND] ,[TESTTANKCS],[TESTTANKCAUSTIC],[TESTTANKAC],[CTRIDIGESTOR],[ACTRIDIGESTOR],[TRIDIGESTORAIM],[CFT5]" +
                                " ,[ACFT5]  ,[FT5AIM],FT5CS,[CDIGDISCH] ,[ACDIGDISCH],[SETTLERFEEDCAUSTIC] ,[SETTLERFEEDAC] ,[PRESSFEEDCAUSTIC] ,[PRESSFEEDAC]" +
                                " ,[LTPCAUSTIC] ,[LTPAC],[LTPAIM],[EVAPFEEDCAUSTIC] ,[EVAPFEEDAC] ,[CEVAPDISCH],[ACEVAPDISCH] ,[WOFCAUSTIC],[WOFAC] ,[SUFCAUSTIC],[SUFAC] FROM[Lab].[dbo].[LAB_CHARGECONTROL]" +
                                "  where ccdate = '" + date + "' and ccround = '2400' union all" +
                                " select 'AVG', AVG([TESTTANKCS]) , AVG([TESTTANKCAUSTIC]),AVG([TESTTANKAC]),AVG([CTRIDIGESTOR]),AVG([ACTRIDIGESTOR]),AVG([TRIDIGESTORAIM]),AVG([CFT5])" +
                                " ,AVG([ACFT5])  ,AVG([FT5AIM]), AVG([FT5CS]), AVG([CDIGDISCH]) ,AVG([ACDIGDISCH]),AVG([SETTLERFEEDCAUSTIC]) ,AVG([SETTLERFEEDAC]) ,AVG([PRESSFEEDCAUSTIC]) ,AVG([PRESSFEEDAC])" +
                                " ,AVG([LTPCAUSTIC]) ,AVG([LTPAC]),AVG([LTPAIM]),AVG([EVAPFEEDCAUSTIC]) ,AVG([EVAPFEEDAC]) ,AVG([CEVAPDISCH]),AVG([ACEVAPDISCH]) ,AVG([WOFCAUSTIC]),AVG([WOFAC]) ,AVG([SUFCAUSTIC]),AVG([SUFAC])" +
                                " from[Lab].[dbo].[LAB_CHARGECONTROL] where ccdate = '" + date + "' ";
                        //precip yield
                        query1 += "select AVG(LTPCAUSTIC *(LTPAC - TESTTANKAC  )) as yield from LAB_CHARGECONTROL where CCDATE = '" + date + "' ";
                        //tt free caustic
                        query1 += "select AVG(TESTTANKCAUSTIC *(1-(106/102)*TESTTANKAC  )) as free_caus from LAB_CHARGECONTROL where CCDATE = '" + date + "'";
                        query = query1;
                    }
                    //1b
                    else if (report == 2)
                    {
                        //cont precip north
                        string query2 = "SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND='0300' or ccround = '300') UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600'  or ccround = '600') UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1500' UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2100' UNION ALL" +
                                " SELECT CCROUND, T1CAUSTIC, T1AC, T7CAUSTIC, T7AC, A7OVERFLOWCAUSTIC, A7OVERFLOWAC, B7OVERFLOWCAUSTIC, B7OVERFLOWAC FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL" +
                                " select 'AVG', AVG([t1c]) , AVG([t1ac]), AVG([t7c]) , AVG([t7ac]), AVG([a7c]) , AVG([a7ac]),AVG([b7c]) , AVG([b7ac]) FROM(SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0300' or ccround = '300') UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1200' UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1500' UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1800' UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2100' UNION ALL" +
                                " SELECT T1CAUSTIC AS 't1c', T1AC AS 't1ac', T7CAUSTIC as 't7c', T7AC as 't7ac', A7OVERFLOWCAUSTIC as 'a7c', A7OVERFLOWAC as 'a7ac', " +
                                " B7OVERFLOWCAUSTIC as 'b7c', B7OVERFLOWAC as 'b7ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2400') x ";
                        //cont prec south
                        query2 += " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND='0300' or ccround = '300') UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1500' UNION ALL" +
                                " SELECT  CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2100' UNION ALL" +
                                " SELECT CCROUND, CAG1, ACAG1, CAG7, ACAG7, CY15OVERFLOW, ACY15OVERFLOW, CY16OVERFLOW, ACY16OVERFLOW  FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL" +
                                " select 'AVG', AVG([ag1c]) , AVG([ag1ac]), AVG([ag7c]) , AVG([ag7ac]), AVG([y15c]) , AVG([y15ac]),AVG([y16c]) , AVG([y16ac]) FROM(" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0300' or ccround = '300') UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0600' or ccround = '600' ) UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND (CCROUND = '0900' or ccround = '900') UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1200' UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1500' UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '1800' UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2100' UNION ALL" +
                                " SELECT CAG1 AS 'ag1c', ACAG1 AS 'ag1ac', CAG7 as 'ag7c', ACAG7 as 'ag7ac', CY15OVERFLOW as 'y15c', ACY15OVERFLOW as 'y15ac', " +
                                " CY16OVERFLOW as 'y16c', ACY16OVERFLOW as 'y16ac' FROM  LAB_CHARGECONTROL WHERE CCDATE = '" + date + "'  AND CCROUND = '2400' ) t ";
                        //pfmg
                        query2 += " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND (CCROUND = '0600' or ccround = '600') UNION ALL" +
                                " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' UNION ALL " +
                                " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' UNION ALL " +
                                " select CCROUND, PFMG FROM LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400' UNION ALL " +
                                " SELECT 'AVG', AVG([pfmg])  FROM(select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' " +
                                " AND (CCROUND = '0600' or ccround = '600') union all " +
                                " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1200' union all " +
                                " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '1800' union all " +
                                " select PFMG as 'pfmg' from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' AND CCROUND = '2400')x ";
                        query2 += " select 'C' as [name], CRETTANK as [RETTANK], CPDS1 AS CPDS1, CPDS2 AS CPDS2, CPDS3 AS CPDS3, CPDS4 AS CPDS4 " +
                                    " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL " +
                                    " select 'A/C' as [name], ARETTANK as [RETTANK], APDS1 AS CPDS1, APDS2 AS CPDS2, APDS3 AS CPDS3, APDS4 AS CPDS4" +
                                    " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL" +
                                    " select '%Solids' as [name], SRETTANK as [RETTANK], SPDS1 AS CPDS1, SPDS2 AS CPDS2, SPDS3 AS CPDS3, SPDS4 AS CPDS4" +
                                    " from LAB_SEC1_DATA where sddate = '" + date + "' UNION ALL" +
                                    " select 'Density' as [name], DRETTANK as [RETTANK], D1PDS AS CPDS1, D2PDS AS CPDS2, D3PDS AS CPDS3, D4PDS AS CPDS4" +
                                    " from LAB_SEC1_DATA where sddate = '" + date + "' ";

                        query2 += " select '0300' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0300' union all " +

                             " select '0600' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0600' union all " +

                             " select '0900' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '0900' union all " +

                             " select '1200' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1200' union all " +

                             " select '1500' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1500' union all " +

                             " select '1800' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1800' union all " +


                            " select '2100' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and ccround = '2100' union all " +

                        " select '2400' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '2400' union all " +

                        " select 'AVG', AVG([evapc]), AVG([evapac]), AVG([pressc]), AVG([pressac]) " +
                        " FROM(select EVAPCCCAUSTIC as [evapc], EVAPCCAC as [evapac], PRESSCCCAUSTIC as [pressc], PRESSCCAC as [pressac] " +
                        "  from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' )x ";
                        //query2 += " select '0600' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        //        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and (CCROUND = '0600' or ccround = '600') union all " +
                        //        " select '1800' as [name], EVAPCCCAUSTIC as EvapC, EVAPCCAC as EvapAC, PRESSCCCAUSTIC as PressC, PRESSCCAC as PressAC " +
                        //        " from LAB_CHARGECONTROL where ccdate = '" + date + "' and CCROUND = '1800' union all " +
                        //        " select 'AVG', AVG([evapc]), AVG([evapac]), AVG([pressc]), AVG([pressac]) " +
                        //        " FROM(select EVAPCCCAUSTIC as [evapc], EVAPCCAC as [evapac], PRESSCCCAUSTIC as [pressc], PRESSCCAC as [pressac] " +
                        //        "  from LAB_CHARGECONTROL WHERE CCDATE = '" + date + "' )x ";
                        query = query2;
                    }
                    //2a
                    else if (report == 3)
                    {
                        //sec ii process vars
                        string query3 = " select CCROUND as [Time], LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0300' or ccround = '300') union all" +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0600' or ccround = '600') union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and (ccround = '0900' or ccround = '900') union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1200' union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1500' union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '1800' union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '2100' union all " +
                                " select CCROUND , LKD4SODA as OXSET, WUFSODA as WUF, MTLSODA as MTL, SRTSODA as SRT from LAB_CHARGECONTROL  where CCDATE = '" + date + "' and ccround = '2400' union all " +
                                " select 'AVG' as [Time], AVG(LKD4SODA), AVG(WUFSODA), AVG(MTLSODA), AVG(SRTSODA) from LAB_CHARGECONTROL  where CCDATE = '" + date + "' ";
                        //hydrate dryer discharge
                        query3 += " select '0600' as [Time], HD0600LS as [L-SODA], HD0600RF AS [REFLECT] from LAB_KILN_DRYER  where KDDATE = '" + date + "'  union all" +
                                    " select '1000' , HD1100LS , HD1100RF from LAB_KILN_DRYER where KDDATE = '" + date + "'  union all " +
                                    " select '1800' , HD1800LS , HD1800RF from LAB_KILN_DRYER where KDDATE = '" + date + "'  union all " +
                                    " select '2200', HD2200LS , HD2200RF as WUF from LAB_KILN_DRYER   where KDDATE = '" + date + "'  union all " +
                                    " select 'AVG', AVG([L-SODA]) AS[L-SODA], AVG([Reflectance]) as [REFLECT] FROM(SELECT HD0600LS AS [L-SODA], HD0600RF AS 'Reflectance'" +
                                    " from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                    " SELECT HD1100LS AS [L-SODA], HD1100RF AS 'Reflectance' from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                    " SELECT HD1800LS AS [L-SODA], HD1800RF from LAB_KILN_DRYER  where KDDATE = '" + date + "' UNION ALL" +
                                    " SELECT HD2200LS AS [L-SODA], HD2200RF from LAB_KILN_DRYER  where KDDATE = '" + date + "' ) x ";
                        //sec 3 process vars
                        query3 += " select 'Primary Feed' as [-] , [PSMAPFNA] as [Na],[PSMAPFCA] as [Ca]  ,[PSMAPFZN] as [Zn], null as [CaO] FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                                  " where kddate = '" + date + "'   union all select 'CPN' as [-], [CPNNA] ,[CPNCA] , [CPNZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                                  " where kddate = '" + date + "'  union all select 'CPS' as [-], [CPSNA] ,[CPSCA] ,[CPSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                                  " where kddate = '" + date + "'  union all select 'TT Seed' as [-], [PSMATTSNA] ,[PSMATTSCA] ,[PSMATTSZN], " +
                                  " null FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  union all " +
                                  " select 'ST Seed' as [-], [PSMASTSNA]  ,[PSMASTSCA] ,[PSMASTSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
                                  " where kddate = '" + date + "'  " +
                                  " union all select '6FT' as [-], KFM0600_1, KFM0600_2, KFM0600_3, FT6 FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' ";
                        //kiln feed moisture
                        query3 += "select kfm as [1], kfm2 as [2], kfm3 as [3] from lab_kiln_dryer where kddate = '" + date + "' ";

                        //kiln feed leachable soda
                        query3 += " select '0600' as [Time], kfls0600_1 as [1], kfls0600_2 as [2], kfls0600_3 as [3] from lab_kiln_dryer " +
                            " where kddate = '" + date + "' union all " +
                            " select '1800' as [Time], kfls1800_1 as [1], kfls1800_2 as [2], kfls1800_3 as [3] from lab_kiln_dryer " +
                            " where kddate = '" + date + "' union all select 'AVG' as [AVG], AVG([kfls1]), AVG([kfls2]), AVG([kfls3]) from(" +
                            " select kfls0600_1 as [kfls1], kfls0600_2 as [kfls2], kfls0600_3 as [kfls3] from lab_kiln_dryer " +
                           " where kddate = '" + date + "' union all " +
                            " select kfls1800_1 as [kfls1], kfls1800_2 as [kfls2], kfls1800_3 as [kfls3] from lab_kiln_dryer " +
                            " where kddate = '" + date + "' )x ";
                        //kiln discharge
                        query3 += "  select '2400' as [Time], KDLOI2200_1 , KDLOI2200_2, KDLOI2200_3, KDCA2200_1, KDCA2200_2, KDCA2200_3 ," +
     " KDNA2200_1, KDNA2200_2, KDNA2200_3, KDZN2200_1, KDZN2200_2, KDZN2200_3 from LAB_KILN_DRYER where kddate = '" + date + "'  union all " +
      " select '0600' as [Time], KDLOI1000_1 , KDLOI1000_2 , KDLOI1000_3, KDCA1000_1, KDCA1000_2, KDCA1000_3 ," +
     " KDNA1000_1, KDNA1000_2, KDNA1000_3, KDZN1000_1, KDZN1000_2, KDZN1000_3 from lab_kiln_dryer where kddate = '" + date + "' union all " +
    " select 'AVG', AVG([loi1]), AVG([loi2]), AVG([loi3]), AVG([ca1]), AVG([ca2]), AVG([ca3]), " +
    " AVG([na1]), AVG([na2]), AVG([na3]), AVG([zn1]), AVG([zn2]), AVG([zn3]) " +
    " from(select KDLOI2200_1 as [loi1], KDLOI2200_2 as [loi2], KDLOI2200_3 as [loi3], KDCA2200_1 as [ca1], KDCA2200_2 as [ca2], KDCA2200_3 as [ca3], " +
     " KDNA2200_1 as [na1], KDNA2200_2 as [na2], KDNA2200_3 as [na3], " +
     " KDZN2200_1 as [zn1], KDZN2200_2 as [zn2], KDZN2200_3 as [zn3] from lab_kiln_dryer where kddate = '" + date + "' UNION ALL " +
     " select KDLOI1000_1, KDLOI1000_2, KDLOI1000_3, KDCA1000_1, KDCA1000_2, KDCA1000_3, KDNA1000_1, KDNA1000_2, KDNA1000_3, " +
    "  KDZN1000_1, KDZN1000_2, KDZN1000_3 from lab_kiln_dryer where kddate = '" + date + "') X ";

                        //mudd taa
                        query3 += " select td as [THA DIG], TAAA4FT, TAAASF, TAAASUF, TAAAWUF, TAAAMTL from LAB_SEC1_DATA where sddate = '" + date + "' ";
                        //%solids
                        query3 += " select SASUF, SAWUF, SAMTL from LAB_SEC1_DATA where sddate = '" + date + "' ";
                        //silica caustic
                        query3 += " select SCATESTTANK, SCA4FT, SCASETTLERFD, SCALTP   from LAB_ENVIRONMENTAL where EADATE = '" + date + "' ";
                        //soda oxalate solids
                        query3 += " select 'LTP' as [name], null as [Soda], null as [Oxalate], null as [Solids],   SALP as [Na2S], LTPCA as [Ca] from LAB_SEC1_DATA " +
                            " where sddate = '" + date + "' union all select 'B Filt Cyc' as [name], SABF, OABF, GPLSBF,  null, null from LAB_SEC1_DATA where " +
                            " sddate = '" + date + "' union all select 'Ox Settler' as [name], SAOXSET, OAOXSET, null, null, null from LAB_SEC1_DATA where " +
                            " sddate = '" + date + "' union all select 'Filter Aid' as [name], null, null, safa, null, null from LAB_SEC1_DATA where " +
                            " sddate = '" + date + "' union all select 'Lime' as [name], SALIMEREC, null, SALR, null, null from LAB_SEC1_DATA where " +
                            " sddate = '" + date + "' union all select 'Sulfide' as [name], null, null, null, sast, null  from LAB_SEC1_DATA where sddate = '" + date + "' ";
                        //washer profile
                        query3 += " select WP0 as [0], WP1 as [1], WP2 AS [2], WP3 AS [3], WP4 AS [4], WP5 AS [5], WP6 AS [6], WP7 AS [7], WP8 AS [8] from LAB_SEC1_DATA  WHERE sddate = '" + date + "' ";
                        query = query3;

                        //dryer feed moisture
                        query3 += " select hdfm0600 as [dfm]  from lab.dbo.LAB_KILN_DRYER where kddate = '" + date + "'";
                        query = query3;
                    }
                    //2b
                    else if (report == 4)
                    {
                        //cont precip north
                        string query4 = " select 'T1' AS [TK No], P100 AS [+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA  from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T1' union all " +
    " select 'T3',  P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T3' union all " +
    " select 'T7', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'T7' union all " +
    " select 'A7 O''F' ,P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A7 O''F' union all " +
    " select 'B7 O''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B7 O''F'  union all " +
    " select 'A7 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A7 U''F'  union all " +
    " select 'B7 U''F' , P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B7 U''F' union all " +
    " select 'A6 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'A6 U''F'  union all " +
    " select 'B6 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'B6 U''F' ";
                        //cont precip south
                        query4 += " select 'AG1' AS [TK No], P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA  from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG1' union all " +
    " select 'AG3',  P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG3' union all " +
    " select 'AG7', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'AG7' union all " +
    " select 'Y15 O''F' ,P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y15 O''F' union all " +
    " select 'Y16 O''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y16 O''F'  union all " +
    " select 'Y15 U''F', P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y15 U''F'  union all " +
    " select 'Y16 U''F' , P100 AS[+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' and secid = 'Y16 U''F'";
                        //st tops samples
                        query4 += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                            " and SECRECORD = 'PTS' UNION ALL SELECT 'AVG' AS[AVG], AVG(P100),  AVG(P200), AVG(P325), AVG(UM20), AVG(CAUS), AVG(AC), AVG(GPLSOL), AVG(SA) from LAB_SEC_III_DATA " +
                            " where SECDATE = '" + date + "' and SECRECORD = 'PTS' ";
                        //caus clean
                        query4 += " select CCTRUCK AS [Tank], CCCAUSTIC as C, CCAC as [A/C]  FROM LAB_CAUSTIC_CLEAN where CCDATE = '" + date + "' and cctruck != '' ";
                        //tt tops samples
                        query4 += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u],UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                            " and SECRECORD = 'TTS' UNION ALL SELECT 'AVG' AS[AVG], AVG(P100),  AVG(P200), AVG(P325), AVG(UM20), AVG(CAUS), AVG(AC), AVG(GPLSOL), AVG(SA) from LAB_SEC_III_DATA " +
                            " where SECDATE = '" + date + "' and SECRECORD = 'TTS' ";
                        //primary feed
                        query4 += " select SECID AS [TK No],  P100 AS [+150u], P200 as [+75u], P325 as [+45u], UM20 AS [-20u], CAUS, AC, GPLSOL, SA from LAB_SEC_III_DATA where SECDATE = '" + date + "' " +
                            " and SECRECORD = 'FST' ";
                        //h20
                        query4 += " SELECT '0000' AS [TANK], H2ONORTH0000 AS [North], H2OSOUTH0000 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                                " SELECT '0600' AS[TANK], H2ONORTH0600 AS[North], H2OSOUTH0600 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                                " SELECT '1200' AS[TANK], H2ONORTH1200 AS[North], H2OSOUTH1200 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                                " SELECT '1800' AS[TANK], H2ONORTH1800 AS[North], H2OSOUTH1800 as South FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all " +
                                " Select 'AVG', AVG([north]), AVG([south]) from(" +
                                " select H2ONORTH0000 as [north], H2OSOUTH0000 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                                " select H2ONORTH0600 as [north], H2OSOUTH0600 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                                " select H2ONORTH1200 as [north], H2OSOUTH1200 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' union all" +
                                " select H2ONORTH1800 as [north], H2OSOUTH1800 as [south]  FROM LAB_H2O_TANK_DATA WHERE H2ODATE = '" + date + "' )x";
                        //% oxalate
                        query4 += " SELECT '1B Cake' as [name], OA1CAKE as [v] FROM LAB_SEC1_DATA  WHERE sddate = '" + date + "' union all SELECT '2B Cake', OA2CAKE FROM" +
                            " LAB_SEC1_DATA WHERE sddate = '" + date + "' union all SELECT 'ST Seed', OASTSEED FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' union all " +
                            " SELECT '6A/B', OA6AB FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' union all SELECT 'Y15/16', Y1516 FROM LAB_SEC1_DATA WHERE " +
                            " sddate = '" + date + "' union all SELECT 'PRIM FD', OAPF FROM LAB_SEC1_DATA WHERE sddate = '" + date + "' ";
                        //tray o'f solids
                        query4 += " select GPLS1 as #1, GPLS2 as #2, GPLS3 as #3, GPLS4 as #4 from LAB_SEC1_DATA WHERE sddate = '" + date + "' ";
                        query = query4;
                    }
                    //page3
                    else if (report == 5)
                    {
                        //string query5 = " select eadate as [Date],FASETTLER as SETTLR, FAWASHER AS WASHR, FAMIDDLE as CYTEC, s.SRPF as [Plant Floc], s.SRS as [Solids GPL], " +
                        //                " s.SRSTARCHI as [STRCH IND TIME], s.SRSTARCHS as [STRCH SET TIME], s.TRIDIGEST as [TRI DIG], s.FT5, e.SAHOTWELL as [Hot Well Ditch], " +
                        //                " e.SAPLANTDRAIN as [Plant Drain Ditch], e.SALIFTSTATION as [Lift STN North], e.SASURGEBASIN as [Surge Basin], e.P2O5CATESTTANK as [TT], " +
                        //                " e.P2O5CASETTLERFEED as SF, e.ABSCATESTTANK as [ABSTT], ABSCALTP as LTP from LAB_ENVIRONMENTAL e join LAB_SEC1_DATA s on " +
                        //                " s.SDDATE = e.EADATE where Datepart(Month, eadate) = '" + month + "' and DATEPART(Year, eadate) = '" + year + "' " +
                        //                " order by s.sddate ";

                        string query5 = " select CONVERT(VARCHAR(10), eadate) as [Date], Round(FASETTLER, 2) as SETTLR, FAWASHER AS WASHR, FAMIDDLE as CYTEC, Round(s.SRPF, 2) as [Plant Floc], " +
                                        " s.SRS as [Solids GPL],s.SRSTARCHI as [STRCH IND TIME], s.SRSTARCHS as [STRCH SET TIME],s.TRIDIGEST as [TRI DIG], s.FT5,e.SAHOTWELL as [Hot Well Ditch], " +
                                        " e.SAPLANTDRAIN as [Plant Drain Ditch], e.SALIFTSTATION as [Lift STN North], e.SASURGEBASIN as [Surge Basin], e.P2O5CATESTTANK as [TT],e.P2O5CASETTLERFEED as SF," +
                                        " e.ABSCATESTTANK as [ABSTT], ABSCALTP as LTP from LAB_ENVIRONMENTAL e join LAB_SEC1_DATA s on s.SDDATE = e.EADATE where Datepart(Month, eadate) = '" + month + "' " +
                                        " and DATEPART(Year, eadate) = '" + year + "' UNION ALL select 'AVG', avg(x.fasettler), AVG(x.WASHR), AVG(x.CYTEC), AVG(Convert(decimal(6, 2), x.[Plant Floc]))," +
                                        " avg(x.[Solids GPL]), avg(x.[STRCH IND TIME]), avg(x.[STRCH SET TIME]), avg(x.[TRI DIG]), AVG(x.FT5), avg(x.[Hot Well Ditch]), avg(x.[Plant Drain Ditch]) " +
                                        " ,avg(x.[Lift STN North]), avg(x.[Surge Basin]), avg(x.TT), avg(x.SF), avg(x.ABSTT), avg(x.LTP) from ( select e.FASETTLER, FAWASHER AS WASHR,FAMIDDLE as CYTEC, " +
                                        " Round(s.SRPF, 2) as [Plant Floc],s.SRS as [Solids GPL], s.SRSTARCHI as [STRCH IND TIME], s.SRSTARCHS as [STRCH SET TIME], s.TRIDIGEST as [TRI DIG], s.FT5, " +
                                        " e.SAHOTWELL as [Hot Well Ditch], e.SAPLANTDRAIN as [Plant Drain Ditch], e.SALIFTSTATION as [Lift STN North], e.SASURGEBASIN as [Surge Basin], e.P2O5CATESTTANK " +
                                        " as [TT], e.P2O5CASETTLERFEED as SF, e.ABSCATESTTANK as [ABSTT], ABSCALTP as LTP from LAB_ENVIRONMENTAL e join LAB_SEC1_DATA s on s.SDDATE = e.EADATE " +
                                        " where Datepart(Month, eadate) = '" + month + "' and DATEPART(Year, eadate) = '" + year + "') x ORDER BY[Date] ";



                        query = query5;
                    }
                    //page4
                    else if (report == 6)
                    {
                        string query6 = " select  LEFT(CONVERT(VARCHAR, eadate, 120), 10) as [date],[RWRPH],[EDFLOW], [EDPH], [FEDFLOW],[FEDPH],[WDFLOW],[WDPH],[CDFLOW], " +
                            " [CDPH],[OXPOND], [SEWERPH1],[SEWERPH2],[SEWERPH3],[SEWERPH5], [DAMPH1] from LAB_ENVIRONMENTAL  where Datepart(Month, eadate) = '" + month + "' and " +
                            " DATEPART(Year, eadate) = '" + year + "' union all select 'AVG',AVG(rwrph),AVG(edflow), AVG(edph), AVG(fedflow),AVG(fedph),AVG(wdflow),AVG(wdph),AVG(cdflow)," +
                            " AVG(cdph),AVG(oxpond), AVG(sewerph1)  ,AVG(sewerph2) ,AVG(sewerph3),AVG(sewerph5), AVG(damph1) FROM( SELECT[RWRPH] as rwrph, [EDFLOW] as edflow, " +
                            " [EDPH] as edph, [FEDFLOW] as fedflow, [FEDPH] as fedph,[WDFLOW] as wdflow,[WDPH] as wdph,[CDFLOW] as cdflow, [CDPH] as cdph,[OXPOND] as oxpond, " +
                            " [SEWERPH1] as sewerph1,[SEWERPH2] as sewerph2,[SEWERPH3] as sewerph3,[SEWERPH5] as sewerph5, [DAMPH1] as damph1 FROM  LAB_ENVIRONMENTAL where " +
                            " Datepart(Month, eadate) = '" + month + "' and DATEPART(Year, eadate) = '" + year + "' ) x ORDER BY [date]  ";
                        query = query6;
                    }
                    //page5
                    else if (report == 7)
                    {
                        DataTable dt = new DataTable();
                        dt = AluminaShipment(month, year, "ALUMINA");
                        Session["Page5"] = dt;
                        Response.Redirect("Page5.aspx");
                        query = "";
                    }
                    //page6
                    else if (report == 8)
                    {
                        DataTable dt = new DataTable();
                        dt = AluminaShipment(month, year, "HYDRATE");
                        Session["Page6"] = dt;
                        Response.Redirect("Page6.aspx");
                        query = "";
                    }
                    //page7
                    else if (report == 9)
                    {
                        DataTable dt = new DataTable();
                        dt = AluminaShipment(month, year, "WETHYDRATE");
                        Session["Page7"] = dt;
                        Response.Redirect("Page7.aspx");
                        query = "";
                    }
                    //page9
                    else if (report == 10)
                    {
                        DataTable dt = new DataTable();
                        dt = HydrateAnalysis(Convert.ToDateTime(date), "WETCAKE");
                        gv_page9_a.DataSource = dt;
                        gv_page9_a.DataBind();

                        DataTable dt2 = new DataTable();
                        dt2 = HydrateAnalysis(Convert.ToDateTime(date), "DRY");
                        gv_page9_b.DataSource = dt2;
                        gv_page9_b.DataBind();

                        query = "";
                        //string query10 = " select * into #tempWetHydrate from (select CONTAINERID, CONVERT(VARCHAR,SADATE) as [Date], REFLECTANCE, LEACHSODA, MOISTURE from  LAB_HYDRATE_ANALYSIS  " +
                        //         " where sadate =  '" + date + "'  and ha_type = 'wet' and containerid != ' '  union all SELECT null, 'USL/LSL', 70, .020, 90.00 union all " +
                        //         " select null, 'AVG', avg(Convert(float, REFLECTANCE)), avg(convert(float, LEACHSODA)), AVG(Convert(float, MOISTURE)) " +
                        //         " from LAB_HYDRATE_ANALYSIS where sadate = '" + date + "' and ha_type = 'wet' ) as x  select * from #tempWetHydrate ";

                        //query10 += " select * into #tempHydrate from (select CONTAINERID, CONVERT(VARCHAR,SADATE) as [Date], REFLECTANCE, LEACHSODA, MOISTURE from  LAB_HYDRATE_ANALYSIS  " +
                        //        " where sadate =  '" + date + "' and ha_type = 'dry' and containerid != ' ' union all SELECT null, 'USL/LSL', 70, .020, 90.00 union all " +
                        //        " select null, 'AVG', avg(Convert(float, REFLECTANCE)), avg(convert(float, LEACHSODA)), AVG(Convert(float, MOISTURE)) " +
                        //        " from LAB_HYDRATE_ANALYSIS where sadate = '" + date + "'  and ha_type = 'dry'  ) as y  select * from #tempHydrate  ";
                       
                    }
                    //h30
                    else if (report == 11)
                    {
                        string query11 = " select '% SiO₂' as [name], (Si * 1.40) as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Fe₂O₃' as [name], (FE * 0.935) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Na₂O' as [name], round((Na * 0.881),2) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% CaO' as [name], (Ca * .9) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Free Moisture' as [name], FREEMOIST from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select 'Bulk Density' as [name], BULKDENS from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' ";

                        query11 += " select '% Caustic Sedimentation' as [name], cseds as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Acid Insolubles' as [name], INSOLS from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Retained on 100 Mesh',  p100 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Retained on 200 Mesh',  p200 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select '% Retained on 325 Mesh',  p325 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select 'Hunter L Value',  HUNTERL from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select 'Hunter a Value',  HUNTERA from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'HYDRATE' UNION ALL " +
                        " select 'Hunter b Value',  HUNTERB from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'HYDRATE' ";

                        query11 += " select CONTAINERID AS [name], REFLECTANCE as reflectance, LEACHSODA as lsoda FROM[Lab].[dbo].[LAB_HYDRATE_ANALYSIS] " +
                                   " where HA_TYPE = 'DRY' AND SADATE = '" + date + "'  and containerid is not null ";

                        query = query11;

                    }
                    //wh30
                    else if (report == 12)
                    {
                        string query12 = " select '% SiO₂' as [name], (Si * 1.40) as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% Fe₂O₃' as [name], (FE * 0.935) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% Na₂O' as [name], (Na * 0.881) from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% CaO' as [name], (Ca * .9) from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'WETHYDRATE'  ";

                        query12 += " select '% Caustic Sedimentation' as [name], cseds as [value] from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% Acid Insolubles' as [name], INSOLS from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'wethydrate' UNION ALL " +
                        " select '% Retained on 100 Mesh',  p100 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% Retained on 200 Mesh',  p200 from LAB_DAILYANALYSIS where DADATE = '" + date + "'   and PRODUCT = 'WETHYDRATE' UNION ALL " +
                        " select '% Retained on 325 Mesh',  p325 from LAB_DAILYANALYSIS where DADATE = '" + date + "'  and PRODUCT = 'WETHYDRATE' ";

                        query12 += " select CONTAINERID AS [name], REFLECTANCE as reflectance, LEACHSODA as lsoda, Moisture as  psolid FROM[Lab].[dbo].[LAB_HYDRATE_ANALYSIS] " +
                                   " where HA_TYPE = 'WET' AND SADATE = '" + date + "'  and containerid is not null ";

                        query = query12;

                    }
                    //c70
                    else if (report == 13)
                    {
                        string query13 = " select 'SiO₂' as [name], '%' as [label], '-.021' as [specs], si * (2.14) as [analysis] from LAB_DAILYANALYSIS where DADATE = '" + date + "'" +
                            " and PRODUCT = 'ALUMINA' UNION ALL " +
                            " select 'Fe₂O₃', '%', '-.016', FE * (1.4297) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL " +
                            " select 'Na₂O', '%', '-.674', NA * (1.348) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'MnO', '%', '-.0026', Mn * (1.2912) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'ZnO', '%', '-.019', Zn * (1.2447) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'CaO', '%', '-.063', Ca * (1.3995) from LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'Bulk Density', 'Lbs/Cu ft.', '-', BULKDENS FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select 'Loss on Ignition', '%Max', '-1', LOI FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '100 Mesh', '% Retained', '-10', P100 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "'and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '200 Mesh', '% Retained', '-', P200 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA' UNION ALL  " +
                            " select '325 Mesh', '% Retained', '90-', P325 FROM  LAB_DAILYANALYSIS where DADATE = '" + date + "' and PRODUCT = 'ALUMINA'  ";
                        query = query13;
                    }
                    //Misc 
                    else if (report == 14)
                    {
                        string query14 = "SELECT [MMISCDESCR],[MMISCQTY],[MMISCSIZE] FROM[Lab].[dbo].[LAB_MISC] where mmiscdate = '" + date + "' AND  MMISCDESCR IS NOT NULL";

                        query = query14;
                    }

                    else
                        query = "select * from LAB_KILN_DRYER  where KDDATE = '" + date + "'";
                    using (SqlConnection con = new SqlConnection(strConnString))
                    {
                        DataSet ds = new DataSet();

                        if (query != "")
                        {
                            SqlCommand cmd = new SqlCommand(query);
                            SqlDataAdapter sda = new SqlDataAdapter();
                            cmd.Connection = con;
                            con.Open();
                            sda.SelectCommand = cmd;
                           
                            sda.Fill(ds);
                        }


                        //SqlCommand cmd = new SqlCommand(query);
                        //SqlDataAdapter sda = new SqlDataAdapter();
                        //cmd.Connection = con;
                        //con.Open();
                        //sda.SelectCommand = cmd;
                        //cmd.CommandType = CommandType.Text;
                     
                        //DataSet ds = new DataSet();
                        //sda.Fill(ds);
                        if (report == 1)
                        {
                            gv_report1a.DataSource = ds.Tables[0];
                            gv_report1a.DataBind();

                            gv_report1a_.DataSource = ds.Tables[0];
                            gv_report1a_.DataBind();

                            string yield = "";
                            string free_caus = "";
                            if (ds.Tables[1].Rows[0]["yield"].ToString() != "")
                            {
                                yield = ds.Tables[1].Rows[0]["yield"].ToString().Substring(0, 5);
                            }
                            if (ds.Tables[2].Rows[0]["free_caus"].ToString() != "")
                            {
                                free_caus = ds.Tables[2].Rows[0]["free_caus"].ToString().Substring(0, 5);
                            }

                            precip_yield.Value = yield;
                            free_c.Value = free_caus;
                        }
                        else if (report == 2)
                        {
                            gv_cpn.DataSource = ds.Tables[0];
                            gv_cpn.DataBind();

                            gv_cps.DataSource = ds.Tables[1];
                            gv_cps.DataBind();

                            gv_pfmg.DataSource = ds.Tables[2];
                            gv_pfmg.DataBind();

                            gv_smix.DataSource = ds.Tables[3];
                            gv_smix.DataBind();

                            gv_evapcc.DataSource = ds.Tables[4];
                            gv_evapcc.DataBind();

                        }

                        else if (report == 3)
                        {
                            gv_sec2pv.DataSource = ds.Tables[0];
                            gv_sec2pv.DataBind();
                     
    
                       
                            gv_hydratedryer.DataSource = ds.Tables[1];
                            gv_hydratedryer.DataBind();

                            gv_sec3pv.DataSource = ds.Tables[2];
                            gv_sec3pv.DataBind();

                            gv_kfm.DataSource = ds.Tables[3];
                            gv_kfm.DataBind();

                            gv_lsoda.DataSource = ds.Tables[4];
                            gv_lsoda.DataBind();

                            gv_kdischarge.DataSource = ds.Tables[5];
                            gv_kdischarge.DataBind();


                            gv_mudd.DataSource = ds.Tables[6];
                            gv_mudd.DataBind();


                            gv_psolids.DataSource = ds.Tables[7];
                            gv_psolids.DataBind();


                            gv_scaustic.DataSource = ds.Tables[8];
                            gv_scaustic.DataBind();


                            gv_soxalate.DataSource = ds.Tables[9];
                            gv_soxalate.DataBind();


                            gv_wprofile.DataSource = ds.Tables[10];
                            gv_wprofile.DataBind();

                            gv_dryerfm.DataSource = ds.Tables[11];
                            gv_dryerfm.DataBind();



                        }
                        else if (report == 4)
                        {
                            gv_precnorth.DataSource = ds.Tables[0];
                            gv_precnorth.DataBind();

                            gv_precsouth.DataSource = ds.Tables[1];
                            gv_precsouth.DataBind();

                            gv_sttops.DataSource = ds.Tables[2];
                            gv_sttops.DataBind();

                            gv_cclean.DataSource = ds.Tables[3];
                            gv_cclean.DataBind();

                            gv_tttops.DataSource = ds.Tables[4];
                            gv_tttops.DataBind();

                            gv_pfeed.DataSource = ds.Tables[5];
                            gv_pfeed.DataBind();

                            gv_water.DataSource = ds.Tables[6];
                            gv_water.DataBind();

                            gv_poxalate.DataSource = ds.Tables[7];
                            gv_poxalate.DataBind();

                            gv_trayo.DataSource = ds.Tables[8];
                            gv_trayo.DataBind();


                        }
                        else if (report == 5)
                        {
                            gv_page3report.DataSource = ds.Tables[0];
                            gv_page3report.DataBind();
                        }
                        else if (report == 6)
                        {
                            gv_page4report.DataSource = ds.Tables[0];
                            gv_page4report.DataBind();
                        }

                        else if (report == 11)
                        {
                            DataTable dt1 = new DataTable();
                            DataTable dt2 = new DataTable();
                            DataTable dt3 = new DataTable();
                            dt1 = ds.Tables[0];
                            dt2 = ds.Tables[1];
                            dt3 = ds.Tables[2];
                            //Store dt in Viewstate
                            Session["h30tbl_1"] = dt1;
                            Session["h30tbl_2"] = dt2;
                            Session["h30tbl_3"] = dt3;

                            Response.Redirect("H30.aspx");
                        }
                        else if (report == 12)
                        {
                            DataTable dt1 = new DataTable();
                            DataTable dt2 = new DataTable();
                            DataTable dt3 = new DataTable();
                            dt1 = ds.Tables[0];
                            dt2 = ds.Tables[1];
                            dt3 = ds.Tables[2];
                            //Store dt in Viewstate
                            Session["wh30tbl_1"] = dt1;
                            Session["wh30tbl_2"] = dt2;
                            Session["wh30tbl_3"] = dt3;

                            Response.Redirect("WH30.aspx");

                        }

                        else if (report == 13)
                        {
                            DataTable dt = new DataTable();
                            // Fill dt
                            dt = ds.Tables[0];
                            //Store dt in Viewstate
                            Session["c70tbl"] = dt;
                            Response.Redirect("Report_C70.aspx");
                            Thread.Sleep(2000);

                        }
                        else if (report == 14)
                        {
                            DataTable dt = new DataTable();
                        
                            dt = ds.Tables[0];

                            //gv_misc.DataSource = dt;
                            //gv_misc.DataBind();
                            Session["Misctbl"] = dt;

                            Response.Redirect("MiscReport.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                        }

                        else
                            query = "";
                    }
                }
                ddlReport.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
        }
        protected void SendPDF_Click(object sender, EventArgs e)
        {
            try
            {

                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
           
                startInfo.FileName = @"C:\Lab\Test_SendingEmailViaOutlook.exe";
                startInfo.Arguments = "dailylabreports";
                startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                Thread.Sleep(4000);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);

            }
            catch (Exception) { }
        }
        public static DataTable HydrateAnalysis(DateTime date, string product)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            DataTable table = new DataTable();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand("LAB_sp_page9Report", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = date;
                    cmd.Parameters.AddWithValue("@product", SqlDbType.VarChar).Value = product;
                    da.Fill(table);
                }
            }
            catch (Exception s)
            {
            }
            return table;
        }
        public static DataSet ProductionDay(DateTime date)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            DataSet dataSet = new DataSet();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand("LAB_sp_ProductionDay", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = date;
                    da.Fill(dataSet);
                }
            }

            catch (Exception s)
            {

            }
            return dataSet;
        }
        public static DataTable AluminaShipment (string month, string year, string product)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            DataTable table = new DataTable();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString))
                using (var cmd = new SqlCommand("LAB_sp_page5_alumina_shipments", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@month", SqlDbType.VarChar).Value = month;
                    cmd.Parameters.AddWithValue("@year", SqlDbType.VarChar).Value = year;
                    cmd.Parameters.AddWithValue("@product", SqlDbType.VarChar).Value = product;
                    da.Fill(table);
                }
            }
            catch(Exception s)
            {
            }
            return table;
        }

        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            HttpContext.Current.Session["report_date"] = selDate;

            return selDate;

        }

        protected void gv_page5_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)

            {

                if (e.Row.RowIndex % 2 != 0)

                {

                    e.Row.BackColor = Color.Blue;

                }

                else

                {

                    e.Row.ForeColor = Color.Red;

                }
            }
        }
    }
}
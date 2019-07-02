using QA_LAB_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.Services;
using System.Threading;
using System.Globalization;
using System.Text;
using ClosedXML.Excel;
using System.Reflection;

namespace QA_LAB_project
{

    public partial class ExcelDownloads : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetSelected(string fromDate, string toDate, List<string> reportName)
        {
            try
            {
            
            ExcelDownloads s = new ExcelDownloads();

            DateTime DTfromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
            DateTime DTtoDate = DateTime.ParseExact(toDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));

            DTfromDate = DTfromDate.Date;
            DTtoDate = DTtoDate.Date;

            HttpContext.Current.Session["DTfromDate"] = DTfromDate;
            HttpContext.Current.Session["DTtoDate"] = DTtoDate;

            string fd = DTfromDate.ToShortDateString();
            string td = DTtoDate.ToShortDateString();

            fd = fd.Replace("/", "_");


            //LabEntities db = new LabEntities();
            //var Names = (from v in db.LAB_REPORT_NAMES
            //             where reportNum.Contains(v.ID)
            //             select v).ToList();
            foreach (var name in reportName)
            {
                System.Data.DataTable result;
                Type type = typeof(ExcelDownloads);
                ExcelDownloads c = new ExcelDownloads();
                if (name == "CausticClean")
                {
                    MethodInfo method = type.GetMethod("CausticClean");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "HydrateAnalysis")
                {
                    MethodInfo method = type.GetMethod("HydrateAnalysis");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "ChargeControl")
                {
                    MethodInfo method = type.GetMethod("ChargeControl");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "KilnDryer")
                {
                    MethodInfo method = type.GetMethod("KilnDryer");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "DailyAnalysis")
                {
                    MethodInfo method = type.GetMethod("DailyAnalysis");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "Misc")
                {
                    MethodInfo method = type.GetMethod("Misc");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "Environmental")
                {
                    MethodInfo method = type.GetMethod("Environmental");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "Sec1_2")
                {
                    MethodInfo method = type.GetMethod("Sec1_2");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if (name == "Sec3")
                {
                    MethodInfo method = type.GetMethod("Sec3");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
                else if(name == "H2O")
                {
                    MethodInfo method = type.GetMethod("H2O");
                    result = (System.Data.DataTable)method.Invoke(c, null);
                    s.ExportToExcel(result, name + "_" + fd);
                }
            }
        }
        catch
        {
        }
                return "";
        }
        [WebMethod]
        public static string GetAll(string fromDate, string toDate)
        {
            try
            {
                ExcelDownloads s = new ExcelDownloads();

                DateTime DTfromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));
                DateTime DTtoDate = DateTime.ParseExact(toDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.GetCultureInfo("en-US"));

                DTfromDate = DTfromDate.Date;
                DTtoDate = DTtoDate.Date;

                HttpContext.Current.Session["DTfromDate"] = DTfromDate;
                HttpContext.Current.Session["DTtoDate"] = DTtoDate;

                string fd = DTfromDate.ToShortDateString();
                string td = DTtoDate.ToShortDateString();

                fd = fd.Replace("/", "_");
                LabEntities db = new LabEntities();
                var Names = (from v in db.LAB_REPORT_NAMES

                             select v.ReportName).ToList();
                foreach (var name in Names)
                {
                    System.Data.DataTable result;
                    Type type = typeof(ExcelDownloads);
                    ExcelDownloads c = new ExcelDownloads();

                    if (name == "CausticClean")
                    {
                        MethodInfo method = type.GetMethod("CausticClean");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "HydrateAnalysis")
                    {
                        MethodInfo method = type.GetMethod("HydrateAnalysis");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "ChargeControl")
                    {
                        MethodInfo method = type.GetMethod("ChargeControl");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "KilnDryer")
                    {
                        MethodInfo method = type.GetMethod("KilnDryer");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "DailyAnalysis")
                    {
                        MethodInfo method = type.GetMethod("DailyAnalysis");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "Misc")
                    {
                        MethodInfo method = type.GetMethod("Misc");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "Environmental")
                    {
                        MethodInfo method = type.GetMethod("Environmental");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "Sec1_2")
                    {
                        MethodInfo method = type.GetMethod("Sec1_2");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else if (name == "Sec3")
                    {
                        MethodInfo method = type.GetMethod("Sec3");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }
                    else
                    {
                        MethodInfo method = type.GetMethod("H2O");
                        result = (System.Data.DataTable)method.Invoke(c, null);
                        s.ExportToExcel(result, name + "_" + fd);
                    }



                }
            }
            catch
            {

            }
            return "";
        }
        public static System.Data.DataTable CausticClean()
        {
            //DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            //DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            //DateTime fromDate = DateTime.Today.AddDays(-1);
            //DateTime toDate = DateTime.Today;

            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());

            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

                table.Columns.AddRange(new DataColumn[4] { new DataColumn("CCDATE"),
                    new DataColumn("CCTRUCK"),
                    new DataColumn("CCCAUSTIC"),
                                                new DataColumn("CCAC") });
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_CAUSTIC_CLEAN
                              where (v.CCDATE >= fdate
                              && v.CCDATE <= todate
                              )
                              orderby v.CCID
                              select v).ToList();

                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.CCDATE, vals.CCTRUCK, vals.CCCAUSTIC, vals.CCAC);
                }
                
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable HydrateAnalysis()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

                
                table.Columns.AddRange(new DataColumn[7] { new DataColumn("ha_type"),
                    new DataColumn("sadate"),
                    new DataColumn("containerid"),
                    new DataColumn("addate"),
                    new DataColumn("reflectance"),
                    new DataColumn("leachsoda"),
                   new DataColumn("moisture") });
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_HYDRATE_ANALYSIS
                              where (v.SADATE >= fdate && v.SADATE <= todate)
                              orderby v.SADATE, v.HA_TYPE
                              select v).ToList();


                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.HA_TYPE, vals.SADATE, vals.CONTAINERID,
                        vals.ADATE, vals.REFLECTANCE, vals.LEACHSODA, vals.MOISTURE
                        );
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable ChargeControl()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

             
                table.Columns.AddRange(new DataColumn[62] {
                    new DataColumn("ccround"),
                    new DataColumn("ccdate"),
                        new DataColumn("testtankcaustic"),
                            new DataColumn("testtankac"),
                            new DataColumn("settlerfeedcaustic"),
                               new DataColumn("settlerfeedac"),
                                  new DataColumn("pressurefeedcaustic"),
                                   new DataColumn("pressurefeedac"),
                                     new DataColumn("ltpcaustic"),
                                      new DataColumn("ltpac"),
                                       new DataColumn("evapfeedcaustic"),
                          new DataColumn("evapfeedac"),
                           new DataColumn("a7overflowcaustic"), new DataColumn("a7overflowac"),
                          new DataColumn("b7overflowcaustic"),    new DataColumn("b7overflowac"),
                         new DataColumn("t1caustic"),       new DataColumn("t1ac"),
                           new DataColumn("t3caustic"),       new DataColumn("t3ac"),
                             new DataColumn("t7caustic"),  new DataColumn("t7ac"),
                             new DataColumn("wofcaustic"),  new DataColumn("wofac"),
                             new DataColumn("sufcaustic"),  new DataColumn("sufac"),
                             new DataColumn("evapcccaustic"),  new DataColumn("evapccac"),
                             new DataColumn("presscccaustic"),  new DataColumn("pressccac"),
                            new DataColumn("lkd4soda"),  new DataColumn("wufsoda"),
                            new DataColumn("mtlsoda"),  new DataColumn("srtsoda"),
                            new DataColumn("pfmg"),  new DataColumn("testtankcs"),
                            new DataColumn("tridigestorcs"),  new DataColumn("ft5cs"),
                              new DataColumn("digdischcs"),  new DataColumn("settlerfeedcs"),
                                new DataColumn("settlerfeedaim"),  new DataColumn("ltpaim"),
                              new DataColumn("ctridigestor"),  new DataColumn("actridigestor"),
                            new DataColumn("cft5"),  new DataColumn("acft5"),
                              new DataColumn("cdigdisch"),  new DataColumn("acdigdisch"),
                               new DataColumn("cevapdisch"),  new DataColumn("acevapdisch"),
                             new DataColumn("cy15overflow"),  new DataColumn("acy15overflow"),
                              new DataColumn("cy16overflow"),  new DataColumn("acy16overflow"),
                               new DataColumn("tridigestoraim"),  new DataColumn("ft5aim"),
                                new DataColumn("cag1"),  new DataColumn("cag3"),  new DataColumn("cag7"),
                                  new DataColumn("acag1"),  new DataColumn("acag3"),  new DataColumn("acag7") });

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_CHARGECONTROL
                              where (v.CCDATE >= fdate && v.CCDATE <= todate)
                              orderby v.CCDATE, v.CCROUND
                              select v).ToList();

                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.CCROUND, vals.CCDATE, vals.TESTTANKCAUSTIC, vals.TESTTANKAC, vals.SETTLERFEEDCAUSTIC,
                     vals.SETTLERFEEDAC, vals.PRESSFEEDCAUSTIC, vals.PRESSFEEDAC, vals.LTPCAUSTIC, vals.LTPAC,
                     vals.EVAPFEEDCAUSTIC, vals.EVAPFEEDAC, vals.A7OVERFLOWCAUSTIC, vals.A7OVERFLOWAC, vals.B7OVERFLOWCAUSTIC,
                     vals.B7OVERFLOWAC, vals.T1CAUSTIC, vals.T1AC, vals.T3CAUSTIC, vals.T3AC,
                     vals.T7CAUSTIC, vals.T7AC, vals.WOFCAUSTIC, vals.WOFAC, vals.SUFCAUSTIC,
                     vals.SUFAC, vals.EVAPCCCAUSTIC, vals.EVAPCCAC, vals.PRESSCCCAUSTIC, vals.PRESSCCAC,
                     vals.LKD4SODA, vals.WUFSODA, vals.MTLSODA, vals.SRTSODA, vals.PFMG,
                     vals.TESTTANKCS, vals.TRIDIGESTORCS, vals.FT5CS, vals.DIGDISCHCS, vals.SETTLERFEEDCS,
                     vals.SETTLERFEEDAIM, vals.LTPAIM, vals.CTRIDIGESTOR, vals.ACTRIDIGESTOR, vals.CFT5,
                     vals.ACFT5, vals.CDIGDISCH, vals.ACDIGDISCH, vals.CEVAPDISCH, vals.ACEVAPDISCH,
                      vals.CY15OVERFLOW, vals.ACY15OVERFLOW, vals.CY16OVERFLOW, vals.ACY15OVERFLOW, vals.TRIDIGESTORAIM,
                       vals.FT5AIM, vals.CAG1, vals.CAG3, vals.CAG7, vals.ACAG1, vals.ACAG3, vals.ACAG7);
                }

            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable  KilnDryer()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

                table.Columns.AddRange(new DataColumn[65] {
                    new DataColumn("kddate"),new DataColumn("kfls0600_1"),new DataColumn("kfls0600_2"),
                    new DataColumn("kfls0600_3"),new DataColumn("kfls1800_1"),new DataColumn("kfls1800_2"),
                   new DataColumn("kfls1800_3"),new DataColumn("kfm0600_1"),new DataColumn("kfm0600_2"),
                   new DataColumn("kfm0600_3"),new DataColumn("kdloi2200_1"),new DataColumn("kdloi2200_2"),
                      new DataColumn("kdloi2200_3"), new DataColumn("kdloi1000_1"),
                          new DataColumn("kdloi1000_2"),    new DataColumn("kdloi1000_3"),
                         new DataColumn("kdna2200_1"),       new DataColumn("kdna2200_2"),
                           new DataColumn("kdna2200_3"),       new DataColumn("kdna1000_1"),
                             new DataColumn("kdna1000_2"),  new DataColumn("kdna1000_3"),
                             new DataColumn("kdca2200_1"),  new DataColumn("kdca2200_2"),
                             new DataColumn("kdca2200_3"),  new DataColumn("kdca1000_1"),
                             new DataColumn("kdca1000_2"),  new DataColumn("kdca1000_3"),
                             new DataColumn("kdzn2200_1"),  new DataColumn("kdzn2200_2"),
                            new DataColumn("kdzn2200_3"),  new DataColumn("kdzn1000_1"),
                            new DataColumn("kdzn1000_2"),  new DataColumn("kdzn1000_3"),
                            new DataColumn("hd0600ls"),  new DataColumn("hd0600rf"),
                            new DataColumn("hd1100ls"),  new DataColumn("hd1100rf"),
                              new DataColumn("hd1800ls"),  new DataColumn("hd1800rf"),
                                new DataColumn("hd2200ls"),  new DataColumn("hd2200rf"),
                              new DataColumn("hdfm0600"),  new DataColumn("psmapfna"),
                            new DataColumn("psmapfca"),  new DataColumn("psmapfzn"),
                              new DataColumn("psma6a6bna"),  new DataColumn("psma6a6bca"),
                               new DataColumn("psma6a6bzn"),  new DataColumn("psmattsna"),
                             new DataColumn("psmattsca"),  new DataColumn("psmattszn"),
                              new DataColumn("psmastsna"),  new DataColumn("psmastsca"),
                               new DataColumn("psmastszn"),  new DataColumn("kfm"),
                                new DataColumn("kfm2"),  new DataColumn("kfm3"),  new DataColumn("cpnna"),
                                  new DataColumn("cpnca"),  new DataColumn("cpnzn"),  new DataColumn("cpsna"),
                new DataColumn("cpsca"), new DataColumn("cpszn"), new DataColumn("ft6")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_KILN_DRYER
                              where (v.KDDATE >= fdate && v.KDDATE <= todate)
                              orderby v.KDDATE
                              select v).ToList();

                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.KDDATE, vals.KFLS0600_1, vals.KFLS0600_2, vals.KFLS0600_3, vals.KFLS1800_1,
                     vals.KFLS1800_2, vals.KFLS1800_3, vals.KFM0600_1, vals.KFM0600_2, vals.KFM0600_3,
                     vals.KDCA2200_1, vals.KDLOI2200_2, vals.KDLOI2200_3, vals.KDLOI1000_1, vals.KDLOI1000_2,
                     vals.KDLOI1000_3, vals.KDNA2200_1, vals.KDNA2200_2, vals.KDNA2200_3, vals.KDNA1000_1,
                     vals.KDNA1000_2, vals.KDNA1000_3, vals.KDCA2200_1, vals.KDCA2200_2, vals.KDCA2200_3,
                     vals.KDCA1000_1, vals.KDCA1000_2, vals.KDCA1000_3, vals.KDZN2200_1, vals.KDZN2200_2,
                     vals.KDZN2200_3, vals.KDZN1000_1, vals.KDZN1000_2, vals.KDZN1000_3, vals.HD0600LS,
                     vals.HD0600RF, vals.HD1100LS, vals.HD1100RF, vals.HD1800LS, vals.HD1800RF,
                     vals.HD2200LS, vals.HD2200RF, vals.HDFM0600, vals.PSMAPFNA, vals.PSMAPFCA,
                     vals.PSMAPFZN, vals.PSMA6A6BNA, vals.PSMA6A6BCA, vals.PSMA6A6BZN, vals.PSMATTSNA,
                      vals.PSMATTSCA, vals.PSMATTSZN, vals.PSMASTSNA, vals.PSMASTSCA, vals.PSMASTSZN,
                       vals.KFM, vals.KFM2, vals.CPNNA, vals.CPNCA, vals.CPNZN, vals.CPSNA, vals.CPSCA,
                      vals.CPSZN, vals.FT6);
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable DailyAnalysis()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {
      
                table.Columns.AddRange(new DataColumn[22] {
                    new DataColumn("dadate"),new DataColumn("product"),new DataColumn("loi"),
                    new DataColumn("p100"),new DataColumn("p200"),new DataColumn("p325"),
                   new DataColumn("bulkdens"),new DataColumn("si"),new DataColumn("fe"),
                   new DataColumn("na"),new DataColumn("zn"),new DataColumn("mn"),
                    new DataColumn("ca"), new DataColumn("ti"),
                    new DataColumn("freemoist"),    new DataColumn("cseds"),
                    new DataColumn("insols"),       new DataColumn("hunterl"),
                    new DataColumn("huntera"),       new DataColumn("hunterb"),
                    new DataColumn("ai"),  new DataColumn("m20")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_DAILYANALYSIS
                              where (v.DADATE >= fdate && v.DADATE <= todate)
                              orderby v.DADATE, v.PRODUCT
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.DADATE, vals.PRODUCT, vals.LOI, vals.P100, vals.P200,
                     vals.P325, vals.BULKDENS, vals.SI, vals.FE, vals.NA,
                     vals.ZN, vals.MN, vals.CA, vals.TI,
                     vals.FREEMOIST, vals.CSEDS, vals.INSOLS, vals.HUNTERL, vals.HUNTERA,
                     vals.HUNTERB, vals.AI, vals.M20
                    );
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable Misc()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {
    
                table.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("mmiscdate"),new DataColumn("mmiscdescr"),new DataColumn("mmiscqty"),
                    new DataColumn("mmiscsize")});
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_MISC
                              where (v.MMISCDATE >= fdate && v.MMISCDATE <= todate)
                              orderby v.MMISCDATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.MMISCDATE, vals.MMISCDESCR, vals.MMISCQTY, vals.MMISCSIZE

                    );
                }
            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable Environmental()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

    
                table.Columns.AddRange(new DataColumn[31] {
                    new DataColumn("eadate"),new DataColumn("rwrph"),new DataColumn("edph"),
                    new DataColumn("wdph"),new DataColumn("fedph"),new DataColumn("cdph"),
                   new DataColumn("oxpond"),new DataColumn("edflow"),new DataColumn("wdflow"),
                   new DataColumn("fedflow"),new DataColumn("cdflow"),new DataColumn("sewerph1"),
                    new DataColumn("sewerph2"), new DataColumn("sewerph3"),
                    new DataColumn("sewerph5"),    new DataColumn("damph1"),
                    new DataColumn("sahotwell"),       new DataColumn("saplantdrain"),
                    new DataColumn("saliftstation"),       new DataColumn("sasurgebasin"),
                    new DataColumn("p2o5catesttank"),       new DataColumn("p2o5casettlerfeed"),
                    new DataColumn("abscatesttank"),       new DataColumn("abscaltp"),
                     new DataColumn("scatesttank"),  new DataColumn("sca4ft"),
                      new DataColumn("scasettlerfd"),  new DataColumn("scaltp"),
                       new DataColumn("fasettler"),  new DataColumn("fawasher"),
                    new DataColumn("famiddle")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_ENVIRONMENTAL
                              where (v.EADATE >= fdate && v.EADATE <= todate)
                              orderby v.EADATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.EADATE, vals.RWRPH, vals.EDPH, vals.WDPH, vals.FEDPH,
                     vals.CDPH, vals.OXPOND, vals.EDFLOW, vals.WDFLOW, vals.FEDFLOW,
                     vals.CDFLOW, vals.SEWERPH1, vals.SEWERPH2, vals.SEWERPH3,
                     vals.SEWERPH5, vals.DAMPH1, vals.SAHOTWELL, vals.SAPLANTDRAIN, vals.SALIFTSTATION,
                     vals.SASURGEBASIN, vals.P2O5CATESTTANK, vals.P2O5CASETTLERFEED, vals.ABSCATESTTANK, vals.ABSCALTP,
                     vals.SCATESTTANK, vals.SCA4FT, vals.SCASETTLERFD, vals.SCALTP,
                     vals.FASETTLER, vals.FAWASHER, vals.FAMIDDLE
                    );
                }

            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable Sec1_2()
        {

            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {
                table.Columns.AddRange(new DataColumn[70] {
                    new DataColumn("sddate"),new DataColumn("sasuf"),new DataColumn("sawuf"),
                    new DataColumn("samtl"),new DataColumn("safa"),new DataColumn("salr"),
                   new DataColumn("gpls1"),new DataColumn("gpls2"),new DataColumn("gpls3"),
                   new DataColumn("gpls4"),new DataColumn("gplsbf"),new DataColumn("gplsoxset"),
                    new DataColumn("sabf"), new DataColumn("saoxset"),
                    new DataColumn("salimerec"),    new DataColumn("sast"),
                    new DataColumn("salp"),       new DataColumn("oaoxset"),
                    new DataColumn("oabf"),       new DataColumn("oa1cake"),
                    new DataColumn("oa2cake"),       new DataColumn("oastseed"),
                    new DataColumn("oa6ab"),       new DataColumn("oapf"),
                     new DataColumn("srsolids"),  new DataColumn("srstarchi"),
                      new DataColumn("srstarchs"),  new DataColumn("srplantfloc"),
                       new DataColumn("taaa4ft"),  new DataColumn("taaasf"),
                       new DataColumn("taaasuf"),  new DataColumn("taaawuf"),
                       new DataColumn("taaamtl"),  new DataColumn("ltpca"),
                       new DataColumn("ltp"),  new DataColumn("spentliq"),
                       new DataColumn("y1516"),  new DataColumn("tridigest"),
                       new DataColumn("ft5"),  new DataColumn("digdisch"),

                        new DataColumn("wp0"),  new DataColumn("wp1"),
                       new DataColumn("wp2"),  new DataColumn("wp3"),
                       new DataColumn("wp4"),  new DataColumn("wp5"),
                       new DataColumn("wp6"),  new DataColumn("wp7"),
                       new DataColumn("wp8"),  new DataColumn("td"),
                       new DataColumn("cpds1"),  new DataColumn("cpds2"),
                       new DataColumn("cpds3"),  new DataColumn("cpds4"),
                       new DataColumn("crettank"),  new DataColumn("apds1"),
                       new DataColumn("apds2"),  new DataColumn("apds3"),
                         new DataColumn("apds4"),  new DataColumn("arettank"),
                       new DataColumn("spds1"),  new DataColumn("spds2"),
                         new DataColumn("spds3"),  new DataColumn("spds4"),
                       new DataColumn("srettank"),  new DataColumn("drettank"),
                         new DataColumn("d1pds"),  new DataColumn("d2pds"),
                       new DataColumn("d3pds"),  new DataColumn("d4pds")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_SEC1_DATA
                              where (v.SDDATE >= fdate && v.SDDATE <= todate)
                              orderby v.SDDATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.SDDATE, vals.SASUF, vals.SAWUF, vals.SAMTL, vals.SALR,
                     vals.GPLS1, vals.GPLS2, vals.GPLS3, vals.GPLS4, vals.GPLSBF,
                     vals.GPLSOXSET, vals.SABF, vals.SAOXSET, vals.SALIMEREC,
                     vals.SAST, vals.SALP, vals.OAOXSET, vals.OABF, vals.OA1CAKE,
                     vals.OA2CAKE, vals.OASTSEED, vals.OA6AB, vals.OAPF, vals.SRS,
                     vals.SRSTARCHI, vals.SRSTARCHS, vals.SRPF, vals.TAAA4FT,
                     vals.TAAASF, vals.TAAASUF, vals.TAAAWUF,
                     vals.TAAAMTL, vals.LTPCA, vals.LTP, vals.SPENTLIQ,
                     vals.Y1516, vals.TRIDIGEST, vals.FT5,
                     vals.DIGDISCH, vals.WP0, vals.WP1, vals.WP2,
                     vals.WP3, vals.WP4, vals.WP5,
                      vals.WP6, vals.WP7, vals.WP8, vals.TD,
                     vals.CPDS1, vals.CPDS2, vals.CPDS3,
                      vals.CPDS4, vals.CRETTANK, vals.APDS1, vals.APDS2,
                     vals.APDS3, vals.APDS4, vals.ARETTANK,
                      vals.SPDS1, vals.SPDS2, vals.SPDS3, vals.SPDS4,
                     vals.SRETTANK, vals.DRETTANK, vals.D1PDS,
                     vals.D2PDS, vals.D3PDS, vals.D4PDS
                    );

                }


            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable H2O()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");

            try
            {

  
                table.Columns.AddRange(new DataColumn[9] {
                    new DataColumn("h2odate"),new DataColumn("h2onorth0000"),new DataColumn("h2onorth0600"),
                    new DataColumn("h2onorth1200"),new DataColumn("h2onorth1800"),new DataColumn("h2osouth0000"),
                   new DataColumn("h2osouth0600"),new DataColumn("h2osouth1200"),new DataColumn("h2osouth1800")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_H2O_TANK_DATA
                              where (v.H2ODATE >= fdate && v.H2ODATE <= todate)
                              orderby v.H2ODATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.H2ODATE, vals.H2ONORTH0000, vals.H2ONORTH0600, vals.H2ONORTH1200, vals.H2ONORTH1800,
                     vals.H2OSOUTH0000, vals.H2OSOUTH0600, vals.H2OSOUTH1200, vals.H2OSOUTH1800
                    );
                }

            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public static System.Data.DataTable Sec3()
        {
            DateTime fdate = Convert.ToDateTime(HttpContext.Current.Session["DTfromDate"].ToString());
            DateTime todate = Convert.ToDateTime(HttpContext.Current.Session["DTtoDate"].ToString());
            System.Data.DataTable table = new System.Data.DataTable("Grid");
            try
            {

                table.Columns.AddRange(new DataColumn[13] {
                    new DataColumn("secdate"),new DataColumn("secrecord"),new DataColumn("secid"),
                    new DataColumn("p100"),new DataColumn("p200"),new DataColumn("p325"),
                   new DataColumn("caus"),new DataColumn("ac"),new DataColumn("gplsol"),
                   new DataColumn("ht"),new DataColumn("sa"),new DataColumn("um20"),
                    new DataColumn("indx")});

                LabEntities db = new LabEntities();

                var Values = (from v in db.LAB_SEC_III_DATA
                              where (v.SECDATE >= fdate && v.SECDATE <= todate) && v.SECID != null
                              orderby v.SECDATE, v.SECRECORD
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.SECDATE, vals.SECRECORD, vals.SECID, vals.P100, vals.P200,
                     vals.P325, vals.CAUS, vals.AC, vals.GPLSOL, vals.HT,
                     vals.SA, vals.UM20, vals.INDX);
                }


            }
            catch (Exception ex)
            {
            }
            return table;
        }
        public void ExportToExcel(System.Data.DataTable table, string filename)
        {
            //string sPath = Server.MapPath(@"C:\\");

            string excelFilename = "C:\\" + filename + ".xls";

            CreateExcelFile.CreateExcelDocument(table, excelFilename);







        }


        protected void CausticClean_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());

            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[4] { new DataColumn("ccdate"),
                    new DataColumn("cctruck"),
                    new DataColumn("cccaustic"),
                    new DataColumn("ccac") }
                  );
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_CAUSTIC_CLEAN
                              where (v.CCDATE >= fromDate && v.CCDATE <= toDate && v.CCTRUCK != null)
                              orderby v.CCDATE
                              select v).ToList();


                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.CCDATE, vals.CCTRUCK, vals.CCCAUSTIC,
                        vals.CCAC
                        );
                }


                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=CausticClean.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();


                Response.End();




            }
            catch (Exception ex)
            {
            }


        }
        protected void Hydrate_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());

            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[7] { new DataColumn("ha_type"),
                    new DataColumn("sadate"),
                    new DataColumn("containerid"),
                    new DataColumn("addate"),
                    new DataColumn("reflectance"),
                    new DataColumn("leachsoda"),
                   new DataColumn("moisture") });
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_HYDRATE_ANALYSIS
                              where (v.SADATE >= fromDate && v.SADATE <= toDate && v.CONTAINERID != null)
                              orderby v.SADATE, v.HA_TYPE
                              select v).ToList();


                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.HA_TYPE, vals.SADATE, vals.CONTAINERID,
                        vals.ADATE, vals.REFLECTANCE, vals.LEACHSODA, vals.MOISTURE
                        );
                }


                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=HydrateAnalysis.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();


                Response.End();




            }
            catch (Exception ex)
            {
            }


        }
        protected void ChargeControl_ExportToExcel(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());

            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[62] {
                    new DataColumn("ccround"),
                    new DataColumn("ccdate"),
                        new DataColumn("testtankcaustic"),
                            new DataColumn("testtankac"),
                            new DataColumn("settlerfeedcaustic"),
                               new DataColumn("settlerfeedac"),
                                  new DataColumn("pressurefeedcaustic"),
                                   new DataColumn("pressurefeedac"),
                                     new DataColumn("ltpcaustic"),
                                      new DataColumn("ltpac"),
                                       new DataColumn("evapfeedcaustic"),
                          new DataColumn("evapfeedac"),
                           new DataColumn("a7overflowcaustic"), new DataColumn("a7overflowac"),
                          new DataColumn("b7overflowcaustic"),    new DataColumn("b7overflowac"),
                         new DataColumn("t1caustic"),       new DataColumn("t1ac"),
                           new DataColumn("t3caustic"),       new DataColumn("t3ac"),
                             new DataColumn("t7caustic"),  new DataColumn("t7ac"),
                             new DataColumn("wofcaustic"),  new DataColumn("wofac"),
                             new DataColumn("sufcaustic"),  new DataColumn("sufac"),
                             new DataColumn("evapcccaustic"),  new DataColumn("evapccac"),
                             new DataColumn("presscccaustic"),  new DataColumn("pressccac"),
                            new DataColumn("lkd4soda"),  new DataColumn("wufsoda"),
                            new DataColumn("mtlsoda"),  new DataColumn("srtsoda"),
                            new DataColumn("pfmg"),  new DataColumn("testtankcs"),
                            new DataColumn("tridigestorcs"),  new DataColumn("ft5cs"),
                              new DataColumn("digdischcs"),  new DataColumn("settlerfeedcs"),
                                new DataColumn("settlerfeedaim"),  new DataColumn("ltpaim"),
                              new DataColumn("ctridigestor"),  new DataColumn("actridigestor"),
                            new DataColumn("cft5"),  new DataColumn("acft5"),
                              new DataColumn("cdigdisch"),  new DataColumn("acdigdisch"),
                               new DataColumn("cevapdisch"),  new DataColumn("acevapdisch"),
                             new DataColumn("cy15overflow"),  new DataColumn("acy15overflow"),
                              new DataColumn("cy16overflow"),  new DataColumn("acy16overflow"),
                               new DataColumn("tridigestoraim"),  new DataColumn("ft5aim"),
                                new DataColumn("cag1"),  new DataColumn("cag3"),  new DataColumn("cag7"),
                                  new DataColumn("acag1"),  new DataColumn("acag3"),  new DataColumn("acag7") });

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_CHARGECONTROL
                              where (v.CCDATE >= fromDate && v.CCDATE <= toDate)
                              orderby v.CCDATE, v.CCROUND
                              select v).ToList();

                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.CCROUND, vals.CCDATE, vals.TESTTANKCAUSTIC, vals.TESTTANKAC, vals.SETTLERFEEDCAUSTIC,
                     vals.SETTLERFEEDAC, vals.PRESSFEEDCAUSTIC, vals.PRESSFEEDAC, vals.LTPCAUSTIC, vals.LTPAC,
                     vals.EVAPFEEDCAUSTIC, vals.EVAPFEEDAC, vals.A7OVERFLOWCAUSTIC, vals.A7OVERFLOWAC, vals.B7OVERFLOWCAUSTIC,
                     vals.B7OVERFLOWAC, vals.T1CAUSTIC, vals.T1AC, vals.T3CAUSTIC, vals.T3AC,
                     vals.T7CAUSTIC, vals.T7AC, vals.WOFCAUSTIC, vals.WOFAC, vals.SUFCAUSTIC,
                     vals.SUFAC, vals.EVAPCCCAUSTIC, vals.EVAPCCAC, vals.PRESSCCCAUSTIC, vals.PRESSCCAC,
                     vals.LKD4SODA, vals.WUFSODA, vals.MTLSODA, vals.SRTSODA, vals.PFMG,
                     vals.TESTTANKCS, vals.TRIDIGESTORCS, vals.FT5CS, vals.DIGDISCHCS, vals.SETTLERFEEDCS,
                     vals.SETTLERFEEDAIM, vals.LTPAIM, vals.CTRIDIGESTOR, vals.ACTRIDIGESTOR, vals.CFT5,
                     vals.ACFT5, vals.CDIGDISCH, vals.ACDIGDISCH, vals.CEVAPDISCH, vals.ACEVAPDISCH,
                      vals.CY15OVERFLOW, vals.ACY15OVERFLOW, vals.CY16OVERFLOW, vals.ACY15OVERFLOW, vals.TRIDIGESTORAIM,
                       vals.FT5AIM, vals.CAG1, vals.CAG3, vals.CAG7, vals.ACAG1, vals.ACAG3, vals.ACAG7);
                }


                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=ChargeControl.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();




            }
            catch (Exception ex)
            {
            }
        }
        protected void KilnDryer_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[65] {
                    new DataColumn("kddate"),new DataColumn("kfls0600_1"),new DataColumn("kfls0600_2"),
                    new DataColumn("kfls0600_3"),new DataColumn("kfls1800_1"),new DataColumn("kfls1800_2"),
                   new DataColumn("kfls1800_3"),new DataColumn("kfm0600_1"),new DataColumn("kfm0600_2"),
                   new DataColumn("kfm0600_3"),new DataColumn("kdloi2200_1"),new DataColumn("kdloi2200_2"),
                      new DataColumn("kdloi2200_3"), new DataColumn("kdloi1000_1"),
                          new DataColumn("kdloi1000_2"),    new DataColumn("kdloi1000_3"),
                         new DataColumn("kdna2200_1"),       new DataColumn("kdna2200_2"),
                           new DataColumn("kdna2200_3"),       new DataColumn("kdna1000_1"),
                             new DataColumn("kdna1000_2"),  new DataColumn("kdna1000_3"),
                             new DataColumn("kdca2200_1"),  new DataColumn("kdca2200_2"),
                             new DataColumn("kdca2200_3"),  new DataColumn("kdca1000_1"),
                             new DataColumn("kdca1000_2"),  new DataColumn("kdca1000_3"),
                             new DataColumn("kdzn2200_1"),  new DataColumn("kdzn2200_2"),
                            new DataColumn("kdzn2200_3"),  new DataColumn("kdzn1000_1"),
                            new DataColumn("kdzn1000_2"),  new DataColumn("kdzn1000_3"),
                            new DataColumn("hd0600ls"),  new DataColumn("hd0600rf"),
                            new DataColumn("hd1100ls"),  new DataColumn("hd1100rf"),
                              new DataColumn("hd1800ls"),  new DataColumn("hd1800rf"),
                                new DataColumn("hd2200ls"),  new DataColumn("hd2200rf"),
                              new DataColumn("hdfm0600"),  new DataColumn("psmapfna"),
                            new DataColumn("psmapfca"),  new DataColumn("psmapfzn"),
                              new DataColumn("psma6a6bna"),  new DataColumn("psma6a6bca"),
                               new DataColumn("psma6a6bzn"),  new DataColumn("psmattsna"),
                             new DataColumn("psmattsca"),  new DataColumn("psmattszn"),
                              new DataColumn("psmastsna"),  new DataColumn("psmastsca"),
                               new DataColumn("psmastszn"),  new DataColumn("kfm"),
                                new DataColumn("kfm2"),  new DataColumn("kfm3"),  new DataColumn("cpnna"),
                                  new DataColumn("cpnca"),  new DataColumn("cpnzn"),  new DataColumn("cpsna"),
                new DataColumn("cpsca"), new DataColumn("cpszn"), new DataColumn("ft6")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_KILN_DRYER
                              where (v.KDDATE >= fromDate && v.KDDATE <= toDate)
                              orderby v.KDDATE
                              select v).ToList();

                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.KDDATE, vals.KFLS0600_1, vals.KFLS0600_2, vals.KFLS0600_3, vals.KFLS1800_1,
                     vals.KFLS1800_2, vals.KFLS1800_3, vals.KFM0600_1, vals.KFM0600_2, vals.KFM0600_3,
                     vals.KDCA2200_1, vals.KDLOI2200_2, vals.KDLOI2200_3, vals.KDLOI1000_1, vals.KDLOI1000_2,
                     vals.KDLOI1000_3, vals.KDNA2200_1, vals.KDNA2200_2, vals.KDNA2200_3, vals.KDNA1000_1,
                     vals.KDNA1000_2, vals.KDNA1000_3, vals.KDCA2200_1, vals.KDCA2200_2, vals.KDCA2200_3,
                     vals.KDCA1000_1, vals.KDCA1000_2, vals.KDCA1000_3, vals.KDZN2200_1, vals.KDZN2200_2,
                     vals.KDZN2200_3, vals.KDZN1000_1, vals.KDZN1000_2, vals.KDZN1000_3, vals.HD0600LS,
                     vals.HD0600RF, vals.HD1100LS, vals.HD1100RF, vals.HD1800LS, vals.HD1800RF,
                     vals.HD2200LS, vals.HD2200RF, vals.HDFM0600, vals.PSMAPFNA, vals.PSMAPFCA,
                     vals.PSMAPFZN, vals.PSMA6A6BNA, vals.PSMA6A6BCA, vals.PSMA6A6BZN, vals.PSMATTSNA,
                      vals.PSMATTSCA, vals.PSMATTSZN, vals.PSMASTSNA, vals.PSMASTSCA, vals.PSMASTSZN,
                       vals.KFM, vals.KFM2, vals.CPNNA, vals.CPNCA, vals.CPNZN, vals.CPSNA, vals.CPSCA,
                      vals.CPSZN, vals.FT6);
                }


                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=KilnDryer.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
        protected void Daily_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {
                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[22] {
                    new DataColumn("dadate"),new DataColumn("product"),new DataColumn("loi"),
                    new DataColumn("p100"),new DataColumn("p200"),new DataColumn("p325"),
                   new DataColumn("bulkdens"),new DataColumn("si"),new DataColumn("fe"),
                   new DataColumn("na"),new DataColumn("zn"),new DataColumn("mn"),
                    new DataColumn("ca"), new DataColumn("ti"),
                    new DataColumn("freemoist"),    new DataColumn("cseds"),
                    new DataColumn("insols"),       new DataColumn("hunterl"),
                    new DataColumn("huntera"),       new DataColumn("hunterb"),
                    new DataColumn("ai"),  new DataColumn("m20")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_DAILYANALYSIS
                              where (v.DADATE >= fromDate && v.DADATE <= toDate)
                              orderby v.DADATE, v.PRODUCT
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.DADATE, vals.PRODUCT, vals.LOI, vals.P100, vals.P200,
                     vals.P325, vals.BULKDENS, vals.SI, vals.FE, vals.NA,
                     vals.ZN, vals.MN, vals.CA, vals.TI,
                     vals.FREEMOIST, vals.CSEDS, vals.INSOLS, vals.HUNTERL, vals.HUNTERA,
                     vals.HUNTERB, vals.AI, vals.M20
                    );
                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=DailyAnalysis.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
        protected void Misc_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {
                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("mmiscdate"),new DataColumn("mmiscdescr"),new DataColumn("mmiscqty"),
                    new DataColumn("mmiscsize")});
                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_MISC
                              where (v.MMISCDATE >= fromDate && v.MMISCDATE <= toDate)
                              orderby v.MMISCDATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.MMISCDATE, vals.MMISCDESCR, vals.MMISCQTY, vals.MMISCSIZE

                    );
                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Misc.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }

        protected void Env_ExportToExcel(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[31] {
                    new DataColumn("eadate"),new DataColumn("rwrph"),new DataColumn("edph"),
                    new DataColumn("wdph"),new DataColumn("fedph"),new DataColumn("cdph"),
                   new DataColumn("oxpond"),new DataColumn("edflow"),new DataColumn("wdflow"),
                   new DataColumn("fedflow"),new DataColumn("cdflow"),new DataColumn("sewerph1"),
                    new DataColumn("sewerph2"), new DataColumn("sewerph3"),
                    new DataColumn("sewerph5"),    new DataColumn("damph1"),
                    new DataColumn("sahotwell"),       new DataColumn("saplantdrain"),
                    new DataColumn("saliftstation"),       new DataColumn("sasurgebasin"),
                    new DataColumn("p2o5catesttank"),       new DataColumn("p2o5casettlerfeed"),
                    new DataColumn("abscatesttank"),       new DataColumn("abscaltp"),
                     new DataColumn("scatesttank"),  new DataColumn("sca4ft"),
                      new DataColumn("scasettlerfd"),  new DataColumn("scaltp"),
                       new DataColumn("fasettler"),  new DataColumn("fawasher"),
                    new DataColumn("famiddle")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_ENVIRONMENTAL
                              where (v.EADATE >= fromDate && v.EADATE <= toDate)
                              orderby v.EADATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.EADATE, vals.RWRPH, vals.EDPH, vals.WDPH, vals.FEDPH,
                     vals.CDPH, vals.OXPOND, vals.EDFLOW, vals.WDFLOW, vals.FEDFLOW,
                     vals.CDFLOW, vals.SEWERPH1, vals.SEWERPH2, vals.SEWERPH3,
                     vals.SEWERPH5, vals.DAMPH1, vals.SAHOTWELL, vals.SAPLANTDRAIN, vals.SALIFTSTATION,
                     vals.SASURGEBASIN, vals.P2O5CATESTTANK, vals.P2O5CASETTLERFEED, vals.ABSCATESTTANK, vals.ABSCALTP,
                     vals.SCATESTTANK, vals.SCA4FT, vals.SCASETTLERFD, vals.SCALTP,
                     vals.FASETTLER, vals.FAWASHER, vals.FAMIDDLE
                    );
                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Environmental.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
        protected void Sec1_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[70] {
                    new DataColumn("sddate"),new DataColumn("sasuf"),new DataColumn("sawuf"),
                    new DataColumn("samtl"),new DataColumn("safa"),new DataColumn("salr"),
                   new DataColumn("gpls1"),new DataColumn("gpls2"),new DataColumn("gpls3"),
                   new DataColumn("gpls4"),new DataColumn("gplsbf"),new DataColumn("gplsoxset"),
                    new DataColumn("sabf"), new DataColumn("saoxset"),
                    new DataColumn("salimerec"),    new DataColumn("sast"),
                    new DataColumn("salp"),       new DataColumn("oaoxset"),
                    new DataColumn("oabf"),       new DataColumn("oa1cake"),
                    new DataColumn("oa2cake"),       new DataColumn("oastseed"),
                    new DataColumn("oa6ab"),       new DataColumn("oapf"),
                     new DataColumn("srsolids"),  new DataColumn("srstarchi"),
                      new DataColumn("srstarchs"),  new DataColumn("srplantfloc"),
                       new DataColumn("taaa4ft"),  new DataColumn("taaasf"),
                       new DataColumn("taaasuf"),  new DataColumn("taaawuf"),
                       new DataColumn("taaamtl"),  new DataColumn("ltpca"),
                       new DataColumn("ltp"),  new DataColumn("spentliq"),
                       new DataColumn("y1516"),  new DataColumn("tridigest"),
                       new DataColumn("ft5"),  new DataColumn("digdisch"),

                        new DataColumn("wp0"),  new DataColumn("wp1"),
                       new DataColumn("wp2"),  new DataColumn("wp3"),
                       new DataColumn("wp4"),  new DataColumn("wp5"),
                       new DataColumn("wp6"),  new DataColumn("wp7"),
                       new DataColumn("wp8"),  new DataColumn("td"),

                       new DataColumn("cpds1"),  new DataColumn("cpds2"),
                       new DataColumn("cpds3"),  new DataColumn("cpds4"),
                       new DataColumn("crettank"),  new DataColumn("apds1"),
                       new DataColumn("apds2"),  new DataColumn("apds3"),
                         new DataColumn("apds4"),  new DataColumn("arettank"),

                       new DataColumn("spds1"),  new DataColumn("spds2"),
                         new DataColumn("spds3"),  new DataColumn("spds4"),
                       new DataColumn("srettank"),  new DataColumn("drettank"),
                         new DataColumn("d1pds"),  new DataColumn("d2pds"),
                       new DataColumn("d3pds"),  new DataColumn("d4pds")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_SEC1_DATA
                              where (v.SDDATE >= fromDate && v.SDDATE <= toDate)
                              orderby v.SDDATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                  
                    table.Rows.Add(vals.SDDATE, 
                        vals.SASUF ?? (object)DBNull.Value,
                        vals.SAWUF ?? (object)DBNull.Value,
                        vals.SAMTL ?? (object)DBNull.Value,
                        vals.SAFA ?? (object)DBNull.Value,
                        vals.SALR ?? (object)DBNull.Value,
                     vals.GPLS1 ?? (object)DBNull.Value,
                     vals.GPLS2 ?? (object)DBNull.Value,
                     vals.GPLS3 ?? (object)DBNull.Value,
                     vals.GPLS4 ?? (object)DBNull.Value,
                     vals.GPLSBF ?? (object)DBNull.Value,
                     vals.GPLSOXSET ?? (object)DBNull.Value,
                     vals.SABF ?? (object)DBNull.Value,
                     vals.SAOXSET ?? (object)DBNull.Value,
                     vals.SALIMEREC ?? (object)DBNull.Value,
                     vals.SAST ?? (object)DBNull.Value,
                     vals.SALP ?? (object)DBNull.Value,
                     vals.OAOXSET ?? (object)DBNull.Value,
                     vals.OABF ?? (object)DBNull.Value,
                     vals.OA1CAKE ?? (object)DBNull.Value,
                     vals.OA2CAKE ?? (object)DBNull.Value,
                     vals.OASTSEED ?? (object)DBNull.Value,
                     vals.OA6AB ?? (object)DBNull.Value,
                     vals.OAPF ?? (object)DBNull.Value,
                     vals.SRS ?? (object)DBNull.Value,
                     vals.SRSTARCHI ?? (object)DBNull.Value,
                     vals.SRSTARCHS ?? (object)DBNull.Value,
                     vals.SRPF ?? (object)DBNull.Value,
                     vals.TAAA4FT ?? (object)DBNull.Value,
                     vals.TAAASF ?? (object)DBNull.Value,
                     vals.TAAASUF ?? (object)DBNull.Value,
                     vals.TAAAWUF ?? (object)DBNull.Value,
                     vals.TAAAMTL ?? (object)DBNull.Value,
                     vals.LTPCA ?? (object)DBNull.Value,
                     vals.LTP ?? (object)DBNull.Value,
                     vals.SPENTLIQ ?? (object)DBNull.Value,
                     vals.Y1516 ?? (object)DBNull.Value,
                     vals.TRIDIGEST ?? (object)DBNull.Value,
                     vals.FT5 ?? (object)DBNull.Value,
                     vals.DIGDISCH ?? (object)DBNull.Value,
                     vals.WP0 ?? (object)DBNull.Value,
                     vals.WP1 ?? (object)DBNull.Value,
                     vals.WP2 ?? (object)DBNull.Value,
                     vals.WP3 ?? (object)DBNull.Value,
                     vals.WP4 ?? (object)DBNull.Value,
                     vals.WP5 ?? (object)DBNull.Value,
                      vals.WP6 ?? (object)DBNull.Value,
                      vals.WP7 ?? (object)DBNull.Value,
                      vals.WP8 ?? (object)DBNull.Value,
                      vals.TD ?? (object)DBNull.Value,
                     vals.CPDS1 ?? (object)DBNull.Value,
                     vals.CPDS2 ?? (object)DBNull.Value,
                     vals.CPDS3 ?? (object)DBNull.Value,
                      vals.CPDS4 ?? (object)DBNull.Value,
                      vals.CRETTANK ?? (object)DBNull.Value,
                      vals.APDS1 ?? (object)DBNull.Value,
                      vals.APDS2 ?? (object)DBNull.Value,
                     vals.APDS3 ?? (object)DBNull.Value,
                     vals.APDS4 ?? (object)DBNull.Value,
                     vals.ARETTANK ?? (object)DBNull.Value,
                      vals.SPDS1 ?? (object)DBNull.Value,
                      vals.SPDS2 ?? (object)DBNull.Value,
                      vals.SPDS3 ?? (object)DBNull.Value,
                      vals.SPDS4 ?? (object)DBNull.Value,
                     vals.SRETTANK ?? (object)DBNull.Value,
                     vals.DRETTANK ?? (object)DBNull.Value,
                     vals.D1PDS ?? (object)DBNull.Value,
                     vals.D2PDS ?? (object)DBNull.Value,
                     vals.D3PDS ?? (object)DBNull.Value,
                     vals.D4PDS ?? (object)DBNull.Value
                    );

                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Sec1.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
        protected void H2O_ExportToExcel(object sender, EventArgs e)
        {


            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[9] {
                    new DataColumn("h2odate"),new DataColumn("h2onorth0000"),new DataColumn("h2onorth0600"),
                    new DataColumn("h2onorth1200"),new DataColumn("h2onorth1800"),new DataColumn("h2osouth0000"),
                   new DataColumn("h2osouth0600"),new DataColumn("h2osouth1200"),new DataColumn("h2osouth1800")});

                LabEntities db = new LabEntities();
                var Values = (from v in db.LAB_H2O_TANK_DATA
                              where (v.H2ODATE >= fromDate && v.H2ODATE <= toDate)
                              orderby v.H2ODATE
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.H2ODATE, vals.H2ONORTH0000, vals.H2ONORTH0600, vals.H2ONORTH1200, vals.H2ONORTH1800,
                     vals.H2OSOUTH0000, vals.H2OSOUTH0600, vals.H2OSOUTH1200, vals.H2OSOUTH1800
                    );
                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=H2OTank.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
        protected void Sec3_ExportToExcel(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(Request.Form["datetimepicker"].ToString());
            DateTime toDate = Convert.ToDateTime(Request.Form["datetimepicker2"].ToString());
            try
            {

                System.Data.DataTable table = new System.Data.DataTable("Grid");
                table.Columns.AddRange(new DataColumn[13] {
                    new DataColumn("secdate"),new DataColumn("secrecord"),new DataColumn("secid"),
                    new DataColumn("p100"),new DataColumn("p200"),new DataColumn("p325"),
                   new DataColumn("caus"),new DataColumn("ac"),new DataColumn("gplsol"),
                   new DataColumn("ht"),new DataColumn("sa"),new DataColumn("um20"),
                    new DataColumn("indx")});

                LabEntities db = new LabEntities();

                var Values = (from v in db.LAB_SEC_III_DATA
                              where (v.SECDATE >= fromDate && v.SECDATE <= toDate) && v.SECID != null
                              orderby v.SECDATE, v.SECRECORD
                              select v).ToList();
                foreach (var vals in Values)
                {
                    table.Rows.Add(vals.SECDATE, vals.SECRECORD, vals.SECID, vals.P100, vals.P200,
                     vals.P325, vals.CAUS, vals.AC, vals.GPLSOL, vals.HT,
                     vals.SA, vals.UM20, vals.INDX);
                }

                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = table;
                GridView1.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Sec3.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each Row
                    GridView1.Rows[i].Attributes.Add("class", "textmode");
                }
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
            }
        }
    }

    //public class DropDownListEventArgs : EventArgs
    //{
    //    public List<string> List;

    //    public void DropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    //    {
    //        List<string> myList = e.List;
    //        return ;
    //    }

    //    public void RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        // ...
    //        DropDownList_SelectedIndexChanged(yourRadioButton, new DropDownListEventArgs()
    //        {
    //            List = yourCreatedList
    //        });
    //    }

    //}
}
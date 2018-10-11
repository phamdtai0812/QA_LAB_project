using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using QA_LAB_project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class DailyAlumina : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
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
                //DateTime? date = null;
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;
                //if (date_ != " ")
                //{
                //    query = "SELECT * from LAB_HYDRATE_ANALYSIS WHERE  HA_TYPE = 'DRY' and SADATE = '" + date_ + "' ";
                //    query += "SELECT * from LAB_HYDRATE_ANALYSIS WHERE  HA_TYPE = 'wet'  and SADATE = '" + date_ + "'";
                //}
                //else
                //{
                //    query = "SELECT * from LAB_HYDRATE_ANALYSIS WHERE HA_TYPE = 'DRY' AND SADATE = (SELECT  MAX(SADATE) FROM LAB_HYDRATE_ANALYSIS) ORDER BY CONTAINERID  ";
                //    query += "SELECT * from LAB_HYDRATE_ANALYSIS WHERE HA_TYPE = 'WET' AND SADATE = (SELECT  MAX(SADATE) FROM LAB_HYDRATE_ANALYSIS) ORDER BY CONTAINERId ";
                //}
                //LEACHSODA
                string date;
                //if (Session["kiln_id"] != null)
                //{  date = Session["kiln_id"].ToString(); }
                //else
                //{
                if (string.IsNullOrEmpty(HttpContext.Current.Session["alumina_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["alumina_date"] = date;
                }
                else
                { date = Session["alumina_date"].ToString(); }
                date_max.Value = date;

                //ALUMINA
                //date = "2018-02-11";
                query = "Select Case name when 'loi' then 'LOI' when 'p100' then '+100' when 'p200' then '+200' when 'p325' then '+325' when 'BULKDENS' THEN 'Bulk Dens' " +
" when 'SI' then 'Si' when 'FE' then 'Fe' when 'NA' then 'Na' when 'ZN' then 'Zn' when 'MN' then 'Mn'  when 'CA' then 'Ca' when 'TI' then 'Ti'" +
" when 'AI' then 'Ai' when 'M20' then '-m20' else name end as 'name'," +
" Case When(value = null) Then NULL Else value End value from(select ISNULL(Convert(varchar(20),[LOI]), ' ')[LOI],ISNULL(Convert(varchar(20),[P100]), ' ')[P100], ISNULL(Convert(varchar(20),[P200]), ' ')[P200]," +
" ISNULL(Convert(varchar(20),[P325]), ' ')[P325], ISNULL(Convert(varchar(20),[BULKDENS]), ' ')[BULKDENS], ISNULL(Convert(varchar(20),[SI]), ' ')[SI], "+
" ISNULL(Convert(varchar(20),[FE]), ' ')[FE], ISNULL(Convert(varchar(20),[NA]), ' ')[NA], ISNULL(Convert(varchar(20),[ZN]), ' ')[ZN], " +
 " ISNULL(Convert(varchar(20),[MN]), ' ')[MN], ISNULL(Convert(varchar(20),[CA]), ' ')[CA], ISNULL(Convert(varchar(20),[TI]), ' ')[TI], " +
 " ISNULL(Convert(varchar(20),[AI]), ' ')[AI], ISNULL(Convert(varchar(20),[M20]), ' ')[M20]" +
        " From LAB_DAILYANALYSIS" +
 " WHERE DADATE = '" + date + "' AND PRODUCT = 'ALUMINA') As pvttask UnPivot(value for name In ( [LOI], [P100], [P200], [P325], [BULKDENS]," +
 " [SI], [FE], [NA], [ZN], [MN], [CA], [TI],  [AI], [M20])) a  ";

           
                //HYDRATE
                query += " Select Case name when 'p100' then '+100' when 'p200' then '+200' when 'p325' then '+325' when 'SI' then 'Si' when 'FE' then 'Fe'" +
                         " when 'NA' then 'Na' when 'ZN' then 'Zn' when 'MN' then 'Mn' when 'CA' then 'Ca' when 'TI' then 'Ti' when 'AI' then 'Ai' else name end as 'name'," +
                         " Case When(value = null) Then NULL Else value End value from(select ISNULL(Convert(varchar(20),[P100]), ' ')[P100], ISNULL(Convert(varchar(20),[P200]), ' ')[P200], " +
						  " ISNULL(Convert(varchar(20),[P325]), ' ')[P325]," +
                         " ISNULL(Convert(varchar(20),[SI]), ' ')[SI], ISNULL(Convert(varchar(20),[FE]), ' ')[FE], ISNULL(Convert(varchar(20),[NA]), ' ')[NA], "+
						 " ISNULL(Convert(varchar(20),[ZN]), ' ')[ZN],  ISNULL(Convert(varchar(20),[MN]), ' ')[MN],  ISNULL(Convert(varchar(20),[CA]), ' ')[CA],  "+
						 " ISNULL(Convert(varchar(20),[TI]), ' ')[TI], " +
                          " ISNULL(Convert(varchar(20),[AI]), ' ')[AI] From LAB_DAILYANALYSIS WHERE DADATE = '" + date + "' AND PRODUCT = 'HYDRATE') As pvttask " +
                          " UnPivot(value for name In (  [P100], [P200], [P325], [SI], [FE], [NA], [ZN], [MN], [CA], [TI],  [AI])) a ";

                query += " Select Case name when 'FREEMOIST' then 'Free Moisture' when 'CSEDS' then 'C. Seds'  when 'BULKDENS' then 'Bulk Dens' when 'INSOLS' THEN 'Insols'" +
                        " when 'HUNTERL' then 'Hunter L' when 'HUNTERA' then 'Hunter A' when 'HUNTERB' then 'Hunter B' else name end as 'name', Case When(value = null) Then " +
                        " NULL Else value End value from( select ISNULL(Convert(varchar(20),[FREEMOIST]), ' ')[FREEMOIST],  ISNULL(Convert(varchar(20),[CSEDS]), ' ')[CSEDS], "+
						 " ISNULL(Convert(varchar(20),[Insols]), ' ')[Insols], ISNULL(Convert(varchar(20),[BULKDENS]), ' ') " +
                        " [BULKDENS], ISNULL(Convert(varchar(20),[HUNTERL]), ' ')[HUNTERL], ISNULL(Convert(varchar(20),[HUNTERA]), ' ')[HUNTERA], "+
						" ISNULL(Convert(varchar(20),[HUNTERB]), ' ')[HUNTERB]  From LAB_DAILYANALYSIS WHERE DADATE = '" + date + "'  " +
                        " AND PRODUCT = 'HYDRATE') As pvttask UnPivot(value for name In (  [FREEMOIST], [CSEDS], INSOLS, [BULKDENS], [HUNTERL], [HUNTERA], [HUNTERB])) a";
             
             
                //WETHYDRATE
                string query2 = "Select Case name when 'p100' then '+100' when 'p200' then '+200' when 'p325' then '+325' when 'SI' then 'Si' when 'FE' then 'Fe' when 'CSEDS' then 'C. Seds'   when 'INSOLS' THEN 'Insols'" +
           " when 'NA' then 'Na' when 'ZN' then 'Zn' when 'MN' then 'Mn' when 'CA' then 'Ca' when 'TI' then 'Ti' else name end as 'name'," +
           " Case When(value = null) Then NULL Else value End value from( select ISNULL(Convert(varchar(20),[P100]), ' ')[P100],  ISNULL(Convert(varchar(20),[P200]), ' ')[P200], "+
		" ISNULL(Convert(varchar(20),[P325]), ' ')[P325], ISNULL(Convert(varchar(20),[CSEDS]), ' ')[CSEDS], ISNULL(Convert(varchar(20),[Insols]), ' ')[Insols], " +
            " ISNULL(Convert(varchar(20),[SI]), ' ')[SI], ISNULL(Convert(varchar(20),[FE]), ' ')[FE], ISNULL(Convert(varchar(20),[NA]), ' ')[NA], ISNULL(Convert(varchar(20),[ZN]), ' ')[ZN], "+ 
			" ISNULL(Convert(varchar(20),[MN]), ' ')[MN], ISNULL(Convert(varchar(20),[CA]), ' ')[CA], ISNULL(Convert(varchar(20),[TI]), ' ')[TI] " +
             "  From LAB_DAILYANALYSIS WHERE DADATE = '" + date + "' AND PRODUCT = 'WETHYDRATE') As pvttask " +
             " UnPivot(value for name In (  [P100], [P200], [P325], [SI], [FE], [NA], [ZN], [MN], [CA], [TI], [CSEDS], [INSOLS] )) a ";

                query2 += "Select Case name when 'CSEDS' then 'C. Seds'   when 'INSOLS' THEN 'Insols'" +
                        " else name end as 'name', Case When(value = null) Then " +
                        " NULL Else value End value from( select  ISNULL(Convert(varchar(20),[CSEDS]), ' ')[CSEDS], ISNULL(Convert(varchar(20),[Insols]), ' ')[Insols] " +
                        "   From LAB_DAILYANALYSIS WHERE DADATE = '" + date + "'  " +
                        " AND PRODUCT = 'WETHYDRATE') As pvttask UnPivot(value for name In (   [CSEDS], INSOLS)) a";

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

                        gv_alumina.DataSource = ds.Tables[0];
                        gv_alumina.DataBind();
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_hydrate1.DataSource = ds.Tables[1];
                        gv_hydrate1.DataBind();
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gv_hydrate2.DataSource = ds.Tables[2];
                        gv_hydrate2.DataBind();


                    }

              
                }



                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand(query2);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv_wethydrate1.DataSource = ds.Tables[0];
                        gv_wethydrate1.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //gv_wethydrate2.DataSource = ds.Tables[1];
                        //gv_wethydrate2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {
            //string strdate = HttpContext.Current.Session["kiln_date"].ToString();
            //var date_ = DateTime.ParseExact(strdate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
            //date_.ToShortDateString();
            //string r1c1; string r1c2; string r1c3; string CaO;
            try
            {
                //gv_alumina
                DataTable dt_alumina = new DataTable();
                dt_alumina.Columns.Add("name", typeof(string));
                dt_alumina.Columns.Add("value", typeof(string));

                foreach (GridViewRow rows in gv_alumina.Rows)
                {
                
                    var row = dt_alumina.NewRow();
                    dt_alumina.Rows.Add(row);

                    System.Web.UI.WebControls.Label lblalumina = (System.Web.UI.WebControls.Label)rows.FindControl("lbl_alumina");
                    string name = lblalumina.Text;
                    System.Web.UI.WebControls.TextBox txtboxalumina = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_alumina");
                    string value = txtboxalumina.Text;
                 
                    row["name"] = name;
                    row["value"] = value;
                  
                }
                Update("ALUMINA", dt_alumina);
                ////////////////

                //gv_HYDRATE
                DataTable dt_hydrate = new DataTable();
            
                dt_hydrate.Columns.Add("value", typeof(string));

                foreach (GridViewRow rows in gv_hydrate1.Rows)
                {
                    var row = dt_hydrate.NewRow();
                    dt_hydrate.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox txtboxhydrate1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate1");
                    string value = txtboxhydrate1.Text;
                    row["value"] = value;
                }
                foreach (GridViewRow rows in gv_hydrate2.Rows)
                {
                    var row = dt_hydrate.NewRow();
                    dt_hydrate.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox txtboxhydrate2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate2");
                    string value = txtboxhydrate2.Text;
                    row["value"] = value;
                }
                Update("HYDRATE", dt_hydrate);
                /////////////////////

                //Wethydrate
                DataTable dt_wethydrate = new DataTable();

                dt_wethydrate.Columns.Add("value", typeof(string));

                foreach (GridViewRow rows in gv_wethydrate1.Rows)
                {
                    var row = dt_wethydrate.NewRow();
                    dt_wethydrate.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox txtboxwethydrate1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate1");
                    string value = txtboxwethydrate1.Text;
                    row["value"] = value;
                }
                //foreach (GridViewRow rows in gv_wethydrate2.Rows)
                //{
                //    var row = dt_wethydrate.NewRow();
                //    dt_wethydrate.Rows.Add(row);
                //    System.Web.UI.WebControls.TextBox txtboxwethydrate2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate2");
                //    string value = txtboxwethydrate2.Text;
                //    row["value"] = value;
                //}
                Update("WETHYDRATE", dt_wethydrate);

                gvBind();

                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {

            }
        }
        public void Update(string Product, DataTable dt)
        {
            string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            try
            {
                if (Product == "ALUMINA")
                {
                    using (SqlConnection con = new SqlConnection(strConnString))
                    {
                        SqlCommand cmd = new SqlCommand("LAB_sp_daily_alumina", con);
                        SqlDataAdapter sda = new SqlDataAdapter();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DATE", SqlDbType.Date).Value = Session["alumina_date"].ToString();
                        cmd.Parameters.AddWithValue("@PRODUCT", SqlDbType.VarChar).Value = _PRODUCT;
                        cmd.Parameters.AddWithValue("@LOI", SqlDbType.VarChar).Value = dt.Rows[0]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P100", SqlDbType.VarChar).Value = dt.Rows[1]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P200", SqlDbType.VarChar).Value = dt.Rows[2]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P325", SqlDbType.VarChar).Value = dt.Rows[3]["value"].ToString();
                        cmd.Parameters.AddWithValue("@BULKDENS", SqlDbType.VarChar).Value = dt.Rows[4]["value"].ToString();
                        cmd.Parameters.AddWithValue("@SI", SqlDbType.VarChar).Value = dt.Rows[5]["value"].ToString();
                        cmd.Parameters.AddWithValue("@FE", SqlDbType.VarChar).Value = dt.Rows[6]["value"].ToString();
                        cmd.Parameters.AddWithValue("@NA", SqlDbType.VarChar).Value = dt.Rows[7]["value"].ToString();
                        cmd.Parameters.AddWithValue("@ZN", SqlDbType.VarChar).Value = dt.Rows[8]["value"].ToString();
                        cmd.Parameters.AddWithValue("@MN", SqlDbType.VarChar).Value = dt.Rows[9]["value"].ToString();
                        cmd.Parameters.AddWithValue("@CA", SqlDbType.VarChar).Value = dt.Rows[10]["value"].ToString();
                        cmd.Parameters.AddWithValue("@TI", SqlDbType.VarChar).Value = dt.Rows[11]["value"].ToString();
                        cmd.Parameters.AddWithValue("@AI", SqlDbType.VarChar).Value = dt.Rows[12]["value"].ToString();
                        cmd.Parameters.AddWithValue("@M20", SqlDbType.VarChar).Value = dt.Rows[13]["value"].ToString();


                        con.Open();
                        cmd.ExecuteNonQuery();
                        PiInsert(Product, dt);
                    }
                }
                else if (Product == "HYDRATE")
                {
                    using (SqlConnection con = new SqlConnection(strConnString))
                    {
                        SqlCommand cmd = new SqlCommand("LAB_sp_daily_alumina", con);
                        SqlDataAdapter sda = new SqlDataAdapter();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DATE", SqlDbType.Date).Value = Session["alumina_date"].ToString();
                        cmd.Parameters.AddWithValue("@PRODUCT", SqlDbType.VarChar).Value = _PRODUCT;
                        cmd.Parameters.AddWithValue("@P100", SqlDbType.VarChar).Value = dt.Rows[0]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P200", SqlDbType.VarChar).Value = dt.Rows[1]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P325", SqlDbType.VarChar).Value = dt.Rows[2]["value"].ToString();
                        cmd.Parameters.AddWithValue("@SI", SqlDbType.VarChar).Value = dt.Rows[3]["value"].ToString();
                        cmd.Parameters.AddWithValue("@FE", SqlDbType.VarChar).Value = dt.Rows[4]["value"].ToString();
                        cmd.Parameters.AddWithValue("@NA", SqlDbType.VarChar).Value = dt.Rows[5]["value"].ToString();
                        cmd.Parameters.AddWithValue("@ZN", SqlDbType.VarChar).Value = dt.Rows[6]["value"].ToString();
                        cmd.Parameters.AddWithValue("@MN", SqlDbType.VarChar).Value = dt.Rows[7]["value"].ToString();
                        cmd.Parameters.AddWithValue("@CA", SqlDbType.VarChar).Value = dt.Rows[8]["value"].ToString();
                        cmd.Parameters.AddWithValue("@TI", SqlDbType.VarChar).Value = dt.Rows[9]["value"].ToString();
                        cmd.Parameters.AddWithValue("@AI", SqlDbType.VarChar).Value = dt.Rows[10]["value"].ToString();
                        cmd.Parameters.AddWithValue("@FREEMOIST", SqlDbType.VarChar).Value = dt.Rows[11]["value"].ToString();
                        cmd.Parameters.AddWithValue("@CSEDS", SqlDbType.VarChar).Value = dt.Rows[12]["value"].ToString();
                        cmd.Parameters.AddWithValue("@INSOLS", SqlDbType.VarChar).Value = dt.Rows[13]["value"].ToString();
                        cmd.Parameters.AddWithValue("@BULKDENS", SqlDbType.VarChar).Value = dt.Rows[14]["value"].ToString();
                        cmd.Parameters.AddWithValue("@HUNTERL", SqlDbType.VarChar).Value = dt.Rows[15]["value"].ToString();
                        cmd.Parameters.AddWithValue("@HUNTERA", SqlDbType.VarChar).Value = dt.Rows[16]["value"].ToString();
                        cmd.Parameters.AddWithValue("@HUNTERB", SqlDbType.VarChar).Value = dt.Rows[17]["value"].ToString();

                        con.Open();
                        cmd.ExecuteNonQuery();
                       
                       PiInsert(Product, dt);
                    }
                }
                else if (Product =="WETHYDRATE")
                {
                    using (SqlConnection con = new SqlConnection(strConnString))
                    {
                        SqlCommand cmd = new SqlCommand("LAB_sp_daily_alumina", con);
                        SqlDataAdapter sda = new SqlDataAdapter();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DATE", SqlDbType.Date).Value = Session["alumina_date"].ToString();
                        cmd.Parameters.AddWithValue("@PRODUCT", SqlDbType.VarChar).Value = _PRODUCT;
                        cmd.Parameters.AddWithValue("@P100", SqlDbType.VarChar).Value = dt.Rows[0]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P200", SqlDbType.VarChar).Value = dt.Rows[1]["value"].ToString();
                        cmd.Parameters.AddWithValue("@P325", SqlDbType.VarChar).Value = dt.Rows[2]["value"].ToString();
                        cmd.Parameters.AddWithValue("@SI", SqlDbType.VarChar).Value = dt.Rows[3]["value"].ToString();
                        cmd.Parameters.AddWithValue("@FE", SqlDbType.VarChar).Value = dt.Rows[4]["value"].ToString();
                        cmd.Parameters.AddWithValue("@NA", SqlDbType.VarChar).Value = dt.Rows[5]["value"].ToString();
                        cmd.Parameters.AddWithValue("@ZN", SqlDbType.VarChar).Value = dt.Rows[6]["value"].ToString();
                        cmd.Parameters.AddWithValue("@MN", SqlDbType.VarChar).Value = dt.Rows[7]["value"].ToString();
                        cmd.Parameters.AddWithValue("@CA", SqlDbType.VarChar).Value = dt.Rows[8]["value"].ToString();
                        cmd.Parameters.AddWithValue("@TI", SqlDbType.VarChar).Value = dt.Rows[9]["value"].ToString();
                        cmd.Parameters.AddWithValue("@CSEDS", SqlDbType.VarChar).Value = dt.Rows[10]["value"].ToString();
                        cmd.Parameters.AddWithValue("@INSOLS", SqlDbType.VarChar).Value = dt.Rows[11]["value"].ToString();
                        con.Open();
                        cmd.ExecuteNonQuery();

                        PiInsert(Product, dt);
                    }
                }
            }
            catch (Exception exc)
            {
            }
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
        public void PiInsert(string Product, DataTable dt)
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
                                 orderby v.Id
                                 select v).Skip(39).Take(44);

                var date = Convert.ToDateTime(Session["alumina_date"].ToString());

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

                //type is not feed moisture
                if (Product == "ALUMINA")
                {

                    //string s = type.Substring(0, type.Length - 4);
                    //string input = type.Substring(type.Length - 4);
                    //int time = Convert.ToInt16(input.TrimEnd('0'));
                    //DateTime datetime;
                    //TimeSpan ts;
                    //if (time == 24)
                    //{
                    //    ts = new TimeSpan(23, 59, 59);
                    //}
                    //else ts = new TimeSpan(time, 0, 0);


                    //datetime = date + ts;

                    //decimal? s = (decimal?)null;
                    //bool nulloremtpy = string.IsNullOrWhiteSpace(dt.Rows[0]["value"].ToString());

                    piTagValues.Add("LABALUMINA_LOI", string.IsNullOrWhiteSpace(dt.Rows[0]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_P100", string.IsNullOrWhiteSpace(dt.Rows[1]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[1]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_P200", string.IsNullOrWhiteSpace(dt.Rows[2]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[2]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_P325", string.IsNullOrWhiteSpace(dt.Rows[3]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[3]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_BULKDENS", string.IsNullOrWhiteSpace(dt.Rows[4]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[4]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_SI", string.IsNullOrWhiteSpace(dt.Rows[5]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[5]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_FE", string.IsNullOrWhiteSpace(dt.Rows[6]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[6]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_NA", string.IsNullOrWhiteSpace(dt.Rows[7]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[7]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_ZN", string.IsNullOrWhiteSpace(dt.Rows[8]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[8]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_MN", string.IsNullOrWhiteSpace(dt.Rows[9]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[9]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_CA", string.IsNullOrWhiteSpace(dt.Rows[10]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[10]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_TI", string.IsNullOrWhiteSpace(dt.Rows[11]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[11]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_AI", string.IsNullOrWhiteSpace(dt.Rows[12]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[12]["value"].ToString()));
                    piTagValues.Add("LABALUMINA_M20", string.IsNullOrWhiteSpace(dt.Rows[13]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[13]["value"].ToString()));


                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {
                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Value = Convert.ToString(entry.Value);

                                //string ctv = currentTag.Value.ToString();
                                //DateTime cttimestamp = currentTag.Timestamp;
                                //DateTime d = cttimestamp.Date;
                                currentTag.Timestamp = date.AddHours(diff);



                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    //if (ctv != null && d != date)
                                    //{
                                       
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    //}
                                    //else
                                    //{
                                    //    currentTag.Timestamp = date.AddHours(diff);
                                    //    myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);
                                    //}

                                }

                            }

                        }
                    }
                }
                else if (Product == "HYDRATE")
                {

                  
                    piTagValues.Add("LABHYDRATE_P100", string.IsNullOrWhiteSpace(dt.Rows[0]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_P200", string.IsNullOrWhiteSpace(dt.Rows[1]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[1]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_P325", string.IsNullOrWhiteSpace(dt.Rows[2]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[2]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_SI", string.IsNullOrWhiteSpace(dt.Rows[3]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[3]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_FE", string.IsNullOrWhiteSpace(dt.Rows[4]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[4]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_NA", string.IsNullOrWhiteSpace(dt.Rows[5]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[5]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_ZN", string.IsNullOrWhiteSpace(dt.Rows[6]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[6]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_MN", string.IsNullOrWhiteSpace(dt.Rows[7]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[7]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_CA", string.IsNullOrWhiteSpace(dt.Rows[8]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[8]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_TI", string.IsNullOrWhiteSpace(dt.Rows[9]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[9]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_AI", string.IsNullOrWhiteSpace(dt.Rows[10]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[10]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_FREEMOIST", string.IsNullOrWhiteSpace(dt.Rows[11]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[11]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_CSEDS", string.IsNullOrWhiteSpace(dt.Rows[12]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[12]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_INSOLS", string.IsNullOrWhiteSpace(dt.Rows[13]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[13]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_BULKDENS", string.IsNullOrWhiteSpace(dt.Rows[14]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[14]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_HUNTERL", string.IsNullOrWhiteSpace(dt.Rows[15]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[15]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_HUNTERA", string.IsNullOrWhiteSpace(dt.Rows[16]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[16]["value"].ToString()));
                    piTagValues.Add("LABHYDRATE_HUNTERB", string.IsNullOrWhiteSpace(dt.Rows[17]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[17]["value"].ToString()));

                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {
                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  // use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Value = Convert.ToString(entry.Value);

                                //string ctv = currentTag.Value.ToString();
                                //DateTime cttimestamp = currentTag.Timestamp;
                                //DateTime d = cttimestamp.Date;

                                currentTag.Timestamp = date.AddHours(diff);


                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    //if (ctv != null && d != date)
                                    //{

                                    //    currentTag.Timestamp = date.AddHours(diff);
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                //    }
                                //    else
                                //    {

                                //        currentTag.Timestamp = date.AddHours(diff);
                                //        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);
                                //    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    piTagValues.Add("LABWETHYDRATE_P100", string.IsNullOrWhiteSpace(dt.Rows[0]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_P200", string.IsNullOrWhiteSpace(dt.Rows[1]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[1]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_P325", string.IsNullOrWhiteSpace(dt.Rows[2]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[2]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_SI", string.IsNullOrWhiteSpace(dt.Rows[3]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[3]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_FE", string.IsNullOrWhiteSpace(dt.Rows[4]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[4]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_NA", string.IsNullOrWhiteSpace(dt.Rows[5]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[5]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_ZN", string.IsNullOrWhiteSpace(dt.Rows[6]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[6]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_MN", string.IsNullOrWhiteSpace(dt.Rows[7]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[7]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_CA", string.IsNullOrWhiteSpace(dt.Rows[8]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[8]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_TI", string.IsNullOrWhiteSpace(dt.Rows[9]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[9]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_CSEDS", string.IsNullOrWhiteSpace(dt.Rows[10]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[10]["value"].ToString()));
                    piTagValues.Add("LABWETHYDRATE_INSOLS", string.IsNullOrWhiteSpace(dt.Rows[11]["value"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[11]["value"].ToString()));
                  
                 
                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {
                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                               // PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  // use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Value = Convert.ToString(entry.Value);

                                //string ctv = currentTag.Value.ToString();
                                //DateTime cttimestamp = currentTag.Timestamp;
                                //DateTime d = cttimestamp.Date;


                                currentTag.Timestamp = date.AddHours(diff);

                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    //if (ctv != null && d != date)
                                    //{
                                        
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    //}
                                    //else
                                    //{
                                    //    currentTag.Timestamp = date.AddHours(diff);
                                    //    myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);
                                    //}

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
        protected void gv_hydrate1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    TextBox txtZip = (TextBox)e.Row.FindControl("txtbox_hydrate1");

                    //int i = e.Row.RowIndex * 8;// here 8 is number of control


                    txtZip.Attributes.Add("tabindex", (1).ToString());

                }
                catch
                {

                }
              }
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {

            HttpContext.Current.Session["alumina_date"] = selDate;
            return selDate;
        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["alumina_date"] != null)
                dt = HttpContext.Current.Session["alumina_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT DADATE   FROM [Lab].[dbo].[LAB_DAILYANALYSIS] WHERE DADATE = '" + dt + "'";
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
                    gvBind();


                }
            }
        }
        public void createNewRow(string dt)
        {
            string sql = "insert into LAB_DAILYANALYSIS (DADATE, PRODUCT) VALUES ('" + dt + "', 'ALUMINA')";
            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                    sql = "insert into LAB_DAILYANALYSIS (DADATE, PRODUCT) VALUES ('" + dt + "', 'HYDRATE')";
                else if ( i == 2)
                    sql = "insert into LAB_DAILYANALYSIS(DADATE, PRODUCT) VALUES('" + dt + "', 'WETHYDRATE')";
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
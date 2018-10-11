using QA_LAB_project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class HydrateAnalysis : System.Web.UI.Page
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
                loadData();



            }

        }
        public void loadData()
        {
            try
            {
                //DateTime? date = null;
                String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                string query;

                string date;
                if (string.IsNullOrEmpty(HttpContext.Current.Session["hydrate_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["hydrate_date"] = date;
                }
                else
                { date = Session["hydrate_date"].ToString(); }
                date_max.Value = date;

                //date = "02-17-2018";
                query = "SELECT * from LAB_HYDRATE_ANALYSIS WHERE  HA_TYPE = 'DRY' and SADATE = '" + date + "' ";
                query += "SELECT * from LAB_HYDRATE_ANALYSIS WHERE  HA_TYPE = 'WET'  and SADATE = '" + date + "'";


                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand(query);
                    SqlDataAdapter sda = new SqlDataAdapter();

                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ViewState["CurrentTable"] = ds.Tables[0];
                 
                    gvHydrate.DataSource = ds.Tables[0];
                    gvHydrate.DataBind();
                    gvHydrate.Columns[0].Visible = false;
                    gvWetHydrate.DataSource = ds.Tables[1];
                    gvWetHydrate.DataBind();
                    gvWetHydrate.Columns[0].Visible = false;

                }
            }
            catch (Exception ex)
            {
                string s = "ss";
            }

        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["hydrate_date"] != null)
                dt = HttpContext.Current.Session["hydrate_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT SADATE   FROM [Lab].[dbo].[LAB_HYDRATE_ANALYSIS] WHERE SADATE = '" + dt + "'";
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
            DateTime date = Convert.ToDateTime(dt);
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_hydrate_analysis", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            HttpContext.Current.Session["hydrate_date"] = selDate;

            return selDate;

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetNames(string pre)
       {
            List<string> all = new List<string>();
            LabEntities db = new LabEntities();
           
                all = (from a in db.LAB_HYDRATE_ANALYSIS
                                  where a.CONTAINERID.StartsWith(pre)
                                  select a.CONTAINERID).Take(1).ToList();

            string stritem="";
            foreach(var item in all)
            {

                stritem = item.Substring(0, item.IndexOf(' '));
               
            }
            all.Add(stritem);
            all.RemoveAt(0);
            return all;
        }
        public static DataTable GenerateTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("HYDRATE_ID", typeof(string));
            dt.Columns.Add("CONTAINERID", typeof(string));
            dt.Columns.Add("REFLECTANCE", typeof(string));
            dt.Columns.Add("LEACHSODA", typeof(string));
            dt.Columns.Add("MOISTURE", typeof(string));
            dt.Columns.Add("SADATE", typeof(string));
            return dt;
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = GenerateTable();
              

                foreach (GridViewRow rows in gvHydrate.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate_containerid");
                    string tbox = txtbox.Text;
                    if (tbox != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.TextBox txtbox0 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydratedate");
                        string a = txtbox0.Text;
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_hydrate_id");
                        string a1 = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate_containerid");
                        string a2 = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate_ref");
                        string a3 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_hydrate_lsoda");
                        string a4 = txtbox4.Text;
                        row["SADATE"] = a;
                        row["HYDRATE_ID"] = a1;
                        row["CONTAINERID"] = a2;
                        row["REFLECTANCE"] = a3;
                        row["LEACHSODA"] = a4;

                      
                    }
                }
                if (dt.Rows != null)
                {
                    Update(dt);
                   
                }

                dt.Clear();
                foreach (GridViewRow rows in gvWetHydrate.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbox = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate_containerid");
                    string tbox = txtbox.Text;
                    if (tbox != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.TextBox txtbox0 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydratedate");
                        string a = txtbox0.Text;
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_wethydrate_id");
                        string a1 = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate_containerid");
                        string a2 = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate_ref");
                        string a3 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate_lsoda");
                        string a4 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_wethydrate_moisture");
                        string a5 = txtbox5.Text;

                        row["SADATE"] = a;
                        row["HYDRATE_ID"] = a1;
                        row["CONTAINERID"] = a2;
                        row["REFLECTANCE"] = a3;
                        row["LEACHSODA"] = a4;
                        row["MOISTURE"] = a5;
                        
                    }
                }
                if (dt.Rows != null)
                {
                    Update(dt);

                }



                loadData();
                
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
                SqlCommand cmd = new SqlCommand("LAB_sp_hydrate_analysis", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HYDRATE_ID", SqlDbType.Int).Value = Convert.ToInt64(dt.Rows[i]["HYDRATE_ID"].ToString());
                //cmd.Parameters.AddWithValue("@SADATE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["SADATE"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["SADATE"].ToString();
               cmd.Parameters.AddWithValue("@CONTAINERID", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["CONTAINERID"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["CONTAINERID"].ToString();
               cmd.Parameters.AddWithValue("@REFLECTANCE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["REFLECTANCE"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["REFLECTANCE"].ToString();
                cmd.Parameters.AddWithValue("@LEACHSODA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["LEACHSODA"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["LEACHSODA"].ToString();
                  cmd.Parameters.AddWithValue("@MOISTURE", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["MOISTURE"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["MOISTURE"].ToString();
                con.Open();
                cmd.ExecuteNonQuery();
            }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
    }

        private void AddNewRowToGrid()

        {

            int rowIndex = 0;



            if (ViewState["CurrentTable"] != null)

            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)

                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)

                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)gvHydrate.Rows[rowIndex].Cells[0].FindControl("txtbox_hydratedate");

                        TextBox box2 = (TextBox)gvHydrate.Rows[rowIndex].Cells[1].FindControl("txtbox_hydrate_containerid");

                        TextBox box3 = (TextBox)gvHydrate.Rows[rowIndex].Cells[2].FindControl("txtbox_hydrate_ref");

                        TextBox box4 = (TextBox)gvHydrate.Rows[rowIndex].Cells[3].FindControl("txtbox_hydrate_lsoda");

                        drCurrentRow = dtCurrentTable.NewRow();

                        //drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["SADATE"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["CONTAINERID"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["REFLECTANCE"] = box3.Text;

                        dtCurrentTable.Rows[i - 1]["LEACHSODA"] = box4.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    gvHydrate.DataSource = dtCurrentTable;

                    gvHydrate.DataBind();

                }

            }

            else

            {

                Response.Write("ViewState is null");

            }

           // 

            //Set Previous Data on Postbacks

            SetPreviousData();
            //this.Response.Redirect(this.Request.Url.ToString());

        }
        public void SetPreviousData()

        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)

            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];

                if (dt.Rows.Count > 0)

                {

                    for (int i = 0; i < dt.Rows.Count; i++)

                    {

                        TextBox box1 = (TextBox)gvHydrate.Rows[rowIndex].Cells[0].FindControl("txtbox_hydratedate");

                        TextBox box2 = (TextBox)gvHydrate.Rows[rowIndex].Cells[1].FindControl("txtbox_hydrate_containerid");

                        TextBox box3 = (TextBox)gvHydrate.Rows[rowIndex].Cells[2].FindControl("txtbox_hydrate_ref");

                        TextBox box4 = (TextBox)gvHydrate.Rows[rowIndex].Cells[3].FindControl("txtbox_hydrate_lsoda");


                        box1.Text = dt.Rows[i]["SADATE"].ToString();

                        box2.Text = dt.Rows[i]["CONTAINERID"].ToString();

                        box3.Text = dt.Rows[i]["REFLECTANCE"].ToString();
                        box4.Text = dt.Rows[i]["LEACHSODA"].ToString();


                        rowIndex++;

                       
                    }

                }

            }

        }
        protected static DataTable CreateDataTable(List<string> Array, string type)
        {
            //try
            //{
            if (type == "DRY")
            {

                DataTable hydrateDatatable = new DataTable();
                hydrateDatatable.Columns.Add("id", typeof(string));
                hydrateDatatable.Columns.Add("date", typeof(string));
                hydrateDatatable.Columns.Add("reflectance", typeof(string));
                hydrateDatatable.Columns.Add("leachsoda", typeof(string));
                for (int i = 0; i < (Array.Count) / 4; i++)
                {
                    if (i > 0)
                    {
                        i = 4 * i;

                    }
                    var row = hydrateDatatable.NewRow();
                    hydrateDatatable.Rows.Add(row);
                    row["id"] = Array[i];
                    row["date"] = Array[i + 1];
                    row["reflectance"] = Array[i + 2]; ;
                    row["leachsoda"] = Array[i + 3];

                    if (i > 0)
                    {
                        i = (i) / 4;
                    }
                }
                return hydrateDatatable;
            }
            else
            {
                DataTable wethydrateDatatable = new DataTable();
                wethydrateDatatable.Columns.Add("id", typeof(string));
                wethydrateDatatable.Columns.Add("date", typeof(string));
                wethydrateDatatable.Columns.Add("reflectance", typeof(string));
                wethydrateDatatable.Columns.Add("leachsoda", typeof(string));
                wethydrateDatatable.Columns.Add("moisture", typeof(string));

                var row = wethydrateDatatable.NewRow();
                for (int i = 0; i < ((Array.Count) / 5); i++)
                {

                    if (i > 0)
                    {
                        i = 5 * i;
                    }
                    row = wethydrateDatatable.NewRow();
                    row["id"] = Array[i];
                    row["date"] = Array[i + 1];
                    row["reflectance"] = Array[i + 2]; ;
                    row["leachsoda"] = Array[i + 3];
                    row["moisture"] = Array[i + 4];

                    wethydrateDatatable.Rows.Add(row);
                    if (i > 0)
                    {
                        i = (i) / 5;
                    }

                }

                return wethydrateDatatable;
            }
            //}
            //catch (Exception excp)
            //{

            //}

        }
        protected void InsertData(DataTable dt, string ha_type)
        {
            try
            {
                string sql = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (ha_type == "DRY")
                    {
                        sql = sql + "insert into LAB_HYDRATE_ANALYSIS (CONTAINERID, SADATE, REFLECTANCE, LEACHSODA, HA_TYPE) values('"
                              + dt.Rows[i]["id"].ToString().Trim() + "','"
                              + dt.Rows[i]["date"].ToString().Trim() + "','"
                              + dt.Rows[i]["reflectance"].ToString().Trim() + "','"
                              + dt.Rows[i]["leachsoda"].ToString().Trim() + "','"
                              + ha_type + "')";
                    }
                    else
                    {
                        sql = sql + "insert into LAB_HYDRATE_ANALYSIS (CONTAINERID, SADATE, REFLECTANCE, LEACHSODA, MOISTURE, HA_TYPE) values('"
                            + dt.Rows[i]["id"].ToString().Trim() + "','"
                            + dt.Rows[i]["date"].ToString().Trim() + "','"
                            + dt.Rows[i]["reflectance"].ToString().Trim() + "','"
                            + dt.Rows[i]["leachsoda"].ToString().Trim() + "','"
                            + dt.Rows[i]["moisture"].ToString().Trim() + "','"
                            + ha_type + "')";
                    }

                }

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
            catch (Exception exc)
            {

            }
            ///////////
        }
   
    }
}
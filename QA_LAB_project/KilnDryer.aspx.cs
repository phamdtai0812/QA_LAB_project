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
using System.Windows.Forms;

using OSIsoft.AF.PI;
using OSIsoft.AF;
using OSIsoft.AF.Time;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using QA_LAB_project.Models;
using System.Net;

namespace QA_LAB_project
{
    public partial class KilnDryer : System.Web.UI.Page
    {
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        string type;
        string @par1; string @par2; string @par3; string @par4;
        protected void Page_Load(object sender, EventArgs e)
        {
            //role.Value = Session["Role"].ToString();

            HttpCookie _userRole = Request.Cookies["UserRole"];
            if (_userRole != null)
            {
                role.Value = _userRole["role"];
            }
            if (!this.IsPostBack)
            {
                //if (HttpContext.Current.Session["ha_date"] != null)
                //{
                //    loadData(HttpContext.Current.Session["ha_date"].ToString());
                //}

                //else
                //{
                insertNewRow();
                gvBind();
                //}
            }
            else
            {
                insertNewRow();
                //if (HttpContext.Current.Session["ha_date"] != null && Session["ha_savedt"] != null)
                //{
                //    loadData(HttpContext.Current.Session["ha_date"].ToString());
                //}
            }
        }

        //protected void OnCheckedChanged(object sender, EventArgs e)
        //{
        //    bool isUpdateVisible = false;
        //    //CheckBox chk = (sender as CheckBox);
        //    //if (chk.ID == "chkAll")
        //    {
        //        foreach (GridViewRow row in gv_kfls.Rows)
        //        {
        //            if (row.RowType == DataControlRowType.DataRow)
        //            {
        //                row.Cells[0].Controls.OfType<System.Web.UI.WebControls.CheckBox>().FirstOrDefault().Checked = true;
        //            }
        //        }
        //    }
        //    System.Web.UI.WebControls.CheckBox chkAll = (gv_kfls.HeaderRow.FindControl("chkAll") as System.Web.UI.WebControls.CheckBox);
        //    chkAll.Checked = true;
        //    foreach (GridViewRow row in gv_kfls.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            bool isChecked = row.Cells[0].Controls.OfType<System.Web.UI.WebControls.CheckBox>().FirstOrDefault().Checked;
        //            for (int i = 1; i < row.Cells.Count; i++)
        //            {
        //                //row.Cells[i].Controls.OfType<System.Web.UI.WebControls.Label>().FirstOrDefault().Visible = !isChecked;
        //                if (row.Cells[i].Controls.OfType<System.Web.UI.WebControls.TextBox>().ToList().Count > 0)
        //                {
        //                    row.Cells[i].Controls.OfType<System.Web.UI.WebControls.TextBox>().FirstOrDefault().Visible = true;
        //                }
        //                //if (row.Cells[i].Controls.OfType<DropDownList>().ToList().Count > 0)
        //                //{
        //                //    row.Cells[i].Controls.OfType<DropDownList>().FirstOrDefault().Visible = isChecked;
        //                //}
        //                if (isChecked && !isUpdateVisible)
        //                {
        //                    isUpdateVisible = true;
        //                }
        //                if (!isChecked)
        //                {
        //                    chkAll.Checked = false;
        //                }
        //            }
        //        }
        //    }
        //    btnUpdate.Visible = isUpdateVisible;

        //}
        protected void Update(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in gvCustomers.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
            //        if (isChecked)
            //        {
            //            SqlCommand cmd = new SqlCommand("UPDATE Customers SET ContactName = @ContactName, Country = @Country WHERE CustomerId = @CustomerId");
            //            cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
            //            cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
            //            cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);
            //            this.ExecuteQuery(cmd, "SELECT");
            //        }
            //    }
            //}
            //btnUpdate.Visible = false;
            this.gvBind();
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            //string date = "somedate";
            //DateTime date = DateTime.Today.AddDays(-20);
            HttpContext.Current.Session["kiln_date"] = selDate;
            //KilnDryer c = new KilnDryer();
            //c.Response.Redirect("~/KilnDryer.aspx");
            //c.Page_Load(null, null);
            //HttpContext.Current.Session["date"] = "2018-02-01";
            //c.SQLDbConnection(date);
        
            //c.gvBind();
            return selDate;

        }
        public void insertNewRow()
        {
            string dt;
            if (HttpContext.Current.Session["kiln_date"] != null)
                dt = HttpContext.Current.Session["kiln_date"].ToString();
            else
               dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT KDDATE   FROM [Lab].[dbo].[LAB_KILN_DRYER] WHERE KDDATE = '" + dt + "'";
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
                    gv_kfls.DataSource = null;
                    gv_kdloi.DataSource = null;
                    gv_kdna.DataSource = null;
                    gv_kdca.DataSource = null;
                    gv_kdzn.DataSource = null;
                    gv_dryerfm.DataSource = null;
                    gv_hydryer.DataSource = null;
                    gv_psma.DataSource = null;


                }
            }
           
        }
   
        public void createNewRow(string dt)
        {
            string sql = "insert into LAB_KILN_DRYER (KDDATE) VALUES ('" + dt + "')";
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
                if (string.IsNullOrEmpty(HttpContext.Current.Session["kiln_date"] as string))

                {
                    date = DateTime.Today.ToShortDateString();

                }
                else
                { date = Session["kiln_date"].ToString(); }
                date_max.Value = date;

                //KFLS
                //date = "2018-02-11";
                query = "SELECT top(1) '0600' as [Time], s.KFLS0600_1 as [-1-], s.KFLS0600_2 as [-2-], s.KFLS0600_3 as [-3-]  FROM [Lab].[dbo].[LAB_KILN_DRYER]  t inner join  [Lab].[dbo].[LAB_KILN_DRYER] s " +
                    " on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' union all SELECT top(1) '1800' as [Time], s.KFLS1800_1 as [-1-], s.KFLS1800_2 as [-2-], " +
                    " s.KFLS1800_3 as [-3-] FROM [Lab].[dbo].[LAB_KILN_DRYER] t inner join[Lab].[dbo].[LAB_KILN_DRYER] s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "'";

                //LOI
                query += "SELECT top(1) '2200' as [Time], s.KDLOI2200_1 as [-1-], s.KDLOI2200_2 as [-2-], s.KDLOI2200_3 as [-3-]  FROM [Lab].[dbo].[LAB_KILN_DRYER]  t inner join  [Lab].[dbo].[LAB_KILN_DRYER] s " +
                         " on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' union all SELECT top(1) '1000' as [Time], s.KDLOI1000_1 as [-1-], s.KDLOI1000_2 as [-2-], s.KDLOI1000_3 as [-3-] FROM [Lab].[dbo].[LAB_KILN_DRYER] t " +
                         " inner join[Lab].[dbo].[LAB_KILN_DRYER] s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "'";

                //NA
                query += "SELECT top(1) '2200' as [Time], s.KDNA2200_1 as [-1-], s.KDNA2200_2 as [-2-], s.KDNA2200_3 as [-3-]  FROM[Lab].[dbo].[LAB_KILN_DRYER] t inner join[Lab].[dbo].[LAB_KILN_DRYER] " +
                        " s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' union all SELECT top(1) '1000' as [Time], s.KDNA1000_1 as [-1-], s.KDNA1000_2 as [-2-], s.KDNA1000_3 as [-3-] FROM[Lab].[dbo].[LAB_KILN_DRYER] t " +
                        " inner join[Lab].[dbo].[LAB_KILN_DRYER] s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' ";

                //CA
                query += "SELECT top(1) '2200' as [Time], s.KDCA2200_1 as [-1-], s.KDCA2200_2 as [-2-], s.KDCA2200_3 as [-3-]  FROM [Lab].[dbo].[LAB_KILN_DRYER]  t inner join  [Lab].[dbo].[LAB_KILN_DRYER] s " +
                    " on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' union all SELECT top(1) '1000' as [Time], s.KDCA1000_1 as [-1-], s.KDCA1000_2 as [-2-], s.KDCA1000_3 as [-3-] FROM[Lab].[dbo].[LAB_KILN_DRYER] t" +
                    " inner join[Lab].[dbo].[LAB_KILN_DRYER] s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "'";

                //ZN
                query += "SELECT top(1) '2200' as [Time], s.KDZN2200_1 as [-1-], s.KDZN2200_2 as [-2-], s.KDZN2200_3 as [-3-]  FROM [Lab].[dbo].[LAB_KILN_DRYER]  t inner join  [Lab].[dbo].[LAB_KILN_DRYER] s " +
                         " on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' union all SELECT top(1) '1000' as [Time], s.KDZN1000_1 as [-1-], s.KDZN1000_2 as [-2-], s.KDZN1000_3 as [-3-] FROM [Lab].[dbo].[LAB_KILN_DRYER] t" +
                         " inner join[Lab].[dbo].[LAB_KILN_DRYER] s on s.KILN_ID = t.KILN_ID where s.kddate = '" + date + "' ";
                //hydrate dryer
                query += "SELECT '0600' AS[TIME],  [HD0600LS] AS [L-Soda] ,[HD0600RF] AS [Reflect] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' " +
                        //" UNION ALL SELECT '1100' AS[TIME], [HD1100LS],[HD1100RF] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' " +
                        " UNION ALL SELECT '1800' AS[TIME] ,[HD1800LS],[HD1800RF] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  ";
                        //" UNION ALL SELECT '2200' AS[TIME], [HD2200LS] ,[HD2200RF] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  ";


                //dryer #5
                query += " SELECT '0600' AS [TIME],  [DRYERNO5_0600LS] AS [L-Soda]  FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' " +
                     //" UNION ALL SELECT '1100' AS[TIME], [HD1100LS],[HD1100RF] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' " +
                     " UNION ALL SELECT '1800' AS [TIME] ,[DRYERNO5_1800LS] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  ";
                //" UNION ALL SELECT '2200' AS[TIME], [HD2200LS] ,[HD2200RF] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'  ";

                //dryer feed moisture
                query += "SELECT HDFM0600 as [-], [KFM] AS[-1-], [KFM2] AS[-2-],[KFM3] AS[-3-] FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' ";
                //Processs samples metals Analysis
                query += "select 'Primary Feed' as [-] , [PSMAPFNA] as [Na],[PSMAPFCA] as [Ca]  ,[PSMAPFZN] as [Zn], null as [CaO] FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
        " where kddate = '" + date + "'  union all select 'CPN' as [-], [CPNNA] ,[CPNCA] , [CPNZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
        " where kddate = '" + date + "'  union all select 'CPS' as [-], [CPSNA] ,[CPSCA] ,[CPSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
        " where kddate = '" + date + "'  union all select 'TT Seed' as [-], [PSMATTSNA] ,[PSMATTSCA] ,[PSMATTSZN], " +
        " null FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' union all " +
        " select 'ST Seed' as [-], [PSMASTSNA]  ,[PSMASTSCA] ,[PSMASTSZN], null FROM[Lab].[dbo].[LAB_KILN_DRYER] " +
        " where kddate = '" + date + "' " +
        " union all select '6FT' as [-], KFM0600_1, KFM0600_2, KFM0600_3, FT6 FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "' ";
                query += "SELECT KILN_ID FROM[Lab].[dbo].[LAB_KILN_DRYER] where kddate = '" + date + "'";

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
                      
                        gv_kfls.DataSource = ds.Tables[0];
                        gv_kfls.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        gv_kfls.DataSource = ds;
                        gv_kfls.DataBind();
                        int columncount = gv_kfls.Rows[0].Cells.Count;
                        gv_kfls.Rows[0].Cells.Clear();
                        gv_kfls.Rows[0].Cells.Add(new TableCell());
                        gv_kfls.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_kfls.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_kdloi.DataSource = ds.Tables[1];
                        gv_kdloi.DataBind();
                    }
                    else
                    {
                        ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
                        gv_kdloi.DataSource = ds;
                        gv_kdloi.DataBind();
                        int columncount = gv_kdloi.Rows[1].Cells.Count;
                        gv_kdloi.Rows[0].Cells.Clear();
                        gv_kdloi.Rows[0].Cells.Add(new TableCell());
                        gv_kdloi.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_kdloi.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gv_kdna.DataSource = ds.Tables[2];
                        gv_kdna.DataBind();
                    }
                    else
                    {
                        ds.Tables[2].Rows.Add(ds.Tables[2].NewRow());
                        gv_kdna.DataSource = ds;
                        gv_kdna.DataBind();
                        int columncount = gv_kdna.Rows[1].Cells.Count;
                        gv_kdna.Rows[0].Cells.Clear();
                        gv_kdna.Rows[0].Cells.Add(new TableCell());
                        gv_kdna.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_kdna.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        gv_kdca.DataSource = ds.Tables[3];
                        gv_kdca.DataBind();
                    }
                    else
                    {
                        ds.Tables[3].Rows.Add(ds.Tables[3].NewRow());
                        gv_kdca.DataSource = ds;
                        gv_kdca.DataBind();
                        int columncount = gv_kdca.Rows[1].Cells.Count;
                        gv_kdca.Rows[0].Cells.Clear();
                        gv_kdca.Rows[0].Cells.Add(new TableCell());
                        gv_kdca.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_kdca.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        gv_kdzn.DataSource = ds.Tables[4];
                        gv_kdzn.DataBind();
                    }
                    else
                    {
                        ds.Tables[4].Rows.Add(ds.Tables[4].NewRow());
                        gv_kdzn.DataSource = ds;
                        gv_kdzn.DataBind();
                        int columncount = gv_kdzn.Rows[1].Cells.Count;
                        gv_kdzn.Rows[0].Cells.Clear();
                        gv_kdzn.Rows[0].Cells.Add(new TableCell());
                        gv_kdzn.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_kdzn.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        gv_hydryer.DataSource = ds.Tables[5];
                        gv_hydryer.DataBind();
                    }
                  
                    else
                    {
                        ds.Tables[5].Rows.Add(ds.Tables[5].NewRow());
                        gv_hydryer.DataSource = ds;
                        gv_hydryer.DataBind();
                        int columncount = gv_hydryer.Rows[1].Cells.Count;
                        gv_hydryer.Rows[0].Cells.Clear();
                        gv_hydryer.Rows[0].Cells.Add(new TableCell());
                        gv_hydryer.Rows[0].Cells[0].ColumnSpan = columncount;
                       // gv_hydryer.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        gv_dryer5.DataSource = ds.Tables[6];
                        gv_dryer5.DataBind();
                    }

                    if (ds.Tables[7].Rows.Count > 0)
                    {
                        gv_dryerfm.DataSource = ds.Tables[7];
                        gv_dryerfm.DataBind();
                    }
                    else
                    {
                        ds.Tables[7].Rows.Add(ds.Tables[7].NewRow());
                        gv_dryerfm.DataSource = ds;
                        gv_hydryer.DataBind();
                        int columncount = gv_dryerfm.Rows[1].Cells.Count;
                        gv_dryerfm.Rows[0].Cells.Clear();
                        gv_dryerfm.Rows[0].Cells.Add(new TableCell());
                        gv_dryerfm.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_dryerfm.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        gv_psma.DataSource = ds.Tables[8];
                        gv_psma.DataBind();
                    }
                    else
                    {
                        ds.Tables[8].Rows.Add(ds.Tables[8].NewRow());
                        gv_psma.DataSource = ds;
                        gv_psma.DataBind();
                        int columncount = gv_psma.Rows[1].Cells.Count;
                        gv_psma.Rows[0].Cells.Clear();
                        gv_psma.Rows[0].Cells.Add(new TableCell());
                        gv_psma.Rows[0].Cells[0].ColumnSpan = columncount;
                        //gv_psma.Rows[0].Cells[0].Text = "No Records Found";
                    }

                   
                        if (ds.Tables[9].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[9].Rows[0];
                            Session["kiln_id"] = row[0].ToString() ;
                            string s = Session["kiln_id"].ToString();
                        }

                        //hide textboxes for 6FT row.
                        foreach( GridViewRow rows in gv_psma.Rows)
                        {
                            if (rows.RowIndex != 5)
                            {
                            System.Web.UI.WebControls.TextBox myTextBox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmacao");
                            myTextBox4.Visible = false;
                            }

                            if (rows.RowIndex == 5)
                            {
                                System.Web.UI.WebControls.TextBox TextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmana");
                                System.Web.UI.WebControls.TextBox TextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmaca");
                                System.Web.UI.WebControls.TextBox TextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmazn");
                            TextBox1.Visible = false;
                            TextBox2.Visible = false;
                            TextBox3.Visible = false;
                            }

                        }



                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {

                //Dryer #5
                DataTable dryer5DT = new DataTable();
                dryer5DT.Columns.Add("lsoda", typeof(string));
                foreach (GridViewRow rows in gv_dryer5.Rows)
                {

                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    string id = Session["kiln_id"].ToString();


                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_dryer5ls");
                    string lsoda = myTextBox1.Text;


                    var row = dryer5DT.NewRow();
                    dryer5DT.Rows.Add(row);
                    type = "dryer5";
                    row["lsoda"] = lsoda;


                }
               Update(type, dryer5DT);

                //HYDRATE DRYER
                DataTable lsodaDT = new DataTable();
                lsodaDT.Columns.Add("Time", typeof(string));
                lsodaDT.Columns.Add("lsoda", typeof(string));
                lsodaDT.Columns.Add("reflect", typeof(string));
                foreach (GridViewRow rows in gv_hydryer.Rows)
                {
                    //GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;
                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    string id = Session["kiln_id"].ToString();


                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_lsoda");
                    string lsoda = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_reflect");
                    string reflect = myTextBox2.Text;

                    var row = lsodaDT.NewRow();
                    lsodaDT.Rows.Add(row);
                    type = "lsoda";
                    row["lsoda"] = lsoda;
                    row["reflect"] = reflect;

                }
                Update(type, lsodaDT);


               



                //DateTime date_;
                //if (HttpContext.Current.Session["kiln_date"] == null)
                //{
                //    HttpContext.Current.Session["kiln_date"] = DateTime.Today;
                //    date_ = DateTime.Today;
                //    date_.ToShortDateString();
                //}
                //else
                //{
                //    string strdate = HttpContext.Current.Session["kiln_date"].ToString();
                //    date_ = DateTime.ParseExact(strdate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                //    date_.ToShortDateString();
                //}
                string r1c1; string r1c2; string r1c3;  string CaO;
                //KFLS...
                foreach (GridViewRow rows in gv_kfls.Rows)
                {
                    //GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;

                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Time", typeof(string));
                    dt.Columns.Add("-1-", typeof(string));
                    dt.Columns.Add("-2-", typeof(string));
                    dt.Columns.Add("-3-", typeof(string));
                    var row = dt.NewRow();
                    dt.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kfls1");
                    r1c1 = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kfls2");
                    r1c2 = myTextBox2.Text;
                    System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kfls3");
                    r1c3 = myTextBox3.Text;
                    row["-1-"] = r1c1;
                    row["-2-"] = r1c2;
                    row["-3-"] = r1c3;
                    if (client_RowIndex == "0")
                        type = "KFLS0600";
                    else
                        type = "KFLS1800";


                   Update(type, dt);
                }
                //LOI..
                foreach (GridViewRow rows in gv_kdloi.Rows)
                {
                    //GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;
                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    DataTable kdloiDT = new DataTable();
                    kdloiDT.Columns.Add("Time", typeof(string));
                    kdloiDT.Columns.Add("-1-", typeof(string));
                    kdloiDT.Columns.Add("-2-", typeof(string));
                    kdloiDT.Columns.Add("-3-", typeof(string));
                    var row = kdloiDT.NewRow();
                    kdloiDT.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdloi1");
                    r1c1 = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdloi2");
                    r1c2 = myTextBox2.Text;
                    System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdloi3");
                    r1c3 = myTextBox3.Text;
                    row["-1-"] = r1c1;
                    row["-2-"] = r1c2;
                    row["-3-"] = r1c3;
                    if (client_RowIndex == "0")
                        type = "KDLOI2200";
                    else
                        type = "KDLOI1000";

                    Update(type, kdloiDT);
                }
                //KDNA..
                foreach (GridViewRow rows in gv_kdna.Rows)
                {
                    //GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;

                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    DataTable kdnaDT = new DataTable();
                    kdnaDT.Columns.Add("Time", typeof(string));
                    kdnaDT.Columns.Add("-1-", typeof(string));
                    kdnaDT.Columns.Add("-2-", typeof(string));
                    kdnaDT.Columns.Add("-3-", typeof(string));
                    var row = kdnaDT.NewRow();
                    kdnaDT.Rows.Add(row);

                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdna1");
                    r1c1 = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdna2");
                    r1c2 = myTextBox2.Text;
                    System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdna3");
                    r1c3 = myTextBox3.Text;

                    row["-1-"] = r1c1;
                    row["-2-"] = r1c2;
                    row["-3-"] = r1c3;

                    if (client_RowIndex == "0")
                        type = "KDNA2200";
                    else
                        type = "KDNA1000";


                    Update(type, kdnaDT);
                }
                //KDCA..
                foreach (GridViewRow rows in gv_kdca.Rows)
                {
                    //GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;

                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    DataTable kdcaDT = new DataTable();
                    kdcaDT.Columns.Add("Time", typeof(string));
                    kdcaDT.Columns.Add("-1-", typeof(string));
                    kdcaDT.Columns.Add("-2-", typeof(string));
                    kdcaDT.Columns.Add("-3-", typeof(string));
                    var row = kdcaDT.NewRow();
                    kdcaDT.Rows.Add(row);
                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdca1");
                    r1c1 = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdca2");
                    r1c2 = myTextBox2.Text;
                    System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdca3");
                    r1c3 = myTextBox3.Text;
                    row["-1-"] = r1c1;
                    row["-2-"] = r1c2;
                    row["-3-"] = r1c3;
                    if (client_RowIndex == "0")
                        type = "KDCA2200";
                    else
                        type = "KDCA1000";
                   Update(type, kdcaDT);

                }
                //KDZN
                foreach (GridViewRow rows in gv_kdzn.Rows)
                {
                    DataTable kdznDT = new DataTable();
                    kdznDT.Columns.Add("Time", typeof(string));
                    kdznDT.Columns.Add("-1-", typeof(string));
                    kdznDT.Columns.Add("-2-", typeof(string));
                    kdznDT.Columns.Add("-3-", typeof(string));
                    var row = kdznDT.NewRow();
                    kdznDT.Rows.Add(row);
                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                    string id = Session["kiln_id"].ToString();

                    System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdzn1");
                    r1c1 = myTextBox1.Text;
                    System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdzn2");
                    r1c2 = myTextBox2.Text;
                    System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kdzn3");
                    r1c3 = myTextBox3.Text;
                    if (client_RowIndex == "0")
                        type = "KDZN2200";
                    else
                        type = "KDZN1000";
                    row["-1-"] = r1c1;
                    row["-2-"] = r1c2;
                    row["-3-"] = r1c3;
                    Update(type, kdznDT);

                }

             

             



                    //Dryer Feed Moisture/Kiln Feed Moisture ...
                    foreach (GridViewRow rows in gv_dryerfm.Rows)
                    {
                        DataTable dryerfmDT = new DataTable();
                        //dryerfmDT.Columns.Add("Time", typeof(string));
                        dryerfmDT.Columns.Add("-", typeof(string));
                        dryerfmDT.Columns.Add("-1-", typeof(string));
                        dryerfmDT.Columns.Add("-2-", typeof(string));
                        dryerfmDT.Columns.Add("-3-", typeof(string));
                        string id = Session["kiln_id"].ToString();
                        //if (client_RowIndex == "0")

                        System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_dryerfm1");
                            string dfm = myTextBox1.Text;
                        System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kilnfm1");
                            string kfm1 = myTextBox2.Text;
                        System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kilnfm2");
                            string kfm2 = myTextBox3.Text;
                        System.Web.UI.WebControls.TextBox myTextBox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_kilnfm3");
                             string kfm3 = myTextBox4.Text;
                        var row = dryerfmDT.NewRow();
                        dryerfmDT.Rows.Add(row);
                        string typ_ = "feedmoisture";
                        row["-"] = dfm;
                        row["-1-"] = kfm1;
                        row["-2-"] = kfm2;
                        row["-3-"] = kfm3;
                        Update(typ_, dryerfmDT);
                    }
                
                //Sec III Process Samples
                foreach (GridViewRow rows in gv_psma.Rows)
                {
                    DataTable psmaDT = new DataTable();
                    psmaDT.Columns.Add("-Na-", typeof(string));
                    psmaDT.Columns.Add("-Ca-", typeof(string));
                    psmaDT.Columns.Add("-Zn-", typeof(string));
                    psmaDT.Columns.Add("-CaO-", typeof(string));
                    var row = psmaDT.NewRow();
                    psmaDT.Rows.Add(row);
                    string client_ID = rows.ClientID;
                    string client_RowIndex = rows.RowIndex.ToString();
                        System.Web.UI.WebControls.TextBox myTextBox1 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmana");
                        r1c1 = myTextBox1.Text;
                        System.Web.UI.WebControls.TextBox myTextBox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmaca");
                        r1c2 = myTextBox2.Text;
                        System.Web.UI.WebControls.TextBox myTextBox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmazn");
                        r1c3 = myTextBox3.Text;
                        System.Web.UI.WebControls.TextBox myTextBox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_psmacao");
                        CaO = myTextBox4.Text;
                        row["-Na-"] = r1c1;
                        row["-Ca-"] = r1c2;
                        row["-Zn-"] = r1c3;
                        row["-CaO-"] = CaO;
                        if (client_RowIndex == "0")
                            { type = "Prime Feed"; }
                        else if (client_RowIndex == "1")
                            { type = "CPN"; }
                        else if (client_RowIndex == "2")
                             { type = "CPS"; }
                        else if (client_RowIndex == "3")
                            { type = "TT Seed"; }
                        else if (client_RowIndex == "4")
                            { type = "ST Seed"; }
                        else if (client_RowIndex == "5")
                            { type = "6FT"; }

                        Update(type, psmaDT);
                    
                }
                gvBind();
                this.Response.Redirect(this.Request.Url.ToString());

            }
            catch (Exception ex)
            {

            }
        }
        protected void gv_kfls_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_kfls, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_kdloi_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_kdloi, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_kdna_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_kdna, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_kdca_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_kdca, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_kdzn_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_kdzn, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_hydryer_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_hydryer, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_dryerfm_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_dryerfm, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gv_psma_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_psma, "Edit$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            System.Web.UI.WebControls.GridView gvr = sender as System.Web.UI.WebControls.GridView;
            Session["gv_ID"] = gvr.ID;


            // IsInEditMode = true;


            //if (gvr.ID == "gv_kfls")
            {
                gv_kfls.EditIndex = e.NewEditIndex;
                ((BoundField)gv_kfls.Columns[0]).ReadOnly = true;

                gv_kfls.EditIndex = 0;
                gv_kfls.EditIndex = 1;
                gv_kfls.EditIndex = 0;

                this.gvBind();
                //gv_kfls.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                gv_kfls.Columns[4].Visible = true;
            }
            //else if (gvr.ID == "gv_kdloi")
            {
                gv_kdloi.EditIndex = e.NewEditIndex;
                ((BoundField)gv_kdloi.Columns[0]).ReadOnly = true;

                gv_kdloi.EditIndex = e.NewEditIndex;
                this.gvBind();
                //gv_kfls.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                gv_kdloi.Columns[4].Visible = true;
            }
            //else if (gvr.ID == "gv_kdca")
            {
                gv_kdca.EditIndex = e.NewEditIndex;
                ((BoundField)gv_kdca.Columns[0]).ReadOnly = true;

                gv_kdca.EditIndex = e.NewEditIndex;
                this.gvBind();
                //gv_kfls.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                gv_kdca.Columns[4].Visible = true;
            }


            //else if (gvr.ID == "gv_kdna")
            {
                gv_kdna.EditIndex = e.NewEditIndex;
                ((BoundField)gv_kdna.Columns[0]).ReadOnly = true;

                gv_kdna.EditIndex = e.NewEditIndex;
                this.gvBind();
                //gv_kfls.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                gv_kdna.Columns[4].Visible = true;
            }


            //else if (gvr.ID == "gv_kdzn")
            {
                gv_kdzn.EditIndex = e.NewEditIndex;
                ((BoundField)gv_kdzn.Columns[0]).ReadOnly = true;

                gv_kdzn.EditIndex = e.NewEditIndex;
                this.gvBind();
                //gv_kfls.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
                gv_kdzn.Columns[4].Visible = true;
            }
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row_ = (sender as LinkButton).NamingContainer as GridViewRow;
                string col1; string col2; string col3;
                string client_ID = row_.ClientID;
                string client_RowIndex = row_.RowIndex.ToString();
                if (Session["kiln_id"] != null)
                {
                    string id = Session["kiln_id"].ToString();
                }
                else
                {
                    string kiln_id = null;
                }
                if (client_RowIndex == "0")
                {
                    col1 = (row_.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
                    col2 = (row_.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
                    col3 = (row_.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
                }
                else
                {
                    col1 = (row_.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
                    col2 = (row_.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
                    col3 = (row_.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text;

                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Time", typeof(string));
                dt.Columns.Add("-1-", typeof(string));
                dt.Columns.Add("-2-", typeof(string));
                dt.Columns.Add("-3-", typeof(string));
                var row = dt.NewRow();
                dt.Rows.Add(row);

                string type;
                if (client_ID.Contains("gv_kfls"))
                {
                    if (client_RowIndex == "0")
                        type = "KFLS0600";
                    else
                        type = "KFLS1800";
                }
                else if (client_ID.Contains("gv_kdloi"))
                {
                    if (client_RowIndex == "0")
                        type = "KDLOI2200";
                    else
                        type = "KDLOI1000";
                }
                else if (client_ID.Contains("gv_kdca"))
                {
                    if (client_RowIndex == "0")
                        type = "KDCA2200";
                    else
                        type = "KDCA1000";
                }
                else if (client_ID.Contains("gv_kdna"))
                {
                    if (client_RowIndex == "0")
                        type = "KDNA2200";
                    else
                        type = "KDNA1000";
                }
                else
                {
                    if (client_RowIndex == "0")
                        type = "KDZN2200";
                    else
                        type = "KDZN1000";
                }

                row["-1-"] = col1;
                row["-2-"] = col2;
                row["-3-"] = col3;
                Update(type, dt);
                resetGrid(client_ID);
            }
            catch (Exception ex)
            {

            }
        }
        public void sqlConnection(string type, string @par1, string @par2, string @par3, string @par4)
        {
            //string strdate = HttpContext.Current.Session["kiln_date"].ToString();
            //var date_ = DateTime.ParseExact(strdate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
            //date_.ToShortDateString();
            try
            {

                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand("LAB_sp_kiln_dryer", con);
                using (con)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@kiln_id", SqlDbType.VarChar, (10)).Value = Session["kiln_id"].ToString();
                    cmd.Parameters.Add("@fieldname", SqlDbType.VarChar,(20)).Value = type;
                    cmd.Parameters.Add("@var1", SqlDbType.VarChar, (10)).Value = @par1;
                    cmd.Parameters.Add("@var2", SqlDbType.VarChar, (10)).Value = @par2;
                    cmd.Parameters.Add("@var3", SqlDbType.VarChar, (10)).Value = @par3;
                    cmd.Parameters.Add("@var4", SqlDbType.VarChar, (10)).Value = @par4;
                    con.Open();
                   cmd.ExecuteNonQuery();
                }


            }
            catch(Exception s)
            {

            }
        }
        public void Update(string type, DataTable dt)
        {     
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            try
            {
                if (type.Contains('K'))
                {
                    @par1 = string.IsNullOrEmpty(dt.Rows[0]["-1-"].ToString()) ? "" : dt.Rows[0]["-1-"].ToString();
                    @par2 = string.IsNullOrEmpty(dt.Rows[0]["-2-"].ToString()) ? "" : dt.Rows[0]["-2-"].ToString();
                    @par3 = string.IsNullOrEmpty(dt.Rows[0]["-3-"].ToString()) ? "" : dt.Rows[0]["-3-"].ToString();
                    sqlConnection(type, @par1, @par2, @par3, "");
                    PiInsert(type, dt);
                }
                else if (type == "lsoda" || type == "reflect")
                {
                    string fieldname = "lsoda";
                    for (int i = 0; i < 2; i++)
                    {    
                        @par1 = string.IsNullOrEmpty(dt.Rows[0][fieldname].ToString()) ? "" : dt.Rows[0][fieldname].ToString();
                       // @par2 = string.IsNullOrEmpty(dt.Rows[1][fieldname].ToString()) ? "" : dt.Rows[1][fieldname].ToString();
                        @par3 = string.IsNullOrEmpty(dt.Rows[1][fieldname].ToString()) ? "" : dt.Rows[1][fieldname].ToString();
                        //@par4 = string.IsNullOrEmpty(dt.Rows[3][fieldname].ToString()) ? "" : dt.Rows[3][fieldname].ToString();
                        sqlConnection(fieldname, @par1, "", @par3, "");
                    
                        fieldname = "reflect";
                    } 
                }
                else if (type == "dryer5")
                {
                    string fieldname = "lsoda";;
                    @par1 = string.IsNullOrEmpty(dt.Rows[0][fieldname].ToString()) ? "" : dt.Rows[0][fieldname].ToString();
                    // @par2 = string.IsNullOrEmpty(dt.Rows[1][fieldname].ToString()) ? "" : dt.Rows[1][fieldname].ToString();
                    @par3 = string.IsNullOrEmpty(dt.Rows[1][fieldname].ToString()) ? "" : dt.Rows[1][fieldname].ToString();
                    //@par4 = string.IsNullOrEmpty(dt.Rows[3][fieldname].ToString()) ? "" : dt.Rows[3][fieldname].ToString();

                 
                    sqlConnection(type, @par1, "", @par3, "");
                    PiInsert(type, dt);


                }
                else if ( type == "feedmoisture")
                {
                    @par1 = string.IsNullOrEmpty(dt.Rows[0]["-"].ToString()) ? "" : dt.Rows[0]["-"].ToString();
                    @par2 = string.IsNullOrEmpty(dt.Rows[0]["-1-"].ToString()) ? "" : dt.Rows[0]["-1-"].ToString();
                    @par3 = string.IsNullOrEmpty(dt.Rows[0]["-2-"].ToString()) ? "" : dt.Rows[0]["-2-"].ToString();
                    @par4 = string.IsNullOrEmpty(dt.Rows[0]["-3-"].ToString()) ? "" : dt.Rows[0]["-3-"].ToString();
                    sqlConnection("feedmoisture", @par1, @par2, @par3, @par4);
                    PiInsert(type, dt);
                }
                else 
                {
                    @par1 = string.IsNullOrEmpty(dt.Rows[0]["-Na-"].ToString()) ? "" : dt.Rows[0]["-Na-"].ToString();
                    @par2 = string.IsNullOrEmpty(dt.Rows[0]["-Ca-"].ToString()) ? "" : dt.Rows[0]["-Ca-"].ToString();
                    @par3 = string.IsNullOrEmpty(dt.Rows[0]["-Zn-"].ToString()) ? "" : dt.Rows[0]["-Zn-"].ToString();
                    @par4 = string.IsNullOrEmpty(dt.Rows[0]["-CaO-"].ToString()) ? "" : dt.Rows[0]["-CaO-"].ToString();
                    sqlConnection(type, @par1, @par2, @par3, @par4);
                    PiInsert(type, dt);
                }

            }
            catch (Exception exc)
            {

            }
            ///////////
        }
        public void PiInsert(string type, DataTable dt)
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
                DateTime date;
                DateTime datetime;

                if (Session["kiln_date"] == null)
                {
                    date = DateTime.Today;

                }
                else
                    date = Convert.ToDateTime(Session["kiln_date"].ToString());


                //Dryer #5
                if (type == "dryer5")
                {
                    DateTime d_t;
                    DateTime now = DateTime.Now;
                    string stime = now.ToString();
                    TimeSpan ts1 = new TimeSpan(6, 0, 0);
                    TimeSpan ts2 = new TimeSpan(18, 0, 0);
                    PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, "LAB_DRYER5");
                    AFValue currentTag = myPIPoint.CurrentValue();
                    if (!stime.Contains("PM"))
                    {
                        d_t = date + ts1;
                        currentTag.Value = string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? "" : dt.Rows[0][0].ToString();
                        currentTag.Timestamp = d_t;
                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                    }
                    else
                    {
                        d_t = date + ts2;
                        currentTag.Value = string.IsNullOrEmpty(dt.Rows[1][0].ToString()) ? "" : dt.Rows[1][0].ToString();
                        currentTag.Timestamp = d_t;
                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                    }

                    
                  
                }

                //type is not feed moisture
                else if (type.Contains("K"))
                {
              
                    string s = type.Substring(0, type.Length - 4);
                    string input = type.Substring(type.Length - 4);
                    int time = Convert.ToInt16(input.Substring(0,2));
                   
                    TimeSpan ts;
                    //if (time == 24)
                    //{
                    //    ts = new TimeSpan(23, 59, 59);
                    //}
                    //else
                    ts = new TimeSpan(time, 0, 0);

             
                    if (time == 22)
                    {
                        date = date.AddDays(-1);
                    }
                    datetime = date + ts;
                    int dt_ = DateTime.Now.Hour;
                    //check for daylight saving time
                    bool dst = DSTcheck();
                    if (!dst)
                    {
                        dt_ = dt_ +1;
                    }
                    //adjust the hours to utc
                    int utc = DateTime.UtcNow.Hour;
                    int diff;
                    if (utc > dt_)
                        diff = utc - dt_;
                    else
                        diff = utc + 24 - dt_;
                    foreach (DataRow d in dt.Rows)
                    {
                        piTagValues.Add("LAB_" + s + "_1", string.IsNullOrEmpty(dt.Rows[0]["-1-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-1-"].ToString()));
                        piTagValues.Add("LAB_" + s + "_2", string.IsNullOrEmpty(dt.Rows[0]["-2-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-2-"].ToString()));
                        piTagValues.Add("LAB_" + s + "_3", string.IsNullOrEmpty(dt.Rows[0]["-3-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-3-"].ToString()));
                    }
                    var PiTaglist = (from v in db.Lab_TagTable
                                     orderby v.Id
                                     select v).Skip(23).Take(16);
                    //Skip(50).Take(50)
                    //var list = (from v in db.Lab_PhamTag
                    //orderby v.Id
                    //            select v);
                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {
                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length-5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                string ct = currentTag.Value.ToString();
                                currentTag.Value = Convert.ToString(entry.Value);
                                currentTag.Timestamp = datetime;

                              

                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    //if (ctv != null && d != date)
                                    //{
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    //}
                                    //else
                                    //    myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);

                                }
                            }
                        }
                    }
                }
                else if (type == "lsoda" || type == "reflect")
                {


                }
                else if (type == "feedmoisture")
                {
                    //var date = Convert.ToDateTime(Session["kiln_date"].ToString());
                    foreach (DataRow d in dt.Rows)
                    {
                        piTagValues.Add("LAB_KFM1", string.IsNullOrEmpty(dt.Rows[0]["-1-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-1-"].ToString()));
                        piTagValues.Add("LAB_KFM2", string.IsNullOrEmpty(dt.Rows[0]["-2-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-2-"].ToString()));
                        piTagValues.Add("LAB_KFM3", string.IsNullOrEmpty(dt.Rows[0]["-3-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-3-"].ToString()));

                    }
                    var PiTaglist = (from v in db.Lab_TagTable
                                     orderby v.Id
                                     select v).Skip(23).Take(16);
                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {

                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Value = Convert.ToString(entry.Value);
                                currentTag.Timestamp = date;

                                string ctv = currentTag.Value.ToString();
                                DateTime cttimestamp = currentTag.Timestamp;
                                DateTime d = cttimestamp.Date;

                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    if (ctv != null && d != date)
                                    {
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    }
                                    else
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);

                                }

                            }

                        }
                    }

                }
                else
                {
                    //var date = Convert.ToDateTime(Session["kiln_date"].ToString());
                 
                    piTagValues.Add("LABPFZn", string.IsNullOrEmpty(dt.Rows[0]["-Zn-"].ToString()) ? (decimal?)null : Convert.ToDecimal(dt.Rows[0]["-Zn-"].ToString()));
                 
                    var PiTaglist = (from v in db.Lab_TagTable
                                     orderby v.Id
                                     select v).Skip(23).Take(16);
                    foreach (KeyValuePair<string, decimal?> entry in piTagValues)
                    {
                        foreach (var item in PiTaglist)
                        {

                            string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                            string TagName_test = item.Pi_Tags_Test;
                            if (TagName == entry.Key)
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Value = Convert.ToString(entry.Value);
                                currentTag.Timestamp = date;



                                string ctv = currentTag.Value.ToString();
                                DateTime cttimestamp = currentTag.Timestamp;
                                DateTime d = cttimestamp.Date;

                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {
                                    if (ctv != null && d != date)
                                    {
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    }
                                    else
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Replace);

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
        public void resetGrid(string clientID)
        {
            try
            {
                if (clientID.Contains("gv_kfls"))
                {
                    gv_kfls.EditIndex = -1;
                    this.gvBind();
                }

                if (clientID.Contains("gv_kdloi"))
                {
                    gv_kdloi.EditIndex = -1;
                    this.gvBind();
                }

                if (clientID.Contains("gv_kdca"))
                {
                    gv_kdca.EditIndex = -1;
                    this.gvBind();
                }

                if (clientID.Contains("gv_kdna"))
                {
                    gv_kdna.EditIndex = -1;
                    this.gvBind();
                }

                if (clientID.Contains("gv_kdzn"))
                {
                    gv_kdzn.EditIndex = -1;
                    this.gvBind();
                }
            }
            catch
            {

            }



        }

        protected void OnCancel(object sender, EventArgs e)
        {
            try
            {

                if (Session["gv_ID"].ToString() == "gv_kfls")
                {
                    gv_kfls.EditIndex = -1;
                    this.gvBind();

                }
                else if (Session["gv_ID"].ToString() == "gv_kdloi")
                {
                    gv_kdloi.EditIndex = -1;
                    this.gvBind();

                }

                else if (Session["gv_ID"].ToString() == "gv_kdna")
                {
                    gv_kdna.EditIndex = -1;
                    this.gvBind();

                }
                else if (Session["gv_ID"].ToString() == "gv_kdca")
                {
                    gv_kdca.EditIndex = -1;
                    this.gvBind();

                }

                else if (Session["gv_ID"].ToString() == "gv_kdzn")
                {
                    gv_kdzn.EditIndex = -1;
                    this.gvBind();

                }
            }
            catch 
            {

            }
            

        }

        //private void emptyCells()
        //{
        //    foreach (GridViewRow row in gv_kfls.Rows)
        //    {
        //        foreach (GridViewRowCollection cell in row.Cells)
        //        {
        //            string value = Convert.ToString(cell);
        //            cell.valu = string.IsNullOrWhiteSpace(value) ? 0 : cell.Value;
        //        }

        //    }
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        gvbind();
        //    }
        //}
        //protected void gvbind()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("Select * from detail", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();
        //    }
        //    else
        //    {
        //        //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //        //GridView1.DataSource = ds;
        //        //GridView1.DataBind();
        //        //int columncount = GridView1.Rows[0].Cells.Count;
        //        //GridView1.Rows[0].Cells.Clear();
        //        //GridView1.Rows[0].Cells.Add(new TableCell());
        //        //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
        //        //GridView1.Rows[0].Cells[0].Text = "No Records Found";
        //    }
        //}
        //protected void gv_kfls_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = (GridViewRow)gv_kfls.Rows[e.RowIndex];
        //    Label lbldeleteid = (Label)row.FindControl("lblID");
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("delete FROM detail where id='" + Convert.ToInt32(gv_kfls.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    gvbind();
        //}
        protected void gv_kfls_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_kfls.EditIndex = e.NewEditIndex;
            gvBind();
        }

        protected void gv_kfls_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int userid = Convert.ToInt32(gv_kfls.DataKeys[e.RowIndex].Value.ToString());
            //GridViewRow row = (GridViewRow)gv_kfls.Rows[e.RowIndex];
            //Label lblID = (Label)row.FindControl("lblID");
            ////TextBox txtname=(TextBox)gr.cell[].control[];  
            //TextBox textName = (TextBox)row.Cells[0].Controls[0];
            //TextBox textadd = (TextBox)row.Cells[1].Controls[0];
            //TextBox textc = (TextBox)row.Cells[2].Controls[0];
          
            gv_kfls.EditIndex = -1;
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            gvBind();
           
        }
        protected void gv_kfls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_kfls.PageIndex = e.NewPageIndex;
            gvBind();
        }
        protected void gv_kfls_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_kfls.EditIndex = -1;
            gvBind();
        }
    }
}
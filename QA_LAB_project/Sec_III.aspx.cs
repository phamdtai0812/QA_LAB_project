using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using QA_LAB_project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QA_LAB_project
{
    public partial class Sec_III : System.Web.UI.Page
    {
       String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        string TagName_test; 
        string TagName;
        bool tableExists = false;
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
                if (string.IsNullOrEmpty(HttpContext.Current.Session["sec3_date"] as string))
                {
                    date = DateTime.Today.ToShortDateString();
                    Session["sec3_date"] = date;
                }
                else
                { date = Session["sec3_date"].ToString(); }
                date_max.Value = date;

                //primary feed tanks
              
                query = "SELECT [secrecord],[SECID],[P100],[P200],[P325],[UM20],[CAUS],[AC],[GPLSOL],[SA], SECIII_ID" +
                    " FROM[Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + date + "' and SECRECORD = 'FST'";

                //st top samples
                query += "  SELECT [SECRECORD],[SECID],[P100],[P200],[P325],[UM20],[CAUS],[AC],[GPLSOL],[SA], SECIII_ID" +
                    " FROM[Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + date + "' and SECRECORD = 'PTS'";

                //tt top samples
                query += "  SELECT [SECRECORD],[SECID],[P100],[P200],[P325],[UM20],[CAUS],[AC],[GPLSOL],[SA], SECIII_ID" +
                    " FROM[Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + date + "' and SECRECORD = 'TTS'";


                //south continuous precip
                query += "SELECT [SECRECORD],[SECID],[P100],[P200],[P325],[UM20],[CAUS],[AC],[GPLSOL],[SA], SECIII_ID" +
                    " FROM[Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + date + "' and SECRECORD = 'SCCP' ";

                //north continuous precip
                query += "SELECT [SECRECORD],[SECID],[P100],[P200],[P325],[UM20],[CAUS],[AC],[GPLSOL],[SA], SECIII_ID" +
                    " FROM[Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + date + "' and SECRECORD = 'NORTHD' ";

                //caustic clean
                query += " Select cctruck, cccaustic, ccac, ccid, ccround from lab_caustic_clean where CCDATE = '" + date + "'  ";

                //water tank
                query += " select 'North' as name, [H2ONORTH0000] as [-0000-],[H2ONORTH0600] as [-0600-],[H2ONORTH1200] as [-1200-] ,[H2ONORTH1800] as [-1800-], [H2O_ID] from LAB_H2O_TANK_DATA" +
                    " where H2ODATE = '" + date + "' UNION ALL" +
                    " select 'South' as name,  [H2OSOUTH0000],[H2OSOUTH0600],[H2OSOUTH1200],[H2OSOUTH1800],[H2O_ID] from LAB_H2O_TANK_DATA" +
                    " where H2ODATE = '" + date + "'   UNION ALL   " +
                    "  select '#5' as name,  [H2ONO5_0000],[H2ONO5_0600],[H2ONO5_1200],[H2ONO5_1800],[H2O_ID] from LAB_H2O_TANK_DATA" +
                    " where H2ODATE = '" + date + "'";

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

                        gv_pft.DataSource = ds.Tables[0];
                        gv_pft.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_stts.DataSource = ds.Tables[1];
                        gv_stts.DataBind();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gv_ttts.DataSource = ds.Tables[2];
                        gv_ttts.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        gv_cps.DataSource = ds.Tables[3];
                        gv_cps.DataBind();
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        gv_cpn.DataSource = ds.Tables[4];
                        gv_cpn.DataBind();
                    }

                    gv_cc.DataSource = ds.Tables[5];
                    gv_cc.DataBind();

                    gv_h2o.DataSource = ds.Tables[6];
                    gv_h2o.DataBind();
                

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
                //st top samples
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("secid", typeof(string));
                dt.Columns.Add("p100", typeof(string));
                dt.Columns.Add("p200", typeof(string));
                dt.Columns.Add("p325", typeof(string));
                dt.Columns.Add("um20", typeof(string));
                dt.Columns.Add("caus", typeof(string));
                dt.Columns.Add("ac", typeof(string));
                dt.Columns.Add("gplsol", typeof(string));
                dt.Columns.Add("sa", typeof(string));

                foreach (GridViewRow rows in gv_stts.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_secid");
                    
                    if (txtbx.Text != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_stts_seciii_id");
                        string sec3_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_secid");
                        string secid = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_p100");
                        string tbp100 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_p200");
                        string tbp200 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_p325");
                        string tbp325 = txtbox5.Text;
                        System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_um20");
                        string tbum20 = txtbox6.Text;
                        System.Web.UI.WebControls.TextBox txtbox7 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_caus");
                        string tbcaus = txtbox7.Text;
                        System.Web.UI.WebControls.TextBox txtbox8 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_ac");
                        string tbac = txtbox8.Text;
                        System.Web.UI.WebControls.TextBox txtbox9 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_gplsol");
                        string tbgplsol = txtbox9.Text;
                        System.Web.UI.WebControls.TextBox txtbox10 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_stts_sa");
                        string tbsa = txtbox10.Text;
                        row["id"] = string.IsNullOrEmpty(sec3_id.ToString()) ? (object)DBNull.Value : sec3_id.ToString();
                        row["secid"] =  string.IsNullOrEmpty(secid.ToString()) ? (object)DBNull.Value : secid.ToString(); 
                        row["p100"] =  string.IsNullOrEmpty(tbp100.ToString()) ? (object)DBNull.Value : tbp100.ToString(); 
                        row["p200"] =  string.IsNullOrEmpty(tbp200.ToString()) ? (object)DBNull.Value : tbp200.ToString(); 
                        row["p325"] =  string.IsNullOrEmpty(tbp325.ToString()) ? (object)DBNull.Value : tbp325.ToString(); 
                        row["um20"] =  string.IsNullOrEmpty(tbum20.ToString()) ? (object)DBNull.Value : tbum20.ToString(); 
                        row["caus"] =  string.IsNullOrEmpty(tbcaus.ToString()) ? (object)DBNull.Value : tbcaus.ToString(); 
                        row["ac"] =    string.IsNullOrEmpty(tbac.ToString()) ? (object)DBNull.Value : tbac.ToString();
                        row["gplsol"] =  string.IsNullOrEmpty(tbgplsol.ToString()) ? (object)DBNull.Value : tbgplsol.ToString();
                        row["sa"] =   string.IsNullOrEmpty(tbsa.ToString()) ? (object)DBNull.Value : tbsa.ToString();
                    }
                }
                Update("st_topsamples", dt);
               
                //tt top samples
                dt.Rows.Clear();
               foreach (GridViewRow rows in gv_ttts.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_secid");
                    if (txtbx.Text != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_ttts_seciii_id");
                        string sec3_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_secid");
                        string secid = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_p100");
                        string tbp100 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_p200");
                        string tbp200 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_p325");
                        string tbp325 = txtbox5.Text;
                        System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_um20");
                        string tbum20 = txtbox6.Text;
                        System.Web.UI.WebControls.TextBox txtbox7 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_caus");
                        string tbcaus = txtbox7.Text;
                        System.Web.UI.WebControls.TextBox txtbox8 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_ac");
                        string tbac = txtbox8.Text;
                        System.Web.UI.WebControls.TextBox txtbox9 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_gplsol");
                        string tbgplsol = txtbox9.Text;
                        System.Web.UI.WebControls.TextBox txtbox10 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_ttts_sa");
                        string tbsa = txtbox10.Text;
                        row["id"] = sec3_id;
                        row["secid"] = secid;
                        row["p100"] = tbp100;
                        row["p200"] = tbp200;
                        row["p325"] = tbp325;
                        row["um20"] = tbum20;
                        row["caus"] = tbcaus;
                        row["ac"] = tbac;
                        row["gplsol"] = tbgplsol;
                        row["sa"] = tbsa;
                    }
                }
               Update("tt_topsamples",dt);

                //primary feed tank
                dt.Rows.Clear();
                foreach (GridViewRow rows in gv_pft.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_p100");

                    //if (txtbx.Text != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_pft_seciii_id");
                        string sec3_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_secid");
                        string secid = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_p100");
                        string tbp100 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_p200");
                        string tbp200 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_p325");
                        string tbp325 = txtbox5.Text;
                        System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_um20");
                        string tbum20 = txtbox6.Text;
                        System.Web.UI.WebControls.TextBox txtbox7 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_caus");
                        string tbcaus = txtbox7.Text;
                        System.Web.UI.WebControls.TextBox txtbox8 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_ac");
                        string tbac = txtbox8.Text;
                        System.Web.UI.WebControls.TextBox txtbox9 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_gplsol");
                        string tbgplsol = txtbox9.Text;
                        System.Web.UI.WebControls.TextBox txtbox10 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_pft_sa");
                        string tbsa = txtbox10.Text;
                        row["id"] = string.IsNullOrEmpty(sec3_id.ToString()) ? (object)DBNull.Value : sec3_id.ToString();
                        row["secid"] = string.IsNullOrEmpty(secid.ToString()) ? (object)DBNull.Value : secid.ToString();
                        row["p100"] = string.IsNullOrEmpty(tbp100.ToString()) ? (object)DBNull.Value : tbp100.ToString();
                        row["p200"] = string.IsNullOrEmpty(tbp200.ToString()) ? (object)DBNull.Value : tbp200.ToString();
                        row["p325"] = string.IsNullOrEmpty(tbp325.ToString()) ? (object)DBNull.Value : tbp325.ToString();
                        row["um20"] = string.IsNullOrEmpty(tbum20.ToString()) ? (object)DBNull.Value : tbum20.ToString();
                        row["caus"] = string.IsNullOrEmpty(tbcaus.ToString()) ? (object)DBNull.Value : tbcaus.ToString();
                        row["ac"] = string.IsNullOrEmpty(tbac.ToString()) ? (object)DBNull.Value : tbac.ToString();
                        row["gplsol"] = string.IsNullOrEmpty(tbgplsol.ToString()) ? (object)DBNull.Value : tbgplsol.ToString();
                        row["sa"] = string.IsNullOrEmpty(tbsa.ToString()) ? (object)DBNull.Value : tbsa.ToString();
                    }
                }
                Update("prime_feedtank", dt);

                //cont precip south
                dt.Rows.Clear();
                foreach (GridViewRow rows in gv_cps.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_p100");

                    //if (txtbx.Text != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_cps_seciii_id");
                        string sec3_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_secid");
                        string secid = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_p100");
                        string tbp100 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_p200");
                        string tbp200 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_p325");
                        string tbp325 = txtbox5.Text;
                        System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_um20");
                        string tbum20 = txtbox6.Text;
                        System.Web.UI.WebControls.TextBox txtbox7 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_caus");
                        string tbcaus = txtbox7.Text;
                        System.Web.UI.WebControls.TextBox txtbox8 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_ac");
                        string tbac = txtbox8.Text;
                        System.Web.UI.WebControls.TextBox txtbox9 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_gplsol");
                        string tbgplsol = txtbox9.Text;
                        System.Web.UI.WebControls.TextBox txtbox10 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cps_sa");
                        string tbsa = txtbox10.Text;
                        row["id"] = string.IsNullOrEmpty(sec3_id.ToString()) ? (object)DBNull.Value : sec3_id.ToString();
                        row["secid"] = string.IsNullOrEmpty(secid.ToString()) ? (object)DBNull.Value : secid.ToString();
                        row["p100"] = string.IsNullOrEmpty(tbp100.ToString()) ? (object)DBNull.Value : tbp100.ToString();
                        row["p200"] = string.IsNullOrEmpty(tbp200.ToString()) ? (object)DBNull.Value : tbp200.ToString();
                        row["p325"] = string.IsNullOrEmpty(tbp325.ToString()) ? (object)DBNull.Value : tbp325.ToString();
                        row["um20"] = string.IsNullOrEmpty(tbum20.ToString()) ? (object)DBNull.Value : tbum20.ToString();
                        row["caus"] = string.IsNullOrEmpty(tbcaus.ToString()) ? (object)DBNull.Value : tbcaus.ToString();
                        row["ac"] = string.IsNullOrEmpty(tbac.ToString()) ? (object)DBNull.Value : tbac.ToString();
                        row["gplsol"] = string.IsNullOrEmpty(tbgplsol.ToString()) ? (object)DBNull.Value : tbgplsol.ToString();
                        row["sa"] = string.IsNullOrEmpty(tbsa.ToString()) ? (object)DBNull.Value : tbsa.ToString();
                    }
                }
                Update("cont_prec_south",dt);

                //cont precip north
                dt.Rows.Clear();
                foreach (GridViewRow rows in gv_cpn.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_p100");
                    //if (txtbx.Text != "")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_cpn_seciii_id");
                        string sec3_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_secid");
                        string secid = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_p100");
                        string tbp100 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_p200");
                        string tbp200 = txtbox4.Text;
                        System.Web.UI.WebControls.TextBox txtbox5 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_p325");
                        string tbp325 = txtbox5.Text;
                        System.Web.UI.WebControls.TextBox txtbox6 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_um20");
                        string tbum20 = txtbox6.Text;
                        System.Web.UI.WebControls.TextBox txtbox7 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_caus");
                        string tbcaus = txtbox7.Text;
                        System.Web.UI.WebControls.TextBox txtbox8 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_ac");
                        string tbac = txtbox8.Text;
                        System.Web.UI.WebControls.TextBox txtbox9 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_gplsol");
                        string tbgplsol = txtbox9.Text;
                        System.Web.UI.WebControls.TextBox txtbox10 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cpn_sa");
                        string tbsa = txtbox10.Text;

                        //string.IsNullOrEmpty(dt.Rows[i]["p100"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["p100"].ToString();
                        row["id"] = string.IsNullOrEmpty(sec3_id.ToString()) ? (object)DBNull.Value : sec3_id.ToString();
                        row["secid"] = string.IsNullOrEmpty(secid.ToString()) ? (object)DBNull.Value : secid.ToString();
                        row["p100"] = string.IsNullOrEmpty(tbp100.ToString()) ? (object)DBNull.Value : tbp100.ToString();
                        row["p200"] = string.IsNullOrEmpty(tbp200.ToString()) ? (object)DBNull.Value : tbp200.ToString();
                        row["p325"] = string.IsNullOrEmpty(tbp325.ToString()) ? (object)DBNull.Value : tbp325.ToString();
                        row["um20"] = string.IsNullOrEmpty(tbum20.ToString()) ? (object)DBNull.Value : tbum20.ToString();
                        row["caus"] = string.IsNullOrEmpty(tbcaus.ToString()) ? (object)DBNull.Value : tbcaus.ToString();
                        row["ac"] = string.IsNullOrEmpty(tbac.ToString()) ? (object)DBNull.Value : tbac.ToString();
                        row["gplsol"] = string.IsNullOrEmpty(tbgplsol.ToString()) ? (object)DBNull.Value : tbgplsol.ToString();
                        row["sa"] = string.IsNullOrEmpty(tbsa.ToString()) ? (object)DBNull.Value : tbsa.ToString();
                    }
                }
                Update("cont_prec_north",dt);

                //caustic cleaning
                DataTable dt_cc = new DataTable();
                dt_cc.Columns.Add("id", typeof(string));
                dt_cc.Columns.Add("truck", typeof(string));
                dt_cc.Columns.Add("caustic", typeof(string));
                dt_cc.Columns.Add("ac", typeof(string));
                dt_cc.Columns.Add("round", typeof(string));

                foreach (GridViewRow rows in gv_cc.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cc_truck");
                    if (txtbx.Text != "")
                    {
                        var row = dt_cc.NewRow();
                        dt_cc.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_cc_ccid");
                        string cc_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cc_truck");
                        string cc_truck = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cc_caustic");
                        string cc_caustic = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cc_ac");
                        string cc_ac = txtbox4.Text;
                        System.Web.UI.WebControls.DropDownList txtbox5 = (System.Web.UI.WebControls.DropDownList)rows.FindControl("txtbox_cc_round");
                        string cc_round = txtbox5.SelectedValue;
                        row["id"] = cc_id;
                        row["truck"] = cc_truck;
                        row["caustic"] = cc_caustic;
                        row["ac"] = cc_ac;
                        row["round"] = cc_round;
                    }
                }
                Update_CausticClean("caustic_clean",dt_cc);

                //h20 tank
                DataTable dt_h2o = new DataTable();
                dt_h2o.Columns.Add("id", typeof(string));
                dt_h2o.Columns.Add("0000", typeof(string));
                dt_h2o.Columns.Add("0600", typeof(string));
                dt_h2o.Columns.Add("1200", typeof(string));
                dt_h2o.Columns.Add("1800", typeof(string));
                dt_h2o.Columns.Add("rindex", typeof(string));
               foreach (GridViewRow rows in gv_h2o.Rows)
                {
                    //System.Web.UI.WebControls.TextBox txtbx = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_cc_truck");
                    //if (txtbx.Text != "")
                    {
                        var row = dt_h2o.NewRow();
                        dt_h2o.Rows.Add(row);
                        System.Web.UI.WebControls.HiddenField txtbox1 = (System.Web.UI.WebControls.HiddenField)rows.FindControl("txtbox_h2o_id");
                        string h2o_id = txtbox1.Value;
                        System.Web.UI.WebControls.TextBox txtbox_ = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_h2o_0000");
                        string h2o_0000 = txtbox_.Text;
                        System.Web.UI.WebControls.TextBox txtbox2 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_h2o_0600");
                        string h2o_0600 = txtbox2.Text;
                        System.Web.UI.WebControls.TextBox txtbox3 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_h2o_1200");
                        string h2o_1200 = txtbox3.Text;
                        System.Web.UI.WebControls.TextBox txtbox4 = (System.Web.UI.WebControls.TextBox)rows.FindControl("txtbox_h2o_1800");
                        string h2o_1800 = txtbox4.Text;
                        row["id"] = h2o_id;
                        row["0000"] = h2o_0000;
                        row["0600"] = h2o_0600;
                        row["1200"] = h2o_1200;
                        row["1800"] = h2o_1800;
                        row["rindex"] = rows.RowIndex;
                    }
                }
                Update_h2o("h2o",dt_h2o);
                gvBind();
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
        public void PiInsert(string area, DataTable dt)
        {
            //**********************Insert records into pi********************************************
            try
            {
                LabEntities db = new LabEntities();
                PIServers myPIServers = new PIServers();
                PIServer myPIServer = myPIServers.DefaultPIServer;
                NetworkCredential credential = new NetworkCredential("labserver", "labserver1");
                myPIServer.Connect(credential);

                var date = Convert.ToDateTime(Session["sec3_date"].ToString());
                int utc = DateTime.UtcNow.Hour;
                int dt_ = DateTime.Now.Hour;

                bool dst = DSTcheck();
                if (dst)
                {
                    dt_ = dt_- 1;
                }
                int diff;
                if (utc > dt_)
                    diff = utc - dt_;
                else
                    diff = utc + 24 - dt_;
                if (area == "caustic_clean")
                {
                    var PiTagList = (from v in db.Lab_TagTable
                                     where v.Tag_Name == area
                                     orderby v.Max, v.Min
                                     select v).ToList();
                    DataTable dt_copy = new DataTable();
                    dt_copy = dt.Copy();
                    dt_copy.Columns.RemoveAt(0);
                    dt_copy.Columns.RemoveAt(3);

                    for (int i = 0; i < dt_copy.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt_copy.Columns.Count; j++)
                        {
                            string TagName = PiTagList[j].Pi_Tags;
                            string TagName_test = PiTagList[j].Pi_Tags_Test; ;
                            {
                                //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                AFValue currentTag = myPIPoint.CurrentValue();
                                currentTag.Timestamp = date;
                                currentTag.Value = Convert.ToString(dt_copy.Rows[i][j]);

                        

                                string ctv = currentTag.Value.ToString();
                                DateTime cttimestamp = currentTag.Timestamp;
                                DateTime d = cttimestamp.Date;

                                if (!string.IsNullOrEmpty(currentTag.Value.ToString()))
                                {

                                        currentTag.Value = Convert.ToString(dt_copy.Rows[i][j]);
                                        currentTag.Timestamp = date.AddHours(diff+i);
                                        myPIPoint.UpdateValue(currentTag, AFUpdateOption.Insert);
                                    
                                }
                            }
                        }
                    }
                }
            
                else
                {
                    var PiTagList = (from v in db.Lab_TagTable
                                     where v.Tag_Name == area
                                     orderby v.Max, v.Min
                                     select v).ToList();
                    DataTable dt_copy = new DataTable();
                    dt_copy = dt.Copy();
                    dt_copy.Columns.RemoveAt(0);
                    dt_copy.Columns.RemoveAt(0);
                    {
                        for (int i = 0; i < dt_copy.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt_copy.Columns.Count; j++)
                            {
                                //string TagName = item.Pi_Tags_Test.Substring(0, item.Pi_Tags_Test.Length - 5);
                                //string TagName_test = item.Pi_Tags_Test;
                                //int g;
                                //if (i != 0)
                                //{
                                //    g = (8 * i) + j;
                                //}
                                //else
                                //    g = j;
                                
                                if (area == "st_topsamples" || area == "tt_topsamples")
                                {
                                    TagName = PiTagList[j].Pi_Tags;
                                     TagName_test = PiTagList[j].Pi_Tags_Test; ;
                                }
                                else
                                {
                                    int g;
                                    if (i != 0)
                                    {
                                        g = (8 * i) + j;
                                        TagName = PiTagList[g].Pi_Tags;
                                        TagName_test = PiTagList[g].Pi_Tags_Test;
                                       
                                    }
                                    else
                                    { 
                                        
                                        TagName = PiTagList[j].Pi_Tags;
                                        TagName_test = PiTagList[j].Pi_Tags_Test; 
                                    }
                                }
                                {
                                    //PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName_test);
                                    PIPoint myPIPoint = PIPoint.FindPIPoint(myPIServer, TagName);  //-- use this when go to production
                                    AFValue currentTag = myPIPoint.CurrentValue();

                                    string s = Convert.ToString(dt_copy.Rows[i][j]);
                                    currentTag.Value = Convert.ToString(dt_copy.Rows[i][j]);
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
            //*************************End*******************************
        }
        public void Update(string area, DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand("LAB_sp_secIII", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Convert.ToInt64(dt.Rows[i]["id"].ToString());
                    cmd.Parameters.AddWithValue("@SECID", SqlDbType.VarChar).Value = dt.Rows[i]["secid"].ToString();
                    cmd.Parameters.AddWithValue("@P100", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["p100"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["p100"].ToString();
                    cmd.Parameters.AddWithValue("@P200", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["p200"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["p200"].ToString();
                    cmd.Parameters.AddWithValue("@P325", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["p325"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["p325"].ToString();
                    cmd.Parameters.AddWithValue("@UM20", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["um20"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["um20"].ToString();
                    cmd.Parameters.AddWithValue("@CAUS", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["caus"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["caus"].ToString();
                    cmd.Parameters.AddWithValue("@AC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["ac"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["ac"].ToString();
                    cmd.Parameters.AddWithValue("@GPLSOL", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["gplsol"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["gplsol"].ToString();
                    cmd.Parameters.AddWithValue("@SA", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["sa"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["sa"].ToString();
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

          PiInsert(area, dt);
        }
        public void Update_CausticClean(string area, DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand("LAB_sp_caustic_clean", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Convert.ToInt64(dt.Rows[i]["id"].ToString());
                    cmd.Parameters.AddWithValue("@TRUCK", SqlDbType.Int).Value = string.IsNullOrEmpty(dt.Rows[i]["truck"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["truck"].ToString();
                    cmd.Parameters.AddWithValue("@CAUSTIC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["caustic"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["caustic"].ToString();
                    cmd.Parameters.AddWithValue("@AC", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["ac"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["ac"].ToString();
                    cmd.Parameters.AddWithValue("@CCROUND", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["round"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["round"].ToString();
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            PiInsert(area, dt);
        }
        public void Update_h2o(string area, DataTable dt)
        {
            //string _PRODUCT = Product;
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlCommand cmd = new SqlCommand("LAB_sp_h2o_tank", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Convert.ToInt64(dt.Rows[i]["id"].ToString());
                    cmd.Parameters.AddWithValue("@0000", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["0000"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["0000"].ToString();
                    cmd.Parameters.AddWithValue("@0600", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["0600"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["0600"].ToString();
                    cmd.Parameters.AddWithValue("@1200", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["1200"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["1200"].ToString();
                    cmd.Parameters.AddWithValue("@1800", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["1800"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["1800"].ToString();
                    cmd.Parameters.AddWithValue("@rindex", SqlDbType.VarChar).Value = string.IsNullOrEmpty(dt.Rows[i]["rindex"].ToString()) ? (object)DBNull.Value : dt.Rows[i]["rindex"].ToString();
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        [WebMethod]
        public static string callCodeBehind(string selDate)
        {
            //string date = "somedate";
            //DateTime date = DateTime.Today.AddDays(-20);
            HttpContext.Current.Session["sec3_date"] = selDate;
            //DailyAlumina c = new DailyAlumina();
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
            if (HttpContext.Current.Session["sec3_date"] != null)
                dt = HttpContext.Current.Session["sec3_date"].ToString();
            else
                dt = DateTime.Today.ToShortDateString();
            string query;
            query = "SELECT SECDATE   FROM [Lab].[dbo].[LAB_SEC_III_DATA] WHERE SECDATE = '" + dt + "'";
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
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_secIII", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        protected void gv_pft_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tb = (TextBox)e.Row.FindControl("txtbox_pft_secid");
                tb.ReadOnly = true;

            }

            foreach (GridViewRow rw in gv_pft.Rows)
            {
                //txtbox_stts_caus;
                //txtbox_stts_ac;
                TextBox txtCaustic = (TextBox)rw.FindControl("txtbox_pft_caus");
                TextBox txt = (TextBox)rw.FindControl("txtbox_pft_ac");
                if (txtCaustic.Text == "")
                {
                    //txt.Text = "0.";
                }

            }


        }
        protected void gv_cps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tb = (TextBox)e.Row.FindControl("txtbox_cps_secid");
                tb.ReadOnly = true;



            }
            foreach (GridViewRow rw in gv_cps.Rows)
            {
                //txtbox_stts_caus;
                //txtbox_stts_ac;
                TextBox txtCaustic = (TextBox)rw.FindControl("txtbox_cps_p100");
                TextBox txt = (TextBox)rw.FindControl("txtbox_cps_ac");
                if (txtCaustic.Text == "")
                {
                    //txt.Text = "0.";
                }

            }



        }

        protected void gv_cpn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tb = (TextBox)e.Row.FindControl("txtbox_cpn_secid");
                tb.ReadOnly = true;

            }

            foreach (GridViewRow rw in gv_cpn.Rows)
            {
                //txtbox_stts_caus;
                //txtbox_stts_ac;
                TextBox txtCaustic = (TextBox)rw.FindControl("txtbox_cpn_p100");
                TextBox txt = (TextBox)rw.FindControl("txtbox_cpn_ac");
                if (txtCaustic.Text == "")
                {
                    //txt.Text = "0.";
                }

            }

        }

        protected void gv_cc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
            }
        }

        protected void gv_stts_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
           

            foreach (GridViewRow rw in gv_stts.Rows)
            {
                //txtbox_stts_caus;
                //txtbox_stts_ac;
                TextBox txtCaustic = (TextBox)rw.FindControl("txtbox_stts_caus");
                TextBox txt = (TextBox)rw.FindControl("txtbox_stts_ac");
                if(txtCaustic.Text == "")
                {
                    //txt.Text = "0.";
                }
                
            }
            
        }
        protected void gv_ttts_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
          

            foreach (GridViewRow rw in gv_ttts.Rows)
            {
                //txtbox_stts_caus;
                //txtbox_stts_ac;
                TextBox txtCaustic = (TextBox)rw.FindControl("txtbox_ttts_caus");
                TextBox txt = (TextBox)rw.FindControl("txtbox_ttts_ac");
                if (txtCaustic.Text == "")
                {
                    //txt.Text = "0.";
                }

            }

        }

    }
}
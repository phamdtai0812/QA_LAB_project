using QA_LAB_project.Models;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace QA_LAB_project
{
    public partial class HouseKeeping : System.Web.UI.Page
    {
        string hkdate_;
        string hkshift_;
        String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie _userRole = Request.Cookies["UserRole"];
                if (_userRole != null)
                {
                    role.Value = _userRole["role"];

                
                }
                //insertNewRow();
                bindData();
            }

        }
        public void insertNewRow()
        {
            try
            {
               
                   string dt = DateTime.Today.ToShortDateString();
              
               string query = "SELECT Date   FROM [Lab].[dbo].[LAB_HOUSEKEEPING] WHERE Date = '" + dt + "'";
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
            catch (Exception x)
            {
            }
        }
        public void createNewRow(string dt)
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand("LAB_sp_create_rows_for_housekeeping", con);
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("date", SqlDbType.Date).Value = dt;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        protected void shift_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            clearData();
            bindData();
        }
        protected void tech_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            clearData();
            ddlShift.SelectedItem.Value = "0";

        }

    protected void clearData()
        {
          
                CheckBox1.Checked = false;
        
                CheckBox1.Checked = false;
          
                CheckBox3.Checked = false;
           
                CheckBox5.Checked = false;
            
                CheckBox7.Checked = false;
            
                CheckBox9.Checked = false;

                CheckBox10.Checked = false;

                CheckBoxSumpPump1.Checked = false;
                CheckBoxSumpPump2.Checked = false;

            //CheckBox11.Checked = false;



            TextBox1.Text = "";
            TextBox2.Text = "";
        }
 
      
    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(@"C:\Users\tai.pham\Downloads\HKchecklist.png"))
                {
                    File.Delete(@"C:\Users\tai.pham\Downloads\HKchecklist.png");
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "preview()", true);


                int chkbox1; int chkbox3; int chkbox5; int chkbox7; int chkbox9; int chkbox10; int chkbox11;int chkboxSumpPump1; int chkboxSumpPump2;

                if (CheckBoxSumpPump1.Checked)
                {
                    chkboxSumpPump1 = 1;
                }
                else
                    chkboxSumpPump1 = 0;
                if (CheckBoxSumpPump2.Checked)
                {
                    chkboxSumpPump2 = 1;
                }
                else
                    chkboxSumpPump2 = 0;
                if (CheckBox1.Checked)
                {
                    chkbox1 = 1;
                }
                else
                    chkbox1 = 0;
                if (CheckBox3.Checked)
                {
                    chkbox3 = 1;
                }
                else
                    chkbox3 = 0;
                if (CheckBox5.Checked)
                {
                    chkbox5 = 1;
                }
                else
                    chkbox5 = 0;
                if (CheckBox7.Checked)
                {
                    chkbox7 = 1;
                }
                else
                    chkbox7 = 0;
                if (CheckBox9.Checked)
                {
                    chkbox9 = 1;
                }
                else
                    chkbox9 = 0;
                if (CheckBox10.Checked)
                {
                    chkbox10 = 1;
                }
                else
                    chkbox10 = 0;
              
                //if (CheckBox11.Checked)
                //{
                //    chkbox11 = 1;
                //}
                //else
                //    chkbox11 = 0;


                DateTime HKDate;
                string HKShift = ddlShift.SelectedItem.Text;

                if (Session["hk_date"] != null)
                {
                    HKDate = DateTime.Parse(Session["hk_date"].ToString());
                }
                else
                {
                    HKDate = DateTime.Today;
                }

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand("LAB_sp_housekeeping", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = HKDate;
                    cmd.Parameters.AddWithValue("Tech", SqlDbType.Int).Value = ddlTech.SelectedItem.Value;
                    cmd.Parameters.AddWithValue("@Shift", SqlDbType.VarChar).Value = HKShift;

                    cmd.Parameters.AddWithValue("@LabSumpPump1", SqlDbType.Int).Value = chkboxSumpPump1;
                    cmd.Parameters.AddWithValue("@LabSumpPump2", SqlDbType.Int).Value = chkboxSumpPump2;

                    cmd.Parameters.AddWithValue("@BenchTop", SqlDbType.Int).Value = chkbox1;
                    cmd.Parameters.AddWithValue("@Trash", SqlDbType.Int).Value = chkbox3;
                    cmd.Parameters.AddWithValue("@MSHAWorkSheet", SqlDbType.Int).Value = chkbox5;
                    cmd.Parameters.AddWithValue("@MissingLabSamples", SqlDbType.Int).Value = chkbox7;
                    cmd.Parameters.AddWithValue("@SampleDiscarded", SqlDbType.Int).Value = chkbox9;
                    cmd.Parameters.AddWithValue("@EmailsRead", SqlDbType.Int).Value = chkbox10;
                    //cmd.Parameters.AddWithValue("@Communication", SqlDbType.Int).Value = chkbox11;
                    cmd.Parameters.AddWithValue("@EquipmentOOS", SqlDbType.VarChar).Value = TextBox1.Text;
                    cmd.Parameters.AddWithValue("@OOSSamples", SqlDbType.VarChar).Value = TextBox2.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();




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

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp-mail.outlook.com", 25);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("QALab@norandaalumina.com", "Dave76664");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("QALab@norandaalumina.com", "Dave76664");

                mail.To.Add(new System.Net.Mail.MailAddress("tai.pham@norandaalumina.com"));
                mail.CC.Add(new System.Net.Mail.MailAddress("tai.pham@norandaalumina.com"));

                mail.Attachments.Add(new System.Net.Mail.Attachment(@"C:\Users\tai.pham\Downloads\HKchecklist.png"));

                mail.Subject = "Housekeeping Checklist -- " + DateTime.Now;
                smtpClient.Send(mail);
                mail.Dispose();
            }
            catch (Exception s)
            {

            }
        }
        [WebMethod]
        public static string callCodeBehind(string hkDate, string hkShift)
        {
            
            HttpContext.Current.Session["hk_date"] = hkDate.Substring(0, 10);
            HttpContext.Current.Session["hk_shift"] = hkShift;

            //hkdate_ = hkDate.Substring(0, 10);
            // hkshift_ = hkShift;
            //bindData();


            return HttpContext.Current.Session["hk_date"].ToString();
           
        }
      

        public  void bindData()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["QA_Lab_ConnectionString"].ConnectionString;
            string query;
            if (Session["hk_date"] != null)
            {
                string s = Session["hk_date"].ToString();
            }

            if (date_max.Value == "" )
            {
          
                date_max.Value = DateTime.Today.Date.ToShortDateString();
            }
            if (Session["hk_date"]  != null )
            {
                
                hkdate_ = Session["hk_date"].ToString();
                hkshift_ = Session["hk_shift"].ToString();
                string tech = ddlTech.SelectedItem.Value;
                
                date_max.Value = hkdate_.Substring(5, 2) +"-"+ hkdate_.Substring(8, 2)+"-"+ hkdate_.Substring(0,4) ;
              
                if(tech == "0" )
                {
                    tech = "1";
                }
               query = " select * FROM [Lab].[dbo].[LAB_HOUSEKEEPING] h inner join LAB_TECHNICIAN t on t.TechId = h.Tech WHERE Date = '" + hkdate_ + "' and Shift = '" + hkshift_ + "' and Tech = '" + tech + "' ";

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(query, con);

                    con.Open();
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //ddlTech.Items.FindByText(myReader["TechName"].ToString()).Selected = true;
                        //ddlTech.Items.FindByValue(myReader["TechId"].ToString()).Selected = true;
                        ddlTech.SelectedValue = myReader["TechId"].ToString();

                        if (myReader["Shift"].ToString() == "PM")
                            {
                            //ddlShift.SelectedItem.Value = "1";

                            //ddlShift.Items.Remove(ddlShift.Items.FindByText(ddlShift.SelectedItem.Text));
                            //ddlShift.SelectedItem.Text = myReader["Shift"].ToString();

                            ddlShift.Items.FindByValue("2").Selected = true;
                        }
                        else
                            ddlShift.Items.FindByValue("1").Selected = true;

                        if (myReader["BenchTop"].ToString() == "1")
                            CheckBox1.Checked = true;
                        else
                            CheckBox1.Checked = false;
                        if (myReader["Trash"].ToString() == "1")
                            CheckBox3.Checked = true;
                        else
                            CheckBox3.Checked = false;
                        if (myReader["MSHAWorkSheet"].ToString() == "1")
                            CheckBox5.Checked = true;
                        else
                            CheckBox5.Checked = false;
                        if (myReader["MissingLabSamples"].ToString() == "1")
                            CheckBox7.Checked = true;
                        else
                            CheckBox7.Checked = false;
                        if (myReader["SampleDiscarded"].ToString() == "1")
                            CheckBox9.Checked = true;
                        else
                            CheckBox9.Checked = false;

                        if (myReader["EmailsRead"].ToString() == "1")
                            CheckBox10.Checked = true;
                        else
                            CheckBox10.Checked = false;

                        //if (myReader["Communication"].ToString() == "1")
                        //    CheckBox11.Checked = true;
                        //else
                        //    CheckBox11.Checked = false;

                        if (myReader["LabSumpPump1"].ToString() == "1")
                            CheckBoxSumpPump1.Checked = true;
                        else
                            CheckBoxSumpPump1.Checked = false;

                        if (myReader["LabSumpPump2"].ToString() == "1")
                            CheckBoxSumpPump2.Checked = true;
                        else
                            CheckBoxSumpPump2.Checked = false;


                        TextBox1.Text = myReader["EquipmentOOS"].ToString();
                        TextBox2.Text = myReader["OOSSamples"].ToString();



                    }
                    con.Close();
                }
            }
        }  
    }
}
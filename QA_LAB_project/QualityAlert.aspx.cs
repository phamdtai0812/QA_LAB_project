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
using System.Net.Mail;

namespace QA_LAB_project
{
    public partial class QualityAlert : System.Web.UI.Page
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


            }
        }
        protected static  string getQualityAlert(string value)
        {
            string title = "";

            if (value == "8")
                title = "Check List for Water Hardness";
            else if (value == "9")
                title = "Check List for High Filtrate Solids";
            else if (value == "4" || value == "5")
                title = "Check List for High Leachable Soda";
            else if (value == "3")
                title = "Check List for Low Evaporation Feed Caustic";
            else if (value == "11" || value == "7")
                title = "Check List for High #8 Washer U'flow and MTL Soda";
            else
                title = "";


            return title;
        }
   
        protected void SendPDF_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
            string title;
            title = getQualityAlert(ddlQualAlert.SelectedValue);

            try
            {
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp-mail.outlook.com", 25);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("QALab@norandaalumina.com", "Dave76664");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("QALab@norandaalumina.com", "Dave76664");
                mail.To.Add(new System.Net.Mail.MailAddress("QA-Alert@norandaalumina.com"));
                //mail.To.Add(new System.Net.Mail.MailAddress("tai.pham@norandaalumina.com"));
                mail.CC.Add(new System.Net.Mail.MailAddress("tai.pham@norandaalumina.com"));

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);

                if (title != "")
                {
                    mail.Attachments.Add(new System.Net.Mail.Attachment(@"C:\QualityAlert\" + title + ".xlsx"));
                    //mail.Attachments.Add(new System.Net.Mail.Attachment(@"\\ga-fs1\shared\Everyone\Lab\QualityAlert\" + title + ".xlsx"));
                    //mail.Attachments.Add(new System.Net.Mail.Attachment(attachmentPath));

                    mail.Subject = "Quality Alert -- " + title.Substring(15, (title.Length - 15));
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
                }

                else
                {
                    mail.Subject = "Quality Alert -- " + ddlQualAlert.SelectedItem;
                }

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
                mail.IsBodyHtml = true;
                mail.Body = "CONSTITUENT:  " + TextArea1.InnerText + "<br />" + "RESULT:  " + TextArea2.InnerText + "<br />" + "INT LIMIT:  "
                        + TextArea3.InnerText + "<br />" + "SPEC LIMIT:  " + TextArea4.InnerText + "<br />" + TextArea5.InnerText;

                smtpClient.Send(mail);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
                ddlQualAlert.SelectedIndex = 0;
                TextArea1.InnerText = "";
                TextArea2.InnerText = "";
                TextArea3.InnerText = "";
                TextArea4.InnerText = "";
            }
            catch (Exception ex)
            {
            }




            //try
            //{
            //    // instantiate the html to pdf converter
            //    HtmlToPdf converter = new HtmlToPdf();
            //    // convert the url to pdf
            //    string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //    SelectPdf.PdfDocument doc = converter.ConvertUrl(url);
            //    // save pdf document
            //    doc.Save(@"\\ga-fs1\shared\Everyone\Lab\gr-tech_QA_LAB_LabTicket.aspx.pdf");
            //    // close pdf document
            //    doc.Close();


            //    ProcessStartInfo startInfo = new ProcessStartInfo();
            //    //startInfo.FileName = @"C:\Lab\Test_SendingEmailViaOutlook.exe";
            //    startInfo.FileName = @"\\ga -fs1\shared\Everyone\Tai_Pham\Lab\EmailLabTicket\Test_SendingEmailViaOutlook.exe";
            //    startInfo.Arguments = "labticket";
            //    startInfo.Verb = "runas";
            //    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //    Process.Start(startInfo);
            //    Thread.Sleep(4000);
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Email/Attachment Sent')", true);
            //}
            //catch (Exception) { }
        }
       
    }
    
}
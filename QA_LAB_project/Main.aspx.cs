using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

namespace QA_LAB_project
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString(); //Domain/Windows Account Name
            string userName = System.Environment.UserName; //Windows Account Name
            //userName_.Value = userName;
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
                        //displayRole.Value = "Admin";
                        //role.Value = "Admin";
                        //Session["Role"] = "Admin";

                        HttpCookie _userRole = new HttpCookie("UserRole");
                        _userRole["role"] = "Admin";
                        Response.Cookies.Add(_userRole);

                        break;
                    }
                    else
                    {
                        //Session["Role"] = "ReadOnly";

                        HttpCookie _userRole = new HttpCookie("UserRole");
                        _userRole["role"] = "ReadOnly";
                        Response.Cookies.Add(_userRole);
                    }
                }

            }
            catch (Exception ex)
            {
            }

        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace The2r
{
    public class SMTPService:SmtpClient
    {
        public string UserName { get; set; }

        public SMTPService():
        base( ConfigurationManager.AppSettings["SMTPHost"], Int32.Parse(ConfigurationManager.AppSettings["SMTPPort"]) )
        {
            this.UserName = ConfigurationManager.AppSettings["SMTPUser"];
            this.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["SMTPSsl"]);
            this.UseDefaultCredentials = false;
            this.Credentials = new System.Net.NetworkCredential(this.UserName, ConfigurationManager.AppSettings["SMTPPassword"]);
        }
    }
}
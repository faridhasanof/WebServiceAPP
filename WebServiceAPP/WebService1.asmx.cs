using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebServiceAPP
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public XmlDocument GetCurrency(string curname)
        {
            string result = @"<roat>{result}</roat>";
            XmlDocument xmldoc = new XmlDocument();

            string date = DateTime.Now.ToString("dd.MM.yyyy");
            xmldoc.Load("https://www.cbar.az/currencies/" + date + ".xml?wsdl");
            XmlNodeList xmlist = xmldoc.GetElementsByTagName("Valute");

            foreach (XmlNode item in xmlist)
            {
                if (item.Attributes[0].Value==curname)
                {
                    result = result.Replace("{result}", item.InnerXml);
                }


            }
            XmlDocument myxml = new XmlDocument();
            myxml.LoadXml(result);

            return myxml;
        }
    }
}

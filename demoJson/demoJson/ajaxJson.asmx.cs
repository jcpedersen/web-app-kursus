using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace demoJson
{
    /// <summary>
    /// Summary description for ajaxJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ajaxJson : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string myJson(string data1, string data2)
        {

            var keyValues = new Dictionary<string, string>
               {
                   { "email1", data1 },
                   { "email5", data2 }
               };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(keyValues);

            return json;
        }
    }
}

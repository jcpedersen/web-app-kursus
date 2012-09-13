using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace helloJson
{
    /// <summary>
    /// Summary description for ajaxJson
    /// </summary>
//    [WebService(Namespace = "http://tempuri.org/")]
//    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
//    [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]

    public class ajaxJson : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string ProcessIndexes(string jsonValue)
        {
            // We use this to deserialize the JSON argument.
            // This can also be used to serialize a return item as a JSON value.
            var serializer = new JavaScriptSerializer();
            List<IndexContainer> container = new List<IndexContainer>();

            IndexContainer tmp1 = new IndexContainer();
            IndexContainer tmp2 = new IndexContainer();
            IndexContainer tmp3 = new IndexContainer();

            tmp1.NewIndex = 1;
            tmp1.OldIndex = 2;
            tmp2.NewIndex = 3;
            tmp2.OldIndex = 4;
            tmp3.NewIndex = 5;
            tmp3.OldIndex = 6;

            container.Add(tmp1);
            container.Add(tmp2);
            container.Add(tmp3);
                
             var jSON = serializer.Serialize(container);
            
            var container2 = serializer.Deserialize<List<IndexContainer>>(jsonValue);

            IndexContainer wee = new IndexContainer();

            wee = (IndexContainer)container2[0];


             return jSON;



        }
    }

    public class IndexContainer
    {
        public int OldIndex { get; set; }
        public int NewIndex { get; set; }
    }
}

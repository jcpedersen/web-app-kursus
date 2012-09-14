using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace gameHanoi
{
    /// <summary>
    /// Summary description for ajaxAct
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ajaxAct : System.Web.Services.WebService
    {

        [WebMethod]
        public string createGame(String gameName)
        {
            return "Hello World";
        }

        [WebMethod]
        public string saveGame(Int32 gameID, String jsonValue)
        {
            return "Hello World";
        }

        [WebMethod]
        public string loadGameList(String PlayerID)
        {
            return "Hello World";
        }

        [WebMethod]
        public string loadGameJson(String GameID)
        {
            return "Hello World";
        }

        [WebMethod]
        public string deleteGame(Int32 gameID)
        {
            return "Hello World";
        }
    }
}

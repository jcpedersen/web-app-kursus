using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ajaxWebChat
{
    public partial class ajaxMsgLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((String)Request["script"] == "msgCount") {
                msgCount();    
            } // if ((String)Request["script"] == "msgCount")


            if ((String)Request["script"] == "msgLoad")
            { 
                     msgLoad();
            } // if ((String)Request["script"] == "load")
            

        }

        private void msgCount()
        {

            //SqlConnection cnn = new SqlConnection(@"Data Source=TEACH\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            if (cnn.State.ToString() == "Open")
                cnn.Close();
            cnn.Open();

            Int32 currentCount = 0;
            String sDateTime = (String)Session["lastUpdate"];
            SqlDataReader resultMsgCount = null;
            String SQLCreateCore = "SELECT COUNT(*) AS count FROM tbl_msg WHERE (msgTime > CONVERT(DATETIME, '" + sDateTime + "', 102)) and toUserID = 0;";

            String currentScript = Request["script"];

            SqlCommand commandCountMsg = new SqlCommand(SQLCreateCore, cnn);
            resultMsgCount = commandCountMsg.ExecuteReader();
            
            if (resultMsgCount.HasRows)
            {
                resultMsgCount.Read();
                currentCount = (Int32) resultMsgCount["count"];
            } // if (myReader.HasRows)

            resultMsgCount.Close();
            container.InnerHtml = currentCount.ToString();
        }

        private void msgLoad()
        {

            //SqlConnection cnn = new SqlConnection(@"Data Source=TEACH\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            if (cnn.State.ToString() == "Open")
                cnn.Close();
            cnn.Open();
            String sDateTime = (String)Session["lastUpdate"];
            String SQLCreateCore = "SELECT * FROM tbl_msg WHERE (msgTime > CONVERT(DATETIME, '" + sDateTime + "', 102)) and toUserID = 0;";
            String newDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            Session["lastUpdate"] = newDateTime;
            SqlCommand commandGetMsg = new SqlCommand(SQLCreateCore, cnn);
            SqlDataReader resultMsg = commandGetMsg.ExecuteReader();
            String sOutPut = "";

            while (resultMsg.Read())
            {
                sOutPut += "<li>" + resultMsg["msgText"] + "</li>";
            } // while (resultMsg.Read())
            container.InnerHtml = sOutPut;
            resultMsg.Close();
        }
    }

}
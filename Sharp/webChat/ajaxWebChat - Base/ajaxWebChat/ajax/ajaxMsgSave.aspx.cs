using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ajaxWebChat
{
    public partial class ajaxMsgSave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Request["script"] == "save") {
                msgSave(Request["msg"]);
            } // if ((String)Request["script"] == "save")
        }
        private void msgSave(String msg) {
            //SqlConnection cnn = new SqlConnection(@"Data Source=TEACH\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=webChat;Integrated Security=True");
            if (cnn.State.ToString() == "Open")
                cnn.Close();
            cnn.Open();

            if (msg.Length < 1)
                return;

            String sDateTime = (String)Session["lastUpdate"];
            String SQLCreateCore = "INSERT INTO tbl_msg (fromUserID, toUserID, msgText, msgTime) VALUES  (2, 0, N'" + msg + "', GETDATE())";

            SqlCommand commandCountMsg = new SqlCommand(SQLCreateCore, cnn);
            commandCountMsg.ExecuteReader();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ajaxFollowMe
{
    public partial class ajaxLoadFromDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open();
            SqlDataReader myReader = null;

            String currentScript = Request["script"];
            String SQLCreateCore = "";
            SQLCreateCore += "SELECT tbl_ajax.* FROM tbl_ajax WHERE ajaxName = '"+ currentScript + "'; ";

            SqlCommand myCommand = new SqlCommand(SQLCreateCore, cnn);
            myReader = myCommand.ExecuteReader();
            String tmpText = "";

            myReader.Read();
            
            outPut.InnerHtml = (String)myReader["ajaxHtml"];

            tmpText += "";

            myReader.Close();

        }
    }
}
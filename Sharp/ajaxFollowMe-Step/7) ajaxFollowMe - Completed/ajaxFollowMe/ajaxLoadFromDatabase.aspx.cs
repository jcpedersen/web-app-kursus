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
            SqlDataReader myReader = null;
            String SQLCreateCore = "";
            SqlConnection cnn = new SqlConnection(@"Data Source=TEACH\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open();

            String currentScript = Request["script"];
            SQLCreateCore += "SELECT tbl_ajax.* FROM tbl_ajax WHERE ajaxName = '" + currentScript + "';";

            SqlCommand myCommand = new SqlCommand(SQLCreateCore, cnn);
            myReader = myCommand.ExecuteReader();
            String tmpText = "";

            myReader.Read();

            outPut.InnerHtml = (String)myReader["ajaxHtml"];
            myReader.Close();

        }
    }
}
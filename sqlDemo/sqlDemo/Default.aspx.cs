using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace sqlDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
          {
            SqlDataReader myReader = null;
            string SQLCreateCore = "";
            SqlConnection cnn = new SqlConnection("Data Source=TEACH\\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open(); 

            SQLCreateCore += "select * from tbl_my";

            SqlCommand myCommand = new SqlCommand(SQLCreateCore, cnn);
            myReader = myCommand.ExecuteReader();
            String tmpText = "";

            while (myReader.Read())  {
                tmpText += myReader["myText"] + " ";
            }
            myReader.Close();
           Label_HelloWorld.Text = tmpText;
        }
    }
}

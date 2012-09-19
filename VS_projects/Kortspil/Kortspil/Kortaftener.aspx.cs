using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Kortspil
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=dbWhist1200;Integrated Security=True");
            sqlConn.Open();
            SqlDataReader rs = null;
            string selectCmd = "";

            selectCmd += "SELECT id, Date FROM tbl_kortaften;";

            SqlCommand sqlCommand = new SqlCommand(selectCmd, sqlConn);
            rs = sqlCommand.ExecuteReader();
            String outText = "";
            String dd_mm_yyyy = "";
            String yyyy, old_yyyy = "";
            String dd_mm = "";

            outText += "<table><th>År</th><th>Datoer</th>";
            outText += "<tr>";
            while (rs.Read())
            {
                dd_mm_yyyy = rs["Date"].ToString().Substring(0, 10);
                yyyy = dd_mm_yyyy.Substring(6, 4);
                if (yyyy != old_yyyy)
                {
                    old_yyyy = yyyy;
                    if (old_yyyy != "")
                    {
                        outText += "</tr>"; //End Line
                    }
                    outText += "<tr>"; //New line
                    outText += "<td>" + yyyy + "</td>";
                }
                dd_mm = dd_mm_yyyy.Substring(0, 5);
                outText += "<td>" + dd_mm + "</td>";
            }
            outText += "</tr>";

            rs.Close();

            outText += "</table>";
            Label_HelloWorld.Text = outText;
        }
    }
}
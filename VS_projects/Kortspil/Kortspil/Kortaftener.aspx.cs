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
            String k_id = "";

            outText += "<table>";
            outText += "<thead><tr><th>År</th><th>Datoer</th></tr></thead>";
            outText += "<tbody>";
            while (rs.Read())
            {
                k_id = rs["id"].ToString();
                dd_mm_yyyy = rs["Date"].ToString().Substring(0, 10);
                yyyy = dd_mm_yyyy.Substring(6, 4);
                if (yyyy != old_yyyy)
                {
                    old_yyyy = yyyy;
                    if (old_yyyy != "")
                    {
                        outText += "</td></tr>"; //End Line
                    }
                    outText += "<tr>"; // Start a new line (record)
                    outText += "<td>" + yyyy + "</td>"; // 1st col.
                    outText += "<td>"; // 2nd column hold all the dates with links
                }
                dd_mm = dd_mm_yyyy.Substring(0, 5);

                outText += "<a href='kortaften.aspx?Id=" + k_id + "'>";
                outText += "" + dd_mm + "</a>,&nbsp";
            }
            outText += "</td></tr></tbody>";

            rs.Close();

            outText += "</table>";
            Kortaften_liste.Text = outText;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kortspil
{
    public partial class Kortaften : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=dbWhist1200;Integrated Security=True");
            sqlConn.Open();
            SqlDataReader rs1, rs2 = null;
            string select1, select2 = "";
            int id = 1; //debug

            select1 = "SELECT * FROM tbl_user";
            SqlCommand sql1Command = new SqlCommand(select1, sqlConn);
            rs1 = sql1Command.ExecuteReader();

            select2 = "SELECT s.id, s.SpilNo, s.Melding, s.Vundne, FORMAT(s.Takst,2) FROM tbl_kortspil AS s WHERE s.SpilNo > 0 and s.idAften =" + id;
            SqlCommand sql2Command = new SqlCommand(select2, sqlConn);
            rs2 = sql2Command.ExecuteReader();

            String outText = "";
            String rsText = "";

            // Create the table header
            outText += "<table>";
            outText += "<thead><tr><th>Spil</th><th>Melding</th><th>+/-</th><th>Takst</th>";
            while (rs1.Read())
            {
                //rsText = rs1["nickName"].ToString();
                outText += "<th>" + rs1["nickName"].ToString() + "</th>"; // 

            }
            outText += "</tr></thead>";
            // End of table header

            // Create the table body
            outText += "<tbody>";
            outText += "<tr>";
            while (rs2.Read())
            {
                rsText  = "<td>" + rs2["s.id"].ToString() + "</td>";
                rsText += "<td>" + rs2["s.SpilNo"].ToString() + "</td>";
                rsText += "<td>" + rs2["s.Melding"].ToString() + "</td>";
                rsText += "<td>" + rs2["s.Vundne"].ToString() + "</td>";
                outText += rsText; // 

            }
            outText += "</tr></tbody>";
            // End of table body

            rs1.Close();
            rs2.Close();

            outText += "</table>";
            KortaftenSpil.Text = outText;
            //PlaceHolder1.ToString(outText);
        }
    }
}
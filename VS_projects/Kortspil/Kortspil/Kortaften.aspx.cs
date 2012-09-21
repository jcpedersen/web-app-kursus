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
            int id = 1; //debug

            SqlConnection sql1Conn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=dbWhist1200;Integrated Security=True");
            sql1Conn.Open();
            SqlDataReader rs1 = null;
            string select1 = "";

            select1 = "SELECT * FROM tbl_user";
            SqlCommand sql1Command = new SqlCommand(select1, sql1Conn);
            rs1 = sql1Command.ExecuteReader();

            // 2nd connection
            SqlConnection sql2Conn = new SqlConnection(@"Data Source=WIN-N931M85P3L8\MYSQL;Initial Catalog=dbWhist1200;Integrated Security=True");
            sql2Conn.Open();
            SqlDataReader rs2 = null;
            
            string select2 = "";
            select2 = "SELECT id, SpilNo, Melding, Vundne, CONVERT(varchar(10), Takst, 0) as beloeb FROM tbl_kortspil WHERE SpilNo > 0 and idAften =" + id;
            SqlCommand sql2Command = new SqlCommand(select2, sql2Conn);
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
                //rsText  = "<td>" + rs2["id"].ToString() + "</td>";
                rsText += "<td>" + rs2["SpilNo"].ToString() + "</td>";
                rsText += "<td>" + rs2["Melding"].ToString() + "</td>";
                rsText += "<td>" + rs2["Vundne"].ToString() + "</td>";
                rsText += "<td>" + rs2["beloeb"].ToString() + "</td>";
                rsText += "</tr>"; // temp!
            }
            outText += rsText; // 
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
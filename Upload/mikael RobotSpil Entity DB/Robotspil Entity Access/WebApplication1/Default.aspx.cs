using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {

        Robot r1, r2;
        Gamedata GData;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string conn = ""; //ConfigurationManager.ConnectionStrings["MyDBEntities"].ConnectionString; 

            if (Page.IsPostBack == false)
            {
                using (RobotMdlContainer context = new RobotMdlContainer())
                {

                    var robots = from a in context.EntRobotSet
                                 orderby a.Navn
                                 select a;

                    lbPerson1.DataSource = robots;
                    lbPerson1.DataValueField = "Id";
                    lbPerson1.DataTextField = "Navn";
                    lbPerson1.DataBind();

                    lbPerson2.DataSource = robots;
                    lbPerson2.DataValueField = "Id";
                    lbPerson2.DataTextField = "Navn";
                    lbPerson2.DataBind();

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (((lbPerson1.SelectedValue != null) &&
                (lbPerson2.SelectedValue != null)) &&
                ((lbPerson1.SelectedValue != "") &&
                (lbPerson2.SelectedValue != "")))
            {

                // DATABASE MODE !!!

                GData = new Gamedata();
                r1 = new Robot();
                r2 = new Robot();

                int rounds = 18;

                r1.loadRobot(Convert.ToInt32(lbPerson1.SelectedValue));
                r2.loadRobot(Convert.ToInt32(lbPerson2.SelectedValue));


                RobotGame robotGame1 = new RobotGame(r1, r2, rounds, GData);
                int result = robotGame1.fight();

                switch (result)
                {
                    case 1: StatusDiv.InnerText = r1.getNavn() + " wins"; break;
                    case 2: StatusDiv.InnerText = r1.getNavn() + " wins"; break;
                    default: StatusDiv.InnerText = "Nobody wins"; break;
                }

                Robot1_Data.InnerHtml = "<h2>" + r1.getNavn() + "</h2>";
                Robot1_Data.InnerHtml += "<ul><li>Liv: <span data-new='" + Convert.ToString(r1.getLiv()) + "'>" + Convert.ToString(r1.getLiv()) + "</span></li>";
                Robot1_Data.InnerHtml += "<li>Sejre: <span data-new='" + Convert.ToString(r1.getSejre()) + "'>" + Convert.ToString(r1.getSejre()) + "</span></li>";
                Robot1_Data.InnerHtml += "<li>Tab: <span data-new='" + Convert.ToString(r1.getTab()) + "'>" + Convert.ToString(r1.getTab()) + "</span></li>";
                Robot1_Data.InnerHtml += "<li>Uafgjort: <span data-new='" + Convert.ToString(r1.getUafgjort()) + "'>" + Convert.ToString(r1.getUafgjort()) + "</span></li></ul>";

                Robot2_Data.InnerHtml = "<h2>" + r2.getNavn() + "</h2>";
                Robot2_Data.InnerHtml += "<ul><li>Liv: <span data-new='" + Convert.ToString(r2.getLiv()) + "'>" + Convert.ToString(r2.getLiv()) + "</span></li>";
                Robot2_Data.InnerHtml += "<li>Sejre: <span data-new='" + Convert.ToString(r2.getSejre()) + "'>" + Convert.ToString(r2.getSejre()) + "</span></li>";
                Robot2_Data.InnerHtml += "<li>Tab: <span data-new='" + Convert.ToString(r2.getTab()) + "'>" + Convert.ToString(r2.getTab()) + "</span></li>";
                Robot2_Data.InnerHtml += "<li>Uafgjort: <span data-new='" + Convert.ToString(r2.getUafgjort()) + "'>" + Convert.ToString(r2.getUafgjort()) + "</span></li></ul>";

                Robot2_Data.InnerHtml += "<script>$(document).ready(function () { displayGameFlow('" + r1.getJSONData() + "','" + r2.getJSONData() + "','" + GData.getJSONData() + "', " + Convert.ToString(rounds) + "); });</script>";

                A2.HRef = "";
                A3.HRef = "";


                
                //Label1.Text = lbPerson1.SelectedValue.ToString();
            }
            else
            {
                 // Fortael lige at der ikke er trykket paa noget

                if (FileUpload1.HasFile)
                {

                    Directory.CreateDirectory("\\temp\\uploads\\");
                    string uploadPath = "\\temp\\uploads\\";

                    FileUpload1.SaveAs(uploadPath + FileUpload1.FileName);
                    FileUpload2.SaveAs(uploadPath + FileUpload2.FileName);

                    r1 = new Robot();
                    r2 = new Robot();
                    Robot r1Old;
                    Robot r2Old;

                    int rounds = 10;

                    r1.loadRobot(FileUpload1.FileName, uploadPath);
                    r2.loadRobot(FileUpload2.FileName, uploadPath);

                    r1Old = r1;
                    r2Old = r2;

                    RobotGame robotGame1 = new RobotGame(r1, r2, rounds, GData);
                    int result = robotGame1.fight();

                    switch (result)
                    {
                        case 1: StatusDiv.InnerText = r1.getNavn() + " wins"; break;
                        case 2: StatusDiv.InnerText = r1.getNavn() + " wins"; break;
                        default: StatusDiv.InnerText = "Nobody wins"; break;
                    }

                    Robot1_Data.InnerHtml = "<h2>" + r1.getNavn() + "</h2>";
                    Robot1_Data.InnerHtml += "<ul><li>Liv: <span data-new='" + Convert.ToString(r1.getLiv()) + "'>" + Convert.ToString(r1Old.getLiv()) + "</span></li>";
                    Robot1_Data.InnerHtml += "<li>Sejre: <span data-new='" + Convert.ToString(r1.getSejre()) + "'>" + Convert.ToString(r1Old.getSejre()) + "</span></li>";
                    Robot1_Data.InnerHtml += "<li>Tab: <span data-new='" + Convert.ToString(r1.getTab()) + "'>" + Convert.ToString(r1Old.getTab()) + "</span></li>";
                    Robot1_Data.InnerHtml += "<li>Uafgjort: <span data-new='" + Convert.ToString(r1.getUafgjort()) + "'>" + Convert.ToString(r1Old.getUafgjort()) + "</span></li></ul>";

                    Robot2_Data.InnerHtml = "<h2>" + r2.getNavn() + "</h2>";
                    Robot2_Data.InnerHtml += "<ul><li>Liv: <span data-new='" + Convert.ToString(r2.getLiv()) + "'>" + Convert.ToString(r2Old.getLiv()) + "</span></li>";
                    Robot2_Data.InnerHtml += "<li>Sejre: <span data-new='" + Convert.ToString(r2.getSejre()) + "'>" + Convert.ToString(r2Old.getSejre()) + "</span></li>";
                    Robot2_Data.InnerHtml += "<li>Tab: <span data-new='" + Convert.ToString(r2.getTab()) + "'>" + Convert.ToString(r2Old.getTab()) + "</span></li>";
                    Robot2_Data.InnerHtml += "<li>Uafgjort: <span data-new='" + Convert.ToString(r2.getUafgjort()) + "'>" + Convert.ToString(r2Old.getUafgjort()) + "</span></li></ul>";

                    Robot2_Data.InnerHtml += "<script>$(document).ready(function () { displayGameFlow('" + r1.getJSONData() + "','" + r2.getJSONData() + "','" + GData.getJSONData() + "', " + Convert.ToString(rounds) + "); });</script>";

                    //System.IO.File.Copy(r1.getPath(), Server.MapPath("xmls" + FileUpload1.FileName), true);
                    //System.IO.File.Copy(r2.getPath(), Server.MapPath("xmls" + FileUpload2.FileName), true);

                    A2.HRef = Server.MapPath(r1.getPath());
                    A3.HRef = Server.MapPath(r2.getPath());
                }

            }



            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotSpil_WebApplikation.RobotBackend;
using System.IO;

namespace RobotSpil_WebApplikation
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadRobot1TextBox.Text = "C:\\BjarkesStuff\\lessons\\week2_c#\\day4_robotgame\\robotspil\\RobotSpil_Data\\TestRobot1.xml";
                LoadRobot2TextBox.Text = "C:\\BjarkesStuff\\lessons\\week2_c#\\day4_robotgame\\robotspil\\RobotSpil_Data\\TestRobot1.xml";
            }


            try // <- laziness inc. (R) (C)
            {
                String filenameRobot1 = LoadRobot1TextBox.Text; // "C:\\BjarkesStuff\\lessons\\week2_c#\\day4_robotgame\\robotspil\\RobotSpil_Data\\TestRobot1.xml";
                String filenameRobot2 = LoadRobot2TextBox.Text; // "C:\\BjarkesStuff\\lessons\\week2_c#\\day4_robotgame\\robotspil\\RobotSpil_Data\\TestRobot1.xml";

                RobotLoadSave loadSave = new RobotLoadSave();
                Robot robot1 = loadSave.Load(filenameRobot1); // exception if error
                Robot robot2 = loadSave.Load(filenameRobot2); // exception if error

                int NUM_ROUNDS = 10;

                RobotGame game = new RobotGame(robot1, robot2, NUM_ROUNDS);
                RobotGame.GameResult result = game.runGame();

                String output = "";
                foreach (RoundResult roundResult in result.results)
                {

                    output += "\n";
                    output += "New round\n";
                    output += "---------\n";
                    output += "\n";
                    output += robot1.getName() + " has " + roundResult.getRobot1LivesBefore() + " lives left.\n";
                    output += robot2.getName() + " has " + roundResult.getRobot2LivesBefore() + " lives left.\n";
                    output += "\n";



                    output += robot1.getName() + " attacks with " + roundResult.getRobot1Attack() + ", " + robot2.getName() + " defends with " + roundResult.getRobot2Defense() + "\n";
                    output += roundResult.getRobot2LoosesALife() ? "Attack was successful\n" : "Attack was averted\n";

                    output += robot2.getName() + " attacks with " + roundResult.getRobot2Attack() + ", " + robot1.getName() + " defends with " + roundResult.getRobot1Defense() + "\n";
                    output += roundResult.getRobot1LoosesALife() ? "Attack was successful\n" : "Attack was averted\n";
                }

                output += "\n";

                switch (result.outcome)
                {
                    case RobotGame.Outcome.ROBOT1WINS:
                        output += "<h3>" + robot1.getName() + "wins!</h3>\n";
                        break;
                    case RobotGame.Outcome.ROBOT2WINS:
                        output += "<h3>" + robot2.getName() + "wins!</h3>\n";
                        break;
                    case RobotGame.Outcome.DRAW:
                        output += "<h3>Nobody wins! Draw between " + robot1.getName() + " and " + robot2.getName() + "</h3>\n";
                        break;
                }


                output = output.Replace("\n", "<br>");
                output = "<pre><code>" + output + "</code></pre>";

                GameWindow.Text = output;

                // TEMP: DOESN'T OVERWRITE OLD ROBOT FOR NOW
                loadSave.Save(robot1, filenameRobot1 + ".new.xml");
                loadSave.Save(robot2, filenameRobot2 + ".new.xml");
            }
            catch (Exception ex)
            {
                GameWindow.Text = "Helpful error message: Can't read robots";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Robot1UploadButton_Click(object sender, EventArgs e)
        {
            // http://asp.net-tutorials.com/controls/file-upload-control/
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/") + "robot1.txt");
            //StatusLabel.Text = "Upload status: File uploaded!";

            System.Diagnostics.Debug.WriteLine(Server.MapPath("~/"));
        }

    }
}

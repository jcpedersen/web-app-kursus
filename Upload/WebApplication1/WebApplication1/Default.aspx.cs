using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Xml.Serialization;


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Genrated by Visual Studio
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        #endregion

        #region Variables and constants
        //File path of the two robot files
        const string FILE_NAME_1 = "c:\\temp1\\Robot1.txt";
        const string FILE_NAME_2 = "c:\\temp1\\Robot2.txt";

        //Minimum number of runder
        const int MIN_NUMBER_OF_RUNDER = 10;

        #region Structures for objects to store in XML files
        /// <summary>
        /// Struktur til spil
        /// </summary>
        public struct robot
        {
            public string navn;
            public List<runde> runder;
            public int tab;
            public int sejre;
            public int liv;
            public int uafgjort;
        }


        public struct runde
        {
            public int skjold;
            public int vaaben;
        }
        
        #endregion

        #endregion

        #region Save user input in robot files

        /// <summary>
        /// Save the robot data from the website to a file
        /// </summary>
        /// <param name="fileName">The file path to save to</param>
        private void saveRobotInFile(string fileName)
        {
            robot persistent = new robot();

            try
            {
                persistent.navn = tbNavn.Text;


                persistent.tab = Convert.ToInt32(tbTab.Text);
                persistent.sejre = Convert.ToInt32(tbSejre.Text);
                persistent.liv = Convert.ToInt32(tbLiv.Text);
                persistent.uafgjort = Convert.ToInt32(tbUafgjort.Text);

            }
            catch (Exception)
            {
                tbErrorMessage.Text = "Error: Not correct input from user.";
            }

            //Save to xml file
            save(persistent, fileName);
        }

        private void saveRundeInFile(string fileName)
        {
            robot persistent = new robot();

            //Get all the content of the file
            load(ref persistent, fileName);

            runde myRunde = new runde();


            //Add en runde to runder list
            try
            {
                myRunde.skjold = Convert.ToInt32(tbSkjold.Text);
                myRunde.vaaben = Convert.ToInt32(tbVaaben.Text);

            }
            catch (Exception)
            {
                tbErrorMessage.Text = "Error: Not correct input from user.";
            }

            persistent.runder.Add(myRunde);

            //Save to xml file
            save(persistent, fileName);
        }
        
        #endregion

        #region Show Robot data for the user
        private void LoadRobotFile(string fileName)
        {
            robot persistent = new robot();

            load(ref persistent, fileName);

            string webPageOutput = string.Empty;


            webPageOutput += "navn: " + persistent.navn + "\n";

            for (int i = 0; i < persistent.runder.Count; i++)
            {
                webPageOutput += "runde " + i + ": skjold = " + persistent.runder[i].skjold + " vaaben = " + persistent.runder[i].vaaben + "\n";
            }

            webPageOutput += "tab: " + persistent.tab + "\n";
            webPageOutput += "sejre: " + persistent.sejre + "\n";
            webPageOutput += "liv: " + persistent.liv + "\n";
            webPageOutput += "uafgjort: " + persistent.uafgjort + "\n";

            tbResult.Text = webPageOutput;
        }

        #endregion

        #region Play the Robot Game
        private void playRobotGame()
        {
            #region Load robot data from files
            //Create robots
            robot r1 = new robot();
            robot r2 = new robot();

            //Add data to robots
            load(ref r1, FILE_NAME_1);
            load(ref r2, FILE_NAME_2);
            #endregion

            #region Get the number of runder from the user
            //Get the minimum number of runder from the user
            int numberOfRunder = 0;
            try
            {
                numberOfRunder = Convert.ToInt32(tbNumberOfRunder.Text);

            }
            catch (Exception)
            {
                tbErrorMessage.Text = "Error: Must be a number, at least " + MIN_NUMBER_OF_RUNDER;

                return;
            }

            if (numberOfRunder < 10)
            {
                tbErrorMessage.Text = "Error: The number of runder must be least " + MIN_NUMBER_OF_RUNDER;

                return;
            }

            #endregion

            #region User message for the start of the game
            //Message to the user
            string userMessage = string.Empty;
            userMessage += "Game start:\n";
            userMessage += "Robot1: " + r1.navn + "\n";
            userMessage += "Robot2: " + r2.navn + "\n";
            userMessage += "\n"; //Empty line

            #endregion

            #region Variable def and assignments
            //The current runde for each robot
            int currentRunde_robot1 = 0;
            int currentRunde_robot2 = 0;

            //The starting number of liv for each robot
            int currentNumberOfLiv_robot1 = r1.liv;
            int currentNumberOfLiv_robot2 = r2.liv;


            //Play
            bool isRobot1_Dead = false;
            bool isRobot2_Dead = false;
            
            #endregion

            //Execute all the runder
            for (int i = 0; i < numberOfRunder; i++)
            {

                int robot1_vaaben = r1.runder[currentRunde_robot1].vaaben;
                int robot1_skjold = r1.runder[currentRunde_robot1].skjold;
                int robot2_vaaben = r2.runder[currentRunde_robot2].vaaben;
                int robot2_skjold = r2.runder[currentRunde_robot2].skjold;

                bool isRobot1_lostOneLiv = false;
                bool isRobot2_lostOneLiv = false;
                if (robot1_skjold != robot2_vaaben)
                {
                    //Robot1 mister et liv, fordi robet1 skjold er forskellig fra robot2 vaaben,
                    isRobot1_lostOneLiv = true;
                    currentNumberOfLiv_robot1--;

                }
                if (robot2_skjold != robot1_vaaben)
                {
                    //Robot2 mister et liv, fordi robet2 skjold er forskellig fra robot1 vaaben,
                    isRobot2_lostOneLiv = true;
                    currentNumberOfLiv_robot2--;
                }

                #region Show user result for one runde
                //Show the user which runde, for the whole program, and also which runde for each robot
                userMessage += "Runde" + i + ": (robot1_runde" + currentRunde_robot1 + ", robot2_runde" + currentRunde_robot2 + ") \n";

                //Show the user result for one runde
                userMessage = addResultForOneRobot(1, robot1_vaaben, robot1_skjold, isRobot1_lostOneLiv, currentNumberOfLiv_robot1, userMessage);
                userMessage += "\n";
                userMessage = addResultForOneRobot(2, robot1_vaaben, robot2_skjold, isRobot2_lostOneLiv, currentNumberOfLiv_robot2, userMessage);
                
                #endregion

                #region Manage runde count for each robot
                //Update current runde index for each robot
                currentRunde_robot1 = updateRobotRundeCount(r1.runder.Count, currentRunde_robot1);
                currentRunde_robot2 = updateRobotRundeCount(r2.runder.Count, currentRunde_robot2);
                
                #endregion
               
                userMessage += "\n";
                userMessage += "\n";

                isRobot1_Dead = currentNumberOfLiv_robot1 < 0;
                isRobot2_Dead = currentNumberOfLiv_robot2 < 0;

                if (isRobot1_Dead || isRobot2_Dead)
                {
                    //Game is over because at least one of the robots are dead
                    break;
                }
            }

            userMessage += "Game is over.\n";

            //Compute winner result

            if (isRobot1_Dead == isRobot2_Dead)
            {
                //Det står lige, because the dead state of the two robots are equal, ie. robot1 and robot2 are both alive, or robot1 and robot2 are both dead 
                userMessage += "Det står lige.\n";
                r1.uafgjort++;
                r2.uafgjort++;
            }
            else
            {
                //There is a winner and a looser, so 
                //Find the winner
                if (isRobot2_Dead)
                {
                    //Robot 1 is still alive, because Robot2 is dead, so

                    //Robot 1 is the winner, and Robot2 is the looser
                    userMessage += "Robot1 vandt og Robot2 tabte\n";
                    r1.sejre++;
                    r2.tab++;

                }
                else
                {
                    //Robot1 is dead, and Robot2 is still alive, so

                    //Robot 1 is the looser, and Robot2 is the winner
                    userMessage += "Robot1 tabte og Robot2 vandt.\n";
                    r1.tab++;
                    r2.sejre++;
                }
            }

            userMessage += "Nuværende status of sejre og tab:\n";
            userMessage += statusOverTabOgSejre(1, r1.tab, r1.sejre, r1.uafgjort);
            userMessage += statusOverTabOgSejre(2, r2.tab, r2.sejre, r2.uafgjort);



            tbResult.Text = userMessage;

            //No errors, so delete the error message
            tbErrorMessage.Text = string.Empty;

            save(r1, FILE_NAME_1);
            save(r2, FILE_NAME_2);
        }

        /// <summary>
        /// Status over tab and sejre to the user info
        /// </summary>
        /// <param name="robotNumber"></param>
        /// <param name="tab"></param>
        /// <param name="sejre"></param>
        /// <returns></returns>
        private string statusOverTabOgSejre(int robotNumber, int tab, int sejre, int uafgjort)
        {

            string message = "Robot" + robotNumber + ": tab = " + tab + ", sejre = " + sejre + ", uafgjort = " + uafgjort + "\n";
            return message;
        }

        /// <summary>
        /// En runde for en robot to the user unfo
        /// </summary>
        /// <param name="robotNumber"></param>
        /// <param name="vaaben"></param>
        /// <param name="skjold"></param>
        /// <param name="isLostOneLiv"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string addResultForOneRobot(int robotNumber, int vaaben, int skjold, bool isLostOneLiv, int livRemaining, string message)
        {
            message += "Robot" + robotNumber + ": angriber med vaaben" + vaaben + " og forsvarer med skjold" + skjold + (!isLostOneLiv ? string.Empty : ", mistede et liv og har nu " + livRemaining + " liv tilbage");
            return message;
        }

        /// <summary>
        /// Uptate runder for each robot.
        /// This is needed because the specified max. number of a game can be bigger than the number of runder for a robot.
        /// If the robot has reached its max number of runder, 
        /// then this robot starts from runde 0 again, and circle in loop until either the game is over because one lost, 
        /// or the max. number of runder for the game is reached.
        /// </summary>
        /// <param name="numberOfRunderInRobot"></param>
        /// <param name="currentRobotRunde"></param>
        /// <returns></returns>
        private int updateRobotRundeCount(int numberOfRunderInRobot, int currentRobotRunde)
        {
            if (currentRobotRunde >= (numberOfRunderInRobot - 1))
            {
                //Robot skal starte forfra i sin runde list
                currentRobotRunde = 0;
            }
            else
            {
                currentRobotRunde++;

            } return currentRobotRunde;
        }
        
        #endregion

        #region File Save and load to xml files
        public bool save(robot persistent, string fileName)
        {
            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(robot));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, persistent);
            myWriter.Close();

            return true;
        }

        public bool load(ref robot persistent, string fileName)
        {
            bool result = false;
            FileStream myFileStream = null;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(robot));
            try
            {
                // To read the file, create a FileStream.
                myFileStream = new FileStream(fileName, FileMode.Open);
                // Call the Deserialize method and cast to the object type.
                persistent = (robot)mySerializer.Deserialize(myFileStream);

                if (myFileStream != null)
                    myFileStream.Close();

                result = true;
            }
            catch (FileNotFoundException)
            {
                //TODO: Write file not found
            }
            return result;
        }
        #endregion

        #region User Events, eg. button click methods

        protected void btnSave_Click(object sender, EventArgs e)
        {
            const string fileName = FILE_NAME_1;


            robot persistent = new robot();

            persistent.navn = "Preben Madsen";


            runde myRunde = new runde();



            persistent.runder = new List<runde>();

            myRunde.skjold = 2;
            myRunde.vaaben = 1;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 3;
            myRunde.vaaben = 4;
            persistent.runder.Add(myRunde);

            persistent.tab = 2;
            persistent.sejre = 5;
            persistent.liv = 4;
            persistent.uafgjort = 1;


            //Save to xml file
            save(persistent, fileName);

        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            string fileName = FILE_NAME_2;


            robot persistent = new robot();

            persistent.navn = "Rikke Olsen";


            runde myRunde = new runde();



            persistent.runder = new List<runde>();

            myRunde.skjold = 3;
            myRunde.vaaben = 4;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 6;
            myRunde.vaaben = 1;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 3;
            myRunde.vaaben = 4;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 6;
            myRunde.vaaben = 1;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 9;
            myRunde.vaaben = 7;
            persistent.runder.Add(myRunde);

            myRunde.skjold = 21;
            myRunde.vaaben = 25;
            persistent.runder.Add(myRunde);

            persistent.tab = 8;
            persistent.sejre = 2;
            persistent.liv = 5;
            persistent.uafgjort = 0;


            //Save to xml file
            save(persistent, fileName);


        }

        protected void btnLoad2_Click(object sender, EventArgs e)
        {
            const string fileName = FILE_NAME_2;

            LoadRobotFile(fileName);
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            const string fileName = FILE_NAME_1;


            LoadRobotFile(fileName);
        }

        protected void btnAddToFile1_Click(object sender, EventArgs e)
        {
            string fileName = FILE_NAME_1;

            saveRobotInFile(fileName);
        }

        protected void btnAddToFile2_Click(object sender, EventArgs e)
        {
            string fileName = FILE_NAME_2;

            saveRobotInFile(fileName);
        }

        protected void bdnAddRundeToFile1_Click(object sender, EventArgs e)
        {
            const string fileName = FILE_NAME_1;

            saveRundeInFile(fileName);
        }

        protected void btnAddRundeToFile2_Click(object sender, EventArgs e)
        {
            const string fileName = FILE_NAME_2;

            saveRundeInFile(fileName);
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {
            playRobotGame();
        }

        #endregion
    }
}

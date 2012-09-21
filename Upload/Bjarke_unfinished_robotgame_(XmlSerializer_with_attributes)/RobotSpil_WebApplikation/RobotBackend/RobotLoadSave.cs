using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

/*
 * Se http://www.switchonthecode.com/tutorials/csharp-tutorial-xml-serialization for cool info om XmlSerialization
 */
namespace RobotSpil_WebApplikation.RobotBackend
{
    public class RobotLoadSave
    {

        /* Internal datastructures for loading/saving (can't be private for XmlSerializer to work with them :/)*/

        public struct robot 
        {
            public String navn;
            public List<runde> runder;
            public int tab;
            public int sejre;
            public int liv;
            public int uafgjort;
        }

        public struct runde
        {
            [XmlAttribute("skjold")]
            public int skjold;
            [XmlAttribute("vaaben")]
            public int vaaben;
        }

        /** NOTE! THE DESERIALIZER REQUIRES <?xml version="1.0" encoding="..."?> */
        public Robot Load(String filename)
        {
            Type structType = typeof(robot);
            XmlSerializer serializer = new XmlSerializer(structType);
            StreamReader stream = new StreamReader(filename);
            robot robot; 
            object readObject = serializer.Deserialize(stream);
            if (readObject == null || !(readObject is robot)) {
                throw new Exception("Illegal filename or file, dude");
            } else {
                robot = (robot)readObject;
            }
            stream.Close();

            // TEST

            //System.Diagnostics.Debug.WriteLine("***************************");
            //System.Diagnostics.Debug.WriteLine(robot.navn);


            // create Robot
            return new Robot(robot.navn, convertToRoundSettings(robot.runder), robot.tab, robot.sejre, robot.liv, robot.uafgjort);
        }

        public void Save(Robot robot, String filename)
        {
            Type structType = typeof(robot);
            XmlSerializer serializer = new XmlSerializer(structType);
            StreamWriter stream = new StreamWriter(filename);
            robot robotStruct = convertClassToStruct(robot);
            serializer.Serialize(stream, robotStruct);
            stream.Close();
        }


        private robot convertClassToStruct(Robot robot)
        {
            robot robotStruct = new robot();
            robotStruct.navn = robot.getName();
            robotStruct.runder = convertFromRoundSettings(robot.getRoundSettings());
            robotStruct.sejre  = robot.getVictories();
            robotStruct.tab = robot.getDefeats();
            robotStruct.liv = robot.getLives();
            robotStruct.uafgjort = robot.getDraws();
            return robotStruct;
        }

        private List<Robot.RoundSetting> convertToRoundSettings(List<runde> runder)
        {
            List<Robot.RoundSetting> roundSettings = new List<Robot.RoundSetting>();
            foreach (runde runde in runder)
            {
                System.Diagnostics.Debug.WriteLine("RUNDE: " + runde.skjold + " " + runde.vaaben);
                Robot.RoundSetting roundSetting = new Robot.RoundSetting(runde.vaaben, runde.skjold);
                roundSettings.Add(roundSetting);
            }
            return roundSettings;
        }

        private List<runde> convertFromRoundSettings(List<Robot.RoundSetting> roundSettings)
        {
            List<runde> runder = new List<runde>();
            foreach (Robot.RoundSetting roundSetting in roundSettings)
            {
                runde runde = new runde();
                runde.skjold = roundSetting.getDefense();
                runde.vaaben = roundSetting.getAttack();
                runder.Add(runde);
            }
            return runder;
        }

    }
}
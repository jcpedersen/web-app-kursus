using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using System.Xml;
using System.Collections;
using System.IO;

namespace WebApplication1
{
    
    public class Robot
    {
        private bool EntityRobot = false;
        private Int32 EntKey = 0;

        private string navn;
        private ArrayList skjold;
        private ArrayList vaaben;
        private int liv;
        private int initLiv = 5;
        private int sejre;
        private int tab;
        private int uafgjort;

        private string xmlFileName;
        private string xmlUploadPath;
        XmlDocument xmlDocument;


        public Robot() {
            skjold = new ArrayList();
            vaaben = new ArrayList();
            xmlDocument = new XmlDocument();
        }


        public bool loadRobot(Int32 Robotid)
        {
            using (RobotMdlContainer context = new RobotMdlContainer())
            {

                EntRobot robot1 = (from a in context.EntRobotSet
                            where a.Id == Robotid
                            select a).FirstOrDefault();

                EntityRobot = true;
                xmlFileName = "";
                xmlUploadPath = "";

                navn = robot1.Navn;
                liv = robot1.Liv ;
                uafgjort = robot1.Uafgjort ;
                tab = robot1.Tab  ;
                sejre = robot1.Sejre ;

                EntKey = robot1.Id;
                
                /*
                var robotRnds = from a in robot1.RobotRunde  
                                orderby a.Id 
                                    select 1;
                */

                //EntRobotRundeData robtrn;
                foreach (EntRobotRundeData robtrn in robot1.RobotRunde)
                {
                    vaaben.Add(Convert.ToInt32(robtrn.Vaaben ));
                    skjold.Add(Convert.ToInt32(robtrn.Skjold ));

                }

            }
            return true;
        }

        public bool loadRobot(string xmlFile, string uploadPath)
        {
            EntityRobot = false;
            xmlFileName = xmlFile;
            xmlUploadPath = uploadPath;
            readXMLFileAndFillVars(uploadPath + xmlFile);
            return true;
        }

        public bool saveRobot() {
            if (EntityRobot == false)
                writeToXMLFile(xmlUploadPath + xmlFileName);
            else
            {
                using (RobotMdlContainer context = new RobotMdlContainer())
                {

                    EntRobot robot1 = (from a in context.EntRobotSet
                                       where a.Id == EntKey
                                       select a).FirstOrDefault();
                    robot1.Liv = liv;
                    robot1.Uafgjort = uafgjort;
                    robot1.Tab = tab;
                    robot1.Sejre = sejre;
                    
                    context.SaveChanges();
                }
            }
            return true;
        }

        

        public string getNavn() {
            return navn;
        }

        public int getLiv()
        {
            return liv;
        }

        public int getSejre()
        {
            return sejre;
        }

        public int getTab()
        {
            return tab;
        }

        public int getUafgjort()
        {
            return uafgjort;
        }

        public int getVaaben(int runde)
        {

            if (runde >= vaaben.Count && runde != 0)
            {
                Random rnd = new Random(362763232);
                runde = rnd.Next(vaaben.Count);
                runde = runde % vaaben.Count;
            }
            return Convert.ToInt32(vaaben[runde]);
        }

        public int getSkjold(int runde)
        {
            if (runde >= skjold.Count && runde != 0)
            {
                Random rnd = new Random(2442324);
                runde = rnd.Next(vaaben.Count);
                runde = runde % vaaben.Count;
            }
            return Convert.ToInt32(skjold[runde]);
        }

        private void readXMLFileAndFillVars(string path)
        {
            xmlDocument.Load(path);
            XmlNodeList rounds = xmlDocument.GetElementsByTagName("runde");
            for (int i = 0; i < rounds.Count; i++) {
                XmlNode n = rounds.Item(i);
                for (int j = 0; j < n.Attributes.Count; j++)
                {
                    XmlNode a = n.Attributes.Item(j);
                    if (a.Name == "vaaben") vaaben.Add(Convert.ToInt32(a.Value));
                    if (a.Name == "skjold") skjold.Add(Convert.ToInt32(a.Value));
                }
            }
            navn = Convert.ToString(xmlDocument.GetElementsByTagName("navn").Item(0).InnerText);
            liv = Convert.ToInt32(xmlDocument.GetElementsByTagName("liv").Item(0).InnerText);
            uafgjort = Convert.ToInt32(xmlDocument.GetElementsByTagName("uafgjort").Item(0).InnerText);
            tab = Convert.ToInt32(xmlDocument.GetElementsByTagName("tab").Item(0).InnerText);
            sejre = Convert.ToInt32(xmlDocument.GetElementsByTagName("sejre").Item(0).InnerText);
        }

        private void writeToXMLFile(string p)
        {
            xmlDocument.GetElementsByTagName("uafgjort").Item(0).InnerText = Convert.ToString(uafgjort);
            xmlDocument.GetElementsByTagName("sejre").Item(0).InnerText = Convert.ToString(sejre);
            xmlDocument.GetElementsByTagName("tab").Item(0).InnerText = Convert.ToString(tab);
            xmlDocument.GetElementsByTagName("liv").Item(0).InnerText = Convert.ToString(initLiv);
            
            xmlDocument.Save(p);
        }

        public ValidationEventHandler ValidationFailed { get; set; }

        private void dieOnce()
        {
            liv--;
        }

        public void newWin()
        {
            sejre++;
        }

        public void newLoose()
        {
            tab++;
            dieOnce();
        }

        public void newUafgjort()
        {
            uafgjort++;
        }

        public string getJSONData() {
            string json = "{\"name\":\"" + navn
                + "\",\"liv\":" + Convert.ToString(liv)
                + ",\"sejre\":" + Convert.ToString(sejre)
                + ",\"tab\":" + Convert.ToString(tab)
                + ",\"uafgjort\":" + Convert.ToString(tab) + ",\"vaaben\":[";
            for (int i = 0; i < vaaben.Count; i++)
            {
                json += vaaben[i];
                if (i < vaaben.Count-1) json += ",";
            }
            json += "],\"skjold\":[";
            for (int i = 0; i < skjold.Count; i++)
            {
                json += skjold[i];
                if (i < skjold.Count - 1) json += ",";
            }
            json += "]}";
            
            return json;
        }



        public string getPath()
        {
            return (xmlUploadPath + xmlFileName);
        }
    }
}
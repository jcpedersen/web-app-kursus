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
    
    public class Gamedata
    {
        private ArrayList KampUdfald;
        private ArrayList R1_VAL; // Value, shield or veapon of robot1
        private ArrayList R2_VAL;

        public Gamedata()
        {
            KampUdfald = new ArrayList();
            R1_VAL = new ArrayList();
            R2_VAL = new ArrayList();
        }

        public void TilfoejKamp(string kampdata, int r1val, int r2val)
        {
            KampUdfald.Add(kampdata);
            R1_VAL.Add(r1val);
            R2_VAL.Add(r2val);
        }


        public string getJSONData() {
            string json = "{\"KampUdfald\":[\"";
            for (int i = 0; i < KampUdfald.Count; i++)
            {
                json += KampUdfald[i];
                if (i < KampUdfald.Count - 1) json += "\",\"";
            }
            json += "\"],\"R1VAL\":[";
            for (int i = 0; i < R1_VAL.Count; i++)
            {
                json += R1_VAL[i];
                if (i < R1_VAL.Count - 1) json += ",";
            }
            json += "],\"R2VAL\":[";
            for (int i = 0; i < R2_VAL.Count; i++)
            {
                json += R2_VAL[i];
                if (i < R2_VAL.Count - 1) json += ",";
            }

            json += "]}";
            
            return json;
        }



    }
}
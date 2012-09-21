using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Web;


namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class MyService : IMyService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //Added by Preben
        #region IMyService Members

        /// <summary>
        /// For debugging, just to test that the WCF works
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string HelloWorld(string name)
        {
            return "Hello1 " + name;
        }

        /// <summary>
        /// Save the data in a file
        /// </summary>
        /// <param name="data"></param>
        public void Save(string data)
        {
            File.Delete(@"c:\pmWCFdata.txt");

            StreamWriter outfile = new StreamWriter(@"c:\pmWCFdata.txt", true);
            
            outfile.Write(data);
            outfile.Close();
        }

        /// <summary>
        /// Load the data from a file
        /// </summary>
        /// <param name="data"></param>
        public string Load()
        {
            StreamReader streamReader = new StreamReader(@"c:\pmWCFdata.txt");
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            return data;
        }

        #endregion

    }
}

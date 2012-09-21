using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections;

namespace MvcHowToChangeLabel.Models
{

    

    public  class MyDisplayName : DisplayNameAttribute
    {
        private static ArrayList  Displaynames;
        private static ArrayList  DisplaynamesDefaultValue;

        public int DbId { get; set; }

        public MyDisplayName(int DbId)
        {
            this.DbId = DbId;
            if (Displaynames == null)
                Displaynames = new ArrayList(DbId + 1);

            if (DisplaynamesDefaultValue == null)
                DisplaynamesDefaultValue = new ArrayList(DbId + 1);

            ExtendArray(DbId);
        }

        public MyDisplayName(int DbId, string _DefaultValue)
        {
            this.DbId = DbId;
            if (Displaynames == null)
                Displaynames = new ArrayList(DbId + 1);

            if (DisplaynamesDefaultValue == null)
                DisplaynamesDefaultValue = new ArrayList(DbId + 1);

            ExtendArray(DbId);  // Den kan være initieret til en mindre størrelse (static)
            DisplaynamesDefaultValue[DbId] = _DefaultValue;
        }

        private void ExtendArray(int DbId)
        {
            while ((DbId + 1) > Displaynames.Count)
            {
                Displaynames.Add(string.Empty);
                DisplaynamesDefaultValue.Add(string.Empty);
            }

        }

        public override string DisplayName
        {
            get
            {
                // Do some db-lookup to retrieve the name
                //return "Some string from DBLookup";
                try
                {
                    if ((Displaynames[DbId] == null) || (Displaynames[DbId].ToString() == ""))
                    {
                        if (DisplaynamesDefaultValue[DbId] != null)
                        return DisplaynamesDefaultValue[DbId].ToString();
                        else
                        return "";
                    }
                    else
                    {
                        return Displaynames[DbId].ToString();
                    }
                }
                catch
                {
                    return "fejl. Labelværdi ikke sat før visning. DbId:" + DbId.ToString() + ", Collectioncount: " + Displaynames.Count.ToString();
                }
            }
        }

        public string LabelValue
        {
            get
            {
                // Do some db-lookup to retrieve the name
                //return "Some string from DBLookup";
                try
                {
                    return DisplayName;
                }
                catch
                {
                    return "Check din kode... ";
                }
            }
            set
            {
                ExtendArray(DbId);
                Displaynames[DbId] = value;
            }
        }

    }

    #region Models
    public class LabelChangeModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MyDisplayName(0,"User name")] //DisplayName("User name")
        public string UserName { get; set; }
    }
    #endregion

}

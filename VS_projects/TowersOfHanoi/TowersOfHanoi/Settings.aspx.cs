using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TowersOfHanoi
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg = "";
            foreach (ListItem li in DropDownList1.Items)
            {
                if (li.Selected == true)
                {
                    msg += "<BR>" + li.Text + " was selected.";
                }
            }
            Label1.Text = msg;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ajaxWebChat
{
    public partial class webChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            Session["lastUpdate"] = sDateTime;

        }
    }
}
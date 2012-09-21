using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Hanoi2
{
    public partial class ajaxDoMove : System.Web.UI.Page
    {

        private ArrayList FromPegBars;
        private ArrayList ToPegBars;


        protected void Page_Load(object sender, EventArgs e)
        {

            string fromtowerid = Request["fromtowerid"];
            string totowerid = Request["totowerid"];

            string fromtowername = "";
            string totowername = "";

            switch(fromtowerid)       
              {         
                 case "1":
                      fromtowername = "LeftPegBars";
                    break;
                 case "2":
                    fromtowername = "MiddlePegBars";
                    break;
                 case "3":
                    fromtowername = "RightPegBars";
                    break;
                 default:
                    return;          
                    break;      
               }

            switch (totowerid)
            {
                case "1":
                    totowername = "LeftPegBars";
                    break;
                case "2":
                    totowername = "MiddlePegBars";
                    break;
                case "3":
                    totowername = "RightPegBars";
                    break;
                default:
                    return;
                    break;
            }

            //Get the 2 lists involved
            FromPegBars = (ArrayList)Session[fromtowername];
            ToPegBars = (ArrayList)Session[totowername];

            int Bar2move;
            Bar2move = (int)FromPegBars[0];

            if (ToPegBars.Count > 0)
            {
                if ((int)ToPegBars[0] < Bar2move) return;
                //Illegal move
            }
            FromPegBars.RemoveAt(0);
            ToPegBars.Reverse();
            ToPegBars.Add(Bar2move);
            ToPegBars.Reverse();

            //Save the 2 lists again
            Session[fromtowername] = FromPegBars;
            Session[totowername] = ToPegBars;

        }
    }
}

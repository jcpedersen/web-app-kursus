using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Hanoi2
{
    public partial class MoreTowers : System.Web.UI.Page
    {
        public string LeftTowerTopElement;
        public string MiddleTowerTopElement;
        public string RightTowerTopElement;

        private ArrayList LeftPegBars;
        private ArrayList MiddlePegBars;
        private ArrayList RightPegBars;

        private void GetArrayLists()
        {
            LeftPegBars = (ArrayList) Session["LeftPegBars"];
            MiddlePegBars = (ArrayList)Session["MiddlePegBars"];
            RightPegBars = (ArrayList)Session["RightPegBars"];
        }


        private void SetArrayLists()
        {
            Session["LeftPegBars"] = LeftPegBars;
            Session["MiddlePegBars"] = MiddlePegBars;
            Session["RightPegBars"] = RightPegBars;
        }


        private void dropArrayLists()
        {
            try
            {
                Session.Remove("LeftPegBars");
                Session.Remove("MiddlePegBars");
                Session.Remove("RightPegBars");
            }
            catch
            {
            }
        }

        private void NewGame(int _barcount)
        {
            for (int x = 1; x <= _barcount; x++)
            {
                LeftPegBars.Add(x);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Kaldes på prerender fordi det kører efter handling af knap klikkene...
            LoadTower();

        }
        
        private void LoadTower()
        {
            leftTower.InnerHtml = "";
            middleTower.InnerHtml = "";
            rightTower.InnerHtml = "";


            if (IsPostBack == false)
            {
                dropArrayLists();
            }
            
            if (Session["LeftPegBars"] == null)
            {

                LeftPegBars = new ArrayList();
                MiddlePegBars = new ArrayList();
                RightPegBars = new ArrayList();

                NewGame(Convert.ToInt16(tbBars.Text));

                //Save list...
                SetArrayLists();
            }
            else
            {
                GetArrayLists();
            }

            int bottom;
            int left;
            bottom = 400;
            left = 15;
            // Draw left peg
            bottom = 440 - (LeftPegBars.Count * 60);
            foreach (int barid in LeftPegBars)
            {
                left = (250 - 20 - (barid * 20)) / 2;
                leftTower.InnerHtml += " <div id='bar" + barid.ToString() + "' data-barsize='" + barid.ToString() + "' data-towerid='1' class='ui-widget-content' style='width: " + (barid * 20).ToString() + "px; height: 30px; padding: 0.5em; float: left; margin: 10px 10px 10px 0;  position: relative; top: " + bottom.ToString() + "px; left: " + left.ToString() + "px;' > <p>Bar" + barid.ToString() + "</p> </div> <div class='clear' style=' clear:both;  height:0;  width:100%;'></div>";

            }
            if (LeftPegBars.Count > 0)
            {
                LeftTowerTopElement = "bar" + LeftPegBars[0].ToString();
            }

            // middle...
            bottom = 440 - (MiddlePegBars.Count * 60);
            foreach (int barid in MiddlePegBars)
            {
                left = (250 - 20 - (barid * 20)) / 2;
                middleTower.InnerHtml += " <div id='bar" + barid.ToString() + "' data-barsize='" + barid.ToString() + "' data-towerid='2' class='ui-widget-content' style='width: " + (barid * 20).ToString() + "px; height: 30px; padding: 0.5em; float: left; margin: 10px 10px 10px 0;  position: relative; top: " + bottom.ToString() + "px; left: " + left.ToString() + "px;' > <p>Bar" + barid.ToString() + "</p> </div><div class='clear' style=' clear:both;  height:0;  width:100%;'></div>";

            }
            if (MiddlePegBars.Count > 0)
            {
                MiddleTowerTopElement = "bar" + MiddlePegBars[0].ToString();
            }

            bottom = 440 - (RightPegBars.Count * 60);
            foreach (int barid in RightPegBars)
            {
                left = (250 - 20 - (barid * 20)) / 2;
                rightTower.InnerHtml += " <div id='bar" + barid.ToString() + "' data-barsize='" + barid.ToString() + "' data-towerid='3' class='ui-widget-content' style='width: " + (barid * 20).ToString() + "px; height: 30px; padding: 0.5em; float: left; margin: 10px 10px 10px 0;  position: relative; top: " + bottom.ToString() + "px; left: " + left.ToString() + "px;'> <p>Bar" + barid.ToString() + "</p> </div><div class='clear' style=' clear:both;  height:0;  width:100%;'></div>";

            }
            if (RightPegBars.Count > 0)
            {
                RightTowerTopElement = "bar" + RightPegBars[0].ToString();
            }

            if ((LeftPegBars.Count == 0) && (MiddlePegBars.Count == 0))
            {
                resultset.InnerHtml = "Tillykke, du er færdig... ";
            }
            else resultset.InnerHtml = "";

        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            dropArrayLists();
        }
    }
}

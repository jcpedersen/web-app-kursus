using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace WCF_Client_Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRetrieveWCF_Click(object sender, EventArgs e)
        {

            //Creating Proxy for the MyService 
            MyServiceClient client = new MyServiceClient();
            Console.WriteLine("Client calling the service...");

            string receivedWCF = string.Empty;

            receivedWCF = client.HelloWorld("Preben");

            Console.WriteLine(receivedWCF);

            //Just to make the console window stop, so there is time to read
            //Console.Read();

            lblUserInfo.Text = receivedWCF;


            // Always close the client.
            client.Close();

        }

        /// <summary>
        /// Send WCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //Creating Proxy for the MyService 
            MyServiceClient client = new MyServiceClient();


            //Send the text over WCF and let the server save it in a file
            client.Save(tbWCFinput.Text);

            //Always close the client.
            client.Close();
        }

        /// <summary>
        /// Retrieve WCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrieveSavedWCF_Click(object sender, EventArgs e)
        {
            //Creating Proxy for the MyService 
            MyServiceClient client = new MyServiceClient();


            //Retrieve the WCF. The server will load it in from a file and then send it back via WCF
            string wcfResultFromServer = client.Load();

            //Show the received WCF in the client dialog box
            lblRetrievedWCF.Text = wcfResultFromServer;

            //Always close the client.
            client.Close();
        }
    }
}

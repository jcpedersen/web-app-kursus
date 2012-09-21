using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebChat
{
    public partial class ajaxLoadFromEntityDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentScript = Request["script"];
            string currentMessage = Request["message"];

            using (ChatDBContainer context = new ChatDBContainer())
            {
                        switch (currentScript) {
                            case "postmessage":


                                var msg2 = new ChatLog();
                                msg2.ChatMessage = currentMessage;
                                msg2.Createdate = System.DateTime.Now;
                                msg2.ToUserName = "";
                                msg2.FromUserName = "";

                                context.AddObject("ChatLogSet", msg2);
                                context.SaveChanges();

                                outPut.InnerHtml = msg2.ChatMessage + "<br />";
                                break;
                            case "refresh":

                                var Messages = from a in context.ChatLogSet
                                               orderby a.Createdate
                                               select a;
                                outPut.InnerHtml = "";
                                foreach (ChatLog  msg1 in Messages)
                                {
                                    outPut.InnerHtml += msg1.ChatMessage + "<br />";
                                }

                                break;
                            case "clear":

                                foreach  (ChatLog  msg1 in context.ChatLogSet)
                                {
                                    context.DeleteObject(msg1);
                                }
                                context.SaveChanges();

                                outPut.InnerHtml = "";
                                break;
                            default:
                                outPut.InnerHtml = "";
                                break;
                        }

            }

        }
    }
}
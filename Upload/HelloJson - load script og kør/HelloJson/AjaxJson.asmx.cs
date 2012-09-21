using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace HelloJson
{
    class Target
    {
        public string TargetType;
        public string TargetSelector;

        public Target(string targetType, string targetSelector)
        {
            this.TargetType = targetType;
            this.TargetSelector = targetSelector;
        }
    }
    class TargetDialogBoxData
    {
        public string Title;
        public string Body;
        public string ButtonText;
        public TargetDialogBoxData(string title, string body, string buttonText)
        {
            this.Title = title;
            this.Body = body;
            this.ButtonText = buttonText;
        }
    }
    class TargetDialogBox : Target
    {
        public TargetDialogBoxData Data;
        public TargetDialogBox(TargetDialogBoxData data) : base("dialogbox", "")
        {
            this.Data = data;
        }

    }
    class TargetScript : Target
    {
        public string ScriptFunction;
        public string ScriptCallStatement;
        public TargetScript(string targetSelector, string scriptFunction, string scriptCallStatement) : base("javascript", targetSelector)
        {
            this.ScriptFunction = scriptFunction;
            this.ScriptCallStatement = scriptCallStatement;
        }

    }

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AjaxJson : System.Web.Services.WebService
    {

        [WebMethod]
        public string TestTargetTypes(string targetType, string targetSelector)
        {
            string json = "";
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            switch (targetType)
            {
                case "dialogbox" :
                    TargetDialogBox dialog = new TargetDialogBox(new TargetDialogBoxData("testtitel", "testbody", "testtekst"));
                    json = jsSerializer.Serialize(dialog);
                    break;
                case "javascript":
                    TargetScript script = new TargetScript(targetSelector,
                                                            @"<script  type='text/javascript'>
                                                                    function myLoadedFunction(text){
                                                                        alert(text);
                                                                    }
                                                                </script>
                                                                ",
                                                            "myLoadedFunction('script')");
                    json = jsSerializer.Serialize(script);
                    break;
            }
            return json;
        }
    }
}

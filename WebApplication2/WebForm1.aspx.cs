using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private int UserControlCount
        { get
            {
                if (ViewState["count"] == null) return 0;
                return (int)ViewState["count"];
            }
            set
            {
                ViewState["count"] = value;
            }
        }
        private WebUserControl1 ControlToDelete { get; set; }

        private List<WebUserControl1> UserControls { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserControls = new List<WebUserControl1>();
            if (!IsPostBack)
            {
                var control = GetUserControl();
                Panel1.Controls.Add(control);
                UserControlCount = 1;
                return;
            }

            for (var i = 0; i < UserControlCount; i++)
            {
                var control = GetUserControl();
                Panel1.Controls.Add(control);
            }
        }

        private void OnAdd(object sender, EventArgs e)
        {
            var control = GetUserControl();
            Panel1.Controls.Add(control);
            UserControlCount++;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var control = sender as WebUserControl1;
            Panel1.Controls.Remove(control);
            UserControlCount--;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var userData = GetDataControls();
        }
        private WebUserControl1 GetUserControl(string text, string value)
        {
            var control = LoadControl("WebUserControl1.ascx") as WebUserControl1;
            control.ClickAdd += OnAdd;
            control.ClickDelete += OnDelete;
            if (text != null) control.Text = text;
            if (value != null) control.Value = value;

            return control;
        }

        private WebUserControl1 GetUserControl()
        {
            return GetUserControl(null, null);
        }

        private List<ListItem> GetDataControls()
        {
            var list = new List<ListItem>();
            foreach (var control in Panel1.Controls)
            {
                var webCont = control as WebUserControl1;
                if (webCont != null)
                {
                    list.Add(new ListItem(webCont.Text, webCont.Value));
                }
            }
            return list;
        }
    }
}
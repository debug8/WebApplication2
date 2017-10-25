using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
   // [ToolboxData("")]
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {

        protected override void OnInit(EventArgs e)
        {
            AddButton.Click += AddButton_Click;
            base.OnInit(e);
        }
        public string Text { get { return TextBox1.Text; } set { TextBox1.Text = value; } }

        public ListItem Value { get { return DropDownList1.SelectedItem; } set { DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(value); } }

        public event EventHandler ClickAdd;
        public event EventHandler ClickDelete;

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (ClickAdd == null) return;
            ClickAdd.Invoke(sender, e);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClickDelete == null) return;
            ClickDelete.Invoke(sender, e);
        }
    }
}
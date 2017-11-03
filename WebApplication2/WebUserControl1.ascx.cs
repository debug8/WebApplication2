using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {

        protected override void OnInit(EventArgs e)
        {
            AddButton.Click += AddButton_Click;
            DeleteButton.Click += DeleteButton_Click;

            base.OnInit(e);
        }
        
        public string Text { get { return TextBox1.Text; } set { TextBox1.Text = value; } }

        public string Value
        {
            get
            {
                return DropDownList1.SelectedItem.Text;
            }
            set
            {
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(new ListItem(value));
            }
        }

        public event EventHandler ClickAdd;
        public event EventHandler ClickDelete;
        public event EventHandler TextChanged;

        protected void AddButton_Click(object sender, EventArgs e)
        {
            ClickAdd?.Invoke(this, e);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            ClickDelete?.Invoke(this, e);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClassLibrary1
{
    internal class WebCustomControl1 : CompositeControl, INamingContainer
    {
        protected Panel Panel11;
        protected DropDownList DropDownList1;
        protected Button AddButton;
        protected Button DeleteButton;
        protected TextBox TextBox1;
        protected internal ListItemCollection DropDownItems {get {return DropDownList1.Items;} }

        public event EventHandler ClickAdd;
        public event EventHandler ClickDelete;

        public WebCustomControl1()
        {
            Panel11 = new Panel();
            DropDownList1 = new DropDownList();
            AddButton = new Button();
            DeleteButton = new Button();
            TextBox1 = new TextBox();
            AddButton.Click += OnAddClick;
            DeleteButton.Click += OnDeleteClick;

            InitializeControls();
        }

        public string Comment { get { return TextBox1.Text; } set { TextBox1.Text = value; } }
        public string Value { get { return DropDownList1.SelectedItem.Text; }
            set
            {
                DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(new ListItem(value));                   
            } }

        protected void OnAddClick(object sender, EventArgs e)
        {
            if (ClickAdd == null) return;
            ClickAdd.Invoke(this, e);
        }

        protected void OnDeleteClick(object sender, EventArgs e)
        {
            if (ClickDelete == null) return;
            ClickDelete.Invoke(this, e);
        }

        private void InitializeControls()
        {
            Panel11.ID = "Panel11";
            Panel11.BorderWidth = 0;
            Panel11.Height = 36;
            Panel11.Width = 500;

            DropDownList1.ID = "DropDownList1";
            DropDownList1.Height = 25;
            DropDownList1.Width = 120;

            AddButton.ID = "AddButton1";
            AddButton.Text = "Add";
            AddButton.Width = 42;

            DeleteButton.ID = "DeleteButton1";
            DeleteButton.Text = "Delete";
            DeleteButton.Width = 60;
            
            TextBox1.ID = "TextBox11";
            TextBox1.Height = 16;
            TextBox1.Width = 197;

            Controls.Add(Panel11);
            Panel11.Controls.Add(DropDownList1);
            Panel11.Controls.Add(AddButton);
            Panel11.Controls.Add(DeleteButton);
            Panel11.Controls.Add(TextBox1);
            base.CreateChildControls();
        }

    }
}

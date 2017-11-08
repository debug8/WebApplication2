using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task3
{
    public partial class OrderControl : System.Web.UI.UserControl
    {
        public event EventHandler AddButtonClick;
        public event EventHandler DeleteButtonClick;

        public int Height { get; private set; }

        protected OrderControl()
        {
            Height = 30;
        }
                
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SelectModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = sender as ListControl;
            if (SelectModeList.SelectedItem.Text == "predefined")
            {
                AddButton.Visible = true;
                DeleteButton.Visible = true;
                PredefinedPositionList.Visible = true;
                CustomPositionText.Visible = false;
            }
            if (SelectModeList.SelectedItem.Text == "custom")
            {
                AddButton.Visible = true;
                DeleteButton.Visible = true;
                CustomPositionText.Visible = true;
                PredefinedPositionList.Visible = false;
            }
        }            

        public string ReadOrderDetails()
        {
            var orderDetails = string.Empty;

            if (SelectModeList.SelectedItem.Text == "predefined")
            {
                if (PredefinedPositionList.SelectedItem == null) return string.Empty;
                orderDetails = PredefinedPositionList.SelectedItem.Text;
            }
            if (SelectModeList.SelectedItem.Text == "custom")
            {
                orderDetails = CustomPositionText.Text;
            }

            return orderDetails;
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            AddButtonClick?.Invoke(this, e);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClick?.Invoke(this, e);
        }
    }
}
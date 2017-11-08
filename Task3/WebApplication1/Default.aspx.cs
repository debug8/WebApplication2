using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Task3
{
    public partial class Default : System.Web.UI.Page
    {
        private int OrderControlHeight {
            get
            {
                if (ViewState["OrderControlHeight"] == null) return 0;
                return (int)ViewState["OrderControlHeight"];
            }
            set
            {
                ViewState["OrderControlHeight"] = value;
            }
        }
        private int OrderCount
        {
            get
            {
                if (ViewState["count"] == null) return 0;
                return (int)ViewState["count"];
            }
            set
            {
                ViewState["count"] = value;
                OrderCollection.Height = Unit.Pixel(value*OrderControlHeight + 15);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var control = GetUserControl();
                OrderControlHeight = control.Height;
                OrderCollection.Controls.Add(control);
                OrderCount = 1;
                return;
            }

            for (var i = 0; i < OrderCount; i++)
            {
                var control = GetUserControl();
                OrderCollection.Controls.Add(control);
            }
        }

        private OrderControl GetUserControl()
        {
            var control = LoadControl("OrderControl.ascx") as OrderControl;
            control.AddButtonClick += OnAdd;
            control.DeleteButtonClick += OnDelete;

            return control;
        }
        private void OnAdd(object sender, EventArgs e)
        {
            var control = GetUserControl();
            OrderCollection.Controls.Add(control);
            OrderCount++;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var control = sender as OrderControl;
            OrderCollection.Controls.Remove(control);

            OrderCount--;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var orders = GetDataControls();
            orders = orders.Where(order=>!string.IsNullOrEmpty(order) && !string.IsNullOrWhiteSpace(order)).ToList();
            SaveOrderDetailsInXml(orders);
        }

        private void SaveOrderDetailsInXml(List<string> orders)
        {
            var userAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var pathToSave = Path.Combine(userAppFolder, "Orders", Session.SessionID);
            var fileName = DateTime.Now.ToString("d.M.y-H.m.s") + ".xml";
            
            Directory.CreateDirectory(pathToSave);
            var serializer = new XmlSerializer(typeof(OrderDetails));
            var stream = new FileStream(Path.Combine(pathToSave, fileName), FileMode.Create, FileAccess.Write, FileShare.Read);

            serializer.Serialize(stream, new OrderDetails(orders));
        }
        private List<string> GetDataControls()
        {
            var list = new List<string>();
            foreach (var control in OrderCollection.Controls)
            {
                var webCont = control as OrderControl;
                if (webCont != null)
                {
                    list.Add(webCont.ReadOrderDetails());
                }
            }
            return list;
        }
    }
}
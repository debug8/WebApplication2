using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClassLibrary1
{
    [ToolboxData("<{0}:CustomList runat=server></{0}:CustomList>")]
    public class CustomList : ListControl
    {
        public List<string> DropDownValues { get; set; }
        private List<WebCustomControl1> InnerList { get; set; }

        public event EventHandler ClickAdd;
        public event EventHandler ClickDelete;
        public CustomList()
        {
            DropDownValues = new List<string>();           
            InnerList = new List<WebCustomControl1>();
            Width = 100;
        }

        public override ListItemCollection Items
        {
            get
            {
                Height = 20 + 36 * base.Items.Count;
                return base.Items;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var control = new WebCustomControl1();
                InnerList.Add(control);
                control.ClickAdd += OnAdd;
                control.ClickDelete += OnDelete;
                control.DropDownItems.AddRange(DropDownValues.Select(j => new ListItem(j)).ToArray());
                control.Value = Items[i].Value;
                control.Comment = Items[i].Text;

                control.RenderControl(writer);
            }
        }

        private void OnAdd(object sender, EventArgs e)
        {
            if (ClickAdd == null) return;
            var control = sender as WebCustomControl1;
            ClickAdd.Invoke(sender, e);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (ClickDelete == null) return;
            var control = sender as WebCustomControl1;
            ClickDelete.Invoke(sender, e);
        }
    }
}

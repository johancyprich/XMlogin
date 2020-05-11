using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMlogin.Assets.UserControls
{
	public partial class URLButton : System.Web.UI.UserControl
	{
		//=== Properties ================================================================================

		public string ImageSrc { set; get; } = "";

		public string OnMouseDown { set; get; } = "";
        public string OnMouseUp { set; get; } = "";
        public string OnMouseOut { set; get; } = "";
        public string OnMouseOver { set; get; } = "";
        public string OnMouseMove { set; get; } = "";
		public string OnMouseWheel { set; get; } = "";

		public bool NewWindow { set; get; } = false;
		public string URL { set; get; } = "";

		//=== Events ====================================================================================


		protected void Page_Load (object sender, EventArgs e)
		{
            OnMouseDown = (OnMouseDown == "") ? "" : $"this.src='{OnMouseDown}'";
            OnMouseUp = (OnMouseUp == "") ? "" : $"this.src='{OnMouseUp}'";

            OnMouseOut = (OnMouseOut == "") ? "" : $"this.src='{OnMouseOut}'";
            OnMouseOver = (OnMouseOver == "") ? "" : $"this.src='{OnMouseOver}'";

            OnMouseMove = (OnMouseMove == "") ? "" : $"this.src='{OnMouseMove}'";
            OnMouseWheel = (OnMouseWheel == "") ? "" : $"this.src='{OnMouseWheel}'";
		}


		//=== Methods ===================================================================================


		public string GetTarget ()
		{
			string target = "";

			if (NewWindow)
				target = $"_blank";

			return target;
		}
	}
}
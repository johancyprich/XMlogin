using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMlogin
{
	public partial class Terms : System.Web.UI.Page
	{
		//=== Properties ==========================================================================


		public Settings settings = new Settings ();


		//=== Events ==============================================================================


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load (object sender, EventArgs e)
		{
			// Expire cache in 1 hour.

			Response.Cache.SetCacheability (HttpCacheability.Public);
			Response.Cache.SetMaxAge (new TimeSpan (1, 0, 0));
		} // Page_Load (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_PreInit (Object sender, EventArgs e)
		{
			this.MasterPageFile = settings.SiteTemplate ();
		} // Page_PreInit (...)


		protected void Button_Agree_Click (object sender, EventArgs e)
		{
			Response.Redirect ("CreateProfile.aspx");
		} // Button_Agree_Click (...)


		//=== Methods =============================================================================

	}
}
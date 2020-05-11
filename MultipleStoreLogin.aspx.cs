using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using Cirrus.Logger;
using Cirrus.Net;
using Cirrus.XMcake;


namespace XMlogin
{
	public partial class MultipleStoreLogin : System.Web.UI.Page
	{
		//=== Properties ==========================================================================


		public Settings settings = new Settings ();
		private XMUser xmuser = new XMUser ();
		private UserWSAPI apiuser = new UserWSAPI ();

		public NetUserInfo netUserInfo = new NetUserInfo ();
		private Logger log = new Logger ();

		private string _email = "";
		private string _password = "";


		//=== Events ==============================================================================


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load (object sender, EventArgs e)
		{
			_email = Session["Email"].ToString ();
			_password = Session["Password"].ToString ();
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


		//=== Methods =============================================================================


		private string GetStoreURL (int storeID)
		{
			string url = "";

			UserWSAPI user = new UserWSAPI ();
			user.uStoreServer = settings.uStore_Server;
			url = user.GetSingleSignOnUrl (settings.uStore_WSAPI_User, settings.uStore_WSAPI_Password, _email, _password, storeID, 54036, 1, "");

			return url;
		}

		public void DisplayStores ()
		{
			using (SqlConnection conn = new SqlConnection (settings.connectString_uStore))
			{
				conn.Open ();

				string sql = "select distinct U.Login, S.StoreID, SC.Name, S.LandingDomain, S.LandingFolder "
						   + "		from Users as U "

						   + "		join ACL_UserGroupMembership UGM "
						   + "			on U.UserID = UGM.UserId "

						   + "		join ACL_UserGroup UG "
						   + "			on UG.UserGroupId = UGM.UserGroupId "

						   + "		join ACL_AccessRule AR "
						   + "			on UGM.UserGroupId = AR.UserGroupId "

						   + "		join Store S "
						   + "			on S.StoreID = AR.EntityId "

						   + "		join Store_Culture SC "
						   + "			on SC.StoreID = AR.EntityId "

						   + $"		where (U.StatusID = 1) and (U.Login = '{_email}') "
						   //+ "			and (S.StoreID != 1719) and (S.StoreID != 5972) and (S.StoreID != 5963) and (S.StoreID != 6103)";
						   + "			and (S.StoreID != 5972) and (S.StoreID != 5963) and (S.StoreID != 6103)";

				using (SqlCommand command = new SqlCommand (sql, conn))
				using (SqlDataReader reader = command.ExecuteReader ())
				{
					while (reader.Read ())
					{
						int storeID = (int)reader["StoreID"];
						string storeName = (string)reader["Name"];

						Response.Write ($"<p style='font-size: 14pt; font-weight: bold'><a href='{GetStoreURL (storeID)}' target='_parent'>{storeName}</a></p>");
					}
				}

				conn.Close ();
			}
		} // DisplayStores (...)

	}
}
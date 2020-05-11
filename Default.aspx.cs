using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Cirrus.Logger;
using Cirrus.Net;
using Cirrus.Net.Mail;
using Cirrus.XMcake;

using MySql.Data.MySqlClient;


namespace XMlogin
{
	public partial class Default : System.Web.UI.Page
	{
		//=== Constants ===========================================================================


		public const int STORE_NWTP = 1719;
		public const int STORE_CUSTOMENVELOPE = 5963;


		//=== Properties ==========================================================================


		public Settings settings = new Settings ();

		private XMHelper xmhelper = new XMHelper ();
		private XMStore xmstore = new XMStore ();
		private XMUser xmuser = new XMUser ();

		public NetUserInfo netUserInfo = new NetUserInfo ();
		private Logger log = new Logger ();

		public string userAgent = "";


		//=== Events ==============================================================================


		/// <summary>
		/// Westbank Project Order
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ImageButton_WestbankProjectOrder_Click (object sender, ImageClickEventArgs e)
		{
			log.Write ("ImageButton Press", "ImageButton_WestbankProjectOrder_Click", "200", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Westbank Project Orders image button pressed.");
			OpenURL (settings.URL_WestbankProjectOrders);
		} // ImageButton_WestbankProjectOrder_Click (...)


		protected void LinkButton_WestbankProjectOrder_Click (object sender, EventArgs e)
		{
			log.Write ("LinkButton Press", "LinkButton_WestbankProjectOrder_Click", "201", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Westbank Project Orders link button pressed.");
			OpenURL (settings.URL_WestbankProjectOrders);
		} // LinkButton_WestbankProjectOrder_Click (...)


		/// <summary>
		/// DFS Planroom Login
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void ImageButton_DFSPlanroomLogin_Click (object sender, ImageClickEventArgs e)
		{
			log.Write ("ImageButton Press", "ImageButton_DFSPlanroomLogin_Click", "210", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "DFS Plan Room Login image button pressed.");
			OpenURL (settings.URL_DFSPlanroomLogin);
		} // ImageButton_DFSPlanroomLogin_Click (...)


		protected void LinkButton_DFSPlanroomLogin_Click (object sender, EventArgs e)
		{
			log.Write ("LinkButton Press", "LinkButton_DFSPlanroomLogin_Click", "211", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "DFS Plan Room Login link button pressed.");
			OpenURL (settings.URL_DFSPlanroomLogin);
		} // LinkButton_DFSPlanroomLogin_Click (...)


		/// <summary>
		/// Order Print Envelopes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void ImageButton_OrderPrintEnvelopes_Click (object sender, ImageClickEventArgs e)
		{
			log.Write ("ImageButton Press", "ImageButton_OrderPrintEnvelopes_Click", "220", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Order Print & Envelopes image button pressed.");
			OpenURL (settings.URL_OrderPrintEnvelopes);
		} // ImageButton_OrderPrintEnvelopes_Click (...)


		protected void LinkButton_OrderPrintEnvelopes_Click (object sender, EventArgs e)
		{
			log.Write ("LinkButton Press", "LinkButton_OrderPrintEnvelopes_Click", "221", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Order Print & Envelopes link button pressed.");
			OpenURL (settings.URL_OrderPrintEnvelopes);
		} // LinkButton_OrderPrintEnvelopes_Click (...)


		/// <summary>
		/// Order Printing Supplies
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void ImageButton_OrderPrintingSupplies_Click (object sender, ImageClickEventArgs e)
		{
			log.Write ("ImageButton Press", "ImageButton_OrderPrintingSupplies_Click", "230", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Order Printing Supplies image button pressed.");
			OpenURL (settings.URL_OrderPrintingSupplies);
		} // ImageButton_OrderPrintingSupplies_Click (...)


		protected void LinkButton_OrderPrintingSupplies_Click (object sender, EventArgs e)
		{
			log.Write ("LinkButton Press", "LinkButton_OrderPrintingSupplies_Click", "231", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Order Printing Supplies link button pressed.");
			OpenURL (settings.URL_OrderPrintingSupplies);
		} // LinkButton_OrderPrintingSupplies_Click (...)


		/// <summary>
		/// Request Pickup or Delivery
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void ImageButton_RequestPickupDelivery_Click (object sender, ImageClickEventArgs e)
		{
			log.Write ("ImageButton Press", "ImageButton_RequestPickupDelivery_Click", "240", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Request PickUp or Delivery image button pressed.");
			OpenURL (settings.URL_RequestPickupDelivery);
		} // ImageButton_RequestPickupDelivery_Click (...)


		protected void LinkButton_RequestPickupDelivery_Click (object sender, EventArgs e)
		{
			log.Write ("LinkButton Press", "LinkButton_RequestPickupDelivery_Click", "241", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Request PickUp or Delivery link button pressed.");
			OpenURL (settings.URL_RequestPickupDelivery);
		} // LinkButton_RequestPickupDelivery_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ImageButton_Submit_Click (object sender, ImageClickEventArgs e)
		{
			Session["Error"] = "";

			string email = TextBox_Email.Text;
			string password = TextBox_Password.Text;

			if (!xmuser.IsUserValid (email, password))
			{
				log.Write ("Store Login", "ImageButton_Submit_Click", "110", netUserInfo.GetIpValue (), email, "", settings.Client_UserAgent, "Invalid login credentials.");

				Session["Error"] = $"<p style='font: bold 12pt/14pt Arial, san-serif; color: white; background-color: darkred; padding: 5px'>The username or password you have entered is invalid. Please try again.</p>";

				Response.Redirect ("Default.aspx");
				//Response.Redirect ("http://www.dominionblue.com/pages-2/xmlogin");
			}

			else
			{
				if (IsMultipleStores (email))
				{
					Session["Email"] = email;
					Session["Password"] = password;

					Response.Redirect ("MultipleStoreLogin.aspx");
				}

				else
					Login (email, password);
			}
		} // ImageButton_Submit_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void LinkButton_NewProfile_Click (object sender, EventArgs e)
		{
			log.Write ("Create Profile", "LinkButton_NewProfile_Click", "120", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Create profile link pressed.");

			OpenURL ("CreateProfile.aspx", false);
		} // LinkButton_NewProfile_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void LinkButton_ForgotPassword_Click (object sender, EventArgs e)
		{
			log.Write ("Forgot Password", "LinkButton_ForgotPassword_Click", "130", netUserInfo.GetIpValue (), TextBox_Email.Text, "", settings.Client_UserAgent, "Forgot password link pressed.");

			OpenURL ($"http://{settings.uStore_Server}/uStore/PasswordRecovery/PasswordReminder.aspx?StoreId=1719");
		} // LinkButton_ForgotPassword_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load (object sender, EventArgs e)
		{
			// Expire cache in 1 hour.

			//Response.Cache.SetExpires (DateTime.Now.AddYears (1));
			Response.Cache.SetCacheability (HttpCacheability.Public);
			Response.Cache.SetMaxAge (new TimeSpan (1, 0, 0));

			// uStore settings.

			xmuser.uStoreServer = settings.uStore_Server;
			xmuser.WSAPI_User = settings.uStore_WSAPI_User;
			xmuser.WSAPI_Password = settings.uStore_WSAPI_Password;

			xmhelper.ConnectionString = settings.connectString_XMHelper;
			xmstore.ConnectionString = settings.connectString_uStore;
			xmuser.ConnectionString = settings.connectString_uStore;

			log.DatabaseConnect (settings.connectString_Log, "xmlogin_Log");
			log.LogToDatabase = true;
			log.AppName = (settings.Options_SiteStatus == "staging") ? $"{settings.Application_Name} (staging)" : settings.Application_Name;
			log.AppVersion = settings.Application_Version;
			log.AppFilename = "Default.aspx.cs";
		} // Page_Load (...)


		/// <summary>
		/// Select template for web page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_PreInit (Object sender, EventArgs e)
		{
			this.MasterPageFile = settings.SiteTemplate ();
		} // Page_PreInit (...)


		//=== Methods =============================================================================


		/// <summary>
		/// Counts the number of orders that a user placed in a store.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="storeID"></param>
		/// <returns></returns>
		private int CountOrders (string email, int storeID)
		{
			int count = 0;

			string sql = "select count(*)"
					   + "		from Orders O"

					   + "		join Users U"
					   + "			on O.CustomerID = U.UserID"

					   + "		where (O.StoreID=" + storeID + ") and (U.Email='" + email + "')";

			using (SqlConnection conn = new SqlConnection (settings.connectString_uStore))
			{
				conn.Open ();

				using (SqlCommand command = new SqlCommand (sql, conn))
				{
					count = (Int32)command.ExecuteScalar ();
				}

				conn.Close ();
			}

			return count;
		} // CountOrders (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="top"></param>
		public void DisplayError (bool top)
		{
			if (top)
			{
				if (Session["Error"] != null)
					Response.Write (Session["Error"]);
			}

			else
			{
				if (Session["Error"] != null)
				{
					Response.Write ("<p>&nbsp;</p>");
					Response.Write (Session["Error"]);
					Session["Error"] = "";
				}
			}
		} // DisplayError (...)


		/// <summary>
		/// Returns the first company store that a user has access to.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		private int GetCompanyStore (string email)
		{
			int id = 0;

			using (SqlConnection conn = new SqlConnection (settings.connectString_uStore))
			{
				conn.Open ();

				string sql = "select distinct S.StoreID"
						   + "		from Users as U"

						   + "		join ACL_UserGroupMembership UGM"
						   + "			on U.UserID = UGM.UserId"

						   + "		join ACL_UserGroup UG"
						   + "			on UG.UserGroupId = UGM.UserGroupId"

						   + "		join ACL_AccessRule AR"
						   + "			on UGM.UserGroupId = AR.UserGroupId"

						   + "		join Store S"
						   + "			on S.StoreID = AR.EntityId"

						   + "		join Store_Culture SC"
						   + "			on SC.StoreID = AR.EntityId"

						   + "		where (U.StatusID = 1) and (U.Login = '" + email + "')"
						   + "			  and (S.StoreID not in (10, 1202, 1316, 1543, 1719, 1788, 5846, 5904, 5963, 5994, 6103))";

				using (SqlCommand command = new SqlCommand (sql, conn))
				using (SqlDataReader reader = command.ExecuteReader ())
				{
					while (reader.Read ())
						id = (int)reader ["StoreID"];
				}

				conn.Close ();
			}

			return id;
		} // GetCompanyStore (...)


		public string GetContent ()
		{
			string content = "";
			
			string sql = "select *"
					   + "		from d4rsn_domblue_customcontent"
					   + "		where application='xmlogin'";

			using (var conn = new MySqlConnection (settings.connectString_Domblue))
			{
				conn.Open ();

				using (var command = new MySqlCommand (sql, conn))
				using (var reader = command.ExecuteReader ())
				{
					while (reader.Read ())
					{
						//content = (string)reader["content"];

						byte[] bytecontent = (byte[])reader["content"];
						content = Encoding.UTF8.GetString (bytecontent, 0, bytecontent.Length);
					}
				}
			}

			return content;
		}


		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		/// <param name="email"></param>
		/// <param name="storeID"></param>
		public void GetSalesRepInfo (out string name, out string email, int storeID)
		{
			/***********************************************************************************************/

			int GetAccountNo (string folder)
			{
				int account = 0;

				using (SqlConnection conn = new SqlConnection (settings.connectString_uStoreScopes))
				{
					conn.Open ();

					string sql = "select *"
							   + "		from uStoreScopes"
							   + $"		where FolderName='{folder}'";

					using (SqlCommand command = new SqlCommand (sql, conn))
					using (SqlDataReader reader = command.ExecuteReader ())
					{
						while (reader.Read ())
							account = (int)reader["AccountNo"];
					}

					conn.Close ();
				}

				return account;
			}

			/***********************************************************************************************/

			string GetSalesCode (int account)
			{
				string firstname = "";

				using (SqlConnection conn = new SqlConnection (settings.connectString_PID))
				{
					conn.Open ();

					string sql = "select SalesCode"
							   + "		from dbCustomer"
							   + $"		where CompanyID={account}";

					using (SqlCommand command = new SqlCommand (sql, conn))
					using (SqlDataReader reader = command.ExecuteReader ())
					{
						while (reader.Read ())
							firstname = (string)reader["SalesCode"];
					}

					conn.Close ();
				}

				return firstname;
			}

			/***********************************************************************************************/

			void GetSalesInfo (string firstName, out string repName, out string repEmail)
			{
				repName = "Randy Brown";
				repEmail = "rbrown@dominionblue.com";

				using (SqlConnection conn = new SqlConnection (settings.connectString_Intranet))
				{
					conn.Open ();

					string sql = "select FirstName, LastName, Email"
							   + "		from Auth_Users"
							   + $"		where FirstName='{firstName}'";

					using (SqlCommand command = new SqlCommand (sql, conn))
					using (SqlDataReader reader = command.ExecuteReader ())
					{
						while (reader.Read ())
						{
							repName = (string)reader["FirstName"] + " " + (string)reader["LastName"];
							repEmail = (string)reader["Email"];
						}
					}

					conn.Close ();
				}
			}

			/***********************************************************************************************/

			name = "";
			email = "";

			string landingFolder = xmuser.GetLandingFolder (storeID);
			int accountNo = GetAccountNo (landingFolder);
			string salesCode = GetSalesCode (accountNo);

			GetSalesInfo (salesCode, out name, out email);
		} // GetSalesRepInfo (...)


		/// <summary>
		/// Get the store that user should login to.
		/// </summary>
		/// <returns></returns>
		private int GetUserStore ()
		{
			int store = 0;

			string email = TextBox_Email.Text;

			// Does user have a company store?

			store = GetCompanyStore (email);

			if (store == 0)
			{
				// Did user order on NWTP?

				/*
				if (CountStores (email, 1719) > 0)
				{
					store = store_NWTP;

					if (GetStoreIDfromDomain (email) > 0)
					{
						// SendMail ();
						store = store_CustomEnvelope;
					}
				}

				else
					store = store_NWTP;
				*/

				store = STORE_NWTP;
			}

			return store;
		} // GetUserStore (...)


		private bool IsMultipleStores (string email)
		{
			int storeID = 0;
			int storeCount = 0;

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

						   + $"		where (U.StatusID = 1) and (U.Login = '{email}') "
						   + "			and (S.StoreID != 1719) and (S.StoreID != 5972) and (S.StoreID != 5963) and (S.StoreID != 6103)";

				using (SqlCommand command = new SqlCommand (sql, conn))
				using (SqlDataReader reader = command.ExecuteReader ())
				{
					while (reader.Read ())
					{
						storeID = (int)reader["StoreID"];
						++storeCount;
					}
				}

				conn.Close ();
			}

			return (storeCount > 1);
		}


		/// <summary>
		/// Login in to a store.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		private void Login (string email, string password)
		{
			// Does the user have a store? If no, assign storeID = NWTP, else storeID = Customer Store.

			int storeID = GetCompanyStore (email);

			if (storeID == 0)
				storeID = STORE_NWTP;

			string url = xmuser.GetLoginURL (email, password, $"{storeID}");

			// If the user is in a company that has a store, send email to let them know. New user goes directly to order form.

			if (storeID == STORE_NWTP)
			{
				string salesRepName = "";
				string salesRepEmail = "";

				int dedicatedStoreID = xmhelper.GetStoreIDfromDomain (email);

				GetSalesRepInfo (out salesRepName, out salesRepEmail, dedicatedStoreID);

				string storeURL = $"http://{settings.uStore_Server}/ustore/?storeid={dedicatedStoreID}";
				string subject = "Your Company has a dedicated Online Ordering Portal with Dominion Blue";

				string htmlBody = $"<p>Dear {xmuser.GetName (email)} for <a href='{storeURL}'>{xmstore.GetStoreName (dedicatedStoreID)}</a>,</p>"
								+ "<p>Your company has a dedicated online ordering portal with Dominion Blue. In addition to being able to order your day to day print services you may have access to a library of items your company has posted in the portal. Items such as business cards, marketing collateral, architectural drawings & projects, etc. may be posted there."
								+ $"<p>Your account rep ({salesRepName}, <a href='mailto:{salesRepEmail}'>{salesRepEmail}</a>) will be in touch with your office admin to see if you should have access to this portal.</p>"
								+ "<p>"
								+ "    Sincerely,<br />"
								+ "    The Dominion Blue<br />"
								+ "    Order Portal Team"
								+ "</p>"
								+ "<p>"
								+ "    Office <a href='tel:604-681-7504'>604.681.7504</a> | <a href='http://www.dominionblue.com'>www.dominionblue.com</a><br />"
								+ "    Vancouver | Downtown Core | North Shore | Richmond | Burnaby<br />"
								+ "    99 West 6th Avenue, Vancouver, BC V5Y 1K2"
								+ "</p>";

				string textBody = $"Dear {xmuser.GetName (email)} for NWTPForm,{Environment.NewLine}"
								+ Environment.NewLine
								+ $"Your company has a dedicated online ordering portal with Dominion Blue. In addition to being able to order your day to day print services you may have access to a library of items your company has posted in the portal. Items such as business cards, marketing collateral, architectural drawings & projects, etc. may be posted there.{Environment.NewLine}"
								+ Environment.NewLine
								+ $"Your account rep ({salesRepName}, {salesRepEmail}) will be in touch with your office admin to see if you should have access to this portal.{Environment.NewLine}"
								+ Environment.NewLine
								+ $"Sincerely,{Environment.NewLine}"
								+ $"The Dominion Blue{Environment.NewLine}"
								+ $"Order Portal Team{Environment.NewLine}"
								+ Environment.NewLine
								+ $"Office 604.681.7504 | www.dominionblue.com{Environment.NewLine}"
								+ $"Vancouver | Downtown Core | North Shore | Richmond | Burnaby{Environment.NewLine}"
								+ $"99 West 6th Avenue, Vancouver, BC V5Y 1K2{Environment.NewLine}";

				// Sign in the NWTP store and open the order printing form.

				UserWSAPI user = new UserWSAPI ();
				user.uStoreServer = settings.uStore_Server;
				url = user.GetSingleSignOnUrl (settings.uStore_WSAPI_User, settings.uStore_WSAPI_Password, email, password, STORE_NWTP, 54036, 1, "");

				log.Write ("Store Login", "Login", "100", netUserInfo.GetIpValue (), email, "", settings.Client_UserAgent, $"Login to store: {xmstore.GetStoreName (storeID)}; {storeID}.");

				OpenURL (url);
			}

			// Existing store user goes to their store's welcome page.

			else
			{
				log.Write ("Store Login", "Login", "100", netUserInfo.GetIpValue (), email, "", settings.Client_UserAgent, $"Login to store: {xmstore.GetStoreName (storeID)}; {storeID}.");

				url = xmuser.GetLoginURL (email, password, storeID.ToString());
				OpenURL (url);
			}
		} // Login (...)


		/// <summary>
		/// Open a URL in the same window or a new window.
		/// </summary>
		/// <param name="url"></param>
		/// <param name="newWindow"></param>
		private void OpenURL (string url, bool newWindow = true)
		{
			if (newWindow)
				Response.Write ($"<script language='javascript'>self.parent.location='{url}';</script>");

			else
				Response.Redirect (url);
		} // OpenURL (...)

	}
}
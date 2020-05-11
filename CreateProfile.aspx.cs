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
	public partial class CreateProfile: System.Web.UI.Page
	{
		//=== Properties ==========================================================================


		public Settings settings = new Settings ();
		private XMUser xmuser = new XMUser ();
		private UserWSAPI apiuser = new UserWSAPI ();

		public NetUserInfo netUserInfo = new NetUserInfo ();
		private Logger log = new Logger ();

		private const int STORE_NWTP = 1719;

		private string firstName = "";
		private string lastName = "";
		private string email = "";
		private string phoneNumber = "";
		private string mobileNumber = "";
		private string companyName = "";
		private string address = "";
		private string city = "";
		private string postalCode = "";
		int country = 0;
		int province = 0;


		//=== Events ==============================================================================


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_Submit_Click (object sender, EventArgs e)
		{
			string email = TextBox_Email.Text;
			string password = TextBox_Password.Text;

			TextBox_FirstName.Text = firstName;
			TextBox_LastName.Text = lastName;
			TextBox_Email.Text = email;
			TextBox_PhoneNumber.Text = phoneNumber;
			TextBox_MobileNumber.Text = mobileNumber;
			TextBox_Company.Text = companyName;
			TextBox_Address1.Text = address;
			TextBox_City.Text = city;
			TextBox_PostalCode.Text = postalCode;

			if (xmuser.GetUserID (email) != 0)
			{
				Session["Error"] = $"<p style='font: bold 12pt/14pt Arial, san-serif; color: white; background-color: darkred; padding: 5px'><span style='color: cyan;'>{email}</span> exists in the store.<br />"
								 + "Please use another email address.<br />"
								 + $"Go to <a href='http://{settings.Options_HomeURL}/pages-2/xmlogin' target='_top'>login</a> page to reset password.</p>"
								 + "<p>&nbsp;</p>";

				log.Write ("Existing Profile", "Button_Submit_Click", "320", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", "", "User tried to create profile with an existing email.");
			}

			else if (!CheckBox_Terms.Checked)
			{
				Session["Error"] = "<p style='font: bold 12pt/14pt Arial, san-serif; color: white; background-color: darkred; padding: 5px'>Please accept the Terms and Conditions to create your profile."
								 + "<p>&nbsp;</p>";

				log.Write ("Terms & Conditions", "Button_Submit_Click", "330", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", settings.Client_UserAgent, "User did not accept terms and conditions.");

				//Response.Redirect ("CreateProfile.aspx");
			}

			else
			{
				CreateUser ();
				Login (email, password);
			}
		} // Button_Submit_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_Reset_Click (object sender, EventArgs e)
		{
			log.Write ("Form Reset", "Button_Reset_Click", "340", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", settings.Client_UserAgent, "User reset form.");
			Response.Redirect (Request.RawUrl);
		} // Button_Reset_Click (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DropDownList_Country_SelectedIndexChanged (object sender, EventArgs e)
		{
			log.Write ("New Country", "DropDownList_Country_SelectedIndexChanged", "340", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", settings.Client_UserAgent, "User changed country.");
			PopulateProvinces (DropDownList_Country.SelectedValue);
		} // DropDownList_Country_SelectedIndexChanged (...)


		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void LinkButton_Terms_Click (object sender, EventArgs e)
		{
			//Response.Redirect (settings.URL_Terms);
			Response.Redirect ("Terms.aspx");
		} // LinkButton_Terms_Click (...)


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

			// Set database for logging.

			log.DatabaseConnect (settings.connectString_Log, "xmlogin_Log");
			log.LogToDatabase = true;
			log.AppName = (settings.Options_SiteStatus == "staging") ? $"{settings.Application_Name} (staging)" : settings.Application_Name;
			log.AppVersion = settings.Application_Version;
			log.AppFilename = "CreateProfile.aspx.cs";

			if (IsPostBack)
			{
				firstName = TextBox_FirstName.Text;
				lastName = TextBox_LastName.Text;
				email = TextBox_Email.Text;
				phoneNumber = TextBox_PhoneNumber.Text;
				mobileNumber = TextBox_MobileNumber.Text;
				companyName = TextBox_Company.Text;
				address = TextBox_Address1.Text;
				city = TextBox_City.Text;
				postalCode = TextBox_PostalCode.Text;
			}

			xmuser.ConnectionString = settings.connectString_uStore;
			xmuser.uStoreServer = settings.uStore_Server;
			xmuser.WSAPI_User = settings.uStore_WSAPI_User;
			xmuser.WSAPI_Password = settings.uStore_WSAPI_Password;

			CheckBox_Terms.Text = $"&nbsp;I accept the <a href='{settings.URL_Terms}'>Terms & Conditions</a>";
			//CheckBox_Terms.Text = $"&nbsp;I accept the ";

			if (!IsPostBack)
			{
				DropDownList_Country.SelectedIndex = 37;

				PopulateProvinces ("36");
			}

			else
			{
				if (DropDownList_Country.SelectedValue == "231")
					Label_Province.Text = "State:";
				else
					Label_Province.Text = "Province:";
			}
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


		/// <summary>
		///
		/// </summary>
		public void CreateUser ()
		{
			string uStoreServer = settings.uStore_Server;
			string WSAPI_User = settings.uStore_WSAPI_User;
			string WSAPI_Password = settings.uStore_WSAPI_Password;

			string email = TextBox_Email.Text;
			string password = TextBox_Password.Text;
			string firstName = TextBox_FirstName.Text;
			string lastName = TextBox_LastName.Text;

			// Creates a new user with the given details and globally unique email address

			int id = xmuser.GetUserID (email);

			if (id > 0)
				Response.Write ($"User {email} exists.");

			else
			{
				// Create new user.

				BasicHttpBinding binding = new BasicHttpBinding ();
				EndpointAddress addressUserWS = new EndpointAddress ($"http://{uStoreServer}/uStoreWSAPI/UserWS.asmx");
				WSAPI_UserWS.UserWSSoapClient userWS = new WSAPI_UserWS.UserWSSoapClient (binding, addressUserWS);

				id = userWS.AddUser (WSAPI_User, WSAPI_Password, firstName, lastName, email, password, "");

				// Update user details.

				WSAPI_UserWS.User newUser = userWS.GetUser (WSAPI_User, WSAPI_Password, id);

				newUser.PhoneNumber = TextBox_PhoneNumber.Text;
				newUser.MobileNumber = TextBox_MobileNumber.Text;
				newUser.CompanyName = TextBox_Company.Text;
				newUser.Department = TextBox_Department.Text;
				newUser.JobTitle = TextBox_JobTitle.Text;

				userWS.UpdateUserDetails (WSAPI_User, WSAPI_Password, newUser);

				// Add user to group: ".. to Multi Users for Estimate & NWTP Stores (ID: 1719, 5963 & 6103) - Registered Cust",
				// UserGroupID = 16966.

				EndpointAddress addressUserGroupWS = new EndpointAddress ($"http://{uStoreServer}/uStoreWSAPI/UserGroupWS.asmx");
				WSAPI_UserGroupWS.UserGroupWSSoapClient userGroupWS = new WSAPI_UserGroupWS.UserGroupWSSoapClient (binding, addressUserGroupWS);

				userGroupWS.AddUserToGroup (WSAPI_User, WSAPI_Password, id, 16966);

				// Add billing address.

				EndpointAddress addressAddressWS = new EndpointAddress ($"http://{uStoreServer}/uStoreWSAPI/AddressWS.asmx");
				WSAPI_AddressWS.AddressWSSoapClient addressWS = new WSAPI_AddressWS.AddressWSSoapClient (binding, addressAddressWS);
				WSAPI_AddressWS.Address billing = new WSAPI_AddressWS.Address ();

				billing.AddressID = 0;
				billing.AddressTypeID = 2;

				billing.UserID = id;
				billing.CustomerID = id;

				billing.DisplayName = $"{firstName} {lastName} Billing Address";
				billing.PersonName = $"{firstName} {lastName}";
				billing.Company = TextBox_Company.Text;
				billing.Address1 = TextBox_Address1.Text;
				billing.Address2 = TextBox_Address2.Text;
				billing.City = TextBox_City.Text;
				billing.StateID = Convert.ToInt32 (DropDownList_Province.SelectedValue);
				billing.CountryID = Convert.ToInt32 (DropDownList_Country.SelectedValue);
				billing.Zip = TextBox_PostalCode.Text;
				billing.Phone = TextBox_PhoneNumber.Text;

				addressWS.AddAddress (WSAPI_User, WSAPI_Password, billing);

				log.Write ("Profile Created", "CreateUser", "300", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", settings.Client_UserAgent, "User created a profile.");
			}
		} // CreateUser (...)


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
		///
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		private void Login (string email, string password)
		{
			const string STORE_NWTP = "1719";

			//string url = xmuser.GetLoginURL (email, password, STORE_NWTP);

			// Break out of iframe and open uStore login page.

			apiuser.uStoreServer = settings.uStore_Server;
			string url = apiuser.GetSingleSignOnUrl (settings.uStore_WSAPI_User, settings.uStore_WSAPI_Password, email, password, 1719, 54036, 1, "");

			log.Write ("Store Login", "Login", "310", netUserInfo.GetIpValue (), TextBox_Email.Text, $"{TextBox_FirstName.Text} {TextBox_LastName.Text}", settings.Client_UserAgent, "New user logged into store.");

			OpenURL (url);
		} // Login (...)


		/// <summary>
		///
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


		/// <summary>
		///
		/// </summary>
		/// <param name="country"></param>
		private void PopulateProvinces (string country)
		{
			int provinces = 0;

			DropDownList_Province.Items.Clear ();

			using (SqlConnection conn = new SqlConnection (settings.connectString_uStore))
			{
				// Move British Columbia to top of list for Canada, all other provinces sort alphabetically.

				string sql = "select P.ProvinceID, P.Name"
						   + "		from Country C"

						   + "		join Province P"
						   + "			on P.CountryID = C.CountryID"

						   + $"		where C.CountryID = '{country}'"
						   + "		order by case when ProvinceID=53 then 0 else 1 end";

				conn.Open ();

				using (SqlCommand command = new SqlCommand (sql, conn))
				using (SqlDataReader reader = command.ExecuteReader ())
				{
					while (reader.Read ())
					{
						++provinces;

						string name = (string)reader ["Name"];
						string provinceID = ((int)reader ["ProvinceID"]).ToString ();

						DropDownList_Province.Items.Add (new ListItem (name, provinceID));
					}
				}

				conn.Close ();
			} // using (SqlConnection conn = new SqlConnection (settings.sqlConnectString_PIDapps))

			if (provinces == 0)
				DropDownList_Province.Items.Add (new ListItem ("None", "0"));
		} // PopulateProvinces (...)

	}
}
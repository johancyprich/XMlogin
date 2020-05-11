using System.Configuration;
using System.Web;

namespace XMlogin
{
	public class Settings
	{
		//=== Properties ================================================================================

		public string connectString_Intranet = ConfigurationManager.AppSettings["connectString_Intranet"];
		public string connectString_PID = ConfigurationManager.AppSettings["connectString_PID"];
		public string connectString_uStore = ConfigurationManager.AppSettings["connectString_uStore"];
		public string connectString_uStoreScopes = ConfigurationManager.AppSettings["connectString_uStoreScopes"];
		public string connectString_XMHelper = ConfigurationManager.AppSettings["connectString_XMHelper"];
		public string connectString_Domblue = ConfigurationManager.AppSettings["connectString_Domblue"];

		public string connectString_Log = ConfigurationManager.AppSettings["connectString_Log"];

		public string Application_Name = ConfigurationManager.AppSettings["app_Name"];
		public string Application_Version = ConfigurationManager.AppSettings["app_Version"];
		public string Application_Date = ConfigurationManager.AppSettings["app_Date"];
		public string Application_Author = ConfigurationManager.AppSettings["app_Author"];
		public string Application_AuthorContact = ConfigurationManager.AppSettings["app_AuthorContact"];
		public string Application_Copyright = ConfigurationManager.AppSettings["app_Copyright"];

		public bool Options_Debug = (ConfigurationManager.AppSettings["options_Debug"] == "true");
		public string Options_Template = ConfigurationManager.AppSettings["options_Template"];
		public string Options_HomeURL = ConfigurationManager.AppSettings["options_HomeURL"];
		public string Options_FormURL = ConfigurationManager.AppSettings["options_FormURL"];
		public string Options_SiteStatus = ConfigurationManager.AppSettings["options_SiteStatus"];
		//public bool Options_SSL = (ConfigurationManager.AppSettings["options_SSL"] == "true");
		public string Options_HTTP = ConfigurationManager.AppSettings["options_HTTP"];
		public string Options_OrderPrintingProduct = ConfigurationManager.AppSettings["options_OrderPrintingProduct"];

		public string Mail_Host = ConfigurationManager.AppSettings["mail_Host"];
		public bool Mail_Authentication = (ConfigurationManager.AppSettings["mail_Authentication"] == "true");
		public string Mail_UserName = ConfigurationManager.AppSettings["mail_UserName"];
		public string Mail_User = ConfigurationManager.AppSettings["mail_User"];
		public string Mail_Password = ConfigurationManager.AppSettings["mail_Password"];

		public string Path_Logs = ConfigurationManager.AppSettings["path_Logs"];

		public string URL_uStoreOrder = ConfigurationManager.AppSettings["url_uStoreOrder"];
		public string URL_PreviousOrder = ConfigurationManager.AppSettings["url_PreviousOrder"];
		public string URL_Terms = ConfigurationManager.AppSettings["url_Terms"];

		public string URL_WestbankProjectOrders = ConfigurationManager.AppSettings["url_WestbankProjectOrders"];
		public string URL_DFSPlanroomLogin = ConfigurationManager.AppSettings["url_DFSPlanroomLogin"];
		public string URL_OrderPrintEnvelopes = ConfigurationManager.AppSettings["url_OrderPrintEnvelopes"];
		public string URL_OrderPrintingSupplies = ConfigurationManager.AppSettings["url_OrderPrintingSupplies"];
		public string URL_RequestPickupDelivery = ConfigurationManager.AppSettings["url_RequestPickupDelivery"];

		public string uStore_Server = ConfigurationManager.AppSettings["ustore_Server"];
		public string uStore_WSAPI_User = ConfigurationManager.AppSettings["ustore_WSAPI_User"];
		public string uStore_WSAPI_Password = ConfigurationManager.AppSettings["ustore_WSAPI_Password"];

		public string ReCAPTCHA_SiteKey = ConfigurationManager.AppSettings["recaptcha_SiteKey"];
		public string ReCAPTCHA_SecretKey = ConfigurationManager.AppSettings["recaptcha_SecretKey"];

		public string Client_UserAgent = HttpContext.Current.Request.UserAgent;


		//=== Constructors ==============================================================================


		public Settings ()
		{
		}

		~Settings ()
		{
		}

		//=== Methods =============================================================================

		public void DebugInfo ()
		{
			string info = "";

			string userID = (HttpContext.Current.Session["UserID"] != null) ? HttpContext.Current.Session["UserID"].ToString () : "";
			string loginRole = (HttpContext.Current.Session["LoginRole"] != null) ? HttpContext.Current.Session["LoginRole"].ToString () : "";

			info = "<div class='debug'>"
				 + $"	<p><b>{Application_Name} {Application_Version}</b></p>"
				 + $"	<p><b>User Agent:</b> {Client_UserAgent}</p>"
				 + "	<p>"
				 + $"			<b>Template:</b> {Options_Template}<br />"
				 + $"			<b>HomeURL:</b> {Options_HomeURL}<br />"
				 + $"			<b>Database:</b> {connectString_uStore}<br />"
				 + $"			<b>Current Dir:</b> {HttpContext.Current.Server.MapPath ("~")}"
				 + "	</p>"
				 + "	<p>"
				 + $"			<b>uStore Order Form:</b> {URL_uStoreOrder}<br />"
				 + $"			<b>Previous Order Form:</b> {URL_PreviousOrder}"
				 + "</div>";

			if (Options_Debug)
				System.Web.HttpContext.Current.Response.Write (info);
		}

		public string SiteTemplate (string template = "")
		{
			if (template == "")
				return $"~/Assets/Templates/{Options_Template}/{Options_Template}.Master";
			else
				return $"~/Assets/Templates/{template}/{template}.Master";
		}
	}
}
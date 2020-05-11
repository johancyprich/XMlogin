<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/Templates/Empty/Empty.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XMlogin.Default" %>
<%@ Register Src="~/Assets/UserControls/URLButton.ascx" TagPrefix="db" TagName="URLButton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% if (settings.Options_Debug) settings.DebugInfo (); %>

	<% DisplayError (true); %>

	<br />

	<div class="container-fluid">
		<div class="form-row">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_Email" runat="server" Text="Email Address" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_Email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_Email" SetFocusOnError="True" Font-Bold="True" ForeColor="White" BackColor="DarkRed" Display="Dynamic"></asp:RequiredFieldValidator>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_Password" runat="server" Text="Password" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_Password" SetFocusOnError="True" Font-Bold="True" ForeColor="White" BackColor="DarkRed" Display="Dynamic"></asp:RequiredFieldValidator>
			</div>
		</div> <!-- form-row -->

		<div class="row">
			<div class="col-md-9" style="margin-top: 20px;">
				<asp:LinkButton ID="LinkButton_NewProfile" runat="server" CssClass="link-label" OnClick="LinkButton_NewProfile_Click" CausesValidation="False" ForeColor="#0098DA">Create a New Profile</asp:LinkButton>
				&nbsp;&nbsp;<span style="font-size: larger;">|</span>&nbsp;&nbsp;
				<asp:LinkButton ID="LinkButton_ForgotPassword" runat="server" CssClass="link-label" OnClick="LinkButton_ForgotPassword_Click" CausesValidation="False" ForeColor="#0098DA">Forgot Password?</asp:LinkButton>
			</div>

			<div class="col-md-3">
				<% ImageButton_Submit.Attributes.Add("onmouseover","this.src=\"Assets/images/Button_Login_Down.png\""); %>
				<% ImageButton_Submit.Attributes.Add("onmouseout","this.src=\"Assets/images/Button_Login_Up.png\""); %>
				<asp:ImageButton ID="ImageButton_Submit" runat="server" ImageUrl="~/Assets/images/Button_Login_Up.png" onmouseover="this.src='~Assets/images/Button_Login_Down.jpg'" onmouseout="this.src='~Assets/images/Button_Login_Up.png'" OnClick="ImageButton_Submit_Click" />
			</div>
		</div> <!-- row -->

		<!--<p>&nbsp;</p>-->

		<!--<hr />-->

		<%= GetContent () %>

		<%--
		<div class="row" style="margin-left: 1px;">
			<p class="subtitle">
				<span class="light-blue">
					The Dominion Blue Print Order System is built so that you can:
				</span>
			</p>
			<ul>
				<li class="biglist">Conveniently Archive Your Print Orders &amp; Documents</li>
				<li class="biglist">Involve Your Team &amp; View Your Drawings and Documents On The Go</li>
				<li class="biglist">Securely Access Your Archived Files Anywhere Anytime 24/7</li>
				<li class="biglist">Create Multiple Shipping and Delivery Addresses</li>
				<li class="biglist">Track the Status of Your Orders</li>
				<li class="biglist">Look Up Your Order History</li>
			</ul>
		</div> <!-- row -->

		<hr />

		<div class="row">
			<div class="col-md-3">
				<span class="specialty-title">Plan Rooms &amp; Specialty Product Orders</span>
			</div>

			<div class="col-md-9">
				<div class="row">
					<div class="col-md-2">
						<div class="specialty-center">
							<a href="<%= settings.URL_WestbankProjectOrders %>">
								<asp:ImageButton ID="ImageButton_WestbankProjectOrder" runat="server" ImageUrl="~/Assets/images/WebsiteButtons/WestbankProjectOrders.png" CssClass="specialty-button" CausesValidation="False" OnClick="ImageButton_WestbankProjectOrder_Click" /><br />
								<asp:LinkButton ID="LinkButton_WestbankProjectOrder" runat="server" CssClass="specialty-subtitle" CausesValidation="False" OnClick="LinkButton_WestbankProjectOrder_Click" ForeColor="#0098DA">Westbank Project Orders</asp:LinkButton>
							</a>
						</div>
					</div>
					<div class="col-md-2">
						<div class="specialty-center">
							<a href="<%= settings.URL_DFSPlanroomLogin %>">
								<asp:ImageButton ID="ImageButton_DFSPlanroomLogin" runat="server" ImageUrl="~/Assets/images/WebsiteButtons/DFSPlanRoomLogin.png" CssClass="specialty-button" CausesValidation="False" OnClick="ImageButton_DFSPlanroomLogin_Click" /><br />
								<asp:LinkButton ID="LinkButton_DFSPlanroomLogin" runat="server" CssClass="specialty-subtitle" CausesValidation="False" OnClick="LinkButton_DFSPlanroomLogin_Click" ForeColor="#0098DA">DFS Plan Room Login</asp:LinkButton>
							</a>
						</div>
					</div>
					<div class="col-md-2">
						<div class="specialty-center">
							<a href="<%= settings.URL_OrderPrintEnvelopes %>">
								<asp:ImageButton ID="ImageButton_OrderPrintEnvelopes" runat="server" ImageUrl="~/Assets/images/WebsiteButtons/OrderAndPrintEnvelopes.png" CssClass="specialty-button" CausesValidation="False" OnClick="ImageButton_OrderPrintEnvelopes_Click" /><br />
								<asp:LinkButton ID="LinkButton_OrderPrintEnvelopes" runat="server" CssClass="specialty-subtitle" CausesValidation="False" OnClick="LinkButton_OrderPrintEnvelopes_Click" ForeColor="#0098DA">Order &amp; Print Envelopes</asp:LinkButton>
							</a>
						</div>
					</div>
					<div class="col-md-2">
						<div class="specialty-center">
							<a href="<%= settings.URL_OrderPrintingSupplies %>">
								<asp:ImageButton ID="ImageButton_OrderPrintingSupplies" runat="server" ImageUrl="~/Assets/images/WebsiteButtons/OrderPrintSupplies.png" CssClass="specialty-button" CausesValidation="False" OnClick="ImageButton_OrderPrintingSupplies_Click" /><br />
								<asp:LinkButton ID="LinkButton_OrderPrintingSupplies" runat="server" CssClass="specialty-subtitle" CausesValidation="False" OnClick="LinkButton_OrderPrintingSupplies_Click" ForeColor="#0098DA">Order Printing Supplies</asp:LinkButton>
							</a>
						</div>
					</div>
					<div class="col-md-2">
						<div class="specialty-center">
							<a href="<%= settings.URL_RequestPickupDelivery %>">
								<asp:ImageButton ID="ImageButton_RequestPickupDelivery" runat="server" ImageUrl="~/Assets/images/WebsiteButtons/RequestPickUpOrDelivery.png" CssClass="specialty-button" CausesValidation="False" OnClick="ImageButton_RequestPickupDelivery_Click" /><br />
								<asp:LinkButton ID="LinkButton_RequestPickupDelivery" runat="server" CssClass="specialty-subtitle" CausesValidation="False" OnClick="LinkButton_RequestPickupDelivery_Click" ForeColor="#0098DA">Request PickUp or Delivery</asp:LinkButton>
							</a>
						</div>
					</div>
				</div>
			</div> <!-- col-md-9 -->
		</div>
		--%>
	</div> <!-- container-fluid -->

	<% DisplayError (false); %>
</asp:Content>
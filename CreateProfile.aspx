<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/Templates/Empty/Empty.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="XMlogin.CreateProfile" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% if (settings.Options_Debug) settings.DebugInfo (); %>

	<% DisplayError (true); %>

	<div class="container-fluid">
		<!-- Profile Information -------------------------------------------------------------------------->

		<h2>Profile Information</h2>
		<p>&nbsp;</p>

		<div class="form-row">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_FirstName" runat="server" Text="First Name" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_FirstName" runat="server" CssClass="form-control" AutoPostBack="False"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_FirstName" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_FirstName" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_LastName" runat="server" Text="Last Name" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_LastName" runat="server" CssClass="form-control" AutoPostBack="False"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_LastName" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_LastName" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col-md-12">
				<asp:Label ID="Label_Email" runat="server" Text="Email Address" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_Email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_Email" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_Password" runat="server" Text="Password" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_Password" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_ConfirmPassword" runat="server" Text="Confirm Password" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_ConfirmPassword" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_ConfirmPassword" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True"></asp:RequiredFieldValidator>
				<asp:CompareValidator ID="CompareValidator_ConfirmPassword" runat="server" ErrorMessage="&nbsp;Passwords Don't Match&nbsp;" ControlToCompare="TextBox_ConfirmPassword" ControlToValidate="TextBox_Password" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:CompareValidator>
			</div>
		</div>

		<!-- User Information --------------------------------------------------------------------------->

		<p>&nbsp;</p>
		<h2>Contact Information</h2>
		<p>&nbsp;</p>

		<div class="form-row">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_PhoneNumber" runat="server" Text="Phone Number" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_PhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_PhoneNumber" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_PhoneNumber" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_MobileNumber" runat="server" Text="Mobile Number" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_MobileNumber" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
		</div>

		<div class="form-row" style="display: none;">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_Department" runat="server" Text="Department" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_Department" runat="server" CssClass="form-control"></asp:TextBox>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_JobTitle" runat="server" Text="Job Title" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_JobTitle" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
		</div>

		<!-- Shipping Address ---------------------------------------------------------------------------->

		<!--
		<p>&nbsp;</p>
		<h2>Shipping Address</h2>
		<p>&nbsp;</p>
		-->

		<div class="form-row">
			<div class="form-group col-md-12">
				<asp:Label ID="Label_Company" runat="server" Text="Company Name" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_Company" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col-md-12">
				<asp:Label ID="Label_Address1" runat="server" Text="Address:" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_Address1" runat="server" CssClass="form-control"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_Address1" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_Address1" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>
		</div>

		<div class="form-row" style="display: none;">
			<div class="form-group col-md-12">
				<asp:Label ID="Label_Address2" runat="server" Text="Address Line 2:" CssClass="login-label"></asp:Label><br />
				<asp:TextBox ID="TextBox_Address2" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col-md-9">
				<asp:Label ID="Label_City" runat="server" Text="City:" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_City" runat="server" CssClass="form-control"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_City" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_City" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>

			<div class="form-group col-md-3">
				<asp:Label ID="Label_PostalCode" runat="server" Text="Postal Code:" CssClass="login-label"></asp:Label><span class="required-asterisk"> *</span><br />
				<asp:TextBox ID="TextBox_PostalCode" runat="server" CssClass="form-control"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator_PostalCode" runat="server" ErrorMessage="&nbsp;Required Field&nbsp;" ControlToValidate="TextBox_PostalCode" Display="Dynamic" ForeColor="White" BackColor="DarkRed" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col-md-6">
				<asp:Label ID="Label_Country" runat="server" Text="Country:" CssClass="login-label"></asp:Label><br />
				<asp:DropDownList ID="DropDownList_Country" runat="server" CssClass="form-control" DataSourceID="uStore" DataTextField="Name" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Country_SelectedIndexChanged"></asp:DropDownList>
				<asp:SqlDataSource ID="uStore" runat="server" ConnectionString="<%$ ConnectionStrings:uStoreConnectionString %>" SelectCommand="SELECT [Name], [CountryID] FROM [Country] ORDER BY [Name]"></asp:SqlDataSource>
			</div>

			<div class="form-group col-md-6">
				<asp:Label ID="Label_Province" runat="server" Text="Province:" CssClass="login-label"></asp:Label><br />
				<asp:DropDownList ID="DropDownList_Province" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
			</div>
		</div>

		<div class="form-row">
			<div class="form-group col">
				<asp:CheckBox ID="CheckBox_Terms" runat="server" AutoPostBack="False" />
				<asp:LinkButton ID="LinkButton_Terms" runat="server" CausesValidation="False" OnClick="LinkButton_Terms_Click" Visible="False">Terms &amp; Conditions</asp:LinkButton><br />
			</div>
		</div>

		<!-- Buttons ------------------------------------------------------------------------------------>

		<p>&nbsp;</p>
		<asp:Button ID="Button_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button_Submit_Click" />
		<asp:Button ID="Button_Reset" runat="server" Text="Reset" CssClass="btn btn-secondary" CausesValidation="False" OnClick="Button_Reset_Click" />
	</div> <!-- .container-fluid -->

	<% DisplayError (false); %>
</asp:Content>
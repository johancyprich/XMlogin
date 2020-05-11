<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/Templates/Empty/Empty.Master" AutoEventWireup="true" CodeBehind="MultipleStoreLogin.aspx.cs" Inherits="XMlogin.MultipleStoreLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<% if (settings.Options_Debug) settings.DebugInfo (); %>

	<div class="container-fluid">
		<!-- Profile Information -------------------------------------------------------------------------->

		<h2>Multiple Stores Found</h2>
		<p>&nbsp;</p>
		<p>Your profile has multiple stores associated with it. Please select the store you would like to login to.</p>

		<% DisplayStores (); %>
	</div> <!-- container-fluid -->
</asp:Content>
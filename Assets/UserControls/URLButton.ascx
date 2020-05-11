<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="URLButton.ascx.cs" Inherits="XMlogin.Assets.UserControls.URLButton" %>

<a href="<%= URL %>"
    <%= (GetTarget () == "") ? "" : $"target={GetTarget ()}" %>
>
	<img src="<%= ImageSrc %>"
        <%= (OnMouseDown == "") ? "" : $"onmousedown={OnMouseDown}" %>
        <%= (OnMouseUp == "") ? "" : $"onmouseup={OnMouseUp}" %>

        <%= (OnMouseOut == "") ? "" : $"onmouseout={OnMouseOut}" %>
        <%= (OnMouseOver == "") ? "" : $"onmouseover={OnMouseOver}" %>

        <%= (OnMouseMove == "") ? "" : $"onmousemove={OnMouseMove}" %>
        <%= (OnMouseWheel == "") ? "" : $"onmousewheel={OnMouseWheel}" %>
    />
</a>
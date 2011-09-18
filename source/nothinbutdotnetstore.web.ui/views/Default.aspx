<%@ MasterType virtualPath="Store.master" %>
<%@ Page Language="c#" 
    Inherits="System.Web.UI.Page"    MasterPageFile="Store.master"    
    enableViewStateMac="True" %>
<asp:Content runat="server" id="contentPlaceHolder" ContentPlaceHolderId="childContentPlaceHolder">
    <div align="center">
        <asp:Image id="titleImage" ImageURL="~/images/Title.jpg" runat="server" Width="736px" />
    </div>
</asp:Content>
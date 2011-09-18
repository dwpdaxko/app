<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>

<asp:Content id="content" runat="server" ContentPlaceHolderId="childContentPlaceHolder">
    <table>
        <tr>
            <td>Select a file To Update Prices With:</td>
            <td><asp:FileUpload id="fileUploadControl" runat="server" CssClass="normalControl"/></td>
            <td><asp:Button id="uploadButton" CssClass="normalButton" runat="server" Text="Update" /></td>
        </tr>
    </table>
    
</asp:Content>
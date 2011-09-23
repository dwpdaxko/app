<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.catalogbrowsing" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core.link_builder" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <% foreach(var department in this.model)
               {
                %>
              <%-- for each department --%>
              <tr class="ListItem">
               <td><a href="<%= Link.to_run<ViewTheDepartmentsOfADepartmentRequest>()
									.conditionally<ViewTheProductsInADepartmentInputModel>(department.has_products)
									.include(department, x => x.has_products) %>">
                <%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
<%@ Control Language="c#" Inherits="System.Web.UI.UserControl"  %>
<table align="right">
	<tr>
		<td>
		    <asp:ImageButton runat="server" id="cartImage" ImageURL="~/images/cart.jpg" />
		</td>		
	</tr>
	<tr>
		<td class="dynamicText" id="itemCountCell" runat="server"></td>    		
	</tr>
	<tr>
	    <td class="dynamicText" id="itemTotalCell" runat="server" ></td>
	</tr>
</table>

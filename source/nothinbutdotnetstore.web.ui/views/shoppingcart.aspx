<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page"     MasterPageFile="Store.master"%>
    
    <asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
            <table>
					<tr>
						<td valign="top" colspan="3">
							<asp:Button id="emptyCartButton"
								Text="Empty Cart" runat="server" />
							<asp:button id="checkoutButton" runat="server" Text="Continue to checkout" CssClass="NormalButton"></asp:button><span class="box2"><asp:button id="updateCartButton" runat="server" Text="Update Cart" CssClass="NormalButton"></asp:button>
							</span>
							<asp:Repeater id="cartItemsRepeater" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Quantity</th>                   
                        <th>Price</th>                                                                        
                        <th>Delete</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>                    
                    <td>
                        <asp:HiddenField id="productIdHiddenField" runat="server" value="Replace With Identity Of Product" />
                        <a href='#'>Replace with url to Product Detail Page For Product</a>
                    </td>
                    <td>Replace with Description of product</td>
                    <td><asp:TextBox id="quantityTextBox" runat="server" Text="Replace with quantity in of product in cart" MaxLength="3" Width="20px"></asp:TextBox></td>
                    <td>Replace With Product Price</td>               
                    <td><asp:CheckBox id="selectForDeletionCheckbox" runat="server" />                    
                </tr>
        </ItemTemplate>
    </asp:Repeater>			
							<asp:Button id="emptyCartButton2" Text="Empty Cart"
								runat="server" />
							<asp:button id="checkoutButton2" runat="server" Text="Continue to checkout" CssClass="NormalButton"></asp:button><span class="box2"><asp:button id="updateCartButton2" runat="server" Text="Update Cart" CssClass="NormalButton"></asp:button>
							</span><asp:label id="cartTotalLabel" runat="server" Width="498px" EnableViewState="False"></asp:label></td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
					</tr>
					</table>
</asp:Content>

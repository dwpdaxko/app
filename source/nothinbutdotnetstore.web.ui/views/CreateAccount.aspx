<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" validateRequest="false" Inherits="System.Web.UI.Page"  MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
            <div id="errorsDiv" runat="server">
                <asp:BulletedList id="errorsList" runat="server" CssClass="errorText"></asp:BulletedList>
            </div>			
			<br/>
			<table>			   
			    <tr>			        
				  <td valign="top">To create a new account, please give us your current 
						e-mail address and a password so you can quickly and easily check-in during 
						future visits.<br/>
						<br/>
						Please enter your e-mail address:<br/>
						<asp:textbox id="emailTextBox" runat="server" Width="216px" CssClass="editTextBox"></asp:textbox><br/>
						<br/>
						Please enter a password (six to 16 characters):<br/>
						<asp:textbox id="passwordTextBox" CssClass="editTextBox" runat="server" MaxLength="16" TextMode="Password" Width="216px"
							></asp:textbox>
						<br/>
						Please confirm your password (Re-enter it in the box below.):<br/>
						<asp:textbox id="confirmPasswordTextBox" runat="server" MaxLength="16" TextMode="Password" Width="216px"
							CssClass="editTextBox"></asp:textbox>
				
					<asp:Button id="submitButton" runat="server" CssClass="normalButton" Text="Submit"></asp:Button><br/>					
				<center>
					<table id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
						<tr>
							<td align="left" colspan="2">
								<hr />
								<b>Tips</b>
								<ul>
									<li>
									Please use a valid e-mail address. Your e-mail address is our primary means of 
									communication with you.
									</li>
									<li>
									Passwords cannot contain any of the following: &lt;, ?, PASS, pass.
									</li>
									<li>
										The first three letters of your password cannot be the same.
									</li>
								</ul>
							</td>
						</tr>
					</table>
				</center>
				</td>
				</tr>
				</table>
</asp:Content>

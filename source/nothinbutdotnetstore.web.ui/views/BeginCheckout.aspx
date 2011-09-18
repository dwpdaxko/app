<%@ Page Language="c#" Inherits="System.Web.UI.Page"    MasterPageFile="Store.master" %>
    
    <asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
						<table id="Table7" cellspacing="0" cellpadding="3" width="792" border="0">
							<tr>
								<td colspan="2" align="left">
									<p /><b class="h1">Ordering from NothinButDotNetStore.com is quick and easy</b><br/>

									<p />
										<asp:Label id="lblError" runat="server" EnableViewState="False" ForeColor="#C04000" Width="149px"></asp:Label>
									<p />Do not have an account with us yet?
										<asp:LinkButton id="lnkCreateAccount" runat="server" EnableViewState="False" CausesValidation="False">Click Here To Create One</asp:LinkButton>
										<br/>
										<br/>
									<p/>
								</td>								
							</tr>
							<tr>
								<td align="left" valign="top" class="body">Enter your e-mail 
									address:&nbsp;</td>
								<td align="left" valign="top">
									<asp:TextBox CssClass="editTextBox" id="txtEmail" runat="server" Width="189px"></asp:TextBox>
							    </td>
							</tr>
							<tr>
								<td class="body" valign="top" >Password
								</td>
								<td align="left">
									<asp:TextBox CssClass="editTextBox" id="txtPassword" runat="server" EnableViewState="False" TextMode="Password"
										MaxLength="16"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right">&nbsp;</td>
								<td>
									<asp:Button CssClass="normalButton" id="loginButton" runat="server" Text="Login" /></td>
							</tr>
							<tr>
								<td><br />
								</td>
								<td>
								    <a href="ForgotPassword.aspx">Forgot Your Password? Click Here.</a>
								</td>
							</tr>												
						</table>					
    </asp:Content>
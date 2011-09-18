<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page"  MasterPageFile="Store.master" %>
 <asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
 <table id="Table7" cellspacing="0" cellpadding="3" width="792" border="0">
							<tr>
								<td align="left" colspan="2">
								    <asp:BulletedList id="errorList" runat="server" CssClass="errorText"></asp:BulletedList>
									<p/><strong>Forgot My Password</strong><br/>																			
								</td>
								<td valign="top" rowspan="7">									
								</td>
							</tr>
							<tr>
								<td valign="top">
									<table id="tabEmail" runat="server">
										<tr>
											<td class="body" valign="top" align="right">Enter your e-mail 
												address:&nbsp;</td>
											<td valign="top">
												<asp:TextBox id="txtEmail" runat="server" CssClass="EditTextBox" Width="189px"></asp:TextBox>
										    </td>
										</tr>
										<tr>
											<td align="right">&nbsp;</td>
											<td>
												<asp:Button id="submitButton" runat="server" CssClass="normalButton" Text="Send Password" Width="144px"></asp:Button></td>
										</tr>
									</table>
									<table id="confirmationTable" runat="server">
										<tr>
											<td id="messageLabel" runat="server">Your password has been sent</td>
										</tr>
										<tr>
											<td><a href='#'>Click here to return to the main page</a></td>
										</tr>
									</table>
								</td>
							</tr>							
						</table>
 </asp:Content>
						
					

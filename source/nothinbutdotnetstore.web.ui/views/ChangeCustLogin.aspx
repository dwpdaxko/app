<%@ Page Language="c#" Inherits="System.Web.UI.Page" validateRequest="false"    MasterPageFile="Store.master" %>
    
    <asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
			<table id="Table1" cellspacing="10" cellPadding="1" width="95%" align="left" border="0">
				<TBODY>
					<tr>
						<td><asp:validationsummary id="valSummary" runat="server" EnableClientScript="False"></asp:validationsummary></td>
					</tr>
					<tr>
						<td bgColor="#3d117b">
							<table id="Table4" cellspacing="0" cellPadding="10" width="100%" align="center" bgColor="#ffffff"
								border="0">
								<TBODY>
									<tr>
										<td width="100%" colSpan="2"><B>Change E-mail Address</B>
											<br/>
											<br/>
											To change your e-mail address, please enter the new address into the form 
											below. Please remember to use this e-mail address the next time you sign in.<br/>
										</td>
									</tr>
									<tr>
										<td width="31%"><B>New e-mail address:</B></td>
										<td width="69%">
											<P>&nbsp;
												<asp:textbox id="txtEmail" runat="server" EnableViewState="False" CssClass="EditTextBox" Width="168px"></asp:textbox><asp:requiredfieldvalidator id="rqfEmail" runat="server" EnableClientScript="False" ErrorMessage="Email is required"
													Enabled="False" ControlToValidate="txtEmail" Display="None"></asp:requiredfieldvalidator></P>
										</td>
									</tr>
									<tr>
										<td width="100%" colSpan="2"><asp:button id="cmdUpdateEmail" runat="server" Text="Update Email" CssClass="NormalButton"></asp:button>&nbsp;
											<asp:button id="cmdCancel" runat="server" Text="Cancel" CssClass="NormalButton"></asp:button></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
					<BR clear="all">
					<tr>
						<td bgColor="#3d117b">
							<table id="Table5" cellspacing="0" cellPadding="10" width="100%" align="center" bgColor="#ffffff"
								border="0">
								<tr>
									<td width="100%" colSpan="2"><B>Change Password</B><br/>
										<br/>
										To change your password, please enter your new password twice below. Your 
										password must be<br/>
										6-16 characters long.
									</td>
								</tr>
								<tr>
									<td width="31%"><B>Enter your new password:</B></td>
									<td width="69%">
										<P>&nbsp;
											<asp:textbox id="txtPassword" runat="server" EnableViewState="False" TextMode="Password" CssClass="EditTextBox"
												Width="152px"></asp:textbox><asp:requiredfieldvalidator id="rqfPassword" runat="server" EnableClientScript="False" ErrorMessage="Password is required"
												Enabled="False" ControlToValidate="txtPassword" Display="None"></asp:requiredfieldvalidator>
											<asp:regularexpressionvalidator id="rqfPasswordLength" runat="server" EnableClientScript="False" Display="None"
												ControlToValidate="txtPassword" ErrorMessage="Password must be at least 6 characters" ValidationExpression="\w{6,16}"></asp:regularexpressionvalidator></P>
									</td>
								</tr>
								<tr>
									<td width="35%"><B>Enter your new password again:</B></td>
									<td width="69%">
										<P>&nbsp;
											<asp:textbox id="txtConfirmPassword" runat="server" EnableViewState="False" TextMode="Password"
												CssClass="EditTextBox" Width="152px"></asp:textbox><asp:comparevalidator id="cmpPassword" runat="server" EnableClientScript="False" ErrorMessage="Compare password must match"
												Enabled="False" ControlToValidate="txtPassword" Display="None" ControlToCompare="txtConfirmPassword"></asp:comparevalidator></P>
									</td>
								</tr>
								<tr>
									<td width="100%" colSpan="2"><asp:button id="cmdUpdatePassword" runat="server" Text="Update Password" CssClass="NormalButton"></asp:button>&nbsp;
										<asp:button id="cmdCancelPassword" runat="server" Text="Cancel" CssClass="NormalButton"></asp:button></td>
								</tr>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
	</asp:Content>
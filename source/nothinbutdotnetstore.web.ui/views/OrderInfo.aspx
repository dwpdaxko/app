<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page" MasterPageFile ="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">            
			<table class="ListItemAlt" id="tblEmptyCart" runat="server">
				<tr>
					<td id="lnkReturn" runat="server"></td>
				</tr>
			</table>
			<table id="tblConfirm" runat="server">
				<tr>
					<td>
						<p><b class="h1">Enter the billing address for this order.</b><br/>
							Enter the name and address where you'd like us to ship your order.&nbsp;When you're done, click the Continue button.&nbsp;&nbsp;&nbsp;
						</p>											
						<table>
							<tr>
								<td>
									<table>
									    <tr>
									        <td>First Name:</td>
									        <td style="width: 251px"><asp:TextBox CssClass="editTextBox" ID="firstNameTextBox" runat="server" /></td>
									    </tr>
									    <tr>
									        <td>Last Name:</td>
									        <td style="width: 251px"><asp:TextBox CssClass="editTextBox" ID="lastNameTextBox" runat="server" /></td>
									    </tr>
									    <tr>
									        <td>Address:</td>
									        <td style="width: 251px"><asp:TextBox CssClass="editTextBox" ID="addressTextBox" runat="server" /></td>
									    </tr>
									    <tr>
									        <td>City:</td>
									        <td style="width: 251px"><asp:TextBox CssClass="editTextBox" ID="cityTextBox" runat="server" /></td>
									    </tr>
									    <tr>
									        <td>Province:</td>
									        <td style="width: 251px"><asp:DropDownList CssClass="normalSelect" ID="provinceDropDownList" runat="Server"/></td>
									    </tr>
									    <tr>
									        <td>Postal Code:</td>
									        <td style="width: 251px"><asp:TextBox CssClass="editTextBox" ID="postalCodeTextBox" runat="server" /></td>
									    </tr>
									</table>
								</td>
							</tr>														
							<tr>
								<td>
									<table id="Table1" cellspacing="0" cellpadding="3" width="100%" border="0">
										<tr>
											<td valign="middle" align="left" colspan="3"><strong>Choose 
													how to pay for this order</strong>
											</td>										
											<td style="WIDTH: 540px">
												Payment Type:<asp:dropdownlist id="cboPaymentType" Width="219px" CssClass="normalSelect" Runat="server"></asp:dropdownlist>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table id="deliveryInformationTable" width="712" border="0" runat="server">
										<tbody>
											<tr>
												<td valign="top" align="center" colspan="2">
													<table>														
														<tr>
															<td>
																<table id="tblDelivery" style="WIDTH: 712px; HEIGHT: 36px" width="712" border="0"
																	runat="server">
																	<tr>
																		<td style="HEIGHT: 8px" colspan="2" id="deliveryTypeLabel" runat="server"><strong>Delivery 
																				Information</strong></td>
																	</tr>
																	<tr>
																		<td style="WIDTH: 303px; HEIGHT: 35px" id="deliveryTimeLabel" runat="server">Delivery 
																			Date/Time:</td>
																		<td style="HEIGHT: 35px"><asp:dropdownlist id="deliveryDateDropDownList" CssClass="normalSelect" runat="server" Width="208px"></asp:dropdownlist>&nbsp;-
																			<asp:dropdownlist id="deliveryTimeDropDownList" CssClass="normalSelect" runat="server" Width="240px"></asp:dropdownlist></td>
																	</tr>																	
																</table>
															</td>
														</tr>
														<tr>
															<td>
																<table id="Table3" style="WIDTH: 712px; HEIGHT: 26px" width="712" border="0">
																	<tr>
																		<td style="WIDTH: 196px" valign="top">Additional Comments:</td>
																		<td><asp:textbox id="additionalCommentsTextBox" CssClass="editTextBox" runat="server" Height="134px" Width="496px" TextMode="MultiLine"></asp:textbox></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
					                                        <td align="right">
						                                        <asp:Button id="continueButton" runat="server" Text="Continue"></asp:Button>
						                                    </td>									
														</tr>
													</table>
												</td>
											</tr>
											</tbody>
											</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>			
</asp:Content>				
	
	
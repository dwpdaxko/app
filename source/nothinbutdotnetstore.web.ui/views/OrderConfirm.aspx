<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page"    MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="Server" ContentPlaceHolderID="childContentPlaceHolder">
<table>     
				<tr>
					<td colspan="3">						
						<p/><br/>
							Your order has not yet been placed.
								Please click <strong>PURCHASE</strong> to complete your order.&nbsp;&nbsp;<br/>
							<asp:button id="cancelButton1" runat="server" CssClass="normalButton" Text="Cancel"/>&nbsp;							
							<asp:button id="purchaseButton1" runat="server" CssClass="normalButton" Text="Purchase"/><br/>
							&nbsp;<br/>
							<br/>
							<asp:label id="lblOrderID" runat="server" Visible="False"/><p />
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 352px" colspan="3">&nbsp;
						<table id="Table4" cellspacing="0" cellpadding="2" width="100%" border="0">
							<tr>
								<td style="HEIGHT: 14px" valign="top" align="left">	
								    <asp:Repeater id="orderItemsRepeater" runat="server">
								    <HeaderTemplate>
								        <table>
								            <thead>
								                <tr>
								                    <th>Quantity</th>
								                    <th>Product Name</th>								                    
								                    <th>Price</th>
								                    <th>GST Exempt</th>
								                </tr>
								            </thead>
								    </HeaderTemplate>   
								    <ItemTemplate>
								        <tr class="nonShadedRow">
								            <td>Quantity Of Items</td>
								            <td>Product Name</td>
								            <td>Product Price</td>
								            <td>Is The GST Exempt</td>
								        </tr>
								    </ItemTemplate>
								    <AlternatingItemTemplate>
								        <tr class="shadedRow">
								            <td>Quantity Of Items</td>
								            <td>Product Name</td>
								            <td>Product Price</td>
								            <td>Is The GST Exempt</td>
								        </tr>
								    </AlternatingItemTemplate>
								</asp:Repeater>	
								</td>														
							</tr>
							<tr>
								<td align="right">
									<table style="WIDTH: 325px; HEIGHT: 84px" width="325" border="0">
										<tr>
											<td style="HEIGHT: 15px">Order Subtotal:</td>
											<td style="HEIGHT: 15px"><asp:label id="orderSubTotalLabel" runat="server" CssClass="normalControl"></asp:label></td>
										</tr>										
										<tr>
											<td style="HEIGHT: 3px">GST:</td>
											<td style="HEIGHT: 3px"><asp:label id="gstLabel" CssClass="normalControl" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td>Order Total</td>
											<td><asp:label id="orderTotalLabel" CssClass="normalControl" Runat="server"></asp:label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>				
				<tr>
					<td colspan="3">
						<!--<HR align="center" width="100%" color="black" noShade>-->
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<p /><strong>Your Information</strong>
						<table width="100%">
							<tr valign="top">
								<td>
									<table width="100%">
										<tr>
											<td class="ListHead">Your Shipping Information</td>
										</tr>
										<tr>
											<td>
												<table id="Table6" style="WIDTH: 371px; HEIGHT: 90px" cellspacing="0" cellpadding="0" width="371"
													border="0">
													<tr>
														<td><asp:label id="customerShippingNameLabel" runat="server" CssClass="normalControl" Width="262px"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="customerShippingAddressLabel" runat="server" CssClass="normalControl" Width="255px"></asp:label></td>
													</tr>
													<tr>
														<td style="HEIGHT: 18px"><asp:label id="customerShippingCityLabel" runat="server" CssClass="normalControl" Width="252px"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="customerShippingProvinceLabel" runat="server" CssClass="normalControl" Width="255px"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="customerShippingPostalCodeLabel" runat="server" CssClass="normalControl" Width="253px"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td valign="top">
									<table width="100%">
										<tr>
											<td class="ListHead">Your Billing Information</td>
										</tr>
										<tr>
											<td>
												<table id="Table7" style="WIDTH: 371px; HEIGHT: 90px" cellspacing="0" cellpadding="0" width="371"
													border="0">
													<tr>
														<td><asp:label id="customerBillingNameLabel" runat="server" CssClass="normalControl" Width="262px"></asp:label></td>
													</tr>
													<tr>
														<td style="HEIGHT: 17px"><asp:label id="customerBillingAddressLabel" runat="server" CssClass="normalControl" Width="255px"></asp:label></td>
													</tr>
													<tr>
														<td style="HEIGHT: 18px"><asp:label id="customerBillingCityLabel" runat="server" CssClass="normalControl" Width="252px"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="customerBillingProvinceLabel" runat="server" CssClass="normalControl" Width="255px"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="customerBillingPostalCodeLabel" runat="server" CssClass="normalControl" Width="253px"></asp:label></td>
													</tr>
												</table>
												<br/>
												<b>Daytime Telephone:</b>&nbsp;
												<asp:label id="customerBillingPhoneNumberLabel" runat="server" CssClass="normalControl" Width="168px"></asp:label><br/>
												<b>Email:</b>
												<asp:label id="customerEmailAddressLabel" runat="server" CssClass="normalControl" Width="159px"></asp:label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<table width="100%">
										<tr>
											<td class="ListHead">Your Payment Information</td>
										</tr>
										<tr>
											<td valign="top">
												<table>
													<tr>
														<td>Payment Type :
															<asp:label id="paymentTypeLabel" runat="server" CssClass="normalControl"></asp:label></td>
													</tr>	
											    </table>												
											</td>
								<td valign="top">
									<table width="100%">
										<tr>
											<td class="ListHead" colspan="2">Your Delivery Information</td>
										</tr>
										<tr>
											<td>
												<table id="Table5" style="WIDTH: 495px; HEIGHT: 138px" cellspacing="0" cellpadding="0"
													width="495" border="0">													
													<tr>
														<td style="WIDTH: 35px">Time:</td>
														<td style="WIDTH: 5px"><asp:label id="deliveryTimeLabel" runat="server" CssClass="normalControl" Width="287px"></asp:label></td>
													</tr>													
													<tr>
														<td style="WIDTH: 35px">Date:</td>
														<td style="WIDTH: 5px"><asp:label id="deliveryDateLabel" runat="server" CssClass="normalControl" Width="336px"></asp:label></td>
													</tr>
													<tr>
														<td style="WIDTH: 35px" valign="top">Additional Comments:</td>
														<td style="WIDTH: 5px" valign="top"><asp:label id="additionalCommentsLabel" runat="server" CssClass="normalControl" Width="366px"
																Height="57px"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
										</tr>
									</table>
								</td>
							</tr>
				<tr>
					<td align="left" colspan="3">
						<hr />
				    </td>
				</tr>
				<tr>
					<td align="left" colspan="3"><b>Tips</b></td>
				</tr>
				<tr>
					<td colspan="3"></td>
				</tr>				
			</table>
			        </td>
			    </tr>
			</table>
</asp:Content>
<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" enableViewStateMac="True" 
 MasterPageFile="Store.master"%>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">

			<table id="Table1" style="WIDTH: 516px; HEIGHT: 602px" width="516" border="0" runat="server">
				<tr>
					<td align="center">Thanks For Your Order</td>
				</tr>
				<tr>
					<td>Your Order Number Is:
						<asp:Label id="lblOrderNo" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td>You Ordered The Following Products:</td>
				</tr>
				<tr>
					<td valign="top">
						<table id="Table2" width="100%" border="0">
							<tr>
								<td>
									<asp:DataGrid id="dgrDetails" HeaderStyle-CssClass="ListHead" ItemStyle-CssClass="DataItem" AlternatingItemStyle-CssClass="ListItemAlt"
										AutoGenerateColumns="False" runat="server" Width="494px">
										<Columns>
											<asp:BoundColumn DataField="Name" HeaderText="Product"></asp:BoundColumn>
											<asp:BoundColumn DataField="Price" HeaderText="Price" DataFormatString="{0:C}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Total">
												<ItemTemplate>
													<asp:Label ID="lblTotal" Runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table id="Table3" width="100%" border="0">
							<tr>
								<td class="ListHead">Your Shipping Info</td>
								<td>&nbsp;</td>
								<td class="ListHead">Your Billing Info</td>
							</tr>
							<tr>
								<td valign="top">
									<table id="Table4" width="100%" border="0">
										<tr>
											<td>
												<asp:Label id="lblShipName" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblShipAddress" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblShipCity" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblShipCountry" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
									</table>
								</td>
								<td>&nbsp;</td>
								<td>
									<table id="Table5" width="100%" border="0">
										<tr>
											<td>
												<asp:Label id="lblBillName" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblBillAddress" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblBillCity" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblBillCountry" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblBillEmail" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:Label id="lblBillPhone" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table>
							<tr>
								<td valign="top">
									<table id="Table6" width="208" border="0" style="WIDTH: 208px; HEIGHT: 138px">
										<tr>
											<td class="ListHead" style="HEIGHT: 12px">Payment Information</td>
										</tr>
										<tr>
											<td id="cellCardInfo" runat="server">Card Name:
												<asp:Label id="lblCardName" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												Payment&nbsp;Type:
												<asp:Label id="lblCardType" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
								<td valign="top">
									<table id="Table7" style="WIDTH: 375px; HEIGHT: 138px" cellspacing="0" cellpadding="0"
										width="375" border="0">
										<tr>
											<td colspan="2" class="ListHead">Delivery Information</td>
										</tr>
										<tr>
											<td style="WIDTH: 35px">Type:</td>
											<td style="WIDTH: 5px">
												<asp:label id="lblDeliveryType" runat="server" Width="325px" CssClass="NormalControl"></asp:label></td>
										</tr>
										<tr>
											<td style="WIDTH: 35px">Time:</td>
											<td style="WIDTH: 5px">
												<asp:label id="lblDeliveryTime" runat="server" Width="287px" CssClass="NormalControl"></asp:label></td>
										</tr>
										<tr>
											<td style="WIDTH: 35px">Location:</td>
											<td style="WIDTH: 5px; HEIGHT: 18px">
												<asp:label id="lblDeliveryLocation" runat="server" Width="341px" CssClass="NormalControl"></asp:label></td>
										</tr>
										<tr>
											<td style="WIDTH: 35px">Date:</td>
											<td style="WIDTH: 5px">
												<asp:label id="lblDeliveryDate" runat="server" Width="336px" CssClass="NormalControl"></asp:label></td>
										</tr>
										<tr>
											<td style="WIDTH: 35px">Additional Comments:</td>
											<td style="WIDTH: 5px" valign="top">
												<asp:label id="lblAdditionalComments" runat="server" Width="366px" CssClass="NormalControl"
													Height="57px"></asp:label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						</td>
				</tr>
			</table>
		</asp:Content>

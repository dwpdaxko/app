<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" Inherits="System.Web.UI.Page" MasterPageFile="Store.master"%>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">

							<table id="Table1" style="WIDTH: 328px; HEIGHT: 156px" width="328" border="0">
								<tr>
									<td valign="top" align="center">
										<asp:DataList id="indexDataList" runat="server" RepeatColumns="26" RepeatDirection="Horizontal">
											<ItemTemplate>
												<table>
													<tr>
														<td>
															<asp:LinkButton ID="letterLinkButton" Runat="server" Text="Replace"></asp:LinkButton></td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:DataList>&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<table id="Table2" width="607" border="0">											
											<tr>
												<td>												    
												    <asp:Repeater ID="categoriesRepeater" runat="server">
												        <HeaderTemplate>
												            <table>
												        </HeaderTemplate>
												        <ItemTemplate>
												            <tr class="nonShadedRow">
												                <td><asp:LinkButton runat="server" ID="categoryLinkButton" Text="Replace with Department name"/></td>
												            </tr>
												        </ItemTemplate>												       
												          <AlternatingItemTemplate>
												            <tr class="shadedRow">
												                <td><asp:LinkButton runat="server" ID="categoryLinkButton" Text="Replace with Department Name"/></td>
												            </tr>
												        </AlternatingItemTemplate>		
												        <FooterTemplate>
												            </table>
												        </FooterTemplate>
												    </asp:Repeater>
												</td>
											</tr>											
										</table>
									</td>
								</tr>
							</table>
							
</asp:Content>
					
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.tbTpNews.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPEasyContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPEasyContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPImgUrl
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPImgUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPBianJi
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPBianJi" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TPFuShu1
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTPFuShu1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		isDel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblisDel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FatherId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFatherId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DateTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OrderBy
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderBy" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>





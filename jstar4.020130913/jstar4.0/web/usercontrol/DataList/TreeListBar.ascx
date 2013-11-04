<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeListBar.ascx.cs" Inherits="usercontrol_DataList_TreeListBar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ListView ID="lvProCate" runat="server" 
    onitemdatabound="lvProCate_ItemDataBound" 
    onselectedindexchanging="lvProCate_SelectedIndexChanging">
<LayoutTemplate>

<tbody >
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>

</LayoutTemplate>
<ItemTemplate>
<div class="TreeListBardivItem" id="TreeListBardivItem" runat="server" >
    <asp:Label ID="lblnTCategoryID" runat="server" Text='<% #Bind("nTCategoryID") %>' Visible="false"  ></asp:Label>

    <asp:LinkButton ID="lbtnsTCategoryNameEN" runat="server" Text='<% #Bind("sTCategoryNameEN") %>' CommandName="select"></asp:LinkButton>
     <asp:LinkButton ID="lbtsTCategoryNameCN" runat="server" Text='<% #Bind("sTCategoryNameCN") %>'  CommandName="select" Visible="false"></asp:LinkButton>
</div>


</ItemTemplate>
</asp:ListView>

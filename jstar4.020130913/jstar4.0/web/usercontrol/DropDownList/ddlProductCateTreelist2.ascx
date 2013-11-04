<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ddlProductCateTreelist2.ascx.cs" Inherits="usercontrol_DropDownList_ddlProductCateTreelist2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:TextBox ID="txtProducCateID" runat="server" Width="180px"></asp:TextBox>
<asp:DropDownExtender ID="txtProducCateID_DropDownExtender" runat="server" 
    TargetControlID="txtProducCateID"  DropDownControlID="PnlTreeList"  >
</asp:DropDownExtender>
<%--<asp:HoverMenuExtender ID="txtGrouplist_HoverMenuExtender" runat="server"  PopupControlID="PnlTreeList"
         TargetControlID="txtProducCateID" PopupPosition="Bottom" 
           >
        </asp:HoverMenuExtender>--%>
<asp:Panel ID="PnlTreeList" runat="server"  style=" min-width:200px; background-color:#fff; border:1px solid #333;">
    <asp:TreeView ID="TreeView1" runat="server"  CssClass="TreeViewSkin" ShowLines="true"  onselectednodechanged="TreeView1_SelectedNodeChanged">
      
        <RootNodeStyle  CssClass="TreeRootNode" />
        <ParentNodeStyle  CssClass="TreeRootNode" />
        <SelectedNodeStyle CssClass="SelectedTreeNode" />
        <LeafNodeStyle  CssClass="LeafTreeNode" />
       <HoverNodeStyle CssClass="HoverTreeNode" />
    </asp:TreeView>
</asp:Panel>

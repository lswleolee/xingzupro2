<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Treebar.ascx.cs" Inherits="usercontrol_DataList_Treebar" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
        <asp:TreeView ID="TreeView1" runat="server" CssClass="sidebar" 
            onselectednodechanged="TreeView1_SelectedNodeChanged" 
            ShowExpandCollapse="false">
            <HoverNodeStyle CssClass="headeritemac" />
            <SelectedNodeStyle  CssClass="headeritemac"/>
            <RootNodeStyle CssClass="headeritem" />
            <ParentNodeStyle CssClass="headeritem" />
            <LeafNodeStyle CssClass="item" />
        </asp:TreeView>
    </ContentTemplate>
</asp:UpdatePanel>
 
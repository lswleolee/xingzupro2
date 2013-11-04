<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowMsg.ascx.cs" Inherits="usercontrol_ShowMsg" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="css/ShowMessage.css" rel="stylesheet" type="text/css" />

    <%--<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
        BackgroundCssClass="ShowMessagemodalBackground" OkControlID="btnModalOK" 
        oncancelscript="btnModalCancel" PopupControlID="PanelModal" 
        PopupDragHandleControlID="lbtnCheckClassID" TargetControlID="HiddenField1">
      </asp:ModalPopupExtender>--%>
      <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
        BackgroundCssClass="ShowMessagemodalBackground" 
        PopupControlID="PanelModal" 
        PopupDragHandleControlID="lbtnCheckClassID" TargetControlID="HiddenField1"></asp:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField1" runat="server" />

<%--<asp:Panel ID="PanelModal" runat="server" CssClass="ShowMessagemodalPopup" style="display:none;">--%>
<asp:Panel ID="PanelModal" runat="server" CssClass="ShowMessagemodalPopup" >
<asp:Panel ID="PnlShowMessage" runat="server"  CssClass="PnlShowMessageStyle">
<div  class="Title">
    <asp:Label ID="lblTitle" runat="server" Text="系统信息" ></asp:Label></div>
    <div  class="Content">
    <div id="divInnerContent" runat="server">
    
    
    </div>
    
    </div>
</asp:Panel>
<div style=" text-align:right;">
                <asp:Button ID="btnModalOK" runat="server" Text="确认" CssClass="btnOrange" 
                    onclick="btnModalOK_Click" />
    <asp:Button ID="btnModalCancel" runat="server" Text="取消" CssClass="button" 
                    Visible="False" /></div>

</asp:Panel>
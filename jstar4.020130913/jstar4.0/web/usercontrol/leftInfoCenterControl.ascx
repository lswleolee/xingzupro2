<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leftInfoCenterControl.ascx.cs" Inherits="usercontrol_leftInfoCenterControl" %>
<style type="text/css">
    .style1
    {
        height: 16px;
    }
</style>
<div class="divleftitle">
    <asp:Label ID="lbltitleleft" runat="server" Text="Info. Center"></asp:Label>
</div>
<div class="divleftlist">
<table class="leftMsg">
              
          <tr>
          <td>
              
          <asp:LinkButton ID="lbltitle" runat="server"  Text="none" 
                  onclick="lbltitle_Click"  ></asp:LinkButton>
             </td>
          
          </tr>
          <tr>
          <td class="style1">
             <asp:Label ID="lbltime" runat="server"    Text="" style="height: 20px; font-size: 12px; color: #999933;"></asp:Label>
          </td>
          
          </tr>
          <tr>
          <td>
             <asp:Label ID="lblContent" runat="server"    Text="" ></asp:Label>
          </td>
          
          </tr>
             
          
          </table>
          <div style=" text-align:right;">
    <asp:Button ID="btnMoreFaqs" runat="server" Text="More"  CssClass="btnGreen"  style="  padding:3px; font-size:10px;"
        onclick="btnMoreFaqs_Click"/>
</div>
</div>
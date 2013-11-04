<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leftFAQsControl.ascx.cs" Inherits="usercontrol_leftFAQsControl" %>
<div class="divleftitle">
    <asp:Label ID="lblFAQSleft" runat="server" Text="FAQS"></asp:Label>
</div>
<div class="divleftlist">
  <asp:GridView ID="gvFAQS" runat="server" AutoGenerateColumns="False" PageSize="2" 
        CssClass="leftMsg" ShowHeader="False" Width="100%" 
        onrowdatabound="gvFAQS_RowDataBound"  GridLines="None"
        onselectedindexchanging="gvFAQS_SelectedIndexChanging">
      <Columns>
          <asp:TemplateField>
          <ItemTemplate>
          <table>
              
          <tr>
          <td>
              <asp:Label ID="lblnID" runat="server" Text='<% #Bind("nFAQID") %>' Visible="false"></asp:Label>
          <asp:LinkButton ID="lblFAQSCN" runat="server"  Text='<% #Bind("sQuestionCN") %>' Visible="false" CommandName="select"></asp:LinkButton>
          <asp:LinkButton ID="lblFAQSEN" runat="server"  Text='<% #Bind("sQuestionEN") %>' CommandName="select"></asp:LinkButton>
          </td>
          
          </tr><tr>
          <td>
          <asp:Label ID="lblAnswerCN" runat="server"    Text='<% #Bind("sAnswerCN") %>' Visible="false"></asp:Label>
          <asp:Label ID="lblAnswerEN" runat="server"    Text='<% #Bind("sAnswerEN") %>'></asp:Label>
          </td>
          
          </tr>
             
          
          </table>
          </ItemTemplate>
          
          </asp:TemplateField>
      </Columns>
</asp:GridView>
<div style=" text-align:right;">
    <asp:Button ID="btnMoreFaqs" runat="server" Text="More"  CssClass="btnGreen"  style="  padding:3px; font-size:10px;"
        onclick="btnMoreFaqs_Click"/>
</div>
</div>



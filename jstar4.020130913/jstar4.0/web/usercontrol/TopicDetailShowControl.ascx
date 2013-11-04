<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopicDetailShowControl.ascx.cs" Inherits="usercontrol_TopicDetailShowControl" %>
 <div class="smalltitle">
        <asp:Label ID="lblBigTitle" runat="server" Text="Aboutus"></asp:Label>
    </div>
    <div class="divrightContent">
    
    
  
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
    <div id="divsContent"  runat="server">
    </div>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:DataList ID="dlAlbum" runat="server" RepeatDirection="Horizontal" 
            RepeatColumns="6" onitemdatabound="dlAlbum_ItemDataBound" >
            <ItemTemplate>
              
                <div style=" width:140px; padding:2px 2px 2px 2px ;">
                
             
                        <%--  <div style="position:relative;   z-index:100;  width:100px; padding:3px; text-align:right;">
                           <asp:LinkButton ID="LinkButton1" runat="server" Text="x" ToolTip="delete" ></asp:LinkButton>
                </div>--%>
                         <div style="position:relative;  z-index:-100;   "> 
                          <asp:Label ID="lblpID" runat="server" Text='<% #Bind("nTCategoryID") %>' Visible="false" ></asp:Label>
                          <asp:Image ID="imgHot" runat="server"  Width="130px" Height="130px" ImageUrl='<% #Bind("sImagePath") %>'/></div>
                   
                
                
                <div style="height:22px;  width:98%; vertical-align: middle;  padding:4px; text-align:center;">
                   <asp:Label ID="lblImgNameEN" runat="server" Text='<% #Bind("sImageNameEN") %>'></asp:Label>
                   <asp:Label ID="lblImgNameCN" runat="server" Text='<% #Bind("sImageNameCN") %>'></asp:Label>
                
                </div>
                
               
               
                </div>
            </ItemTemplate>
      
        </asp:DataList>
    </asp:View>
    <asp:View ID="View3" runat="server">
        <asp:ListView ID="lvNews" runat="server" onitemdatabound="lvNews_ItemDataBound" 
            onselectedindexchanging="lvNews_SelectedIndexChanging" >
        <LayoutTemplate>

  <table cellspacing="0" width="100%"  class="lvNewsList">
                  
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </tbody>
                </table>

</LayoutTemplate>
<ItemTemplate>
    <tr>
        <td>
            <table>
                <tr>
                    <td rowspan="3">
                        <asp:Label ID="lblnID" runat="server" Text='<% #Bind("nNewsID") %>'  Visible="false"></asp:Label>
                        <asp:Image ID="imgNews" runat="server" Width="120px" Height="120px" ImageUrl='<% #Bind("sImagePath") %>' />
                    </td>
                    <td style="height: 20px;">
                  
                        <asp:LinkButton ID="lbtnNewsTitle" runat="server" Text='<% #Bind("sTitle") %>' CommandName="select"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; font-size: 12px; color: #999933;">
                        <asp:Label ID="lbltime" runat="server" Text='<% #Bind("dUpdatedTime") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 70px; vertical-align: top;">
                        <asp:Label ID="lblContent" runat="server" Text='<% #Bind("sContent") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</ItemTemplate>
        </asp:ListView>
        <asp:Panel ID="PnlNewsDetail" runat="server" Visible="false" Width="100%">
        <div style=" padding:4px;">
            <asp:Label ID="lblNewsDetailtitle" runat="server" Text="Label"></asp:Label>
        </div>
        <div style=" padding:4px;height: 20px; font-size: 12px; color: #999933;">
            <asp:Label ID="lblNewsDetailTime" runat="server" Text="Label"></asp:Label>
        </div>
        <div id="divNewsDetail" runat="server" style=" padding:4px;"></div>
        </asp:Panel>
    </asp:View>
    <asp:View ID="View4" runat="server">
    <asp:ListView ID="lvFAQs" runat="server" onitemdatabound="lvFAQs_ItemDataBound" 
            onselectedindexchanging="lvFAQs_SelectedIndexChanging">
     <LayoutTemplate>

  <table cellspacing="0" width="100%"  class="lvNewsList">
                  
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </tbody>
                </table>

</LayoutTemplate>
<ItemTemplate>
<tr><td>
    
    <table>
        <tr>
            <td rowspan="3">
            </td>
            <td style="height: 25px;">
             <asp:Label ID="lblnID" runat="server" Text='<% #Bind("nFAQID") %>' Visible="false"></asp:Label>
            <asp:LinkButton ID="lbtnFAQsTitleEN" runat="server" Text='<% #Bind("sQuestionEN") %>' CommandName="select"></asp:LinkButton>
                <asp:LinkButton ID="lbtnFAQsTitleCN" runat="server" Text='<% #Bind("sQuestionCN") %>' CommandName="select" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 25px; font-size: 12px; color: #ff9933;">
                <asp:Label ID="lbltime" runat="server" Text='<% #Bind("dCreatedTime") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 70px; vertical-align: top;">
                <asp:Label ID="lblFAQsAnswerEN" runat="server" Text='<% #Bind("sAnswerEN") %>'></asp:Label>
               <asp:Label ID="lblFAQsAnswerCN" runat="server" Text='<% #Bind("sAnswerCN") %>' Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</td></tr>
</ItemTemplate>
        </asp:ListView>
        <asp:Panel ID="PnlFAQsDetail" runat="server" Visible="false" Width="100%">
        <div style=" padding:4px;">
            <asp:Label ID="lblFAQsDetailtitle" runat="server" Text="Label"></asp:Label>
        </div>
        <div style=" padding:4px;height: 20px; font-size: 12px; color: #999933;">
            <asp:Label ID="lblFAQsDetailTime" runat="server" Text="Label"></asp:Label>
        </div>
        <div id="divFAQsDetail" runat="server" style=" padding:4px;"></div>
        </asp:Panel>
    </asp:View>
    
</asp:MultiView>

  </div>
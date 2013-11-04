<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditAlbum.aspx.cs" Inherits="manage_Album_EditAlbum" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="相册列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
               所属相册栏目: <asp:DropDownList ID="ddlnTCategoryID" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlnTCategoryID_SelectedIndexChanged">
                                </asp:DropDownList>
                <asp:ListView ID="lvAlbumList" runat="server" 
                    onpagepropertieschanged="lvAlbumList_PagePropertiesChanged" 
                    onitemdatabound="lvAlbumList_ItemDataBound" 
                    onitemdeleting="lvAlbumList_ItemDeleting">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnAlbumID" runat="server" 
                                    Text='<% #Bind("nAlbumID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsImageNameCN" runat="server" 
                                    Text='<%#Bind("sImageNameCN") %>'></asp:Label>
                            </td>
                            <td>
                            <asp:Image ID="ImsImagePath" runat="server" 
                                  Width="220px" Height="165px" ImageUrl='<%#Bind("sImagePath") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lbldUpdatedTime" runat="server" 
                                    Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd hh:mm}")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgDelete" runat="server" CommandName="delete"
                                    ImageUrl="~/manage/style/images/trash.png" CssClass="imgbtn"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table cellspacing="0" class="ListViewStyle">
                            <thead>
                                <tr class="ListViewHead">
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnAlbumID" runat="server" Text="相册编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsImageNameCN" runat="server" Text="图片中文名字"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsImagePath" runat="server" Text="图片"></asp:LinkButton>
                                    </th>
                                    <th style=" width:130px;">
                                        <asp:LinkButton ID="lbtndUpdatedTime" runat="server" Text="更新时间"></asp:LinkButton>
                                    </th>
                                    <th class="roundedright">
                                        <asp:Label ID="lbloprea" runat="server" Text=""></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
                <asp:DataPager ID="DataPager1" runat="server" 
                    PagedControlID="lvAlbumList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
        </asp:MultiView>
        
    </ContentTemplate>
</asp:UpdatePanel>
    </asp:Content>


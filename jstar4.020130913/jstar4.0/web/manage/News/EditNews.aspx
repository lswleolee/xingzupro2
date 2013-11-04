<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditNews.aspx.cs" Inherits="manage_News_EditNews" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<%@ Register Src="../../usercontrol/MutileUploaderUserControl3.ascx" tagname="MutileUploaderUserControl3" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="新闻列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>
     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvNewsList" runat="server" 
                    onpagepropertieschanged="lvNewsList_PagePropertiesChanged" 
                    onitemdatabound="lvNewsList_ItemDataBound" 
                    onitemdeleting="lvNewsList_ItemDeleting" 
                    onselectedindexchanging="lvNewsList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnNewsID" runat="server" 
                                    Text='<% #Bind("nNewsID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnTCategoryID" runat="server" 
                                    Text='<% #Bind("nTCategoryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnLangType" runat="server" 
                                    Text='<%#Bind("nLangType") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTitle" runat="server" 
                                    Text='<%#Bind("sTitle") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsAuthor" runat="server" 
                                    Text='<%#Bind("sAuthor") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnSorting" runat="server" 
                                    Text='<%#Bind("nSorting") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldUpdatedTime" runat="server" 
                                    Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd hh:mm}")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgEdit" runat="server" CommandName="select"
                                    ImageUrl="~/manage/style/images/user_edit.png" CssClass="imgbtn" />
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
                                        <asp:LinkButton ID="lbtnnNewsID" runat="server" Text="新闻编号"></asp:LinkButton>
                                    </th>
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnTCategoryID" runat="server" Text="栏目名称"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnLangType" runat="server" Text="语种"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTitle" runat="server" Text="标题"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsAuthor" runat="server" Text="作者"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnSorting" runat="server" Text="优先级"></asp:LinkButton>
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
                    PagedControlID="lvNewsList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑新闻"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回新闻列表" />

                                 <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnTCategoryID" runat="server" Text="栏目"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:DropDownList ID="ddlnTCategoryID" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnLangType" runat="server" Text="语种"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="rblnLangType" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">中文</asp:ListItem>
                                    <asp:ListItem Value="2">英文</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsTitle" runat="server" Text="标题"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTitle" runat="server" Width="400px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsAuthor" runat="server" Text="作者"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsAuthor" runat="server" Width="400px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                        <td class="FirstCol">
                        <asp:Label ID="Label2" runat="server" Text="图片列表"></asp:Label><br />
                            <asp:Button ID="Button1" runat="server" CssClass="btnOrange" Text="清除图片" 
                                onclick="Button1_Click" />
                        </td>
                        <td class="SecondCol">
                           
                            <asp:Image ID="Image3" runat="server" Height="75px" Width="135px" />
                           
                        </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsImagePath" runat="server" Text="图片路径"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <uc2:MutileUploaderUserControl3 ID="MutileUploaderUserControl3" 
                                    runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContent" runat="server" Text="内容"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <ckeditor:ckeditorcontrol ID="CKEditorControl1" runat="server"   Height="350px" Width=""
                                    ></ckeditor:ckeditorcontrol>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentEN" runat="server" Text="内容(英文)"></asp:Label>
                            </td>
                                <td class="SecondCol">
                                <ckeditor:ckeditorcontrol ID="CKEditorControl2" runat="server"   Height="350px" Width=""
                                    ></ckeditor:ckeditorcontrol>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnSorting" runat="server" Text="优先级"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:DropDownList ID="ddlnSorting" runat="server">
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                
                            </td>
                            <td class="SecondCol">
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="更新" />
                                    
                                        <asp:HiddenField ID="hfNewsUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


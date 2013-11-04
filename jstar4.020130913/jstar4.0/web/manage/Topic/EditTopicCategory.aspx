<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditTopicCategory.aspx.cs" Inherits="manage_Topic_EditTopicCategory" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="栏目列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvTopicCategoryList" runat="server" 
                    onpagepropertieschanged="lvTopicCategoryList_PagePropertiesChanged" 
                    onitemdatabound="lvTopicCategoryList_ItemDataBound" 
                    onitemdeleting="lvTopicCategoryList_ItemDeleting" 
                    onselectedindexchanging="lvTopicCategoryList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnTCategoryID" runat="server" 
                                    Text='<% #Bind("nTCategoryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnTopicID" runat="server" 
                                    Text='<% #Bind("nTopicID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTCategoryNameCN" runat="server" 
                                    Text='<%#Bind("sTCategoryNameCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTCategoryNameEN" runat="server" 
                                    Text='<%#Bind("sTCategoryNameEN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnType" runat="server" 
                                    Text='<%#Bind("nType") %>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnTCategoryID" runat="server" Text="栏目编号"></asp:LinkButton>
                                    </th>
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnTopicID" runat="server" Text="母栏目名称"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTCategoryNameCN" runat="server" Text="栏目名称(中文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTCategoryNameEN" runat="server" Text="栏目名称(英文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnType" runat="server" Text="显示型式"></asp:LinkButton>
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
                    PagedControlID="lvTopicCategoryList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑栏目"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回栏目列表" />

                                 <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnTopicID" runat="server" Text="母栏目"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:DropDownList ID="ddlnTopicID" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsTCategoryNameCN" runat="server" Text="栏目名称(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTCategoryNameCN" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsTCategoryNameEN" runat="server" Text="栏目名称(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTCategoryNameEN" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnType" runat="server" Text="显示型式"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="rblnType" runat="server" RepeatDirection="Horizontal" 
                                    AutoPostBack="True" onselectedindexchanged="rblnType_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Selected="True">自定义编辑内容</asp:ListItem>
                                    <asp:ListItem Value="2">相册</asp:ListItem>
                                    <asp:ListItem Value="3">新闻信息列表</asp:ListItem>
                                    <asp:ListItem Value="4">问答信息列表</asp:ListItem>
                                    <asp:ListItem Value="5">联系方式内容</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentCN" runat="server" Text="内容(中文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <ckeditor:ckeditorcontrol ID="CKEditorControl1" runat="server"   Height="350px" Width=""
                                    ></ckeditor:ckeditorcontrol>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentEN" runat="server" Text="内容(英文)"></asp:Label>
                            </td>
                                <td class="SecondCol">
                                <ckeditor:ckeditorcontrol ID="CKEditorControl2" runat="server"   Height="350px" Width=""
                                    ></ckeditor:ckeditorcontrol>
                            </td>
                        </tr>
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
                                    
                                        <asp:HiddenField ID="hfTopicCategoryUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
        
    </ContentTemplate>
</asp:UpdatePanel>
    </asp:Content>


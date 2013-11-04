<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditTopic.aspx.cs" Inherits="manage_Topic_EditTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="栏目列表"></asp:Label>
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvTopicList" runat="server" 
                    onpagepropertieschanged="lvTopicList_PagePropertiesChanged" 
                    onitemdatabound="lvTopicList_ItemDataBound" 
                    onitemdeleting="lvTopicList_ItemDeleting" 
                    onselectedindexchanging="lvTopicList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnTopicID" runat="server" 
                                    Text='<% #Bind("nTopicID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTopicNameCN" runat="server" 
                                    Text='<% #Bind("sTopicNameCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTopicNameEN" runat="server" 
                                    Text='<%#Bind("sTopicNameEN") %>'></asp:Label>
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
                                <asp:ImageButton ID="imgEdit" runat="server" 
                                    ImageUrl="~/manage/style/images/user_edit.png" CssClass="imgbtn" />
                                <asp:ImageButton ID="imgDelete" runat="server" 
                                    ImageUrl="~/manage/style/images/trash.png" CssClass="imgbtn"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table cellspacing="0" class="ListViewStyle">
                            <thead>
                                <tr class="ListViewHead">
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnTopicID" runat="server" Text="栏目编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTopicNameCN" runat="server" Text="栏目名称(中文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTopicNameEN" runat="server" Text="栏目名称(英文)"></asp:LinkButton>
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
                    PagedControlID="lvTopicList">
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
                                <asp:Label ID="lblsTopicNameCN" runat="server" Text="栏目名称(中文)"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTopicNameCN" runat="server" Width="180px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsTopicNameEN" runat="server" Text="栏目名称(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTopicNameEN" runat="server" Width="180px" ></asp:TextBox>
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
                                    
                                        <asp:HiddenField ID="hfTopicUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


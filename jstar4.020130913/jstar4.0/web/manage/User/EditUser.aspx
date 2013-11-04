<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="manage_User_EditUser" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="用户列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvUserList" runat="server" 
                    onpagepropertieschanged="lvUserList_PagePropertiesChanged" 
                    onitemdatabound="lvUserList_ItemDataBound" 
                    onitemdeleting="lvUserList_ItemDeleting" 
                    onselectedindexchanging="lvUserList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnUserID" runat="server" 
                                    Text='<% #Bind("nUserID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsUsername" runat="server" 
                                    Text='<% #Bind("sUsername") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnUserType" runat="server" 
                                    Text='<%#Bind("nUserType") %>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnUserID" runat="server" Text="用户编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsUsername" runat="server" Text="用户名称"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnUserType" runat="server" Text="用户类型"></asp:LinkButton>
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
                    PagedControlID="lvUserList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑用户"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回用户列表" />

                                <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUsername" runat="server" Text="用户名称"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUsername" runat="server" Width="180px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPassword" runat="server" Text="用户密码"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPassword" runat="server" Width="180px" 
                                    TextMode="Password" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPassword2" runat="server" Text="用户密码确认"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPassword2" runat="server" Width="180px" 
                                    TextMode="Password" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsRealName" runat="server" Text="用户真实名"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsRealName" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnUserSex" runat="server" Text="用户性别"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="rblnUserSex" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserQQ" runat="server" Text="用户QQ"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsUserQQ" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserMSN" runat="server" Text="用户MSN"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserMSN" runat="server" Width="180px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserPhone" runat="server" Text="用户手机号码"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserPhone" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsUserEmail" runat="server" Text="用户EMAIL"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsUserEmail" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnUserType" runat="server" Text="用户类型"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:RadioButtonList ID="rblnUserType" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">普通用户</asp:ListItem>
                                    <asp:ListItem Value="2">超级用户</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblIsContact" runat="server" Text="查看留言权限"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:CheckBox ID="cbIsContact" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblIsInquiry" runat="server" Text="查看需求权限"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:CheckBox ID="cbIsInquiry" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                
                            </td>
                            <td class="SecondCol">
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="更新" />
                                    
                                        <asp:HiddenField ID="hfUserUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


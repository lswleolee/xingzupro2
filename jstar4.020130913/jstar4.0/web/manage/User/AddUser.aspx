<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="manage_User_AddUser" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加用户"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
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
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    OnClick="BtnAdd_Click" Text="添加" />


                                <asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空" 
                                    onclick="BtnClear_Click" />


                              
                            </td>
                        </tr>
                    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddLink.aspx.cs" Inherits="manage_Link_AddLink" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加联系"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
    <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnType" runat="server" Text="联系方式类型"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:DropDownList ID="ddlnType" runat="server">
                                    <asp:ListItem Value="1">MSN</asp:ListItem>
                                    <asp:ListItem Value="2">EMAIL</asp:ListItem>
                                    <asp:ListItem Value="3">Skype</asp:ListItem>
                                    <asp:ListItem Value="4">QQ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsLink" runat="server" Text="联系"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsLink" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnSorting" runat="server" Text="优先级"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:DropDownList ID="ddlnSorting" runat="server">
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
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    OnClick="BtnAdd_Click" Text="添加" />


                                <asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空" 
                                    onclick="BtnClear_Click" />


                              
                            </td>
                        </tr>
                    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddTopicCategory.aspx.cs" Inherits="manage_Topic_AddTopicCategory" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加栏目"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
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
                                    onselectedindexchanged="rblnType_SelectedIndexChanged" AutoPostBack="True">
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
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    OnClick="BtnAdd_Click" Text="添加" />


                                <asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空" 
                                    onclick="BtnClear_Click" />


                              
                            </td>
                        </tr>
                    </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


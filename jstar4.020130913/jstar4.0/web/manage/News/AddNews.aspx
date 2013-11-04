<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="manage_News_AddNews" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<%@ Register src="../../usercontrol/MutileUploaderUserControl3.ascx" tagname="MutileUploaderUserControl3" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加新闻"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
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
                                <asp:Label ID="lblsImagePath" runat="server" Text="图片路径"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <uc2:MutileUploaderUserControl3 ID="MutileUploaderUserControl3" runat="server" />
                            </td>
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
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    OnClick="BtnAdd_Click" Text="添加" />


                                <asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空" 
                                    onclick="BtnClear_Click" />


                              
                            </td>
                        </tr>
                    </table>
</asp:Content>


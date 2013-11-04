<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddTopic.aspx.cs" Inherits="manage_Topic_AddTopic" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加栏目"></asp:Label>
    </div>
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
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btnOrange" 
                                    OnClick="BtnAdd_Click" Text="添加" />


                                <asp:Button ID="BtnClear" runat="server" CssClass="btnGreen" Text="清空" 
                                    onclick="BtnClear_Click" />


                              
                            </td>
                        </tr>
                    </table>
</asp:Content>


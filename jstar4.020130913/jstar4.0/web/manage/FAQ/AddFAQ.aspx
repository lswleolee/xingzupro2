<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddFAQ.aspx.cs" Inherits="manage_FAQ_AddFAQ" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="添加FAQ"></asp:Label>
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
    <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsQuestionCN" runat="server" Text="问题(中文)"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsQuestionCN" runat="server" Width="500px" Height="120px" 
                                    TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsQuestionEN" runat="server" Text="问题(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsQuestionEN" runat="server"  Width="500px" Height="120px" 
                                    TextMode="MultiLine" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsAnswerCN" runat="server" Text="答案(中文)"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsAnswerCN" runat="server"  Width="500px" Height="120px" 
                                    TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsAnswerEN" runat="server" Text="答案(英文)"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsAnswerEN" runat="server" Width="500px" Height="120px" 
                                    TextMode="MultiLine" ></asp:TextBox>
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


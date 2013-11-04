<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddProductCategory.aspx.cs" Inherits="manage_Product_AddProductCategory" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/DropDownList/ddlProductCateTreelist.ascx" tagname="ddlProductCateTreelist" tagprefix="uc1" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="货品类别添加"></asp:Label>
        <uc2:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
    <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnParentCategoryID" runat="server" Text="父级类别"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <uc1:ddlProductCateTreelist ID="ddlProductCateTreelist1" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>      
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameCN" runat="server" Text="类别中文名"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductCategoryNameCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductCategoryNameEN" runat="server" Text="类别英文名"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductCategoryNameEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentCN" runat="server" Text="内容"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>


                               
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentEN" runat="server" Text="内容"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server"></CKEditor:CKEditorControl>


                               
                                <br />
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


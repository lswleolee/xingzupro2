<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="manage_Product_AddProduct" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>
<%@ Register src="../../usercontrol/DropDownList/ddlProductCateTreelist2.ascx" tagname="ddlProductCateTreelist2" tagprefix="uc1" %>
<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc2" %>
<%@ Register Src="../../usercontrol/MutileUploaderUserControl.ascx" tagname="MutileUploaderUserControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="产品资料添加"></asp:Label>
        <uc2:ShowMsg ID="ShowMsg1" runat="server" />
    </div>
    <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnParentCategoryID" runat="server" Text="产品类别选择"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <uc1:ddlProductCateTreelist2 ID="ddlProductCateTreelist2" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>      
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblbHot" runat="server" Text="热门产品"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:CheckBox ID="cbbHot" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductNameCN" runat="server" Text="产品名称(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductNameCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductNameEN" runat="server" Text="产品名称(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsProductNameEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                            <asp:Label ID="Label1" runat="server" Text="产品图片"></asp:Label>
                            </td>
                            <td class="SecondCol">
                            <uc3:MutileUploaderUserControl ID="MutileUploaderUserControl1" 
                                    runat="server" />
                                </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryCN" runat="server" Text="产品简介(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsSummaryCN" runat="server" Width="500px" Height="125px" 
                                    TextMode="MultiLine" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSummaryEN" runat="server" Text="产品简介(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsSummaryEN" runat="server" Width="500px" Height="125px" 
                                    TextMode="MultiLine" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                       <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPlaceoforiginCN" runat="server" Text="产地(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPlaceoforiginCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPlaceoforiginEN" runat="server" Text="产地(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPlaceoforiginEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsModelNoCN" runat="server" Text="型号(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsModelNoCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsModelNoEN" runat="server" Text="型号(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsModelNoEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPriceTermsCN" runat="server" Text="价格条款(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPriceTermsCN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPriceTermsEN" runat="server" Text="价格条款(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPriceTermsEN" runat="server" Width="180px" ></asp:TextBox>


                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPaymentTermsCN" runat="server" Text="付款方式(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPaymentTermsCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPaymentTermsEN" runat="server" Text="付款方式(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPaymentTermsEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPackageCN" runat="server" Text="包装(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPackageCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPackageEN" runat="server" Text="包装(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsPackageEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMinimumOrderCN" runat="server" Text="最少起订量(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMinimumOrderCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMinimumOrderEN" runat="server" Text="最少起订量(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsMinimumOrderEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDeliveryTimeCN" runat="server" Text="交货时间(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsDeliveryTimeCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsDeliveryTimeEN" runat="server" Text="交货时间(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsDeliveryTimeEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsBrandNameCN" runat="server" Text="品牌名称(中文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsBrandNameCN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsBrandNameEN" runat="server" Text="品牌名称(英文)"></asp:Label>


                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsBrandNameEN" runat="server" Width="180px" ></asp:TextBox>

                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentCN" runat="server" Text="中文内容"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" 
                                  ></CKEditor:CKEditorControl>


                               
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContentEN" runat="server" Text="英文内容"></asp:Label>


                            </td>
                            <td class="SecondCol">
                               
                                <CKEditor:CKEditorControl ID="CKEditorControl2" runat="server" 
                                   ></CKEditor:CKEditorControl>


                               
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


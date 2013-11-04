<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="manage_Product_EditProduct" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="ckeditor" %>

<%@ Register src="../../usercontrol/DropDownList/ddlProductCateTreelist2.ascx" tagname="ddlProductCateTreelist2" tagprefix="uc1" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc2" %>
<%@ Register Src="../../usercontrol/MutileUploaderUserControl.ascx" tagname="MutileUploaderUserControl" tagprefix="uc3" %>
<%@ Register src="../../usercontrol/DropDownList/ddlProductCateTreelist.ascx" tagname="ddlProductCateTreelist" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="产品列表"></asp:Label>
       
        <uc2:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           所属产品类型:
                        </td>
                        <td>
                           <uc1:ddlProductCateTreelist ID="ddlProductCateTreelist1" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="关键字"></asp:Label>   <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btnOrange" Height="24px" 
                    onclick="btnSearch_Click" Text="Search" />
                        </td>
                    </tr>
                   
                </table>
               

                
               
                <asp:ListView ID="lvProductList" runat="server" 
                    onpagepropertieschanged="lvProductList_PagePropertiesChanged" 
                    onitemdatabound="lvProductList_ItemDataBound" 
                    onitemdeleting="lvProductList_ItemDeleting" 
                    onselectedindexchanging="lvProductList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnProductID" runat="server" 
                                    Text='<% #Bind("nProductID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnProductCategoryID" runat="server" 
                                    Text='<% #Bind("nProductCategoryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsProductNameCN" runat="server" 
                                    Text='<%#Bind("sProductNameCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsProductNameEN" runat="server" 
                                    Text='<%#Bind("sProductNameEN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldCreatedTime" runat="server" 
                                    Text='<% #Bind("dCreatedTime","{0:yyyy-MM-dd hh:mm}")%>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnProductID" runat="server" Text="产品ID"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnProductCategoryID" runat="server" Text="类别"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsProductNameCN" runat="server" Text="产品名称(中文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsProductNameEN" runat="server" Text="产品名称(英文)"></asp:LinkButton>
                                    </th>
                                    <th style=" width:130px;">
                                        <asp:LinkButton ID="lbtndCreatedTime" runat="server" Text="加入时间"></asp:LinkButton>
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
                    PagedControlID="lvProductList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑产品"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回产品列表" />
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
                        <asp:Label ID="Label2" runat="server" Text="图片列表"></asp:Label><br />
                            <asp:Button ID="Button1" runat="server" CssClass="btnOrange" Text="显示图片" 
                                onclick="Button1_Click" />
                        </td>
                        <td class="SecondCol">
                           <asp:ListView ID="lvProductImageList" runat="server" 
                                onitemdatabound="lvProductImageList_ItemDataBound" 
                                onitemdeleting="lvProductImageList_ItemDeleting" Visible="False" >
                             <ItemTemplate>
                               <tr class="ListViewRow">
                                 <td>
                                <asp:Label ID="lblnPImageID" runat="server" 
                                    Text='<% #Bind("nPImageID") %>'></asp:Label>
                            </td>
                            <td>
                            <asp:Image ID="ImsPImagePath" runat="server" 
                                  Width="75px" Height="50px" ImageUrl='<%#Bind("sPImagePath") %>' />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgDelete1" runat="server" CommandName="delete"
                                    ImageUrl="~/manage/style/images/trash.png" CssClass="imgbtn"/>
                            </td>
                               </tr>
                             </ItemTemplate>
                             <LayoutTemplate>
                               <table cellspacing="0" class="ListViewStyle">
                            <thead>
                               <tr class="ListViewHead">
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnPImageID" runat="server" Text="图片编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsImagePath" runat="server" Text="图片"></asp:LinkButton>
                                    </th>
                                    <th class="roundedright">
                                        <asp:Label ID="lbloprea" runat="server" Text=""></asp:Label>
                                    </th>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                           </asp:ListView>
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
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="更新" />
                                    
                                        <asp:HiddenField ID="hfProductUpdateID" runat="server" />
                                    </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


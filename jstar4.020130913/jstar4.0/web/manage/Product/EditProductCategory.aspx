<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditProductCategory.aspx.cs" Inherits="manage_Product_EditProductCategory" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="ckeditor" %>

<%@ Register src="../../usercontrol/DropDownList/ddlProductCateTreelist.ascx" tagname="ddlProductCateTreelist" tagprefix="uc1" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="货品类别列表"></asp:Label>
       
        <uc2:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvProductCategoryList" runat="server" 
                    onpagepropertieschanged="lvProductCategoryList_PagePropertiesChanged" 
                    onitemdatabound="lvProductCategoryList_ItemDataBound" 
                    onitemdeleting="lvProductCategoryList_ItemDeleting" 
                    onselectedindexchanging="lvProductCategoryList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnProductCategoryID" runat="server" 
                                    Text='<% #Bind("nProductCategoryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnParentCategoryID" runat="server" 
                                    Text='<% #Bind("nParentCategoryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsProductCategoryNameCN" runat="server" 
                                    Text='<%#Bind("sProductCategoryNameCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsProductCategoryNameEN" runat="server" 
                                    Text='<%#Bind("sProductCategoryNameEN") %>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnProductCategoryID" runat="server" Text="产品类别ID"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnParentCategoryID" runat="server" Text="父类别"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsProductCategoryNameCN" runat="server" Text="产品类别中文名"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsProductCategoryNameEN" runat="server" Text="产品类别英文名"></asp:LinkButton>
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
                    PagedControlID="lvProductCategoryList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑类别"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回类别列表" />
                <table class="TableList">
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblnProductCategoryIDtitle" runat="server" Text="类型ID"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <asp:Label ID="lblPCID" runat="server" Text="类型ID"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblnParentCategoryID" runat="server" Text="父级类别"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <uc1:ddlProductCateTreelist ID="ddlProductCateTreelist1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblsProductCategoryNameCNtitle" runat="server" Text="类别中文名"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <asp:TextBox ID="txtsProductCategoryNameCN" runat="server" Width="180px"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblsProductCategoryNameENtitle" runat="server" Text="类别英文名"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <asp:TextBox ID="txtsProductCategoryNameEN" runat="server" Width="180px"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblsContentCNtitle" runat="server" Text="内容"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <ckeditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="350px" 
                                Width=""></ckeditor:CKEditorControl>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="FirstCol">
                            <asp:Label ID="lblsContentENtitle" runat="server" Text="内容"></asp:Label>
                        </td>
                        <td class="SecondCol">
                            <ckeditor:CKEditorControl ID="CKEditorControl2" runat="server" Height="350px" 
                                Width=""></ckeditor:CKEditorControl>
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
                                    
                                        <asp:HiddenField ID="hfProductCategoryUpdateID" runat="server" />
                                    </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


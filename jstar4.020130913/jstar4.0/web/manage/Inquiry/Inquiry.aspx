<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="manage_Inquiry_Inquiry" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="需求列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvInquiryList" runat="server" 
                    onpagepropertieschanged="lvInquiryList_PagePropertiesChanged" 
                    onitemdatabound="lvInquiryList_ItemDataBound"
                    onselectedindexchanging="lvInquiryList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnInquiryID" runat="server" 
                                    Text='<% #Bind("nInquiryID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsFirstName" runat="server" 
                                    Text='<% #Bind("sFirstName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsEmail" runat="server" 
                                    Text='<%#Bind("sEmail") %>'></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblsCountry" runat="server" 
                                    Text='<%#Bind("sCountry") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldUpdatedTime" runat="server" 
                                    Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd hh:mm}")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgEdit" runat="server" CommandName="select"
                                    ImageUrl="~/manage/style/images/user_edit.png" CssClass="imgbtn" />
                               <%-- <asp:ImageButton ID="imgDelete" runat="server" CommandName="delete"
                                    ImageUrl="~/manage/style/images/trash.png" CssClass="imgbtn"/>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table cellspacing="0" class="ListViewStyle">
                            <thead>
                                <tr class="ListViewHead">
                                    <th class="roundedleft">
                                        <asp:LinkButton ID="lbtnnInquiryID" runat="server" Text="需求编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsFirstName" runat="server" Text="名字"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsEmail" runat="server" Text="邮箱"></asp:LinkButton>
                                    </th>
                                     <th>
                                        <asp:LinkButton ID="lbtnsCountry" runat="server" Text="国家"></asp:LinkButton>
                                    </th>
                                    <th style=" width:130px;">
                                        <asp:LinkButton ID="lbtndUpdatedTime" runat="server" Text="更新时间"></asp:LinkButton>
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
                    PagedControlID="lvInquiryList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑需求"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回需求列表" />

                                <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsFirstName" runat="server" Text="名字"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsFirstName" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblnSex" runat="server" Text="性别"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtnSex" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsEmail" runat="server" Text="电子邮箱"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsEmail" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsSubject" runat="server" Text="主题"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsSubject" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsMessage" runat="server" Text="内容"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsMessage" runat="server" Width="360px" Height="200px" 
                                    TextMode="MultiLine" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsCountry" runat="server" Text="国家"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsCountry" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsProductIDList" runat="server" Text="需求产品"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsProductIDList" runat="server" Width="360px" Height="76px" 
                                    TextMode="MultiLine" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                
                            </td>
                            <td class="SecondCol">
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="已阅读" />
                                    
                                        <asp:HiddenField ID="hfInquiryUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>

            </asp:View>
        </asp:MultiView>
    </asp:Content>


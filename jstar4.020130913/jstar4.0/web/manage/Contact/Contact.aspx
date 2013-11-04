<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="manage_Contact_Contact" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="留言列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvContactList" runat="server" 
                    onpagepropertieschanged="lvContactList_PagePropertiesChanged" 
                    onitemdatabound="lvContactList_ItemDataBound"
                    onselectedindexchanging="lvContactListt_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnContactID" runat="server" 
                                    Text='<% #Bind("nContactID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsTitle" runat="server" 
                                    Text='<% #Bind("sTitle") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsName" runat="server" 
                                    Text='<%#Bind("sName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsContents" runat="server" 
                                    Text='<%#Bind("sContents") %>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnContactID" runat="server" Text="留言编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsTitle" runat="server" Text="标题"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsName" runat="server" Text="联系人"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsContents" runat="server" Text="内容"></asp:LinkButton>
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
                    PagedControlID="lvContactList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑留言"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回留言列表" />

                                <table class="TableList">
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsTitle" runat="server" Text="标题"></asp:Label>

</td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsTitle" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsName" runat="server" Text="联系人"></asp:Label>
                            </td>
                            <td class="SecondCol">
                                <asp:TextBox ID="txtsName" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsCompanyName" runat="server" Text="企业名称"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsCompanyName" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsAddress" runat="server" Text="企业联系地址"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsAddress" runat="server" Width="180px" ></asp:TextBox>
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
                                <asp:Label ID="lblsFax" runat="server" Text="传真"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsFax" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsPhone" runat="server" Text="手机号码"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsPhone" runat="server" Width="180px" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="FirstCol">
                                <asp:Label ID="lblsContents" runat="server" Text="留言内容"></asp:Label>
                            </td>
                            <td class="SecondCol">
                               <asp:TextBox ID="txtsContents" runat="server" Width="360px" Height="200px" 
                                    TextMode="MultiLine" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FirstCol">
                                
                            </td>
                            <td class="SecondCol">
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="已阅读" />
                                    
                                        <asp:HiddenField ID="hfContactListUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>

            </asp:View>
        </asp:MultiView>
    </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="EditFAQ.aspx.cs" Inherits="manage_FAQ_EditFAQ" %>

<%@ Register src="../../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divpagetitle">
        <asp:Label ID="lbltitle" runat="server" Text="FAQ列表"></asp:Label>
       
        <uc1:ShowMsg ID="ShowMsg1" runat="server" />
       
    </div>

     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:ListView ID="lvFAQList" runat="server" 
                    onpagepropertieschanged="lvFAQList_PagePropertiesChanged" 
                    onitemdatabound="lvFAQList_ItemDataBound" 
                    onitemdeleting="lvFAQList_ItemDeleting" 
                    onselectedindexchanging="lvFAQList_SelectedIndexChanging">
                    <ItemTemplate>
                        <tr class="ListViewRow">
                            <td>
                                <asp:Label ID="lblnFAQID" runat="server" 
                                    Text='<% #Bind("nFAQID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsQuestionCN" runat="server" 
                                    Text='<% #Bind("sQuestionCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsQuestionEN" runat="server" 
                                    Text='<%#Bind("sQuestionEN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsAnswerCN" runat="server" 
                                    Text='<% #Bind("sAnswerCN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsAnswerEN" runat="server" 
                                    Text='<%#Bind("sAnswerEN") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblnSorting" runat="server" 
                                    Text='<%#Bind("nSorting") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldUpdatedTime" runat="server" 
                                    Text='<% #Bind("dUpdatedTime","{0:yyyy-MM-dd hh:mm}")%>'></asp:Label>
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
                                        <asp:LinkButton ID="lbtnnFAQID" runat="server" Text="FAQ编号"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsQuestionCN" runat="server" Text="问题(中文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsQuestionEN" runat="server" Text="问题(英文)"></asp:LinkButton>
                                    </th>
                                     <th>
                                        <asp:LinkButton ID="lbtnsAnswerCN" runat="server" Text="答案(中文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnsAnswerEN" runat="server" Text="答案(英文)"></asp:LinkButton>
                                    </th>
                                    <th>
                                        <asp:LinkButton ID="lbtnnSorting" runat="server" Text="优先级"></asp:LinkButton>
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
                    PagedControlID="lvFAQList">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btnLightBlue" ButtonType="Button" 
                            FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                        <asp:NumericPagerField NextPageText="下一页" PreviousPageText="上一页" />
                    </Fields>
                </asp:DataPager>
            </asp:View>
            <asp:View ID="View2" runat="server">
            <asp:Label ID="Label8" runat="server" Text="编辑FAQ"></asp:Label>
                            <asp:Button ID="btnBackToList" runat="server" CssClass="btnLightBlue" 
                                OnClick="btnBackToList_Click" Text="返回FAQ列表" />

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
                                <asp:TextBox ID="txtsAnswerEN" runat="server"  Width="500px" Height="120px" 
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
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btnOrange" 
                                            OnClick="BtnUpdate_Click" Text="更新" />
                                    
                                        <asp:HiddenField ID="hfFAQUpdateID" runat="server" />
                                    </td>
                        </tr>
                    </table>
            </asp:View>
        </asp:MultiView>
    </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/manage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="managepage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="divpagetitle">
    <asp:Label ID="lbltitle" runat="server" Text="网站首页"></asp:Label>
    </div>
        <asp:ListView runat="server" ID="lvSystemLog"  >
            <ItemTemplate>
                <tr class="ListViewRow">
                    <td>
                        <asp:Label ID="lblnLogID" runat="server" Text='<% #Bind("nLogID") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblsTypeCN" runat="server" Text='<%#Bind("sTypeCN") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblsRemarkCN" runat="server" Text='<%#Bind("sRemarkCN") %>'></asp:Label>
                    </td>
                 
                    <td >
                        <asp:Label ID="lbldCreatedTime" runat="server" Text='<% #Bind("dCreatedTime") %>'></asp:Label>
                    </td>
                  
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table cellspacing="0" class="ListViewStyle">
                    <thead>
                        <tr class="ListViewHead">
                            <th class="roundedleft">
                               <asp:LinkButton ID="lbtnnLogID" runat="server" Text="记录ID"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbtnsTypeCN" runat="server" Text="操作类型"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbtnsRemarkCN" runat="server" Text="操作内容"></asp:LinkButton>
                            </th>
                        
                       
                            
                            <th class="roundedright" style=" width:200px;">
                             <asp:LinkButton ID="lbtndCreatedTime" runat="server" Text="执行时间"></asp:LinkButton>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        
</asp:Content>


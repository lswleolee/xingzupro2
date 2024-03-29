﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MutileUploaderUserControl2.ascx.cs" Inherits="usercontrol_MutileUploaderUserControl2" %>
<script>

    function AddNewAttachment() {
        document.getElementById("divFiles").insertAdjacentHTML("beforeEnd", '<br/>图片中文名字：<input name="txtCN" type="text" style="width: 180px" /><br/>图片英文名字：<input name="txtEN" type="text" style="width: 180px" /><br/><input type="file" name="myfile"  width="250px"/>');
    }
</script>



<div>


<input type="button" id="btnNewAttach" value="添加新附件" onclick="AddNewAttachment();"/>
    <div id="divFiles">
            <asp:Label ID="lblsImageNameCN" runat="server" Text="图片中文名字："></asp:Label>
        
            <asp:TextBox ID="txtsImageNameCN" runat="server" Width="180px" ></asp:TextBox><br />
        
            <asp:Label ID="lblsImageNameEN" runat="server" Text="图片英文名字："></asp:Label>
       
            <asp:TextBox ID="txtsImageNameEN" runat="server" Width="180px" ></asp:TextBox><br />
        <asp:FileUpload ID="FileUpload1" runat="server"  width="250px"/>
    </div>

     <asp:GridView ID="gvFileList" runat="server" CellPadding="4" ForeColor="#333333" 
         GridLines="None" AutoGenerateColumns="False" Width="300px" 
    ShowHeader="False">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:TemplateField>
                 <HeaderTemplate>
                     <asp:LinkButton ID="lbtnsFilenameTitle" runat="server" Text="文件名"></asp:LinkButton>
                 </HeaderTemplate>
                 <ItemTemplate>
                 <asp:Label ID="lblsImageNameCN" runat="server" Text='<% #Bind("sImageNameCN") %>'></asp:Label>
                 <asp:Label ID="lblsImageNameEN" runat="server" Text='<% #Bind("sImageNameEN") %>'></asp:Label>
                     <asp:Label ID="lblsFilename" runat="server" Text='<% #Bind("sFilename") %>'></asp:Label>
                     <asp:Label ID="lblnID" runat="server" Text='<% #Bind("nID") %>'  Visible="false" />
                     </ItemTemplate>
               <ControlStyle Width="250px" />
                  <HeaderStyle Width="250px" />
             </asp:TemplateField>
             
             <asp:TemplateField>
             <HeaderTemplate>
                     <asp:LinkButton ID="lbtnDelTitle0" runat="server" Text=""></asp:LinkButton>
                 </HeaderTemplate>
                 <ItemTemplate>
               <asp:Label ID="lblsHadFilenameTitle" runat="server" Text="已上传"></asp:Label>
                 </ItemTemplate>
                  <ControlStyle Width="50px" />
                  <HeaderStyle Width="50px" />
             </asp:TemplateField>
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="orange" Font-Bold="True" ForeColor="White"   CssClass="gvheadtemplate"/>
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
     
     
     
</div>
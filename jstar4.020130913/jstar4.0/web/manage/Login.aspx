<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="manage_Login" %>

<%@ Register src="../usercontrol/ShowMsg.ascx" tagname="ShowMsg" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/niceforms-default.css" rel="stylesheet" type="text/css" />
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link href="../style/controlcss/Button.css" rel="stylesheet" type="text/css" />
    <link href="../style/controlcss/ShowMessage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main_container">

	<div  class="header_login" style="width:400px; height:100px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </div>

     
         <div class="login_form">
         
        <div style=" width:100%"> <h3>jstar管理面板登陆页面</h3></div>
   
         <div style="clear:both; padding-top:12px; padding-left:20px; font-size:14px; color:#333;">
         <table>
         <tr>
         <td style=" width:120px; text-align:right; padding:5px; height:30px;">
        <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></td>
         <td style="  padding:5px; padding-left:10px;">
            <asp:TextBox ID="txtUsername" runat="server" width="250px"></asp:TextBox></td>
         </tr>
          <tr>
         <td style=" width:120px; text-align:right; padding:5px;height:30px;">
        <asp:Label ID="Label2" runat="server" Text="密 码"></asp:Label></td>
         <td style="  padding:5px; padding-left:10px;">
            <asp:TextBox ID="txtPassword" runat="server" width="250px" TextMode="Password"></asp:TextBox></td>
         </tr>
         <tr>
         <td style=" width:120px; text-align:right; padding:5px;height:30px;">
             &nbsp;</td>
         <td style="  padding:5px; padding-left:10px;">
             <asp:Label ID="Label3" runat="server" Text="(请输入正确的登陆信息)"></asp:Label>
             </td>
         </tr>
         <tr>
         <td style=" width:120px; text-align:right; padding:5px;height:30px;">
        </td>
         <td style="  padding:5px; padding-left:10px;">
            <asp:Button ID="btnLogin" runat="server" Text="登陆管理" CssClass="btnOrange" 
                 onclick="btnLogin_Click" />
                 <asp:Button ID="btnBack" runat="server" Text="返回前台" CssClass="btnOrange" 
                 onclick="btnBack_Click" />  </td>
         </tr>
         </table>
         
         </div>
       
         
       
         </div>  
          
	
    
    <div class="footer_login">
    
    	<div class="left_footer_login">IN ADMIN PANEL | Powered by FrameNet技术支持（黎生：15900092217,谭生：13316745033）</div>
    	<div class="right_footer_login"></div>
    
    </div>

        <uc1:ShowMsg ID="ShowMsg1" runat="server" />

</div>
    </form>
</body>
</html>

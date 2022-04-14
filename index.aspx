<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2NET.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-cn">
<head runat="server">
    <link href="./CSS/goove1.css" rel="stylesheet"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程设计先导程序</title>
    <meta name="description" content="先导程序，正处于测试阶段"/>
    <style type="text/css">
        #form1 {
            font-family: MiSans;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
        <a><h1 id="myHeader">区域安全警报与控制系统</h1></a>
        <p id="sub" align="center">Regional Security <strong>Alarm and Control System</strong>&nbsp;&copy;</p>
    <hr />
    <!--导航栏-->
    <nav id="navZone">
        <asp:HyperLink CssClass="sub" ID="HyperLink_Home" runat="server" Font-Bold="True" Font-Names="MiSans" NavigateUrl="~/index.aspx" Width="50px">主页</asp:HyperLink>
        <asp:HyperLink CssClass="sub" ID="HyperLink_Monitor" runat="server" NavigateUrl="~/error_access.aspx" Width="50px">监视</asp:HyperLink>
    </nav>
        <asp:Button ID="Button_Start" runat="server" Text="开始监视" Font-Size="Small" style="font-weight: 700" OnClick="Button_Start_Click" />
        <asp:Button ID="Button_Stop" runat="server" Text="停止监视" style="font-weight: 700" OnClick="Button_Stop_Click" />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Label" OnDataBinding="Button_Start_Click"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="89px" ReadOnly="True" TextMode="MultiLine" Width="627px"></asp:TextBox>
    <hr />
        <br />
    <div>
        <a href="error_access.aspx">项目支持</a>
        <a href="Report/Report.txt">报告导出</a>
        <a href="#">回到顶部</a>
    </div>
</form>
</body>
</html>

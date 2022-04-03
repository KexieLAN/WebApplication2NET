<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2NET.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-cn">
<head runat="server">
    <link href="./CSS/goove1.css" rel="stylesheet"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程设计先导程序</title>
</head>
<body>
<form id="form1" runat="server">
        <a id="top"><h1 id="myHeader">区域安全警报与控制系统</h1></a>
        <p id="sub">Regional Security <strong>Alarm and Control System</strong></p>
        <hr />
        <br />
        <img src="/img/computer.png" alt="区域监视器" style="width: 215px; height: 217px"/>
        <img src="/img/computer.png" alt="区域监视器" style="width: 215px; height: 217px" />
    </form>
<!----表格---->
    <div>
        <table id="table_show_box">
            <tr  id="show_box">
                <th>区域</th><th>状态</th><th>警报</th>
            </tr>
            <tr ><td>#0</td><td> Dangerous</td><td>Fire</td></tr>
            <tr ><td>#1</td><td>Safe</td><td>NULL</td></tr>
            <tr ><td>#2</td><td>Damage</td><td>Explode</td></tr>
        </table>
    </div>
<!----链接---->
    <div>
        <a href="https://www.bilibili.com" target="_blank">项目支持</a>
        <a href="Report/Report.txt">报告导出</a>
        <a href="#top">回到顶部</a>
    </div>
</body>
</html>

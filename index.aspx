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
        <a><h1 class="myHeader">区域安全警报与控制系统</h1></a>
        <p class="sub">Regional Security <strong>Alarm and Control System</strong>&nbsp;&copy;</p>
    <hr />
    <!--导航栏-->
    <nav class="navZone">
        <asp:HyperLink CssClass="sub" ID="HyperLink_Home" runat="server" Font-Bold="True" NavigateUrl="~/index.aspx" Width="50px">主页</asp:HyperLink>
        <asp:HyperLink CssClass="sub" ID="HyperLink_ERRORS" runat="server" NavigateUrl="~/BugInfo.aspx" Width="100px">错误信息</asp:HyperLink>
        <asp:HyperLink CssClass="sub" ID="HyperLink_Partition" runat="server" NavigateUrl="~/PartitionInfo.aspx" Width="100px">分区信息</asp:HyperLink>
        <asp:HyperLink CssClass="sub" ID="HyperLink_Detector" runat="server" NavigateUrl="~/DetectorInfo.aspx" Width="125px">探测器信息</asp:HyperLink>
        <asp:HyperLink CssClass="sub" ID="HyperLink_FireExtinguisher" runat="server" NavigateUrl="~/FireExtinguisherInfo.aspx" Width="125px">灭火器信息</asp:HyperLink>
    </nav>
        <asp:Button CssClass="buttonSharp" ID="Button_Start" runat="server" Text="开始监视" Font-Size="Small" style="font-weight: 700" OnClick="Button_Start_Click" />
        <asp:Button CssClass="buttonSharp" ID="Button_Stop" runat="server" Text="停止监视" style="font-weight: 700" OnClick="Button_Stop_Click" />
        <br />
    <asp:Label ID="Label_Sta" runat="server" Text="Label" OnDataBinding="Button_Start_Click"></asp:Label>
        <br />
    <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceSysInfo" ForeColor="#333333" Width="889px" CssClass="table_bk" EmptyDataText="尚未收取到任何数据，可能的原因：数据库内没有数据，请稍后点击“刷新”按钮查询">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="warningCount" HeaderText="警报数量" SortExpression="warningCount">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="bugCount" HeaderText="错误数量" SortExpression="bugCount">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="detectorCount" HeaderText="探测器计数" SortExpression="detectorCount">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceSysInfo" runat="server" ConnectionString="<%$ ConnectionStrings:MySerConnectionString %>" SelectCommand="SELECT * FROM [SysInfo]"></asp:SqlDataSource>
<div>
    <hr />
    <a href="error_access.aspx">项目支持</a>
    <a href="Report/Report.txt">报告导出</a>
    <a href="#">回到顶部</a>
</div>
</form>
</body>
</html>

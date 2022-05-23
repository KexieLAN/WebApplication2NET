<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FireExtinguisherInfo.aspx.cs" Inherits="WebApplication2NET.FireExtinguisherInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
<p class="sub">Regional Security <strong>Alarm and Control System</strong>&nbsp;&copy;<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </p>
<hr />
<!--导航栏-->
<nav class="navZone">
    <asp:HyperLink CssClass="sub" ID="HyperLink_Home" runat="server"  NavigateUrl="~/index.aspx" Width="50px">主页</asp:HyperLink>
    <asp:HyperLink CssClass="sub" ID="HyperLink_ERRORS" runat="server" NavigateUrl="~/BugInfo.aspx" Width="100px">错误信息</asp:HyperLink>
    <asp:HyperLink CssClass="sub" ID="HyperLink_Partition" runat="server" NavigateUrl="~/PartitionInfo.aspx" Width="100px">分区信息</asp:HyperLink>
    <asp:HyperLink CssClass="sub" ID="HyperLink_Detector" runat="server" NavigateUrl="~/DetectorInfo.aspx" Width="125px">探测器信息</asp:HyperLink>
    <asp:HyperLink CssClass="sub" ID="HyperLink_FireExtinguisher" runat="server" Font-Bold="True" NavigateUrl="~/FireExtinguisherInfo.aspx" Width="125px">灭火器信息</asp:HyperLink>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">登出</asp:LinkButton>
</nav>
    <asp:Label ID="Label1" runat="server" Text="灭火器信息" BackColor="White" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceBugInfo" ForeColor="#333333" CssClass="table_bk" EmptyDataText="尚未收取到任何数据，可能的原因：数据库内没有数据，请点击“刷新”按钮查询或等待自动更新" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="sharpNumber" HeaderText="sharpNumber" SortExpression="sharpNumber">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <PagerTemplate>
                                    当前第:
                                     <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                                    <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                    页/共:
                                    <%--//得到分页页面的总数--%>
                                    <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    页
                                    <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                        Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                        CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                                    <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                                    转到第
                                    <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                                    <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                        CommandName="Page" Text="GO" />
                                </PagerTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceBugInfo" runat="server" ConnectionString="<%$ ConnectionStrings:MySerConnectionString %>" SelectCommand="SELECT * FROM [FireExtinguisherInfo]"></asp:SqlDataSource>
             <asp:Timer ID="TimerfeInfo" runat="server" Interval="6000">
             </asp:Timer>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="TimerfeInfo" EventName="Tick" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowUpdated" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCreated" />
        </Triggers>
    </asp:UpdatePanel>
   
    <hr />
    <asp:Button ID="ButtonCleanInfo" runat="server" Text="清空灭火器信息" OnClick="ButtonCleanInfo_Click" CssClass="buttonSharp" />
    <asp:Button ID="ButtonF" runat="server" CssClass="buttonSharp" OnClick="ButtonF_Click" Text="刷新" />
    <hr />
    <asp:Label ID="Label2" runat="server" Text="历史灭火器信息" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceBugInfoHis" ForeColor="#333333" CssClass="table_bk" EmptyDataText="尚未收取到任何数据，可能的原因：数据库内没有数据，请点击“刷新”按钮查询或等待自动更新" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="sharpNumber" HeaderText="sharpNumber" SortExpression="sharpNumber" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
        <PagerTemplate>
                                    当前第:
                                     <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                                    <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                    页/共:
                                    <%--//得到分页页面的总数--%>
                                    <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    页
                                    <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                        Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                        CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                                    <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                                    转到第
                                    <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                                    <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                        CommandName="Page" Text="GO" />
                                </PagerTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceBugInfoHis" runat="server" ConnectionString="<%$ ConnectionStrings:MySerConnectionString %>" SelectCommand="SELECT * FROM [FireExtinguisherInfo_History]"></asp:SqlDataSource>
            <asp:Timer ID="TimerfeInfoHis" runat="server" Interval="6000">
            </asp:Timer>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="TimerfeInfoHis" EventName="Tick" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowUpdated" />
            <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="RowCreated" />
        </Triggers>
    </asp:UpdatePanel>
    
    <hr />
    <asp:Button ID="ButtonClearHis" runat="server" OnClick="ButtonClearHis_Click" Text="清空历史灭火器信息" CssClass="buttonSharp" />
    <asp:Button ID="ButtonF2" runat="server" OnClick="ButtonF2_Click" Text="刷新" CssClass="buttonSharp" />
    <div>
        <hr />
        <a href="error_access.aspx">项目支持</a>
        <a href="Report/Report.txt">报告导出</a>
        <a href="#">回到顶部</a>
    </div>
    </form>
</body>
</html>

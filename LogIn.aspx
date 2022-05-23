<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication2NET.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="./CSS/goove1.css" rel="stylesheet"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>C#课程设计程序</title>
    <meta name="description" content="先导程序，正处于测试阶段"/>
    <style type="text/css">
        #form1 {
            font-family: MiSans; 
        }
        .auto-style1 {
            height: 84px;
        }
        .auto-style2 {
            height: 53px;
        }
        .auto-style3 {
            width: 861px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
<a><h1 class="myHeader">区域安全警报与控制系统</h1></a>
<p class="sub">Regional Security <strong>Alarm and Control System</strong>&nbsp;&copy;</p>
<hr />
    <div align="center">
        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="385px" OnAuthenticate="Login1_Authenticate" Width="853px" CssClass="login" >
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LayoutTemplate>
            <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td class="auto-style3">
                        <table cellpadding="0" style="height:385px;width:853px;">
                            <tr>
                                <td align="center" class="auto-style2" colspan="2" style="color:White;background-color:#507CD1;font-size:0.9em;font-weight:bold;">登录</td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="X-Large">用户名:</asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em" Height="25px" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="X-Large">密码:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" Height="25px" TextMode="Password" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Font-Size="Large" Text="下次记住我。" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" Font-Size="Medium" ForeColor="#284E98" Text="登录" ValidationGroup="Login1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
    </div>
</form>
</body>
</html>

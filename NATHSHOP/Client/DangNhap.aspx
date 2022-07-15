<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="NATHSHOP.Client.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .dd{
            color:red;
            text-decoration:none;
        }
        .auto-style1 {
            width: 503px;
        }
    </style>
    <div class="dangnhap">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table>
                    <caption>
                        <h1 style="text-align:center; width: 601px; color:red;">Đăng Nhập</h1>
                        <br />
                        <tr>
                            <td>
                                <p>
                                    Tên đăng nhập</p>
                            </td>
                            <td style="width: 500px">
                                <asp:TextBox ID="txtTendangnhap" runat="server" Height="27px" Width="310px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    Mật khẩu</p>
                            </td>
                            <td style="width: 500px">
                                <asp:TextBox ID="txtMatkhau" runat="server" Height="25px" TextMode="Password" Width="311px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="float:right;">
                                <asp:Button ID="bttDN" runat="server" Height="41px" OnClick="bttDN_Click" Font-Size="Large" Text="Đăng Nhập " Width="161px" />
                            </td>
                            <td style="width: 500px; text-align:center;">
                                <asp:HyperLink ID="hplQuenmatkhau" runat="server" CssClass="dd" NavigateUrl="QuenMatKhau.aspx">Quên mật khẩu ?</asp:HyperLink>
                                <br />
                                <asp:HyperLink ID="hplDangki" runat="server" CssClass="dd" NavigateUrl="DangKi.aspx">Chưa có tài khoản ?</asp:HyperLink>
                            </td>
                        </tr>
                    </caption>
                </table>
                <div id="dn_message">
                   <asp:Label ID="lblThongbao" runat="server" CssClass="login_message"></asp:Label><br />
                    <asp:RequiredFieldValidator ID="rfv3" runat="server"
                        ErrorMessage="Vui lòng nhập tên đăng nhập"
                        ControlToValidate="txtTendangnhap" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="rfv4" runat="server"
                        ErrorMessage="Vui lòng nhập mật khẩu" ControlToValidate="txtMatkhau"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

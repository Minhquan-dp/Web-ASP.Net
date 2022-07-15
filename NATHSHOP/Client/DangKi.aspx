<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DangKi.aspx.cs" Inherits="NATHSHOP.Client.DangKi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />

        <div class="dangky" style="margin-left: 200px;">

            <h3 class="box-color-2-title" style="float: inherit; color:#031583;"><span">Đăng Kí Thành Viên</span></h3>
            <h2 style="width: 597px; text-align:center; color:Red;">Thông Tin Đăng Kí Thành Viên</h2>
            <br />

            <div class="content">
                <table class="style1" style="margin: 20px auto;">
                    <tr>

                        <td class="style2">
                            <asp:Label ID="lblTendangnhap" runat="server" Text="Tên đăng nhập"
                                ForeColor="black"></asp:Label>
                            &nbsp;</td>
                        <td class="style3">
                            <asp:TextBox ID="txtTendangnhap" runat="server" Height="26px" Width="161px"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvTendangnhap" runat="server"
                                ErrorMessage="Chưa nhập tên đăng nhập" ControlToValidate="txtTendangnhap"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblUsername" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblMatkhau" runat="server" Text="Mật khẩu" ForeColor="black"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtMatkhau" runat="server" Height="26px" Width="161px"
                                TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvMatkhau" runat="server"
                                ErrorMessage="Chưa nhập mật khẩu" ControlToValidate="txtMatkhau"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblNhaplaimatkhau" runat="server" Text="Nhập lại mật khẩu"
                                ForeColor="black"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtNLMatkhau" runat="server" Height="26px" Width="161px"
                                TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvNLMatkhau" runat="server"
                                ErrorMessage="Chưa nhập mật khẩu lần 2" ControlToValidate="txtNLMatkhau"
                                ForeColor="Red"></asp:RequiredFieldValidator><br />
                            <asp:CompareValidator ID="cvMatkhau" runat="server"
                                ErrorMessage="Mật khẩu không khớp" ControlToCompare="txtMatkhau"
                                ControlToValidate="txtNLMatkhau" ForeColor="Red"></asp:CompareValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label4" runat="server" Text="Họ tên" ForeColor="black"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtHoten" runat="server" Height="26px" Width="161px"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvHoten" runat="server"
                                ErrorMessage="Chưa nhập họ tên" ControlToValidate="txtHoten"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label5" runat="server" Text="Giới tính" ForeColor="black"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:RadioButtonList ID="rblGioitinh" runat="server" ForeColor="black">
                                <asp:ListItem>Nam</asp:ListItem>
                                <asp:ListItem>Nữ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvGioitinh" runat="server"
                                ErrorMessage="Chưa chọn giới tính" ControlToValidate="rblGioitinh"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label6" runat="server" Text="Địa chỉ" ForeColor="black"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtDiachi" runat="server" Height="26px" Width="161px"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RequiredFieldValidator ID="rfvDiachi" runat="server"
                                ErrorMessage="Chưa nhập địa chỉ" ControlToValidate="txtDiachi"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label7" runat="server" Text="Email" ForeColor="black"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtEmail" runat="server" Height="26px" Width="161px"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:RegularExpressionValidator ID="rexEmail" runat="server"
                                ErrorMessage="Nhập sai email"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" ForeColor="Red"></asp:RegularExpressionValidator>
                            &nbsp;<br />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="Chưa nhập email"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblEmail" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblDienthoai" runat="server" Text="Số điện thoại" ForeColor="black"></asp:Label></td>
                        <td class="style3">
                            <asp:TextBox ID="txtDienthoai" runat="server" Height="26px" Width="161px"
                                TabIndex="1" ForeColor="#663300"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:CompareValidator ID="cvSodienthoai" runat="server"
                                ControlToValidate="txtDienthoai" ErrorMessage="Chỉ nhập số"
                                ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvSodienthoai" runat="server"
                                ControlToValidate="txtDienthoai" ErrorMessage="Chưa nhập số điện thoại"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2" colspan="2" style="text-align:center;">
                            <br />
                            <asp:Button ID="btnXacnhan" runat="server" Text="Xác nhận" ForeColor="Black"
                                Height="35px" Width="102px" CssClass="dangky" OnClick="btnXacnhan_Click" />
                            &nbsp;     
                <br />
                        </td>
                        <td class="style4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" colspan="3" align="center">
                            <asp:Label ID="lblThongBao" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>


        </div>

    <br class="clear" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

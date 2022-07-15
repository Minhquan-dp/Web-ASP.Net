<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="NATHSHOP.Client.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />

    <h3 class="box-color-1-title"><span>Chi tiết sản phẩm</span></h3>

    <div class="box-color-1-text">

        <div class="product-info">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 302px; margin-right: 10px;" rowspan="7">&nbsp;
                        &nbsp;
                        <img alt="" src="<%#Eval("HinhAnh") %>"
                            style="width: 319px; height: 320px;" /></td>

                        </tr>
                        <br />
                        <tr>
                            <td style="width: 130px;">

                                <span style="color: #663300; font:bold;"> <strong> Sản Phẩm:</strong> </span>
                            </td>
                            <td>
                                <span style="color: #00CC00"><strong
                                    style="font-size: medium"><%#Eval("TenSanPham") %></strong></span>
                        </tr>
                        <tr>
                            <td style="width: 130px; color: #663300; font:bold;"><strong>Loại sản phẩm:</strong> </td>
                            <td>
                                <span style="color: #00CC00;"><strong><%#Eval("TenLoai") %>
                                </strong></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="Label1" runat="server" Text="Size :" ForeColor="#663300" Height="30px" Font-Bold="True"></asp:Label>

                            </td>
                            <td>
                                <span style="color: #00CC00"><strong><%#Eval("Size") %>
                                </strong></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                <span style="color: #663300"><strong>Xuất Xứ: </strong></span>
                            </td>
                            <td>
                                <span style="color: #00CC00"><strong><%#Eval("ThongTin") %>
                                </strong></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                <span style="color: #663300; font:bold;"><strong>Giá Bán: </strong></span>
                            </td>
                            <td>
                                <span style="color: #FF0000"><strong><%#Eval("GiaBan") %>  VND
                                </strong></span>
                            </td>
                        </tr>

                    </table>

                </ItemTemplate>
            </asp:Repeater>
            <table>
                <tr>
                    <td style="width: 316px">&nbsp;</td>
                    <td>
                        <asp:ImageButton ID="ibtnmua" ImageUrl="Images/shoppingcart.png" runat="server"/>
                    </td>
                </tr>
            </table>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

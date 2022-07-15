<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="NATHSHOP.Client.SanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <style type="text/css">

        .dtl {
            text-align: center;
            color: blue;

        }

        a {
            color: #72ae13;
            text-decoration: none;
            text-align: center;
            cursor: pointer;
        }
    </style>
    <div>
        <table style="width: 1122px">
            <asp:DataList ID="dtlSanPham" DataKeyField="MASP" runat="server" RepeatColumns="4" CssClass="dtl" OnSelectedIndexChanged="dtlSanPham_SelectedIndexChanged" Width="100%">
                <ItemTemplate>
                    <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=chitiet&id={0}") %>">
                        <asp:Image ID="Image1" runat="server" Height="217px" Width="206px" ImageUrl='<%# Eval("HinhAnh") %>' /> </a>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSanPham") %>'></asp:Label>
                        <br />
                        Size: &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("Size") %>'> </asp:Label>
                        <br />
                        Giá:&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
                        <br />
                        <a href='<%#Eval("MaSP","ChiTietSanPham.aspx?action=add&id={0}")%>'>Đặt Mua</a>
                        &nbsp;&nbsp;
                    <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=chitiet&id={0}") %>">Chi Tiết ...</a>
                        <br />
                        <br />
                </ItemTemplate>
            </asp:DataList>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

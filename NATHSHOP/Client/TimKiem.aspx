<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="NATHSHOP.Client.TimKiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <asp:DataList runat="server" DataKeyField="MaSP" DataSourceID="SqlDataSource1" CssClass="dtl" RepeatColumns="5" Width="1203px">
        <ItemTemplate>

            <asp:Image runat="server" ImageUrl='<%#Eval("HinhAnh") %>' Width="215" Height="205" />
            <br />
          <asp:Label ID="TenSanPhamLabel" runat="server" Text='<%# Eval("TenSanPham") %>' />
            <br />
            Size:<asp:Label ID="Label1" runat="server" Text='<%# Eval("Size") %>' />
            <br />
            GiaBan:
          <asp:Label ID="GiaBanLabel" runat="server" Text='<%# Eval("GiaBan") %>' />
            <br />
            <a href='<%#Eval("MaSP","ChiTietSanPham.aspx?action=add&id={0}")%>'>Đặt Mua</a>
            &nbsp;&nbsp;
                    <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=chitiet&id={0}") %>">Chi Tiết ...</a>
            <br />
            <br />
            <br />
            <br />

        </ItemTemplate>

    </asp:DataList>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SPORTDATAConnectionString %>" SelectCommand="SELECT MaSP, TenSanPham, HinhAnh, GiaBan, Size FROM SanPham WHERE (TenSanPham LIKE '%' + @Param1 + '%')">
        <SelectParameters>
            <asp:QueryStringParameter Name="Param1" QueryStringField="TenSanPham" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

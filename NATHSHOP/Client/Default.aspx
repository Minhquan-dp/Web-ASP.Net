<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NATHSHOP.Client.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Slider">
        <div id="wrap-slider">
            <div id="slider">
                <img class="slide-box" src="Images/1.jpg" />
                <img class="slide-box" src="Images/2.jpg" />
                <img class="slide-box" src="Images/3.jpg" />
                <img class="slide-box" src="Images/4.jpg" />
            </div>
        </div>
        <span id="prev-slide">Previous</span><span id="next-slide">Next</span>
    </div>
    <br />
    <br />
    <div class="danhmuc">
        <div class="adidas">
            <a href="SanPham.aspx?url=Adidas">
                <img src="Images/adidas1.jpg" style="height: 223px; width: 381px;" />
            </a>
        </div>
        <div class="nike">
            <a href="SanPham.aspx?url=Nike">
                <img src="Images/nike.png" style="height: 227px; width: 311px;" />
            </a>
        </div>
        <div class="jordan">
            <a href="SanPham.aspx?url=Jordan">
                <img src="Images/jodan.png" style="height: auto; width: 400px;" />
            </a>
        </div>
    </div>

    <br />
    <br />
    <asp:DataList ID="dtlSanPham3" DataKeyField="MASP" runat="server" CssClass="dtl3" RepeatColumns="4" OnSelectedIndexChanged="dtlSanPham3_SelectedIndexChanged" Width="100%" Height="653px">
        <ItemTemplate>
            <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=chitiet&id={0}") %>">
            <asp:Image ID="Image1" runat="server" Height="217px" Width="206px" ImageUrl='<%# Eval("HinhAnh") %>' /> </a>
            <br />
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSanPham") %>'></asp:Label>
            <br />
            Size: &nbsp;
                <asp:Label ID="Label3" runat="server" Text=' <%# Eval("Size") %>'></asp:Label>
            <br />

            <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaBan") %>'></asp:Label>
            <br />
            <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=add&id={0}") %>">Đặt Mua</a>
            &nbsp;&nbsp;
            <a href="<%#Eval("MaSP", "ChiTietSanPham.aspx?action=chitiet&id={0}") %>">Chi Tiết ...</a>

        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" />
    </asp:DataList>
   <style>
       .dtl3{
           color: blue;
            text-align: center;
       }
        a {
            color: #72ae13;
            text-decoration: none;
            text-align: center;
            cursor: pointer;
        }
   </style>
</asp:Content>

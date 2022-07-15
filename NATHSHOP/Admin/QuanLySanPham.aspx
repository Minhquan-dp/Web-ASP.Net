<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QuanLySanPham.aspx.cs" Inherits="NATHSHOP.Admin.QuanLySan_Pham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 52%;
        }

        .style2 {
            width: 142px;
        }

        .style3 {
            width: 134px;
        }

        .style5 {
            width: 205px;
        }

        .style6 {
            width: 191px;
        }

        .auto-style1 {
            width: 142px;
            height: 26px;
        }

        .auto-style2 {
            width: 134px;
            height: 26px;
        }

        .auto-style3 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 10px;">


                <h2>Bộ lọc</h2>
                <table class="style1">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Loại sản phẩm "></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:DropDownList
                                ID="ddlLoaiSP" runat="server" Height="35px" Width="110px">
                                <asp:ListItem Value="1" Selected="True">Adidas</asp:ListItem>
                                <asp:ListItem Value="2">Nike</asp:ListItem>
                                <asp:ListItem Value="3">Jordan</asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td class="auto-style3"></td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="btnDuyet" runat="server" OnClick="btnDuyet_Click" Text="Duyệt"
                                Width="94px" Style="height: 26px" />
                        </td>
                        <td class="style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>

            <div style="padding: 30px;">
                <asp:GridView ID="gvDSSP" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None"
                    Width="946px" DataKeyNames="MASP" OnRowDeleting="gvDSSP_RowDeleting"
                    OnRowCommand="gvDSSP_RowCommand">
                    <AlternatingRowStyle BackColor="White" />

                    <Columns>
                        <asp:BoundField DataField="MaSP" HeaderText="MASP" ReadOnly="True" SortExpression="MASP" />
                        <asp:BoundField DataField="TenLoai" HeaderText="Ten Loai Hang" SortExpression="TenSanPham" />
                        <asp:BoundField DataField="TenSanPham" HeaderText="Ten San Pham" SortExpression="TenSanPham" />
                        <asp:BoundField DataField="GiaMua" HeaderText="Gia Mua" SortExpression="GiaMua" />
                        <asp:BoundField DataField="GiaBan" HeaderText="Gia Ban" SortExpression="GiaBan" />
                        <asp:BoundField DataField="NgayNhapHang" HeaderText="Ngay Nhap Hang" SortExpression="NgayNhapHang" />
                        <asp:BoundField DataField="Size" HeaderText="Kich Thuoc" SortExpression="KichThuoc" />
                        <asp:BoundField DataField="Soluong" HeaderText="Soluong" SortExpression="So luong" />
                        <asp:BoundField DataField="ThongTin" HeaderText="Thong Tin" SortExpression="Thong Tin" />
                        <asp:BoundField DataField="hinhAnh" HeaderText="Link Hinh Anh" SortExpression="Link Hinh Anh" />
                        <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
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

            </div>
            <div style="padding: 10px;">
                <table>
                    <tr>
                        <td colspan="4">
                            <h1>
                                <asp:Label ID="Label2" runat="server" Text="Thêm sản phẩm"></asp:Label></h1>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMaSP" runat="server" Text="Mã sản phẩm"></asp:Label>
                        </td>

                        <td class="style6">
                            <asp:TextBox ID="txtMaSP" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="txtMaSP" ErrorMessage="Chưa nhập mã sản phẩm"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator><br />
                            <asp:Label ID="lblMaSP1" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTenSP" runat="server" Text="Tên sản phẩm"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtTenSP" runat="server" Width="180px"></asp:TextBox>

                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtTenSP" ErrorMessage="Chưa nhập tên sản phẩm"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblGiaMua" runat="server" Text="Giá mua"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtGiaMua" runat="server" Width="180px"></asp:TextBox>
                        </td>

                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtGiaMua" ErrorMessage="Chưa nhập giá mua"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Giá bán"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtGiaBan" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="txtGiaBan" ErrorMessage="Chưa nhập giá bán"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:DropDownList ID="ddlSize" runat="server">
                                <asp:ListItem Value="0">38</asp:ListItem>
                                <asp:ListItem Value="1">39</asp:ListItem>
                                <asp:ListItem Value="2">40</asp:ListItem>
                                <asp:ListItem Value="3">41</asp:ListItem>
                                <asp:ListItem Value="4">42</asp:ListItem>
                            </asp:DropDownList></td>
                        <td></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Số lượng"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtSoluong" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvSoLuong" runat="server"
                                ErrorMessage="Chưa nhập số lượng" ControlToValidate="txtSoluong"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLoaiSP" runat="server" Text="Loại sản phẩm"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:DropDownList
                                ID="ddlLoai" runat="server" Height="35px" Width="185px">
                                <asp:ListItem Value="0">Addidas</asp:ListItem>
                                <asp:ListItem Value="1">Nike</asp:ListItem>
                                <asp:ListItem Value="2">Jordan</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td>&nbsp;</td>
                        <td class="style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblThongTin" runat="server" Text="Thông tin"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtThongTin" runat="server" TextMode="MultiLine" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtThongTin" ErrorMessage="Chưa nhập thông tin"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                        <td class="style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNgayNhap" runat="server" Text="Ngày nhập hàng"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtNgayNhap" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtNgayNhap" ErrorMessage="Chưa nhập ngày nhập hàng"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblHinhAnh" runat="server" Text="Link hình ảnh"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:TextBox ID="txtHinhAnh" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtHinhAnh" ErrorMessage="Chưa nhập link hình ảnh"
                                ValidationGroup="CapNhat"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnThemSP" runat="server" Text="Thêm"
                                OnClick="btnThemSP_Click" ValidationGroup="CapNhat" Height="31px"
                                Width="75px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <h2>
                                <asp:Label ID="lblThongBao" runat="server" Text="" ForeColor="Red"></asp:Label></h2>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

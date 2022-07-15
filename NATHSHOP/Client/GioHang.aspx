<%@ Page Title="" Language="C#" MasterPageFile="~/Client/GiaoDien.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="NATHSHOP.Client.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <br />
    <asp:GridView ID="gvGioHang" runat="server" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="MaSP" GridLines="None"
        OnRowCancelingEdit="gvGioHang_RowCancelingEdit"
        OnRowEditing="gvGioHang_RowEditing" OnRowUpdating="gvGioHang_RowUpdating"
        OnRowDeleting="gvGioHang_RowDeleting" Width="1200px"
        EditRowStyle-Height="200px" RowStyle-Height="50px" ForeColor="#333333" OnSelectedIndexChanged="gvGioHang_SelectedIndexChanged">

        <AlternatingRowStyle BackColor="White" />

        <Columns>
            <asp:BoundField HeaderText="Mã SP" DataField="MaSP" ReadOnly="true"
                ItemStyle-HorizontalAlign="Center">

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:TemplateField HeaderText="Tên SP" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <p style="color: #332221; font-weight: bold;"><%# Eval("TenSanPham") %></p>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Sản Phẩm" ItemStyle-HorizontalAlign="Center"> 
                <ItemTemplate>
                    <p style="color: #332221;height:170px; width:170px;font-weight: bold;"><img alt="" src="<%#Eval("HinhAnh") %>"
                            style="width: 204px; height: 180px;" /></p> 
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Kích cỡ" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <p style="color: #332221; font-weight: bold;"><%# Eval("Size") %></p>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Số lượng" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <p style="color: #332221; font-weight: bold;"><%# Eval("SoLuong") %></p>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSL" runat="server" Text='<%# Eval("SoLuong") %>' Width="50px" />
                </EditItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Giá bán" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <p style="color: #332221; font-weight: bold;"><%# Eval("GiaBan") %></p>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cập nhật" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnCapNhat" runat="server" CommandName="Edit">Cập nhật</asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="lbtnOK" runat="server" CommandName="Update">Xác nhận</asp:LinkButton>
                    <asp:LinkButton ID="lbtnHuy" runat="server" CommandName="Cancel">Hủy</asp:LinkButton>
                </EditItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Xóa ?" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span onclick="return confirm('Bạn có chắc chắn muốn xóa không ?')">
                        <asp:LinkButton ID="lbtnXoa" runat="server" CommandName="Delete">Xóa</asp:LinkButton>
                    </span>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>

        <EditRowStyle Height="100px" BackColor="#39C9C4"></EditRowStyle>

        <FooterStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center"
            Font-Bold="True" />
        <HeaderStyle BackColor="#311F1F" Font-Bold="True" ForeColor="White"
            HorizontalAlign="Center" Height="20px" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="Aqua" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
        <table style="margin-top: 10px; border-style: none; width: 811px;">
            <tr>
                <td style="padding-left: 30px"><asp:Button ID="btnmuatiep" runat="server" Text="Mua Tiếp" CssClass="mybutton1" OnClick="btnmuatiep_Click" Height="40px" Width="108px" /> </td>
                <td style="padding-left: 30px">
                    <asp:Button ID="btnDatHang" runat="server" Text="Đặt hàng" CssClass="mybutton1" OnClick="btnDatHang_Click" Height="40px" Width="106px" />
                </td>
                <td style="padding-left: 30px">
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa Giỏ Hàng" CssClass="mybutton1" OnClick="btnXoa_Click" Height="37px" Width="136px" />
                </td>
                <td style="float:right; width: auto; background-color:#4cff00; font-size:xx-large"><asp:Label ID="lblTongCong" runat="server" Text="" CssClass="lblTongTien" ></asp:Label></td>
            </tr>
        </table>
            <br />
            <br />
</asp:Content>
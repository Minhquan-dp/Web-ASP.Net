<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QuanLyUser.aspx.cs" Inherits="NATHSHOP.Admin.QuanLyUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1024px;">
        <div style="padding: 30px;">

            <asp:GridView ID="gvAdmin" runat="server" CellPadding="4"
                ForeColor="#333333" GridLines="None" Height="109px" Width="884px"
                AutoGenerateColumns="False"
                OnRowCancelingEdit="gvAdmin_RowCancelingEdit"
                OnRowEditing="gvAdmin_RowEditing" DataKeyNames="MaAdmin"
                OnRowUpdating="gvAdmin_RowUpdating"
                OnRowDeleting="gvAdmin_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="MaAdmin" DataField="MaAdmin" ReadOnly="true"
                        ItemStyle-HorizontalAlign="Center" SortExpression="MaAdmin"></asp:BoundField>

                    <asp:TemplateField HeaderText="Họ tên" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("TenAdmin") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtHoTen" runat="server" Text='<%# Eval("TenAdmin") %>' Width="100px" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="TenDangNhap" SortExpression="TenDangNhap">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("TenDangNhap") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTenDangNhap" runat="server" Text='<%# Eval("TenDangNhap") %>' Width="100px" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mật khẩu" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("MatKhau") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMatKhau" runat="server" Text='<%# Eval("MatKhau") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Địa chỉ" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("DiaChi") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDiaChi" runat="server" Text='<%# Eval("DiaChi") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Là Admin" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("TrangThai").ToString().Equals("True")? "Da Duyet" : "Dang Cho" %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlIsAdmin" runat="server">
                                <asp:ListItem Text="Da Duyet" Value="True" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Dang Cho" Value="False"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>

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
                <EditRowStyle BackColor="Aqua" />
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
    </div>
</asp:Content>

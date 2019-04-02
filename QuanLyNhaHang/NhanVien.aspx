<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="QuanLyNhaHang.NhanVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            width: 360px;
        }
        .style3
        {
            width: 360px;
        }
        .style4
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: 700; text-align: center">
                <h2>
                    <asp:Label ID="lblTieuDe" runat="server" Text="Quản Lý Nhân Viên"></asp:Label>
                </h2>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Mã NV:</td>
            <td>
                <asp:TextBox ID="txtMaNV" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tài Khoản:</td>
            <td>
                <asp:TextBox ID="txtUser" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Mật Khẩu:</td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Họ Và Tên:</td>
            <td>
                <asp:TextBox ID="txtHoTen" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Ngày Sinh:</td>
            <td>
                Ngày
                <asp:DropDownList ID="ddlNgay" runat="server">
                </asp:DropDownList>
&nbsp;Tháng&nbsp;
                <asp:DropDownList ID="ddlThang" runat="server" 
                    onselectedindexchanged="ddlThang_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;Năm&nbsp;
                <asp:DropDownList ID="ddlNam" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Giới Tính:</td>
            <td>
                &nbsp;
                <asp:RadioButtonList ID="rbGioiTinh" runat="server">
                    <asp:ListItem>Nam</asp:ListItem>
                    <asp:ListItem>Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Địa Chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                SĐT:</td>
            <td>
                <asp:TextBox ID="txtSDT" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" 
                    Text="Thêm" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnHuy" runat="server" Text="Hủy" onclick="btnHuy_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblTBLoi" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style4" colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td class="style4" colspan="2">
&nbsp;<asp:TextBox ID="txtTimKiem" runat="server" Width="150px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnTim" runat="server" Text="Tìm Kiếm" onclick="btnTim_Click" />
        </td>
    </tr>
    <tr>
        <td class="style4" colspan="2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                HorizontalAlign="Center" onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Mã NV" DataField="MaNV" />
                    <asp:BoundField HeaderText="Tài Khoản" DataField="UserName" />
                    <asp:BoundField HeaderText="Họ Tên" DataField="HoTen" />
                    <asp:BoundField HeaderText="Ngày Sinh" DataField="NgaySinh" 
                        DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Giới Tính" DataField="GioiTinh" />
                    <asp:BoundField HeaderText="Địa Chỉ" DataField="DiaChi" />
                    <asp:BoundField HeaderText="Số Điện Thoại" DataField="SDT" />
<%--                    <asp:ButtonField HeaderText="Xóa" Text="Xóa" />
                    <asp:ButtonField HeaderText="Cập nhật" Text="Cập Nhật" />--%>
                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:LinkButton ID="b" runat="server" CommandName="sua" Text="Sửa"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xoá">
                        <ItemTemplate>
                            <asp:LinkButton ID="c" runat="server" CommandName="xoa" onClientClick="javascript:return confirm('Bạn có chắc muốn xoá không?');" Text="Xoá">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    </table>
</asp:Content>

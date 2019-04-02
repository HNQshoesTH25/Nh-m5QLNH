<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="QuanLyNhaHang.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 45%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <h2>
                    <strong>Đăng Nhập Hệ Thống&nbsp;</strong></h2>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                Nếu chưa có tài khoản
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/DangKy.aspx">Đăng ký</asp:HyperLink>
&nbsp;tại đây</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="style2">
                <asp:Label ID="Label1" runat="server" Text="Tài Khoản:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="style2">
                <asp:Label ID="Label2" runat="server" Text="Mật Khẩu:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:CheckBox ID="cbNhoMK" runat="server" Text="Nhớ mật khẩu" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDangNhap" runat="server" Text="Đăng Nhập" 
                    onclick="btnDangNhap_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblTBLoi" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/payroll/payrollMasterPage.Master" AutoEventWireup="true" CodeBehind="warning.aspx.cs" Inherits="IntegratedHrPayroll.payroll.warning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-header">Manager Employee</div>
    <div class="body-main-content">
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="warning-nav">
                <div class="body-main-search">
                </div>
                <div>
                    <asp:Button ID="Button5" runat="server"  Text="Add" OnClick="AddEmployee" />
                    <asp:Button ID="Button6" runat="server"  Text="Cancel" OnClick="HandleAddEmployee" />
                </div>
            </div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="TB_EmployeeID" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_FirstName" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_MiddleName" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_LastName" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Gender" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Nation" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Birtdate" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Department" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Workingday" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TB_Dayoff" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <div class="warning-nav">
                <div class="body-main-search">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="search-input"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" CssClass="search-btn" Text="Find" OnClick="HandleFindEmployee" />
                    <asp:Button ID="Button1" runat="server" CssClass="reset-btn" Text="Reset" OnClick="HandleResetEmployee" />
                </div>
                <div>
                    <asp:Button ID="Button3" runat="server" CssClass="addannouce-btn" Text="Add Employee" OnClick="HandleAddEmployee" />
                </div>
            </div>
            <div class="warning-table">
                <table class="table-shareholders" border="1px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PERSONAL_ID" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Employee ID" DataField="PERSONAL_ID" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Employee Full Name" DataField="EmployeeName" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Gender" DataField="Gender" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Nation" DataField="Nation" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Birthdate" DataField="Birthdate" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Department" DataField="Department" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Working day" DataField="Workingday" />
                            <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Maximum of Number day off" DataField="MaximumofNumberdayoff" />
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" CancelText="Hủy" DeleteText="Xóa" EditText="Sửa" UpdateText="Cập nhật" />
                        </Columns>
                    </asp:GridView>

                    <asp:Label ID="Label1" runat="server" Text="Data is empty" Visible="false" CssClass="data-not-found"></asp:Label>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
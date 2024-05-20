<%@ Page Title="" Language="C#" MasterPageFile="~/payroll/payrollMasterPage.Master" AutoEventWireup="true" CodeBehind="totalholiday.aspx.cs" Inherits="IntegratedHrPayroll.totalholiday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-header">Number Of Days Off</div>
    <div class="body-main-content">
        <asp:GridView ID="GridView1" runat="server" HeaderStyle-CssClass="colum-header" BorderWidth="1px" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Full Name" DataField="fullname" />
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Gender" DataField="Gender" />
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Nation" DataField="Ethnicity" />
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Department" DataField="Department" />
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Number Of Days Off" DataField="Vacation_Days" />
                <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Maximum Number Of Days Off" DataField="maximumday"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

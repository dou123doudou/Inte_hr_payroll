﻿<%@ Page Title="" Language="C#" MasterPageFile="~/payroll/payrollMasterPage.Master" AutoEventWireup="true" CodeBehind="listempl.aspx.cs" Inherits="IntegratedHrPayroll.payroll.listempl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="body-header">Number Of Employee</div>
                    <div class="body-main-content">
                        <div class="body-main-search">
                        </div>
                    </div>
                        <asp:GridView ID="GridView1" HeaderStyle-CssClass="colum-header" BorderWidth="1px" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns >
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Employee Full Name" DataField="EmployeeName" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Nation" DataField="Nation" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Department" DataField="Department" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Working day" DataField="Workingday" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Maximum of Number day off" DataField="MaximumofNumberdayoff" />
                                    </Columns>
                                </asp:GridView>
                        </table> 
                    </div>
</asp:Content>

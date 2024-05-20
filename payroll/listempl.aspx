<%@ Page Title="" Language="C#" MasterPageFile="~/payroll/payrollMasterPage.Master" AutoEventWireup="true" CodeBehind="listempl.aspx.cs" Inherits="IntegratedHrPayroll.payroll.listempl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="body-header">Number Of Employee</div>
                    <div class="body-main-content">
                        <div class="body-main-search">
                            <input type="text" id="txtSearch" runat="server" class="search-input" placeholder="Employee Name..."/>
                            <button onclick="Search_Click" class="search-btn" runat="server">Find</button>
                        </div>
                    </div>
                        <%--<table class="table-shareholders" border="1px">
                            <tr class="table-shareholders-row">
                                 
                                    <td class="table-shareholders-colum colum-header">Employee Name</td>
                                    <td class="table-shareholders-colum colum-header">Gender</td>  
                                    <td class="table-shareholders-colum colum-header">Nation</td>
                                    <td class="table-shareholders-colum colum-header">Department</td>
                                    <td class="table-shareholders-colum colum-header">Working day</td> 
                                    <td class="table-shareholders-colum colum-header">Maximum Number Of Days Off</td>  --%>     
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
                           <%-- </tr>
                            <tr class="table-shareholders-row">
                                <td class="table-shareholders-colum ">Nhân Viên A</td>
                                <td class="table-shareholders-colum ">Male</td>  
                                <td class="table-shareholders-colum ">Kinh</td>
                                <td class="table-shareholders-colum ">Fulltime</td>
                                <td class="table-shareholders-colum ">IT</td>
                                <td class="table-shareholders-colum ">01/04/2019</td> 
                                <td class="table-shareholders-colum ">10</td>  
                                <td class="table-shareholders-colum ">16</td>           
                        </tr>
                        <tr class="table-shareholders-row">
                            <td class="table-shareholders-colum ">Nhân Viên A</td>
                            <td class="table-shareholders-colum ">Male</td>  
                            <td class="table-shareholders-colum ">Kinh</td>
                            <td class="table-shareholders-colum ">Fulltime</td>
                            <td class="table-shareholders-colum ">IT</td>
                            <td class="table-shareholders-colum ">01/04/2019</td> 
                            <td class="table-shareholders-colum ">10</td>  
                            <td class="table-shareholders-colum ">16</td>           
                    </tr>
                    <tr class="table-shareholders-row">
                        <td class="table-shareholders-colum ">Nhân Viên A</td>
                        <td class="table-shareholders-colum ">Male</td>  
                        <td class="table-shareholders-colum ">Kinh</td>
                        <td class="table-shareholders-colum ">Fulltime</td>
                        <td class="table-shareholders-colum ">IT</td>
                        <td class="table-shareholders-colum ">01/04/2019</td> 
                        <td class="table-shareholders-colum ">10</td>  
                        <td class="table-shareholders-colum ">16</td>           
                </tr>
                <tr class="table-shareholders-row">
                    <td class="table-shareholders-colum ">Nhân Viên A</td>
                    <td class="table-shareholders-colum ">Male</td>  
                    <td class="table-shareholders-colum ">Kinh</td>
                    <td class="table-shareholders-colum ">Fulltime</td>
                    <td class="table-shareholders-colum ">IT</td>
                    <td class="table-shareholders-colum ">01/04/2019</td> 
                    <td class="table-shareholders-colum ">10</td>  
                    <td class="table-shareholders-colum ">16</td>           
            </tr>--%>
                        
                            
                        </table> 
                    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/payroll/payrollMasterPage.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="IntegratedHrPayroll.payroll.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 500px; height: 500px;"><canvas id="myChart" ></canvas></div>
    <script>
        // lấy data trong session ra
        var totalEmployee = '<%= Session["totalEmployee"] %>'.split(',');

        var totalEmployee = JSON.parse('<%= Session["totalEmployee"] %>');
        //console.log(sessionCheck);
        const labels = JSON.parse('<%= Session["labels"] as string %>');
        const data = JSON.parse('<%= Session["data"] as string %>');
        const backgroundColor = JSON.parse('<%= Session["backgroundColor"] as string %>');
        var ctx = document.getElementById('myChart').getContext('2d');
        var chart = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels,
                datasets: [
                    {
                        label: '',
                        data,
                        backgroundColor,
                    }
                ]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>>
        <div class="body-main-dashboard">
                        <div class="dashboard-group">
                            <a href="#" class="dashboard-link dashboard-link1 link-active">Earnings Per Employee</a>
                            <a href="#" class="dashboard-link dashboard-link2">Total income</a>
                        </div>
                        <div class="dashboard-display ">
                            <div class="dashboard-shareholders">
                                <asp:GridView ID="GridView1" HeaderStyle-CssClass="colum-header" BorderWidth="1px" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns >
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Full Name" DataField="fullname" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Nation" DataField="Ethnicity" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Payrate" DataField="payrate" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Paid To Date" DataField="paid_to_date" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Tax Percentage" DataField="tax_percentage" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Pay Amount" DataField="payamount" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" DataField="total_income" HeaderText="Total Income"  />
                                    </Columns>
                                    
                                </asp:GridView>
                                <%--<table class="table-shareholders" border="1px">
                                    <tr class="table-shareholders-row">
                                            <td class="table-shareholders-colum colum-header">Date</td> xoa bang nay
                                            <td class="table-shareholders-colum colum-header">Name of shareholder</td>
                                            <td class="table-shareholders-colum colum-header">Gender</td>  
                                            <td class="table-shareholders-colum colum-header">Nation</td> 
                                            <td class="table-shareholders-colum colum-header">Total income</td>             
                                    </tr>
                                    <tr class="table-shareholders-row">
                                        <td class="table-shareholders-colum ">16/03/2023</td>
                                        <td class="table-shareholders-colum ">Cổ Đông A</td>
                                        <td class="table-shareholders-colum ">Nam</td>  
                                        <td class="table-shareholders-colum ">Kinh</td> 
                                        <td class="table-shareholders-colum ">17,123,000</td>             
                                    </tr>
                                </table>   --%> 
                            </div>
                            <div class="dashboard-employee unable-display">
                                <asp:GridView ID="GridView2" HeaderStyle-CssClass="colum-header" BorderWidth="1px" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <columns >
                                        <asp:boundfield itemstyle-cssclass="table-shareholders-colum" datafield="plan_name" headertext="Plan name"  />
                                        <asp:boundfield itemstyle-cssclass="table-shareholders-colum" datafield="total_income" headertext="Total income"  />
                                    </columns>
                                   <%--<Columns >
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Full Name" DataField="fullname" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Nation" DataField="Ethnicity" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Payrate" DataField="payrate" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Paid To Date" DataField="paid_to_date" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Tax Percentage" DataField="tax_percentage" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" HeaderText="Pay Amount" DataField="payamount" />
                                        <asp:BoundField ItemStyle-CssClass="table-shareholders-colum" DataField="total_income" HeaderText="Total Income"  />
                                    </Columns>--%>
                                </asp:GridView>
                                <%--<table class="table-shareholders" border="1px">
                                    <tr class="table-shareholders-row">
                                            <td class="table-shareholders-colum colum-header">Date</td>
                                            <td class="table-shareholders-colum colum-header">Type of employee</td>
                                            <td class="table-shareholders-colum colum-header">Total income</td>              
                                    </tr>
                                    <tr class="table-shareholders-row">
                                        <td class="table-shareholders-colum">16/03/2023</td>
                                        <td class="table-shareholders-colum">Full-time</td>
                                        <td class="table-shareholders-colum">10,200,210</td>              
                                    </tr>
                                    <tr class="table-shareholders-row">
                                        <td class="table-shareholders-colum">16/03/2023</td>
                                        <td class="table-shareholders-colum">Part-time</td>
                                        <td class="table-shareholders-colum">6,018,700</td>              
                                    </tr>
                                </table> --%>   
                            </div>
                        </div>
                    </div>
    <script type="text/javascript">
        const link1 = document.querySelector('.dashboard-link1');
        const link2 = document.querySelector('.dashboard-link2');
        const shareholdersDiv = document.querySelector('.dashboard-shareholders');
        const employeeDiv = document.querySelector('.dashboard-employee');

        link1.addEventListener('click', function (event) {
            employeeDiv.classList.add('unable-display');
            shareholdersDiv.classList.remove('unable-display');
            link1.classList.add('link-active');
            link2.classList.remove('link-active');

        });

        link2.addEventListener('click', function (event) {
            shareholdersDiv.classList.add('unable-display');
            employeeDiv.classList.remove('unable-display');
            link2.classList.add('link-active');
            link1.classList.remove('link-active');
            console.log('click');
        });
    </script>
</asp:Content>
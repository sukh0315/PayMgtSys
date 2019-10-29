<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayrollPMS.aspx.cs" Inherits="PayMgtSys.PayrollPMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-12 col-lg-8">
                <div class="title-single-box">
                    <h1 class="title-single">Payroll</h1>
                </div>
            </div>
            <div class="col-md-12 col-lg-4">
                <nav aria-label="breadcrumb" class="breadcrumb-box d-flex justify-content-lg-end">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a runat="server" href="~/">Home</a>
                        </li>
                        <li class="breadcrumb-item active" aria-current="page">Payroll
                        </li>
                    </ol>
                </nav>
            </div>
        </div>
  <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputEmployee">Employee <span style="color: red;">*</span></label>
                <asp:DropDownList ID="EmployeeID" AppendDataBoundItems="true" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Employee ------</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" runat="server" ControlToValidate="EmployeeID" ErrorMessage="Please choose department " ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
             <div class="form-group">
                <label for="exampleInputNoOfLeaves">No Of Leaves <span style="color: red;">*</span></label>
                <asp:TextBox ID="NoOfLeaves" class="form-control" runat="server" placeholder="No Of Leaves"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="NoOfLeaves" ErrorMessage="Please enter minimum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
             <div class="form-group">
                <label for="exampleInputGrossSalary">Gross Salary <span style="color: red;">*</span></label>
                <asp:TextBox ID="GrossSalary" class="form-control" runat="server" placeholder="Gross Salary"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ControlToValidate="GrossSalary" ErrorMessage="Please enter minimum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
             <div class="form-group">
                <label for="exampleInputTotalDeduction">Total Deduction <span style="color: red;">*</span></label>
                <asp:TextBox ID="TotalDeduction" class="form-control" runat="server" placeholder="Total Deduction"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Save" runat="server" ControlToValidate="TotalDeduction" ErrorMessage="Please enter minimum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
             <div class="form-group">
                <label for="exampleInputNetPay">Net Pay <span style="color: red;">*</span></label>
                <asp:TextBox ID="NetPay" class="form-control" runat="server" placeholder="Net Pay"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Save" runat="server" ControlToValidate="NetPay" ErrorMessage="Please enter minimum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-primary" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Reset" runat="server" class="btn btn-danger" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
           
                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                    <asp:BoundField DataField="NoOfLeaves" HeaderText="No Of Leaves" />
                    <asp:BoundField DataField="GrossSalary" HeaderText="Gross Salary" />
                    <asp:BoundField DataField="TotalDeduction" HeaderText="Total Deduction" />
                    <asp:BoundField DataField="NetPay" HeaderText="Net Pay" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                              <asp:LinkButton ID="butType" runat="server" class="btn btn-success btn-xs" CommandName="updates" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Edit"></asp:LinkButton>
                            <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
    
</asp:Content>

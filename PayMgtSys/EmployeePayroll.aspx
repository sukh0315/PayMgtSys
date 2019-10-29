<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePayroll.aspx.cs" Inherits="PayMgtSys.EmployeePayroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-12 col-lg-8">
                <div class="title-single-box">
                    <h1 class="title-single">Employee</h1>
                </div>
            </div>
            <div class="col-md-12 col-lg-4">
                <nav aria-label="breadcrumb" class="breadcrumb-box d-flex justify-content-lg-end">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a runat="server" href="~/">Home</a>
                        </li>
                        <li class="breadcrumb-item active" aria-current="page">Employee
                        </li>
                    </ol>
                </nav>
            </div>
        </div>
    <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputPosition">Position <span style="color: red;">*</span></label>
                <asp:DropDownList ID="PositionID" AppendDataBoundItems="true" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Position ------</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" runat="server" ControlToValidate="PositionID" ErrorMessage="Please choose department " ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputName">Name <span style="color: red;">*</span></label>
                <asp:TextBox ID="Name" class="form-control" runat="server" placeholder="Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Save" runat="server" ControlToValidate="Name" ErrorMessage="Please enter name" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputGender">Gender</label>
                <asp:DropDownList ID="GenderList" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Gender ------</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Save" ControlToValidate="GenderList" ErrorMessage="Please enter gender" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputFatherName">Father Name</label>
                <asp:TextBox ID="FatherName" class="form-control" runat="server" placeholder="Father Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Save" ControlToValidate="FatherName" ErrorMessage="Please enter fatherName" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputAddress">Address</label>
                <textarea id="Address" class="form-control" cols="20" rows="2" runat="server" placeholder="Address"></textarea>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Save" ControlToValidate="Address" ErrorMessage="Please enter address" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputPhoneNumber">Phone Number</label>
                <asp:TextBox ID="PhoneNumber" class="form-control" runat="server" placeholder="Phone Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Save" ControlToValidate="PhoneNumber" ErrorMessage="Please enter phone number" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail">Email</label>
                <asp:TextBox ID="Email" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Save" ControlToValidate="Email" ErrorMessage="Please enter email" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputDOBDate">DOB Date</label>
                <asp:TextBox ID="DOBDate" class="form-control DOBDate" runat="server" placeholder="DOB Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Save" ControlToValidate="DOBDate" ErrorMessage="Please select hire date" ForeColor="#993333"></asp:RequiredFieldValidator>
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Name
                           
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("Name") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PositionName" HeaderText="Position" />
                    <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone Number" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB Date" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>

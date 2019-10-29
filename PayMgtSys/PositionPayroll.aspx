<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PositionPayroll.aspx.cs" Inherits="PayMgtSys.PositionPayroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-lg-8">
          <div class="title-single-box">
            <h1 class="title-single">Position</h1>
          </div>
        </div>
        <div class="col-md-12 col-lg-4">
          <nav aria-label="breadcrumb" class="breadcrumb-box d-flex justify-content-lg-end">
            <ol class="breadcrumb">
              <li class="breadcrumb-item">
                <a runat="server" href="~/">Home</a>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
               Position
              </li>
            </ol>
          </nav>
        </div>
      </div>
    <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputName">Position <span style="color: red;">*</span></label>
                <asp:TextBox ID="PositionName" class="form-control" runat="server" placeholder="Position"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPositionName" ValidationGroup="Save" runat="server" ControlToValidate="PositionName" ErrorMessage="Please enter position name" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputDailyRate">Daily Rate <span style="color: red;">*</span></label>
                <asp:TextBox ID="DailyRate" class="form-control" runat="server" placeholder="Daily Rate"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="DailyRate" ErrorMessage="Please enter daily rate" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputMonthlyRate">Monthly Rate <span style="color: red;">*</span></label>
                <asp:TextBox ID="MonthlyRate" class="form-control" runat="server" placeholder="Monthly Rate"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ControlToValidate="MonthlyRate" ErrorMessage="Please enter monthly rate" ForeColor="#993333"></asp:RequiredFieldValidator>
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
                                Position
                           
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("PositionName") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DailyRate" HeaderText="Daily Rate" />
                        <asp:BoundField DataField="MonthlyRate" HeaderText="Monthly Rate" />
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

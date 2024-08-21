<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpPage.aspx.cs" Inherits="EmployeeCrudOperation.EmpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="Container">
    <div class="row">
        <div class="col-md-6">
    <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="EmpName" HeaderText ="EmployeeName" />
            <asp:BoundField DataField="Position" HeaderText="Position" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />
        </Columns>
    </asp:GridView>
        </div>
            <div class="col-md-6">
              EmployeeId:<asp:TextBox ID="txtId" runat="server" OnTextChanged="txtId_TextChanged" ></asp:TextBox><br />
              EmployeeName:<asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox><br />
              Position:<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox><br />
              Salary:<asp:TextBox ID="txtSalary" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Employee" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Employee" OnClick="btnDelete_Click" />
            </div>
       </div>
     </div>

</asp:Content>

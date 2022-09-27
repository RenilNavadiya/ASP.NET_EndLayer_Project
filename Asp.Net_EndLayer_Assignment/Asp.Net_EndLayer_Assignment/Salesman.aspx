<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Salesman.aspx.cs" Inherits="Asp.Net_EndLayer_Assignment.Salesman" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 class="lable">Enter Salesman</h2>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Panel ID="successMessage" runat="server" Visible="false">
                <h2><span class="badge badge-success btn-lg btn-block">Salesman has been added Successfully!! </span></h2>
            </asp:Panel>
            <%--HTML FOR FORM--%>
            <div class="ml-lg-3">
                <div class="form-group row">
                    <label for="salesmanNo" class="col-2 col-form-label ">Salesman Number:</label>
                    <div class="col-sm-5">
                        <asp:TextBox TextMode="Number" class="form-control" ID="txtSalesmanId" runat="server" placeholder="Salesman ID"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="salesmanNo" class="col-sm-2 col-form-label ">Salesman Name:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtSalesmanName" runat="server" placeholder="Salesman Name"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="salesmanNo" class="col-sm-2 col-form-label ">Salesman City:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtSalesmanCity" runat="server" placeholder="Salesman City"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="salesmanNo" class="col-sm-2 col-form-label ">Commission:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtCommission" runat="server" placeholder="Commission"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <%--HTML FOR BUTTON--%>
            <div class="col-sm-6 form-group m-2">
                <asp:Panel Visible="true" ID="SubmitButton" runat="server">
                    <asp:Button CssClass="btn btn-primary col-md-3" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                        Text="Submit" Style="font-size: larger"></asp:Button>
                </asp:Panel>
            </div>
            <div class="col-sm-6 form-group m-2">
                <asp:Panel Visible="false" ID="UpdateButton" runat="server">
                    <asp:Button CssClass="btn btn-success col-md-3" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
                        Text="Update" Style="font-size: larger"></asp:Button>
                </asp:Panel>
            </div>
            <div class="col-sm-6 m-2">
                <asp:Button CssClass="btn btn-danger col-md-3" ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                    Text="Cancel" Style="font-size: larger"></asp:Button>
            </div>


            <br />
            <h2 class="lable">Existing Salesman</h2>
            <br />


            <div class="table-responsive">
                <asp:GridView ID="gvSalesman" runat="server" AllowPaging="True" class="table" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="salesman_id" DataSourceID="SalesmanDataSource" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="salesman_id" HeaderText="Salesman ID" ReadOnly="True" SortExpression="salesman_id" />
                        <asp:BoundField DataField="name" HeaderText="Salesman Name" SortExpression="name" />
                        <asp:BoundField DataField="city" HeaderText="Salesman City" SortExpression="city" />
                        <asp:BoundField DataField="commision" HeaderText="Commission" SortExpression="commision" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CssClass="btn btn-success" Text="Update" runat="server" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" CssClass="btn btn-danger" Text="Delete" runat="server" OnClick="btnDelete_Click1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>

            <asp:SqlDataSource ID="SalesmanDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" DeleteCommand="DELETE FROM [salesman] WHERE [salesman_id] = @salesman_id" InsertCommand="INSERT INTO [salesman] ([salesman_id], [name], [city], [commision]) VALUES (@salesman_id, @name, @city, @commision)" SelectCommand="SELECT * FROM [salesman]" UpdateCommand="UPDATE [salesman] SET [name] = @name, [city] = @city, [commision] = @commision WHERE [salesman_id] = @salesman_id">
                <DeleteParameters>
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="commision" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="commision" Type="Decimal" />
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

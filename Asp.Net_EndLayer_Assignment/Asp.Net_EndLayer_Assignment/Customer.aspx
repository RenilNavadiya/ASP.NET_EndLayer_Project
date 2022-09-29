<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Asp.Net_EndLayer_Assignment.Customer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <h2 class="lable">Enter Customer</h2>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Panel ID="successMessage" runat="server" Visible="false">
                <h2><span class="badge badge-success btn-lg btn-block">Customer has been added Successfully!! </span></h2>
            </asp:Panel>
            <%--HTML FOR FORM--%>
            <div class="ml-lg-3">
                <div class="form-group row">
                    <label for="CustomerId" class="col-2 col-form-label ">Customer ID:</label>
                    <div class="col-sm-5">
                        <asp:TextBox TextMode="Number" class="form-control" ID="txtCustomerId" runat="server" placeholder="Customer ID"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CustomerName" class="col-sm-2 col-form-label ">Customer Name:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtCustomerName" runat="server" placeholder="Customer Name"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CustomerCity" class="col-sm-2 col-form-label ">Customer City:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtCustomerCity" runat="server" placeholder="Customer City"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CustomerGrade" class="col-sm-2 col-form-label ">Customer Grade:</label>
                    <div class="col-sm-5">
                        <asp:TextBox TextMode="Number" class="form-control" ID="txtCustomerGrade" runat="server" placeholder="Customer Grade"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="SalesmanId" class="col-sm-2 col-form-label ">Salesman ID:</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlSalesmanId" class="form-select" runat="server" DataSourceID="SalesmanIdDataSource" AppendDataBoundItems="true" DataTextField="salesman_id"
                            DataValueField="salesman_id">
                            <asp:ListItem Text="----- SELECT ONE -----" Value="" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <br />
            <%--HTML FOR BUTTON--%>
            <div class="row col-6">
                <div class="col-sm-6">
                    <asp:Panel Visible="true" ID="SubmitButton" runat="server">
                        <asp:Button CssClass="btn btn-primary col-md-6" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                            Text="Submit" Style="font-size: larger"></asp:Button>
                    </asp:Panel>
                    <asp:Panel Visible="false" ID="UpdateButton" runat="server">
                        <asp:Button CssClass="btn btn-success col-md-6" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
                            Text="Update" Style="font-size: larger"></asp:Button>
                    </asp:Panel>
                </div>
                <div class="col-sm-6 text-left" style="margin-left: -5.5em">
                    <asp:Button CssClass="btn btn-danger col-md-6" ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        Text="Cancel" Style="font-size: larger"></asp:Button>
                </div>
            </div>


            <br />
            <h2 class="lable">Existing Customer</h2>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="gvCustomer" runat="server" class="table" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="customer_id" DataSourceID="CustomerDataSource"
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="customer_id" HeaderText="Customer ID" ReadOnly="True" SortExpression="customer_id" />
                        <asp:BoundField DataField="cust_name" HeaderText="Customer Name" SortExpression="cust_name" />
                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                        <asp:BoundField DataField="grade" HeaderText="Grade" SortExpression="grade" />
                        <asp:BoundField DataField="salesman_id" HeaderText="Salesman ID" SortExpression="salesman_id" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CssClass="btn btn-success" Text="Update" runat="server" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" CssClass="btn btn-danger" Text="Delete" runat="server" OnClick="btnDelete_Click" />
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
            <asp:SqlDataSource ID="CustomerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>"
                DeleteCommand="DELETE FROM [customer] WHERE [customer_id] = @customer_id"
                InsertCommand="INSERT INTO [customer] ([customer_id], [cust_name], [city], [grade], [salesman_id]) VALUES (@customer_id, @cust_name, @city, @grade, @salesman_id)" SelectCommand="SELECT * FROM [customer]" UpdateCommand="UPDATE [customer] SET [cust_name] = @cust_name, [city] = @city, [grade] = @grade, [salesman_id] = @salesman_id WHERE [customer_id] = @customer_id">
                <DeleteParameters>
                    <asp:Parameter Name="customer_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="customer_id" Type="Int32" />
                    <asp:Parameter Name="cust_name" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="grade" Type="Int32" />
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="cust_name" Type="String" />
                    <asp:Parameter Name="city" Type="String" />
                    <asp:Parameter Name="grade" Type="Int32" />
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                    <asp:Parameter Name="customer_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SalesmanIdDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT [salesman_id] FROM [salesman]"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

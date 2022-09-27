<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Asp.Net_EndLayer_Assignment.Orders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:AdRotator ID="AdRotator1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />

            <%--HTML FOR FORM--%>
            <div class="ml-lg-3">
                <div class="form-group row">
                    <label for="OrderNumber" class="col-2 col-form-label ">Order Number:</label>
                    <div class="col-sm-5">
                        <asp:TextBox TextMode="Number" class="form-control" ID="txtOrderNumber" runat="server" placeholder="Order Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="PurchaseAmount" class="col-sm-2 col-form-label ">Purchase Amount:</label>
                    <div class="col-sm-5">
                        <asp:TextBox class="form-control" ID="txtPurchaseAmount" runat="server" placeholder="Purchase Amount"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="OrderDate" class="col-sm-2 col-form-label ">Order Date:</label>
                    <div class="col-sm-5">
                        <asp:TextBox TextMode="date" class="form-control" ID="txtOrderDate" runat="server" placeholder="Order Date"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CustomerId" class="col-sm-2 col-form-label ">Customer ID:</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlCustomerId" runat="server" class="form-select" DataSourceID="CustomerIdDataSource" DataTextField="customer_id" AppendDataBoundItems="true"
                            DataValueField="customer_id">
                            <asp:ListItem Text="----- SELECT ONE -----" Value="" />
                        </asp:DropDownList>
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

            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <asp:SqlDataSource ID="SalesmanIdDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT [salesman_id] FROM [salesman]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="CustomerIdDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT [customer_id] FROM [customer]"></asp:SqlDataSource>

            <br />

            <h2 class="lable">Existing Orders</h2>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="gvOrder" class="table" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4"
                    DataKeyNames="order_no" DataSourceID="OrdersDataSource" GridLines="None" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:BoundField DataField="order_no" HeaderText="Order Number" ReadOnly="True" SortExpression="order_no" />
                        <asp:BoundField DataField="purch_amt" HeaderText="Purchase Amount" SortExpression="purch_amt" />
                        <asp:BoundField DataField="ord_date" HeaderText="Order Date" SortExpression="ord_date" />
                        <asp:BoundField DataField="customer_id" HeaderText="Customer ID" SortExpression="customer_id" />
                        <asp:BoundField DataField="salesman_id" HeaderText="Salesman ID" SortExpression="salesman_id" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" CssClass="btn btn-success" Text="Update" runat="server" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" CssClass="btn btn-danger" Text="Delete" runat="server" OnClick="btnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#666666" ForeColor="White" Font-Size="Larger" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
            <asp:SqlDataSource ID="OrdersDataSource" runat="server"
                ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>"
                DeleteCommand="DELETE FROM [orders] WHERE [order_no] = @order_no"
                InsertCommand="INSERT INTO [orders] ([order_no], [purch_amt], [ord_date], [customer_id], [salesman_id])VALUES (@order_no, @purch_amt, @ord_date, @customer_id, @salesman_id)"
                SelectCommand="SELECT * FROM [orders]"
                UpdateCommand="UPDATE [orders] SET [purch_amt] = @purch_amt, [ord_date] = @ord_date, [customer_id] = @customer_id, [salesman_id] = @salesman_id WHERE [order_no] = @order_no">
                <DeleteParameters>
                    <asp:Parameter Name="order_no" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="order_no" Type="Int32" />
                    <asp:Parameter Name="purch_amt" Type="Decimal" />
                    <asp:Parameter Name="ord_date" DbType="Date" />
                    <asp:Parameter Name="customer_id" Type="Int32" />
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="purch_amt" Type="Decimal" />
                    <asp:Parameter Name="ord_date" DbType="Date" />
                    <asp:Parameter Name="customer_id" Type="Int32" />
                    <asp:Parameter Name="salesman_id" Type="Int32" />
                    <asp:Parameter Name="order_no" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

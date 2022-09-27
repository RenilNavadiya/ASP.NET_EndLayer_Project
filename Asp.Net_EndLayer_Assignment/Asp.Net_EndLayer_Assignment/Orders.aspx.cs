using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net_EndLayer_Assignment
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateButton.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int orderNumber = int.Parse(txtOrderNumber.Text);
            decimal purchaseAmount = decimal.Parse(txtPurchaseAmount.Text);
            DateTime orderDate = DateTime.Parse(txtOrderDate.Text);
            int customerId = int.Parse(ddlCustomerId.SelectedValue);
            int salesmanId = int.Parse(ddlSalesmanId.SelectedValue);

            OrderBO newOrder = new OrderBO()
            {
                OrderNumber = orderNumber,
                PurchaseAmount = purchaseAmount,
                OrderDate = orderDate,
                CustomerId = customerId,
                SalesmanId = salesmanId
            };

            OrderBL orderBL = new OrderBL();
            int result = orderBL.InsertOrder(newOrder);

            if (result != 0)
            {
                ClearForm();
                gvOrder.DataBind();
            }
        }

        private void ClearForm()
        {
            txtOrderNumber.Text = "";
            txtPurchaseAmount.Text = "";
            txtOrderDate.Text = "";
            ddlCustomerId.Text = "";
            ddlSalesmanId.Text = "";
            txtOrderNumber.Focus();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SubmitButton.Visible = false;
            UpdateButton.Visible = true;

            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            txtOrderNumber.Text = row.Cells[0].Text;
            txtPurchaseAmount.Text = row.Cells[1].Text;
            txtOrderDate.Text = row.Cells[2].Text;
            ddlCustomerId.SelectedValue = row.Cells[3].Text;
            ddlSalesmanId.SelectedValue = row.Cells[4].Text;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            int orderNumber = int.Parse(row.Cells[0].Text);

            OrderBL orderBL = new OrderBL();
            int result = orderBL.DeleteOrder(orderNumber);

            if (result != 0)
            {
                gvOrder.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedOrderNumber = int.Parse(txtOrderNumber.Text);
            decimal updatedPurchaseAmount = decimal.Parse(txtPurchaseAmount.Text);
            DateTime updatedOrderDate = DateTime.Parse(txtOrderDate.Text);
            int updatedCustomerId = int.Parse(ddlCustomerId.SelectedValue);
            int updatedSalesmanId = int.Parse(ddlSalesmanId.SelectedValue);

            OrderBO updatedOrder = new OrderBO()
            {
                OrderNumber = updatedOrderNumber,
                PurchaseAmount = updatedPurchaseAmount,
                OrderDate = updatedOrderDate,
                CustomerId = updatedCustomerId,
                SalesmanId = updatedSalesmanId
            };

            OrderBL orderBL = new OrderBL();
            int result = orderBL.UpdateOrder(updatedOrder);

            if (result != 0)
            {
                ClearForm();
                SubmitButton.Visible = true;
                UpdateButton.Visible = false;
                gvOrder.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SubmitButton.Visible = true;
            UpdateButton.Visible = false;
            ClearForm();
        }
    }
}
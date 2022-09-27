using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net_EndLayer_Assignment
{
    public partial class Customer : System.Web.UI.Page
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
            int cutomerId = int.Parse(txtCustomerId.Text);
            string customerName = txtCustomerName.Text;
            int grade = int.Parse(txtCustomerGrade.Text);
            string city = txtCustomerCity.Text;
            int salesmanId = int.Parse(ddlSalesmanId.SelectedValue);

            CustomerBO customerBO = new CustomerBO()
            {
                CustomerId = cutomerId,
                CustomerName = customerName,
                Grade = grade,
                City = city,
                SalesmanId = salesmanId
            };

            CustomerBL customerBL = new CustomerBL();
            int result = customerBL.InsertCustomer(customerBO);

            if (result != 0)
            {
                ClearForm();
                gvCustomer.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SubmitButton.Visible = false;
            UpdateButton.Visible = true;

            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            txtCustomerId.Text = row.Cells[0].Text;
            txtCustomerName.Text = row.Cells[1].Text;
            txtCustomerCity.Text = row.Cells[2].Text;
            txtCustomerGrade.Text= row.Cells[3].Text;
            ddlSalesmanId.SelectedValue = row.Cells[4].Text;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            int customerId = int.Parse(row.Cells[0].Text);

            CustomerBL customerBL = new CustomerBL();
            int result = customerBL.DeleteCustomer(customerId);

            if (result != 0)
            {
                gvCustomer.DataBind();
            }
        }

        private void ClearForm()
        {
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtCustomerCity.Text = "";
            txtCustomerGrade.Text = "";
            ddlSalesmanId.Text = "";
            txtCustomerId.Focus();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int cutomerIdUpdated = int.Parse(txtCustomerId.Text);
            string customerNameUpdated = txtCustomerName.Text;
            int gradeUpdated = int.Parse(txtCustomerGrade.Text);
            string cityUpdated = txtCustomerCity.Text;
            int salesmanIdUpdated = int.Parse(ddlSalesmanId.SelectedValue);

            CustomerBO customerBO = new CustomerBO()
            {
                CustomerId = cutomerIdUpdated,
                CustomerName = customerNameUpdated,
                Grade = gradeUpdated,
                City = cityUpdated,
                SalesmanId = salesmanIdUpdated
            };

            CustomerBL customerBL = new CustomerBL();
            int result = customerBL.UpdateCustomer(customerBO);

            if (result != 0)
            {
                ClearForm();
                SubmitButton.Visible = true;
                UpdateButton.Visible = false;
                gvCustomer.DataBind();
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
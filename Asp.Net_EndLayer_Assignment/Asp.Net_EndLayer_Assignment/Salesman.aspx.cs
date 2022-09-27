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
    public partial class Salesman : System.Web.UI.Page
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
            int salesmanId = int.Parse(txtSalesmanId.Text);
            string salesmanName = txtSalesmanName.Text;
            string salesmanCity = txtSalesmanCity.Text;
            Decimal commission = Decimal.Parse(txtCommission.Text);

            SalesmanBO salesmanBO = new SalesmanBO()
            {
                SalesmanName = salesmanName,
                SalesmanId = salesmanId,
                City = salesmanCity,
                Commission = commission
            };

            SalesmanBL salesmanBL = new SalesmanBL();
            int result = salesmanBL.InsertSalesman(salesmanBO);

            if (result != 0)
            {
                ClearForm();
                gvSalesman.DataBind();
            }
        }

        private void ClearForm()
        {
            txtSalesmanId.Text = "";
            txtSalesmanName.Text = "";
            txtSalesmanCity.Text = "";
            txtCommission.Text = "";
            txtSalesmanId.Focus();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SubmitButton.Visible = false;
            UpdateButton.Visible = true;

            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            txtSalesmanId.Text = row.Cells[0].Text;
            txtSalesmanName.Text = row.Cells[1].Text;
            txtSalesmanCity.Text = row.Cells[2].Text;
            txtCommission.Text = row.Cells[3].Text;
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(sender as Button).NamingContainer;
            int salesmanId = int.Parse(row.Cells[0].Text);

            SalesmanBL salesmanBL = new SalesmanBL();
            int result = salesmanBL.DeleteSalesman(salesmanId);

            if (result != 0)
            {
                gvSalesman.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int salesmanIdUpdated = int.Parse(txtSalesmanId.Text);
            string salesmanNameUpdated = txtSalesmanName.Text;
            string salesmanCityUpdated = txtSalesmanCity.Text;
            Decimal commissionUpdated = Decimal.Parse(txtCommission.Text);

            SalesmanBO salesmanBO = new SalesmanBO()
            {
                SalesmanName = salesmanNameUpdated,
                SalesmanId = salesmanIdUpdated,
                City = salesmanCityUpdated,
                Commission = commissionUpdated
            };

            SalesmanBL salesmanBL = new SalesmanBL();
            int result = salesmanBL.UpdateSalesman(salesmanBO);

            if (result != 0)
            {
                ClearForm();
                SubmitButton.Visible = true;
                UpdateButton.Visible = false;
                gvSalesman.DataBind();
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
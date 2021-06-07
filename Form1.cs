using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1._1
{
    public partial class Form1 : Form
    {
        Expenses ex = new Expenses();
        public Form1()
        {
            InitializeComponent();
            Prop_Info.Visible = false;
            Rental.Visible = false;
        }

        private void Renting_CheckedChanged(object sender, EventArgs e)
        {
            Rental.Visible = true;
            Prop_Info.Visible = false;


        }

        private void Buying_CheckedChanged(object sender, EventArgs e)
        {
            Prop_Info.Visible = true;
            Rental.Visible = false;


        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
        //sets Values
        private void Add2_Click(object sender, EventArgs e)
        {
            ex.setIncome(Convert.ToInt32(tMonthlyInc.Text));
            ex.setTax(Convert.ToInt32(tMonthTax.Text));
            ex.setGroceries(Convert.ToInt32(tGroceries.Text));
            ex.setWaterLights(Convert.ToInt32(tWaterLights.Text));
            ex.setTravelCost(Convert.ToInt32(tTravelCost.Text));
            ex.setCellphone(Convert.ToInt32(tPhone.Text));
            ex.setOther(Convert.ToInt32(tOther.Text));
            
           
            
         
            
            ItemsList();
        }

        private void Rental_Paint(object sender, PaintEventArgs e)
        {

        }
        //Adds items to a list
        private void ItemsList()
        {
            string strChanceofLoan;
            double db1thirdSalary = ((ex.getIncome() * 33) / 100);
            if (ex.getMonthlySalary() >= db1thirdSalary)
            {
                strChanceofLoan = "Your chance of getting the home load is high";
            }
            else
            {
                strChanceofLoan = "Your chance of getting the home load is slim to none";
            }
            

            List.Items.Clear();
            string strTemp = String.Format("{0} ,\t{1}", "Expense\t\t\t" , "Amount");
            List.Items.Add(strTemp);
            //As a fail safe if the print doesnt work
            strTemp = String.Format("{0} ,\t R{1}", "Gross Monthly Income", ex.getIncome());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t  R{1}", "Monthly tax estimate", ex.getTax());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t \t R{1}", "Groceries", ex.getGroceries());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t \t R{1}", "Water and lights", ex.getWaterLights());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t \t R{1}", "Travel Cost", ex.getTravelCost());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t \t \t R{1}", "Phone", ex.getCellphone());
            List.Items.Add(strTemp);
            strTemp = String.Format("{0} ,\t \t \t R{1}", "Other", ex.getOther());
            List.Items.Add(strTemp);
            
            strTemp = String.Format("{0} ,\t \t R{1}", "Monthly Salary", ex.getMonthlySalary());
            List.Items.Add(strTemp);
            //Works half the time maybe try new class
            strTemp = String.Format("{0}, \t", "Chance of home loan", strChanceofLoan);
            List.Items.Add(strTemp);

            if (Rental.Visible == true)
            {
                ex.setRental(Convert.ToInt32(RentalAmount.Text));
                strTemp = String.Format("{0} ,\t \t R{1}", "Rental Amount", ex.getRental());
                List.Items.Add(strTemp);
            }
            else 
            {
                
                ex.setPropertyPrice(Convert.ToInt32(tPurchasePrice.Text)); 
                ex.setDeposit(Convert.ToInt32(tDeposit.Text));
                ex.setInterest(Convert.ToInt32(tInterest.Text));
                ex.setMonths(Convert.ToInt32(tNoMonths.Text));
                strTemp = String.Format("{0} ,\t \t R{1}", "Property Amount", ex.getPropertyPrice());
                List.Items.Add(strTemp);
                strTemp = String.Format("{0} ,\t \t R{1}", "Total Deposit", ex.getDeposit());
                List.Items.Add(strTemp);
                strTemp = String.Format("{0} ,\t \t", "Interest Rate", ex.getInterest(), "%{1}");
                List.Items.Add(strTemp);
                strTemp = String.Format("{0} ,\t  R{1}", "Number of months", ex.getMonths());
                List.Items.Add(strTemp);
            }
            lblTotal.Text = "The total is :" + ex.getTotal();

        }
        
    }
}

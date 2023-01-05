using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_system
{
    public partial class frm_items : Form
    {
        const double price_burger = 15;
        const double price_pizza = 22;
        const double price_sandwich = 14;
        const double price_soup = 10;
        const double price_salad = 12;
        const double price_cola = 9;
        const double price_fanta = 9;
        const double price_coffee = 12;
        const double price_tea = 10;
        const double price_water = 6;

        List<OrderingHistory> orhistory = new List<OrderingHistory>();

        public frm_items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            cmb_payment.Items.Add("");
            cmb_payment.Items.Add("Cash");
            cmb_payment.Items.Add("Cash on delivery");

            btn_order.Enabled = false;

            EnableTextBoxes();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm you want to exit",
                "Ordering system", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void EnableTextBoxes() 
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Enabled = false;
                        (control as TextBox).Text = "0";
                        txt_name.Text = "Name Surname";
                        txt_address.Text = "Region, City, Street";
                        txt_number.Text = "0XXXXXXXXX";
                    }
                    else
                        func(control.Controls);
            };
            func(Controls);
        }


        private void chck_burger_CheckedChanged(object sender, EventArgs e)
        {
            if(chck_burger.Checked == true) 
            {
                txt_burger.Enabled = true;
                txt_burger.Text = "";
                txt_burger.Focus();
            }
            else
            {
                txt_burger.Enabled = false;
                txt_burger.Text = "0";
            }
        }

        private void chck_pizza_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_pizza.Checked == true)
            {
                txt_pizza.Enabled = true;
                txt_pizza.Text = "";
                txt_pizza.Focus();
            }
            else
            {
                txt_pizza.Enabled = false;
                txt_pizza.Text = "0";
            }
        }

        private void chck_sandwich_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_sandwich.Checked == true)
            {
                txt_sandwich.Enabled = true;
                txt_sandwich.Text = "";
                txt_sandwich.Focus();
            }
            else
            {
                txt_sandwich.Enabled = false;
                txt_sandwich.Text = "0";
            }
        }

        private void chck_salad_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_salad.Checked == true)
            {
                txt_salad.Enabled = true;
                txt_salad.Text = "";
                txt_salad.Focus();
            }
            else
            {
                txt_salad.Enabled = false;
                txt_salad.Text = "0";
            }
        }

        private void chck_soup_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_soup.Checked == true)
            {
                txt_soup.Enabled = true;
                txt_soup.Text = "";
                txt_soup.Focus();
            }
            else
            {
                txt_soup.Enabled = false;
                txt_soup.Text = "0";
            }
        }

        private void chck_cola_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_cola.Checked == true)
            {
                txt_cola.Enabled = true;
                txt_cola.Text = "";
                txt_cola.Focus();
            }
            else
            {
                txt_cola.Enabled = false;
                txt_cola.Text = "0";
            }
        }

        private void chck_fanta_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_fanta.Checked == true)
            {
                txt_fanta.Enabled = true;
                txt_fanta.Text = "";
                txt_fanta.Focus();
            }
            else
            {
                txt_fanta.Enabled = false;
                txt_fanta.Text = "0";
            }
        }

        private void chck_coffee_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_coffee.Checked == true)
            {
                txt_coffee.Enabled = true;
                txt_coffee.Text = "";
                txt_coffee.Focus();
            }
            else
            {
                txt_coffee.Enabled = false;
                txt_coffee.Text = "0";
            }
        }

        private void chck_tea_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_tea.Checked == true)
            {
                txt_tea.Enabled = true;
                txt_tea.Text = "";
                txt_tea.Focus();
            }
            else
            {
                txt_tea.Enabled = false;
                txt_tea.Text = "0";
            }
        }

        private void chck_water_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_water.Checked == true)
            {
                txt_water.Enabled = true;
                txt_water.Text = "";
                txt_water.Focus();
            }
            else
            {
                txt_water.Enabled = false;
                txt_water.Text = "0";
            }
        }

        private void cmb_payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_payment.Text == "Cash")
            {
                txt_payment.Enabled = true;
                txt_payment.Text = "";
                txt_payment.Focus();

                txt_name.Text = "Name Surname";
                txt_address.Text = "Region, City, Street";
                txt_number.Text = "0XXXXXXXXX";

                txt_name.Enabled = false;
                txt_address.Enabled = false;
                txt_number.Enabled = false;
            }

            else if(cmb_payment.Text == "Cash on delivery")
            {
                txt_name.Enabled = true;
                txt_address.Enabled = true;
                txt_number.Enabled = true;
                txt_name.Text = "";
                txt_address.Text = "";
                txt_number.Text = "";
                txt_name.Focus();
                txt_address.Focus();
                txt_number.Focus();

                txt_payment.Enabled = false;
                txt_payment.Text = "0";

                lbl_total.Text = "total result";
                lbl_change.Text = "change result";

                btn_order.Enabled = true;
            }
            else
            {
                txt_payment.Enabled = false;
                txt_payment.Text = "0";
            }
        }

        private void btn_total_Click(object sender, EventArgs e)
        {
            double[] itemcost = new double[100];
            itemcost[0] = Convert.ToDouble(txt_burger.Text) * price_burger;
            itemcost[1] = Convert.ToDouble(txt_pizza.Text) * price_pizza;
            itemcost[2] = Convert.ToDouble(txt_sandwich.Text) * price_sandwich;
            itemcost[3] = Convert.ToDouble(txt_soup.Text) * price_soup;
            itemcost[4] = Convert.ToDouble(txt_salad.Text) * price_salad;
            itemcost[5] = Convert.ToDouble(txt_cola.Text) * price_cola;
            itemcost[6] = Convert.ToDouble(txt_fanta.Text) * price_fanta;
            itemcost[7] = Convert.ToDouble(txt_coffee.Text) * price_coffee;
            itemcost[8] = Convert.ToDouble(txt_tea.Text) * price_tea;
            itemcost[9] = Convert.ToDouble(txt_water.Text) * price_water;

            double total, payment, cost;

            if (cmb_payment.Text == "Cash")
            {
                total = itemcost[0] + itemcost[1] + itemcost[2] + itemcost[3] + itemcost[4]
                    + itemcost[5] + itemcost[6] + itemcost[7] + itemcost[8] + itemcost[9];

                if (total == 0)
                {
                    MessageBox.Show("Choose something to order!");
                }
                else if (txt_payment.Text == "")
                {
                    MessageBox.Show("Deposit funds for payment");
                }
                else
                {
                    lbl_total.Text = Convert.ToString(total);
                    payment = Convert.ToInt32(txt_payment.Text);
                    cost = payment - total;
                    lbl_change.Text = Convert.ToString(cost);

                    if (cost < 0)
                    {
                        MessageBox.Show("You do not have enough funds to pay!\nDeposit more funds.");
                    }
                    else
                    {
                        btn_order.Enabled = true;
                    }
                }
            }
            else
            {
                total = itemcost[0] + itemcost[1] + itemcost[2] + itemcost[3] + itemcost[4]
                    + itemcost[5] + itemcost[6] + itemcost[7] + itemcost[8] + itemcost[9];

                if (total == 0)
                {
                    MessageBox.Show("Choose something to order!");
                }
                else
                {
                    lbl_total.Text = Convert.ToString(total);
                    lbl_change.Text = "0";
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            ResetCheckBox();

            btn_order.Enabled = false;
            cmb_payment.Text = "";
            lbl_total.Text = "total result";
            lbl_change.Text = "change result";
        }

        private void ResetTextBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Enabled = false;
                        (control as TextBox).Text = "0";
                        txt_name.Text = "Name Surname";
                        txt_address.Text = "Region, City, Street";
                        txt_number.Text = "0XXXXXXXXX";
                    }
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void ResetCheckBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is CheckBox)
                    {
                        (control as CheckBox).Checked = false;
                    }
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            if (cmb_payment.Text == "Cash on delivery")
            {
                if (txt_name.Text == "" || txt_address.Text == "" || txt_number.Text.Length != 10)
                {
                    MessageBox.Show("Provide all contact information!");
                }
                else if(lbl_total.Text == "total result")
                {
                    MessageBox.Show("Check your Total to continue!");
                }
                else
                {
                    MessageBox.Show("Thank you for choosing us!\nWe'll deliver your order at: " + txt_address.Text + "\n" + "We'll inform you at: " + txt_number.Text);

                    DateTime now = DateTime.Now;
                    string orderDate = now.ToString("F");

                    var order = new OrderingHistory(txt_name.Text, txt_address.Text, txt_number.Text, orderDate);
                    orhistory.Add(order);
                }
            } 
            else
            {
                MessageBox.Show("Thanks for choosing us!");

                DateTime now = DateTime.Now;
                string orderDate = now.ToString("F");

                var order = new OrderingHistory("Offline client", "Offline cafe", "No number", orderDate);
                orhistory.Add(order);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(@"C:\Users\dimka\Desktop\Order history.txt"))
            {
                foreach (OrderingHistory order in orhistory)
                {
                    string text = order.CustomerName + ", " + order.CustomerAddress + ", " + order.CustomerNumber + ", " + order.OrderDate;
                    sw.WriteLine(text);
                }
            }

            MessageBox.Show("Order history on your desktop");
        }
    }
}

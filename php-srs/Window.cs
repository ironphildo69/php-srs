using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace php_srs
{
    public partial class Window : Form
    {
        private string user = "";

        public Window()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void setUser(string user)
        {
            this.user = user;
            loginstatus_l.Text = "Currently logged in as: " + user;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        //Panel 1 mainmenu
        //Stock Items
        private void button1_Click(object sender, EventArgs e)
        {
            mainmenu_p.Visible = false;
            stockitem_p.Visible = true;
        }

        //Sales Records
        private void button2_Click(object sender, EventArgs e)
        {
            mainmenu_p.Visible = false;
            salesrecords_p.Visible = true;
        }

        //Reports
        private void button3_Click(object sender, EventArgs e)
        {
            mainmenu_p.Visible = false;
            report_p.Visible = true;
        }

        //log out
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //quit
        private void button5_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        //Panel 2 submenu stockitem_p
        //update stock
        private void updatestock_b_Click(object sender, EventArgs e)
        {
            stocktableupdate_p.Visible = true;

            id_stockup_list.Items.Clear();

            StockTake st = new StockTake();

            List<string> results = st.GetNameRows("SELECT Name FROM StockTable");

            for (int i = 0; i < results.Count; i++)
            {
                id_stockup_list.Items.Insert(i, results[i]);
            }

            stockitem_p.Visible = false;
        }

        //view stock
        private void viewcurrentstock_b_Click(object sender, EventArgs e)
        {
            stockitemview_p.Visible = true;

            id_stockview_list.Items.Clear();
            name_stockview_list.Items.Clear();

            name_stockview_list.Items.Insert(0, "");
            id_stockview_list.Items.Insert(0, "");

            StockTake st = new StockTake();
            List<string> results = st.GetNameRows("SELECT Name FROM StockTable");
            for (int i = 0; i < results.Count; i++)
            {
                name_stockview_list.Items.Insert((i + 1), results[i]);
                id_stockview_list.Items.Insert((i + 1), (i + 1));
            }

            stockitem_p.Visible = false;
        }

        //back button
        private void back_b_Click(object sender, EventArgs e)
        {
            mainmenu_p.Visible = true;
            confirm_label.Text = " ";
            stockitem_p.Visible = false;            
        }
        

        //Panel 3 submenu stockupdate
        // enter
        private void enter_stockup_b_Click(object sender, EventArgs e)
        {
            string inputName = name_stockup_t.Text;
            string inputDesc = desc_stockup_t.Text;
            string inputQty = qty_stockup_t.Text;
            string inputPrice = price_stockup_t.Text;
            string inputAttr = attr_stockup_list.GetItemText(attr_stockup_list.SelectedItem);

            int value1;
            double value2;
            int inputQtyOut = 0;
            double inputPrcOut = 0;

            if (inputName == "" || inputDesc == "" || inputAttr == "" || inputPrice == "" || inputQty == "")
            {
                MessageBox.Show("One of the fields has not been filled.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //confirm_label.Text = "One of the fields has not been filled.";
            } else {  
                if (int.TryParse(inputQty, out value1))
                {
                    inputQtyOut = value1;

                    if (double.TryParse(inputPrice, out value2))
                    {
                        inputPrcOut = value2;

                        AddItem ai = new AddItem();
                        ai.InsertIntoTable(inputName, inputDesc, inputAttr, inputQtyOut, inputPrcOut);
                        MessageBox.Show("The item has been added", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        changeAlert();
                        //confirm_label.Text = "The item has been added.";
                    } else {
                        MessageBox.Show("The Price value must be a number. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //confirm_label.Text = "The Price Value was not correct. Please try again.";
                    }
                } else {
                    MessageBox.Show("The Quantity value must be a number. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //confirm_label.Text = "The Quantity Value was not correct. Please try again.";
                }
            }

            name_stockup_t.Clear();
            desc_stockup_t.Clear();
            qty_stockup_t.Clear();
            price_stockup_t.Clear();
            attr_stockup_list.ClearSelected();   
        }

        //apply update of id qty
        private void enterid_stockup_b_Click(object sender, EventArgs e)
        {
            string inputID = id_stockup_list.GetItemText(id_stockup_list.SelectedItem);
            string inputQty = qtyid_stockup_t.Text;

            int value1;
            int inputQtyOut = 0;

            if (inputID == "" || inputQty == "")
            {
                MessageBox.Show("Nothing has been chosen or entered. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (int.TryParse(inputQty, out value1))
                {
                    inputQtyOut = value1;

                    AddItem ai = new AddItem();
                    ai.UpdateTableByName(inputID, inputQtyOut, 0);

                    MessageBox.Show("The item has been updated.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    changeAlert();

                    //confirmbyid_label.Text = "The item has been updated.";
                } else {
                    MessageBox.Show("The Quantity Value must be a number. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //confirmbyid_label.Text = "Quantity needs numeric input only.";
                }
            }
            
            qtyid_stockup_t.Clear();
            id_stockup_list.ClearSelected();
        }        
        
        //back to prior menu from stock update
        private void back_stocktableupdate_b_Click(object sender, EventArgs e)
        {
            stocktableupdate_p.Visible = false;
            qtyid_stockup_t.Clear();
            id_stockup_list.ClearSelected();
            stockitem_p.Visible = true;
        }

        //to additem panel stock item
        private void additem_stockup_b_Click(object sender, EventArgs e)
        {
            stockitem_p.Visible = false;
            stockadditem_p.Visible = true;
        }

        //back to prior menu from stock update
        private void back_stockadditem_b_Click(object sender, EventArgs e)
        {
            stockadditem_p.Visible = false;
            name_stockup_t.Clear();
            desc_stockup_t.Clear();
            qty_stockup_t.Clear();
            price_stockup_t.Clear();
            attr_stockup_list.ClearSelected();
            stockitem_p.Visible = true;
        }

        //Report Panel
        //

        private void back_report_b_Click( object sender, EventArgs e)
        {
            report_p.Visible = false;
            mainmenu_p.Visible = true;
            //this.CSVsales_l.Visible = false;
            //this.CSVstock_l.Visible = false;

        }

        private void back_reportCSVsales_b_Click(object sender, EventArgs e)
        {
            CSV salesCSV = new CSV();
            salesCSV.WriteStockSalesToFile();

            MessageBox.Show("Sales Records Successfully Exported to CSV-StockSales.txt.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.CSVsales_l.Visible = true;
            //this.CSVstock_l.Visible = false;


        }

        private void back_reportCSVstock_b_Click(object sender, EventArgs e)
        {
            CSV stockCSV = new CSV();
            stockCSV.WriteStockTakeToFile();
            MessageBox.Show("Stock Records Successfully Exported to CSV-StockSales.txt.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.CSVsales_l.Visible = false;
            //this.CSVstock_l.Visible = true;
            
        }

        private void back_reportsales_b_Click(object sender, EventArgs e)
        {
            this.CSVsales_l.Visible = false;
            this.CSVstock_l.Visible = false;
            
        }

        private void back_reportstock_b_Click(object sender, EventArgs e)
        {
            this.CSVsales_l.Visible = false;
            this.CSVstock_l.Visible = false;
            
        }        

        //Submenu stockview
        //show all current stock
        private void allstock_b_Click(object sender, EventArgs e)
        {
            stockitemview_p.Visible = false;
            StockTake st = new StockTake();
            st.SelectFromTable("SELECT * FROM StockTable", dataGridStock);
            stocktable_p.Visible = true;
        }

        //enter
        private void enter1_b_Click(object sender, EventArgs e)
        {
            stockitemview_p.Visible = false;
            
            string inputID = "";
            string inputName = "";
            string inputAttr = "";

            if (id_stockview_list.SelectedIndex != 0)
            {
                inputID = id_stockview_list.GetItemText(id_stockview_list.SelectedItem);
            }

            if (name_stockview_list.SelectedIndex != 0)
            {
                inputName = name_stockview_list.GetItemText(name_stockview_list.SelectedItem);
            }

            if (attribute_lst.SelectedIndex != 0)
            {
                inputAttr = attribute_lst.GetItemText(attribute_lst.SelectedItem);
            }
                        
            StockTake st = new StockTake();
            
            string query = "SELECT * FROM StockTable ";
            string whereClause = "WHERE ";
            string whereAnd = " AND ";
            string whereID = "ID = " + inputID;
            string whereName = "Name = " + "'" + inputName + "'";
            string whereAttr = "Attribute = " + "'" + inputAttr + "'";

            if (inputID != "")
            {
                query += whereClause;
                query += whereID;

                if (inputName != "")
                {
                    query += whereAnd;
                    query += whereName;

                    if (inputAttr != "")
                    {
                        query += whereAnd;
                        query += whereAttr;
                    }
                } else if (inputAttr != "") {
                    query += whereAnd;
                    query += whereAttr;                    
                }
            } else if (inputName != "")
                {
                    query += whereClause;
                    query += whereName;

                    if (inputAttr != "")
                    {
                        query += whereAnd;
                        query += whereAttr;
                    }                
            } else if (inputAttr != "") {
                query += whereClause;
                query += whereAttr;
            }          
            
            st.SelectFromTable(query, dataGridStock);

            id_stockview_list.ClearSelected();
            name_stockview_list.ClearSelected();
            attribute_lst.ClearSelected();

            stocktable_p.Visible = true;
        }

        //back
        private void back2_b_Click(object sender, EventArgs e)
        {
            stockitemview_p.Visible = false;
            stockitem_p.Visible = true;
        }

        //back to main menu from stock table
        private void back_stocktable_b_Click(object sender, EventArgs e)
        {            
            stocktable_p.Visible = false;
            mainmenu_p.Visible = true;
        }


        //Panel - Sales Records
        private void makesales_b_Click(object sender, EventArgs e)
        {
            salesrecords_p.Visible = false;

            salesitems_list.Items.Clear();

            salesitems_list.Items.Insert(0, "");

            StockTake st = new StockTake();
            List<string> results = st.GetItemRows("SELECT * FROM StockTable");
            for (int i = 0; i < results.Count; i++)
            {
                salesitems_list.Items.Insert((i + 1), results[i]);
            }

            makesale_p.Visible = true;
        }

        private void viewrecord_b_Click(object sender, EventArgs e)
        {
            salesrecords_p.Visible = false;

            StockSales ss = new StockSales();
            ss.SelectFromTable("SELECT * FROM SalesRecords", sales_datagrid);
            
            salesview_p.Visible = true;            
        }

        private void salesrecordback_b_Click(object sender, EventArgs e)
        {
            salesrecords_p.Visible = false;
            mainmenu_p.Visible = true;
        }

        //Make sale
        private void sales_enter_b_Click(object sender, EventArgs e)
        {            
            string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string time = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString();

            int item = salesitems_list.SelectedIndex;
            string itemString = "" + item;
            string inputQty = sales_qty_t.Text;
            int outputQty;
            string name = "";
            double price = 0;

            if (item > 0)
            {
                StockTake st = new StockTake();
                name = st.GetName(itemString);
                price = st.GetPrice(itemString);

                if (int.TryParse(inputQty, out outputQty))
                {
                    price = price * outputQty;

                    AddItem ai = new AddItem();
                    ai.UpdateTableByName(name, outputQty, 1);

                    AddSalesRecord asr = new AddSalesRecord();
                    asr.InsertIntoTable(name, outputQty, price, user, date, time);

                    makesale_p.Visible = false;
                    changeAlert();
                    successbox_t.Text = "You have succesfully sold " + outputQty + " " + name + "'s for $" + price + ".";
                    confirmsale_p.Visible = true;

                } else {
                    MessageBox.Show("The Quantity value must be a number. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //confirmsale_l.Text = "Quantity can only be numeric.";
                }

            } else {
                MessageBox.Show("You have not yet chosen an Item from the list. \nPlease try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //confirmsale_l.Text = "You have not yet chosen an item.";
            }

            sales_qty_t.Clear();
            confirmsale_l.Text = " ";
            salesitems_list.ClearSelected();            
        }

        //back 
        private void sales_back_b_Click(object sender, EventArgs e)
        {
            makesale_p.Visible = false;
            sales_qty_t.Clear();
            salesitems_list.ClearSelected();
            confirmsale_l.Text = " ";
            salesrecords_p.Visible = true;
        }

        //continue from confirm sale
        private void continuesale_b_Click(object sender, EventArgs e)
        {
            confirmsale_p.Visible = false;
            successbox_t.Clear();
            salesrecords_p.Visible = true;
        }

        //back from salestable
        private void back_salesview_b_Click(object sender, EventArgs e)
        {
            salesview_p.Visible = false;
            mainmenu_p.Visible = true;
        }        
        
        public void changeAlert()
        {
            StockTake st = new StockTake();
            List<string> rows = st.GetNameRows("SELECT * FROM StockTable");

            record_l.Text = "";

            int quantity;
            string name;

            if (rows.Count() == 0)
            {
                record_l.Text = "There are no critical items.";
            }

            for (int i = 0; i < rows.Count(); i++)
            {
                name = st.GetName("" + (i + 1));
                quantity = st.GetQuantity("" + (i + 1));

                if (quantity < 100)
                {
                    record_l.Text += name + " only has " + quantity + " items in stock!\n";
                }
            }
        }

        //window
        private void window_Resize(object sender, EventArgs e)
        {
            //mainmenu
            this.heading_img.Left = (this.ClientSize.Width - this.heading_img.Width) / 2;
            this.stockitem_b.Left = (this.ClientSize.Width - this.stockitem_b.Width) / 2;
            this.salesrecord_b.Left = (this.ClientSize.Width - this.salesrecord_b.Width) / 2;
            this.report_b.Left = (this.ClientSize.Width - this.report_b.Width) / 2;
            this.logout_b.Left = (this.ClientSize.Width - this.logout_b.Width) / 2 - 65;
            this.quit_b.Left = (this.ClientSize.Width - this.quit_b.Width) / 2 + 65;

            //smenu report
            this.back_report_b.Left = (this.ClientSize.Width - this.back_report_b.Width) / 2 ;
            this.back_reportCSVsales_b.Left = (this.ClientSize.Width - this.back_report_b.Width) / 2;
            this.back_reportCSVstock_b.Left = (this.ClientSize.Width - this.back_report_b.Width) / 2;
            this.back_reportsales_b.Left = (this.ClientSize.Width - this.back_reportsales_b.Width) / 2 + 150;
            this.back_reportstock_b.Left = (this.ClientSize.Width - this.back_reportstock_b.Width) / 2 - 150;

            //smenu stock
            this.updatestock_b.Left = (this.ClientSize.Width - this.updatestock_b.Width) / 2;
            this.viewcurrentstock_b.Left = (this.ClientSize.Width - this.viewcurrentstock_b.Width) / 2;
            this.back_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2;
            this.additem_stockup_b.Left = (this.ClientSize.Width - this.additem_stockup_b.Width) / 2;

            //smenu updatestock
            this.addiditem_stockup_l.Left = (this.ClientSize.Width - this.addiditem_stockup_l.Width) / 2;
            this.qtyid_stockup_t.Left = (this.ClientSize.Width - this.qtyid_stockup_t.Width) / 2 + 75;
            this.id_l.Left = (this.ClientSize.Width - this.id_l.Width) / 2 - 150;
            this.id_qty_l.Left = (this.ClientSize.Width - this.id_qty_l.Width) / 2 - 150;
            this.id_stockup_list.Left = (this.ClientSize.Width - this.id_stockup_list.Width) / 2 + 75;
            this.enterid_stockup_b.Left = (this.ClientSize.Width - this.enterid_stockup_b.Width) / 2;
            this.back_stocktableupdate_b.Left = (this.ClientSize.Width - this.back_stocktableupdate_b.Width) / 2;
            this.confirmbyid_label.Left = (this.ClientSize.Width - this.confirmbyid_label.Width) / 2;            

            //smenu addstock
            this.addnewitem_stockup_l.Left = (this.ClientSize.Width - this.addnewitem_stockup_l.Width) / 2;
            this.name_stockup_l.Left = (this.ClientSize.Width - this.name_stockup_l.Width) / 2 - 150;
            this.desc_stockup_l.Left = (this.ClientSize.Width - this.desc_stockup_l.Width) / 2 - 150;
            this.attr_stockup_l.Left = (this.ClientSize.Width - this.attr_stockup_l.Width) / 2 - 150;
            this.qty_stockup_l.Left = (this.ClientSize.Width - this.qty_stockup_l.Width) / 2 - 150;
            this.price_stockup_l.Left = (this.ClientSize.Width - this.price_stockup_l.Width) / 2 - 150;           
            this.name_stockup_t.Left = (this.ClientSize.Width - this.name_stockup_t.Width) / 2 + 75;
            this.desc_stockup_t.Left = (this.ClientSize.Width - this.desc_stockup_t.Width) / 2 + 75;
            this.qty_stockup_t.Left = (this.ClientSize.Width - this.qty_stockup_t.Width) / 2 + 75;
            this.price_stockup_t.Left = (this.ClientSize.Width - this.price_stockup_t.Width) / 2 + 75;            
            this.confirm_label.Left = (this.ClientSize.Width - this.confirm_label.Width) / 2 ;
            this.back_stockadditem_b.Left = (this.ClientSize.Width - this.back_stockadditem_b.Width) / 2;
            this.attr_stockup_list.Left = (this.ClientSize.Width - this.attr_stockup_list.Width) / 2 + 75;                       
            this.enter_stockup_b.Left = (this.ClientSize.Width - this.enter_stockup_b.Width) / 2;                     

            //smenu viewstock
            this.allstock_b.Left = (this.ClientSize.Width - this.viewcurrentstock_b.Width) / 2 - 150;
            this.enter1_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2 + 150;
            this.back2_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2;
            this.label_stocktable_id.Left = (this.ClientSize.Width - this.label_stocktable_id.Width) / 2 - 150;
            this.label_stocktable_name.Left = (this.ClientSize.Width - this.label_stocktable_name.Width) / 2 - 150;
            this.label_stocktable_attr.Left = (this.ClientSize.Width - this.label_stocktable_attr.Width) / 2 - 150;
            this.id_stockview_list.Left = (this.ClientSize.Width - this.id_stockview_list.Width) / 2 + 75;
            this.name_stockview_list.Left = (this.ClientSize.Width - this.name_stockview_list.Width) / 2 + 75;
            this.attribute_lst.Left = (this.ClientSize.Width - this.attribute_lst.Width) / 2 + 75;
            this.specificitemhead_l.Left = (this.ClientSize.Width - this.specificitemhead_l.Width) / 2;

            //smenu stocktable
            this.back_stocktable_b.Left = (this.ClientSize.Width - this.back_stocktable_b.Width) / 2;
            this.dataGridStock.Left = (this.ClientSize.Width - this.dataGridStock.Width) / 2;
            this.stockviewhead_l.Left = (this.ClientSize.Width - this.stockviewhead_l.Width) / 2;

            //smenu salesrecords
            this.makesales_b.Left = (this.ClientSize.Width - this.makesales_b.Width) / 2;
            this.viewrecord_b.Left = (this.ClientSize.Width - this.viewrecord_b.Width) / 2;
            this.salesrecordback_b.Left = (this.ClientSize.Width - this.salesrecordback_b.Width) / 2;

            this.choosestock_l.Left = (this.ClientSize.Width - this.choosestock_l.Width) / 2;
            this.sales_qty_l.Left = (this.ClientSize.Width - this.sales_qty_l.Width) / 2 - 125;
            this.salesitems_list.Left = (this.ClientSize.Width - this.salesitems_list.Width) / 2;
            this.sales_qty_t.Left = (this.ClientSize.Width - this.sales_qty_t.Width) / 2 + 88;
            this.sales_enter_b.Left = (this.ClientSize.Width - this.sales_enter_b.Width) / 2;
            this.sales_back_b.Left = (this.ClientSize.Width - this.sales_back_b.Width) / 2;
            this.confirmsale_l.Left = (this.ClientSize.Width - this.confirmsale_l.Width) / 2;
            

            //smenu confirm
            this.confirmation_l.Left = (this.ClientSize.Width - this.confirmation_l.Width) / 2;
            this.successbox_t.Left = (this.ClientSize.Width - this.successbox_t.Width) / 2;
            this.continuesale_b.Left = (this.ClientSize.Width - this.continuesale_b.Width) / 2;

            //smenu salestable
            this.sales_datagrid.Left = (this.ClientSize.Width - this.sales_datagrid.Width) / 2;
            this.back_salesview_b.Left = (this.ClientSize.Width - this.back_salesview_b.Width) / 2;
            this.salesviewhead_l.Left = (this.ClientSize.Width - this.salesviewhead_l.Width) / 2;

            //record updates on window
            //this.record_heading_l.Left = (this.ClientSize.Width - this.record_heading_l.Width) / 2;
            //this.record_l.Left = (this.ClientSize.Width - this.record_l.Width) / 2;
        }
    }
}

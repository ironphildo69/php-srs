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
        public Window()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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

        }

        //Reports
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //log out
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //quit
        private void button5_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                confirm_label.Text = "One of the fields has not been filled.";
            } else {
                

                if (int.TryParse(inputQty, out value1))
                {
                    inputQtyOut = value1;

                    if (double.TryParse(inputPrice, out value2))
                    {
                        inputPrcOut = value2;

                        AddItem ai = new AddItem();
                        ai.InsertIntoTable(inputName, inputDesc, inputAttr, inputQtyOut, inputPrcOut);
                        confirm_label.Text = "The item has been added.";
                    }
                    else
                    {
                        confirm_label.Text = "The Price Value was not correct. Please try again.";
                    }
                }
                else
                {
                    confirm_label.Text = "The Quantity Value was not correct. Please try again.";
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

            if (int.TryParse(inputQty, out value1))
            {
                inputQtyOut = value1;

                AddItem ai = new AddItem();
                ai.UpdateTable(inputID, inputQtyOut);

                confirmbyid_label.Text = "The item has been updated.";
            } else {
                confirmbyid_label.Text = "Quantity needs numeric input only.";
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
            
            string inputID = "" + id_stockview_list.SelectedItem.ToString();
            string inputName = "" + name_stockview_list.SelectedItem.ToString();
            string inputAttr = "" + attribute_lst.SelectedItem.ToString();
                        
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

        //window
        private void window_Resize(object sender, EventArgs e)
        {
            //mainmenu
            this.heading_img.Left = (this.ClientSize.Width - this.heading_img.Width) / 2;
            this.record_l.Left = (this.ClientSize.Width - this.record_l.Width) / 2 + 150;
            this.stockitem_b.Left = (this.ClientSize.Width - this.stockitem_b.Width) / 2 - 150;
            this.salesrecord_b.Left = (this.ClientSize.Width - this.salesrecord_b.Width) / 2 - 150;
            this.report_b.Left = (this.ClientSize.Width - this.report_b.Width) / 2 - 150;
            this.logout_b.Left = (this.ClientSize.Width - this.logout_b.Width) / 2 - (217);
            this.quit_b.Left = (this.ClientSize.Width - this.quit_b.Width) / 2 - (83);

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
            this.back2_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2 + 150;
            this.label_stocktable_id.Left = (this.ClientSize.Width - this.label_stocktable_id.Width) / 2 - 150;
            this.label_stocktable_name.Left = (this.ClientSize.Width - this.label_stocktable_name.Width) / 2 - 150;
            this.label_stocktable_attr.Left = (this.ClientSize.Width - this.label_stocktable_attr.Width) / 2 - 150;
            this.id_stockview_list.Left = (this.ClientSize.Width - this.id_stockview_list.Width) / 2 + 150;
            this.name_stockview_list.Left = (this.ClientSize.Width - this.name_stockview_list.Width) / 2 + 150;
            this.attribute_lst.Left = (this.ClientSize.Width - this.attribute_lst.Width) / 2 + 150;

            //smenu stocktable
            this.back_stocktable_b.Left = (this.ClientSize.Width - this.back_stocktable_b.Width) / 2;
            this.dataGridStock.Left = (this.ClientSize.Width - this.dataGridStock.Width) / 2;
            

        }
    }
}

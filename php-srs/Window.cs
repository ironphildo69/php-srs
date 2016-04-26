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
            stockitem_p.Visible = false;
        }

        //view stock
        private void viewcurrentstock_b_Click(object sender, EventArgs e)
        {
            stockitemview_p.Visible = true;
            stockitem_p.Visible = false;
        }

        //back button
        private void back_b_Click(object sender, EventArgs e)
        {
            stockitem_p.Visible = false;
            mainmenu_p.Visible = true;
        }

        //Panel 3 submenu stockupdate

        //
        private void enter_b_Click(object sender, EventArgs e)
        {            

        }

        //back button
        private void back1_b_Click(object sender, EventArgs e)
        {
            stockitemupdate_p.Visible = false;
            stockitem_p.Visible = true;
        }

        //Panel 4 submenu stockview

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

        //back to main menu from stock table
        private void back_stocktableupdate_b_Click(object sender, EventArgs e)
        {
            stocktableupdate_p.Visible = false;
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

            //smenu updatestock
            //this.enter_b.Left = (this.ClientSize.Width - this.enter_b.Width) / 2;
            //this.back1_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2;
            this.dataGridStockUpdate.Left = (this.ClientSize.Width - this.dataGridStockUpdate.Width) / 2;
            this.back_stocktableupdate_b.Left = (this.ClientSize.Width - this.back_stocktableupdate_b.Width) / 2;
            


            //smenu viewstock
            this.allstock_b.Left = (this.ClientSize.Width - this.viewcurrentstock_b.Width) / 2 - 150;
            this.enter1_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2 + 150;
            this.back2_b.Left = (this.ClientSize.Width - this.back_b.Width) / 2 + 150;            
            
            this.label_stocktable_id.Left = (this.ClientSize.Width - this.label_stocktable_id.Width) / 2 - 131;
            this.label_stocktable_name.Left = (this.ClientSize.Width - this.label_stocktable_name.Width) / 2 - 142;
            this.label_stocktable_attr.Left = (this.ClientSize.Width - this.label_stocktable_attr.Width) / 2 - 150;
            this.textbox_id.Left = (this.ClientSize.Width - this.textbox_id.Width) / 2 + 150;
            this.textbox_name.Left = (this.ClientSize.Width - this.textbox_name.Width) / 2 + 150;
            this.attribute_lst.Left = (this.ClientSize.Width - this.attribute_lst.Width) / 2 + 150;

            //smenu stocktable
            this.back_stocktable_b.Left = (this.ClientSize.Width - this.back_stocktable_b.Width) / 2;
            this.dataGridStock.Left = (this.ClientSize.Width - this.dataGridStock.Width) / 2;
            

        }
    }
}

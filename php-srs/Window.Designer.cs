namespace php_srs
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.stockitem_b = new System.Windows.Forms.Button();
            this.salesrecord_b = new System.Windows.Forms.Button();
            this.report_b = new System.Windows.Forms.Button();
            this.logout_b = new System.Windows.Forms.Button();
            this.quit_b = new System.Windows.Forms.Button();
            this.updatestock_b = new System.Windows.Forms.Button();
            this.viewcurrentstock_b = new System.Windows.Forms.Button();
            this.back_b = new System.Windows.Forms.Button();
            this.enter_b = new System.Windows.Forms.Button();
            this.back1_b = new System.Windows.Forms.Button();
            this.allstock_b = new System.Windows.Forms.Button();
            this.enter1_b = new System.Windows.Forms.Button();
            this.back2_b = new System.Windows.Forms.Button();
            this.loginstatus_l = new System.Windows.Forms.Label();
            this.record_l = new System.Windows.Forms.Label();
            this.mainmenu_p = new System.Windows.Forms.Panel();
            this.stockitem_p = new System.Windows.Forms.Panel();
            this.stockitemupdate_p = new System.Windows.Forms.Panel();
            this.stockitemview_p = new System.Windows.Forms.Panel();
            this.attribute_lst = new System.Windows.Forms.ListBox();
            this.label_stocktable_name = new System.Windows.Forms.Label();
            this.label_stocktable_id = new System.Windows.Forms.Label();
            this.label_stocktable_attr = new System.Windows.Forms.Label();
            this.textbox_id = new System.Windows.Forms.TextBox();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.heading_img = new System.Windows.Forms.Panel();
            this.stocktable_p = new System.Windows.Forms.Panel();
            this.back_stocktable_b = new System.Windows.Forms.Button();

            this.stocktableupdate_p = new System.Windows.Forms.Panel();
            this.back_stocktableupdate_b = new System.Windows.Forms.Button();

            this.dataGridStock = new System.Windows.Forms.DataGridView();
            this.dataGridStockUpdate = new System.Windows.Forms.DataGridView();            
            this.mainmenu_p.SuspendLayout();
            this.stockitem_p.SuspendLayout();
            this.stockitemupdate_p.SuspendLayout();
            this.stockitemview_p.SuspendLayout();
            this.stocktable_p.SuspendLayout();
            this.stocktableupdate_p.SuspendLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).BeginInit();
            this.SuspendLayout();
            // 
            // stockitem_b
            // 
            this.stockitem_b.Location = new System.Drawing.Point(70, 20);
            this.stockitem_b.Name = "stockitem_b";
            this.stockitem_b.Size = new System.Drawing.Size(250, 50);
            this.stockitem_b.TabIndex = 1;
            this.stockitem_b.Text = "Stock Items";
            this.stockitem_b.UseVisualStyleBackColor = true;
            this.stockitem_b.Click += new System.EventHandler(this.button1_Click);
            // 
            // salesrecord_b
            // 
            this.salesrecord_b.Location = new System.Drawing.Point(70, 95);
            this.salesrecord_b.Name = "salesrecord_b";
            this.salesrecord_b.Size = new System.Drawing.Size(250, 50);
            this.salesrecord_b.TabIndex = 2;
            this.salesrecord_b.Text = "Sales Records";
            this.salesrecord_b.UseVisualStyleBackColor = true;
            this.salesrecord_b.Click += new System.EventHandler(this.button2_Click);
            // 
            // report_b
            // 
            this.report_b.Location = new System.Drawing.Point(70, 170);
            this.report_b.Name = "report_b";
            this.report_b.Size = new System.Drawing.Size(250, 50);
            this.report_b.TabIndex = 3;
            this.report_b.Text = "Reports";
            this.report_b.UseVisualStyleBackColor = true;
            this.report_b.Click += new System.EventHandler(this.button3_Click);
            // 
            // logout_b
            // 
            this.logout_b.Location = new System.Drawing.Point(70, 245);
            this.logout_b.Name = "logout_b";
            this.logout_b.Size = new System.Drawing.Size(115, 50);
            this.logout_b.TabIndex = 4;
            this.logout_b.Text = "Log-out";
            this.logout_b.UseVisualStyleBackColor = true;
            this.logout_b.Click += new System.EventHandler(this.button4_Click);
            // 
            // quit_b
            // 
            this.quit_b.Location = new System.Drawing.Point(70, 245);
            this.quit_b.Name = "quit_b";
            this.quit_b.Size = new System.Drawing.Size(115, 50);
            this.quit_b.TabIndex = 5;
            this.quit_b.Text = "Quit";
            this.quit_b.UseVisualStyleBackColor = true;
            this.quit_b.Click += new System.EventHandler(this.button5_Click);
            // 
            // updatestock_b
            // 
            this.updatestock_b.Location = new System.Drawing.Point(275, 20);
            this.updatestock_b.Name = "updatestock_b";
            this.updatestock_b.Size = new System.Drawing.Size(250, 50);
            this.updatestock_b.TabIndex = 0;
            this.updatestock_b.Text = "Update Stock";
            this.updatestock_b.UseVisualStyleBackColor = true;
            this.updatestock_b.Click += new System.EventHandler(this.updatestock_b_Click);
            // 
            // viewcurrentstock_b
            // 
            this.viewcurrentstock_b.Location = new System.Drawing.Point(275, 95);
            this.viewcurrentstock_b.Name = "viewcurrentstock_b";
            this.viewcurrentstock_b.Size = new System.Drawing.Size(250, 50);
            this.viewcurrentstock_b.TabIndex = 1;
            this.viewcurrentstock_b.Text = "View Current Stock";
            this.viewcurrentstock_b.UseVisualStyleBackColor = true;
            this.viewcurrentstock_b.Click += new System.EventHandler(this.viewcurrentstock_b_Click);
            // 
            // back_b
            // 
            this.back_b.Location = new System.Drawing.Point(275, 170);
            this.back_b.Name = "back_b";
            this.back_b.Size = new System.Drawing.Size(250, 50);
            this.back_b.TabIndex = 2;
            this.back_b.Text = "Back";
            this.back_b.UseVisualStyleBackColor = true;
            this.back_b.Click += new System.EventHandler(this.back_b_Click);
            // 
            // enter_b
            // 
            this.enter_b.Location = new System.Drawing.Point(275, 20);
            this.enter_b.Name = "enter_b";
            this.enter_b.Size = new System.Drawing.Size(250, 50);
            this.enter_b.Text = "Enter";
            this.enter_b.UseVisualStyleBackColor = true;
            this.enter_b.Click += new System.EventHandler(this.enter_b_Click);
            // 
            // back1_b
            // 
            this.back1_b.Location = new System.Drawing.Point(275, 95);
            this.back1_b.Name = "back1_b";
            this.back1_b.Size = new System.Drawing.Size(250, 50);
            this.back1_b.Text = "Back";
            this.back1_b.UseVisualStyleBackColor = true;
            this.back1_b.Click += new System.EventHandler(this.back1_b_Click);
            // 
            // allstock_b
            // 
            this.allstock_b.Location = new System.Drawing.Point(70, 245);
            this.allstock_b.Name = "allstock_b";
            this.allstock_b.Size = new System.Drawing.Size(250, 50);
            this.allstock_b.Text = "Show All Stock";
            this.allstock_b.UseVisualStyleBackColor = true;
            this.allstock_b.Click += new System.EventHandler(this.allstock_b_Click);
            // 
            // enter1_b
            // 
            this.enter1_b.Location = new System.Drawing.Point(70, 245);
            this.enter1_b.Name = "enter1_b";
            this.enter1_b.Size = new System.Drawing.Size(250, 50);
            this.enter1_b.TabIndex = 2;
            this.enter1_b.Text = "Enter";
            this.enter1_b.UseVisualStyleBackColor = true;
            this.enter1_b.Click += new System.EventHandler(this.enter1_b_Click);

            // 
            // loginstatus_l
            // 
            this.loginstatus_l.AutoSize = true;
            this.loginstatus_l.BackColor = System.Drawing.Color.Transparent;
            this.loginstatus_l.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginstatus_l.Location = new System.Drawing.Point(5, 5);
            this.loginstatus_l.Name = "loginstatus_l";
            this.loginstatus_l.Size = new System.Drawing.Size(198, 16);
            this.loginstatus_l.TabIndex = 5;
            this.loginstatus_l.Text = "Currently Logged in as: Admin";            
            // 
            // record_l
            // 
            this.record_l.AutoSize = true;
            this.record_l.Location = new System.Drawing.Point(400, 20);
            this.record_l.Name = "record_l";
            this.record_l.Size = new System.Drawing.Size(97, 13);
            this.record_l.Text = "Record Information";
            // 
            // mainmenu_p
            // 
            this.mainmenu_p.BackColor = System.Drawing.Color.Transparent;
            this.mainmenu_p.Controls.Add(this.record_l);
            this.mainmenu_p.Controls.Add(this.quit_b);
            this.mainmenu_p.Controls.Add(this.stockitem_b);
            this.mainmenu_p.Controls.Add(this.logout_b);
            this.mainmenu_p.Controls.Add(this.salesrecord_b);
            this.mainmenu_p.Controls.Add(this.report_b);
            this.mainmenu_p.Location = new System.Drawing.Point(0, 240);
            this.mainmenu_p.Name = "mainmenu_p";
            this.mainmenu_p.Size = new System.Drawing.Size(1680, 1080);
            // 
            // stockitem_p
            // 
            this.stockitem_p.BackColor = System.Drawing.Color.Transparent;
            this.stockitem_p.Controls.Add(this.back_b);
            this.stockitem_p.Controls.Add(this.viewcurrentstock_b);
            this.stockitem_p.Controls.Add(this.updatestock_b);
            this.stockitem_p.Location = new System.Drawing.Point(0, 240);
            this.stockitem_p.Name = "stockitem_p";
            this.stockitem_p.Size = new System.Drawing.Size(1680, 1080);
            this.stockitem_p.Visible = false;
            // 
            // stockitemupdate_p
            // 
            this.stockitemupdate_p.BackColor = System.Drawing.Color.Transparent;
            this.stockitemupdate_p.Controls.Add(this.back1_b);
            this.stockitemupdate_p.Controls.Add(this.enter_b);
            this.stockitemupdate_p.Location = new System.Drawing.Point(0, 240);
            this.stockitemupdate_p.Name = "stockitemupdate_p";
            this.stockitemupdate_p.Size = new System.Drawing.Size(1680, 1080);
            this.stockitemupdate_p.TabIndex = 3;
            this.stockitemupdate_p.Visible = false;
            // 
            // stockitemview_p
            // 
            this.stockitemview_p.BackColor = System.Drawing.Color.Transparent;
            this.stockitemview_p.Controls.Add(this.allstock_b);
            this.stockitemview_p.Controls.Add(this.enter1_b);
            this.stockitemview_p.Controls.Add(this.back2_b);
            this.stockitemview_p.Controls.Add(this.attribute_lst);
            this.stockitemview_p.Controls.Add(this.label_stocktable_name);
            this.stockitemview_p.Controls.Add(this.label_stocktable_id);
            this.stockitemview_p.Controls.Add(this.label_stocktable_attr);
            this.stockitemview_p.Controls.Add(this.textbox_id);
            this.stockitemview_p.Controls.Add(this.textbox_name);
            this.stockitemview_p.Location = new System.Drawing.Point(0, 240);
            this.stockitemview_p.Name = "stockitemview_p";
            this.stockitemview_p.Size = new System.Drawing.Size(1680, 1080);
            this.stockitemview_p.TabIndex = 4;
            this.stockitemview_p.Visible = false;
            // 
            // attribute_lst
            // 
            this.attribute_lst.FormattingEnabled = true;
            this.attribute_lst.Location = new System.Drawing.Point(275, 170);
            this.attribute_lst.Name = "attribute_lst";
            this.attribute_lst.Size = new System.Drawing.Size(250, 43);
            this.attribute_lst.TabIndex = 3;
            // 
            // label_stocktable_name
            // 
            this.label_stocktable_name.AutoSize = false;
            this.label_stocktable_name.BackColor = System.Drawing.Color.White;
            this.label_stocktable_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_stocktable_name.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stocktable_name.Location = new System.Drawing.Point(5, 95);
            this.label_stocktable_name.Name = "label_stocktable_name";
            this.label_stocktable_name.Size = new System.Drawing.Size(82, 16);
            this.label_stocktable_name.Text = "Item Name: ";
            this.label_stocktable_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_stocktable_id
            // 
            this.label_stocktable_id.AutoSize = false;
            this.label_stocktable_id.BackColor = System.Drawing.Color.White;
            this.label_stocktable_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_stocktable_id.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stocktable_id.Location = new System.Drawing.Point(5, 20);
            this.label_stocktable_id.Name = "label_stocktable_id";
            this.label_stocktable_id.Size = new System.Drawing.Size(59, 16);
            this.label_stocktable_id.Text = "Item ID: ";
            this.label_stocktable_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_stocktable_attr
            // 
            this.label_stocktable_attr.AutoSize = false;
            this.label_stocktable_attr.BackColor = System.Drawing.Color.White;
            this.label_stocktable_attr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_stocktable_attr.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_stocktable_attr.Location = new System.Drawing.Point(5, 170);
            this.label_stocktable_attr.Name = "label_stocktable_attr";
            this.label_stocktable_attr.Size = new System.Drawing.Size(98, 16);
            this.label_stocktable_attr.Text = "Item Attribute: ";
            this.label_stocktable_attr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textbox_id
            // 
            this.textbox_id.AcceptsReturn = true;
            this.textbox_id.AcceptsTab = true;
            this.textbox_id.Location = new System.Drawing.Point(275, 20);
            this.textbox_id.Name = "textbox_id";
            this.textbox_id.Size = new System.Drawing.Size(250, 20);
            this.textbox_id.TabIndex = 7;
            // 
            // textbox_name
            // 
            this.textbox_name.AcceptsReturn = true;
            this.textbox_name.AcceptsTab = true;
            this.textbox_name.Location = new System.Drawing.Point(275, 95);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(250, 20);
            this.textbox_name.TabIndex = 8;
            // 
            // heading_img
            // 
            this.heading_img.BackColor = System.Drawing.Color.Transparent;
            this.heading_img.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heading_img.BackgroundImage")));
            this.heading_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heading_img.Location = new System.Drawing.Point(297, -100);
            this.heading_img.Name = "heading_img";
            this.heading_img.Size = new System.Drawing.Size(1000, 500);
            this.heading_img.TabIndex = 7;
            // 
            // stocktable_p
            // 
            this.stocktable_p.BackColor = System.Drawing.Color.Transparent;
            this.stocktable_p.Controls.Add(this.back_stocktable_b);
            this.stocktable_p.Controls.Add(this.dataGridStock);
            this.stocktable_p.Location = new System.Drawing.Point(0, 240);
            this.stocktable_p.Name = "stocktable_p";
            this.stocktable_p.Size = new System.Drawing.Size(1680, 1080);
            this.stocktable_p.Visible = false;
            // 
            // back_stocktable_b
            // 
            this.back_stocktable_b.Location = new System.Drawing.Point(70, 320);
            this.back_stocktable_b.Name = "back_stocktable_b";
            this.back_stocktable_b.Size = new System.Drawing.Size(250, 50);
            this.back_stocktable_b.TabIndex = 2;
            this.back_stocktable_b.Text = "Back";
            this.back_stocktable_b.UseVisualStyleBackColor = true;
            this.back_stocktable_b.Click += new System.EventHandler(this.back_stocktable_b_Click);

            // 
            // stocktableupdate_p
            // 
            this.stocktableupdate_p.BackColor = System.Drawing.Color.Transparent;
            this.stocktableupdate_p.Controls.Add(this.back_stocktableupdate_b);
            this.stocktableupdate_p.Controls.Add(this.dataGridStockUpdate);
            this.stocktableupdate_p.Location = new System.Drawing.Point(0, 240);
            this.stocktableupdate_p.Name = "stocktableupdate_p";
            this.stocktableupdate_p.Size = new System.Drawing.Size(1680, 1080);
            this.stocktableupdate_p.Visible = false;
            // 
            // back_stocktableupdate_b
            // 
            this.back_stocktableupdate_b.Location = new System.Drawing.Point(70, 320);
            this.back_stocktableupdate_b.Name = "back_stocktableupdate_b";
            this.back_stocktableupdate_b.Size = new System.Drawing.Size(250, 50);
            this.back_stocktableupdate_b.TabIndex = 2;
            this.back_stocktableupdate_b.Text = "Back";
            this.back_stocktableupdate_b.UseVisualStyleBackColor = true;
            this.back_stocktableupdate_b.Click += new System.EventHandler(this.back_stocktableupdate_b_Click);

            // 
            // dataGridStockUpdate
            // 
            this.dataGridStockUpdate.AllowUserToAddRows = true;
            this.dataGridStockUpdate.AllowUserToDeleteRows = true;
            this.dataGridStockUpdate.AllowUserToOrderColumns = true;
            this.dataGridStockUpdate.AllowUserToResizeColumns = false;
            this.dataGridStockUpdate.AllowUserToResizeRows = false;
            this.dataGridStockUpdate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridStockUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStockUpdate.Location = new System.Drawing.Point(30, 20);
            this.dataGridStockUpdate.Name = "dataGridStockUpdate";
            this.dataGridStockUpdate.ReadOnly = false;
            this.dataGridStockUpdate.Size = new System.Drawing.Size(800, 290);
            // 
            // dataGridStock
            // 
            this.dataGridStock.AllowUserToAddRows = false;
            this.dataGridStock.AllowUserToDeleteRows = false;
            this.dataGridStock.AllowUserToOrderColumns = true;
            this.dataGridStock.AllowUserToResizeColumns = false;
            this.dataGridStock.AllowUserToResizeRows = false;
            this.dataGridStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStock.Location = new System.Drawing.Point(30, 20);
            this.dataGridStock.Name = "dataGridStock";
            this.dataGridStock.ReadOnly = true;
            this.dataGridStock.Size = new System.Drawing.Size(800, 290);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mainmenu_p);
            this.Controls.Add(this.stockitem_p);
            this.Controls.Add(this.stocktable_p);
            this.Controls.Add(this.stockitemupdate_p);
            this.Controls.Add(this.stockitemview_p);
            this.Controls.Add(this.stocktableupdate_p);            
            this.Controls.Add(this.loginstatus_l);
            this.Controls.Add(this.heading_img);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Window";
            this.Text = "People Health Pharmacy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.window_Resize);
            this.mainmenu_p.ResumeLayout(false);
            this.mainmenu_p.PerformLayout();
            this.stockitem_p.ResumeLayout(false);
            this.stockitemupdate_p.ResumeLayout(false);
            this.stockitemview_p.ResumeLayout(false);
            this.stocktableupdate_p.ResumeLayout(false);            
            this.stockitemview_p.PerformLayout();
            this.stocktable_p.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //Labels
        private System.Windows.Forms.Label loginstatus_l;
        private System.Windows.Forms.Label record_l;

        private System.Windows.Forms.Label label_stocktable_id;
        private System.Windows.Forms.Label label_stocktable_name;
        private System.Windows.Forms.Label label_stocktable_attr;   

        //Buttons
        private System.Windows.Forms.Button stockitem_b;
        private System.Windows.Forms.Button salesrecord_b;
        private System.Windows.Forms.Button report_b;
        private System.Windows.Forms.Button logout_b;
        private System.Windows.Forms.Button quit_b;    
        private System.Windows.Forms.Button updatestock_b;
        private System.Windows.Forms.Button viewcurrentstock_b;
        private System.Windows.Forms.Button back_b;

        private System.Windows.Forms.Button enter_b;
        private System.Windows.Forms.Button back1_b;

        private System.Windows.Forms.Button allstock_b;
        private System.Windows.Forms.Button enter1_b;
        private System.Windows.Forms.Button back2_b;

        private System.Windows.Forms.Button back_stocktable_b;

        private System.Windows.Forms.Button back_stocktableupdate_b;        

        //Panels
        private System.Windows.Forms.Panel mainmenu_p;
        private System.Windows.Forms.Panel stockitem_p;
        private System.Windows.Forms.Panel stockitemupdate_p;
        private System.Windows.Forms.Panel stockitemview_p;
        private System.Windows.Forms.Panel heading_img;
        private System.Windows.Forms.Panel stocktable_p;
        private System.Windows.Forms.Panel stocktableupdate_p;
        


        //ListBox
        private System.Windows.Forms.ListBox attribute_lst;

        //GridDataView
        private System.Windows.Forms.DataGridView dataGridStock;
        private System.Windows.Forms.DataGridView dataGridStockUpdate;        

        //TextBox        
        private System.Windows.Forms.TextBox textbox_id;
        private System.Windows.Forms.TextBox textbox_name;
    }
}
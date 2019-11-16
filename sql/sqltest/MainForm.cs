namespace sqltest
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public class MainForm : Form
    {
        private IContainer components = null;
        private Button button1;
        private DataGridView dataGridView1;

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.123.226;database=mr;uid=sa;pwd=123";
            SqlConnection selectConnection = new SqlConnection(connectionString);
            selectConnection.Open();
            string selectCommandText = "Select * from test";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "table");
            this.dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
            selectConnection.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button1 = new Button();
            this.dataGridView1 = new DataGridView();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.button1.Location = new Point(0x146, 0xa8);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.Button1Click);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(390, 150);
            this.dataGridView1.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x19d, 0xc3);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.button1);
            base.Name = "MainForm";
            this.Text = "sqltest";
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }
    }
}


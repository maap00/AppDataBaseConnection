namespace AppDataBaseConnection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dgvWindDate = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvWindDate).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(479, 42);
            button1.Name = "button1";
            button1.Size = new Size(202, 47);
            button1.TabIndex = 1;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvWindDate
            // 
            dgvWindDate.AllowUserToAddRows = false;
            dgvWindDate.AllowUserToDeleteRows = false;
            dgvWindDate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWindDate.Location = new Point(12, 353);
            dgvWindDate.Name = "dgvWindDate";
            dgvWindDate.ReadOnly = true;
            dgvWindDate.RowHeadersWidth = 62;
            dgvWindDate.RowTemplate.Height = 33;
            dgvWindDate.Size = new Size(686, 286);
            dgvWindDate.TabIndex = 2;
            dgvWindDate.CellContentClick += dgvWindDate_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 644);
            Controls.Add(dgvWindDate);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWindDate).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DataGridView dgvWindDate;
    }
}

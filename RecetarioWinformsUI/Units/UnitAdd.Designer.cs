namespace RecetarioWinformsUI.Units
{
    partial class UnitAdd
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtAbbreviation = new TextBox();
            btnAddUnit = new Button();
            btnAddAndContinue = new Button();
            btnCancelUnit = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(159, 30);
            label1.TabIndex = 0;
            label1.Text = "Agregar Unidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 19);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 79);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Abreviación";
            // 
            // txtName
            // 
            txtName.Location = new Point(14, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(279, 23);
            txtName.TabIndex = 1;
            // 
            // txtAbbreviation
            // 
            txtAbbreviation.Location = new Point(14, 97);
            txtAbbreviation.Name = "txtAbbreviation";
            txtAbbreviation.Size = new Size(279, 23);
            txtAbbreviation.TabIndex = 2;
            // 
            // btnAddUnit
            // 
            btnAddUnit.CausesValidation = false;
            btnAddUnit.Location = new Point(27, 202);
            btnAddUnit.Name = "btnAddUnit";
            btnAddUnit.Size = new Size(70, 23);
            btnAddUnit.TabIndex = 3;
            btnAddUnit.Text = "&Agregar";
            btnAddUnit.UseVisualStyleBackColor = true;
            btnAddUnit.Click += btnAdd_Click;
            // 
            // btnAddAndContinue
            // 
            btnAddAndContinue.CausesValidation = false;
            btnAddAndContinue.Location = new Point(103, 202);
            btnAddAndContinue.Name = "btnAddAndContinue";
            btnAddAndContinue.Size = new Size(129, 23);
            btnAddAndContinue.TabIndex = 4;
            btnAddAndContinue.Text = "Agregar y Crear &Otra";
            btnAddAndContinue.UseVisualStyleBackColor = true;
            btnAddAndContinue.Click += btnAddAndContinue_Click;
            // 
            // btnCancelUnit
            // 
            btnCancelUnit.CausesValidation = false;
            btnCancelUnit.Location = new Point(238, 202);
            btnCancelUnit.Name = "btnCancelUnit";
            btnCancelUnit.Size = new Size(68, 23);
            btnCancelUnit.TabIndex = 5;
            btnCancelUnit.Text = "&Cancelar";
            btnCancelUnit.UseVisualStyleBackColor = true;
            btnCancelUnit.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtAbbreviation);
            groupBox1.Location = new Point(12, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 132);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // UnitAdd
            // 
            AcceptButton = btnAddUnit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelUnit;
            ClientSize = new Size(336, 247);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelUnit);
            Controls.Add(btnAddAndContinue);
            Controls.Add(btnAddUnit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UnitAdd";
            ShowInTaskbar = false;
            Text = "Agregar Unidad";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtAbbreviation;
        private Button btnAddUnit;
        private Button btnAddAndContinue;
        private Button btnCancelUnit;
        private GroupBox groupBox1;
    }
}
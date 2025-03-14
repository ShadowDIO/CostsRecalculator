namespace RecetarioWinformsUI.Units
{
    partial class UnitUpdate
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtAbbreviation = new TextBox();
            btnCancelUnit = new Button();
            btnUpdateUnit = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtAbbreviation);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 132);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
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
            // btnCancelUnit
            // 
            btnCancelUnit.CausesValidation = false;
            btnCancelUnit.Location = new Point(238, 206);
            btnCancelUnit.Name = "btnCancelUnit";
            btnCancelUnit.Size = new Size(68, 23);
            btnCancelUnit.TabIndex = 4;
            btnCancelUnit.Text = "&Cancelar";
            btnCancelUnit.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUnit
            // 
            btnUpdateUnit.CausesValidation = false;
            btnUpdateUnit.Location = new Point(153, 206);
            btnUpdateUnit.Name = "btnUpdateUnit";
            btnUpdateUnit.Size = new Size(70, 23);
            btnUpdateUnit.TabIndex = 3;
            btnUpdateUnit.Text = "&Actualizar";
            btnUpdateUnit.UseVisualStyleBackColor = true;
            btnUpdateUnit.Click += btnUpdateUnit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(138, 30);
            label1.TabIndex = 9;
            label1.Text = "Editar Unidad";
            // 
            // UnitUpdate
            // 
            AcceptButton = btnUpdateUnit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelUnit;
            ClientSize = new Size(338, 239);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelUnit);
            Controls.Add(btnUpdateUnit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UnitUpdate";
            ShowInTaskbar = false;
            Text = "Actualizar Unidad";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtAbbreviation;
        private Button btnCancelUnit;
        private Button btnAddAndContinue;
        private Button btnUpdateUnit;
        private Label label1;
    }
}
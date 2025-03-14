namespace RecetarioWinformsUI.Ingredients
{
    partial class UpdateIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateIngredient));
            btnCancel = new Button();
            btnAddIngredient = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label7 = new Label();
            txtAmountSoldBy = new NumericUpDown();
            txtEfficiency = new NumericUpDown();
            cbUnits = new ComboBox();
            txtCost = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtProvider = new RichTextBox();
            txtIngredientName = new RichTextBox();
            label6 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmountSoldBy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCost).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(308, 346);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddIngredient.Location = new Point(156, 346);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(136, 23);
            btnAddIngredient.TabIndex = 7;
            btnAddIngredient.Text = "&Actualizar Ingrediente";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += BtnAddIngredient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(217, 30);
            label1.TabIndex = 10;
            label1.Text = "Actualizar Ingrediente";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtAmountSoldBy);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(cbUnits);
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtProvider);
            groupBox1.Controls.Add(txtIngredientName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 259);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(130, 75);
            label7.Name = "label7";
            label7.Size = new Size(74, 30);
            label7.TabIndex = 32;
            label7.Text = "Cantidad\r\n por Compra";
            // 
            // txtAmountSoldBy
            // 
            txtAmountSoldBy.Location = new Point(130, 107);
            txtAmountSoldBy.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtAmountSoldBy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmountSoldBy.Name = "txtAmountSoldBy";
            txtAmountSoldBy.Size = new Size(91, 23);
            txtAmountSoldBy.TabIndex = 3;
            txtAmountSoldBy.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // txtEfficiency
            // 
            txtEfficiency.Location = new Point(227, 107);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.Size = new Size(91, 23);
            txtEfficiency.TabIndex = 4;
            txtEfficiency.Tag = "";
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // cbUnits
            // 
            cbUnits.DisplayMember = "Abbreviation";
            cbUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(324, 107);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(92, 23);
            cbUnits.TabIndex = 5;
            cbUnits.ValueMember = "Id";
            // 
            // txtCost
            // 
            txtCost.DecimalPlaces = 4;
            txtCost.Location = new Point(22, 108);
            txtCost.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(102, 23);
            txtCost.TabIndex = 2;
            txtCost.ThousandsSeparator = true;
            txtCost.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(227, 90);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 29;
            label5.Text = "Rendimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(324, 90);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 27;
            label4.Text = "Unidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 90);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 25;
            label3.Text = "Costo";
            // 
            // txtProvider
            // 
            txtProvider.Location = new Point(23, 163);
            txtProvider.Name = "txtProvider";
            txtProvider.Size = new Size(394, 82);
            txtProvider.TabIndex = 6;
            txtProvider.Text = "";
            // 
            // txtIngredientName
            // 
            txtIngredientName.Location = new Point(23, 52);
            txtIngredientName.Multiline = false;
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(394, 21);
            txtIngredientName.TabIndex = 1;
            txtIngredientName.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 140);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 24;
            label6.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 34);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 20;
            label2.Text = "Nombre";
            // 
            // UpdateIngredient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 390);
            Controls.Add(btnCancel);
            Controls.Add(btnAddIngredient);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateIngredient";
            ShowInTaskbar = false;
            Text = "Actualizar Ingrediente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmountSoldBy).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnAddIngredient;
        private Label label1;
        private GroupBox groupBox1;
        private RichTextBox txtProvider;
        private RichTextBox txtIngredientName;
        private Label label6;
        private Label label2;
        private Label label7;
        private NumericUpDown txtAmountSoldBy;
        private NumericUpDown txtEfficiency;
        private ComboBox cbUnits;
        private NumericUpDown txtCost;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}
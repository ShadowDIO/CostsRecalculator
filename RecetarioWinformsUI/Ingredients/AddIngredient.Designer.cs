namespace RecetarioWinformsUI.Ingredients
{
    partial class AddIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIngredient));
            groupBox1 = new GroupBox();
            label7 = new Label();
            txtAmountSoldBy = new NumericUpDown();
            txtProvider = new RichTextBox();
            txtEfficiency = new NumericUpDown();
            cbUnits = new ComboBox();
            txtCost = new NumericUpDown();
            txtIngredientName = new RichTextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnAddIngredient = new Button();
            btnCancel = new Button();
            btnAddAndContinue = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmountSoldBy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCost).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtAmountSoldBy);
            groupBox1.Controls.Add(txtProvider);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(cbUnits);
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(txtIngredientName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 259);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(131, 77);
            label7.Name = "label7";
            label7.Size = new Size(74, 30);
            label7.TabIndex = 11;
            label7.Text = "Cantidad\r\n por Compra";
            // 
            // txtAmountSoldBy
            // 
            txtAmountSoldBy.Location = new Point(131, 109);
            txtAmountSoldBy.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtAmountSoldBy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmountSoldBy.Name = "txtAmountSoldBy";
            txtAmountSoldBy.Size = new Size(91, 23);
            txtAmountSoldBy.TabIndex = 3;
            txtAmountSoldBy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtProvider
            // 
            txtProvider.Location = new Point(23, 163);
            txtProvider.Name = "txtProvider";
            txtProvider.Size = new Size(394, 82);
            txtProvider.TabIndex = 6;
            txtProvider.Text = "";
            // 
            // txtEfficiency
            // 
            txtEfficiency.Location = new Point(228, 109);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.Size = new Size(91, 23);
            txtEfficiency.TabIndex = 4;
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // cbUnits
            // 
            cbUnits.DisplayMember = "Abbreviation";
            cbUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(325, 109);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(92, 23);
            cbUnits.TabIndex = 5;
            cbUnits.ValueMember = "Id";
            // 
            // txtCost
            // 
            txtCost.DecimalPlaces = 4;
            txtCost.Location = new Point(23, 110);
            txtCost.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(102, 23);
            txtCost.TabIndex = 2;
            txtCost.ThousandsSeparator = true;
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
            label6.TabIndex = 4;
            label6.Text = "Proveedor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 92);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 3;
            label5.Text = "Rendimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(325, 92);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 2;
            label4.Text = "Unidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 92);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "Costo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 34);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(199, 30);
            label1.TabIndex = 1;
            label1.Text = "Agregar Ingrediente";
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddIngredient.Location = new Point(30, 355);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(136, 23);
            btnAddIngredient.TabIndex = 7;
            btnAddIngredient.Text = "&Agregar Ingrediente";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += BtnAddIngredient_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(308, 355);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddAndContinue
            // 
            btnAddAndContinue.CausesValidation = false;
            btnAddAndContinue.Location = new Point(172, 355);
            btnAddAndContinue.Name = "btnAddAndContinue";
            btnAddAndContinue.Size = new Size(129, 23);
            btnAddAndContinue.TabIndex = 8;
            btnAddAndContinue.Text = "Agregar y Crear &Otro";
            btnAddAndContinue.UseVisualStyleBackColor = true;
            btnAddAndContinue.Click += BtnAddAndContinue_Click;
            // 
            // AddIngredient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(462, 390);
            Controls.Add(btnAddAndContinue);
            Controls.Add(btnCancel);
            Controls.Add(btnAddIngredient);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddIngredient";
            ShowInTaskbar = false;
            Text = "Agregar Ingrediente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmountSoldBy).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnAddIngredient;
        private Button btnCancel;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnAddAndContinue;
        private NumericUpDown txtEfficiency;
        private ComboBox cbUnits;
        private NumericUpDown txtCost;
        private RichTextBox txtIngredientName;
        private RichTextBox txtProvider;
        private Label label7;
        private NumericUpDown txtAmountSoldBy;
    }
}
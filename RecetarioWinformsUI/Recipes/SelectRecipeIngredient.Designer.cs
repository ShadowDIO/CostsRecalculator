namespace RecetarioWinformsUI.Recipes
{
    partial class SelectRecipeIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRecipeIngredient));
            groupBox1 = new GroupBox();
            txtCalculatedEfficiency = new TextBox();
            label8 = new Label();
            txtUnits = new TextBox();
            txtProvider = new RichTextBox();
            label7 = new Label();
            txtCost = new TextBox();
            txtAmount = new NumericUpDown();
            txtEfficiency = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cbIngredientName = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            btnCancel = new Button();
            btnAccept = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtCalculatedEfficiency);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtUnits);
            groupBox1.Controls.Add(txtProvider);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(txtAmount);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbIngredientName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(443, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtCalculatedEfficiency
            // 
            txtCalculatedEfficiency.Enabled = false;
            txtCalculatedEfficiency.Location = new Point(175, 112);
            txtCalculatedEfficiency.Name = "txtCalculatedEfficiency";
            txtCalculatedEfficiency.PlaceholderText = "1";
            txtCalculatedEfficiency.ReadOnly = true;
            txtCalculatedEfficiency.Size = new Size(75, 23);
            txtCalculatedEfficiency.TabIndex = 16;
            txtCalculatedEfficiency.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(175, 80);
            label8.Name = "label8";
            label8.Size = new Size(75, 30);
            label8.TabIndex = 15;
            label8.Text = "Rendimiento\r\nCalculado\r\n";
            // 
            // txtUnits
            // 
            txtUnits.Enabled = false;
            txtUnits.Location = new Point(255, 112);
            txtUnits.Name = "txtUnits";
            txtUnits.PlaceholderText = ".";
            txtUnits.ReadOnly = true;
            txtUnits.Size = new Size(67, 23);
            txtUnits.TabIndex = 14;
            txtUnits.TabStop = false;
            // 
            // txtProvider
            // 
            txtProvider.Location = new Point(16, 160);
            txtProvider.Name = "txtProvider";
            txtProvider.ReadOnly = true;
            txtProvider.Size = new Size(413, 82);
            txtProvider.TabIndex = 13;
            txtProvider.TabStop = false;
            txtProvider.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 142);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 12;
            label7.Text = "Proveedor";
            // 
            // txtCost
            // 
            txtCost.Enabled = false;
            txtCost.Location = new Point(329, 113);
            txtCost.Name = "txtCost";
            txtCost.PlaceholderText = "$ 0.00";
            txtCost.ReadOnly = true;
            txtCost.Size = new Size(100, 23);
            txtCost.TabIndex = 11;
            txtCost.TabStop = false;
            // 
            // txtAmount
            // 
            txtAmount.DecimalPlaces = 4;
            txtAmount.Location = new Point(16, 113);
            txtAmount.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(72, 23);
            txtAmount.TabIndex = 2;
            txtAmount.ThousandsSeparator = true;
            txtAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmount.ValueChanged += TxtAmount_ValueChanged;
            // 
            // txtEfficiency
            // 
            txtEfficiency.Location = new Point(93, 114);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.Size = new Size(75, 23);
            txtEfficiency.TabIndex = 3;
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            txtEfficiency.ValueChanged += TxtEfficiency_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(329, 95);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 5;
            label6.Text = "Costo Calculado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(93, 95);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Rendimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(255, 95);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Unidades";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 95);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "Cantidad";
            // 
            // cbIngredientName
            // 
            cbIngredientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbIngredientName.DisplayMember = "IngredientName";
            cbIngredientName.FormattingEnabled = true;
            cbIngredientName.Location = new Point(16, 50);
            cbIngredientName.Name = "cbIngredientName";
            cbIngredientName.Size = new Size(413, 23);
            cbIngredientName.TabIndex = 1;
            cbIngredientName.ValueMember = "Id";
            cbIngredientName.SelectedValueChanged += CbIngredientName_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 32);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(230, 30);
            label1.TabIndex = 3;
            label1.Text = "Seleccionar Ingrediente";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(361, 323);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(259, 323);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(96, 23);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += BtnAccept_Click;
            // 
            // SelectRecipeIngredient
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(467, 358);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectRecipeIngredient";
            ShowInTaskbar = false;
            Text = "Seleccionar Ingrediente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cbIngredientName;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown txtEfficiency;
        private TextBox txtCost;
        private NumericUpDown txtAmount;
        private Button btnCancel;
        private Button btnAccept;
        private RichTextBox txtProvider;
        private Label label7;
        private TextBox txtUnits;
        private Label label8;
        private TextBox txtCalculatedEfficiency;
    }
}
namespace RecetarioWinformsUI.Recipes
{
    partial class SelectRecipeSubRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRecipeSubRecipe));
            btnAccept = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            cbUnits = new ComboBox();
            groupBox3 = new GroupBox();
            gvSubRecipe = new DataGridView();
            SubRecipeId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            btnViewRecipeSubRecipeView = new DataGridViewButtonColumn();
            txtSubRecipesCost = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtIngredientCosts = new TextBox();
            label1 = new Label();
            gvRecipeIngredients = new DataGridView();
            IngredientId = new DataGridViewTextBoxColumn();
            IngredientName = new DataGridViewTextBoxColumn();
            IngredientQuantity = new DataGridViewTextBoxColumn();
            IngredientUnit = new DataGridViewTextBoxColumn();
            IngredientEfficiency = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            txtCalculatedEfficiency = new NumericUpDown();
            label8 = new Label();
            txtCost = new TextBox();
            txtAmount = new NumericUpDown();
            txtEfficiency = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cbRecipeName = new ComboBox();
            label2 = new Label();
            SubRecipeRecipeName = new DataGridViewTextBoxColumn();
            SubRecipeAmountProduced = new DataGridViewTextBoxColumn();
            SubRecipeUnitAbreviation = new DataGridViewTextBoxColumn();
            SubRecipeEfficiency = new DataGridViewTextBoxColumn();
            SubRecipeCost = new DataGridViewTextBoxColumn();
            btnRemoveRecipeSubRecipeView = new DataGridViewButtonColumn();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipe).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCalculatedEfficiency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(442, 629);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(96, 23);
            btnAccept.TabIndex = 5;
            btnAccept.Text = "&Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += BtnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(544, 629);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cbUnits);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(txtCalculatedEfficiency);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(txtAmount);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbRecipeName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(626, 600);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // cbUnits
            // 
            cbUnits.DisplayMember = "Abbreviation";
            cbUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(265, 113);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(95, 23);
            cbUnits.Sorted = true;
            cbUnits.TabIndex = 4;
            cbUnits.ValueMember = "Id";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(gvSubRecipe);
            groupBox3.Controls.Add(txtSubRecipesCost);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(16, 372);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(595, 210);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "SubRecetas";
            // 
            // gvSubRecipe
            // 
            gvSubRecipe.AllowUserToAddRows = false;
            gvSubRecipe.AllowUserToDeleteRows = false;
            gvSubRecipe.AllowUserToOrderColumns = true;
            gvSubRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gvSubRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvSubRecipe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gvSubRecipe.BorderStyle = BorderStyle.Fixed3D;
            gvSubRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvSubRecipe.Columns.AddRange(new DataGridViewColumn[] { SubRecipeId, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, btnViewRecipeSubRecipeView });
            gvSubRecipe.Location = new Point(6, 36);
            gvSubRecipe.Name = "gvSubRecipe";
            gvSubRecipe.ReadOnly = true;
            gvSubRecipe.RowHeadersVisible = false;
            gvSubRecipe.RowTemplate.Height = 25;
            gvSubRecipe.Size = new Size(579, 140);
            gvSubRecipe.TabIndex = 16;
            gvSubRecipe.VirtualMode = true;
            gvSubRecipe.CellContentClick += GvSubRecipe_CellContentClick;
            gvSubRecipe.CellContentDoubleClick += GvSubRecipe_CellContentDoubleClick;
            // 
            // SubRecipeId
            // 
            SubRecipeId.DataPropertyName = "SubRecipeId";
            SubRecipeId.HeaderText = "RecipeId";
            SubRecipeId.Name = "SubRecipeId";
            SubRecipeId.ReadOnly = true;
            SubRecipeId.Visible = false;
            SubRecipeId.Width = 58;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "SubRecipeName";
            dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "SubRecipeQuantity";
            dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "SubRecipeUnit";
            dataGridViewTextBoxColumn3.HeaderText = "Unidad";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "SubRecipeEfficiency";
            dataGridViewTextBoxColumn4.HeaderText = "Rendimiento";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "SubRecipeCost";
            dataGridViewTextBoxColumn5.HeaderText = "Costo";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 63;
            // 
            // btnViewRecipeSubRecipeView
            // 
            btnViewRecipeSubRecipeView.HeaderText = "Ver";
            btnViewRecipeSubRecipeView.Name = "btnViewRecipeSubRecipeView";
            btnViewRecipeSubRecipeView.ReadOnly = true;
            btnViewRecipeSubRecipeView.SortMode = DataGridViewColumnSortMode.Automatic;
            btnViewRecipeSubRecipeView.Text = "Ver";
            btnViewRecipeSubRecipeView.UseColumnTextForButtonValue = true;
            btnViewRecipeSubRecipeView.Width = 48;
            // 
            // txtSubRecipesCost
            // 
            txtSubRecipesCost.Enabled = false;
            txtSubRecipesCost.Location = new Point(485, 182);
            txtSubRecipesCost.Name = "txtSubRecipesCost";
            txtSubRecipesCost.PlaceholderText = "$ 0.00";
            txtSubRecipesCost.ReadOnly = true;
            txtSubRecipesCost.Size = new Size(100, 23);
            txtSubRecipesCost.TabIndex = 15;
            txtSubRecipesCost.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(375, 185);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 14;
            label7.Text = "Costo SubRecetas:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtIngredientCosts);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(gvRecipeIngredients);
            groupBox2.Location = new Point(16, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(595, 213);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ingredientes";
            // 
            // txtIngredientCosts
            // 
            txtIngredientCosts.Enabled = false;
            txtIngredientCosts.Location = new Point(485, 184);
            txtIngredientCosts.Name = "txtIngredientCosts";
            txtIngredientCosts.PlaceholderText = "$ 0.00";
            txtIngredientCosts.ReadOnly = true;
            txtIngredientCosts.Size = new Size(100, 23);
            txtIngredientCosts.TabIndex = 13;
            txtIngredientCosts.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(372, 187);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 12;
            label1.Text = "Costo Ingredientes:";
            // 
            // gvRecipeIngredients
            // 
            gvRecipeIngredients.AllowUserToAddRows = false;
            gvRecipeIngredients.AllowUserToDeleteRows = false;
            gvRecipeIngredients.AllowUserToOrderColumns = true;
            gvRecipeIngredients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gvRecipeIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvRecipeIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gvRecipeIngredients.BorderStyle = BorderStyle.Fixed3D;
            gvRecipeIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvRecipeIngredients.Columns.AddRange(new DataGridViewColumn[] { IngredientId, IngredientName, IngredientQuantity, IngredientUnit, IngredientEfficiency, Cost });
            gvRecipeIngredients.Location = new Point(6, 35);
            gvRecipeIngredients.MultiSelect = false;
            gvRecipeIngredients.Name = "gvRecipeIngredients";
            gvRecipeIngredients.ReadOnly = true;
            gvRecipeIngredients.RowHeadersVisible = false;
            gvRecipeIngredients.RowTemplate.Height = 25;
            gvRecipeIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvRecipeIngredients.Size = new Size(583, 140);
            gvRecipeIngredients.TabIndex = 0;
            gvRecipeIngredients.VirtualMode = true;
            // 
            // IngredientId
            // 
            IngredientId.DataPropertyName = "Id";
            IngredientId.HeaderText = "IngredientId";
            IngredientId.Name = "IngredientId";
            IngredientId.ReadOnly = true;
            IngredientId.Visible = false;
            IngredientId.Width = 77;
            // 
            // IngredientName
            // 
            IngredientName.DataPropertyName = "IngredientName";
            IngredientName.HeaderText = "Nombre";
            IngredientName.Name = "IngredientName";
            IngredientName.ReadOnly = true;
            IngredientName.Width = 76;
            // 
            // IngredientQuantity
            // 
            IngredientQuantity.DataPropertyName = "IngredientQuantity";
            IngredientQuantity.HeaderText = "Cantidad";
            IngredientQuantity.Name = "IngredientQuantity";
            IngredientQuantity.ReadOnly = true;
            IngredientQuantity.Width = 80;
            // 
            // IngredientUnit
            // 
            IngredientUnit.DataPropertyName = "IngredientUnit";
            IngredientUnit.HeaderText = "Unidad";
            IngredientUnit.Name = "IngredientUnit";
            IngredientUnit.ReadOnly = true;
            IngredientUnit.Width = 70;
            // 
            // IngredientEfficiency
            // 
            IngredientEfficiency.DataPropertyName = "IngredientEfficiency";
            IngredientEfficiency.HeaderText = "Rendimiento";
            IngredientEfficiency.Name = "IngredientEfficiency";
            IngredientEfficiency.ReadOnly = true;
            // 
            // Cost
            // 
            Cost.DataPropertyName = "IngredientCost";
            Cost.HeaderText = "Costo Calculado";
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 109;
            // 
            // txtCalculatedEfficiency
            // 
            txtCalculatedEfficiency.Enabled = false;
            txtCalculatedEfficiency.Location = new Point(382, 113);
            txtCalculatedEfficiency.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtCalculatedEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtCalculatedEfficiency.Name = "txtCalculatedEfficiency";
            txtCalculatedEfficiency.ReadOnly = true;
            txtCalculatedEfficiency.Size = new Size(102, 23);
            txtCalculatedEfficiency.TabIndex = 16;
            txtCalculatedEfficiency.TabStop = false;
            txtCalculatedEfficiency.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(382, 80);
            label8.Name = "label8";
            label8.Size = new Size(75, 30);
            label8.TabIndex = 15;
            label8.Text = "Rendimiento\r\nCalculado\r\n";
            // 
            // txtCost
            // 
            txtCost.Enabled = false;
            txtCost.Location = new Point(505, 113);
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
            txtAmount.Size = new Size(105, 23);
            txtAmount.TabIndex = 2;
            txtAmount.ThousandsSeparator = true;
            txtAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmount.ValueChanged += TxtAmount_ValueChanged;
            // 
            // txtEfficiency
            // 
            txtEfficiency.Location = new Point(140, 113);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.Size = new Size(107, 23);
            txtEfficiency.TabIndex = 3;
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            txtEfficiency.ValueChanged += TxtEfficiency_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(507, 96);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 5;
            label6.Text = "Costo Calculado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(141, 94);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Rendimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 95);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 4;
            label4.Text = "Unidades";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 80);
            label3.Name = "label3";
            label3.Size = new Size(61, 30);
            label3.TabIndex = 3;
            label3.Text = "Cantidad\r\nProducida";
            // 
            // cbRecipeName
            // 
            cbRecipeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbRecipeName.DisplayMember = "RecipeName";
            cbRecipeName.FormattingEnabled = true;
            cbRecipeName.Location = new Point(16, 50);
            cbRecipeName.Name = "cbRecipeName";
            cbRecipeName.Size = new Size(589, 23);
            cbRecipeName.TabIndex = 1;
            cbRecipeName.ValueMember = "Id";
            cbRecipeName.SelectedValueChanged += CbRecipeName_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 32);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Receta";
            // 
            // SubRecipeRecipeName
            // 
            SubRecipeRecipeName.DataPropertyName = "RecipeName";
            SubRecipeRecipeName.Frozen = true;
            SubRecipeRecipeName.HeaderText = "Nombre";
            SubRecipeRecipeName.Name = "SubRecipeRecipeName";
            SubRecipeRecipeName.Width = 76;
            // 
            // SubRecipeAmountProduced
            // 
            SubRecipeAmountProduced.DataPropertyName = "AmountProduced";
            SubRecipeAmountProduced.Frozen = true;
            SubRecipeAmountProduced.HeaderText = "Cantidad";
            SubRecipeAmountProduced.Name = "SubRecipeAmountProduced";
            SubRecipeAmountProduced.Width = 80;
            // 
            // SubRecipeUnitAbreviation
            // 
            SubRecipeUnitAbreviation.DataPropertyName = "UnitAbbreviation";
            SubRecipeUnitAbreviation.Frozen = true;
            SubRecipeUnitAbreviation.HeaderText = "Unidad";
            SubRecipeUnitAbreviation.Name = "SubRecipeUnitAbreviation";
            SubRecipeUnitAbreviation.Width = 70;
            // 
            // SubRecipeEfficiency
            // 
            SubRecipeEfficiency.DataPropertyName = "RecipeEfficiency";
            SubRecipeEfficiency.Frozen = true;
            SubRecipeEfficiency.HeaderText = "Rendimiento";
            SubRecipeEfficiency.Name = "SubRecipeEfficiency";
            // 
            // SubRecipeCost
            // 
            SubRecipeCost.DataPropertyName = "RecipeCost";
            SubRecipeCost.Frozen = true;
            SubRecipeCost.HeaderText = "Costo Calculado";
            SubRecipeCost.Name = "SubRecipeCost";
            SubRecipeCost.Width = 109;
            // 
            // btnRemoveRecipeSubRecipeView
            // 
            btnRemoveRecipeSubRecipeView.Frozen = true;
            btnRemoveRecipeSubRecipeView.HeaderText = "Ver";
            btnRemoveRecipeSubRecipeView.Name = "btnRemoveRecipeSubRecipeView";
            btnRemoveRecipeSubRecipeView.Text = "Ver";
            btnRemoveRecipeSubRecipeView.UseColumnTextForButtonValue = true;
            btnRemoveRecipeSubRecipeView.Width = 29;
            // 
            // SelectRecipeSubRecipe
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(650, 664);
            Controls.Add(groupBox1);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectRecipeSubRecipe";
            Text = "Seleccionar Subreceta";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipe).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCalculatedEfficiency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        private GroupBox groupBox1;
        private NumericUpDown txtCalculatedEfficiency;
        private Label label8;
        private TextBox txtCost;
        private NumericUpDown txtAmount;
        private NumericUpDown txtEfficiency;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cbRecipeName;
        private Label label2;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private DataGridView gvRecipeIngredients;
        private ComboBox cbUnits;
        private TextBox txtSubRecipesCost;
        private Label label7;
        private TextBox txtIngredientCosts;
        private Label label1;
        private DataGridViewTextBoxColumn IngredientId;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn IngredientQuantity;
        private DataGridViewTextBoxColumn IngredientUnit;
        private DataGridViewTextBoxColumn IngredientEfficiency;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn SubRecipeRecipeName;
        private DataGridViewTextBoxColumn SubRecipeAmountProduced;
        private DataGridViewTextBoxColumn SubRecipeUnitAbreviation;
        private DataGridViewTextBoxColumn SubRecipeEfficiency;
        private DataGridViewTextBoxColumn SubRecipeCost;
        private DataGridViewButtonColumn btnRemoveRecipeSubRecipeView;
        private DataGridView gvSubRecipe;
        private DataGridViewTextBoxColumn SubRecipeId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn btnViewRecipeSubRecipeView;
    }
}
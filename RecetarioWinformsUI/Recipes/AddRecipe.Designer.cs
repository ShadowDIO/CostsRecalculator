namespace RecetarioWinformsUI.Recipes
{
    partial class AddRecipe
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecipe));
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtCost = new TextBox();
            label6 = new Label();
            txtEfficiency = new NumericUpDown();
            cbUnits = new ComboBox();
            txtAmount = new NumericUpDown();
            txtRecipeName = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtIngredientCosts = new TextBox();
            label7 = new Label();
            btnAddIngredient = new Button();
            gvRecipeIngredients = new DataGridView();
            IngredientId = new DataGridViewTextBoxColumn();
            IngredientName = new DataGridViewTextBoxColumn();
            IngredientQuantity = new DataGridViewTextBoxColumn();
            IngredientUnit = new DataGridViewTextBoxColumn();
            IngredientEfficiency = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            btnRemoveRecipeIngredient = new DataGridViewButtonColumn();
            groupBox3 = new GroupBox();
            txtSubRecipesCost = new TextBox();
            label8 = new Label();
            btnAddSubRecipe = new Button();
            gvSubRecipe = new DataGridView();
            SubRecipeId = new DataGridViewTextBoxColumn();
            SubRecipeRecipeName = new DataGridViewTextBoxColumn();
            SubRecipeAmountProduced = new DataGridViewTextBoxColumn();
            SubRecipeUnitAbreviation = new DataGridViewTextBoxColumn();
            SubRecipeEfficiency = new DataGridViewTextBoxColumn();
            SubRecipeCost = new DataGridViewTextBoxColumn();
            btnViewRecipeSubRecipeView = new DataGridViewButtonColumn();
            btnRemoveRecipeSubRecipe = new DataGridViewButtonColumn();
            btnAddRecipe = new Button();
            btnCancel = new Button();
            frmAddRecipeToolTip = new ToolTip(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipe).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(155, 30);
            label1.TabIndex = 2;
            label1.Text = "Agregar Receta";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(cbUnits);
            groupBox1.Controls.Add(txtAmount);
            groupBox1.Controls.Add(txtRecipeName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 158);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Generales";
            // 
            // txtCost
            // 
            txtCost.Enabled = false;
            txtCost.Location = new Point(454, 106);
            txtCost.Name = "txtCost";
            txtCost.PlaceholderText = "$ 0.00";
            txtCost.ReadOnly = true;
            txtCost.Size = new Size(100, 23);
            txtCost.TabIndex = 12;
            txtCost.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(454, 87);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 9;
            label6.Text = "Costo Calculado";
            // 
            // txtEfficiency
            // 
            txtEfficiency.Location = new Point(311, 106);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.Size = new Size(120, 23);
            txtEfficiency.TabIndex = 4;
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            txtEfficiency.ValueChanged += TxtEfficiency_ValueChanged;
            // 
            // cbUnits
            // 
            cbUnits.DisplayMember = "Abbreviation";
            cbUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnits.FormattingEnabled = true;
            cbUnits.Location = new Point(160, 105);
            cbUnits.Name = "cbUnits";
            cbUnits.Size = new Size(121, 23);
            cbUnits.Sorted = true;
            cbUnits.TabIndex = 3;
            cbUnits.ValueMember = "Id";
            // 
            // txtAmount
            // 
            txtAmount.DecimalPlaces = 4;
            txtAmount.Location = new Point(23, 105);
            txtAmount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(120, 23);
            txtAmount.TabIndex = 2;
            txtAmount.ThousandsSeparator = true;
            txtAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            txtAmount.ValueChanged += TxtAmount_ValueChanged;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(20, 52);
            txtRecipeName.Multiline = false;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(537, 21);
            txtRecipeName.TabIndex = 1;
            txtRecipeName.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 87);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 3;
            label5.Text = "Rendimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 87);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "Unidades";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 87);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 1;
            label3.Text = "Cantidad Producida";
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtIngredientCosts);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnAddIngredient);
            groupBox2.Controls.Add(gvRecipeIngredients);
            groupBox2.Location = new Point(12, 225);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(567, 217);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ingredientes";
            // 
            // txtIngredientCosts
            // 
            txtIngredientCosts.Enabled = false;
            txtIngredientCosts.Location = new Point(457, 184);
            txtIngredientCosts.Name = "txtIngredientCosts";
            txtIngredientCosts.PlaceholderText = "$ 0.00";
            txtIngredientCosts.ReadOnly = true;
            txtIngredientCosts.Size = new Size(100, 23);
            txtIngredientCosts.TabIndex = 15;
            txtIngredientCosts.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(344, 187);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 14;
            label7.Text = "Costo Ingredientes:";
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(529, 11);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(32, 23);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "+";
            frmAddRecipeToolTip.SetToolTip(btnAddIngredient, "Agregar Ingrediente l;a Receta");
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += BtnAddIngredient_Click;
            // 
            // gvRecipeIngredients
            // 
            gvRecipeIngredients.AllowUserToAddRows = false;
            gvRecipeIngredients.AllowUserToDeleteRows = false;
            gvRecipeIngredients.AllowUserToOrderColumns = true;
            gvRecipeIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvRecipeIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gvRecipeIngredients.BorderStyle = BorderStyle.Fixed3D;
            gvRecipeIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvRecipeIngredients.Columns.AddRange(new DataGridViewColumn[] { IngredientId, IngredientName, IngredientQuantity, IngredientUnit, IngredientEfficiency, Cost, btnRemoveRecipeIngredient });
            gvRecipeIngredients.Location = new Point(6, 35);
            gvRecipeIngredients.MultiSelect = false;
            gvRecipeIngredients.Name = "gvRecipeIngredients";
            gvRecipeIngredients.ReadOnly = true;
            gvRecipeIngredients.RowHeadersVisible = false;
            gvRecipeIngredients.RowTemplate.Height = 25;
            gvRecipeIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvRecipeIngredients.Size = new Size(555, 140);
            gvRecipeIngredients.TabIndex = 0;
            gvRecipeIngredients.VirtualMode = true;
            gvRecipeIngredients.CellContentClick += GvRecipeIngredients_CellContentClick;
            // 
            // IngredientId
            // 
            IngredientId.DataPropertyName = "IngredientId";
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
            Cost.HeaderText = "Costo";
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 63;
            // 
            // btnRemoveRecipeIngredient
            // 
            btnRemoveRecipeIngredient.HeaderText = "Remover";
            btnRemoveRecipeIngredient.Name = "btnRemoveRecipeIngredient";
            btnRemoveRecipeIngredient.ReadOnly = true;
            btnRemoveRecipeIngredient.Text = "Remover";
            btnRemoveRecipeIngredient.ToolTipText = "Remover este ingrediente de la Receta.";
            btnRemoveRecipeIngredient.UseColumnTextForButtonValue = true;
            btnRemoveRecipeIngredient.Width = 60;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtSubRecipesCost);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(btnAddSubRecipe);
            groupBox3.Controls.Add(gvSubRecipe);
            groupBox3.Location = new Point(6, 448);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(567, 219);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "SubRecetas";
            // 
            // txtSubRecipesCost
            // 
            txtSubRecipesCost.Enabled = false;
            txtSubRecipesCost.Location = new Point(460, 187);
            txtSubRecipesCost.Name = "txtSubRecipesCost";
            txtSubRecipesCost.PlaceholderText = "$ 0.00";
            txtSubRecipesCost.ReadOnly = true;
            txtSubRecipesCost.Size = new Size(100, 23);
            txtSubRecipesCost.TabIndex = 17;
            txtSubRecipesCost.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(350, 190);
            label8.Name = "label8";
            label8.Size = new Size(104, 15);
            label8.TabIndex = 16;
            label8.Text = "Costo SubRecetas:";
            // 
            // btnAddSubRecipe
            // 
            btnAddSubRecipe.Location = new Point(529, 10);
            btnAddSubRecipe.Name = "btnAddSubRecipe";
            btnAddSubRecipe.Size = new Size(32, 23);
            btnAddSubRecipe.TabIndex = 6;
            btnAddSubRecipe.Text = "+";
            frmAddRecipeToolTip.SetToolTip(btnAddSubRecipe, "Agregar Subreceta a la Receta.");
            btnAddSubRecipe.UseVisualStyleBackColor = true;
            btnAddSubRecipe.Click += BtnAddSubRecipe_Click;
            // 
            // gvSubRecipe
            // 
            gvSubRecipe.AllowUserToAddRows = false;
            gvSubRecipe.AllowUserToDeleteRows = false;
            gvSubRecipe.AllowUserToOrderColumns = true;
            gvSubRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvSubRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvSubRecipe.Columns.AddRange(new DataGridViewColumn[] { SubRecipeId, SubRecipeRecipeName, SubRecipeAmountProduced, SubRecipeUnitAbreviation, SubRecipeEfficiency, SubRecipeCost, btnViewRecipeSubRecipeView, btnRemoveRecipeSubRecipe });
            gvSubRecipe.Location = new Point(7, 34);
            gvSubRecipe.Name = "gvSubRecipe";
            gvSubRecipe.ReadOnly = true;
            gvSubRecipe.RowHeadersVisible = false;
            gvSubRecipe.RowTemplate.Height = 25;
            gvSubRecipe.Size = new Size(555, 140);
            gvSubRecipe.TabIndex = 1;
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
            // SubRecipeRecipeName
            // 
            SubRecipeRecipeName.DataPropertyName = "SubRecipeName";
            SubRecipeRecipeName.HeaderText = "Nombre";
            SubRecipeRecipeName.Name = "SubRecipeRecipeName";
            SubRecipeRecipeName.ReadOnly = true;
            SubRecipeRecipeName.Width = 76;
            // 
            // SubRecipeAmountProduced
            // 
            SubRecipeAmountProduced.DataPropertyName = "SubRecipeQuantity";
            SubRecipeAmountProduced.HeaderText = "Cantidad";
            SubRecipeAmountProduced.Name = "SubRecipeAmountProduced";
            SubRecipeAmountProduced.ReadOnly = true;
            SubRecipeAmountProduced.Width = 80;
            // 
            // SubRecipeUnitAbreviation
            // 
            SubRecipeUnitAbreviation.DataPropertyName = "SubRecipeUnit";
            SubRecipeUnitAbreviation.HeaderText = "Unidad";
            SubRecipeUnitAbreviation.Name = "SubRecipeUnitAbreviation";
            SubRecipeUnitAbreviation.ReadOnly = true;
            SubRecipeUnitAbreviation.Width = 70;
            // 
            // SubRecipeEfficiency
            // 
            SubRecipeEfficiency.DataPropertyName = "SubRecipeEfficiency";
            SubRecipeEfficiency.HeaderText = "Rendimiento";
            SubRecipeEfficiency.Name = "SubRecipeEfficiency";
            SubRecipeEfficiency.ReadOnly = true;
            // 
            // SubRecipeCost
            // 
            SubRecipeCost.DataPropertyName = "SubRecipeCost";
            SubRecipeCost.HeaderText = "Costo";
            SubRecipeCost.Name = "SubRecipeCost";
            SubRecipeCost.ReadOnly = true;
            SubRecipeCost.Width = 63;
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
            // btnRemoveRecipeSubRecipe
            // 
            btnRemoveRecipeSubRecipe.HeaderText = "Remover";
            btnRemoveRecipeSubRecipe.Name = "btnRemoveRecipeSubRecipe";
            btnRemoveRecipeSubRecipe.ReadOnly = true;
            btnRemoveRecipeSubRecipe.Resizable = DataGridViewTriState.True;
            btnRemoveRecipeSubRecipe.SortMode = DataGridViewColumnSortMode.Automatic;
            btnRemoveRecipeSubRecipe.Text = "Remover";
            btnRemoveRecipeSubRecipe.UseColumnTextForButtonValue = true;
            btnRemoveRecipeSubRecipe.Width = 79;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Location = new Point(426, 673);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(75, 23);
            btnAddRecipe.TabIndex = 7;
            btnAddRecipe.Text = "&Agregar";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += BtnAddRecipe_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(506, 673);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // frmAddRecipeToolTip
            // 
            frmAddRecipeToolTip.IsBalloon = true;
            frmAddRecipeToolTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // AddRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(591, 708);
            Controls.Add(btnCancel);
            Controls.Add(btnAddRecipe);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRecipe";
            ShowInTaskbar = false;
            Text = "Agregar Receta";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private NumericUpDown txtEfficiency;
        private ComboBox cbUnits;
        private NumericUpDown txtAmount;
        private RichTextBox txtRecipeName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView gvRecipeIngredients;
        private DataGridView gvSubRecipe;
        private Button btnAddRecipe;
        private Button btnCancel;
        private Button btnAddIngredient;
        private Button btnAddSubRecipe;
        private Label label6;
        private ToolTip frmAddRecipeToolTip;
        private TextBox txtCost;
        private TextBox txtIngredientCosts;
        private Label label7;
        private TextBox txtSubRecipesCost;
        private Label label8;
        private DataGridViewTextBoxColumn IngredientId;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn IngredientQuantity;
        private DataGridViewTextBoxColumn IngredientUnit;
        private DataGridViewTextBoxColumn IngredientEfficiency;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewButtonColumn btnRemoveRecipeIngredient;
        private DataGridViewTextBoxColumn SubRecipeId;
        private DataGridViewTextBoxColumn SubRecipeRecipeName;
        private DataGridViewTextBoxColumn SubRecipeAmountProduced;
        private DataGridViewTextBoxColumn SubRecipeUnitAbreviation;
        private DataGridViewTextBoxColumn SubRecipeEfficiency;
        private DataGridViewTextBoxColumn SubRecipeCost;
        private DataGridViewButtonColumn btnViewRecipeSubRecipeView;
        private DataGridViewButtonColumn btnRemoveRecipeSubRecipe;
    }
}
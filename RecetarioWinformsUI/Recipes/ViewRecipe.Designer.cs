namespace RecetarioWinformsUI.Recipes
{
    partial class ViewRecipe
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
            groupBox4 = new GroupBox();
            groupBox6 = new GroupBox();
            rbRecalculateByWeight = new RadioButton();
            rbRecalculateByCost = new RadioButton();
            groupBox5 = new GroupBox();
            rbRecalculateBySubRecipe = new RadioButton();
            rbRecalculateByIngredient = new RadioButton();
            rbRecalculateByRecipeTotal = new RadioButton();
            label9 = new Label();
            btnRecalculateRecipe = new Button();
            txtRecalculateValue = new NumericUpDown();
            label1 = new Label();
            cbRecalculateField = new ComboBox();
            groupBox3 = new GroupBox();
            txtSubRecipesCost = new TextBox();
            label8 = new Label();
            gvSubRecipes = new DataGridView();
            SubRecipeId = new DataGridViewTextBoxColumn();
            SubRecipeRecipeName = new DataGridViewTextBoxColumn();
            SubRecipeAmountProduced = new DataGridViewTextBoxColumn();
            SubRecipeUnitAbreviation = new DataGridViewTextBoxColumn();
            SubRecipeEfficiency = new DataGridViewTextBoxColumn();
            SubRecipeCost = new DataGridViewTextBoxColumn();
            btnViewRecipeSubRecipeView = new DataGridViewButtonColumn();
            groupBox2 = new GroupBox();
            txtIngredientCosts = new TextBox();
            label7 = new Label();
            gvRecipeIngredients = new DataGridView();
            IngredientId = new DataGridViewTextBoxColumn();
            IngredientName = new DataGridViewTextBoxColumn();
            IngredientQuantity = new DataGridViewTextBoxColumn();
            IngredientUnit = new DataGridViewTextBoxColumn();
            IngredientEfficiency = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            txtUnits = new TextBox();
            cbMarginEarnings = new ComboBox();
            label12 = new Label();
            txtSuggestedPrice = new TextBox();
            label11 = new Label();
            txtCost = new TextBox();
            label6 = new Label();
            txtEfficiency = new NumericUpDown();
            txtAmount = new NumericUpDown();
            txtRecipeName = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label10 = new Label();
            btnClose = new Button();
            lblRecipeName = new Label();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtRecalculateValue).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipes).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Controls.Add(groupBox5);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(btnRecalculateRecipe);
            groupBox4.Controls.Add(txtRecalculateValue);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(cbRecalculateField);
            groupBox4.Location = new Point(27, 80);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(567, 113);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Recalcular";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(rbRecalculateByWeight);
            groupBox6.Controls.Add(rbRecalculateByCost);
            groupBox6.Location = new Point(12, 14);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(102, 85);
            groupBox6.TabIndex = 13;
            groupBox6.TabStop = false;
            // 
            // rbRecalculateByWeight
            // 
            rbRecalculateByWeight.AutoSize = true;
            rbRecalculateByWeight.Location = new Point(11, 40);
            rbRecalculateByWeight.Name = "rbRecalculateByWeight";
            rbRecalculateByWeight.Size = new Size(71, 19);
            rbRecalculateByWeight.TabIndex = 3;
            rbRecalculateByWeight.Text = "Por Peso";
            rbRecalculateByWeight.UseVisualStyleBackColor = true;
            // 
            // rbRecalculateByCost
            // 
            rbRecalculateByCost.AutoSize = true;
            rbRecalculateByCost.Checked = true;
            rbRecalculateByCost.Location = new Point(11, 22);
            rbRecalculateByCost.Name = "rbRecalculateByCost";
            rbRecalculateByCost.Size = new Size(77, 19);
            rbRecalculateByCost.TabIndex = 2;
            rbRecalculateByCost.TabStop = true;
            rbRecalculateByCost.Text = "Por Costo";
            rbRecalculateByCost.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(rbRecalculateBySubRecipe);
            groupBox5.Controls.Add(rbRecalculateByIngredient);
            groupBox5.Controls.Add(rbRecalculateByRecipeTotal);
            groupBox5.Location = new Point(120, 14);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(161, 85);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            // 
            // rbRecalculateBySubRecipe
            // 
            rbRecalculateBySubRecipe.AutoSize = true;
            rbRecalculateBySubRecipe.Location = new Point(7, 60);
            rbRecalculateBySubRecipe.Name = "rbRecalculateBySubRecipe";
            rbRecalculateBySubRecipe.Size = new Size(80, 19);
            rbRecalculateBySubRecipe.TabIndex = 14;
            rbRecalculateBySubRecipe.Text = "SubReceta";
            rbRecalculateBySubRecipe.UseVisualStyleBackColor = true;
            rbRecalculateBySubRecipe.CheckedChanged += RbRecalculateBy_CheckedChanged;
            // 
            // rbRecalculateByIngredient
            // 
            rbRecalculateByIngredient.AutoSize = true;
            rbRecalculateByIngredient.Location = new Point(7, 37);
            rbRecalculateByIngredient.Name = "rbRecalculateByIngredient";
            rbRecalculateByIngredient.Size = new Size(85, 19);
            rbRecalculateByIngredient.TabIndex = 13;
            rbRecalculateByIngredient.Text = "Ingrediente";
            rbRecalculateByIngredient.UseVisualStyleBackColor = true;
            rbRecalculateByIngredient.CheckedChanged += RbRecalculateBy_CheckedChanged;
            // 
            // rbRecalculateByRecipeTotal
            // 
            rbRecalculateByRecipeTotal.AutoSize = true;
            rbRecalculateByRecipeTotal.Checked = true;
            rbRecalculateByRecipeTotal.Location = new Point(7, 16);
            rbRecalculateByRecipeTotal.Name = "rbRecalculateByRecipeTotal";
            rbRecalculateByRecipeTotal.Size = new Size(104, 19);
            rbRecalculateByRecipeTotal.TabIndex = 12;
            rbRecalculateByRecipeTotal.TabStop = true;
            rbRecalculateByRecipeTotal.Text = "Total de Receta";
            rbRecalculateByRecipeTotal.UseVisualStyleBackColor = true;
            rbRecalculateByRecipeTotal.CheckedChanged += RbRecalculateBy_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(311, 14);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 8;
            label9.Text = "Valor";
            // 
            // btnRecalculateRecipe
            // 
            btnRecalculateRecipe.Location = new Point(473, 30);
            btnRecalculateRecipe.Name = "btnRecalculateRecipe";
            btnRecalculateRecipe.Size = new Size(75, 23);
            btnRecalculateRecipe.TabIndex = 7;
            btnRecalculateRecipe.Text = "&Recalcular";
            btnRecalculateRecipe.UseVisualStyleBackColor = true;
            btnRecalculateRecipe.Click += BtnRecalculateRecipe_Click;
            // 
            // txtRecalculateValue
            // 
            txtRecalculateValue.DecimalPlaces = 2;
            txtRecalculateValue.Location = new Point(311, 32);
            txtRecalculateValue.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtRecalculateValue.Minimum = new decimal(new int[] { 1, 0, 0, 327680 });
            txtRecalculateValue.Name = "txtRecalculateValue";
            txtRecalculateValue.Size = new Size(120, 23);
            txtRecalculateValue.TabIndex = 6;
            txtRecalculateValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(311, 58);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 3;
            label1.Text = "Campo";
            // 
            // cbRecalculateField
            // 
            cbRecalculateField.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbRecalculateField.DisplayMember = "Value";
            cbRecalculateField.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRecalculateField.Enabled = false;
            cbRecalculateField.FormattingEnabled = true;
            cbRecalculateField.Location = new Point(311, 76);
            cbRecalculateField.Name = "cbRecalculateField";
            cbRecalculateField.Size = new Size(121, 23);
            cbRecalculateField.TabIndex = 2;
            cbRecalculateField.ValueMember = "Id";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtSubRecipesCost);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(gvSubRecipes);
            groupBox3.Location = new Point(27, 626);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(567, 219);
            groupBox3.TabIndex = 16;
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
            // gvSubRecipes
            // 
            gvSubRecipes.AllowUserToAddRows = false;
            gvSubRecipes.AllowUserToDeleteRows = false;
            gvSubRecipes.AllowUserToOrderColumns = true;
            gvSubRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvSubRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvSubRecipes.Columns.AddRange(new DataGridViewColumn[] { SubRecipeId, SubRecipeRecipeName, SubRecipeAmountProduced, SubRecipeUnitAbreviation, SubRecipeEfficiency, SubRecipeCost, btnViewRecipeSubRecipeView });
            gvSubRecipes.Location = new Point(7, 34);
            gvSubRecipes.MultiSelect = false;
            gvSubRecipes.Name = "gvSubRecipes";
            gvSubRecipes.ReadOnly = true;
            gvSubRecipes.RowHeadersVisible = false;
            gvSubRecipes.RowTemplate.Height = 25;
            gvSubRecipes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvSubRecipes.Size = new Size(555, 140);
            gvSubRecipes.TabIndex = 1;
            gvSubRecipes.CellContentClick += GvSubRecipes_CellContentClick;
            gvSubRecipes.CellContentDoubleClick += GvSubRecipes_CellContentDoubleClick;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtIngredientCosts);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(gvRecipeIngredients);
            groupBox2.Location = new Point(27, 403);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(567, 217);
            groupBox2.TabIndex = 15;
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
            // gvRecipeIngredients
            // 
            gvRecipeIngredients.AllowUserToAddRows = false;
            gvRecipeIngredients.AllowUserToDeleteRows = false;
            gvRecipeIngredients.AllowUserToOrderColumns = true;
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
            gvRecipeIngredients.Size = new Size(555, 140);
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
            Cost.HeaderText = "Costo";
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 63;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUnits);
            groupBox1.Controls.Add(cbMarginEarnings);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtSuggestedPrice);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtCost);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtEfficiency);
            groupBox1.Controls.Add(txtAmount);
            groupBox1.Controls.Add(txtRecipeName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(27, 198);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 199);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Generales";
            // 
            // txtUnits
            // 
            txtUnits.Enabled = false;
            txtUnits.Location = new Point(160, 106);
            txtUnits.Name = "txtUnits";
            txtUnits.ReadOnly = true;
            txtUnits.Size = new Size(127, 23);
            txtUnits.TabIndex = 17;
            // 
            // cbMarginEarnings
            // 
            cbMarginEarnings.DisplayMember = "Value";
            cbMarginEarnings.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMarginEarnings.FormattingEnabled = true;
            cbMarginEarnings.Location = new Point(454, 160);
            cbMarginEarnings.Name = "cbMarginEarnings";
            cbMarginEarnings.Size = new Size(103, 23);
            cbMarginEarnings.Sorted = true;
            cbMarginEarnings.TabIndex = 16;
            cbMarginEarnings.SelectedIndexChanged += CbMarginEarnings_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(454, 142);
            label12.Name = "label12";
            label12.Size = new Size(92, 15);
            label12.TabIndex = 15;
            label12.Text = "Margen Utilidad";
            // 
            // txtSuggestedPrice
            // 
            txtSuggestedPrice.Enabled = false;
            txtSuggestedPrice.Location = new Point(311, 160);
            txtSuggestedPrice.Name = "txtSuggestedPrice";
            txtSuggestedPrice.PlaceholderText = "$ 0.00";
            txtSuggestedPrice.ReadOnly = true;
            txtSuggestedPrice.Size = new Size(120, 23);
            txtSuggestedPrice.TabIndex = 14;
            txtSuggestedPrice.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(298, 142);
            label11.Name = "label11";
            label11.Size = new Size(133, 15);
            label11.TabIndex = 13;
            label11.Text = "Precio Público Sugerido";
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
            txtEfficiency.Enabled = false;
            txtEfficiency.Location = new Point(311, 106);
            txtEfficiency.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            txtEfficiency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtEfficiency.Name = "txtEfficiency";
            txtEfficiency.ReadOnly = true;
            txtEfficiency.Size = new Size(120, 23);
            txtEfficiency.TabIndex = 4;
            txtEfficiency.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // txtAmount
            // 
            txtAmount.DecimalPlaces = 4;
            txtAmount.Enabled = false;
            txtAmount.Location = new Point(23, 105);
            txtAmount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtAmount.Name = "txtAmount";
            txtAmount.ReadOnly = true;
            txtAmount.Size = new Size(120, 23);
            txtAmount.TabIndex = 2;
            txtAmount.ThousandsSeparator = true;
            txtAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtRecipeName
            // 
            txtRecipeName.Enabled = false;
            txtRecipeName.Location = new Point(20, 52);
            txtRecipeName.Multiline = false;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.ReadOnly = true;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(27, 15);
            label10.Name = "label10";
            label10.Size = new Size(250, 30);
            label10.TabIndex = 18;
            label10.Text = "Detalles Receta y Costeos";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(514, 864);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 19;
            btnClose.Text = "&Cerrar";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblRecipeName.Location = new Point(78, 51);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(138, 25);
            lblRecipeName.TabIndex = 20;
            lblRecipeName.Text = "lblRecipeName";
            // 
            // ViewRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 899);
            Controls.Add(lblRecipeName);
            Controls.Add(btnClose);
            Controls.Add(label10);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ViewRecipe";
            Text = "Ver Receta";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtRecalculateValue).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvSubRecipes).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipeIngredients).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEfficiency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox4;
        private Button btnRecalculateRecipe;
        private NumericUpDown txtRecalculateValue;
        private Label label1;
        private ComboBox cbRecalculateField;
        private GroupBox groupBox3;
        private TextBox txtSubRecipesCost;
        private Label label8;
        private DataGridView gvSubRecipes;
        private DataGridViewTextBoxColumn SubRecipeId;
        private DataGridViewTextBoxColumn SubRecipeRecipeName;
        private DataGridViewTextBoxColumn SubRecipeAmountProduced;
        private DataGridViewTextBoxColumn SubRecipeUnitAbreviation;
        private DataGridViewTextBoxColumn SubRecipeEfficiency;
        private DataGridViewTextBoxColumn SubRecipeCost;
        private DataGridViewButtonColumn btnViewRecipeSubRecipeView;
        private GroupBox groupBox2;
        private TextBox txtIngredientCosts;
        private Label label7;
        private DataGridView gvRecipeIngredients;
        private GroupBox groupBox1;
        private TextBox txtCost;
        private Label label6;
        private NumericUpDown txtEfficiency;
        private NumericUpDown txtAmount;
        private RichTextBox txtRecipeName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
        private Label label10;
        private ComboBox cbMarginEarnings;
        private Label label12;
        private TextBox txtSuggestedPrice;
        private Label label11;
        private Button btnClose;
        private GroupBox groupBox6;
        private RadioButton rbRecalculateByWeight;
        private RadioButton rbRecalculateByCost;
        private GroupBox groupBox5;
        private RadioButton rbRecalculateBySubRecipe;
        private RadioButton rbRecalculateByIngredient;
        private RadioButton rbRecalculateByRecipeTotal;
        private TextBox txtUnits;
        private DataGridViewTextBoxColumn IngredientId;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn IngredientQuantity;
        private DataGridViewTextBoxColumn IngredientUnit;
        private DataGridViewTextBoxColumn IngredientEfficiency;
        private DataGridViewTextBoxColumn Cost;
        private Label lblRecipeName;
    }
}
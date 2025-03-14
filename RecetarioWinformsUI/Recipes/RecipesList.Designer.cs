namespace RecetarioWinformsUI.Recipes
{
    partial class RecipesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipesList));
            groupBox1 = new GroupBox();
            gvRecipes = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            RecipeName = new DataGridViewTextBoxColumn();
            RecipeEfficiency = new DataGridViewTextBoxColumn();
            RecipeCost = new DataGridViewTextBoxColumn();
            txtSearchRecipeName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnCancel = new Button();
            btnUpdateRecipe = new Button();
            btnAddRecipe = new Button();
            btnViewRecipe = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(gvRecipes);
            groupBox1.Controls.Add(txtSearchRecipeName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(694, 396);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // gvRecipes
            // 
            gvRecipes.AllowUserToAddRows = false;
            gvRecipes.AllowUserToDeleteRows = false;
            gvRecipes.AllowUserToOrderColumns = true;
            gvRecipes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvRecipes.Columns.AddRange(new DataGridViewColumn[] { Id, RecipeName, RecipeEfficiency, RecipeCost });
            gvRecipes.Location = new Point(6, 66);
            gvRecipes.MultiSelect = false;
            gvRecipes.Name = "gvRecipes";
            gvRecipes.ReadOnly = true;
            gvRecipes.RowHeadersVisible = false;
            gvRecipes.RowTemplate.Height = 25;
            gvRecipes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvRecipes.Size = new Size(682, 324);
            gvRecipes.StandardTab = true;
            gvRecipes.TabIndex = 6;
            gvRecipes.VirtualMode = true;
            gvRecipes.CellDoubleClick += GvRecipes_CellDoubleClick;
            gvRecipes.CellFormatting += GvRecipes_CellFormatting;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // RecipeName
            // 
            RecipeName.DataPropertyName = "RecipeName";
            RecipeName.HeaderText = "Nombre";
            RecipeName.Name = "RecipeName";
            RecipeName.ReadOnly = true;
            RecipeName.Width = 76;
            // 
            // RecipeEfficiency
            // 
            RecipeEfficiency.DataPropertyName = "RecipeEfficiency";
            RecipeEfficiency.HeaderText = "Rendimiento";
            RecipeEfficiency.Name = "RecipeEfficiency";
            RecipeEfficiency.ReadOnly = true;
            // 
            // RecipeCost
            // 
            RecipeCost.DataPropertyName = "RecipeCost";
            RecipeCost.HeaderText = "Costo de Prod";
            RecipeCost.Name = "RecipeCost";
            RecipeCost.ReadOnly = true;
            RecipeCost.Width = 107;
            // 
            // txtSearchRecipeName
            // 
            txtSearchRecipeName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchRecipeName.Location = new Point(6, 37);
            txtSearchRecipeName.Name = "txtSearchRecipeName";
            txtSearchRecipeName.Size = new Size(682, 23);
            txtSearchRecipeName.TabIndex = 5;
            txtSearchRecipeName.TextChanged += TxtSearchRecipeName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 2;
            label2.Text = "Buscar Recetas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 30);
            label1.TabIndex = 2;
            label1.Text = "Recetario";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(709, 129);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnUpdateRecipe
            // 
            btnUpdateRecipe.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdateRecipe.Location = new Point(709, 100);
            btnUpdateRecipe.Name = "btnUpdateRecipe";
            btnUpdateRecipe.Size = new Size(136, 23);
            btnUpdateRecipe.TabIndex = 8;
            btnUpdateRecipe.Text = "&Modificar Receta";
            btnUpdateRecipe.UseVisualStyleBackColor = true;
            btnUpdateRecipe.Click += BtnUpdateRecipe_Click;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddRecipe.Location = new Point(709, 71);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(136, 23);
            btnAddRecipe.TabIndex = 7;
            btnAddRecipe.Text = "&Agregar Receta";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += BtnAddRecipe_Click;
            // 
            // btnViewRecipe
            // 
            btnViewRecipe.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewRecipe.Enabled = false;
            btnViewRecipe.Location = new Point(709, 42);
            btnViewRecipe.Name = "btnViewRecipe";
            btnViewRecipe.Size = new Size(136, 23);
            btnViewRecipe.TabIndex = 10;
            btnViewRecipe.Text = "&Ver Receta";
            btnViewRecipe.UseVisualStyleBackColor = true;
            btnViewRecipe.Click += BtnViewRecipe_Click;
            // 
            // RecipesList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(857, 450);
            Controls.Add(btnViewRecipe);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdateRecipe);
            Controls.Add(btnAddRecipe);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RecipesList";
            Text = "Lista Recetas";
            FormClosing += RecipesList_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvRecipes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox txtSearchRecipeName;
        private DataGridView gvRecipes;
        private Button btnCancel;
        private Button btnUpdateRecipe;
        private Button btnAddRecipe;
        private Button btnViewRecipe;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn RecipeName;
        private DataGridViewTextBoxColumn RecipeEfficiency;
        private DataGridViewTextBoxColumn RecipeCost;
    }
}
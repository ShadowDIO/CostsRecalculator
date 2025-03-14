namespace RecetarioWinformsUI.Ingredients
{
    partial class IngredientsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngredientsList));
            groupBox1 = new GroupBox();
            txtSearchIngredient = new TextBox();
            rdProvider = new RadioButton();
            rdName = new RadioButton();
            label2 = new Label();
            gvIngredients = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            IngredientName = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            AmountSoldBy = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            Efficiency = new DataGridViewTextBoxColumn();
            Provider = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnCancel = new Button();
            btnUpdateIngredient = new Button();
            btnAddIngredient = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvIngredients).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtSearchIngredient);
            groupBox1.Controls.Add(rdProvider);
            groupBox1.Controls.Add(rdName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(gvIngredients);
            groupBox1.Location = new Point(12, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(624, 374);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtSearchIngredient
            // 
            txtSearchIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchIngredient.Location = new Point(6, 42);
            txtSearchIngredient.Name = "txtSearchIngredient";
            txtSearchIngredient.Size = new Size(612, 23);
            txtSearchIngredient.TabIndex = 3;
            txtSearchIngredient.TextChanged += TxtSearchIngredient_TextChanged;
            // 
            // rdProvider
            // 
            rdProvider.AutoSize = true;
            rdProvider.Location = new Point(206, 17);
            rdProvider.Name = "rdProvider";
            rdProvider.Size = new Size(79, 19);
            rdProvider.TabIndex = 2;
            rdProvider.Text = "Proveedor";
            rdProvider.UseVisualStyleBackColor = true;
            rdProvider.CheckedChanged += RdProvider_CheckedChanged;
            // 
            // rdName
            // 
            rdName.AutoSize = true;
            rdName.Checked = true;
            rdName.Location = new Point(131, 17);
            rdName.Name = "rdName";
            rdName.Size = new Size(69, 19);
            rdName.TabIndex = 1;
            rdName.TabStop = true;
            rdName.Text = "Nombre";
            rdName.UseVisualStyleBackColor = true;
            rdName.CheckedChanged += RdName_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Buscar Ingredientes";
            // 
            // gvIngredients
            // 
            gvIngredients.AllowUserToAddRows = false;
            gvIngredients.AllowUserToDeleteRows = false;
            gvIngredients.AllowUserToOrderColumns = true;
            gvIngredients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvIngredients.Columns.AddRange(new DataGridViewColumn[] { Id, IngredientName, Cost, AmountSoldBy, UnitName, Efficiency, Provider });
            gvIngredients.Location = new Point(6, 78);
            gvIngredients.MultiSelect = false;
            gvIngredients.Name = "gvIngredients";
            gvIngredients.ReadOnly = true;
            gvIngredients.RowHeadersVisible = false;
            gvIngredients.RowTemplate.Height = 25;
            gvIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvIngredients.Size = new Size(612, 290);
            gvIngredients.StandardTab = true;
            gvIngredients.TabIndex = 4;
            gvIngredients.VirtualMode = true;
            gvIngredients.CellDoubleClick += GvIngredients_CellDoubleClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 23;
            // 
            // IngredientName
            // 
            IngredientName.DataPropertyName = "IngredientName";
            IngredientName.HeaderText = "Nombre";
            IngredientName.Name = "IngredientName";
            IngredientName.ReadOnly = true;
            IngredientName.Width = 76;
            // 
            // Cost
            // 
            Cost.DataPropertyName = "Cost";
            Cost.HeaderText = "Costo";
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 63;
            // 
            // AmountSoldBy
            // 
            AmountSoldBy.DataPropertyName = "AmountSoldBy";
            AmountSoldBy.HeaderText = "Cantidad por Venta";
            AmountSoldBy.Name = "AmountSoldBy";
            AmountSoldBy.ReadOnly = true;
            AmountSoldBy.Width = 96;
            // 
            // UnitName
            // 
            UnitName.DataPropertyName = "UnitName";
            UnitName.HeaderText = "Unidad";
            UnitName.Name = "UnitName";
            UnitName.ReadOnly = true;
            UnitName.Width = 70;
            // 
            // Efficiency
            // 
            Efficiency.DataPropertyName = "Efficiency";
            Efficiency.HeaderText = "Rendimiento";
            Efficiency.Name = "Efficiency";
            Efficiency.ReadOnly = true;
            // 
            // Provider
            // 
            Provider.DataPropertyName = "Provider";
            Provider.HeaderText = "Proveedor";
            Provider.Name = "Provider";
            Provider.ReadOnly = true;
            Provider.Width = 86;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(289, 30);
            label1.TabIndex = 1;
            label1.Text = "Lista Ingredientes Disponibles";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(642, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnUpdateIngredient
            // 
            btnUpdateIngredient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdateIngredient.Location = new Point(642, 93);
            btnUpdateIngredient.Name = "btnUpdateIngredient";
            btnUpdateIngredient.Size = new Size(136, 23);
            btnUpdateIngredient.TabIndex = 6;
            btnUpdateIngredient.Text = "&Modificar Ingrediente";
            btnUpdateIngredient.UseVisualStyleBackColor = true;
            btnUpdateIngredient.Click += BtnUpdateIngredient_Click;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddIngredient.Location = new Point(642, 64);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(136, 23);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "&Agregar Ingrediente";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += BtnAddIngredient_Click;
            // 
            // IngredientsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(786, 431);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdateIngredient);
            Controls.Add(btnAddIngredient);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "IngredientsList";
            ShowInTaskbar = false;
            Text = "Ingredientes";
            FormClosing += IngredientsList_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView gvIngredients;
        private Label label1;
        private Button btnCancel;
        private Button btnUpdateIngredient;
        private Button btnAddIngredient;
        private TextBox txtSearchIngredient;
        private RadioButton rdProvider;
        private RadioButton rdName;
        private Label label2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn IngredientName;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn AmountSoldBy;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn Efficiency;
        private DataGridViewTextBoxColumn Provider;
    }
}
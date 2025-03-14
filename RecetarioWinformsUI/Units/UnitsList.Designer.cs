namespace RecetarioWinformsUI
{
    partial class UnitsList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            GridViewUnits = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            Abbreviation = new DataGridViewTextBoxColumn();
            btnAddUnit = new Button();
            btnUpdateUnit = new Button();
            label1 = new Label();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)GridViewUnits).BeginInit();
            SuspendLayout();
            // 
            // GridViewUnits
            // 
            GridViewUnits.AllowUserToAddRows = false;
            GridViewUnits.AllowUserToDeleteRows = false;
            GridViewUnits.AllowUserToOrderColumns = true;
            GridViewUnits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridViewUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridViewUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridViewUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewUnits.Columns.AddRange(new DataGridViewColumn[] { Id, UnitName, Abbreviation });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridViewUnits.DefaultCellStyle = dataGridViewCellStyle2;
            GridViewUnits.Location = new Point(12, 73);
            GridViewUnits.MultiSelect = false;
            GridViewUnits.Name = "GridViewUnits";
            GridViewUnits.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridViewUnits.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridViewUnits.RowHeadersVisible = false;
            GridViewUnits.RowTemplate.Height = 25;
            GridViewUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewUnits.Size = new Size(265, 233);
            GridViewUnits.StandardTab = true;
            GridViewUnits.TabIndex = 0;
            GridViewUnits.VirtualMode = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // UnitName
            // 
            UnitName.DataPropertyName = "Name";
            UnitName.HeaderText = "Nombre";
            UnitName.Name = "UnitName";
            UnitName.ReadOnly = true;
            UnitName.Width = 76;
            // 
            // Abbreviation
            // 
            Abbreviation.DataPropertyName = "Abbreviation";
            Abbreviation.HeaderText = "Abreviación";
            Abbreviation.Name = "Abbreviation";
            Abbreviation.ReadOnly = true;
            Abbreviation.Width = 95;
            // 
            // btnAddUnit
            // 
            btnAddUnit.Location = new Point(289, 78);
            btnAddUnit.Name = "btnAddUnit";
            btnAddUnit.Size = new Size(107, 23);
            btnAddUnit.TabIndex = 1;
            btnAddUnit.Text = "&Agregar Unidad";
            btnAddUnit.UseVisualStyleBackColor = true;
            btnAddUnit.Click += BtnAddUnit_Click;
            // 
            // btnUpdateUnit
            // 
            btnUpdateUnit.Location = new Point(289, 107);
            btnUpdateUnit.Name = "btnUpdateUnit";
            btnUpdateUnit.Size = new Size(107, 23);
            btnUpdateUnit.TabIndex = 2;
            btnUpdateUnit.Text = "&Modificar Unidad";
            btnUpdateUnit.UseVisualStyleBackColor = true;
            btnUpdateUnit.Click += BtnUpdateUnit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(99, 30);
            label1.TabIndex = 3;
            label1.Text = "Unidades";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(289, 136);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // UnitsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 318);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(btnUpdateUnit);
            Controls.Add(btnAddUnit);
            Controls.Add(GridViewUnits);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "UnitsList";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Lista Unidades";
            FormClosing += UnitsList_FormClosing;
            ((System.ComponentModel.ISupportInitialize)GridViewUnits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GridViewUnits;
        private Button btnAddUnit;
        private Button btnUpdateUnit;
        private Label label1;
        private Button btnCancel;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn Abbreviation;
    }
}
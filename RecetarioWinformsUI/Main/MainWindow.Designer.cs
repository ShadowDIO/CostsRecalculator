namespace RecetarioWinformsUI.Main
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            mainWindowMenu = new MenuStrip();
            ingredientesToolStripMenuItem = new ToolStripMenuItem();
            listaIngredientesToolStripMenuItem = new ToolStripMenuItem();
            agregarIngredientesToolStripMenuItem = new ToolStripMenuItem();
            recetasToolStripMenuItem = new ToolStripMenuItem();
            buscarRecetasToolStripMenuItem = new ToolStripMenuItem();
            crearRecetaToolStripMenuItem = new ToolStripMenuItem();
            unidadesToolStripMenuItem = new ToolStripMenuItem();
            listaUnidadesToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            mainWindowMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mainWindowMenu
            // 
            mainWindowMenu.Items.AddRange(new ToolStripItem[] { ingredientesToolStripMenuItem, recetasToolStripMenuItem, unidadesToolStripMenuItem });
            mainWindowMenu.Location = new Point(0, 0);
            mainWindowMenu.Name = "mainWindowMenu";
            mainWindowMenu.Size = new Size(1489, 24);
            mainWindowMenu.TabIndex = 1;
            mainWindowMenu.Text = "menuStrip1";
            // 
            // ingredientesToolStripMenuItem
            // 
            ingredientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaIngredientesToolStripMenuItem, agregarIngredientesToolStripMenuItem });
            ingredientesToolStripMenuItem.Name = "ingredientesToolStripMenuItem";
            ingredientesToolStripMenuItem.Size = new Size(84, 20);
            ingredientesToolStripMenuItem.Text = "&Ingredientes";
            // 
            // listaIngredientesToolStripMenuItem
            // 
            listaIngredientesToolStripMenuItem.Name = "listaIngredientesToolStripMenuItem";
            listaIngredientesToolStripMenuItem.Size = new Size(184, 22);
            listaIngredientesToolStripMenuItem.Text = "&Lista Ingredientes";
            listaIngredientesToolStripMenuItem.Click += listaIngredientesToolStripMenuItem_Click;
            // 
            // agregarIngredientesToolStripMenuItem
            // 
            agregarIngredientesToolStripMenuItem.Name = "agregarIngredientesToolStripMenuItem";
            agregarIngredientesToolStripMenuItem.Size = new Size(184, 22);
            agregarIngredientesToolStripMenuItem.Text = "&Agregar Ingredientes";
            agregarIngredientesToolStripMenuItem.Click += agregarIngredientesToolStripMenuItem_Click;
            // 
            // recetasToolStripMenuItem
            // 
            recetasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buscarRecetasToolStripMenuItem, crearRecetaToolStripMenuItem });
            recetasToolStripMenuItem.Name = "recetasToolStripMenuItem";
            recetasToolStripMenuItem.Size = new Size(59, 20);
            recetasToolStripMenuItem.Text = "&Recetas";
            // 
            // buscarRecetasToolStripMenuItem
            // 
            buscarRecetasToolStripMenuItem.Name = "buscarRecetasToolStripMenuItem";
            buscarRecetasToolStripMenuItem.Size = new Size(152, 22);
            buscarRecetasToolStripMenuItem.Text = "&Buscar Recetas";
            buscarRecetasToolStripMenuItem.Click += buscarRecetasToolStripMenuItem_Click;
            // 
            // crearRecetaToolStripMenuItem
            // 
            crearRecetaToolStripMenuItem.Name = "crearRecetaToolStripMenuItem";
            crearRecetaToolStripMenuItem.Size = new Size(152, 22);
            crearRecetaToolStripMenuItem.Text = "&Crear Receta";
            crearRecetaToolStripMenuItem.Click += crearRecetaToolStripMenuItem_Click;
            // 
            // unidadesToolStripMenuItem
            // 
            unidadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaUnidadesToolStripMenuItem });
            unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            unidadesToolStripMenuItem.Size = new Size(68, 20);
            unidadesToolStripMenuItem.Text = "&Unidades";
            // 
            // listaUnidadesToolStripMenuItem
            // 
            listaUnidadesToolStripMenuItem.Name = "listaUnidadesToolStripMenuItem";
            listaUnidadesToolStripMenuItem.Size = new Size(150, 22);
            listaUnidadesToolStripMenuItem.Text = "L&ista Unidades";
            listaUnidadesToolStripMenuItem.Click += listaUnidadesToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Location = new Point(0, 923);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1489, 108);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 1031);
            Controls.Add(pictureBox1);
            Controls.Add(mainWindowMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = mainWindowMenu;
            Name = "MainWindow";
            Text = "MainWindow";
            mainWindowMenu.ResumeLayout(false);
            mainWindowMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainWindowMenu;
        private ToolStripMenuItem ingredientesToolStripMenuItem;
        private ToolStripMenuItem listaIngredientesToolStripMenuItem;
        private ToolStripMenuItem agregarIngredientesToolStripMenuItem;
        private ToolStripMenuItem recetasToolStripMenuItem;
        private ToolStripMenuItem buscarRecetasToolStripMenuItem;
        private ToolStripMenuItem crearRecetaToolStripMenuItem;
        private ToolStripMenuItem unidadesToolStripMenuItem;
        private ToolStripMenuItem listaUnidadesToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RecetarioBackEnd.BLL;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioWinformsUI.Main;

namespace RecetarioWinformsUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1) Configuramos el contenedor de servicios
            var services = new ServiceCollection();

            // 2) Registramos DALs
            services.AddSingleton<IIngredientsDAL, IngredientsDAL>();
            services.AddSingleton<IUnitsDAL, UnitsDAL>();
            services.AddSingleton<IRecipesDAL, RecipesDAL>();
            services.AddSingleton<IRecipeIngredientsDAL, RecipeIngredientsDAL>();
            services.AddSingleton<IRecipeSubRecipesDAL, RecipeSubRecipesDAL>();

            // 3) Registramos BLLs
            services.AddSingleton<IIngredientsBLL, IngredientsBLL>();
            services.AddSingleton<IUnitsBLL, UnitsBLL>();
            services.AddSingleton<IRecipesBLL, RecipesBLL>();
            services.AddSingleton<IRecipeIngredientsBLL, RecipeIngredientsBLL>();
            services.AddSingleton<IRecipeSubRecipesBLL, RecipeSubRecipesBLL>();

            // 4) Registramos el formulario principal
            services.AddSingleton<MainWindow>();

            // 5) Construimos el ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // 6) Inicializamos WinForms
            ApplicationConfiguration.Initialize();
            Application.ThreadException += (s, e) =>
                MessageBox.Show(e.Exception.ToString(), "Error en hilo UI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // 7) Ejecutamos la UI
            var mainForm = serviceProvider.GetRequiredService<MainWindow>();
            Application.Run(mainForm);
        }
    }
}

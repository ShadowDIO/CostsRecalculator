using Moq;
using RecetarioBackEnd.BLL;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEndTests
{
    public class RecipesBLLTests
    {
        private IRecipesBLL Bll { get; set; }

        private RecipeDTO RecipeDTO { get; set; }

        [SetUp]
        public void Setup()
        {
            var mockedRecipesDal = new Mock<IRecipesDAL>();
            var mockedIngredientsDal = new Mock<IIngredientsDAL>();

            mockedRecipesDal.Setup(x => x.GetRecipe(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(new Recipe()
                { 
                    Id = 2,
                    AmountProduced = 1,
                    Efficiency = 1,
                    RecipeName = "test recipe",
                    UnitId = 1,
                    Unit = new Unit()
                    {
                        Id = 2,
                        Abbreviation = "T",
                        Name = "Name"
                    },
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient()
                        { 
                            Id = 1,
                            Efficiency = .9,
                            Quantity = 10,
                            RecipeId = 1,
                            IngredientId = 1,
                            Ingredient = new Ingredient() 
                            {
                                Id = 1,
                                AmountSoldBy = 10,
                                Cost = 5,
                                IngredientName = "Ingredient",
                                Efficiency = .65,
                                Provider = "Provider",
                                UnitId = 1
                            }
                        }
                    }
                });

            Bll = new RecipesBLL(mockedRecipesDal.Object, new RecipeIngredientsDAL(), new RecipeSubRecipesDAL() , new IngredientsBLL(mockedIngredientsDal.Object));

            RecipeDTO = new RecipeDTO()
            {
                Id = 1,
                RecipeName = "Test Recipe",
                Efficiency = 1,
                AmountProduced = 1,
                UnitName = "Unit Name",
                Cost = 10,
                Ingredients = new List<RecipeIngredientDTO>()
                {
                    new RecipeIngredientDTO()
                    {
                        Ingredient = new IngredientDTO()
                        {
                            Id = 1,
                            IngredientName = "Ingredient Test 1",
                            AmountSoldBy = 50,
                            Cost = 100,
                            UnitName = "Unit Name",
                            Efficiency = 1,
                            Provider = "Provider Name 1"
                        },
                        Quantity = 1,
                        Cost = 2,
                        Efficiency= 1
                    },
                    new RecipeIngredientDTO()
                    {
                        Ingredient = new IngredientDTO()
                        {
                            Id = 2,
                            IngredientName = "Ingredient Test 2",
                            AmountSoldBy = 50,
                            Cost = 150,
                            UnitName = "Unit Name",
                            Efficiency = .8f,
                            Provider = "Provider Name 2"
                        },
                        Quantity = 1,
                        Cost = 3,
                        Efficiency= 1
                    }
                },
                SubRecipes = new List<RecipeSubRecipeDTO>()
                {
                    new RecipeSubRecipeDTO()
                    {
                        SubRecipe = new RecipeDTO()
                        {
                            Id = 2,
                            RecipeName = "Test SubRecipe",
                            Efficiency = 1,
                            AmountProduced = 2,
                            UnitName = "Unit Name",
                            Cost = 2
                        },
                        Quantity = 1,
                        Cost = 1,
                        Efficiency = 1
                    }
                }
            };
        }

        [Test]
        public void RecalculateRecipeTestByTotalCost()
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total,
                RecalculateFieldId = -1,
                RecalculateValue = 20
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 2);

            Assert.That(recalculatedRecipe.Cost == 20);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 2);

            Assert.That(ingredientRecalculated1.Cost == 4);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 2);

            Assert.That(ingredientRecalculated2.Cost == 6);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.Quantity == 2);

            Assert.That(subRecipe.Cost == 10);

        }

        [Test]
        public void RecalculateRecipeTestByIngredientCost()
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient,
                RecalculateFieldId = 1,
                RecalculateValue = 4
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 2);

            Assert.That(recalculatedRecipe.Cost == 20);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 2);

            Assert.That(ingredientRecalculated1.Cost == 4);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 2);

            Assert.That(ingredientRecalculated2.Cost == 6);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.SubRecipe?.AmountProduced == 2);

            Assert.That(subRecipe.Cost == 10);
        }

        [Test]
        public void RecalculateRecipeTestBySubRecipeCost()
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe,
                RecalculateFieldId = 2,
                RecalculateValue = 20
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 4);

            Assert.That(recalculatedRecipe.Cost == 40);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 4);

            Assert.That(ingredientRecalculated1.Cost == 8);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 4);

            Assert.That(ingredientRecalculated2.Cost == 12);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.SubRecipe?.AmountProduced == 2);

            Assert.That(subRecipe.Cost == 20);
        }

        [Test]
        public void RecalculateRecipeTestByTotalWeight()
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total,
                RecalculateFieldId = -1,
                RecalculateValue = 2
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 2);

            Assert.That(recalculatedRecipe.Cost == 20);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 2);

            Assert.That(ingredientRecalculated1.Cost == 4);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 2);

            Assert.That(ingredientRecalculated2.Cost == 6);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.SubRecipe?.AmountProduced == 2);

            Assert.That(subRecipe.Cost == 10);

        }

        [Test]
        public void RecalculateRecipeTestByIngredientWeight()
        {

            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient,
                RecalculateFieldId = 1,
                RecalculateValue = 10
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 10);

            Assert.That(recalculatedRecipe.Cost == 100);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 10);

            Assert.That(ingredientRecalculated1.Cost == 20);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 10);

            Assert.That(ingredientRecalculated2.Cost == 30);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.SubRecipe?.AmountProduced == 2);

            Assert.That(subRecipe.Cost == 50);
        }

        [Test]
        public void RecalculateRecipeTestBySubRecipeWeight()
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO()
            {
                RecalculateType = RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight,
                RecalculateOverField = RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe,
                RecalculateFieldId = 2,
                RecalculateValue = 4
            };

            var recalculatedRecipe = Bll.RecalculateRecipe(RecipeDTO, recalculateParameters);

            Assert.That(recalculatedRecipe.AmountProduced == 4);

            Assert.That(recalculatedRecipe.Cost == 40);

            var ingredientRecalculated1 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 1);

            Assert.That(ingredientRecalculated1.Quantity == 4);

            Assert.That(ingredientRecalculated1.Cost == 8);

            var ingredientRecalculated2 = recalculatedRecipe.Ingredients.First(p => p.Ingredient.Id == 2);

            Assert.That(ingredientRecalculated2.Quantity == 4);

            Assert.That(ingredientRecalculated2.Cost == 12);

            var subRecipe = recalculatedRecipe.SubRecipes.First();

            Assert.That(subRecipe.SubRecipe?.AmountProduced == 2);

            Assert.That(subRecipe.Cost == 20);
        }
    }
}
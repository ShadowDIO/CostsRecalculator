using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecetarioBackEnd.Models;

public partial class RecetarioDbContext : DbContext
{
    public RecetarioDbContext()
    {
    }

    public RecetarioDbContext(DbContextOptions<RecetarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeSubRecipe> RecipeSubRecipes { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\RecetarioDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(e => e.Efficiency).HasDefaultValueSql("1");

            entity.HasOne(d => d.Unit).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.Property(e => e.Efficiency).HasDefaultValueSql("1");

            entity.HasOne(d => d.Unit).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasIndex(e => new { e.RecipeId, e.IngredientId }, "IX_RecipeIngredients_RecipeId_IngredientId").IsUnique();

            entity.Property(e => e.Efficiency).HasDefaultValueSql("1");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RecipeSubRecipe>(entity =>
        {
            entity.HasIndex(e => new { e.RecipeId, e.SubRecipeId }, "IX_RecipeSubRecipes_RecipeId_SubRecipeId").IsUnique();

            entity.Property(e => e.Efficiency).HasDefaultValueSql("1");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeSubRecipeRecipes)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubRecipe).WithMany(p => p.RecipeSubRecipeSubRecipes)
                .HasForeignKey(d => d.SubRecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

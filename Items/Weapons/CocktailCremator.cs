using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NEF.Items.Weapons
{
	public class CocktailCremator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cocktail Cremator");
	
			Tooltip.SetDefault("Spews burning cinders that linger on the ground"
				+ "\nUses gel for ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 44;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 16000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.MolotovFire;
			item.reuseDelay = 10;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Gel;
		}

		public override bool ConsumeAmmo(Player player)
		{
            		return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override void AddRecipes()
		
		{
	ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MolotovCocktail, 30);
			recipe.AddIngredient(ItemID.CopperBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);

			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MolotovCocktail, 30);
			recipe.AddIngredient(ItemID.TinBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);

			recipe.AddRecipe();		
		}
	
	}
}

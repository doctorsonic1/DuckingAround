using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;


namespace DuckingAround.UI
{
    internal class ExampleUI : UIState
	{
		public DragableUIPanel CoinCounterPanel;
		public UIHoverImageButton ExampleButton;

		public override void OnInitialize()
		{
			CoinCounterPanel = new DragableUIPanel();
			CoinCounterPanel.SetPadding(0);

			CoinCounterPanel.Left.Set(400f, 0f);
			CoinCounterPanel.Top.Set(100f, 0f);
			CoinCounterPanel.Width.Set(170f, 0f);
			CoinCounterPanel.Height.Set(70f, 0f);
			CoinCounterPanel.BackgroundColor = new Color(73, 94, 171);

			Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			UIHoverImageButton playButton = new UIHoverImageButton(buttonPlayTexture, "Reset Coins Per Minute Counter");
			playButton.Left.Set(110, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			CoinCounterPanel.Append(playButton);

			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52")); // Localized text for "Close"
			closeButton.Left.Set(140, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			CoinCounterPanel.Append(closeButton);

			Texture2D buttonFavoriteTexture = ModContent.GetTexture("Terraria/UI/ButtonFavoriteActive");
			ExampleButton = new UIHoverImageButton(buttonFavoriteTexture, "SendClientChanges Example: Non-Stop Party (???)"); // See ExamplePlayer.OnEnterWorld
			ExampleButton.Left.Set(140, 0f);
			ExampleButton.Top.Set(36, 0f);
			ExampleButton.Width.Set(22, 0f);
			ExampleButton.Height.Set(22, 0f);
			CoinCounterPanel.Append(ExampleButton);

			Append(CoinCounterPanel);
		}
	}
}
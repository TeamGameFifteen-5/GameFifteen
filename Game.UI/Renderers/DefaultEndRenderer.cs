namespace Game.UI.Renderers
{
	using Game.Common.Players;
	using Game.UI.IOProviders;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;


	public class DefaultEndRenderer : IRenderer<IPlayer>
	{
		public void Render(IOutputProvider outputProvider, IPlayer player)
		{
			outputProvider.DisplayLine("Congratulations! You won the game in {0} moves.", player.Score.ToString());
		}
	}
}

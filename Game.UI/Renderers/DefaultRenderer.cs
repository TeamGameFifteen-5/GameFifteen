using Game.UI.IOProviders;
using System.Drawing;

namespace Game.UI.Renderers
{
	public class DefaultRenderer : IRenderer
	{
		private static readonly Color DEFAULT_COLOR = Color.Cyan;

		private Color _color;

		public DefaultRenderer(Color? color = null)
		{
			this._color = color ?? DEFAULT_COLOR;
		}

		public void Format(IIOProvider ioService)
		{
			ioService.ChangeColor(this._color);
		}
	}
}
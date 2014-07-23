using Game.UI.IOProviders;
using System.Drawing;

namespace Game.UI.Renderers
{
	public class DefaultRenderer : IRenderer
	{
		private static readonly Color _defaultColor = Color.Cyan;

		private Color _color;

		public DefaultRenderer(Color? color = null)
		{
			this._color = color ?? _defaultColor;
		}

		public void Format(IIOProvider ioService)
		{
			ioService.ChangeColor(this._color);
		}
	}
}
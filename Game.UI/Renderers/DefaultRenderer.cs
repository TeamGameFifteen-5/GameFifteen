using Game.UI.IOProviders;
using System.Drawing;

namespace Game.UI.Renderers
{
	/// <summary>
	/// Represents Default renderer.
	/// </summary>
	/// <seealso cref="Game.UI.Renderers.IRenderer"/>
	public class DefaultRenderer : IRenderer
	{
		private static readonly Color _defaultColor = Color.Cyan;

		private Color _color;

		public DefaultRenderer(Color? color = null)
		{
			this._color = color ?? _defaultColor;
		}

		public void Render(IIOProvider ioProvider)
		{
			ioProvider.ChangeColor(this._color);
		}
	}
}
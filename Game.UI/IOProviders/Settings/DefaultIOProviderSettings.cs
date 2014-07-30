namespace Game.UI.IOProviders.Settings
{
    using System.Drawing;

	/// <summary>
	/// Default i/o provider settings.
	/// </summary>
	/// <seealso cref="Game.UI.Renderers.IIOProviderSettings"/>
	public class DefaultIOProviderSettings : IIOProviderSettings
	{
		/// <summary>
		/// The default color.
		/// </summary>
		private static readonly Color _DefaultColor = Color.Cyan;

        /// <summary>
        /// The color.
        /// </summary>
        private readonly Color _color;

		/// <summary>
		/// Initializes a new instance of the DefaultIOProviderSettings class.
		/// </summary>
		/// <param name="color">The color.</param>
		public DefaultIOProviderSettings(Color? color = null)
		{
			this._color = color ?? _DefaultColor;
		}

		/// <summary>
		/// Renders the given i/o provider.
		/// </summary>
		/// <param name="ioProvider">The i/o provider.</param>
		public void Apply(IIOProvider ioProvider)
		{
			ioProvider.ChangeColor(this._color);
		}
	}
}
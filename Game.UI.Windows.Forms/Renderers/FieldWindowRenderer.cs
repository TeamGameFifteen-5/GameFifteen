namespace Game.UI.Windows.Forms.Renderers
{
	using Game.Common.Map;
	using Game.Common.Utils;
	using Game.UI.IOProviders;
	using Game.UI.Renderers;

	/// <summary>
	/// Field window renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	public class FieldWindowsRenderer<TOutputProvider> : DefaultFieldRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		/// <summary>
		/// Renders the field screen.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		/// <param name="field">		 The field.</param>
		public void Render(TOutputProvider outputProvider, IField field)
		{
			Validation.ThrowIfNull(outputProvider);
			Validation.ThrowIfNull(field);

			base.Render(outputProvider, field);
			outputProvider.DisplayLine();
		}
	}
}
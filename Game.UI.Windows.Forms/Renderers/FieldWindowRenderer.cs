namespace Game.UI.Windows.Forms.Renderers
{
	using Game.Common.Map;
	using Game.Common.Utils;
	using Game.UI.IOProviders;
	using Game.UI.Renderers;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Field window renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	[ExcludeFromCodeCoverage]
	public class FieldWindowsRenderer<TOutputProvider> : DefaultFieldRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		protected override int HorizontalLineLength
		{
			get
			{
				return 7;
			}
		}

		/// <summary>
		/// Renders the field screen.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		/// <param name="field">		 The field.</param>
		public override void Render(TOutputProvider outputProvider, IField field)
		{
			Validation.ThrowIfNull(outputProvider);
			Validation.ThrowIfNull(field);

			base.Render(outputProvider, field);
			outputProvider.DisplayLine();
		}
	}
}
namespace Game.UI.Windows.Forms.Renderers
{
	using Game.Common.Utils;
	using Game.UI.IOProviders;
	using Game.UI.Renderers;
	using System.Diagnostics.CodeAnalysis;
	using System.Windows.Forms;

	/// <summary>
	/// Exit window renderer.
	/// </summary>
	/// <typeparam name="TIOProvider">Type of the tio provider.</typeparam>
	/// <seealso cref="Game.UI.Renderers.DefaultExitRenderer{TIOProvider}"/>
	[ExcludeFromCodeCoverage]
	public class ExitWindowRenderer<TIOProvider> : DefaultExitRenderer<TIOProvider>
		where TIOProvider : IIOProvider
	{
		/// <summary>
		/// Renders exit screen to the given ioProvider.
		/// </summary>
		/// <param name="ioProvider">The i/o provider.</param>
		public override void Render(TIOProvider ioProvider)
		{
			Validation.ThrowIfNull(ioProvider);

			base.Render(ioProvider);
			ioProvider.DisplayLine("Press any key to exit . .");
			ioProvider.GetKeyInput();
			Application.Exit();
		}
	}
}
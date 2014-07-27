namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	/// <summary>
	/// Interface for renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	public interface IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		/// <summary>
		/// Renders the given outputProvider.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		void Render(TOutputProvider outputProvider);
	}
}
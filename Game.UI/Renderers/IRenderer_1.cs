namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	/// <summary>
	/// Interface for renderer.
	/// </summary>
	/// <typeparam name="TOutputProvider">Type of the output provider.</typeparam>
	/// <typeparam name="TArgs">		  Type of the arguments.</typeparam>
	public interface IRenderer<TOutputProvider, TArgs>
		where TOutputProvider : IOutputProvider
	{
		/// <summary>
		/// Renders the screen to the given outputProvider.
		/// </summary>
		/// <param name="outputProvider">The output provider.</param>
		/// <param name="args">			 The arguments.</param>
		void Render(TOutputProvider outputProvider, TArgs args);
	}
}
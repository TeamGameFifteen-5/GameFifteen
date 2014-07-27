namespace Game.UI.Renderers
{
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultInvalidInputRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
            Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine("The provided input is not valid in this context!");
		}
	}
}
namespace Game.UI.Renderers
{
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultIllegalCommandRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
            Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine("Illegal command!");
		}
	}
}
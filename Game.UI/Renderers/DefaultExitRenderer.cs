namespace Game.UI.Renderers
{
    using Game.Common.Utils;
    using Game.UI.IOProviders;

	public class DefaultExitRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public virtual void Render(TOutputProvider outputProvider)
		{
            Validation.ThrowIfNull(outputProvider);

			outputProvider.DisplayLine("Good bye!");
		}
	}
}
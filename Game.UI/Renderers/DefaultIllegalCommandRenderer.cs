namespace Game.UI.Renderers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;


	public class DefaultIllegalCommandRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("Illegal command!");
		}
	}
}

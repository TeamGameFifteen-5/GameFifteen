namespace Game.UI.Renderers
{
	using Game.Common.Map;
	using Game.Common.Utils;
	using Game.UI.IOProviders;

	public class DefaultFieldRenderer<TOutputProvider> : IRenderer<TOutputProvider, IField>
		where TOutputProvider : IOutputProvider
	{
		#region Constants

		private const char HORIZONTAL_LINE = '\u2500';
		private const char VERTICAL_LINE = '\u2502';
		private const char UPPER_LEFT_CORNER = '\u250c';
		private const char UPPER_RIGHT_CORNER = '\u2510';
		private const char LOWER_LEFT_CORNER = '\u2514';
		private const char LOWER_RIGHT_CORNER = '\u2518';

		#endregion Constants

		protected virtual int HorizontalLineLength
		{
			get
			{
				return 13;
			}
		}

		public virtual void Render(TOutputProvider outputProvider, IField field)
		{
            var upperLine = string.Format("{0}{1}{2}", UPPER_LEFT_CORNER, new string(HORIZONTAL_LINE, this.HorizontalLineLength), UPPER_RIGHT_CORNER);
            var lowerLine = string.Format("{0}{1}{2}", LOWER_LEFT_CORNER, new string(HORIZONTAL_LINE, this.HorizontalLineLength), LOWER_RIGHT_CORNER);

			Validation.ThrowIfNull(outputProvider);
			Validation.ThrowIfNull(field);

			outputProvider.DisplayLine(upperLine);

			foreach (var row in field)
			{
				outputProvider.Display(VERTICAL_LINE.ToString() + " ");

				foreach (var col in row)
				{
					outputProvider.Display(col >= 10 ? "{0} " : " {0} ", col == 0 ? " " : col.ToString());
				}

				outputProvider.DisplayLine(VERTICAL_LINE.ToString());
			}

			outputProvider.DisplayLine(lowerLine);
		}
	}
}
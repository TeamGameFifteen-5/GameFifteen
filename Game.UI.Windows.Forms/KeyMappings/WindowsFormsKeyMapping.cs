namespace Game.UI.Windows.Forms.KeyMappings
{
    using System.Windows.Forms;
    using Game.Common;
    using Game.UI.KeyMappings;

	/// <summary>
	/// Windows forms key mapping.
	/// </summary>
	/// <seealso cref="T:Game.UI.KeyMappings.IKeyMapping{System.Windows.Forms.Keys}"/>
	public class WindowsFormsKeyMapping : IKeyMapping<Keys>
	{
		/// <summary>
		/// Maps the given windows forms keys.
		/// </summary>
		/// <param name="windowsFormsKeys">The windows forms keys.</param>
		/// <returns>
		/// The mapped action type
		/// </returns>
		public Common.ActionType Map(Keys windowsFormsKeys)
		{
			ActionType key;

			switch (windowsFormsKeys)
			{
				case Keys.W:
				case Keys.Up:
					key = ActionType.Get(DefaultActionTypes.Up);
					break;

				case Keys.S:
				case Keys.Down:
					key = ActionType.Get(DefaultActionTypes.Down);
					break;

				case Keys.A:
				case Keys.Left:
					key = ActionType.Get(DefaultActionTypes.Left);
					break;

				case Keys.D:
				case Keys.Right:
					key = ActionType.Get(DefaultActionTypes.Right);
					break;

				case Keys.Escape:
				case Keys.Q:
					key = ActionType.Get(DefaultActionTypes.Exit);
					break;

				case Keys.R:
					key = ActionType.Get(DefaultActionTypes.Reset);
					break;

				case Keys.T:
					key = ActionType.Get(DefaultActionTypes.Scores);
					break;

				default:
					key = ActionType.Get(DefaultActionTypes.Unmapped);
					break;
			}

			return key;
		}
	}
}
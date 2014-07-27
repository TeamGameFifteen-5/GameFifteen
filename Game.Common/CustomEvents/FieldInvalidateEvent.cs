namespace Game.Common.CustomEvents
{
	using Game.Common.Map;

	/// <summary>
	/// Represents field invalidate event.
	/// </summary>
	/// <seealso cref="Game.Common.CustomEvents.CustomEvent"/>
	public class FieldInvalidateEvent : CustomEvent<IField>
	{
		/// <summary>
		/// Initializes a new instance of the FieldInvalidateEvent class.
		/// </summary>
		/// <param name="field">The field.</param>
		public FieldInvalidateEvent(IField field)
			: base(field)
		{
		}
	}
}
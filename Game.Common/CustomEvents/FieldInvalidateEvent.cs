namespace Game.Common.CustomEvents
{
    using Game.Common.Map;

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
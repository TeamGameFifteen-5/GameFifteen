namespace Game.Common
{
	using System;

	[Serializable]
	public class NameValue<TValue> : NameValue, INameValue<TValue>
	{
		public NameValue(string name, TValue value)
			: base(name)
		{
			this.ValueObject = value;
		}

		public TValue ValueObject { get; private set; }

		public override string Value
		{
			get
			{
				return this.ValueObject.ToString();
			}
		}
	}
}
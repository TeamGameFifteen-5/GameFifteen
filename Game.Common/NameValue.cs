namespace Game.Common
{
	public abstract class NameValue : INameValue
	{
		public NameValue(string name)
		{
			this.Name = name;
		}

		public string Name { get; private set; }

		public abstract string Value { get; }
	}
}
namespace Game.Common
{
	public interface INameValue<TValue> : INameValue
	{
		TValue ValueObject { get; }
	}
}
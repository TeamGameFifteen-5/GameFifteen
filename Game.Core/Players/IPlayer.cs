namespace Game.Core.Players
{
	public interface IPlayer
	{
		string Name { get; set; }

		int Score { get; set; }
	}
}
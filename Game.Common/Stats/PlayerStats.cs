namespace Game.Common.Stats
{
    using System;
    using Game.Common.Players;

	public class PlayerStats : IStatsStorage<IPlayer>
	{
		public IPlayer Load()
		{
			return new Player();
		}

		public void Save(IPlayer stats)
		{
			throw new NotImplementedException();
		}
	}
}
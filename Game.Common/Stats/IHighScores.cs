using Game.Common.Players;
using System.Collections.Generic;

namespace Game.Common.Stats
{
    public interface IHighScores
    {
        List<IPlayer> Load();

        void Save(IPlayer player);

    }
}

using System;

namespace Game.Core
{
	public interface ICoreEngine
	{
		event Action GameStart;

		event Action GameEnd;

		event Action GameExit;

		event Action GameMovement;

		event Action GameIllegalMove;

		event Action GameIllegalCommand;

		event FieldEvent GameInvalidate;

		void Start();
	}
}
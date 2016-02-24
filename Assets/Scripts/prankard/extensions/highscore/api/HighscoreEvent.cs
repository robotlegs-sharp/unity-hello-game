using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace prankard.extensions.highscore.api
{
	public class HighscoreEvent : Event 
	{
		public enum Type
		{
			HIGHSCORE_UPDATED
		}

		public int Highscore { get; private set; }

		public HighscoreEvent (Type type, int highscore) : base (type)
		{
			Highscore = highscore;
		}
	}
}
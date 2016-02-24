using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace prankard.extensions.highscore.impl
{
	public class HighscoreRequestEvent : Event 
	{
		public enum Type
		{
			REQUEST,
			ON_REQUEST
		}

		public int Highscore { get; private set; }

		public HighscoreRequestEvent (Type type) : base (type) { }
		public HighscoreRequestEvent (Type type, int highscore) : base (type)
		{
			Highscore = highscore;
		}
	}
}
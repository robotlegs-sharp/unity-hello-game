using robotlegs.bender.extensions.eventDispatcher.impl;

namespace prankard.extensions.highscore.api
{
	public class HasHighscoreEvent : Event 
	{
		public enum Type
		{
			HAS_HIGHSCORE
		}

		public HasHighscoreEvent (Type type) : base (type)
		{
			
		}
	}
}
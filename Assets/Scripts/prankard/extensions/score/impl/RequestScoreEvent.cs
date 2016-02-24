using robotlegs.bender.extensions.eventDispatcher.impl;

namespace prankard.extensions.score.impl
{
	public class RequestScoreEvent : Event 
	{
		public enum Type
		{
			REQUEST,
			ON_REQUEST
		}

		public int Score {get; private set;}

		public RequestScoreEvent (Type type) : base (type) { }
		public RequestScoreEvent (Type type, int score) : base (type) 
		{
			Score = score;
		}
	}
}
using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace prankard.extensions.score.api
{
	public class ScoreEvent : Event 
	{
		public enum Type
		{
			SET_SCORE,
			ADD_TO_SCORE,
			SCORE_CHANGED
		}

		public int Score { get; private set; }

		public ScoreEvent (Type type, int score) : base (type)
		{
			Score = score;
		}
	}
}
using prankard.extensions.score.api;
using Robotlegs.Bender.Extensions.EventManagement.API;

namespace prankard.extensions.score.impl
{
	public class ScoreModel : IScoreModel
	{
		[Inject] public IEventDispatcher dispatcher;

		public int Score { get; private set; }

		public void SetScore(int score)
		{
			Score = score;
			dispatcher.Dispatch(new ScoreEvent(ScoreEvent.Type.SCORE_CHANGED, score));
		}

		public void ResetScore()
		{
			SetScore(0);
		}
	}
}
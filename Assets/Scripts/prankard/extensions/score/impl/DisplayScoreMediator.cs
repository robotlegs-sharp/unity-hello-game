using Robotlegs.Bender.Bundles.MVCS;
using prankard.extensions.score.api;

namespace prankard.extensions.score.impl
{
	public class DisplayScoreMediator : Mediator
	{
		[Inject] public IDisplayScoreView view;

		public override void Initialize ()
		{
			AddContextListener<ScoreEvent>(ScoreEvent.Type.SCORE_CHANGED, ScoreChanged);
			RequestScore();
		}

		private void RequestScore()
		{
			AddContextListener<RequestScoreEvent>(RequestScoreEvent.Type.ON_REQUEST, OnRequestScore);
			Dispatch(new RequestScoreEvent(RequestScoreEvent.Type.REQUEST));
		}

		private void OnRequestScore(RequestScoreEvent evt)
		{
			RemoveContextListener<RequestScoreEvent>(RequestScoreEvent.Type.ON_REQUEST, OnRequestScore);
			view.Score = evt.Score;
		}

		private void ScoreChanged(ScoreEvent evt)
		{
			view.Score = evt.Score;
		}
	}
}
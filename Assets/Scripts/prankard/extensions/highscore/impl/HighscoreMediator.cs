using robotlegs.bender.bundles.mvcs;
using prankard.extensions.highscore.api;

namespace prankard.extensions.highscore.impl
{
	public class HighscoreMediator : Mediator
	{
		[Inject] public IHighscoreView view;

		public override void Initialize ()
		{
			AddContextListener<HighscoreEvent>(HighscoreEvent.Type.HIGHSCORE_UPDATED, HighscoreUpdated);
			RequestHighscore();
		}

		private void RequestHighscore()
		{
			AddContextListener<HighscoreRequestEvent>(HighscoreRequestEvent.Type.ON_REQUEST, OnRequestHighscore);
			Dispatch(new HighscoreRequestEvent(HighscoreRequestEvent.Type.REQUEST));
		}

		private void OnRequestHighscore(HighscoreRequestEvent evt)
		{
			RemoveContextListener<HighscoreRequestEvent>(HighscoreRequestEvent.Type.ON_REQUEST, OnRequestHighscore);
			view.Highscore = evt.Highscore;
		}

		private void HighscoreUpdated (HighscoreEvent evt)
		{
			view.Highscore = evt.Highscore;
		}
	}
}
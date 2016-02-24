using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.highscore.api;
using prankard.extensions.score.api;

namespace prankard.extensions.highscore.impl
{
	public class SetHighscoreCommand : ICommand 
	{
		[Inject] public ScoreEvent evt;
		[Inject] public IHighscoreService service;

		public void Execute ()
		{
			service.SetHighscore(evt.Score);
		}
	}
}
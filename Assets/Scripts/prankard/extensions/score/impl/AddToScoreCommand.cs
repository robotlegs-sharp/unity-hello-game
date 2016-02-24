using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.score.api;

namespace prankard.extensions.score.impl
{
	public class AddToScoreCommand : ICommand 
	{
		[Inject] public ScoreEvent evt;
		[Inject] public IScoreModel model;

		public void Execute ()
		{
			model.SetScore(model.Score + evt.Score);
		}
	}
}
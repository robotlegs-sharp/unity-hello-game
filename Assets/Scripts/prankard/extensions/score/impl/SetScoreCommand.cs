using Robotlegs.Bender.Extensions.CommandCenter.API;
using prankard.extensions.score.api;

namespace prankard.extensions.score.impl
{
	public class SetScoreCommand : ICommand 
	{
		[Inject] public ScoreEvent evt;
		[Inject] public IScoreModel model;

		public void Execute ()
		{
			model.SetScore(evt.Score);
		}
	}
}
using robotlegs.bender.bundles.mvcs;
using prankard.extensions.score.api;

namespace prankard.extensions.score.impl
{
	public class SetScoreMediator : Mediator
	{
		public override void Initialize ()
		{
			AddViewListener(ScoreEvent.Type.ADD_TO_SCORE, Dispatch);
			AddViewListener(ScoreEvent.Type.SET_SCORE, Dispatch);
		}
	}
}
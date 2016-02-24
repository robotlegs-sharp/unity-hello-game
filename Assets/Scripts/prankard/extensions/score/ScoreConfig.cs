using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Extensions.EventCommand.API;
using prankard.extensions.score.api;
using prankard.extensions.score.impl;

namespace prankard.extensions.score
{
	public class ScoreConfig : IConfig
	{
		[Inject] public IMediatorMap mediatorMap;
		[Inject] public IEventCommandMap commandMap;

		public void Configure ()
		{
			mediatorMap.Map<IDisplayScoreView>().ToMediator<DisplayScoreMediator>();
			mediatorMap.Map<ISetScoreView>().ToMediator<SetScoreMediator>();
			commandMap.Map(ScoreEvent.Type.SET_SCORE).ToCommand<SetScoreCommand>();
			commandMap.Map(ScoreEvent.Type.ADD_TO_SCORE).ToCommand<AddToScoreCommand>();
			commandMap.Map(RequestScoreEvent.Type.REQUEST).ToCommand<RequestScoreCommand>();
		}
	}
}
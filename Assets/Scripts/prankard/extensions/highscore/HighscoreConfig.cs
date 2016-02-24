using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using prankard.extensions.score.api;
using prankard.extensions.highscore.impl;
using prankard.extensions.highscore.api;

namespace prankard.extensions.highscore
{
	public class HighscoreConfig : IConfig
	{
		[Inject] public IEventCommandMap commandMap;
		[Inject] public IMediatorMap mediatorMap;
	
		public void Configure ()
		{
			mediatorMap.Map<IHighscoreView>().ToMediator<HighscoreMediator>();
			commandMap.Map(ScoreEvent.Type.SCORE_CHANGED).ToCommand<SetHighscoreCommand>();
			commandMap.Map(HighscoreRequestEvent.Type.REQUEST).ToCommand<HighscoreRequestCommand>();
		}
	}
}
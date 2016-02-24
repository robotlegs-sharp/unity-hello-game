using Robotlegs.Bender.Framework.API;
using prankard.extensions.score.api;
using prankard.extensions.score.impl;

namespace prankard.extensions.score
{
	public class ScoreExtension : IExtension 
	{
		public void Extend (IContext context)
		{
			context.injector.Map<IScoreModel>().ToSingleton<ScoreModel>();
			context.Configure<ScoreConfig>();
		}
	}
}
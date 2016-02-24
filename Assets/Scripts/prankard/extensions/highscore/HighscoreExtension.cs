using robotlegs.bender.framework.api;
using prankard.extensions.highscore.api;
using prankard.extensions.highscore.impl;

namespace prankard.extensions.highscore
{
	public class HighscoreExtension : IExtension 
	{
		public void Extend (IContext context)
		{
			context.injector.Map<IHighscoreModel>().ToSingleton<HighscoreModel>();
			context.injector.Map<IHighscoreService>().ToSingleton<PlayerPrefsHighscoreService>();
			context.Configure<HighscoreConfig>();
		}
	}
}
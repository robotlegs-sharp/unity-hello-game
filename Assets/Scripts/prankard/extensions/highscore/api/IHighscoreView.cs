using robotlegs.bender.extensions.mediatorMap.api;

namespace prankard.extensions.highscore.api
{
	public interface IHighscoreView : IView 
	{
		int Highscore { set; }
	}
}
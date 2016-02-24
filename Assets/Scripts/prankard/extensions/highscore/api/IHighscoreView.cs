using Robotlegs.Bender.Extensions.Mediation.API;

namespace prankard.extensions.highscore.api
{
	public interface IHighscoreView : IView 
	{
		int Highscore { set; }
	}
}
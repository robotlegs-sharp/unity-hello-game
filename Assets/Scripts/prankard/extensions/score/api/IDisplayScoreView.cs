using Robotlegs.Bender.Extensions.Mediation.API;

namespace prankard.extensions.score.api
{
	public interface IDisplayScoreView : IView 
	{
		int Score { set; }
	}
}
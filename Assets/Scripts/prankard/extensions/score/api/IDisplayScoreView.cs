using robotlegs.bender.extensions.mediatorMap.api;

namespace prankard.extensions.score.api
{
	public interface IDisplayScoreView : IView 
	{
		int Score { set; }
	}
}
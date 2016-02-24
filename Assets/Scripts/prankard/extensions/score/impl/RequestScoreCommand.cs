using Robotlegs.Bender.Extensions.CommandCenter.API;
using prankard.extensions.score.api;
using Robotlegs.Bender.Extensions.EventManagement.API;

namespace prankard.extensions.score.impl
{
	public class RequestScoreCommand : ICommand 
	{
		[Inject] public IEventDispatcher dispatcher;
		[Inject] public IScoreModel model;

		public void Execute ()
		{
			dispatcher.Dispatch(new RequestScoreEvent(RequestScoreEvent.Type.ON_REQUEST, model.Score));
		}
	}
}
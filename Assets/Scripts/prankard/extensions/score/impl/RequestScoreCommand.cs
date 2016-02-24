using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.score.api;
using robotlegs.bender.extensions.eventDispatcher.api;

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
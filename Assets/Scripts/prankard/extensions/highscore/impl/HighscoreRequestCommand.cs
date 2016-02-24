using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.highscore.api;
using robotlegs.bender.extensions.eventDispatcher.api;

namespace prankard.extensions.highscore.impl
{
	public class HighscoreRequestCommand : ICommand 
	{
		[Inject] public HighscoreRequestEvent evt;
		[Inject] public IHighscoreService service;
		[Inject] public IEventDispatcher dispatcher;

		public void Execute ()
		{
			dispatcher.Dispatch(new HighscoreRequestEvent(HighscoreRequestEvent.Type.ON_REQUEST, service.Highscore));
		}
	}
}
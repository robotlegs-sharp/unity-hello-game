using Robotlegs.Bender.Extensions.CommandCenter.API;
using prankard.extensions.scenecommand.api;
using prankard.extensions.score.api;
using Robotlegs.Bender.Extensions.EventManagement.API;
using prankard.extensions.sound.api.events;
using Robotlegs.Bender.Framework.API;

namespace prankard.hellogame.controller.command
{
	public class LoadSceneCommand : ICommand 
	{
		[Inject] public SceneEvent evt;
		[Inject] public IScoreModel scoreModel;
		[Inject] public IEventDispatcher dispatcher;
		[Inject] public ILogging logger;

		public void Execute ()
		{
			logger.Info("Loaded scene {0}", evt.Scene.name);
			switch (evt.Scene.name)
			{
				case SceneNames.GAME:
					scoreModel.ResetScore();
					dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.PLAY_MUSIC_TRACK, "game"));
					break;
			}
		}
	}
}
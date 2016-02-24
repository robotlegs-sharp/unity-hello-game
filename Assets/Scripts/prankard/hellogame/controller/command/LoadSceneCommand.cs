using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.scenecommand.api;
using prankard.extensions.score.api;
using robotlegs.bender.extensions.eventDispatcher.api;
using prankard.extensions.sound.api.events;
using robotlegs.bender.framework.api;

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
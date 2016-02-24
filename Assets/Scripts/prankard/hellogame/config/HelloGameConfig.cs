using robotlegs.bender.framework.api;
using robotlegs.bender.extensions.eventCommandMap.api;
using prankard.extensions.scenecommand.api;
using prankard.hellogame.controller.command;

namespace robotlegs.hellogame
{
	public class HelloGameConfig : IConfig 
	{
		[Inject] public IEventCommandMap commandMap;

		public void Configure ()
		{
			commandMap.Map<SceneEvent>(SceneEvent.Type.CHANGE_SCENE).ToCommand<LoadSceneCommand>();
		}
	}
}

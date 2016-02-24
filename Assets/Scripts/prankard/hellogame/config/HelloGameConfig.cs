using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.EventCommand.API;
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

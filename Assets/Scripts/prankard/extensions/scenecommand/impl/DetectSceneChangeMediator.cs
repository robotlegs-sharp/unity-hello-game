using robotlegs.bender.bundles.mvcs;
using prankard.extensions.scenecommand.api;

namespace prankard.extensions.scenecommand.impl
{
	public class DetectSceneChangeMediator : Mediator
	{
		public override void Initialize ()
		{
			AddViewListener(SceneEvent.Type.CHANGE_SCENE, Dispatch);
		}
	}
}
using robotlegs.bender.framework.api;
using robotlegs.bender.extensions.eventDispatcher.api;
using prankard.extensions.scenecommand.api;
using UnityEngine;
using UnityEngine.SceneManagement;
using robotlegs.bender.extensions.mediatorMap.api;
using prankard.extensions.scenecommand.impl;

namespace prankard.extensions.scenecommand
{
	public class SceneCommandConfig : IConfig 
	{
		[Inject] public Transform transform;

		[Inject] public IContext context;

		[Inject] public IEventDispatcher dispatcher;

		[Inject] public IMediatorMap mediatorMap;

		public void Configure ()
		{
			mediatorMap.Map<DetectSceneChangeView>().ToMediator<DetectSceneChangeMediator>();
			context.AfterInitializing(FireInitialCommand);
		}

		private void FireInitialCommand()
		{
			dispatcher.Dispatch(new SceneEvent(SceneEvent.Type.CHANGE_SCENE, SceneManager.GetActiveScene()));
			transform.gameObject.AddComponent<DetectSceneChangeView>();
		}
	}
}
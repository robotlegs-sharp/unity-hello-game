using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using prankard.extensions.scenecommand.api;
using UnityEngine;
using UnityEngine.SceneManagement;
using Robotlegs.Bender.Extensions.Mediation.API;
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
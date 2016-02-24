using UnityEngine;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;
using UnityEngine.SceneManagement;
using prankard.extensions.scenecommand.api;

namespace prankard.extensions.scenecommand.impl
{
	public class DetectSceneChangeView : EventView 
	{
		protected override void Start ()
		{
			base.Start ();
		}

		private void OnLevelWasLoaded(int level)
		{
			//UnityEngine.Debug.Log(SceneManager.GetActiveScene().name);
			//UnityEngine.Debug.Log(SceneManager.sceneCount);
			//dispatcher.Dispatch(new SceneEvent(SceneEvent.Type.CHANGE_SCENE, SceneManager.GetSceneAt(level)));
			dispatcher.Dispatch(new SceneEvent(SceneEvent.Type.CHANGE_SCENE, SceneManager.GetActiveScene()));
		}
	}
}
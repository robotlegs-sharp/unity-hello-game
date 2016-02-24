using Robotlegs.Bender.Extensions.EventManagement.Impl;
using UnityEngine.SceneManagement;

namespace prankard.extensions.scenecommand.api
{
	public class SceneEvent : Event 
	{
		public enum Type
		{
			CHANGE_SCENE
		}

		public Scene Scene { get;private set; }

		public SceneEvent (Type type, Scene scene) : base (type)
		{
			Scene = scene;
		}
	}
}
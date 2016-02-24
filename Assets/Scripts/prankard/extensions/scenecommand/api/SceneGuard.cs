using Robotlegs.Bender.Framework.API;
using UnityEngine.SceneManagement;

namespace prankard.extensions.scenecommand.api
{
	public class SceneGuard : IGuard 
	{
		private string[] _allowedScenes;

		public SceneGuard(params string[] allowedScenes)
		{
			_allowedScenes = allowedScenes;
		}

		public bool Approve ()
		{
			string currentScene = SceneManager.GetActiveScene().name;
			foreach (string scene in _allowedScenes)
			{
				if (scene == currentScene)
					return true;
			}
			return false;
		}
	}
}
using Robotlegs.Bender.Framework.API;
using prankard.extensions.scenecommand.api;
using prankard.extensions.scenecommand.impl;

namespace prankard.extensions.scenecommand
{
	public class SceneCommandExtension : IExtension 
	{
		public void Extend (IContext context)
		{
			context.Configure<SceneCommandConfig>();
		}
	}
}
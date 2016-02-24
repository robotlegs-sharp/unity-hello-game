using Robotlegs.Bender.Bundles;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using UnityEngine;
using prankard.extensions.scenecommand;
using prankard.extensions.language;
using prankard.extensions.score;
using prankard.extensions.highscore;
using prankard.extensions.sound.api.vo;
using prankard.extensions.sound;
using Robotlegs.Bender.Platforms.Unity.Bundles;

namespace robotlegs.hellogame
{
	public static class Main 
	{
		private static IContext context;

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			context = new Context();
			context.Install<UnitySingleContextBundle>();
			context.Install<SceneCommandExtension>();
			context.Install<LanguageExtension>();
			context.Install<ScoreExtension>();
			context.Install<HighscoreExtension>();
			context.Install<SoundExtension>();
			context.Configure<HelloGameConfig>();
			context.Configure(new LanguageXMLConfig(Resources.Load<TextAsset>("GameCopy").text));
			context.Configure(new LoadSoundsConfig(Resources.Load<SoundConfigVO>("SoundConfigVO")));
			GameObject contextView = new GameObject("Context View");
			MonoBehaviour.DontDestroyOnLoad(contextView);
			context.Configure(new TransformContextView(contextView.transform));
		}
	}
}
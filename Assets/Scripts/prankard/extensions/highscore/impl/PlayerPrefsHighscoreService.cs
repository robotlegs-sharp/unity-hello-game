using Robotlegs.Bender.Extensions.EventManagement.API;
using prankard.extensions.highscore.api;
using UnityEngine;

namespace prankard.extensions.highscore.impl
{
	public class PlayerPrefsHighscoreService : IHighscoreService
	{
		private readonly string PLAYER_PREFS_KEY;

		[Inject] public IEventDispatcher dispatcher;

		public PlayerPrefsHighscoreService(string playerPrefsKey = "HighscoreExtensionScore")
		{
			PLAYER_PREFS_KEY = playerPrefsKey;
		}

		public int Highscore
		{
			get
			{
				return PlayerPrefs.GetInt(PLAYER_PREFS_KEY, 0);
			}
			private set
			{
				PlayerPrefs.SetInt(PLAYER_PREFS_KEY, value);
				PlayerPrefs.Save();
			}
		}

		public void SetHighscore(int highscore)
		{
			if (highscore > Highscore)
			{
				Highscore = highscore;
				dispatcher.Dispatch(new HighscoreEvent(HighscoreEvent.Type.HIGHSCORE_UPDATED, highscore));
			}
		}
	}
}
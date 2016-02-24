using UnityEngine;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class LanguageSaveService : ILanguageSaveService
	{
		private const string LANGUAGE_SAVE_KEY = "langauge-save-service";

		private string _languageName;

		public LanguageSaveService()
		{
			if (!PlayerPrefs.HasKey(LANGUAGE_SAVE_KEY))
				_languageName = null;
			else
				_languageName = PlayerPrefs.GetString(LANGUAGE_SAVE_KEY);
		}

		public string LanguageName 
		{ 
			get
			{
				return _languageName;
			}
		}

		public void SaveLanguage(string languageName)
		{
			if (_languageName == languageName)
				return;

			_languageName = languageName;
			PlayerPrefs.SetString(LANGUAGE_SAVE_KEY, languageName);
			PlayerPrefs.Save();
		}
	}
}
using prankard.extensions.language.api;
using System.Collections.Generic;
using Robotlegs.Bender.Extensions.EventManagement.API;

namespace prankard.extensions.language.impl
{
	public class LanguageModel : ILanguageModel
	{
		private const string DEFAULT_LANGUAGE_KEY = "default";

		[Inject] public IEventDispatcher dispatcher;

		private Dictionary<string, LanguageContentVO> _languageByKey = new Dictionary<string, LanguageContentVO>();

		public string CurrentLanguage
		{
			get
			{
				return _currentLanguage;
			}
		}

		private string _currentLanguage = DEFAULT_LANGUAGE_KEY;

		public string GetText (string key)
		{
			string content;
			if (GetLanguageVO(CurrentLanguage).languageContentByKey.TryGetValue(key, out content))
				return content;
			return "Not Implemented";
		}

		public void SetCurrentLanguage(string language)
		{
			if (_currentLanguage == language)
				return;

			_currentLanguage = language;
			dispatcher.Dispatch(new LanguageEvent(LanguageEvent.Type.CHANGED_LANGUAGE, language));
		}

		public void AddText(string key, string content)
		{
			AddText(DEFAULT_LANGUAGE_KEY, key, content);
		}

		public void AddText(string languageKey, string key, string content)
		{
			GetLanguageVO(languageKey).languageContentByKey[key] = content;
		}

		public void AddLanguage(LanguageVO language)
		{
			foreach (CopyVO copy in language.copy)
			{
				AddText(language.name, copy.key, copy.copy);
			}
		}

		public void AddLanguages(LanguageVO[] languages)
		{
			foreach (LanguageVO language in languages)
			{
				AddLanguage(language);
			}
		}

		private LanguageContentVO GetLanguageVO(string key)
		{
			LanguageContentVO lang;
			if (_languageByKey.TryGetValue(key, out lang))
			{
				return lang;
			}
			lang = new LanguageContentVO(key);
			_languageByKey.Add(key, lang);
			return lang;
		}
	}
}
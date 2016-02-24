namespace prankard.extensions.language.api
{
	public interface ILanguageModel
	{
		string CurrentLanguage { get; }

		string GetText(string key);

		/// <summary>
		/// Adds text to the language 'default'
		/// </summary>
		/// <param name="key">The key to recieve the text</param>
		/// <param name="content">Content of the text</param>
		void AddText(string key, string content);

		/// <summary>
		/// Adds text to the language set in 'languageKey'
		/// </summary>
		/// <param name="languageKey">The Language Key</param>
		/// <param name="key">The key to recieve the text</param>
		/// <param name="content">Content of the text</param>
		void AddText(string languageKey, string key, string content);

		void SetCurrentLanguage(string language);

		void AddLanguage(LanguageVO language);
		void AddLanguages(LanguageVO[] languages);
	}
}
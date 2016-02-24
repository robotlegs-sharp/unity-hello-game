namespace prankard.extensions.language.api
{
	public interface ILanguageSaveService
	{
		string LanguageName { get; }

		void SaveLanguage(string languageName);
	}
}
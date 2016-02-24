namespace prankard.extensions.language.api
{
	public interface ILanguageParser
	{
		LanguageVO[] Parse(string content);
	}
}
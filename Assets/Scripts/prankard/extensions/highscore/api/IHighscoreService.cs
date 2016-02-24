namespace prankard.extensions.highscore.api
{
	public interface IHighscoreService
	{
		int Highscore { get; }

		void SetHighscore(int highscore);
	}
}
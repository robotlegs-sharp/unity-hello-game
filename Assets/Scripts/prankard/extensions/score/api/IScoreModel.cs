namespace prankard.extensions.score.api
{
	public interface IScoreModel
	{
		int Score { get; }
		void SetScore(int score);
		void ResetScore();
	}
}
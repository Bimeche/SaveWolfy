public static class GameData  {
	private static int score, cowDeaths, cowHits, wolfHits;

	public static int Score
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
		}
	}

	public static int CowDeaths
	{
		get
		{
			return cowDeaths;
		}
		set
		{
			cowDeaths = value;
		}
	}

	public static int CowHits
	{
		get
		{
			return cowHits;
		}
		set
		{
			cowHits = value;
		}
	}

	public static int WolfHits
	{
		get
		{
			return wolfHits;
		}
		set
		{
			wolfHits = value;
		}
	}

	public static int TotalHits
	{
		get
		{
			return wolfHits + cowHits;
		}
	}

	public static void ResetValues () {
		score = 0;
		cowDeaths = 0;
		cowHits = 0;
		wolfHits = 0;
	}
}
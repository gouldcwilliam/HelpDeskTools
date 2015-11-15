using System;

/// <summary>
/// 
/// </summary>
public class ProgressBar
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="MaxValue"></param>
	/// <param name="TaskName"></param>
	/// <param name="ProgressCharacter"></param>
	public ProgressBar(int MaxValue, string TaskName, char ProgressCharacter)
	{
		maxVal = MaxValue;
		taskName = string.Format(" {0} : ", TaskName);
		barSize = barSize - taskName.Length;
		progressCharacter = ProgressCharacter;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="MaxValue"></param>
	/// <param name="TaskName"></param>
	/// <param name="ProgressCharacter"></param>
	public ProgressBar(int MaxValue, string TaskName, string ProgressCharacter)
	{
		maxVal = MaxValue;
		taskName = string.Format(" {0} : ", TaskName);
		barSize = barSize - taskName.Length;
		if (ProgressCharacter != string.Empty)
		{
			progressCharacter = ProgressCharacter.ToCharArray()[0];
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="MaxValue"></param>
	/// <param name="TaskName"></param>
	public ProgressBar(int MaxValue, string TaskName)
	{
		maxVal = MaxValue;
		taskName = string.Format(" {0} : ", TaskName);
		barSize = barSize - taskName.Length;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="MaxValue"></param>
	/// <param name="ProgressCharacter"></param>
	public ProgressBar(int MaxValue, char ProgressCharacter)
	{
		maxVal = MaxValue;
		progressCharacter = ProgressCharacter;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="MaxValue"></param>
	public ProgressBar(int MaxValue)
	{
		maxVal = MaxValue;
	}

	private const int off = 22;
	private int maxVal = 1;
	private string taskName = ">";
	private char progressCharacter = (" ").ToCharArray()[0];
	// "‡"	

	private int barSize = Console.BufferWidth - Console.CursorLeft - off;

	/// <summary>
	/// 
	/// </summary>
	public void Start()
	{
		Console.Write("\n" + taskName);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="Complete"></param>
	public void Update(int Complete)
	{
		if (Complete == 0)
		{
			Start();
		}
		else
		{
			DrawProgress(Complete, maxVal, barSize, progressCharacter);
		}
	}

	private void DrawProgress(int complete, int maxVal, int barSize, char progressCharacter)
	{
		if (maxVal == 0) { return; }
		if (barSize == 0) { return; }
		Console.CursorVisible = false;
		int left = Console.CursorLeft;
		decimal perc = (decimal)complete / (decimal)maxVal;
		int chars = (int)Math.Floor(perc / ((decimal)1 / (decimal)barSize));


		string p0 = string.Format("{0}/{1} ", complete.ToString(), maxVal.ToString());
		string p1 = string.Empty, p2 = string.Empty;

		for (int i = 0; i < chars; i++) p1 += progressCharacter;
		for (int i = 0; i < barSize - chars; i++) p2 += progressCharacter;

		if (progressCharacter == " ".ToCharArray()[0])
		{
			Console.Write(p0);
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.Write(p1);
			Console.BackgroundColor = ConsoleColor.DarkGray;
			Console.Write(p2);
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(p1);
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(p2);
		}
		Console.ResetColor();
		Console.Write(" {0}%", (perc * 100).ToString("N2"));
		Console.CursorLeft = left;
	}
	private void DrawProgressComplete()
	{
		DrawProgress(maxVal, maxVal, barSize, progressCharacter);
		Console.WriteLine();
	}
	private void ClearProgressBar()
	{
		Console.CursorVisible = false;
		int left = Console.CursorLeft;
		string clean = string.Empty;

		for (int i = 0; i < barSize + off / 2; i++) { clean += " "; }
		Console.Write(clean);
		Console.CursorLeft = left;
	}
	private void ReplaceWithMessage(string message, ConsoleColor color)
	{
		ClearProgressBar();
		Console.ForegroundColor = color;
		Console.Write(message);
		Console.ResetColor();
		Console.WriteLine();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	public void Completed(string message)
	{
		ReplaceWithMessage(message, ConsoleColor.Green);
	}
	/// <summary>
	/// 
	/// </summary>
	public void Completed()
	{
		DrawProgressComplete();
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	public void Failed(string message)
	{
		ReplaceWithMessage(message, ConsoleColor.Red);
	}
	/// <summary>
	/// 
	/// </summary>
	public void Failed()
	{
		Failed("Failed");
	}
}

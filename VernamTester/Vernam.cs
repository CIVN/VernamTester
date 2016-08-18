using System.Collections.Generic;

public class Vernam
{	
	/// <summary>
	/// 文字列からバーナム暗号を生成します。
	/// </summary>
	/// <param name="str">文字列</param>
	/// <param name="row">使用する乱数の行</param>
	/// <returns>バーナム暗号</returns>
	public static string ToVernam(string str, int row)
	{
		row--;

		int i = 0;
		string result = "";
		List<int> original = new List<int>();
		List<int> added = new List<int>();
		List<int> surplus = new List<int>();

		foreach (var o in str)
		{
			original.Add(ConvertToNumber(o));
		}

		foreach (var _o in original)
		{
			added.Add(_o + table[row, i]);
			i++;
		}

		foreach (var a in added)
		{
			surplus.Add(a % 26);
		}

		foreach (var s in surplus)
		{
			result += ConvertToChar(s);
		}

		return result;
	}

	/// <summary>
	/// バーナム暗号を解読します。
	/// </summary>
	/// <param name="str">バーナム暗号</param>
	/// <param name="row">使用した乱数の行数</param>
	/// <returns>元の文字列</returns>
	public static string FromVernam(string str, int row)
	{
		var _vernam = new List<int>();

		foreach (var v in str)
		{
			_vernam.Add(ConvertToNumber(v));
		}

		var i = 0;
		row = row - 1;
		var _original = new List<int>();

		foreach (var _v in _vernam)
		{
			var multiple = -26;

			while (!(_v + multiple >= table[row, i]))
			{
				multiple += 26;
			}

			_original.Add((_v + multiple) - table[row, i]);
			i++;
		}

		var result = "";

		foreach (var _o in _original)
		{
			result += ConvertToChar(_o);
		}

		return result;
	}

	#region table
	private static sbyte[,] table = new sbyte[,]
	{
		/*1行目*/ { 93, 90, 60, 2, 17, 25, 89, 42, 27, 41 },
		/*2行目*/ { 34, 14, 39, 65, 54, 32, 14, 2, 6, 84 },
		/*3行目*/ { 85, 59, 37, 19, 69, 19, 17, 72, 81, 69 },
		/*4行目*/ { 1, 15, 67, 23, 14, 32, 15, 49, 2, 52 },
		/*5行目*/ { 95, 16, 61, 89, 77, 47, 14, 14, 40, 87 },
		/*6行目*/ { 26, 19, 79, 75,  97, 29, 19, 0, 30, 1 },
		/*7行目*/ { 50, 45, 95, 10, 48, 25, 29, 74, 63, 48 },
		/*8行目*/ { 3, 28, 70, 90, 33, 89, 66, 9, 23, 46 },
		/*9行目*/ { 36, 72, 79, 70, 41, 8, 85, 77, 3, 32 },
		/*10行目*/ { 19, 31, 85, 29, 48, 89, 59, 53, 99, 46 },
		/*11行目*/ { 14, 58, 90, 27, 73, 67, 17, 8, 43, 78 },
		/*12行目*/ { 56, 96, 30, 88, 10, 54, 85, 62, 1, 89 },
		/*13行目*/ { 37, 43, 4, 36, 86, 72, 63, 43, 21, 6 },
		/*14行目*/ { 22, 18, 73, 19, 32, 54, 5, 18, 36, 45},
		/*15行目*/ { 44, 85, 81, 89, 45, 27, 98, 41, 77, 78}
	};
	#endregion

	#region ConvertToNumber
	private static sbyte ConvertToNumber(char str)
	{
		switch (char.ToUpper(str))
		{
			case 'A': return 0;
			case 'B': return 1;
			case 'C': return 2;
			case 'D': return 3;
			case 'E': return 4;
			case 'F': return 5;
			case 'G': return 6;
			case 'H': return 7;
			case 'I': return 8;
			case 'J': return 9;
			case 'K': return 10;
			case 'L': return 11;
			case 'M': return 12;
			case 'N': return 13;
			case 'O': return 14;
			case 'P': return 15;
			case 'Q': return 16;
			case 'R': return 17;
			case 'S': return 18;
			case 'T': return 19;
			case 'U': return 20;
			case 'V': return 21;
			case 'W': return 22;
			case 'X': return 23;
			case 'Y': return 24;
			case 'Z': return 25;
		}

		return 0;
	}
	#endregion

	#region ConvertToChar
	private static char ConvertToChar(int num)
	{
		switch (num)
		{
			case 0: return 'A';
			case 1: return 'B';
			case 2: return 'C';
			case 3: return 'D';
			case 4: return 'E';
			case 5: return 'F';
			case 6: return 'G';
			case 7: return 'H';
			case 8: return 'I';
			case 9: return 'J';
			case 10: return 'K';
			case 11: return 'L';
			case 12: return 'M';
			case 13: return 'N';
			case 14: return 'O';
			case 15: return 'P';
			case 16: return 'Q';
			case 17: return 'R';
			case 18: return 'S';
			case 19: return 'T';
			case 20: return 'U';
			case 21: return 'V';
			case 22: return 'W';
			case 23: return 'X';
			case 24: return 'Y';
			case 25: return 'Z';
		}

		return 'A';
	}
	#endregion
}

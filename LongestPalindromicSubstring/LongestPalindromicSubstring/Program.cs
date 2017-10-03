using System;

namespace LongestPalindromicSubstring
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("racecar"));
			Console.WriteLine(LongestPalindrome("russell investments"));
        }

		public static string LongestPalindrome(string s)
		{
			int resultStart = 0;
			int length = s.Length;
			int[] dp = new int[length];
			dp[0] = 1;

			for (int i = 1; i < length; i++)
			{
				int previous = dp[i - 1];
				                
				if (IsPalindrome(s, i - previous - 1, i))
				{
					dp[i] = dp[i - 1] + 2;
					resultStart = i - previous - 1;
				}
				              
				else if (IsPalindrome(s, i - previous, i))
				{
					dp[i] = dp[i - 1] + 1;
					resultStart = i - previous;
				}
				else
				{
					dp[i] = dp[i - 1];
				}
			}
			return s.Substring(resultStart, dp[length - 1]);
		}

		private static bool IsPalindrome(string s, int start, int end)
		{
			while (start >= 0 && start < end && s[start] == s[end])
			{
				start++;
				end--;
			}
			return start >= end;
		}
    }
}

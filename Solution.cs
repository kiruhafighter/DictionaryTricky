namespace DictionaryTricky
{
    public class Solution
    {
        public void ClearDictionary(SortedDictionary<int, char> dict, char target)
        {
            List<int> keysToRemove = new List<int>();

            foreach (var kvp in dict)
            {
                if (kvp.Value == target)
                {
                    keysToRemove.Add(kvp.Key);
                    break;
                }
                keysToRemove.Add(kvp.Key);
            }


            foreach (int key in keysToRemove)
            {
                dict.Remove(key);
            }
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s is null)
            {
                return 0;
            }
            if (s.Length == 1)
            {
                return 1;
            }

            SortedDictionary<int, char> dict = new SortedDictionary<int, char>();
            List<int> results = new List<int>();

            int tempStart = 0;
            int length = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsValue(s[i]))
                {
                    dict.Add(i, s[i]);
                }
                else
                {
                    ClearDictionary(dict, s[i]);
                    length = i - tempStart;
                    results.Add(length);
                    dict.Add(i, s[i]);
                    tempStart = dict.Keys.First();
                }
            }

            int lastEl = s.Length;
            length = lastEl - tempStart;
            results.Add(length);

            return results.Max();
        }
    }
}
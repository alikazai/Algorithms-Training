namespace LeetCode.RomanToInteger;

public class RomanToInteger
{
    private Dictionary<char, int> romanValues = new ()
    {
        {'I',1},
        {'V',5},
        {'X',10},
        {'L',50},
        {'C',100},
        {'D',500},
        {'M',1000}
    };

    public int RomanToInt(string s)
    {
        int total = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            var firstNumerial = romanValues[s[i]];

            if (i + 1 < s.Length)
            {
                var secondNumerial = romanValues[s[i + 1]];
                if (firstNumerial >= secondNumerial)
                {
                    total += firstNumerial;
                }
                else
                {
                    total -= firstNumerial;
                }
            }
            else
            {
                total += firstNumerial;
            }
        }

        return total;
    }
}
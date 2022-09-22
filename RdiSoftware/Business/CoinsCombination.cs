namespace RdiSoftware.Business;

public class CoinsCombination
{
    public static long Count(int[] C, int m, int n)
    {
        var table = new long[n + 1];

        table[0] = 1;

        for (int i = 0; i < m; i++)
            for (int j = C[i]; j <= n; j++)
                table[j] += table[j - C[i]];

        return table[n];
    }
}
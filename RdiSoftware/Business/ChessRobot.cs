namespace RdiSoftware.Business;

public class ChessRobot
{
    public static string IsCrossed(String path)
    {
        if (path.Length == 0)
            return "";

        // Stores the count of
        // crossed vertex
        bool ans = false;

        // Stores (x, y) coordinates
        HashSet<KeyValuePair<int, int>> mySet = new();

        // The coordinates for the origin
        int x = 0, y = 0;
        mySet.Add(new KeyValuePair<int, int>(x, y));

        // Iterate over the String
        for (int i = 0; i < path.Length; i++)
        {

            // Condition to increment X or
            // Y co-ordinates respectively
            if (path[i] == 'U')
                mySet.Add(
                    new KeyValuePair<int, int>(x, y++));

            if (path[i] == 'D')
                mySet.Add(
                    new KeyValuePair<int, int>(x, y--));

            if (path[i] == 'R')
                mySet.Add(
                    new KeyValuePair<int, int>(x++, y));

            if (path[i] == 'L')
                mySet.Add(
                    new KeyValuePair<int, int>(x--, y));

            // Check if (x, y) is already
            // visited
            if (mySet.Contains(
                    new KeyValuePair<int, int>(x, y)))
            {
                ans = true;
                break;
            }
        }

        // Print the result
        if (ans)
            return "Crossed";
        else
            return "Not Crossed";
    }
}
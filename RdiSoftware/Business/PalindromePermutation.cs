namespace RdiSoftware.Business;

public class PalindromePermutation
{
    public static int[] PrepareCharacterSetMappingTable(string inputString)
    {
        string stringToBeProcessed = inputString.Replace(" ", "").ToLower();

        //Convert string into an array f characters   
        char[] chars = stringToBeProcessed.ToCharArray();

        //declare an array of integer type with size 128 because as per the ASCII standard character set  
        //there are 128 characters for electronic communication.  
        int[] characterSetMappingTable = new int[128];

        //Iterate through an array and for the index matching with the character ASCII value,  
        //set the value in the integer array to 1 if the value is 0 otherwise set the value  in the integer array to 0 if it is already 1   
        foreach (char c in chars)
        {
            var characterIndex = c;

            if (characterSetMappingTable[characterIndex] == 0)
                characterSetMappingTable[characterIndex] = 1;
            else if (characterSetMappingTable[characterIndex] == 1)
                characterSetMappingTable[characterIndex] = 0;
        }

        return characterSetMappingTable;
    }

    /// <summary>  
    /// this method will determine that no more than one character has an odd count.  
    /// </summary>  
    /// <param name="characterSetMappingTable"></param>  
    /// <returns></returns>  
    public static bool IsOnlyOddOneFound(int[] characterSetMappingTable)
    {
        int countOddOneFound = 0;

        foreach (var index in characterSetMappingTable)
        {
            if (countOddOneFound > 1)
                return false;

            if (index == 1)
                countOddOneFound++;
        }

        return true;
    }
}
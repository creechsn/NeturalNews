using System;

/// <summary>
/// This writes user submitted URL to text file for processing.
/// </summary>
public class WriteTextFile
{
    class WriteTextFile
    {
        static void Main()
        {
            string text = "URLSource: " + UserInput;

            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\URLSourceUpdate.txt", text);

        }
    }

}

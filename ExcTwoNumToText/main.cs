using System.IO;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(NumberToText(1234));
    }
    public static string NumberToText(long number)
    {
        string result = "";
        
        if (number == 0) {return "Zero";};
        if (number < 0 )
        {  
            result = "Negative ";
            number = -1 * number;
        }
        
        string[] HundradToTrillion = new string[] {"Hundred ", "Thousand", "Million", "Billion", "Trillion"};
        string[] TwentyToNinety = new string[] {"Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ",
        "Eighty ", "Ninety "};
        string[] OneToNinteen = new string[] {"One ", "Two ", "Three ", "Four ", "Five ", "Six ",
        "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", 
        "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "};
        
        int NumLength = 1;
        long[] SplitNum = new long[NumLength];
                
        while (number > 0)
        {
            SplitNum[NumLength - 1] = number % 1000;
            number = number / 1000;
            if ( number != 0 ) 
            {
                NumLength += 1;
                Array.Resize(ref SplitNum, NumLength);
            }
        }
 
        while ( NumLength > 0) 
        {
            long NumToWorkWith = SplitNum[NumLength - 1];

            if (NumLength != SplitNum.Length && NumToWorkWith != 0) {result += ", ";} //To add , only if the number to follow million, trillion... is not zero
            
            if ((NumToWorkWith / 100) > 0) {result += OneToNinteen[(NumToWorkWith / 100) - 1] + HundradToTrillion[0];}
            
            if ((NumToWorkWith % 100) > 0)
            { 
                if ((NumToWorkWith % 100) >= 20) 
                {
                    if (NumLength == 1 ) {result += "and ";}
                    result += TwentyToNinety[((NumToWorkWith % 100) / 10) - 2];
                    if ((NumToWorkWith % 10) > 0 ) { result += OneToNinteen[(NumToWorkWith % 10) - 1]; }
                }
                else
                {
                    if (NumLength == 1 ) {result += "and ";}
                    result += OneToNinteen[(NumToWorkWith % 100) - 1] ;
                }
            }
            
            if (NumLength > 1 && NumToWorkWith != 0) {result += HundradToTrillion[NumLength - 1];}
            
            NumLength -= 1;
        } 
        return result;
    }
}

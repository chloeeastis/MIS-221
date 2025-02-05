
string result = GetDigits();
Console.WriteLine("Output: " + result);

    static string GetDigits(){
        string result = "";
		int index = 0;
        string input = "112223";  
        int length = input.Length; 

        while (index < length)
        {
            char currentDigit = input[index]; 
            int count = 1;

            while (index + 1 < length && input[index] == input[index + 1])
            {
                count = count + 1;
                index = index + 1;
            }

            result = result + count.ToString() + currentDigit;
            index = index + 1;
        }

        return result;
    }



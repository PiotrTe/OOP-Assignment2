interface IValidation
{    


    //                //
    // Int validation //
    //                //


    // A method for validating if an input is an integer or not
    private static int ValidateInt(string input)                                           
    {
        int number;
        bool isValid = int.TryParse(input, out number);
        if (isValid == false)
        {
            Console.WriteLine($"Value of '{input}' is not integer");
            return -2147483648;
        }
        else
        {
            return number;
        }
    }

    // A method for validating if an input is within a given range
    private static bool ValidateIntRange(int input, int min, int max)                      
    {
        if (input < min || input > max)
        {
            Console.WriteLine($"Value of {input} is outside of acceptable boundaries ({min}-{max})");
            return false;
        }
        else
        {
            return true;
        }
    }

    // A method for validating if an input is an integer and within a given range
    protected static int GetIntInput(string inputMessage, int min, int max)                  
    {
        string? input;
        int intInput;
        while (true)
        {
            Console.WriteLine($"{inputMessage} (min: {min}, max: {max})");
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input cannot be empty");
                continue;
            }
            intInput = ValidateInt(input);

            if (intInput == -2147483648)
            {

                continue;
            }
            else
            {
                if (ValidateIntRange(intInput, min, max))                                 
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        return intInput;
    }

    // A method for validating if an input is an integer
    protected static int GetIntInput(string inputMessage)                                  
    {
        string? input;
        int intInput;
        while (true)
        {
            Console.WriteLine($"{inputMessage}");
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input cannot be empty");
                continue;
            }
            intInput = ValidateInt(input);

            if (intInput == -2147483648)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return intInput;
    }


    //                  //
    // Float validation //
    //                  //


    // A method for validating if an input is a float or not
    private static float ValidateFloat(string input)                                         
    {
        float number;
        bool isValid = float.TryParse(input, out number);
        if (isValid == false)
        {
            Console.WriteLine($"Value of '{input}' is not float");
            return -3.402823E+38f;
        }
        else
        {
            return number;
        }
    }

    // A method for validating if a float is within a certain range or not
    private static bool ValidateFloatRange(float input, float min, float max)                
    {
        if (input < min || input > max)
        {
            Console.WriteLine($"Value of {input} is outside of acceptable boundaries ({min}-{max})");
            return false;
        }
        else
        {
            return true;
        }
    }
    // A method for validating if an input is a float or not
    protected static float GetFloatInput(string inputMessage, float min, float max)          
    {
        string? input;
        float floatInput;
        while (true)
        {
            Console.WriteLine($"{inputMessage} (min: {min}, max: {max})");
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input cannot be empty");
                continue;
            }
            floatInput = ValidateFloat(input);

            if (floatInput == -3.402823E+38f)
            {
                continue;
            }
            else
            {
                
                if (ValidateFloatRange(floatInput, min, max))                               
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        return floatInput;
    }

    // A method for validating if an input is a float or not
    protected static float GetFloatInput(string inputMessage)                               
    {
        string? input;
        float floatInput;
        while (true)
        {
            Console.WriteLine($"{inputMessage}");
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Input cannot be empty");
                continue;
            }
            floatInput = ValidateFloat(input);

            if (floatInput == -3.402823E+38f)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return floatInput;
    }


}

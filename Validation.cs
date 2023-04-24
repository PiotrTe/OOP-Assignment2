    interface IValidation                                                        
    {                                                                                     
        // A method for validating if an input is an integer or not                       
        private static int ValidateInt(string input)                                           
        {
            int number;
            bool isValid = int.TryParse(input, out number); // Try to parse the input as an integer
            if (isValid == false)
            {
                Console.WriteLine($"Value of '{input}' is not integer"); // If the input is not an integer, display an error message
                return -2147483648;
            }
            else
            {
                return number; // If the input is an integer, return its value
            }
        }

        // A method for validating if an integer is within a certain range or not
        private static bool ValidateIntRange(int input, int min, int max)                      
        {
            if (input < min || input > max) // If the input is outside the given range, display an error message
            {
                Console.WriteLine($"Value of {input} is outside of acceptable boundaries ({min}-{max})");
                return false;
            }
            else
            {
                return true; // If the input is within the given range, return true
            }
        }

        // A method for getting an integer input from the user within a certain range
        protected static int GetIntInput(string inputMessage, int min, int max)                  
        {
            string? input;
            int intInput;
            while (true) // Keep asking for input until valid input is given
            {
                Console.WriteLine($"{inputMessage}"); // Display the input message
                input = Console.ReadLine(); // Get input from the user
                if (input == null)
                {
                    Console.WriteLine("Input cannot be empty");
                    continue;
                }
                intInput = ValidateInt(input); // Validate the input as an integer

                if (intInput == -2147483648) // If the input is not valid, ask for input again
                {

                    continue;
                }
                else
                {
                    // If the input is within the given range, return the input value
                    if (ValidateIntRange(intInput, min, max))                                 
                    {
                        break;
                    }
                    else // If the input is not within the given range, ask for input again
                    {
                        continue;
                    }
                }
            }
            return intInput; // Return the valid input value
        }
        // A method for validating if an input is a float or not
        private static float ValidateFloat(string input)                                         
        {
            float number;
            bool isValid = float.TryParse(input, out number); // Try to parse the input as a float
            if (isValid == false)
            {
                Console.WriteLine($"Value of '{input}' is not float"); // If the input is not a float, display an error message
                return -3.402823E+38f;
            }
            else
            {
                return number; // If the input is a float, return its value
            }
        }

        // A method for validating if a float is within a certain range or not
        private static bool ValidateFloatRange(float input, float min, float max)                
        {
            if (input < min || input > max) // If the input is outside the given range, display an error message
            {
                Console.WriteLine($"Value of {input} is outside of acceptable boundaries ({min}-{max})");
                return false;
            }
            else
            {
                return true; // If the input is within the given range, return true
            }
        }

        // A method for getting a float input from the user within a certain range

        protected static float GetFloatInput(string inputMessage, float min, float max)          
        {
            string? input;
            float floatInput;
            while (true) // Keep asking for input until valid input is given
            {
                Console.WriteLine($"{inputMessage}"); // Display the input message
                input = Console.ReadLine(); // Get input from the user
                if (input == null)
                {
                    Console.WriteLine("Input cannot be empty");
                    continue;
                }
                floatInput = ValidateFloat(input); // Validate the input as a float

                if (floatInput == -3.402823E+38f) // If the input is not valid, ask for input again
                {
                    continue;
                }
                else
                {
                    // If the input is within the given range, return the input value
                    if (ValidateFloatRange(floatInput, min, max))                               
                    {
                        break;
                    }
                    else // If the input is not within the given range, ask for input again
                    {
                        continue;
                    }
                }
            }
            return floatInput; // Return the valid input value
        }
    }
internal class Program
{
    


    // Display the arry 
    static void DisplayArray(double[,] Aray, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{Aray[i, j]:F2}\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    //  swap two row of  Aray مع بعض ههه
    static void SwapRows(double[,] Array, int rowA, int rowB)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            double temp = Array[rowA, j];
            Array[rowA, j] = Array[rowB, j];
            Array[rowB, j] = temp;
        }
    }

    // A main method that perform GaussJordan in a Aray
    static void Gauss(double[,] Array, int rows, int cols)
    {
        // Loop over the rows
        for (int i = 0; i < rows; i++)
        {
            // Find the pivot element 
            int pivot = i;
            for (int k = i + 1; k < rows; k++)
            {
                if (Math.Abs(Array[k, i]) > Math.Abs(Array[pivot, i]))
                {
                    pivot = k;
                }
            }
            

            // Swap the pivot 
            if (pivot != i)
            {
                SwapRows(Array, i, pivot);
            }

            // Divide row 
            double divisor = Array[i, i];
            if (divisor != 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    Array[i, j] /= divisor;
                }
            }
            // Print the Aray after dividing 
            Console.WriteLine($"After dividing row {i + 1} by {divisor:F2}:");
            DisplayArray(Array, rows, cols);
            Console.WriteLine();

            // Eliminate the other rows 
            for (int k = 0; k < rows; k++)
            {
                if (k != i )
                {
                    double factor = Array[k, i];
                    for (int j = i; j < cols; j++)
                    {
                        Array[k, j] -= factor * Array[i, j];
                    }

                    // Print the Aray after eliminating 
                    Console.WriteLine($"After eliminating row {k + 1} using row {i + 1}:");
                    DisplayArray(Array, rows, cols);
                    Console.WriteLine();
                }
            }
        }
    }

    //  solve a system
    static double[] SolveSystem(double[,] Array, int rows, int cols)
    {
        // Check if the system is consistent and has a unique solution
        if (rows + 1 != cols)
        {
            throw new ArgumentException("The system is not consistent or has no unique solution.");
        }

      
        Gauss(Array, rows, cols);

        double[] solution = new double[rows];
        for (int i = 0; i < rows; i++)
        {
            solution[i] = Array[i, cols - 1];
        }

        return solution;
    }

    static void Main(string[] args)
    {
       
       
       


        Console.WriteLine("enter rows");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("enter rows");
        int cols = int.Parse(Console.ReadLine());      // dimensions[1];

      
        double[,] Array = new double[rows, cols];

        
        Console.WriteLine("Enter each row of a sequence and separated by space:");

       
        for (int i = 0; i < rows; i++)
        {
            // Read the input for the current row
          string  input = Console.ReadLine();

            // Split the input by space and convert it to a double array
            double[] row = input.Split(' ').Select(double.Parse).ToArray();

            
            if (row.Length != cols)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            // Copy the row to the Aray
            for (int j = 0; j < cols; j++)
            {
                Array[i, j] = row[j];
            }
        }

        Console.WriteLine("The augmented matrix is:");
        DisplayArray(Array, rows, cols);
        Console.WriteLine();

        double[] solution = SolveSystem(Array, rows, cols);

      
        Console.WriteLine("The solution is:");
        foreach (double x in solution)
        {
            Console.WriteLine(x);
        }
    }
}


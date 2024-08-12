namespace SP_HW_16_07
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int[,] matrix1 = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            int[,] matrix2 = {
                { 7, 8 },
                { 9, 10 },
                { 11, 12 }
            };

            int[,] result = await MultiplyMatricesAsync(matrix1, matrix2);

            Console.WriteLine("Result:");
            PrintMatrix(result);
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static async Task<int[,]> MultiplyMatricesAsync(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (cols1 != rows2)
                throw new InvalidOperationException("Count of cols first matrix must be equal to count of rows second matrix.");

            int[,] result = new int[rows1, cols2];

            await Task.Run(() =>
            {
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < cols1; k++)
                        {
                            sum += matrix1[i, k] * matrix2[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
            });

            return result;
        }      
    }
}

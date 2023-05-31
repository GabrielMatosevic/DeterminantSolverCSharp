namespace Program
{
    class Program
    {
        static double [,] MatrixShortening (int Size, double[,] Matrix, int i)
        {
            double[,] ShortMatrix = new double[Size-1,Size-1];
            int xIndex = 0;
            int yIndex = 0;
            for (int x = 1; x < Size; x++, xIndex++)
            {
                yIndex = 0;
                for (int y = 0; y < Size; y++)
                {
                    if (y == i) continue;
                    ShortMatrix[xIndex,yIndex++] = Matrix[x,y];
                }
            }
            return ShortMatrix;
        }
        static double Determinant (int Size, double[,] Matrix)
        {
            if (Size == 2)
            {
                return (Matrix[0,0] * Matrix[1,1] - Matrix[0,1] * Matrix[1,0]);
            }else{
                double Result = 0;
                for (int i = 0; i < Size; i++)
                {
                    Result += Math.Pow(-1,i+2) * Matrix[0,i] * Determinant(Size-1, MatrixShortening(Size, Matrix, i));
                }
                return Result;
            }
        }

        static void Main(string[] args)
        {
            StreamReader Data = new StreamReader("Data.txt");
            int Size = Convert.ToInt32(Data.ReadLine());
            double[,] Matrix = new double[Size,Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Matrix[i,j] = Convert.ToDouble(Data.ReadLine());
                }
            }
            Console.WriteLine(Determinant(Size,Matrix));
        }
    }
}

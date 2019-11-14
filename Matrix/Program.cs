using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Matrix
{
    class Program
    {
       
        static void Main(string[] args)
        {

            Matrix Result  = new Matrix(4,4);
            Matrix matrixA = new Matrix(4,4);
            matrixA.FillMatrixWithRandom();

            Matrix matrixB = new Matrix(4,4);
            matrixB.FillMatrixWithRandom();

            Console.WriteLine("The A Matrix is ");
            matrixA.Print();

            Console.WriteLine("Maximum element in A Matrix matrix is " + matrixA.MaxElement());
            Console.WriteLine("Minimum element in A Matrix " + matrixA.MinElement());

            Console.WriteLine("Multiply with scalar  3");
            matrixA.ScalarMultiplication(3);
            matrixA.Print();

            Console.WriteLine("Traspose of  A matrix is " );
            Result = matrixA.TransposeMatrix();
            Result.Print();

            Console.WriteLine("Inverse of A matrix is ");
            Result = matrixA.InverseMatrix();
            Result.Print();

            Console.WriteLine("Is A matrix orthogonal " + matrixA.IsOrthogonal());

            Console.WriteLine("The B matrix is");
            matrixB.Print();

            Console.WriteLine("Addition of A  and B matrix is ");
            Result = matrixA.Addition(matrixB);
            Result.Print();

            Console.WriteLine("Multiplication of A  and B matrix is ");
            Result = matrixA.Multiply(matrixB);
            Result.Print();



            Console.ReadKey();
        }
    }
}

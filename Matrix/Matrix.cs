using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Matrix
{
    class Matrix
    {
        private double[,] matrix = new double[0,0];
        private int rows;
        private int columns;
        static  Random rand = new Random();

        public Matrix(int rows,int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new double[rows,columns];          
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] =0;
                }
            }
        }       
        public void FillMatrixWithRandom()
        {
            matrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(10);
                }
            }
        } // matrix mej grvum en 0-10 patahakn tver
        public void FillMatrix(double [,] fillMatrix)
        {
            matrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = fillMatrix[i,j];
                }
            }
        } // matrixin dzerqocv arjeq talu hamar 
        public int GetRows
        {
            get => this.rows;
        }
        public int GetColumns
        {
            get => this.columns;
        }
        public double GetElement(int indexRows,int indexColumns)
        {
          return this.matrix[indexRows,indexColumns];
        }
        public void Print()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    Console.Write(this.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }      

        public Matrix Addition(Matrix otherMatrix)
        {
            Matrix ResultMatrix = new Matrix(this.rows,this.columns);

            if (this.rows == otherMatrix.GetRows && this.columns == otherMatrix.GetColumns)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        ResultMatrix.matrix[i, j] =this.matrix[i,j] + otherMatrix.GetElement(i, j);
                    }
                }

            }
            else
            {
                Console.WriteLine("Fisrt matrix's rows and columns must be equal to second matrix's rows and columns");
            }
            return ResultMatrix;
        }  
        public Matrix Multiply(Matrix otherMatrix)
        {
            Matrix ResultMatrix = new Matrix(otherMatrix.GetRows, otherMatrix.GetColumns);
            
            if (this.GetRows == otherMatrix.GetRows)
            {
                for (int i = 0; i < otherMatrix.GetRows; i++)
                {
                    for (int j = 0; j < otherMatrix.GetColumns; j++)
                    {
                        ResultMatrix.matrix[i, j] = 0;
                        for (int k = 0; k < otherMatrix.GetRows; k++)
                        {
                            ResultMatrix.matrix[i, j] += this.matrix[i, k] * otherMatrix.GetElement(k, j);
                        }

                    }
                }


            }
            else
            {
                Console.WriteLine("Fisrt matrix's rows must be equal to other's columns");
            }
            return ResultMatrix;
        } 
        public void ScalarMultiplication(int value)
        {
            double[,] tempMatrix = new double[this.rows, this.columns];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    tempMatrix[i, j] = this.matrix[i, j] * value;
                }
            }
            this.matrix = tempMatrix;
            
        }
        public Matrix TransposeMatrix()
        {
            Matrix ResultMatrix = new Matrix(this.rows, this.columns);
            double[,] tempMatrix = new double[this.rows,this.columns];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    tempMatrix[i, j] = this.matrix[j, i];
                }
            }
            ResultMatrix.matrix = tempMatrix;
            return ResultMatrix;
        } //Veradarcnum e nor Matrix tipi object vor handisanum e skzbanakni trasnpose matrix-y
        public Matrix InverseMatrix()
        {
            Matrix ResultMatrix = new Matrix(this.rows, this.columns);
            ResultMatrix.matrix = this.matrix;
            double det = Determinant(this.rows, this.matrix);         
            double[,] tempMatrix = new double[this.rows, this.columns];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    tempMatrix[i, j] = ResultMatrix.TransposeMatrix().matrix[i,j]/ det;
                    
                }
            }
            ResultMatrix.matrix = tempMatrix;          
            return ResultMatrix;
        }  // Veradarcnum e nor Matrix tipi object vor handisanum e skzbanakni invers matrix
        private double Determinant(Matrix targetMatrix) {
            return  Determinant(targetMatrix.GetColumns, targetMatrix.matrix);
             
        } // qani vor nerqevi Determinant funckian grvac e  rekursiayov dra hamar hayatararel em sa , inverseMatrix- um aveli harmar ogtagorcelu hamar
        private double Determinant(int n, double[,] Matrix)
        {
            double determinant = 0;
            int subMatrixM, subMatrixN;
            double [,] SubMatrix = new double[n, n];
            if (n == 1)
            {
                return Matrix[0, 0];
            }
            if (n == 2)
            {
                return ((Matrix[0, 0] * Matrix[1, 1]) - (Matrix[1, 0] * Matrix[0, 1]));
            }
            else
            {
                for (int k = 0; k < n; k++)
                {
                    subMatrixM = 0;
                    for (int i = 1; i < n; i++)
                    {
                        subMatrixN = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            SubMatrix[subMatrixM, subMatrixN] = Matrix[i, j];
                            subMatrixN++;
                        }
                        subMatrixM++;
                    }
                    determinant = determinant + ((Math.Pow(-1, k)) * Matrix[0, k] * Determinant(n - 1, SubMatrix));
                }
            }
            return determinant;
        }
        public bool IsOrthogonal()
        {
            if (TransposeMatrix() == InverseMatrix())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public double MinElement()
        {
            double min = matrix[0,0];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (min >= matrix[i,j])
                    {
                        min = matrix[i,j]; 
                    }
                }

            }
            return min; 
        }
        public double MaxElement()
        {
            double max = double.MinValue;
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (max <= matrix[i, j])
                    {
                        max = matrix[i, j];
                    }
                }

            }
            return max;
        }

    }
}

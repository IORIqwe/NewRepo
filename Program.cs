using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Створіть клас Matrix, який представляє цілочисельну матрицю. В цьому класі створіть:
//Зубчастий двовимірний масив цілих чисел.
//Індексатор для доступу до елементів матриці за допомогою індексів row та column.

//Напишіть метод FillMatrixRandom(int rows, int columns, int min, int max), який заповнює матрицю випадковими числами в діапазоні від min до max.
//Створіть об'єкт класу Matrix, заповніть його випадковими значеннями та виведіть матрицю на консоль. Потім, за допомогою індексатора, знайдіть та виведіть значення певного елемента матриці.

namespace Module
{

    class Matrix
    {

        private int[][] _Matrix { set; get; }


        public Matrix(int[][] matrix) 
        { 
            for (int j = 0;j < matrix.Length; j++)
            {
                for(int i = 0; i < matrix.Length; i++)
                {
                    _Matrix[i] = matrix[i];
                }
                _Matrix[j] = matrix[j];
            }
        }

        public override string ToString()
        {
            return $"Matrix {_Matrix}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();

            Console.WriteLine(matrix.ToString());

        }
    }
}

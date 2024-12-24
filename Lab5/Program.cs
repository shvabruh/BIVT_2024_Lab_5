using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] A = { { -1, -2, -3 },
                     { -150, 5, -7 },
                     { -12 , 90, 0 },
                     { 100,120,190}};

        int[,] B = { { -100, -45, 3 },
                      { -1, -5, 7 },
                     { 24, -90, -8 } };


        A = SortRowsByMaxElement(A);
        B = SortRowsByMaxElement(B);

        // create and use SortRowsByMaxElement(matrix);
        int[,] SortRowsByMaxElement(int[,] matrix)
        {
            int[] maximums = new int[matrix.GetLength(0)];
            int[] sorted = new int[matrix.GetLength(0)];
            int[] indexes = new int[matrix.GetLength(0)];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int index = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index = i;
                    }
                }
                maximums[i] = max;
                sorted[i] = max;
                indexes[i] = index;
            }


            //  Эффективная гномья сортировка

            for (int i = 1, j = 2; i < sorted.Length;)
            {
                if (i == 0 || sorted[i] <= sorted[i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int temp = sorted[i];
                    sorted[i] = sorted[i - 1];
                    sorted[i - 1] = temp;
                    i--;
                }
            }
            //for (int i = 0; i < sorted.Length; i++)
            //{
            //    Console.WriteLine(sorted[i]);
            //}
            int[] sorted_ind = new int[matrix.GetLength(0)];

            for (int i = 0; i < maximums.Length; i++)
            {
                for (int j = 0; j < sorted.Length; j++)
                {
                    if (maximums[j] == sorted[i])
                    {
                        indexes[i] = j;
                        maximums[j] = int.MaxValue;
                        sorted[i] = int.MinValue;
                    }
                }

            }
            int[,] new_matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < indexes.Length; k++)
                {
                    if (indexes[k] == i)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            new_matrix[k, j] = matrix[i, j];
                        }
                    }
                }

            }
            return new_matrix;
        }

        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.Write(B[i, j] + " ");
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine("bruh");
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                Console.Write(A[i, j] + " ");
            }
            Console.WriteLine("\n");
        }
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        if (n < k || n < 0 || k < 0) return 0;
        long answer = 0;
        answer = Combianations(n, k);
        // code here

        // create and use Combinations(n, k);
        static int Combianations(int n, int k)
        {
            int combinations = Factorial(n) / Factorial(k) * Factorial(n - k);
            return combinations;
        }
        // create and use Factorial(n);
        static int Factorial(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        if (first.Length != second.Length || first.Length != 3 || second.Length != 3) answer = -1;
        else if (first[0] >= first[1] + first[2] || first[1] >= first[0] + first[2] || first[2] >= first[1] + first[0] || second[0] >= second[1] + second[2] || second[1] >= second[0] + second[2] || second[2] >= second[1] + second[0]) answer = -1;
        else
        {
            if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2]))
            {
                answer = 1;
            }
            if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2]))
            {
                answer = 2;
            }
            if (GeronArea(first[0], first[1], first[2]) == GeronArea(second[0], second[1], second[2]))
            {
                answer = 0;
            }
        }




        // code here

        // create and use GeronArea(a, b, c);
        static double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return S;

        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) answer = 1;
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) answer = 2;
        else answer = 0;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    private static double GetDistance(double v, double a, int t)
    {
        double S = v * t + (a * t * t) / 2;
        return S;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        for (int time = 1; ; time++)
        {
            if (GetDistance(v1, a1, time) <= GetDistance(v2, a2, time))
            {
                answer = time;
                break;
            }
        }
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        FindMaxIndex(A, out int row_A, out int column_A);
        FindMaxIndex(B, out int row_B, out int column_B);

        int temp = A[row_A, column_A];
        A[row_A, column_A] = B[row_B, column_B];
        B[row_B, column_B] = temp;
    }
        // create and use FindMaxIndex(matrix, out row, out column);
        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            int r = 0;
            int c = 0;
            int max_element = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max_element)
                    {
                        max_element = matrix[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            row = r;
            column = c;
        }
        
        // end
    

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        int max_B = FindDiagonalMaxIndex(B);
        int max_C = FindDiagonalMaxIndex(C);

        int[,] new_B = new int[B.GetLength(0) - 1, B.GetLength(0)];
        int[,] new_C = new int[C.GetLength(0) - 1, C.GetLength(0)];

        for (int i = 0; i < max_B; i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                new_B[i, j] = B[i, j];
            }
        }
        for (int i = max_B; i < new_B.GetLength(0); i++)
        {
            for (int j = 0; j < new_B.GetLength(1); j++)
            {
                new_B[i, j] = B[i + 1, j];
            }
        }
        for (int i = 0; i < max_C; i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                new_C[i, j] = C[i, j];
            }
        }
        for (int i = max_C; i < new_C.GetLength(0); i++)
        {
            for (int j = 0; j < new_C.GetLength(1); j++)
            {
                new_C[i, j] = C[i + 1, j];
            }
        }
        B = new_B;
        C = new_C;
    }
        //  create and use method FindDiagonalMaxIndex(matrix);
        static int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max_ind = 0;
            int max_element = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max_element < matrix[i, j] && i == j)
                    {
                        max_ind = i;
                        max_element = matrix[i, j];
                    }
                }

            }
            return max_ind;

        }

        // end
    

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        FindMaxInColumn(A, 0, out int rowIndex_A);
        FindMaxInColumn(B, 0, out int rowIndex_B);

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int temp = A[rowIndex_A, i];
            A[rowIndex_A, i] = B[rowIndex_B, i];
            B[rowIndex_B, i] = temp;
        }
    }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        static void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
        {
            int max_row_ind = 0;
            int max_el = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (max_el < matrix[i, 0])
                {
                    max_row_ind = i;
                    max_el = matrix[i, 0];
                }
            }
            rowIndex = max_row_ind;
        }
        
        // end
    

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        if (B.GetLength(0) != 4 || B.GetLength(1) != 5 || C.GetLength(0) != 5 || C.GetLength(1) != 6) return;

        int count_max_row = int.MinValue;
        int row_index = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            int count = CountRowPositive(B, i);
            if (count > count_max_row)
            {
                count_max_row = count;
                row_index = i;
            }
        }

        int count_max_col = int.MinValue;
        int col_index = 0;
        for (int i = 0; i < C.GetLength(1); i++)
        {
            int count = CountColumnPositive(C, i);
            if (count > count_max_col)
            {
                count_max_col = count;
                col_index = i;
            }
        }

        int[] C_max = new int[C.GetLength(0)];
        for (int i = 0; i < C.GetLength(0); i++)
        {
            C_max[i] = C[i, col_index];
        }

        int[,] new_B = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0; i <= row_index; i++)
        {
            for (int j = 0; j < new_B.GetLength(1); j++)
            {
                new_B[i, j] = B[i, j];
            }
        }
        for (int i = 0; i < new_B.GetLength(1); i++)
        {
            new_B[row_index + 1, i] = C_max[i];
        }
        for (int i = row_index + 1; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                new_B[i + 1, j] = B[i, j];
            }
        }
        B = new_B;
    }
        //for (int i = 0; i < new_B.GetLength(0); i++)
        //{
        //    for (int j = 0; j < new_B.GetLength(1); j++)
        //    {
        //        Console.Write(new_B[i, j] + " ");
        //    }
        //    Console.WriteLine("\n");
        //}
        //Console.WriteLine("bruh");

        // create and use CountRowPositive(matrix, rowIndex);
        public int CountRowPositive(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] > 0)
                {
                    count++;
                }
            }
            return count;
        }
        // create and use CountColumnPositive(matrix, colIndex);
        public int CountColumnPositive(int[,] matrix, int colIndex)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        
        // end
    

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        //if (A.GetLength(0) != 6 || A.GetLength(1) != 5 || C.GetLength(0) != 7 || C.GetLength(1) != 4) return null;

        int[] sum_A = SumPositiveElementsInColumns(A);
        int[] sum_C = SumPositiveElementsInColumns(C);

        int[] sum_A_C = new int[sum_A.Length + sum_C.Length];

        for (int i = 0; i < sum_A.Length; i++)
        {
            sum_A_C[i] = sum_A[i];
        }

        int k = sum_A.Length;
        for (int i = 0; i < sum_C.Length; i++)
        {
            sum_A_C[i + k] = sum_C[i];

        }

        answer = sum_A_C;

        // create and use SumPositiveElementsInColumns(matrix);
        static int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] sum = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int col_sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        col_sum += matrix[i, j];
                    }
                }
                sum[j] = col_sum;
            }
            return sum;
        }
        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        FindMaxIndex(A, out int max_row_A, out int max_col_A);
        FindMaxIndex(B, out int max_row_B, out int max_col_B);

        int temp = A[max_row_A, max_col_A];
        A[max_row_A, max_col_A] = B[max_row_B, max_col_B];
        B[max_row_B, max_col_B] = temp;

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
        void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            int max_el = int.MinValue;
            int r = 0;
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max_el)
                    {
                        max_el = matrix[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            row = r;
            column = c;
        }
        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        int min_el = int.MaxValue;
        int min_ind = 0;

        int max_el = int.MinValue;
        int max_ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max_el)
                {
                    max_el = matrix[i, j];
                    max_ind = i;
                }
                if (matrix[i, j] < min_el)
                {
                    min_el = matrix[i, j];
                    min_ind = i;
                }
            }
        }


        matrix = RemoveRow(matrix, min_ind);

        if (min_ind < max_ind)
        {
            matrix = RemoveRow(matrix, max_ind - 1);
        }
        else if (min_ind > max_ind)
        {
            matrix = RemoveRow(matrix, max_ind);
        }
    }
    // create and use RemoveRow(matrix, rowIndex);
    int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] new_matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

        for (int i = 0; i < rowIndex; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                new_matrix[i, j] = matrix[i, j];
            }
        }
        for (int i = rowIndex; i < new_matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                new_matrix[i, j] = matrix[i + 1, j];
            }
        }
        return new_matrix;
    }
    // end


    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        int[] answer_array = new int[3];

        answer_array[0] = GetAverageWithoutMinMax(A);
        answer_array[1] = GetAverageWithoutMinMax(B);
        answer_array[2] = GetAverageWithoutMinMax(C);

        if (answer_array[0] < answer_array[1] && answer_array[1] < answer_array[2]) answer = 1;
        else if (answer_array[0] > answer_array[1] && answer_array[1] > answer_array[2]) answer = -1;
        else answer = 0;

        // create and use GetAverageWithoutMinMax(matrix);

        int GetAverageWithoutMinMax(int[,] matrix)
        {
            int average;
            int summa = 0;
            int n = 0;
            int max_el = int.MinValue;
            int min_el = int.MaxValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max_el < matrix[i, j])
                    {
                        max_el = matrix[i, j];
                    }
                    if (min_el > matrix[i, j])
                    {
                        min_el = matrix[i, j];
                    }
                    summa += matrix[i, j];
                    n++;
                }
            }
            summa = summa - min_el - max_el;
            n -= 2;
            average = summa / n;
            return average;
        }
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        //for (int i = 0; i < B.GetLength(0); i++)
        //{
        //    for (int j = 0; j < B.GetLength(1); j++)
        //    {
        //        Console.Write(B[i, j] + " ");
        //    }
        //    Console.WriteLine("\n");
        //}
        //Console.WriteLine("bruh");
        //for (int i = 0; i < A.GetLength(0); i++)
        //{
        //    for (int j = 0; j < A.GetLength(1); j++)
        //    {
        //        Console.Write(A[i, j] + " ");
        //    }
        //    Console.WriteLine("\n");
        //}
        //Console.WriteLine("bruh");

        A = SortRowsByMaxElement(A);
        B = SortRowsByMaxElement(B);

        //for (int i = 0; i < B.GetLength(0); i++)
        //{
        //    for (int j = 0; j < B.GetLength(1); j++)
        //    {
        //        Console.Write(B[i, j] + " ");
        //    }
        //    Console.WriteLine("\n");
        //}
        //Console.WriteLine("bruh");
        //for (int i = 0; i < A.GetLength(0); i++)
        //{
        //    for (int j = 0; j < A.GetLength(1); j++)
        //    {
        //        Console.Write(A[i, j] + " ");
        //    }
        //    Console.WriteLine("\n");
        //}
    }
    // create and use SortRowsByMaxElement(matrix);
    int[,] SortRowsByMaxElement(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        int[] tempind = new int[matrix.GetLength(0)];
        int[,] M = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = matrix[i, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            temp[i] = max;
            tempind[i] = i;
        }
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < temp.Length - 1 - i; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                    (tempind[j], tempind[j + 1]) = (tempind[j + 1], tempind[j]);
                }
            }
        }
        for (int j = 0; j < M.GetLength(0); j++)
        {
            for (int i = 0; i < M.GetLength(1); i++)
            {
                M[j, i] = matrix[tempind[j], i];
            }
        }
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                matrix[i, j] = M[i, j];
            }
        }
        return matrix;
    }
    //for (int i = 0; i < B.GetLength(0); i++)
    //{
    //    for (int j = 0; j < B.GetLength(1); j++)
    //    {
    //        Console.Write(B[i, j] + " ");
    //    }
    //    Console.WriteLine("\n");
    //}
    //Console.WriteLine("bruh");
    //for (int i = 0; i < A.GetLength(0); i++)
    //{
    //    for (int j = 0; j < A.GetLength(1); j++)
    //    {
    //        Console.Write(A[i, j] + " ");
    //    }
    //    Console.WriteLine("\n");
    //}
    // end


    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix = RemoveRow(matrix, i);
                }
            }
        }
        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        {
            answerA = CreateArrayFromMins(A);
            answerB = CreateArrayFromMins(B);
        }

        // create and use CreateArrayFromMins(matrix);
        int[] CreateArrayFromMins(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                array[i] = min;
            }
            return array;
        }

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        A = MatrixValuesChange(A);
        B = MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);
        double[,] MatrixValuesChange(double[,] matrix)
        {


            double[] sorted = new double[matrix.GetLength(0) * matrix.GetLength(1)];

            for (int i = 0, count = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sorted[count] = matrix[i, j];
                    count++;
                }
            }

            // эффективная гномья сортировка

            for (int i = 1, j = 2; i < sorted.Length;)
            {
                if (i == 0 || sorted[i] <= sorted[i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    double temp = sorted[i];
                    sorted[i] = sorted[i - 1];
                    sorted[i - 1] = temp;
                    i--;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == sorted[0] || matrix[i, j] == sorted[1] || matrix[i, j] == sorted[2] || matrix[i, j] == sorted[3] || matrix[i, j] == sorted[4])
                    {
                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] *= 2;
                        }
                        else
                        {
                            matrix[i, j] /= 2;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] /= 2;
                        }
                        else
                        {
                            matrix[i, j] *= 2;
                        }
                    }
                }
            }
            return matrix;
        }
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int[] minimums = new int[matrix.GetLength(0)];
            int[] sorted_ind = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                minimums[i] = count;
            }

            int max_ind = 0;
            int max_min = int.MinValue;

            for (int i = 0; i < minimums.Length; i++)
            {
                if (minimums[i] > max_min)
                {
                    max_min = minimums[i];
                    max_ind = i;
                }
            }
            return max_ind;
        }
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        A = ReplaceMaxElementOdd(A);
        A = ReplaceMaxElementEven(A);
        B = ReplaceMaxElementOdd(B);
        B = ReplaceMaxElementEven(B);
    }
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
        {
            int max = int.MinValue;
            columnIndex = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[rowIndex, i] > max)
                {
                    max = matrix[rowIndex, i];
                    columnIndex = i;
                }
            }
        }

        // create and use ReplaceMaxElementOdd(matrix, row, column);

        int[,] ReplaceMaxElementOdd(int[,] matrix)
        {
            int j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 != 0)
                {
                    FindRowMaxIndex(matrix, i, out j);
                    matrix[i, j] = 0;
                }
            }
            return matrix;
        }

        // create and use ReplaceMaxElementEven(matrix, row, column);

        int[,] ReplaceMaxElementEven(int[,] matrix)
        {
            int j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    FindRowMaxIndex(matrix, i, out j);
                    matrix[i, j] *= (j + 1);
                }
            }
            return matrix;
        }

        // end
    

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3

    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);

    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] answer = new double[(int)((b - a) / h) + 1, 2];

        for (int i = 0; i < answer.GetLength(0); i++)
        {
            answer[i, 0] = sFunction(a + i * h);
            answer[i, 1] = yFunction(a + i * h);
        }

        return answer;
    }

    public double y_A(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public double y_B(double x)
    {
        return (x * x - (Math.PI * Math.PI / 3)) / 4;
    }

    public double s_A(double x)
    {
        double answer = 1.0, lastFactorial = 1.0, elem = Math.Cos(x);

        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            answer += elem;
            lastFactorial *= i;
            elem = Math.Cos(i * x) / lastFactorial;
        }

        return answer;
    }

    public double s_B(double x)
    {
        double answer = 0, sign = -1.0, elem = -Math.Cos(x);

        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            answer += elem;
            sign = -sign;
            elem = sign * Math.Cos(i * x) / (i * i);
        }

        return answer;
    }

    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        firstSumAndY = GetSumAndY(s_A, y_A, 0.1, 1.0, 0.1);
        secondSumAndY = GetSumAndY(s_B, y_B, Math.PI / 5.0, Math.PI, Math.PI / 25.0);
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public delegate void SwapDirection(ref double[] array);

    public void SwapRight(ref double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }

    public void SwapLeft(ref double[] array)
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }

    public double GetSum(double[] array, int start, int h)
    {
        double answer = 0;

        for (int i = start; i < array.Length; i += h)
            answer += array[i];

        return answer;
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        double average = 0;

        for (int i = 0; i < array.Length; i++) average += array[i];

        if (array.Length != 0)
            average /= array.Length;

        SwapDirection swapper = default(SwapDirection);

        if (array[0] > average)
            swapper = SwapLeft;
        else
            swapper = SwapRight;

        swapper(ref array);
        answer = GetSum(array, 1, 2); 

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }


    public delegate double FunctionDelegate(double x);
    public double Func1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double Func2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public int CountSignFlips(YFunction yfunction, double a, double b, double h)
    {
        int count = 0;
        double timeY = yfunction(a);
        for (double x = a + h; x <= b; x += h)
        {
            double prTime = yfunction(x);
            if (timeY * prTime < 0)
            {
                count++;
            }
            if (prTime != 0)
            {
                timeY = prTime;
            }
        }
        return count;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;
        double a1 = 0, b1 = 2, h1 = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;
        func1 = CountSignFlips(Func1, a1, b1, h1);
        func2 = CountSignFlips(Func2, a2, b2, h2);
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public delegate int CountPositive(int[,] matrix, int index);

    public void InsertColumn(ref int[,] matrixB, int CountRow, int[,] matrixC, int CountColumn)
    {
        int rowsB = matrixB.GetLength(0), colsB = matrixB.GetLength(1);
        int rowsC = matrixC.GetLength(0), colsC = matrixC.GetLength(1);

        int[,] newB = new int[rowsB + 1, colsB];

        for (int j = 0; j < colsB; j++)
        {
            newB[CountRow + 1, j] = matrixC[j, CountColumn];
        }

        for (int i = 0; i < rowsB; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                newB[i <= CountRow ? i : i + 1, j] = matrixB[i, j];
            }
        }

        matrixB = newB;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        int maxRow = int.MinValue, maxCol = int.MinValue;
        int maxRowPos = 0, maxColPos = 0;

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int count = CountRowPositive(B, i);
            if (count > maxRow)
            {
                maxRow = count;
                maxRowPos = i;
            }
        }

        for (int j = 0; j < C.GetLength(1); j++)
        {
            int count = CountColumnPositive(C, j);
            if (count > maxCol)
            {
                maxCol = count;
                maxColPos = j;
            }
        }

        InsertColumn(ref B, maxRowPos, C, maxColPos);
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);
    public static int FindMax(int[,] matrix)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }
    public static int FindMin(int[,] matrix)
    {
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }
    public static int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int max = findMax(matrix);
        int min = findMin(matrix);
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    count++;
                    break;
                }
            }
        }
        int[] rows = new int[count];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    rows[count] = i;
                    count++;
                    break;
                }
            }
        }
        int[,] A = new int[matrix.GetLength(0) - count, matrix.GetLength(1)];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (count < rows.Length && i == rows[count])
            {
                count++;
                continue;
            }
            else
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i - count, j] = matrix[i, j];
                }
            }
        }
        return A;
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        matrix = RemoveRows(matrix, FindMax, FindMin);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }



    public delegate int[,] ReplaceMaxElement(int[,] matrix);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement ReplaceMaxElementOdd, ReplaceMaxElement ReplaceMaxElementEven)
    {
        ReplaceMaxElementEven(matrix);
        ReplaceMaxElementOdd(matrix);
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part

    public delegate void MatrixConverter(double[,] matrix);

    public static void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = 0; j <= n - 2; j++)
        {
            for (int k = j + 1; k <= n - 1; k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m <= n - 1; m++) matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
            }
        }
    }

    public static void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = n - 1; j >= 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double p = matrix[k, j] / matrix[j, j];

                for (int m = j; m >= 0; m--) matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
            }
        }
    }

    public static void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }

    public static void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        

        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1)) return matrix;
        MatrixConverter[] mc = new MatrixConverter[4] { ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal };

        mc[index](matrix);

        return matrix;
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

    }
}
    #endregion

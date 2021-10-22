using System;

namespace LinearAlgebraIRL
{
    class MatrixCalculator
    {
        enum SpacerOn { Middle, Bottom } // enum MatrixType { Frontera, Cruz, Identidad, IdentidadInver, Centro, TrianSuperior, TrianInferior, TrianInvSup }
        static void Main(string[] args)
        {//                                                                 Variables
            int E = 6;
            int Z = 9;
            int luckyNumber = 7;
            int[,] matrix = new int[E, Z];
            int[,] matrix2 = new int[luckyNumber, luckyNumber];
            int[,] matrix3 = new int[4, 20];
            int numberOfOperations = 4;
            int numberOfOnes = new int();
            //                                                              Body
            for (int i = 0; i < numberOfOperations; i++)
            {
                MatrixSelect(i);
            }
            Spacer(0, SpacerOn.Bottom);
            Console.WriteLine();
            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine(".");
            }
            Console.WriteLine();
            Console.WriteLine("Fin de la transmisión.");
            Spacer(0, SpacerOn.Bottom);
            //                                                              Functions
            void MatrixSelect(int select)
            {
                if (select == 0)
                {
                    numberOfOnes = MatrizFrontera(E, Z);
                    Console.WriteLine();
                    NumberOf1s(numberOfOnes);
                    Spacer(matrix.GetLength(1), SpacerOn.Middle);
                }
                else if (select == 1)
                {
                    numberOfOnes = MatrizCruz();
                    Console.WriteLine();
                    NumberOf1s(numberOfOnes);
                    Spacer(matrix2.GetLength(1), SpacerOn.Middle);
                }
                else if (select == 2)
                {
                    numberOfOnes = MatrizIDentidad();
                    Console.WriteLine();
                    NumberOf1s(numberOfOnes);
                    Spacer(matrix3.GetLength(1), SpacerOn.Middle);
                }
                else if (select == 3)
                {
                    MatrizIDentidadInvertida();
                    Spacer(matrix3.GetLength(1), SpacerOn.Middle);
                }
                Console.WriteLine();
            }
            void NumberOf1s(int number)
            {
                Console.WriteLine("El numero de 1's es: " + number + ".");
                numberOfOnes = new int();
                Console.WriteLine();
            }
            void Spacer(int length, SpacerOn where)
            {
                if (where == SpacerOn.Middle)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write("☣");
                    for (int i = 0; i < (length - 2); i++)
                    {
                        Console.Write("∫ ");
                    }
                    Console.Write("∫☣ \n ");
                    for (int i = 0; i < (length - 2); i++)
                    {
                        Console.Write(" ∫");
                    }
                    Console.WriteLine(" ☣");
                    Console.Write("☣");
                    for (int i = 0; i < (length - 2); i++)
                    {
                        Console.Write("∫ ");
                    }
                    Console.Write("∫☣");
                }
                else
                {
                    int size = new int();
                    if (matrix.GetLength(1) > matrix2.GetLength(1))
                    {
                        if (matrix.GetLength(1) > matrix3.GetLength(1))
                        {
                            size = matrix.GetLength(1);
                        }
                    }
                    else
                    {
                        if (matrix2.GetLength(1) > matrix.GetLength(1))
                        {
                            if (matrix2.GetLength(1) > matrix3.GetLength(1))
                            {
                                size = matrix2.GetLength(1);
                            }
                        }
                        else
                        {
                            size = matrix3.GetLength(1);
                        }
                    }
                }
            }
            void HeaderInfo(string name, int sizeX, int sizeY)
            {
                string tmpString = "  Matriz " + name + "® - [" + sizeX + "," + sizeY + "]";
                Console.WriteLine();
                Console.Write("*");
                for (int i = 0; i < (tmpString.Length + 1); i++)
                {
                    Console.Write(".");
                }
                Console.WriteLine("*");
                Console.WriteLine("  Matriz " + name + "® - [" + sizeX + "," + sizeY + "]");
                Console.Write("*");
                for (int i = 0; i < (tmpString.Length + 1); i++)
                {
                    Console.Write(".");
                }
                Console.WriteLine("* \n");
            }//                                                              Opeations
            int MatrizFrontera(int sizeX, int sizeY)
            {
                HeaderInfo("Frontera", matrix.GetLength(0), matrix.GetLength(1));
                for (int i = 0; i < sizeX; i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (i == 0 || i == (matrix.GetLength(0) - 1) ||
                            j == 0 || j == (matrix.GetLength(1) - 1))
                        {
                            matrix[i, j] = 1;
                            numberOfOnes++;
                        }
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine("|");
                }
                return numberOfOnes;
            }
            int MatrizCruz()
            {
                HeaderInfo("Cruz", matrix2.GetLength(0), matrix2.GetLength(1));
                float midX = (float)(matrix2.GetLength(0) / 2) + 1;
                float midY = (float)(matrix2.GetLength(1) / 2) + 1;

                if (matrix2.GetLength(0) % 2 != 1)
                {
                    Console.WriteLine("ERROR: Las columnas no tienen mitad!");
                }
                else
                {
                    midX = (float)(matrix2.GetLength(0) / 2);
                    if (matrix.GetLength(1) % 2 != 1)
                    {
                        Console.WriteLine("ERROR: Las filas no tienen mitad!");
                    }
                    else
                    {
                        midY = (float)(matrix2.GetLength(1) / 2);
                        for (int i = 0; i < matrix2.GetLength(0); i++)
                        {
                            Console.Write("| ");
                            for (int j = 0; j < matrix2.GetLength(1); j++)
                            {
                                if (i == midX || j == midY)
                                {
                                    matrix2[i, j] = 1;
                                    numberOfOnes++;
                                }
                                Console.Write(matrix2[i, j] + " ");
                            }
                            Console.WriteLine("|");
                        }
                    }
                }
                return numberOfOnes;
            }
            int MatrizIDentidad()
            {
                HeaderInfo("Identidad", matrix3.GetLength(0), matrix3.GetLength(1));
                int remainingColmuns = new int();
                remainingColmuns = matrix3.GetLength(1) - matrix3.GetLength(0);

                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix3.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            matrix3[i, j] = 1;
                            numberOfOnes++;
                        }
                        Console.Write(matrix3[i, j] + " ");
                    }
                    Console.WriteLine("|");
                }
                int nullity = matrix3.GetLength(1) - matrix3.GetLength(0);
                Console.WriteLine();
                if (nullity > 0)
                {
                    Console.WriteLine("La matriz tiene infinitas soluciones!");
                    Console.Write("La matriz tiene nulidad: " + nullity + " !");
                }
                else if (nullity < 0)
                {
                    Console.WriteLine("La matriz no tiene soluciones reales!");
                }
                else
                {
                    Console.WriteLine("La matriz es cuadrada!");
                    Console.WriteLine("La matrix tiene unica solucion!");
                }
                return numberOfOnes;
            }
            void MatrizIDentidadInvertida()
            {
                matrix3 = new int[4, 20];
                HeaderInfo("Identidad Invertida", matrix3.GetLength(0), matrix3.GetLength(1));
                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix3.GetLength(1); j++)
                    {
                        if (j == matrix3.GetLength(1) - (1 + i))
                        {
                            matrix3[i, j] = 1;
                        }
                        Console.Write(matrix3[i, j] + " ");
                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine();
            }
        }
    }
}// 𝓣𝓱𝓮 𝓮𝓷𝓭...
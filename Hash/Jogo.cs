using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    internal class Jogo
    {

        //criar jogo da velha
        //string [,] = matriz bidimensional - linhas e colunas
        public string[,] Tabuleiro { get; set; }  //get = pegar o valor e retornar ao usuario, set = altera o valor de uma variavel
        public int contador { get; set; }
        //construtor
        public Jogo()
        {
            Tabuleiro = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            contador = 0;

        }

        //jogadores
        //inicio
        public void Iniciar()  //metodo (Jogo) ou função (Program)            
        {
            while (contador < 9)
            {
                Console.Clear();
                Imprimir();
                Push();
                Console.Clear();
                Imprimir();
                VerificaStatus();               
            }
            //Console.Clear();
            //Imprimir();


            //nome dos jogadores
            //ver quem é X ou O

        }

        public void Push() //inserir valores
        {
            Console.WriteLine("Digite um valor:");
            string Valor = Console.ReadLine();
            for (int linha = 0; linha < Tabuleiro.GetLength(0); linha++)  //0 de linha
            {
                for (int coluna = 0; coluna < Tabuleiro.GetLength(1); coluna++)  // 1 de coluna
                {
                    if (Tabuleiro[linha, coluna] == Valor)
                    {
                        if (contador % 2 == 0)
                        {
                            Tabuleiro[linha, coluna] = "X"; // hora que entra é zero (par)
                        }
                        else
                        {
                            Tabuleiro[linha, coluna] = "O"; 
                        }
                        contador++; //alternar jogada do X e O
                    }
                }
            }
        }

        public void Imprimir()
        {
            Console.WriteLine(@"

            _{0}_|_{1}_|_{2}_
            _{3}_|_{4}_|_{5}_
             {6} | {7} | {8}
        ", Tabuleiro[0, 0], Tabuleiro[0, 1], Tabuleiro[0, 2], Tabuleiro[1, 0], Tabuleiro[1, 1], Tabuleiro[1, 2], Tabuleiro[2, 0], Tabuleiro[2, 1], Tabuleiro[2, 2]);

        }

        public void VerificaStatus() //metodo
        {
            int X = 0, O = 0, DiagonalPrincipalX = 0, DiagonalPrincipalO = 0, DiagonalSecundariaX = 0, DiagonalSecundariaO = 0;
            for (int linha = 0; linha < Tabuleiro.GetLength(0); linha++)  //verifica linhas iguais X X X
            {
                for (int coluna = 0; coluna < Tabuleiro.GetLength(1); coluna++)  // diagonal
                {
                    if (linha == coluna)
                    {
                        if (Tabuleiro[linha, coluna] == "X")
                        {
                            DiagonalPrincipalX++;
                        }
                        else if (Tabuleiro[linha, coluna] == "O")
                        {
                            DiagonalPrincipalO++;

                        }

                    }

                    if (Tabuleiro[linha, coluna] == "X")  
                    {
                        X++;
                    }
                    else if (Tabuleiro[linha, coluna] == "O")
                    {
                        O++;
                    }
                }
                if (X == 3 || O == 3 || DiagonalPrincipalX == 3 || DiagonalPrincipalO == 3)
                {
                    if ((X == 3) || (DiagonalPrincipalX == 3))
                    {
                        Console.WriteLine("O jogador do X ganhou");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                    if ((O == 3) || (DiagonalPrincipalO == 3))
                    {
                        Console.WriteLine("O jogador do O ganhou");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                }
                else
                {
                    X = 0;
                    O = 0;
                }
            }
            for (int linha = 0; linha < Tabuleiro.GetLength(0); linha++)
            {
                for (int coluna = Tabuleiro.GetLength(1) - 1; coluna >= 0; coluna--)
                {

                    if (linha + coluna == 2)
                    {
                        if (Tabuleiro[linha, coluna] == "X")
                        {
                            DiagonalSecundariaX++;
                        }
                        else if (Tabuleiro[linha, coluna] == "O")
                        {
                            DiagonalSecundariaO++;

                        }
                        if (X == 3 || O == 3 || DiagonalSecundariaX == 3 || DiagonalSecundariaO == 3)
                        {
                            if ((X == 3) || (DiagonalSecundariaX == 3))
                            {
                                Console.WriteLine("O jogador do X ganhou");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;
                            }
                            if ((O == 3) || (DiagonalSecundariaO == 3))
                            {
                                Console.WriteLine("O jogador do O ganhou");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;
                            }
                        }
                    }
                }
            }
            for (int coluna = 0; coluna < Tabuleiro.GetLength(1); coluna++)
            {
                X = 0;
                O = 0;
                for (int linha = 0; linha < Tabuleiro.GetLength(0); linha++)
                {
                    if (Tabuleiro[linha, coluna] == "X")
                    {
                        X++;
                        if (X == 3)
                        {
                            Console.WriteLine("O jogador do X ganhou");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        }


                    }
                    else if (Tabuleiro[linha, coluna] == "O")
                    {
                        O++;
                        if(O == 3)
                        {
                            Console.WriteLine("O jogador do O ganhou");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        }
                    }
                }
            }             
                      
            if (contador == 9)
            {
                Console.WriteLine("Empatou!!!");
            }
        }
    }
}


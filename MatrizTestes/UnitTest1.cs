namespace MatrizTestes
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var contador = 0;

            int linhas = 0;
            int colunas = 0;

            int _col = 0;
            int _li = 0;

            int primeira_coluna = 0;
            int primeira_linha = 0;

            string[,] matriz = new string[7, 7] {

                /*0,   1,   2,   3,   4,   5,   6*/

                { "1", "5", "1", "2", "4", "6", "1" }, //0

                { "1", "6", "2", "2", "2", "2", "2" }, //1

                { "1", "1", "1", "2", "4", "1", "5" }, //2

                { "1", "2", "2", "5", "2", "1", "4" }, //3

                { "1", "4", "4", "4", "1", "5", "3" }, //4

                { "1", "4", "1", "4", "1", "6", "2" }, //5

                { "1", "4", "5", "5", "5", "6", "2" } //6

            };

            //CompararValoresHorizontal(matriz[linhas, colunas], matriz[linhas, colunas + 1]);

            CompararValoresVertical(matriz[_li, _col], matriz[_li + 1, _col]);

            for (linhas = 0; linhas <= 6; linhas++)
            {
                for (colunas = 0; colunas < 6; colunas++)
                {
                    Console.Write("{0}, ", matriz[linhas, colunas]);
                }
                Console.WriteLine("\n");
            }

            void CompararValoresHorizontal(string m1, string m2)
            {
                //caso dois valores sejam iguais, ele deve chamar o m�todo SubstituirValoresHorizontal
                //nos par�metros s�o passados a posi��o do primeiro valor
                if (m1 == m2)
                {
                    primeira_coluna = colunas;
                    SubstituirValoresHorizontal(linhas, colunas);
                }

                //Se colunas igual a 5 ou 6, ent�o foi percorrido todas as colunas da matriz.
                if (colunas == 5 || colunas == 6)
                {
                    colunas = 0;
                    linhas++;
                }
                else
                {
                    colunas++;
                }

                //Se linhas igual a 7, ent�o foi percorrido todas a linhas da matriz.
                if (linhas < 7)
                    CompararValoresHorizontal(matriz[linhas, colunas], matriz[linhas, colunas + 1]);
            }

            void CompararValoresVertical(string m1, string m2)
            {
                if (m1 == m2)
                {
                    primeira_linha = linhas;
                    SubstituirValoresVertical(linhas, colunas);
                }

                //Se linhas igual a 5 ou 6, ent�o foi percorrido todas as linhas da matriz.
                if (linhas == 5 || linhas == 6)
                {
                    linhas = 0;
                    colunas++;
                }
                else
                    linhas++;


                //Se colunas igual a 7, ent�o foi percorrido todas as colunas da matriz.
                if (colunas < 7)
                    CompararValoresVertical(matriz[linhas, colunas], matriz[linhas + 1, colunas]);
            }

            void SubstituirValoresHorizontal(int linha, int coluna)
            {
                int aux_linha = linha;
                int aux_coluna = coluna;
                int aux_contador = 0;


                if (coluna < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha, aux_coluna + 1]))
                {
                    contador++;
                    SubstituirValoresHorizontal(aux_linha, aux_coluna + 1);
                }
                else
                {
                    aux_contador = contador;
                    contador = 0;
                    colunas = aux_coluna;
                }

                if (aux_contador == 4)
                {
                    TrocaPorCaractereHorizontal(aux_linha, aux_coluna, "*", primeira_coluna);
                }

                if (aux_contador == 3)
                {
                    TrocaPorCaractereHorizontal(aux_linha, aux_coluna, "!", primeira_coluna);
                }

                if (aux_contador == 2)
                {
                    TrocaPorCaractereHorizontal(aux_linha, aux_coluna, ">", primeira_coluna);
                }
            };

            void SubstituirValoresVertical(int linha, int coluna)
            {
                int aux_linha = linha;
                int aux_coluna = coluna;
                int aux_contador = 0;

                if (linha < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha + 1, aux_coluna]) && contador < 4)
                {
                    contador++;
                    SubstituirValoresVertical(aux_linha + 1, aux_coluna);
                }
                else
                {
                    aux_contador = contador;
                    contador = 0;
                    linhas = aux_linha;
                }

                if (aux_contador == 4)
                {
                    TrocaPorCaractereVertical(aux_linha, aux_coluna, "*", primeira_linha);
                }

                if (aux_contador == 3)
                {
                    TrocaPorCaractereVertical(aux_linha, aux_coluna, "!", primeira_linha);
                }

                if (aux_contador == 2)
                {
                    TrocaPorCaractereVertical(aux_linha, aux_coluna, ">", primeira_linha);
                }
            };

            void TrocaPorCaractereHorizontal(int aux_l, int aux_col, string caractere, int primeira_posicao)
            {
                while (aux_col >= primeira_posicao)
                {
                    matriz[aux_l, aux_col] = caractere;
                    aux_col--;
                }
            }

            void TrocaPorCaractereVertical(int aux_l, int aux_col, string caractere, int primeira_posicao)
            {
                while (aux_l >= primeira_posicao)
                {
                    matriz[aux_l, aux_col] = caractere;
                    aux_l--;
                }
            }
        }
    }
}
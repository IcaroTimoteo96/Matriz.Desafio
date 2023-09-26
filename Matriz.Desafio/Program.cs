var contador = 0;

int linhas = 0;
int colunas = 0;

int primeira_coluna = 0;
int primeira_linha = 0;

string[,] matriz = new string[7, 7] {

                /*0,   1,   2,   3,   4,   5,   6*/

                { "1", "5", "3", "2", "1", "3", "1" }, //0

                { "2", "2", "3", "5", "6", "1", "4" }, //1

                { "3", "4", "1", "1", "1", "1", "1" }, //2

                { "6", "5", "4", "3", "1", "4", "2" }, //3

                { "5", "5", "1", "5", "7", "4", "1" }, //4

                { "4", "5", "5", "6", "4", "4", "2" }, //5

                { "2", "1", "3", "3", "3", "4", "5" } //6

            };

CompararValoresHorizontal(matriz[linhas, colunas], matriz[linhas, colunas + 1]);

linhas = 0; colunas = 0;

CompararValoresVertical(matriz[linhas, colunas], matriz[linhas + 1, colunas]);

void CompararValoresHorizontal(string m1, string m2)
{
    //caso dois valores sejam iguais, ele deve chamar o método SubstituirValoresHorizontal
    //nos parâmetros são passados a posição do primeiro valor
    if (m1 == m2)
    {
        primeira_coluna = colunas;
        SubstituirValoresNaHorizontal(linhas, colunas);
    }

    //Se colunas igual a 5 ou 6, então foi percorrido todas as colunas da matriz.
    if (colunas == 5 || colunas == 6)
    {
        colunas = 0;
        linhas++;
    }
    else
        colunas++;


    //Se linhas igual a 7, então foi percorrido todas a linhas da matriz.
    if (linhas < 7)
        CompararValoresHorizontal(matriz[linhas, colunas], matriz[linhas, colunas + 1]);
}

void CompararValoresVertical(string m1, string m2)
{
    if (m1 == m2)
    {
        primeira_linha = linhas;
        SubstituirValoresNaVertical(linhas, colunas);
    }

    //Se linhas igual a 5 ou 6, então foi percorrido todas as linhas da matriz.
    if (linhas == 5 || linhas == 6)
    {
        linhas = 0;
        colunas++;
    }
    else
        linhas++;


    //Se colunas igual a 7, então foi percorrido todas as colunas da matriz.
    if (colunas < 7)
        CompararValoresVertical(matriz[linhas, colunas], matriz[linhas + 1, colunas]);
}

void SubstituirValoresNaHorizontal(int linha, int coluna)
{
    int aux_linha = linha;
    int aux_coluna = coluna;
    int aux_contador = 0;


    if (coluna < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha, aux_coluna + 1]) && contador < 4)
    {
        contador++;
        SubstituirValoresNaHorizontal(aux_linha, aux_coluna + 1);
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

void SubstituirValoresNaVertical(int linha, int coluna)
{
    int aux_linha = linha;
    int aux_coluna = coluna;
    int aux_contador = 0;

    if (linha < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha + 1, aux_coluna]) && contador < 4)
    {
        contador++;
        SubstituirValoresNaVertical(aux_linha + 1, aux_coluna);
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


for (int li = 0; li <= 6; li++)
{
    for (int col = 0; col <= 6; col++)
    {
        Console.Write("{0} ", matriz[li, col]);
    }
    Console.WriteLine("\n");
}

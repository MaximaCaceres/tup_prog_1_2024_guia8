using System;

namespace Guia8Consola
{
    class Program
    {
        private static bool ordenado = false;
        const int indice = 100;
        private static int[] vector = new int[indice];
        private static int cont = 0;
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();
                opcion = Convert.ToInt16(Console.ReadLine());
                VerificarOpcion(opcion);

            } while (opcion != 4);
            Console.ReadKey();
        }
        #region//vista
        static public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1.Cargar vector \n2.Ordenar vector \n3.Buscar elemento \n4.Salir");
        }
        #endregion
       
        static public void VerificarOpcion(int opcion)
        {    
            switch (opcion)
            {
                case 1:
                    CargarVector();
                    break;
                case 2:
                    OrdenarVector();
                    break;
                case 3:
                    BuscarElemento();
                    break;
            }

        }
        #region//dominio
        static void CargarVector()
        {

            int elemento;
            do
            {
                SolicitarElemento();
                elemento = Convert.ToInt16(Console.ReadLine());
                if(elemento != -1)
                {
                    vector[cont] = elemento;
                    cont++;
                }
                
            } while (elemento != -1);

        }
        static public void SolicitarElemento()
        {
            Console.Clear();
            Console.WriteLine("Ingrese numero a cargar (-1 para salir)");

        }
        static public void OrdenarVector()
        {
            Burbuja();
            MostrarOrdenado();
        }
        static public void Burbuja()
        {
            int i = 0, j = 0, aux = 0;
            ordenado = true;
            for (i = 0; i <= cont - 1; i++)
            {
                for (j = i + 1; j <= cont; j++)
                {
                    if (vector[i] > vector[j])
                    {
                        aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
                }
            }
        }
        static public void MostrarOrdenado()
        {
            int muestra;
            Console.Clear();
            Console.WriteLine("=====Vector ordenado=====");
            for(int i = 1; i <= cont; i++)
            {
                muestra = vector[i];
                Console.WriteLine("{0}\n", muestra);
            }
            Console.ReadKey();
        }
        static public void BuscarElemento()
        {
            int buscado = 0, encontrado = 0;
            Console.WriteLine("Ingrese elemento a buscar");
            buscado = Convert.ToInt16(Console.ReadLine());
            if(ordenado == true)
            {
                encontrado = BusquedaBinaria(buscado);
                Console.WriteLine("el valor es {0}",encontrado);
                Console.ReadKey();
            }
            else
            {
             encontrado = BusquedaSecuencial(buscado);
                Console.WriteLine("el valor es {0}", encontrado);
                Console.ReadKey();
            }
            
        }
        static public int BusquedaBinaria(int buscado)
        {
            int izq, der, mid, ret = -1;
            bool encontrado = false;
            izq = 0;
            der = cont;
            do
            {
                mid = izq + der / 2;
                if (vector[mid] == buscado)
                {
                    encontrado = true;
                }
                else
                {
                    if (vector[mid] < buscado)
                    {
                        izq = mid + 1;
                    }
                    else
                    {
                        der = mid - 1;
                    }
                }
            } while (encontrado == false && izq <= der);

            if(encontrado == true)
            {
                ret = vector[mid];
            }
            return ret;
        }
        static public int BusquedaSecuencial(int buscado)
        {
            int i = 0, post = -1;
            while(post == -1 && i <= cont)
            {
                if(vector[i] == buscado)
                {
                    post = vector[i];
                }
                i++;
            }
            return post;
        }
    }
    #endregion
}

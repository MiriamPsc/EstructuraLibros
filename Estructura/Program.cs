using System;

namespace Estructura
{
    class Program
    {

        static void Main(string[] args)
        {
            int OpcionMenu;
            Lista L = new Lista();
            int nIsbn;
            string nTitulo;
            do
            {
                Console.WriteLine("\n              REGISTROS              ");
                Console.WriteLine("\n 1. Insertar      | 6. Cargar        ");
                Console.WriteLine("\n 2. Buscar        | 7. Contar        ");
                Console.WriteLine("\n 3. Eliminar      | 8. Eliminar todo ");
                Console.WriteLine("\n 4. Mostrar       | 9. Salir         ");
                Console.WriteLine("\n 5. Guardar       |                  ");
                Console.WriteLine("\n           Escoja una Opción:        ");
                OpcionMenu = Convert.ToInt32(Console.ReadLine());
                switch (OpcionMenu)
                {
                    case 1:
                        Console.WriteLine("\n\n INSERTA REGISTRO EN LA LISTA \n\n");
                        Console.WriteLine("Libro a agregar:");
                        Console.WriteLine("ISBN:");
                        nIsbn = Convert.ToInt32(Console.ReadLine());
                        if (L.BuscarAgregar(nIsbn)==false)
                        {
                            Console.WriteLine("Titulo:    ");
                            nTitulo = Console.ReadLine();
                            L.Agregar(nIsbn, nTitulo);
                        }
                        else
                        {
                            Console.WriteLine("EL LIBRO YA ESTÁ EN LA LISTA");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n\n BUSCAR UN REGISTRO EN LA LISTA \n\n");
                        L.Buscar();
                        break;
                    case 3:
                        Console.WriteLine("\n\n ELIMINAR UN REGISTRO DE LA LISTA \n\n");
                        L.Eliminar();
                        break;
                    case 4:
                        Console.WriteLine("\n\n MOSTRAR REGISTROS \n\n");
                        L.Mostrar();
                        break;
                    case 5:
                        Console.WriteLine("\n\n  GUARDAR REGISTROS \n\n");
                        L.GuardarArchivo();
                        break;
                    case 6:
                        Console.WriteLine("\n\n CARGAR REGISTROS \n\n");
                        L.CargarArchivo();
                        break;
                    case 7:
                        Console.WriteLine("\n\n  CONTAR REGISTROS \n\n");
                        L.Contar();
                        break;
                    case 8:
                        Console.WriteLine("\n\n  ELIMINAR TODO \n\n");
                        L.EliminarTodo();
                        break;
                    case 9:
                        Environment.Exit(-1);
                        break;
                }
            } while (OpcionMenu!=9);
        }
    }
}
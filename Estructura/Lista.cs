using System;
using System.IO;

namespace Estructura
{
    class Lista
    {
        public int index = 0;

        public struct Libros
        {
            public int? ISBN;
            public string titulo;
        }
        public Libros[] libro = new Libros[200];

        public void Agregar(int nIsbn, string nTitulo)
        {
            libro[index].ISBN = nIsbn;
            libro[index].titulo = nTitulo;
            index++;
        }
        public bool BuscarAgregar(int b)
        {
            for (int i = 0; i < index; i++)
            {
                if (libro[i].ISBN == b)
                {
                    return true;
                }
            }
            return false;
        }
        public void Mostrar()
        {
            Console.WriteLine("Libros agregados:    \n");
            for (int i = 0; i < index; i++)
            {
                if (libro[i].ISBN!=null && libro[i].titulo != null)
                {
                    Console.WriteLine("ISBN:  " + libro[i].ISBN + "\n");
                    Console.WriteLine("Título:  " + libro[i].titulo + "\n");
                }
            }
        }
        public void Eliminar()
        {
            int busquedaMenu;
            int? eliminarISBN;
            string eliminarTitulo;
            Console.WriteLine("Por ISBN = 1         Por Título = 2");
            busquedaMenu = Convert.ToInt32(Console.ReadLine());

            switch (busquedaMenu)
            {
                case 1:
                    Console.WriteLine("Ingresa ISBN:    ");
                    eliminarISBN = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < index; i++)
                    {
                        if (libro[i].ISBN == eliminarISBN)
                        {
                            libro[i].titulo = null;
                            libro[i].ISBN = null;
                        }
                    }
                    Console.WriteLine("El ISBN no se encuentra registrado");
                    break;
                case 2:
                    Console.WriteLine("Ingresa titulo:    ");
                    eliminarTitulo = Console.ReadLine();
                    for (int i = 0; i < index; i++)
                    {
                        if (libro[i].titulo == eliminarTitulo)
                        {
                            libro[i].titulo = null;
                            libro[i].ISBN = null;
                        }
                    }
                    Console.WriteLine("El título no se encuentra registrado");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        }
        public void Contar()
        {
            int contador = 0;
            for (int i = 0; i < index; i++)
            {
                if (libro[i].ISBN != null && libro[i].titulo != null)
                {
                    contador++;
                }
            }

            Console.WriteLine("El total de libros que hay guardados es igual a:   " + contador);
        }
        public void Buscar()
        {
            int busquedaMenu = 0;
            int? busquedaISBN;
            string busquedaTitulo;
            Console.WriteLine("Por ISBN = 1         Por Título = 2");
            busquedaMenu = Convert.ToInt32(Console.ReadLine());

            switch (busquedaMenu)
            {
                case 1:
                    Console.WriteLine("Ingresa ISBN:    ");
                    busquedaISBN =  Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < index; i++)
                    {
                        if (libro[i].ISBN == busquedaISBN)
                        {
                            Console.WriteLine("El dato  " + busquedaISBN + "  existe");
                            Console.WriteLine("El título es  " + libro[i].titulo);
                            return;
                        }
                    }
                    Console.WriteLine("El ISBN no se encuentra registrado");
                    break;
                case 2:
                    Console.WriteLine("Ingresa titulo:    ");
                    busquedaTitulo = Console.ReadLine();
                    for (int i = 0; i < index; i++)
                    {
                        if (libro[i].titulo == busquedaTitulo)
                        {
                            Console.WriteLine("El dato  " + busquedaTitulo + "  existe");
                            Console.WriteLine("El ISBN es  " + libro[i].ISBN);
                            return;
                        }
                    }
                    Console.WriteLine("El título no se encuentra registrado");
                    break;
                default:
                    Console.WriteLine("Opción invalida.");
                    break;
            }
        }
        public void EliminarTodo()
        {
            Array.Clear(libro, 0, index);
        }
        public void GuardarArchivo()
        {
            string ruta = @"C:\Users\miria\Desktop\Lista.txt";
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                for (int i = 0; i < index; i++)
                {
                    writer.WriteLine("ISBN: " + libro[i].ISBN.ToString());
                    writer.WriteLine("Título: " + libro[i].titulo.ToString());
                }
            }

        }
        public void CargarArchivo()
        {
            int nIsbn;
            string nTitulo;
            string ruta = @"C:\Users\miria\Desktop\Lista.txt";
            EliminarTodo();
            string[] lineas = File.ReadAllLines(ruta);
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i].StartsWith("ISBN: "))
                {
                   lineas[i] = lineas[i].Replace("ISBN: ", "");

                    nIsbn = Convert.ToInt32(lineas[i]);

                    if (lineas[i+1].StartsWith("Título: "))
                    {
                        nTitulo = lineas[i + 1];
                        Agregar(nIsbn, nTitulo);
                    }
                
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DATALIST.Models;


namespace DATALIST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrabajandoConEF();
            Ejercicios31032022();
            
        }
        static void TrabajandoConEF()
        {
            var context = new ModelNorthwind();
            var Clientes = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r=> r.City)
                .ToList();
            foreach (var cliente in Clientes)
            {
                Console.WriteLine($"ID:{cliente.CustomerID}");
                Console.WriteLine($"Empresa:{cliente.CompanyName}");
                Console.WriteLine($"Region:{cliente.City}-{cliente.Country}"+ Environment.NewLine);
            }
        }
        static void Ejercicios31032022()
        {
            var context = new ModelNorthwind();


            //Los empleados con ID 3, 5 y 8

            var empleados = context.Employees
                .Where(r => r.EmployeeID == 3 || r.EmployeeID == 5 || r.EmployeeID == 8)
                .ToList();
            
            //Productos con stock mayor de cero

                var productos = context.Products
                .Where(r => r.UnitsInStock > 0)
                .ToList();
            

            //Clientes de USA

            var clientesUSA = context.Customers
                .Where(r => r.Country == "%USA%")
                .ToList();
            foreach (var clie in clientesUSA)
            {
                Console.WriteLine($"Los clientes de USA son:{clie.ContactName}");
            }

            //Productos precio mayor de 20 y menor 90

            var productoPr = context.Products
               .Where(r => r.UnitPrice > 20 && r.UnitPrice <90)
               .ToList();


            //Proveedores (Suppliers) de BERLIN


            var proveedoresBERLIN = context.Suppliers
              .Where(r => r.Country == "Berlin")
              .ToList();


            //Pedidos entre 01.01.97 y 15.07.97

            var pedidosRango = context.Orders
              .Where(r => r.OrderDate >= new DateTime(1997 ,1 ,1) && r.OrderDate >= new DateTime(1997, 7, 15))
              .ToList();


            // Productos con stock mayor de cero de los proveedores con id 1, 3 y 5

            int?[] supplID = new int?[] { 1, 3, 5 };

            var xx = context.Products
                .Where(r => supplID.Contains(r.SupplierID) && r.UnitsInStock > 0)
                .ToList();


            //Clientes que no tiene fax


            var xxx = context.Customers
                .Where(r => r.Fax == null)
                .ToList();


            //Empresas de la letra B de UK


            var xxxx = context.Customers
                .Where(r => r.CompanyName.StartsWith("B") && r.Country == "Uk")
                .ToList();

            //Productos de la categoria 3 y 5

            var P1 = context.Products
                .Where(r => new int?[] {3,5}.Contains(r.CategoryID))
                .ToList();



            //Los 10 productos más baratos


            var P2 = context.Products
                .OrderBy(r => r.UnitPrice)
                .Take(10)
                .ToList();

            //Los 10 productos más caros con stock

            var P3 = context.Products
               .Where(r => r.UnitPrice > 0)
               .OrderByDescending(r => r.UnitPrice)
               .Take(10)
               .ToList();

            //Valor total del stock

            var P4 = context.Products
                .ToList()
               .Sum(r => r.UnitPrice * r.UnitsInStock);
             

        }





        //Pedidos del 97 registrado por los empleados con id 1,3,4 y 8

        //Pedidos de abril de 96

        //Pedidos del realizado los dia uno de cada mes del año 98




        /// <summary>
        /// Representa el Objeto Cliente
        /// </summary>
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaNac { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Producto
        /// </summary>
        public class Producto
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public float Precio { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Pedido
        /// </summary>
        public class Pedido
        {
            public int Id { get; set; }
            public int IdCliente { get; set; }
            public DateTime FechaPedido { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Linea de Pedido
        /// </summary>
        public class LineaPedido
        {
            public int Id { get; set; }
            public int IdPedido { get; set; }
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
        }

        /// <summary>
        /// Representa una Base de datos en memoria utilizando LIST
        /// </summary>
        public static class DataLists
        {
            private static List<Cliente> _listaClientes = new List<Cliente>() {
            new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
            new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
            new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
            new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
            new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
        };

            private static List<Producto> _listaProductos = new List<Producto>()
        {
            new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
            new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
            new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
            new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
            new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
            new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
            new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
            new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
            new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
            new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
            new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
            new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
        };

            private static List<Pedido> _listaPedidos = new List<Pedido>()
        {
            new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
            new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
            new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
            new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
            new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
            new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
            new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
            new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
            new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
            new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
        };

            private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
        {
            new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
            new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
            new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
            new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
            new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
            new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
            new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
            new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
            new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
            new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
            new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
            new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
            new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
            new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
            new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
            new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
            new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
        };

            // Propiedades de los elementos privados
            public static List<Cliente> ListaClientes { get { return _listaClientes; } }
            public static List<Producto> ListaProductos { get { return _listaProductos; } }
            public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
            public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }
        }
    }
}

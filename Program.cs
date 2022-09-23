using NLog;

namespace Taller2TP3{
    class Program{
        static void Main(string[] args){
            var Logger = LogManager.GetCurrentClassLogger();

            Cadeteria cadeteria = new Cadeteria();
            int opcion = 1;
            int num, id, tel;
            string detalles, nombre, direc, datos;

            List<Cadete> cadetes = new List<Cadete>();

            foreach(var str in File.ReadAllLines("Cadetes.csv")){
                if(str != ""){
                    var aux = str.Split(";");
                    cadeteria.IngresarCadete(new Cadete(Int32.Parse(aux[0]), aux[1], aux[2], Int32.Parse(aux[3])));
                }
            }

            cadeteria.MostrarCadetes();


            while(opcion != 0){
                Console.WriteLine("1) Alta de pedidos");
                Console.WriteLine("2) Asignar pedido a cadete");
                Console.WriteLine("3) Cambiar estado de pedido");
                Console.WriteLine("4) Cambiar cadete del pedido");
                Console.WriteLine("0) Salir");

                Console.Write("Opción: ");
                opcion = Int32.Parse(Console.ReadLine());

                if(opcion == 1){
                    Console.WriteLine("Número de pedido: ");
                    num = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Detalles del pedido: ");
                    detalles = Console.ReadLine();
                    Console.WriteLine("ID del cliente: ");
                    id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Nombre del cliente: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Dirección del cliente: ");
                    direc = Console.ReadLine();
                    Console.WriteLine("Teléfono del cliente: ");
                    tel = Int32.Parse(Console.ReadLine());

                    cadeteria.GenerarPedido(num, detalles, id, nombre, direc, tel);
                    Console.WriteLine($"Pedido generado con número {num}");
                }
                else if(opcion == 2){
                    Console.WriteLine("Ingrese el número del pedido: ");
                    num = Int32.Parse(Console.ReadLine());
                    if(cadeteria.AsignarPedidoPorNum(num)) Console.WriteLine("Pedido asignado con éxito");
                    else Console.WriteLine("No se pudo asignar el pedido");
                }
                else if(opcion == 3){
                    Console.WriteLine("Ingrese el número del pedido: ");
                    num = Int32.Parse(Console.ReadLine());

                    if(cadeteria.EntregarPedido(num)) Console.WriteLine("Pedido entregado con éxito");
                    else Console.WriteLine("No se pudo entregar el pedido");
                }
                else if(opcion == 4){
                    Console.WriteLine("Ingrese el número del pedido: ");
                    num = Int32.Parse(Console.ReadLine());

                    if(cadeteria.ReAsignarPedido(num)) Console.WriteLine("Pedido reasignado con éxito");
                    else Console.WriteLine("No se pudo reasignar el pedido");
                }

                Console.WriteLine();
            }
        }
    }
}
namespace Taller2TP3{
    class Cadeteria{
        private string Nombre;
        private int Telefono;
        private List<Cadete> ListadoCadetes;
        private List<Pedido> PedidosPendientes;

        public Cadeteria(){
            ListadoCadetes = new List<Cadete>();
            PedidosPendientes = new List<Pedido>();
        }

        public void IngresarCadete(Cadete cadete){
            ListadoCadetes.Add(cadete);
        }

        public void MostrarCadetes(){
            foreach(var cadete in ListadoCadetes){
                Console.WriteLine(cadete);
            }
        }

        public List<Pedido> ObtenerPedidos(){
            return PedidosPendientes;
        }

        public bool EntregarPedido(int num){
            foreach(var cadete in ListadoCadetes){
                if(cadete.TienePedidoEnCurso() && cadete.PedidoEnCurso().Nro == num && cadete.EntregarPedido()) return true;
            }

            return false;
        }

        public Cadeteria(string nom, int tel){
            Nombre = nom;
            Telefono = tel;
        }

        public void IngresarCadete(int id, string nom, string direc, int tel){
            ListadoCadetes.Add(new Cadete(id, nom, direc, tel));
        }

        public void GenerarPedido(int nro, string det, int id, string nom, string direc, int tel){
            PedidosPendientes.Add(new Pedido(nro, det, id, nom, direc, tel));

            if(ListadoCadetes.Count > 0 && AsignarPedido(PedidosPendientes[PedidosPendientes.Count - 1])){
                PedidosPendientes.RemoveAt(PedidosPendientes.Count - 1);
            }
        }

        public bool ReAsignarPedido(int num){
            Pedido pedido;

            foreach(var cadete in ListadoCadetes){
                if(cadete.PedidoEnCurso() != null && cadete.PedidoEnCurso().Nro == num){
                    pedido = cadete.PedidoEnCurso();
                    if(AsignarPedido(pedido)){
                        cadete.EliminarPedido();
                        return true;
                    }
                }
            }

            return false;
        }

        public bool AsignarPedidoPorNum(int nro){
            bool asignado = false;

            foreach(var pedido in PedidosPendientes){
                if(pedido.Nro == nro){
                    asignado = AsignarPedido(pedido);
                    if(asignado) break;
                }
            }

            return asignado;
        }

        public bool AsignarPedido(Pedido pedido){
            Random rnd = new();
            bool asignado = false;

            foreach(var cadete in ListadoCadetes){
                if(!cadete.TienePedidoEnCurso()){
                    cadete.IngresarPedido(pedido);
                    asignado = true;
                    break;
                }
            }

            return asignado;
        }
    }
}
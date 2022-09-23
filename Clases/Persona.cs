namespace Taller2TP3{
    abstract class Persona{
        protected int id;
        protected string nombre;
        protected string direccion;
        protected int telefono;

        public override string ToString()
        {
            return $"ID: {id}\nNombre: {nombre}\nDireccion: {direccion}\nTelefono: {telefono}";
        }
    }

    class Cliente: Persona{
        private string DatosReferenciaDireccion;

        public Cliente(){

        }

        public Cliente(int id, string nom, string direc, int tel){
            this.id = id;
            nombre = nom;
            direccion = direc;
            telefono = tel;
        }
    }

    class Cadete: Persona{
        private List<Pedido> ListadoPedidos;

        public Cadete(int id, string nom, string direc, int tel){
            this.id = id;
            nombre = nom;
            direccion = direc;
            telefono = tel;
            ListadoPedidos = new List<Pedido>();
        }

        public void IngresarPedido(Pedido pedido){
            ListadoPedidos.Add(pedido);
        }

        public bool TienePedidoEnCurso(){
            if(ListadoPedidos.Count == 0) return false;
            else return ListadoPedidos[ListadoPedidos.Count - 1].EstaEnCurso();
        }

        public Pedido? PedidoEnCurso(){
            if(ListadoPedidos.Count == 0) return null;
            else if(TienePedidoEnCurso()) return ListadoPedidos[ListadoPedidos.Count - 1];
            return null;
        }

        public bool EntregarPedido(){
            if(ListadoPedidos.Count == 0) return false;
            else if(TienePedidoEnCurso()){
                ListadoPedidos[ListadoPedidos.Count - 1].EntregarPedido();
                return true;
            }
            return false;
        }

        public bool EliminarPedido(){
            if(ListadoPedidos.Count == 0) return false;
            else if(TienePedidoEnCurso()){
                ListadoPedidos.RemoveAt(ListadoPedidos.Count - 1);
                return true;
            }

            return false;
        }

        public float JornalACobrar(){
            float sumatoria = 0;

            foreach(var pedido in ListadoPedidos){
                if(pedido.EstaEnCurso()) sumatoria += sumatoria += 300;
            }

            return sumatoria;
        }
    }
}
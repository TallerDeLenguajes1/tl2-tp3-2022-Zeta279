namespace Taller2TP3{
    class Pedido{
        public int Nro {get; set;}
        private string Detalles {get; set;}
        private Cliente cliente {get; set;}
        private bool EnCurso {get; set;}

        public Pedido(){

        }

        public Pedido(int nro, string det, int id, string nom, string direc, int tel){
            Nro = nro;
            Detalles = det;
            cliente = new Cliente(id, nom, direc, tel);
        }

        public void IniciarPedido(){
            EnCurso = true;
        }

        public void EntregarPedido(){
            EnCurso = false;
        }

        public bool EstaEnCurso(){
            return EnCurso;
        }
    }
}
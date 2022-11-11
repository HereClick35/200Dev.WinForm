using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.WindowsForm.Entity
{
    public class CompraGado
    {
        public int Id { get; set; }
        public int PecuaristaId { get; set; }
        public string dataEntrega { get; set; }
        public decimal valorCompra { get; set; }
        public Pecuarista Pecuarista { get; set; }
        public List<CompraGadoItem> items { get; set; }
    }

    public class CompraGadoItem
    {
        public int compraGadoId { get; set; }
        public int animalId { get; set; }
        public string animal { get; set; }
        public int quantidade { get; set; }
        public decimal preco { get; set; }
        public decimal total { get; set; }
    }

    public class CompraGadoGrid
    {
        public int Id { get; set; }
        public int PecuaristaId { get; set; }
        public string Pecuarista { get; set; }
        public string dataEntrega { get; set; }
        public decimal ValorCompra { get; set; }
        
    }
}

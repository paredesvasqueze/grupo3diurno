namespace FrontEnd.Models
{
    public class Compra
    {
        public int nidcompra { get; set; }
        public int nidproveedor { get; set; }
        public string? cnombreproveedor { get; set; }
        public DateTime dfechacompra { get; set; }
        public double ntotal { get; set; }
    }
}

namespace CapaEntidad
{
    public class venta
    {
        public int nidVenta { get; set; }
        public int nidcliente { get; set; }
        public int nidempleado { get; set; }
        public DateTime dfechaventa { get; set; }
        public decimal ntotal { get; set; }
    }
}
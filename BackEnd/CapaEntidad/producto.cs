namespace CapaEntidad
{
    public class producto
    {
        public int nidproducto { get; set; }
        public string cnombre { get; set; }
        public string cdescripcion { get; set; }
        public decimal npreciounitario { get; set; }
        public int nstock { get; set; }
        public int nidcategoria { get; set; }
        public DateTime dfecharegistro { get; set; }
    }
}

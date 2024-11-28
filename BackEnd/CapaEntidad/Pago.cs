namespace CapaEntidad
{
    public class Pago
    {
        public int nidpago { get; set; }
        public string? cventa { get; set; }
        public string? nidventa { get; set; }     
        public DateTime dfechapago { get; set; }  
        public decimal nmonto { get; set; }      
        public string? nidmetodopago { get; set; }
        public string? cmetodopago { get; set; }
    }
}

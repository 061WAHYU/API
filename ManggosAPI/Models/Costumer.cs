namespace ManggosAPI.Models
{
    public class Costumer
    {
        public Guid Id { get; set; }
        public string Barang { get; set; }    
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public int TotalHarga { get; set; }
    }
}

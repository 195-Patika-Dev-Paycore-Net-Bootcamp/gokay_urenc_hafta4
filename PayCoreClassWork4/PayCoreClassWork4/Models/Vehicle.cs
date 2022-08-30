namespace PayCoreClassWork4.Models
{
    // Veritabanında "vehicles" tablosuna karşılık gelecek araç sınıfı.
    public class Vehicle
    {
        public virtual long Id { get; set; } // Id alanı (Tam sayı)
        public virtual string VehicleName { get; set; } // Araç adı alanı (Metinsel)
        public virtual string VehiclePlate { get; set; } // Araç plakası alanı (Metinsel)
    }
}
namespace PayCoreClassWork4.Models
{
    // Veritabanında "containers" tablosuna karşılık gelecek konteyner sınıfı.
    public class Container
    {
        public virtual long Id { get; set; } // Id alanı (Tam sayı)
        public virtual string ContainerName { get; set; } // Konteyner alanı (Metinsel)
        public virtual double Latitude { get; set; } // Enlem alanı (Ondalıklı)
        public virtual double Longitude { get; set; } // Boylam alanı (Ondalıklı)
        public virtual long VehicleId { get; set; } // Araç numarası alanı (Tam sayı)
    }
}
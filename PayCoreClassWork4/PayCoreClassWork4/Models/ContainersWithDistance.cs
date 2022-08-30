namespace PayCoreClassWork4.Models
{
    // 2 konteyner ve aralarındaki uzaklık bilgisinin ölçümünde kullanılmak için oluşturulmuş yardımcı model sınıfı.
    public class ContainersWithDistance
    {
        // Kurucu metod yardımıyla nesne; konteyner listesi ve uzaklık bilgisiyle birlikte oluşturulur.
        public ContainersWithDistance(List<Container> containers, double distance)
        {
            Containers = containers;
            Distance = distance;
        }

        public List<Container> Containers { get; set; } // Uzaklıkları hesaplamaya alınacak konteyner listesi.
        public double Distance { get; set; } // Uzaklık bilgisi.
    }
}
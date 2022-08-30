using PayCoreClassWork4.Models;

namespace PayCoreClassWork4.Utilities
{
    public static class Calculation
    {
        // 2 farklı koordinat (enlem, boylam) arasındaki uzaklığın hesaplanma yöntemi.
        // Matematiksel formüller kullanılarak elde edilmiştir.
        // Konteynerlerin arasındaki mesafeyi hesaplamak amacıyla kullanılmıştır.
        public static ContainersWithDistance GetDistance(Container container1, Container container2)
        {
            var lat1 = container1.Latitude * Math.PI / 180; // Enlem ve boylam değerleri radyan değerlere dönüştürülür.
            var lon1 = container1.Longitude * Math.PI / 180;
            var lat2 = container2.Latitude * Math.PI / 180;
            var lon2 = container2.Longitude * Math.PI / 180;

            var dlat = lat2 - lat1; // Enlemler farkı alınır.
            var dlon = lon2 - lon1; // Boylamlar farkı alınır.

            var distance = 2 * Math.Asin // 2 koordinat arasındaki uzaklık bu formüle göre hesaplanır.
                               (
                                  Math.Sqrt
                                  (
                                     Math.Pow(Math.Sin(dlat / 2), 2) +
                                     Math.Cos(lat1) *
                                     Math.Cos(lat2) *
                                     Math.Pow(Math.Sin(dlon / 2), 2)
                                  )
                               ) * 6371; // Uzaklık değerinin kilometre cinsinden olması için 6371 ile çarpılır.

            var containers = new List<Container>() { container1, container2 };
            var containersWithDistance = new ContainersWithDistance(containers, distance);

            return containersWithDistance; // Hesaplamaya alınan konteynerlar aralarındaki uzaklık değeri ile birlikte döndürülür.
        }

        // Kümeleme işlemi yapılır.
        // Hesaplamaya alınan konteynerlar ve uzaklıkların listesi ele alınır.
        // Bu uzaklık mesafeleri küçükten büyüğe olacak şekilde sıralanır ve belirtilen küme sayısına uygun şekilde kümelenir.
        public static List<List<ContainersWithDistance>> Cluster(List<ContainersWithDistance> list, int clusterCount)
        {
            var index = 0;
            var clusteredList = list.OrderBy(c => c.Distance) // Uzaklık mesafelerine göre küçükten büyüğe sıralama yapılır.
                                    .GroupBy(s => index++ / clusterCount) // Belirtilen küme sayısı değerine göre kümeleme yapılır.
                                    .Select(g => g.ToList()) // Her küme bir listeye dönüştürülür.
                                    .ToList(); // Kümelerin bir listesi oluşturulur.

            return clusteredList; // Elde edilen kümeler listesi döndürülür.
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using PayCoreClassWork4.Models;
using PayCoreClassWork4.Utilities;
using ISession = NHibernate.ISession;

namespace PayCoreClassWork4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusteringController : ControllerBase
    {
        private readonly ISession _session; // NHibernate kütüphanesine ait ISession nesnesi veritabanıyla iletişim kurmak amacıyla kullanılmıştır.

        public ClusteringController(ISession session) => _session = session; // Kurucu metod aracılığıyla ISession nesnesinin bağımlılığı eklenir.

        // Tek bir action metod olduğu için bir önceki projede kullandığım katmanlı yapıyı tekrar inşaat etmeye gerek duymadım. Sadece ISession nesnesi üzerinden çalıştım.
        [HttpGet("{vehicleId}/{clusterCount}")]
        public async Task<ActionResult<List<List<ContainersWithDistance>>>> Get(long? vehicleId, int? clusterCount)
        {
            if (vehicleId == null) return BadRequest("Vehicle id can't be null."); // Araç numarası boş bırakılarak istek gönderilirse "Geçersiz İstek" hatası döndürülür.
            if (clusterCount == null) return BadRequest("Cluster count can't be null."); // Küme sayısı boş bırakılarak istek gönderilirse "Geçersiz İstek" hatası döndürülür.
            if (clusterCount <= 1) return BadRequest("Cluster count must be at least 2."); // Küme sayısı en az 2 değilse "Geçersiz İstek" hatası döndürülür.

            var vehicle = await _session.Query<Vehicle>().FirstOrDefaultAsync(c => c.Id == vehicleId); // İstek yapılan araç numarasına ait araç tutulur.
            if (vehicle == null) return NotFound($"No vehicle were found for this ID : ({vehicleId})."); // Eğer böyle bir araç bulunamadıysa "Bulunamadı" hatası döndürülür.

            var containers = await _session.Query<Container>().Where(c => c.VehicleId == vehicleId).ToListAsync(); // İstek yapılan araç numarasına sahip konteynerlar tutulur.
            if (containers.Count == 0) return NotFound($"No containers were found for this vehicle : {vehicle.VehicleName}.\nContainer count must be at least 1."); // Eğer hiç konteyner yoksa "Bulunamadı" hatası döndürülür.
            if (containers.Count < clusterCount) return BadRequest($"Cluster count ({clusterCount}) must be less than container count ({containers.Count})."); // Eğer belirtilen küme sayısı bulunan konteynerların sayısından büyükse "Geçersiz İstek" hatası döndürülür.

            var list = new List<ContainersWithDistance>();
            for (int i = 0; i < containers.Count - 1; i++) // Sırayla tüm mesafelerin hesaplanabilmesi için gerekli döngüsel işlem başlatılır.
                list.Add(Calculation.GetDistance(containers[i], containers[i + 1])); // Hesaplanan veriler listeye uzaklık bilgisiyle beraber eklenir.

            var clusteredList = Calculation.Cluster(list, (int)clusterCount); // Kümeleme algoritması devreye girer. Belirtilen küme sayısı kadar kümelenir. Eşit bölünememe durumunda son kümelere düzgün dağıtım yapılarak kümelenir.
            return Ok(clusteredList); // Kümeler listesi "Başarılı" mesajıyla birlikte döndürülür.
        }
    }
}
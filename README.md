<i>PayCore .NET Core Bootcamp - 4. Hafta</i>

<hr />
<h2>Proje Hakkında</h2>
<ul>
    <li>.NET 6 ile geliştirilmiş bir ASP.NET Web API projesidir.</li>
    <li>Sınıflara ve barındırdığı özelliklere dair açıklamalar her dosyanın içerisinde yorum satırlarında detaylı olarak belirtilmiştir.</li>
    <li><a href="https://www.postgresql.org" target="_blank">PostgreSQL</a> veri tabanı kullanılmıştır.</li>
    <li><a href="https://nhibernate.info" target="_blank">NHibernate</a> ORM aracından yararlanılmıştır.</li>
    <li>Sonuçlar en aşağıda yer almaktadır.</li>
    <li>Veritabanına ait script kodlarına <a href="https://pastebin.com/pk7mtrZz" target="_blank">bu linkten</a> erişilebilir. (VPN gerekebilir.)</li>
    <li>Travelling salesman algoritmasından yararlanılmıştır. Uzaklık hesaplaması için matematiksel formüllerden yararlanılmıştır.</li>
    <li>Kümeleme işlemlerinde kullanılan metodun oluşturulmasında yardımcı bir model sınıf kullanılmıştır.</li>
</ul>

<hr />
<h2>Proje Yapısı</h2>
<ul>
    <li>Controllers
        <ul>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Controllers/ClusteringController.cs">ClusteringController.cs</a></li>
        </ul>
    </li>
    <li>Extensions
        <ul>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Extensions/NHibernateExtension.cs">NHibernateExtension.cs</a></li>
        </ul>
    </li>
    <li>Models
        <ul>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Models/Vehicle.cs">Vehicle.cs</a></li>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Models/Container.cs">Container.cs</a></li>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Models/ContainersWithDistance.cs">ContainersWithDistance.cs</a></li>
        </ul>
    </li>
    <li>Mappings
        <ul>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Mappings/VehicleMap.cs">VehicleMap.cs</a></li>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Mappings/ContainerMap.cs">ContainerMap.cs</a></li>
        </ul>
    </li>
    <li>Utilities
        <ul>
            <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Utilities/Calculation.cs">Calculation.cs</a></li>
        </ul>
    </li>
    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/Program.cs">Program.cs</a></li>
    <li><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta4/blob/main/PayCoreClassWork4/PayCoreClassWork4/appsettings.json">appsettings.json</a></li>
</ul>

<hr />
<h2><b>Veritabanı Tablo ve Kolon Şeması</b></h2>
<ul>
    <li>
        <h3>Araçlar (vehicles) tablosu</h3>
        <p dir="auto">
            <a target="_blank" rel="noopener noreferrer" href="">
                <img src="https://i.hizliresim.com/92c310o.png" alt="Swagger" style="max-width: 100%;">
            </a>
        </p>
    </li>
    <li>
        <h3>Konteynerler (containers) tablosu</h3>
        <p dir="auto">
            <a target="_blank" rel="noopener noreferrer" href="">
                <img src="https://i.hizliresim.com/3nrvd5f.png" alt="Swagger" style="max-width: 100%;">
            </a>
        </p>
    </li>
</ul>

<hr />
<h2><b>Sonuç</b></h2>
<h4>Örnek: Veritabanında 1 araç numarasına sahip 8 (N) araç bulunmaktadır. 3 (X) farklı rotada kümelenerek en kısa mesafe üzerinden doldurum ve boşaltım yapılması amaçlandığı zaman oluşan listeler listesinin örnek JSON çıktısı aşağıdaki gibidir.</h4>
<br />
<code>[HttpGet("{vehicleId}/{clusterCount}")] Get(long? vehicleId, int? clusterCount)</code>
<br />
<code>Request URL: api/Clustering/1/3</code>
<br />
<br />

```JSON
[
  [
    {
      "containers": [
        {
          "id": 3,
          "containerName": "TestContainer3",
          "latitude": 33.235214,
          "longitude": 40.331585,
          "vehicleId": 1
        },
        {
          "id": 4,
          "containerName": "TestContainer4",
          "latitude": 32.235214,
          "longitude": 39.331585,
          "vehicleId": 1
        }
      ],
      "distance": 145.3014335758858
    },
    {
      "containers": [
        {
          "id": 4,
          "containerName": "TestContainer4",
          "latitude": 32.235214,
          "longitude": 39.331585,
          "vehicleId": 1
        },
        {
          "id": 5,
          "containerName": "TestContainer5",
          "latitude": 31.235214,
          "longitude": 38.331585,
          "vehicleId": 1
        }
      ],
      "distance": 145.9699859772582
    },
    {
      "containers": [
        {
          "id": 5,
          "containerName": "TestContainer5",
          "latitude": 31.235214,
          "longitude": 38.331585,
          "vehicleId": 1
        },
        {
          "id": 6,
          "containerName": "TestContainer6",
          "latitude": 30.235214,
          "longitude": 37.331585,
          "vehicleId": 1
        }
      ],
      "distance": 146.62401820541245
    }
  ],
  [
    {
      "containers": [
        {
          "id": 6,
          "containerName": "TestContainer6",
          "latitude": 30.235214,
          "longitude": 37.331585,
          "vehicleId": 1
        },
        {
          "id": 7,
          "containerName": "TestContainer7",
          "latitude": 29.235214,
          "longitude": 36.331585,
          "vehicleId": 1
        }
      ],
      "distance": 147.26293208619572
    },
    {
      "containers": [
        {
          "id": 7,
          "containerName": "TestContainer7",
          "latitude": 29.235214,
          "longitude": 36.331585,
          "vehicleId": 1
        },
        {
          "id": 8,
          "containerName": "TestContainer8",
          "latitude": 28.235214,
          "longitude": 35.331585,
          "vehicleId": 1
        }
      ],
      "distance": 147.88615008326633
    },
    {
      "containers": [
        {
          "id": 1,
          "containerName": "TestContainer1",
          "latitude": 35.235214,
          "longitude": 42.331585,
          "vehicleId": 1
        },
        {
          "id": 3,
          "containerName": "TestContainer3",
          "latitude": 33.235214,
          "longitude": 40.331585,
          "vehicleId": 1
        }
      ],
      "distance": 288.5334071608722
    }
  ],
  [
    {
      "containers": [
        {
          "id": 8,
          "containerName": "TestContainer8",
          "latitude": 28.235214,
          "longitude": 35.331585,
          "vehicleId": 1
        },
        {
          "id": 2,
          "containerName": "TestContainer2",
          "latitude": 34.235214,
          "longitude": 41.331585,
          "vehicleId": 1
        }
      ],
      "distance": 877.4020546726479
    }
  ]
]
```

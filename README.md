- ToDoPlanning solution'ınında .Net Core Console,Web Api ve Mvc olmak üzere 3 proje bulunmaktadır.
- Console uygulaması 3 farklı providerdan gelen to-do iş bilgilerini çekerek Mongo Db'ye yazmaktadır.
- Api projesi MongoDb'ye yazılan developer ve task listelerini çekerek taskların en kısa sürede tamamlanmasını sağlayacak şekilde developarlara assign etmektedir.
- Mvc projesi ilgili Api'ye istek atarak developarlara asign edilmiş takları haftalık bazlı olarak göstermektedir.

Projenin Çalıştırılması
- Projenin ana dizininde bulunan docker-compose dosyası docker-compose run komutu ile çalıştırıldığında mongo db container olarak ayağa kalkmaktadır.
- MongoDb çalıştırıldıktan sonra Console uygulamasını çalıştırıldığında ilgili provider'lardan veriler çekilerek mongo db'ye yazılmaktadır.
- Web Api ve Web Mvc uygulamaları birlikte çalıştırıldğı zamanda Home ekranında developarlara atanan haftalık tasklar ekrana gelmektedir.
- Web Api link -> http://localhost:5017/swagger/index.html
- Mvc link -> https://localhost:7179/

Api'den dönen response : 
![image](https://github.com/BurakSarpkaya/ToDoPlanning/assets/56655317/87ed17dd-ef1c-4a13-a520-e85eb78c83f3)

Home Ekranı : 
![image](https://github.com/BurakSarpkaya/ToDoPlanning/assets/56655317/ee34635c-8a85-4938-9d0f-31a7409c0be2)


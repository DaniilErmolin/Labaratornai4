﻿using Azure;
using lab4.Data;
using lab4.Models;
using System.Threading.Tasks;

namespace lab4
{
    public static class DbInitializer
    {
        private static Random random = new Random();
        private static List<string> Names = new()
        {
            "Пляжный отдых", "Горнолыжный отдых", "Экскурсии", "Активный отдых",
            "Культурный отдых", "Гастрономический туризм", "Спа-отдых", "Экологический туризм",
            "Круизы", "Альпинизм", "Путешествие с детьми", "Фестивали и мероприятия",
            "Путешествие в исторические эпохи", "Паломничество", "Треккинг", "Велотуризм",
            "Дайвинг", "Сафари", "Городские прогулки", "Путешествие в маленькие деревни",
            "Водные виды отдыха", "Гаражный туризм", "Экстремальный спорт", "Путешествие в лес",
            "Морская охота", "Археологические раскопки", "Искусство и ремесла", "Астрономические наблюдения",
            "Походы с палатками", "Термальные источники", "Фотосафари", "Рыбалка",
            "Каякинг", "Серфинг", "Йога и здоровье", "Лошади и верховая езда",
            "Походы в горы", "Медицинский туризм", "Путешествия на воздушных шарах",
            "Семейный отдых", "Спортивные мероприятия", "Зоотуризм", "Архитектурный туризм",
            "Гастрономические туры", "Кино и культура", "Походы на водопады",
            "Посещение термальных источников", "Путешествия на морских круизных лайнерах",
            "Фотографический туризм", "Спелеотуризм", "Индивидуальные туры", "Исторические путешествия",
            "Садоводство и ботанические сады"
        };
        private static List<string> Descriptions = new()
        {
            "Отдых на берегу моря", "Катание на горных лыжах", "Посещение туристических мест и достопримечательностей",
            "Спортивные мероприятия и приключения", "Посещение музеев и исторических мест",
            "Путешествие для гурманов", "Посещение спа-центров и процедур", "Путешествие по экологически чистым местам",
            "Путешествие на круизном лайнере", "Покорение вершин и скал", "Семейный отдых с детьми",
            "Посещение фестивалей и культурных событий", "Посещение исторических реконструкций",
            "Религиозное путешествие к святым местам", "Пеший туризм по тропам и маршрутам", "Путешествие на велосипеде",
            "Подводное плавание и исследование морских глубин", "Путешествие на африканских сафари",
            "Ознакомление с историей города", "Знакомство с местной культурой",
            "Активности на воде: каякинг, серфинг и др.", "Путешествие на автомобиле или мотоцикле",
            "Путешествие для адреналин-зависимых", "Оздоровление и медитация в природе",
            "Подводная охота и добыча морских биоресурсов", "Исследование археологических памятников",
            "Мастер-классы и творческие занятия", "Изучение звезд и планет",
            "Переезды и ночевки в палатках", "Посещение горячих источников и курортов",
            "Съемка дикой природы и животных", "Охота на рыбу и ловля",
            "Путешествие на байдарках и каяках", "Катание на волнах и серфбордах",
            "Занятия йогой и здоровый образ жизни", "Путешествие на лошадях и тренировки",
            "Покорение вершин и альпинизм", "Путешествие для получения медицинских услуг",
            "Воздушные прогулки и экскурсии", "Отдых с семьей и детьми",
            "Посещение спортивных событий и соревнований", "Посещение зоопарков и заповедников",
            "Исследование архитектурных памятников и стилей", "Путешествие для гурманов и дегустации",
            "Посещение киносъемок и культурных мероприятий", "Путешествие к водопадам и каскадам",
            "Оздоровление в термальных источниках", "Плавание на круизных кораблях",
            "Съемка пейзажей и архитектуры", "Исследование подземных пещер и карстов",
            "Организация индивидуальных маршрутов", "Посещение исторических мест и памятников",
            "Уход за садами и изучение растений"
        };
        private static List<string> Restriction = new()
        {
            "Нет особых ограничений", "Требуется опыт вождения лыж", "Возможны долгие поездки", "Физическая подготовка необходима",
            "Без специальных ограничений", "Возможны ограничения по диете", "Могут потребоваться предварительные записи",
            "Соблюдение правил охраны природы", "Важно учитывать стихийные бедствия", "Высокая физическая подготовка",
            "Удобства и развлечения для детей", "Сезонность мероприятий", "Соблюдение исторической аутентичности",
            "Духовное вдохновение и покаяние", "Специальное снаряжение и физическая подготовка", "Безопасность на дороге",
            "Сертификация и оборудование", "Безопасность при встрече с дикой природой", "Пешеходные маршруты и гиды",
            "Простые условия и общение с местными жителями", "Уровень подготовки и безопасность", "Транспорт и маршруты",
            "Экстремальные условия и безопасность", "Выживание и безопасность", "Законы и лицензии", "Соблюдение законов и методологии",
            "Творческий потенциал и интересы", "Телескоп и наблюдательные условия", "Подготовка и оборудование",
            "Гигиенические меры и релаксация", "Фототехника и охрана природы", "Рыболовные удочки и законы",
            "Безопасность на воде и маршруты", "Оборудование и безопасность", "Инструкторы и практика",
            "Лошади и седла", "Высота и экстримальные условия", "Медицинская документация",
            "Безопасность и погодные условия", "Удобства для детей и развлечения",
            "Билеты и график мероприятий", "Экологические меры и безопасность", "Архитектурные особенности",
            "Местная кухня и рестораны", "Расписание и билеты", "Тропы и маршруты к водопадам",
            "Температурные режимы и лечебные свойства", "Маршруты и каюты на корабле", "Фотоаппаратура и композиция",
            "Снаряжение и опасности в пещерах", "Персональное обслуживание", "Экскурсии и исторические факты",
            "Ботанические особенности"
        };
        private static List<string> Fios = new()
        {
            "Екатерина Козлова",
            "Иван Смирнов",
            "Дмитрий Иванов",
            "Екатерина Сидорова",
            "Александр Козлов",
            "Мария Козлова",
            "Иван Иванов",
            "Дмитрий Петров",
            "Мария Смирнов",
            "Иван Сидоров",
            "Александр Петров"
        };

        public static void Initialize(TouristAgency1Context db)
        {
            db.Database.EnsureCreated();

            if (!db.TypesOfRecreations.Any())
            {
               for (int i = 0; i < 100; i++)
                {
                    string Name = Names[random.Next(0,Names.Count)];
                    string Description = Descriptions[random.Next(0, Descriptions.Count)];
                    string Restrictions = Restriction[random.Next(0, Restriction.Count)];
                    db.Add(new TypesOfRecreation() { Name = Name, Description = Description, Restrictions = Restrictions });
                }
                db.SaveChanges();
            }

            if (!db.Clients.Any())
            {
                for (int i = 0; i < 100; i++)
                {
                    string Fio = Fios[random.Next(0, Fios.Count)];
                    DateTime DateOfBirth = DateTime.Now.AddYears(-random.Next(0, 100));
                    string Sex = (db.Clients.Count() % 2 == 0) ? "Мужской" : "Женский";
                    string Address = "Адрес " + db.Clients.Count().ToString();
                    string Series = Guid.NewGuid().ToString().Substring(0, 2);
                    long Number = Math.Abs(random.Next()) % 10000000000;
                    int Discount = Math.Abs(random.Next()) % 20;
                    db.Add(new Client() { Fio = Fio, DateOfBirth = DateOfBirth, Sex = Sex, Address = Address, Series = Series, Number = Number, Discount = Discount });
                }
                db.SaveChanges();
            }

            if(!db.Vouchers.Any()) {
                for (int i = 0; i < 100; i++)
                {
                    DateTime startDate = DateTime.Now.AddDays(-random.Next(0, 365));
                    DateTime expirationDate = startDate.AddDays(random.Next(1, 31));
                    int typeOfRecreationId = random.Next(1, 51);
                    int clientId = random.Next(1, 51); 
                    db.Add(new Voucher() { StartDate = startDate, ExpirationDate = expirationDate, TypeOfRecreationId=typeOfRecreationId, ClientId = clientId });
                }
                db.SaveChanges();
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    class ContextInitializer:CreateDatabaseIfNotExists<MyContextDb>
    {
        protected override void Seed(MyContextDb context)
        {
            context.DetailTypes.Add(new DetailType { TypeName = "Мікрофон", Id = 1 });//1
            context.DetailTypes.Add(new DetailType { TypeName = "Динамік", Id = 2 });//2
            context.DetailTypes.Add(new DetailType { TypeName = "Роз'єм", Id = 3 });//3
            context.DetailTypes.Add(new DetailType { TypeName = "Дисплей", Id = 4 });//4
            context.DetailTypes.Add(new DetailType { TypeName = "Кнопка", Id = 5 });//5
            context.DetailTypes.Add(new DetailType { TypeName = "Камера", Id = 6 });//6
            context.DetailTypes.Add(new DetailType { TypeName = "Тачпад", Id = 7 });//7
            context.DetailTypes.Add(new DetailType { TypeName = "Клавіатура", Id = 8 });//8
            context.DetailTypes.Add(new DetailType { TypeName = "Процесор", Id = 9  });//9
            context.DetailTypes.Add(new DetailType { TypeName = "Оперативна пам'ять", Id = 10 });//10
            context.DetailTypes.Add(new DetailType { TypeName = "Відеокарта", Id = 11 });//11
            context.DetailTypes.Add(new DetailType { TypeName = "Акумулятор", Id = 12 });//12



            context.DeviceTypes.Add(new DeviceType { TypeName = "Телефон", Id = 1 });
            context.DeviceTypes.Add(new DeviceType { TypeName = "Планшет", Id = 2 });
            context.DeviceTypes.Add(new DeviceType { TypeName = "Ноутбук", Id = 3 });

            context.OrderStatuses.Add(new OrderStatus { StatusName = "Замовлення прийнято", Id = 1 });
            context.OrderStatuses.Add(new OrderStatus { StatusName = "В обробці", Id = 2 });
            context.OrderStatuses.Add(new OrderStatus { StatusName = "Виконано", Id = 3 });
            context.OrderStatuses.Add(new OrderStatus { StatusName = "Замовлення отримане клієнтом", Id = 4 });

            context.OrderTypes.Add(new OrderType { TypeName = "З доставкою", Id = 1 });
            context.OrderTypes.Add(new OrderType { TypeName = "Без доставки", Id = 2 });

            context.Positions.Add(new Position { PositionName = "Керівник", Id = 1});
            context.Positions.Add(new Position { PositionName = "Технік", Id = 2 });
            context.Positions.Add(new Position { PositionName = "Менеджер по замовленнях", Id = 3 });
            context.Positions.Add(new Position { PositionName = "Менеджер по деталях", Id = 4});

            context.Employees.Add(new Employee { Id = 1, Name = "Василь", Surname = "Вольник", FatherName = "Степанович", IdPosition = 2, Login = "vasylVol6678", Password = "volnyk6678" });//1
            context.Employees.Add(new Employee { Id = 2, Name = "Петро", Surname = "Стещук", FatherName = "Віталійович", IdPosition = 2, Login = "petroSte9290", Password = "steshchuk9290" });//2
            context.Employees.Add(new Employee { Id = 3, Name = "Андрій", Surname = "Григорчук", FatherName = "Олегович", IdPosition = 2, Login = "andriiGry5262", Password = "grygorchuk5262" });//3
            context.Employees.Add(new Employee { Id = 4, Name = "Вікторія", Surname = "Мельник", FatherName = "Романівна", IdPosition = 3, Login = "viktoriyaMel1111", Password = "melnyk1111" });//4
            context.Employees.Add(new Employee { Id = 5, Name = "Віктор", Surname = "Пилипчук", FatherName = "Андрійович", IdPosition = 3, Login = "viktorPil5161", Password = "pilipchuk5161" });//5
            context.Employees.Add(new Employee { Id = 6, Name = "Олександр", Surname = "Козак", FatherName = "Йосипович", IdPosition = 4, Login = "olexandrKoz1353", Password = "kozak1353" });//6
            context.Employees.Add(new Employee { Id = 7, Name = "Богдан", Surname = "Шклянка", FatherName = "Богданович", IdPosition = 1, Login = "bogdanShkl2020", Password = "admin2020" });//7

            context.Details.Add(new Detail { DetailName = "R33-s25", IdDetailType =  1, Price = 15, AvaibleQuantity = 5});//1
            context.Details.Add(new Detail { DetailName = "Samsung VT-42", IdDetailType =  4, Price = 30, AvaibleQuantity = 3});///2
            context.Details.Add(new Detail { DetailName = "Xiaomi I4235", IdDetailType =  5, Price = 10, AvaibleQuantity = 10});//3
            context.Details.Add(new Detail { DetailName = "Apple B2682", IdDetailType =  2, Price = 25, AvaibleQuantity = 6});//4
            context.Details.Add(new Detail { DetailName = "Apple RD26829", IdDetailType =  6, Price = 40, AvaibleQuantity = 4});//5
            context.Details.Add(new Detail { DetailName = "Huawei 52829IS", IdDetailType =  7, Price = 40, AvaibleQuantity = 4});//6
            context.Details.Add(new Detail { DetailName = "Huawei 3583GR42", IdDetailType =  8, Price = 50, AvaibleQuantity = 2});//7
            context.Details.Add(new Detail { DetailName = "Apple 538GR", IdDetailType =  4, Price = 50, AvaibleQuantity = 1});//8
            context.Details.Add(new Detail { DetailName = "Apple DIS49205", IdDetailType =  4, Price = 37, AvaibleQuantity = 4});//9
            context.Details.Add(new Detail { DetailName = "Samsung GD9026", IdDetailType =  5, Price = 25, AvaibleQuantity = 6});//10
            context.Details.Add(new Detail { DetailName = "Samsung 52FR53", IdDetailType =  2, Price = 20, AvaibleQuantity = 11});//11
            context.Details.Add(new Detail { DetailName = "Samsung 42RF52", IdDetailType =  1, Price = 13, AvaibleQuantity = 12});//12
            context.Details.Add(new Detail { DetailName = "Xiaomi R2524", IdDetailType =  2, Price = 7, AvaibleQuantity = 6});//13


            context.Devices.Add(new Device { Mark = "Apple", Model = "Iphone 8", IdDeviceType = 1 });
            context.Devices.Add(new Device { Mark = "Apple", Model = "Iphone X", IdDeviceType = 1 });
            context.Devices.Add(new Device { Mark = "Apple", Model = "Iphone Xs", IdDeviceType = 1 });
            context.Devices.Add(new Device { Mark = "Apple", Model = "MacBook Air", IdDeviceType = 3 });
            context.Devices.Add(new Device { Mark = "Xiaomi", Model = "Redmi 8x ", IdDeviceType = 1 });
            context.Devices.Add(new Device { Mark = "Xiaomi", Model = "Mi Book pro", IdDeviceType = 3});
            context.Devices.Add(new Device { Mark = "Lenovo", Model = "Yoga Tablet", IdDeviceType = 2});
            context.Devices.Add(new Device { Mark = "Lenovo", Model = "ThinkPad T370", IdDeviceType = 3});

            context.Clients.Add(new Client { Name = "Ігор", Surname = "Веретільник", FatherName = "Тарасович", Phone = "+380672692624", Address ="" });
            context.Clients.Add(new Client { Name = "Антон", Surname = "Крутоголов", FatherName = "Микитович", Phone = "+380672683963", Address ="м.Львів вул.Городоцька 224" });
            context.Clients.Add(new Client { Name = "Віталій", Surname = "Томаш", FatherName = "Валентинович", Phone = "+380635689473", Address ="м.Львів вул.Стрийська 124" });
            context.Clients.Add(new Client { Name = "Орест", Surname = "Войтик", FatherName = "Петрович", Phone = "+380935675285", Address ="" });
            context.Clients.Add(new Client { Name = "Ангеліна", Surname = "Кульчицька", FatherName = "Василівна", Phone = "+380977658736", Address ="" });



            context.Orders.Add(new Order { OrderDate = new DateTime(2021, 02, 10), Description = "Пошкоджений дисплей", TotalPrice = 50, IdClient = 1, IdOrderStatus = 4, IdWorkman = 3, IdOrderType = 2, IdDevice = 2 });
            context.Orders.Add(new Order { OrderDate = new DateTime(2021, 02, 12), Description = "Тихо звучить верхній динамік", TotalPrice = 40, IdClient = 2, IdOrderStatus = 4, IdWorkman = 2, IdOrderType = 1, IdDevice = 5 });
            context.Orders.Add(new Order { OrderDate = new DateTime(2021, 03, 03), Description = "Тріснула камера", TotalPrice = 30, IdClient = 3, IdOrderStatus = 4, IdWorkman = 1, IdOrderType = 1, IdDevice = 3 });

            context.UsedDetails.Add(new UsedDetail { IdDetail = 8, IdOrder = 1 });
            context.UsedDetails.Add(new UsedDetail { IdDetail = 13, IdOrder = 2 });
            context.UsedDetails.Add(new UsedDetail { IdDetail = 5, IdOrder = 3 });

        }
    }
}

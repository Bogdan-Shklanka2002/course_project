using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ComputerRepair
{
    public class MyContextDb: DbContext
    {
        public MyContextDb(string conStr) : base(conStr)
        {

        }
        static MyContextDb()
        {
            Database.SetInitializer<MyContextDb>(new ContextInitializer());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<UsedDetail> UsedDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var clients = modelBuilder.Entity<Client>();
            clients.HasKey(x => x.Id);
            clients.Property(x => x.Address).IsOptional();
            clients.Property(x => x.Name).IsRequired();
            clients.Property(x => x.Surname).IsRequired();
            clients.Property(x => x.FatherName).IsRequired();
            clients.Property(x => x.Phone).IsRequired();
            clients.HasMany(x => x.Orders).WithRequired(x => x.Client).HasForeignKey(x => x.IdClient);

            var deviceTypes = modelBuilder.Entity<DeviceType>();
            deviceTypes.HasKey(x => x.Id);
            deviceTypes.Property(x => x.TypeName).IsRequired();
            deviceTypes.HasMany(x => x.Devices).WithRequired(x => x.DeviceType).HasForeignKey(x => x.IdDeviceType);

            var devices = modelBuilder.Entity<Device>();
            devices.HasKey(x => x.Id);
            devices.Property(x => x.Mark).IsRequired();
            devices.Property(x => x.Model).IsRequired();
            devices.HasMany(x => x.Orders).WithRequired(x => x.Device).HasForeignKey(x => x.IdDevice);

            var detailTypes = modelBuilder.Entity<DetailType>();
            detailTypes.HasKey(x => x.Id);
            detailTypes.Property(x => x.TypeName).IsRequired();
            detailTypes.HasMany(x => x.Details).WithRequired(x => x.DetailType).HasForeignKey(x => x.IdDetailType);

            var details = modelBuilder.Entity<Detail>();
            details.HasKey(x => x.Id);
            details.Property(x => x.DetailName).IsRequired();
            details.Property(x => x.AvaibleQuantity).IsRequired();
            details.Property(x => x.Price).IsRequired();
            details.Property(x => x.Price).HasColumnType("money");
            details.HasMany(x => x.UsedDetails).WithRequired(x => x.Detail).HasForeignKey(x => x.IdDetail);

            var orderStatus = modelBuilder.Entity<OrderStatus>();
            orderStatus.HasKey(x => x.Id);
            orderStatus.Property(x => x.StatusName).IsRequired();
            orderStatus.HasMany(x => x.Orders).WithOptional(x => x.OrderStatus).HasForeignKey(x => x.IdOrderStatus);

            var orderType = modelBuilder.Entity<OrderType>();
            orderType.HasKey(x => x.Id);
            orderType.Property(x => x.TypeName).IsRequired();
            orderType.HasMany(x => x.Orders).WithRequired(x => x.OrderType).HasForeignKey(x => x.IdOrderType);

            var positions = modelBuilder.Entity<Position>();
            positions.HasKey(x => x.Id);
            positions.Property(x => x.PositionName).IsRequired();
            positions.HasMany(x => x.Employees).WithRequired(x => x.Position).HasForeignKey(x => x.IdPosition);

            var employees = modelBuilder.Entity<Employee>();
            employees.HasKey(x => x.Id);
            employees.Property(x => x.Name).IsRequired();
            employees.Property(x => x.Surname).IsRequired();
            employees.Property(x => x.FatherName).IsRequired();
            employees.Property(x => x.Login).IsRequired();
            employees.Property(x => x.Password).IsRequired();
            employees.HasMany(x => x.Orders).WithOptional(x => x.Workman).HasForeignKey(x => x.IdWorkman);

            var orders = modelBuilder.Entity<Order>();
            orders.HasKey(x => x.Id);
            orders.Property(x => x.OrderDate).HasColumnType("date").IsRequired();
            orders.Property(x => x.TotalPrice).HasColumnType("money").IsOptional();
            orders.Property(x => x.IdWorkman).IsOptional();
            orders.Property(x => x.IdOrderStatus).IsOptional();
            orders.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            orders.HasMany(x => x.UsedDetails).WithRequired(x => x.Order).HasForeignKey(x => x.IdOrder);

            var usedDetails = modelBuilder.Entity<UsedDetail>();
            usedDetails.HasKey(x => x.Id);
            usedDetails.Property(x => x.IdDetail).IsRequired();
            usedDetails.Property(x => x.IdOrder).IsRequired();

           
            







        }

    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pryanichek_version_1000.Models
{
    public partial class new_pryanickContext : DbContext
    {
        public new_pryanickContext()
        {
        }

        public new_pryanickContext(DbContextOptions<new_pryanickContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bakery> Bakery { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientPrefer> ClientPrefer { get; set; }
       // public virtual DbSet<CountAllergicIngredients> CountAllergicIngredients { get; set; }
        public virtual DbSet<CumulativeAmount> CumulativeAmount { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        //public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<MonthSales> MonthSales { get; set; }
        public virtual DbSet<NewMonthSales> NewMonthSales { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInclude> ProductInclude { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Sort> Sort { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<НакопительнаяСуммаПродаж> НакопительнаяСуммаПродаж { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=new_pryanick;Username=postgres;Password=cherry19");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "sex", new[] { "F", "M" });

            modelBuilder.Entity<Bakery>(entity =>
            {
                entity.HasKey(e => e.BakeryNo)
                    .HasName("Bakery_pkey");

                entity.ToTable("bakery");

                entity.HasIndex(e => new { e.Street, e.HouseNumber, e.TelNo })
                    .HasName("Bakery_Street_HouseNumber_TelNo_key")
                    .IsUnique();

                entity.Property(e => e.BakeryNo).HasDefaultValueSql("nextval('\"Bakery_BakeryNo_seq\"'::regclass)");

                entity.Property(e => e.BakeryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TelNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientNo)
                    .HasName("Client_pkey");

                entity.ToTable("client");

                entity.HasIndex(e => e.TelNo)
                    .HasName("Client_TelNo_key")
                    .IsUnique();

                entity.Property(e => e.ClientNo).HasDefaultValueSql("nextval('\"Client_ClientNo_seq\"'::regclass)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TelNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ClientPrefer>(entity =>
            {
                entity.HasKey(e => e.ClientPreferNo)
                    .HasName("ClientPrefer_pkey");

                entity.ToTable("client_prefer");

                entity.HasIndex(e => new { e.ClientNo, e.ProductNo })
                    .HasName("ClientPrefer_ClientNo_ProductNo_key")
                    .IsUnique();

                entity.Property(e => e.ClientPreferNo).HasDefaultValueSql("nextval('\"ClientPrefer_ClientPreferNo_seq\"'::regclass)");

               /*entity.HasOne(d => d.ClientNoNavigation)
                    .WithMany(p => p.ClientPrefer)
                    .HasForeignKey(d => d.ClientNo)
                    .HasConstraintName("ClientPrefer_ClientNo_fkey");
*/
                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.ClientPrefer)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("ClientPrefer_ProductNo_fkey");
            });

           /* modelBuilder.Entity<CountAllergicIngredients>(entity =>
            {
                entity.HasNoKey();
            });*/

            modelBuilder.Entity<CumulativeAmount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cumulative amount");

                entity.Property(e => e.НакопительнаяСуммаПродаж)
                    .HasColumnName("Накопительная сумма продаж")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.HasKey(e => e.DetailsNo)
                    .HasName("Details_pkey");

                entity.ToTable("details");

                entity.HasIndex(e => new { e.OrderNo, e.ProductNo })
                    .HasName("Details_OrderNo_ProductNo_key")
                    .IsUnique();

                entity.Property(e => e.DetailsNo).HasDefaultValueSql("nextval('\"Details_DetailsNo_seq\"'::regclass)");

                entity.HasOne(d => d.CookNoNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.CookNo)
                    .HasConstraintName("Details_CookNo_fkey");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.OrderNo)
                    .HasConstraintName("Details_OrderNo_fkey");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("Details_ProductNo_fkey");
            });

            /*modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IngredientNo)
                    .HasName("Ingredient_pkey");

                entity.ToTable("ingredient");

                entity.HasIndex(e => e.IngredientName)
                    .HasName("Ingredient_IngredientName_key")
                    .IsUnique();

                entity.Property(e => e.IngredientNo).HasDefaultValueSql("nextval('\"Ingredient_IngredientNo_seq\"'::regclass)");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(20);
            });
            */
            modelBuilder.Entity<MonthSales>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.НазваниеПекарни)
                    .HasColumnName("Название пекарни")
                    .HasMaxLength(50);

                entity.Property(e => e.ПродажаЗаМесяц)
                    .HasColumnName("Продажа за месяц")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<NewMonthSales>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.НазваниеПекарни)
                    .HasColumnName("Название пекарни")
                    .HasMaxLength(50);

                entity.Property(e => e.ПродажаЗаМесяц)
                    .HasColumnName("Продажа за месяц")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("Order_pkey");

                entity.ToTable("order");

                entity.Property(e => e.OrderNo).HasDefaultValueSql("nextval('\"Order_OrderNo_seq\"'::regclass)");

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.Property(e => e.DateOfReceipt).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.CashierNoNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CashierNo)
                    .HasConstraintName("Order_CashierNo_fkey");

                /* entity.HasOne(d => d.ClientNoNavigation)
                     .WithMany(p => p.Order)
                     .HasForeignKey(d => d.ClientNo)
                     .HasConstraintName("Order_ClientNo_fkey");
             });*/

                modelBuilder.Entity<Position>(entity =>
                {
                    entity.HasKey(e => e.PositionNo)
                        .HasName("Position_pkey");

                    entity.ToTable("position");

                    entity.Property(e => e.PositionNo).HasDefaultValueSql("nextval('\"Position_PositionNo_seq\"'::regclass)");

                    entity.Property(e => e.PositionName)
                        .IsRequired()
                        .HasMaxLength(50);
                });

                modelBuilder.Entity<Product>(entity =>
                {
                    entity.HasKey(e => e.ProductNo)
                        .HasName("Product_pkey");

                    entity.ToTable("product");

                    entity.HasIndex(e => e.ProductName)
                        .HasName("Product_ProductName_key")
                        .IsUnique();

                    entity.Property(e => e.ProductNo).HasDefaultValueSql("nextval('\"Product_ProductNo_seq\"'::regclass)");

                    entity.Property(e => e.Price).HasColumnType("numeric(7,2)");

                    entity.Property(e => e.ProductName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.Recipe).IsRequired();

                    entity.HasOne(d => d.ProductSortNavigation)
                        .WithMany(p => p.Product)
                        .HasForeignKey(d => d.ProductSort)
                        .HasConstraintName("Product_ProductSort_fkey");
                });

                modelBuilder.Entity<ProductInclude>(entity =>
                {
                    entity.HasKey(e => e.ProductIncludeNo)
                        .HasName("ProductInclude_pkey");

                    entity.ToTable("product_include");

                    entity.HasIndex(e => new { e.ProductNo, e.IngredientNo })
                        .HasName("ProductInclude_ProductNo_IngredientNo_key")
                        .IsUnique();

                    entity.Property(e => e.ProductIncludeNo).HasDefaultValueSql("nextval('\"ProductInclude_ProductIncludeNo_seq\"'::regclass)");

                    entity.Property(e => e.Measure)
                        .IsRequired()
                        .HasMaxLength(50);

                /* entity.HasOne(d => d.IngredientNoNavigation)
                     .WithMany(p => p.ProductInclude)
                     .HasForeignKey(d => d.IngredientNo)
                     .HasConstraintName("ProductInclude_IngredientNo_fkey");*/

                    entity.HasOne(d => d.ProductNoNavigation)
                        .WithMany(p => p.ProductInclude)
                        .HasForeignKey(d => d.ProductNo)
                        .HasConstraintName("ProductInclude_ProductNo_fkey");
                });

                modelBuilder.Entity<Rack>(entity =>
                {
                    entity.HasKey(e => e.RackNo)
                        .HasName("Rack_pkey");

                    entity.ToTable("rack");

                    entity.HasIndex(e => new { e.RackBakeryNo, e.RackInBakeryNo })
                        .HasName("Rack_RackBakeryNo_RackInBakeryNo_key")
                        .IsUnique();

                    entity.Property(e => e.RackNo).HasDefaultValueSql("nextval('\"Rack_RackNo_seq\"'::regclass)");

                    entity.HasOne(d => d.RackBakeryNoNavigation)
                        .WithMany(p => p.Rack)
                        .HasForeignKey(d => d.RackBakeryNo)
                        .HasConstraintName("Rack_RackBakeryNo_fkey");

                    entity.HasOne(d => d.SortRackNavigation)
                        .WithMany(p => p.Rack)
                        .HasForeignKey(d => d.SortRack)
                        .HasConstraintName("Rack_SortRack_fkey");
                });

                modelBuilder.Entity<Receipt>(entity =>
                {
                    entity.HasKey(e => e.ReceiptNo)
                        .HasName("Receipt_pkey");

                    entity.ToTable("receipt");

                    entity.Property(e => e.ReceiptNo).HasDefaultValueSql("nextval('\"Receipt_ReceiptNo_seq\"'::regclass)");

                    entity.Property(e => e.AmountOfDiscount).HasColumnType("numeric");

                    entity.Property(e => e.TheDate).HasColumnType("date");

                    entity.HasOne(d => d.CashierNoNavigation)
                        .WithMany(p => p.Receipt)
                        .HasForeignKey(d => d.CashierNo)
                        .HasConstraintName("Receipt_CashierNo_fkey");

                    entity.HasOne(d => d.ClientNoNavigation)
                        .WithMany(p => p.Receipt)
                        .HasForeignKey(d => d.ClientNo)
                        .HasConstraintName("Receipt_ClientNo_fkey");
                });

                modelBuilder.Entity<Sale>(entity =>
                {
                    entity.HasKey(e => e.SaleNo)
                        .HasName("Sale_pkey");

                    entity.ToTable("sale");

                    entity.HasIndex(e => new { e.ProductNo, e.ReceiptNo })
                        .HasName("Sale_ProductNo_ReceiptNo_key")
                        .IsUnique();

                    entity.Property(e => e.SaleNo).HasDefaultValueSql("nextval('\"Sale_SaleNo_seq\"'::regclass)");

                    entity.HasOne(d => d.ProductNoNavigation)
                        .WithMany(p => p.Sale)
                        .HasForeignKey(d => d.ProductNo)
                        .HasConstraintName("Sale_ProductNo_fkey");

                    entity.HasOne(d => d.ReceiptNoNavigation)
                        .WithMany(p => p.Sale)
                        .HasForeignKey(d => d.ReceiptNo)
                        .HasConstraintName("Sale_ReceiptNo_fkey");
                });

                modelBuilder.Entity<Sort>(entity =>
                {
                    entity.HasKey(e => e.SortNo)
                        .HasName("Sort_pkey");

                    entity.ToTable("sort");

                    entity.Property(e => e.SortNo).HasDefaultValueSql("nextval('\"Sort_SortNo_seq\"'::regclass)");

                    entity.Property(e => e.SortName)
                        .IsRequired()
                        .HasMaxLength(20);
                });

                modelBuilder.Entity<Staff>(entity =>
                {
                    entity.HasKey(e => e.StaffNo)
                        .HasName("Staff_pkey");

                    entity.ToTable("staff");

                    entity.HasIndex(e => e.TelNo)
                        .HasName("Staff_TelNo_key")
                        .IsUnique();

                    entity.Property(e => e.StaffNo).HasDefaultValueSql("nextval('\"Staff_StaffNo_seq\"'::regclass)");

                    entity.Property(e => e.Characteristic).HasMaxLength(200);

                    entity.Property(e => e.DateOfBirth).HasColumnType("date");

                    entity.Property(e => e.FiredCharacteristic).HasMaxLength(100);

                    entity.Property(e => e.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.LastName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.Salary).HasColumnType("numeric");

                    entity.Property(e => e.TelNo)
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsFixedLength();

                    entity.HasOne(d => d.PositionNoNavigation)
                        .WithMany(p => p.Staff)
                        .HasForeignKey(d => d.PositionNo)
                        .HasConstraintName("Staff_PositionNo_fkey");

                    entity.HasOne(d => d.StaffBakeryNoNavigation)
                        .WithMany(p => p.Staff)
                        .HasForeignKey(d => d.StaffBakeryNo)
                        .HasConstraintName("Staff_StaffBakeryNo_fkey");
                });

                modelBuilder.Entity<НакопительнаяСуммаПродаж>(entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("Накопительная сумма продаж");

                    entity.Property(e => e.ПродажаЗаМесяц)
                        .HasColumnName("Продажа за месяц")
                        .HasColumnType("numeric");
                });

                OnModelCreatingPartial(modelBuilder);
            }
            ); }
            

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

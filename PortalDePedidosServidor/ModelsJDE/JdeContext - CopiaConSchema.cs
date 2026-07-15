//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;

//namespace PortalDePedidosServidor.ModelsJDE;

//public partial class JdeContext : DbContext
//{
//    private Schema _Schema { get; set; }
//    public JdeContext()
//    {
//    }

//    public JdeContext(DbContextOptions<JdeContext> options,Schema schema)
//        : base(options)
//    {
//        _Schema = schema;
//    }

//    public virtual DbSet<F0101> F0101s { get; set; }

//    public virtual DbSet<F47011> F47011s { get; set; }

//    public virtual DbSet<F47012> F47012s { get; set; }

//    public virtual DbSet<F55sp002> F55sp002s { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer();

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        if(!_Schema.schema.IsNullOrEmpty())
//            modelBuilder.HasDefaultSchema(_Schema.schema);
//        modelBuilder.Entity<F0101>(entity =>
//        {
//            entity.HasKey(e => e.Aban8).HasName("F0101_PK");

//            entity.ToTable("F0101");

//            entity.Property(e => e.Aban8).HasColumnName("ABAN8");
//            entity.Property(e => e.Abab3)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABAB3");
//            entity.Property(e => e.Abac01)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC01");
//            entity.Property(e => e.Abac02)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC02");
//            entity.Property(e => e.Abac03)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC03");
//            entity.Property(e => e.Abac04)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC04");
//            entity.Property(e => e.Abac05)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC05");
//            entity.Property(e => e.Abac06)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC06");
//            entity.Property(e => e.Abac07)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC07");
//            entity.Property(e => e.Abac08)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC08");
//            entity.Property(e => e.Abac09)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC09");
//            entity.Property(e => e.Abac10)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC10");
//            entity.Property(e => e.Abac11)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC11");
//            entity.Property(e => e.Abac12)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC12");
//            entity.Property(e => e.Abac13)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC13");
//            entity.Property(e => e.Abac14)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC14");
//            entity.Property(e => e.Abac15)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC15");
//            entity.Property(e => e.Abac16)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC16");
//            entity.Property(e => e.Abac17)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC17");
//            entity.Property(e => e.Abac18)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC18");
//            entity.Property(e => e.Abac19)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC19");
//            entity.Property(e => e.Abac20)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC20");
//            entity.Property(e => e.Abac21)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC21");
//            entity.Property(e => e.Abac22)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC22");
//            entity.Property(e => e.Abac23)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC23");
//            entity.Property(e => e.Abac24)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC24");
//            entity.Property(e => e.Abac25)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC25");
//            entity.Property(e => e.Abac26)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC26");
//            entity.Property(e => e.Abac27)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC27");
//            entity.Property(e => e.Abac28)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC28");
//            entity.Property(e => e.Abac29)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC29");
//            entity.Property(e => e.Abac30)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAC30");
//            entity.Property(e => e.Abactin)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABACTIN");
//            entity.Property(e => e.Abaempgp)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("ABAEMPGP");
//            entity.Property(e => e.Abalky)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("ABALKY");
//            entity.Property(e => e.Abalp1)
//                .HasMaxLength(40)
//                .IsFixedLength()
//                .HasColumnName("ABALP1");
//            entity.Property(e => e.Abalph)
//                .HasMaxLength(40)
//                .IsFixedLength()
//                .HasColumnName("ABALPH");
//            entity.Property(e => e.Aban81).HasColumnName("ABAN81");
//            entity.Property(e => e.Aban82).HasColumnName("ABAN82");
//            entity.Property(e => e.Aban83).HasColumnName("ABAN83");
//            entity.Property(e => e.Aban84).HasColumnName("ABAN84");
//            entity.Property(e => e.Aban85).HasColumnName("ABAN85");
//            entity.Property(e => e.Aban86).HasColumnName("ABAN86");
//            entity.Property(e => e.Abat1)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABAT1");
//            entity.Property(e => e.Abat2)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABAT2");
//            entity.Property(e => e.Abat3)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABAT3");
//            entity.Property(e => e.Abat4)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABAT4");
//            entity.Property(e => e.Abat5)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABAT5");
//            entity.Property(e => e.Abate)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABATE");
//            entity.Property(e => e.Abatp)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABATP");
//            entity.Property(e => e.Abatpr)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABATPR");
//            entity.Property(e => e.Abatr)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABATR");
//            entity.Property(e => e.Abcaad).HasColumnName("ABCAAD");
//            entity.Property(e => e.Abclass01)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABCLASS01");
//            entity.Property(e => e.Abclass02)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABCLASS02");
//            entity.Property(e => e.Abclass03)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABCLASS03");
//            entity.Property(e => e.Abclass04)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABCLASS04");
//            entity.Property(e => e.Abclass05)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("ABCLASS05");
//            entity.Property(e => e.Abcm)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("ABCM");
//            entity.Property(e => e.Abdc)
//                .HasMaxLength(40)
//                .IsFixedLength()
//                .HasColumnName("ABDC");
//            entity.Property(e => e.Abduns)
//                .HasMaxLength(13)
//                .IsFixedLength()
//                .HasColumnName("ABDUNS");
//            entity.Property(e => e.Abeftb)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("ABEFTB");
//            entity.Property(e => e.Abexchg)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABEXCHG");
//            entity.Property(e => e.Abglba)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("ABGLBA");
//            entity.Property(e => e.Abgrowthr).HasColumnName("ABGROWTHR");
//            entity.Property(e => e.Abjobn)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABJOBN");
//            entity.Property(e => e.Ablngp)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("ABLNGP");
//            entity.Property(e => e.Abmcu)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("ABMCU");
//            entity.Property(e => e.Abmsga)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABMSGA");
//            entity.Property(e => e.Abnoe).HasColumnName("ABNOE");
//            entity.Property(e => e.Abpdi)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("ABPDI");
//            entity.Property(e => e.Abperrs).HasColumnName("ABPERRS");
//            entity.Property(e => e.Abpid)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABPID");
//            entity.Property(e => e.Abprgf)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABPRGF");
//            entity.Property(e => e.Abpti).HasColumnName("ABPTI");
//            entity.Property(e => e.Abrevrng)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("ABREVRNG");
//            entity.Property(e => e.Abrmk)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("ABRMK");
//            entity.Property(e => e.Absbli)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABSBLI");
//            entity.Property(e => e.Absccltp)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("ABSCCLTP");
//            entity.Property(e => e.Absic)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABSIC");
//            entity.Property(e => e.Absyncs).HasColumnName("ABSYNCS");
//            entity.Property(e => e.Abtax)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("ABTAX");
//            entity.Property(e => e.Abtaxc)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("ABTAXC");
//            entity.Property(e => e.Abticker)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABTICKER");
//            entity.Property(e => e.Abtx2)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("ABTX2");
//            entity.Property(e => e.Abtxct)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("ABTXCT");
//            entity.Property(e => e.Abupmj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("ABUPMJ");
//            entity.Property(e => e.Abupmt).HasColumnName("ABUPMT");
//            entity.Property(e => e.Aburab).HasColumnName("ABURAB");
//            entity.Property(e => e.Aburat).HasColumnName("ABURAT");
//            entity.Property(e => e.Aburcd)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("ABURCD");
//            entity.Property(e => e.Aburdt)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("ABURDT");
//            entity.Property(e => e.Aburrf)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("ABURRF");
//            entity.Property(e => e.Abuser)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("ABUSER");
//            entity.Property(e => e.Abyearstar)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("ABYEARSTAR");
//        });

//        modelBuilder.Entity<F47011>(entity =>
//        {
//            entity.HasKey(e => new { e.Syedoc, e.Syedct, e.Syekco }).HasName("F47011_PK");

//            entity.ToTable("F47011");

//            entity.Property(e => e.Syedoc).HasColumnName("SYEDOC");
//            entity.Property(e => e.Syedct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYEDCT");
//            entity.Property(e => e.Syekco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SYEKCO");
//            entity.Property(e => e.Syaddj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYADDJ");
//            entity.Property(e => e.Syadlj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYADLJ");
//            entity.Property(e => e.Syadtm).HasColumnName("SYADTM");
//            entity.Property(e => e.Syaft)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYAFT");
//            entity.Property(e => e.Syan8).HasColumnName("SYAN8");
//            entity.Property(e => e.Syanby).HasColumnName("SYANBY");
//            entity.Property(e => e.Syasn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SYASN");
//            entity.Property(e => e.Syatxt)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYATXT");
//            entity.Property(e => e.Syaufi)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYAUFI");
//            entity.Property(e => e.Syauft)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYAUFT");
//            entity.Property(e => e.Syautn)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYAUTN");
//            entity.Property(e => e.Syback)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYBACK");
//            entity.Property(e => e.Sybcrc)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYBCRC");
//            entity.Property(e => e.Sybsc)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYBSC");
//            entity.Property(e => e.Sycact)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SYCACT");
//            entity.Property(e => e.Sycars).HasColumnName("SYCARS");
//            entity.Property(e => e.Syccidln).HasColumnName("SYCCIDLN");
//            entity.Property(e => e.Sycexp)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYCEXP");
//            entity.Property(e => e.Syclass01)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCLASS01");
//            entity.Property(e => e.Syclass02)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCLASS02");
//            entity.Property(e => e.Syclass03)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCLASS03");
//            entity.Property(e => e.Syclass04)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCLASS04");
//            entity.Property(e => e.Syclass05)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCLASS05");
//            entity.Property(e => e.Sycndj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYCNDJ");
//            entity.Property(e => e.Sycnid)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("SYCNID");
//            entity.Property(e => e.Syco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SYCO");
//            entity.Property(e => e.Sycord).HasColumnName("SYCORD");
//            entity.Property(e => e.Sycot)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCOT");
//            entity.Property(e => e.Sycrcd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYCRCD");
//            entity.Property(e => e.Sycrmd)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYCRMD");
//            entity.Property(e => e.Sycrr).HasColumnName("SYCRR");
//            entity.Property(e => e.Sycrrm)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYCRRM");
//            entity.Property(e => e.Sydct4)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYDCT4");
//            entity.Property(e => e.Sydcto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYDCTO");
//            entity.Property(e => e.Sydel1)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYDEL1");
//            entity.Property(e => e.Sydel2)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYDEL2");
//            entity.Property(e => e.Sydoc1).HasColumnName("SYDOC1");
//            entity.Property(e => e.Sydoco).HasColumnName("SYDOCO");
//            entity.Property(e => e.Sydrqj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYDRQJ");
//            entity.Property(e => e.Sydrqt).HasColumnName("SYDRQT");
//            entity.Property(e => e.Sydvan).HasColumnName("SYDVAN");
//            entity.Property(e => e.Syedbt)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SYEDBT");
//            entity.Property(e => e.Syeddl).HasColumnName("SYEDDL");
//            entity.Property(e => e.Syeddt)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYEDDT");
//            entity.Property(e => e.Syeder)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYEDER");
//            entity.Property(e => e.Syedft)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYEDFT");
//            entity.Property(e => e.Syedln).HasColumnName("SYEDLN");
//            entity.Property(e => e.Syedsp)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYEDSP");
//            entity.Property(e => e.Syedsq).HasColumnName("SYEDSQ");
//            entity.Property(e => e.Syedst)
//                .HasMaxLength(6)
//                .IsFixedLength()
//                .HasColumnName("SYEDST");
//            entity.Property(e => e.Syedty)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYEDTY");
//            entity.Property(e => e.Syexdt0)
//                .HasColumnType("datetime")
//                .HasColumnName("SYEXDT0");
//            entity.Property(e => e.Syexdt1)
//                .HasColumnType("datetime")
//                .HasColumnName("SYEXDT1");
//            entity.Property(e => e.Syexdt2)
//                .HasColumnType("datetime")
//                .HasColumnName("SYEXDT2");
//            entity.Property(e => e.Syexnm0).HasColumnName("SYEXNM0");
//            entity.Property(e => e.Syexnm1).HasColumnName("SYEXNM1");
//            entity.Property(e => e.Syexnm2).HasColumnName("SYEXNM2");
//            entity.Property(e => e.Syexnmp0).HasColumnName("SYEXNMP0");
//            entity.Property(e => e.Syexnmp1).HasColumnName("SYEXNMP1");
//            entity.Property(e => e.Syexnmp2).HasColumnName("SYEXNMP2");
//            entity.Property(e => e.Syexr1)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYEXR1");
//            entity.Property(e => e.Syexvar0)
//                .HasMaxLength(255)
//                .HasColumnName("SYEXVAR0");
//            entity.Property(e => e.Syexvar1)
//                .HasMaxLength(255)
//                .HasColumnName("SYEXVAR1");
//            entity.Property(e => e.Syexvar12)
//                .HasMaxLength(25)
//                .HasColumnName("SYEXVAR12");
//            entity.Property(e => e.Syexvar13)
//                .HasMaxLength(25)
//                .HasColumnName("SYEXVAR13");
//            entity.Property(e => e.Syexvar4)
//                .HasMaxLength(50)
//                .HasColumnName("SYEXVAR4");
//            entity.Property(e => e.Syexvar5)
//                .HasMaxLength(50)
//                .HasColumnName("SYEXVAR5");
//            entity.Property(e => e.Syexvar6)
//                .HasMaxLength(50)
//                .HasColumnName("SYEXVAR6");
//            entity.Property(e => e.Syexvar7)
//                .HasMaxLength(50)
//                .HasColumnName("SYEXVAR7");
//            entity.Property(e => e.Syfap).HasColumnName("SYFAP");
//            entity.Property(e => e.Syfcst).HasColumnName("SYFCST");
//            entity.Property(e => e.Syfrth)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYFRTH");
//            entity.Property(e => e.Syftan).HasColumnName("SYFTAN");
//            entity.Property(e => e.Syfuf1)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYFUF1");
//            entity.Property(e => e.Sygan8).HasColumnName("SYGAN8");
//            entity.Property(e => e.Sygcars).HasColumnName("SYGCARS");
//            entity.Property(e => e.Sygdvan).HasColumnName("SYGDVAN");
//            entity.Property(e => e.Sygftan).HasColumnName("SYGFTAN");
//            entity.Property(e => e.Sygitan).HasColumnName("SYGITAN");
//            entity.Property(e => e.Sygpa8).HasColumnName("SYGPA8");
//            entity.Property(e => e.Sygpban).HasColumnName("SYGPBAN");
//            entity.Property(e => e.Sygpran8).HasColumnName("SYGPRAN8");
//            entity.Property(e => e.Sygshan).HasColumnName("SYGSHAN");
//            entity.Property(e => e.Syhold)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYHOLD");
//            entity.Property(e => e.Syinmg)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYINMG");
//            entity.Property(e => e.Syir01)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYIR01");
//            entity.Property(e => e.Syir02)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYIR02");
//            entity.Property(e => e.Syir03)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYIR03");
//            entity.Property(e => e.Syir04)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYIR04");
//            entity.Property(e => e.Syir05)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYIR05");
//            entity.Property(e => e.Syitan).HasColumnName("SYITAN");
//            entity.Property(e => e.Syjobn)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYJOBN");
//            entity.Property(e => e.Sykcoo)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SYKCOO");
//            entity.Property(e => e.Sylngp)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYLNGP");
//            entity.Property(e => e.Symcu)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SYMCU");
//            entity.Property(e => e.Symot)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYMOT");
//            entity.Property(e => e.Syntr)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYNTR");
//            entity.Property(e => e.Synxdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYNXDJ");
//            entity.Property(e => e.Syocto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYOCTO");
//            entity.Property(e => e.Syofrq)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOFRQ");
//            entity.Property(e => e.Syokco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SYOKCO");
//            entity.Property(e => e.Syoorn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SYOORN");
//            entity.Property(e => e.Syopba)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOPBA");
//            entity.Property(e => e.Syopbk).HasColumnName("SYOPBK");
//            entity.Property(e => e.Syopbo)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYOPBO");
//            entity.Property(e => e.Syopdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYOPDJ");
//            entity.Property(e => e.Syopld)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYOPLD");
//            entity.Property(e => e.Syopll)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOPLL");
//            entity.Property(e => e.Syopms)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOPMS");
//            entity.Property(e => e.Syoppid).HasColumnName("SYOPPID");
//            entity.Property(e => e.Syoppl)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOPPL");
//            entity.Property(e => e.Syopps)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYOPPS");
//            entity.Property(e => e.Syopsb).HasColumnName("SYOPSB");
//            entity.Property(e => e.Syopss)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOPSS");
//            entity.Property(e => e.Syoptc).HasColumnName("SYOPTC");
//            entity.Property(e => e.Syoptt).HasColumnName("SYOPTT");
//            entity.Property(e => e.Syorby)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYORBY");
//            entity.Property(e => e.Syotind)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYOTIND");
//            entity.Property(e => e.Syotot).HasColumnName("SYOTOT");
//            entity.Property(e => e.Sypa8).HasColumnName("SYPA8");
//            entity.Property(e => e.Sypban).HasColumnName("SYPBAN");
//            entity.Property(e => e.Sypcrt).HasColumnName("SYPCRT");
//            entity.Property(e => e.Sypddj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPDDJ");
//            entity.Property(e => e.Sypdtt).HasColumnName("SYPDTT");
//            entity.Property(e => e.Sypefj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPEFJ");
//            entity.Property(e => e.Sypid)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPID");
//            entity.Property(e => e.Sypmdt).HasColumnName("SYPMDT");
//            entity.Property(e => e.Sypnid)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SYPNID");
//            entity.Property(e => e.Sypohab01).HasColumnName("SYPOHAB01");
//            entity.Property(e => e.Sypohab02).HasColumnName("SYPOHAB02");
//            entity.Property(e => e.Sypohc01)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC01");
//            entity.Property(e => e.Sypohc02)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC02");
//            entity.Property(e => e.Sypohc03)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC03");
//            entity.Property(e => e.Sypohc04)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC04");
//            entity.Property(e => e.Sypohc05)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC05");
//            entity.Property(e => e.Sypohc06)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC06");
//            entity.Property(e => e.Sypohc07)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC07");
//            entity.Property(e => e.Sypohc08)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC08");
//            entity.Property(e => e.Sypohc09)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC09");
//            entity.Property(e => e.Sypohc10)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC10");
//            entity.Property(e => e.Sypohc11)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC11");
//            entity.Property(e => e.Sypohc12)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYPOHC12");
//            entity.Property(e => e.Sypohd01)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPOHD01");
//            entity.Property(e => e.Sypohd02)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPOHD02");
//            entity.Property(e => e.Sypohp01)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP01");
//            entity.Property(e => e.Sypohp02)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP02");
//            entity.Property(e => e.Sypohp03)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP03");
//            entity.Property(e => e.Sypohp04)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP04");
//            entity.Property(e => e.Sypohp05)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP05");
//            entity.Property(e => e.Sypohp06)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP06");
//            entity.Property(e => e.Sypohp07)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP07");
//            entity.Property(e => e.Sypohp08)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP08");
//            entity.Property(e => e.Sypohp09)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP09");
//            entity.Property(e => e.Sypohp10)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP10");
//            entity.Property(e => e.Sypohp11)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP11");
//            entity.Property(e => e.Sypohp12)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP12");
//            entity.Property(e => e.Sypohp13)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SYPOHP13");
//            entity.Property(e => e.Sypohu01)
//                .HasColumnType("datetime")
//                .HasColumnName("SYPOHU01");
//            entity.Property(e => e.Sypohu02)
//                .HasColumnType("datetime")
//                .HasColumnName("SYPOHU02");
//            entity.Property(e => e.Syppdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPPDJ");
//            entity.Property(e => e.Sypran8).HasColumnName("SYPRAN8");
//            entity.Property(e => e.Syprcidln).HasColumnName("SYPRCIDLN");
//            entity.Property(e => e.Syprgp)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SYPRGP");
//            entity.Property(e => e.Syprio)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYPRIO");
//            entity.Property(e => e.Sypsdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYPSDJ");
//            entity.Property(e => e.Sypstm).HasColumnName("SYPSTM");
//            entity.Property(e => e.Syptc)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYPTC");
//            entity.Property(e => e.Syrcd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYRCD");
//            entity.Property(e => e.Syrcto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYRCTO");
//            entity.Property(e => e.Syreti)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYRETI");
//            entity.Property(e => e.Syrkco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SYRKCO");
//            entity.Property(e => e.Syrorn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SYRORN");
//            entity.Property(e => e.Syrout)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYROUT");
//            entity.Property(e => e.Syrqsj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYRQSJ");
//            entity.Property(e => e.Syrsdt).HasColumnName("SYRSDT");
//            entity.Property(e => e.Syrsht).HasColumnName("SYRSHT");
//            entity.Property(e => e.Syryin)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYRYIN");
//            entity.Property(e => e.Sysbal)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SYSBAL");
//            entity.Property(e => e.Sysdattn)
//                .HasMaxLength(50)
//                .IsFixedLength()
//                .HasColumnName("SYSDATTN");
//            entity.Property(e => e.Sysfxo)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYSFXO");
//            entity.Property(e => e.Syshan).HasColumnName("SYSHAN");
//            entity.Property(e => e.Syshccidln).HasColumnName("SYSHCCIDLN");
//            entity.Property(e => e.Sysoor)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYSOOR");
//            entity.Property(e => e.Syspattn)
//                .HasMaxLength(50)
//                .IsFixedLength()
//                .HasColumnName("SYSPATTN");
//            entity.Property(e => e.Syssdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYSSDJ");
//            entity.Property(e => e.Systop)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYSTOP");
//            entity.Property(e => e.Sytday).HasColumnName("SYTDAY");
//            entity.Property(e => e.Sytkby)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYTKBY");
//            entity.Property(e => e.Sytorg)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYTORG");
//            entity.Property(e => e.Sytotc).HasColumnName("SYTOTC");
//            entity.Property(e => e.Sytpur)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYTPUR");
//            entity.Property(e => e.Sytrdc).HasColumnName("SYTRDC");
//            entity.Property(e => e.Sytrdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYTRDJ");
//            entity.Property(e => e.Sytxa1)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYTXA1");
//            entity.Property(e => e.Sytxct)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("SYTXCT");
//            entity.Property(e => e.Syupmj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYUPMJ");
//            entity.Property(e => e.Syurab).HasColumnName("SYURAB");
//            entity.Property(e => e.Syurat).HasColumnName("SYURAT");
//            entity.Property(e => e.Syurcd)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYURCD");
//            entity.Property(e => e.Syurdt)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SYURDT");
//            entity.Property(e => e.Syurrf)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SYURRF");
//            entity.Property(e => e.Syuser)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SYUSER");
//            entity.Property(e => e.Syvr01)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SYVR01");
//            entity.Property(e => e.Syvr02)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SYVR02");
//            entity.Property(e => e.Syvr03)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SYVR03");
//            entity.Property(e => e.Syvumd)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYVUMD");
//            entity.Property(e => e.Sywumd)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SYWUMD");
//            entity.Property(e => e.Syzon)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SYZON");
//        });

//        modelBuilder.Entity<F47012>(entity =>
//        {
//            entity.HasKey(e => new { e.Szedoc, e.Szedct, e.Szekco, e.Szedln }).HasName("F47012_PK");

//            entity.ToTable("F47012");

//            entity.Property(e => e.Szedoc).HasColumnName("SZEDOC");
//            entity.Property(e => e.Szedct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZEDCT");
//            entity.Property(e => e.Szekco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZEKCO");
//            entity.Property(e => e.Szedln).HasColumnName("SZEDLN");
//            entity.Property(e => e.Szacom)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZACOM");
//            entity.Property(e => e.Szaddj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZADDJ");
//            entity.Property(e => e.Szadtm).HasColumnName("SZADTM");
//            entity.Property(e => e.Szaexp).HasColumnName("SZAEXP");
//            entity.Property(e => e.Szaft)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZAFT");
//            entity.Property(e => e.Szaid)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZAID");
//            entity.Property(e => e.Szaitm)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SZAITM");
//            entity.Property(e => e.Szan8).HasColumnName("SZAN8");
//            entity.Property(e => e.Szanby).HasColumnName("SZANBY");
//            entity.Property(e => e.Szani)
//                .HasMaxLength(29)
//                .IsFixedLength()
//                .HasColumnName("SZANI");
//            entity.Property(e => e.Szaopn).HasColumnName("SZAOPN");
//            entity.Property(e => e.Szapts)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZAPTS");
//            entity.Property(e => e.Szapum)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZAPUM");
//            entity.Property(e => e.Szasn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZASN");
//            entity.Property(e => e.Szatxt)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZATXT");
//            entity.Property(e => e.Szback)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZBACK");
//            entity.Property(e => e.Szbsc)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZBSC");
//            entity.Property(e => e.Szcadc).HasColumnName("SZCADC");
//            entity.Property(e => e.Szcars).HasColumnName("SZCARS");
//            entity.Property(e => e.Szcbsc)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZCBSC");
//            entity.Property(e => e.Szcfgfl)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZCFGFL");
//            entity.Property(e => e.Szcitm)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SZCITM");
//            entity.Property(e => e.Szclvl)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZCLVL");
//            entity.Property(e => e.Szcmcg)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZCMCG");
//            entity.Property(e => e.Szcmgl)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZCMGL");
//            entity.Property(e => e.Szcmgp)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZCMGP");
//            entity.Property(e => e.Szcndj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZCNDJ");
//            entity.Property(e => e.Szcnid)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("SZCNID");
//            entity.Property(e => e.Szco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZCO");
//            entity.Property(e => e.Szcomm)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZCOMM");
//            entity.Property(e => e.Szcot)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZCOT");
//            entity.Property(e => e.Szcpnt).HasColumnName("SZCPNT");
//            entity.Property(e => e.Szcrcd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZCRCD");
//            entity.Property(e => e.Szcrmd)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZCRMD");
//            entity.Property(e => e.Szcrr).HasColumnName("SZCRR");
//            entity.Property(e => e.Szcsto)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZCSTO");
//            entity.Property(e => e.Szctry).HasColumnName("SZCTRY");
//            entity.Property(e => e.Szdct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZDCT");
//            entity.Property(e => e.Szdcto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZDCTO");
//            entity.Property(e => e.Szdeid).HasColumnName("SZDEID");
//            entity.Property(e => e.Szdeln).HasColumnName("SZDELN");
//            entity.Property(e => e.Szdgl)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZDGL");
//            entity.Property(e => e.Szdmcs).HasColumnName("SZDMCS");
//            entity.Property(e => e.Szdmct)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SZDMCT");
//            entity.Property(e => e.Szdoc).HasColumnName("SZDOC");
//            entity.Property(e => e.Szdoco).HasColumnName("SZDOCO");
//            entity.Property(e => e.Szdrqj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZDRQJ");
//            entity.Property(e => e.Szdrqt).HasColumnName("SZDRQT");
//            entity.Property(e => e.Szdsc1)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZDSC1");
//            entity.Property(e => e.Szdsc2)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZDSC2");
//            entity.Property(e => e.Szdsft)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZDSFT");
//            entity.Property(e => e.Szdspr).HasColumnName("SZDSPR");
//            entity.Property(e => e.Szdtbs)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZDTBS");
//            entity.Property(e => e.Szdtys)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZDTYS");
//            entity.Property(e => e.Szdual)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZDUAL");
//            entity.Property(e => e.Szdvan).HasColumnName("SZDVAN");
//            entity.Property(e => e.Szecst).HasColumnName("SZECST");
//            entity.Property(e => e.Szedbt)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SZEDBT");
//            entity.Property(e => e.Szeddl).HasColumnName("SZEDDL");
//            entity.Property(e => e.Szeddt)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZEDDT");
//            entity.Property(e => e.Szeder)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZEDER");
//            entity.Property(e => e.Szedft)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZEDFT");
//            entity.Property(e => e.Szedsp)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZEDSP");
//            entity.Property(e => e.Szedsq).HasColumnName("SZEDSQ");
//            entity.Property(e => e.Szedst)
//                .HasMaxLength(6)
//                .IsFixedLength()
//                .HasColumnName("SZEDST");
//            entity.Property(e => e.Szedty)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZEDTY");
//            entity.Property(e => e.Szemcu)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SZEMCU");
//            entity.Property(e => e.Szeuse)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZEUSE");
//            entity.Property(e => e.Szexdp).HasColumnName("SZEXDP");
//            entity.Property(e => e.Szexr1)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZEXR1");
//            entity.Property(e => e.Szfapp)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZFAPP");
//            entity.Property(e => e.Szfea).HasColumnName("SZFEA");
//            entity.Property(e => e.Szfec).HasColumnName("SZFEC");
//            entity.Property(e => e.Szfprc).HasColumnName("SZFPRC");
//            entity.Property(e => e.Szfrat)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZFRAT");
//            entity.Property(e => e.Szfrgd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZFRGD");
//            entity.Property(e => e.Szfrmp).HasColumnName("SZFRMP");
//            entity.Property(e => e.Szfrtc)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZFRTC");
//            entity.Property(e => e.Szfrth)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZFRTH");
//            entity.Property(e => e.Szfuc).HasColumnName("SZFUC");
//            entity.Property(e => e.Szfuf1)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZFUF1");
//            entity.Property(e => e.Szfun2).HasColumnName("SZFUN2");
//            entity.Property(e => e.Szfup).HasColumnName("SZFUP");
//            entity.Property(e => e.Szfy).HasColumnName("SZFY");
//            entity.Property(e => e.Szgan8).HasColumnName("SZGAN8");
//            entity.Property(e => e.Szgcars).HasColumnName("SZGCARS");
//            entity.Property(e => e.Szgdvan).HasColumnName("SZGDVAN");
//            entity.Property(e => e.Szglc)
//                .HasMaxLength(4)
//                .IsFixedLength()
//                .HasColumnName("SZGLC");
//            entity.Property(e => e.Szgpa8).HasColumnName("SZGPA8");
//            entity.Property(e => e.Szgrwt).HasColumnName("SZGRWT");
//            entity.Property(e => e.Szgshan).HasColumnName("SZGSHAN");
//            entity.Property(e => e.Szgvend).HasColumnName("SZGVEND");
//            entity.Property(e => e.Szgwum)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZGWUM");
//            entity.Property(e => e.Szhold)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZHOLD");
//            entity.Property(e => e.Szinmg)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZINMG");
//            entity.Property(e => e.Szir01)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZIR01");
//            entity.Property(e => e.Szir02)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZIR02");
//            entity.Property(e => e.Szir03)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZIR03");
//            entity.Property(e => e.Szir04)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZIR04");
//            entity.Property(e => e.Szir05)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZIR05");
//            entity.Property(e => e.Szitm).HasColumnName("SZITM");
//            entity.Property(e => e.Szitvl).HasColumnName("SZITVL");
//            entity.Property(e => e.Szitwt).HasColumnName("SZITWT");
//            entity.Property(e => e.Szivd)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZIVD");
//            entity.Property(e => e.Szjbcd)
//                .HasMaxLength(6)
//                .IsFixedLength()
//                .HasColumnName("SZJBCD");
//            entity.Property(e => e.Szjobn)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZJOBN");
//            entity.Property(e => e.Szkco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZKCO");
//            entity.Property(e => e.Szkcoo)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZKCOO");
//            entity.Property(e => e.Szktln).HasColumnName("SZKTLN");
//            entity.Property(e => e.Szktp).HasColumnName("SZKTP");
//            entity.Property(e => e.Szlcod)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZLCOD");
//            entity.Property(e => e.Szlitm)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SZLITM");
//            entity.Property(e => e.Szlnid).HasColumnName("SZLNID");
//            entity.Property(e => e.Szlnty)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZLNTY");
//            entity.Property(e => e.Szlob)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZLOB");
//            entity.Property(e => e.Szlocn)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("SZLOCN");
//            entity.Property(e => e.Szlotn)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZLOTN");
//            entity.Property(e => e.Szlprc).HasColumnName("SZLPRC");
//            entity.Property(e => e.Szlt)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZLT");
//            entity.Property(e => e.Szlttr)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZLTTR");
//            entity.Property(e => e.Szmcu)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SZMCU");
//            entity.Property(e => e.Szmot)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZMOT");
//            entity.Property(e => e.Szntr)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZNTR");
//            entity.Property(e => e.Sznxtr)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZNXTR");
//            entity.Property(e => e.Szobj)
//                .HasMaxLength(6)
//                .IsFixedLength()
//                .HasColumnName("SZOBJ");
//            entity.Property(e => e.Szocto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZOCTO");
//            entity.Property(e => e.Szodct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZODCT");
//            entity.Property(e => e.Szodoc).HasColumnName("SZODOC");
//            entity.Property(e => e.Szogno).HasColumnName("SZOGNO");
//            entity.Property(e => e.Szokc)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZOKC");
//            entity.Property(e => e.Szokco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZOKCO");
//            entity.Property(e => e.Szomcu)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SZOMCU");
//            entity.Property(e => e.Szoorn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZOORN");
//            entity.Property(e => e.Szopdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZOPDJ");
//            entity.Property(e => e.Szoptt).HasColumnName("SZOPTT");
//            entity.Property(e => e.Szorp)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZORP");
//            entity.Property(e => e.Szorpr)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZORPR");
//            entity.Property(e => e.Szotqy)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZOTQY");
//            entity.Property(e => e.Szpa8).HasColumnName("SZPA8");
//            entity.Property(e => e.Szpddj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZPDDJ");
//            entity.Property(e => e.Szpdtt).HasColumnName("SZPDTT");
//            entity.Property(e => e.Szpefj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZPEFJ");
//            entity.Property(e => e.Szpid)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZPID");
//            entity.Property(e => e.Szpmdt).HasColumnName("SZPMDT");
//            entity.Property(e => e.Szpmpn)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZPMPN");
//            entity.Property(e => e.Szpmtn)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("SZPMTN");
//            entity.Property(e => e.Szpmto)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZPMTO");
//            entity.Property(e => e.Szpnid)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SZPNID");
//            entity.Property(e => e.Szpodc01)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPODC01");
//            entity.Property(e => e.Szpodc02)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPODC02");
//            entity.Property(e => e.Szpodc03)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZPODC03");
//            entity.Property(e => e.Szpodc04)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZPODC04");
//            entity.Property(e => e.Szppdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZPPDJ");
//            entity.Property(e => e.Szpqor).HasColumnName("SZPQOR");
//            entity.Property(e => e.Szprgr)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZPRGR");
//            entity.Property(e => e.Szprio)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZPRIO");
//            entity.Property(e => e.Szprjm).HasColumnName("SZPRJM");
//            entity.Property(e => e.Szprov)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZPROV");
//            entity.Property(e => e.Szprp1)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPRP1");
//            entity.Property(e => e.Szprp2)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPRP2");
//            entity.Property(e => e.Szprp3)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPRP3");
//            entity.Property(e => e.Szprp4)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPRP4");
//            entity.Property(e => e.Szprp5)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPRP5");
//            entity.Property(e => e.Szpsdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZPSDJ");
//            entity.Property(e => e.Szpsig)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZPSIG");
//            entity.Property(e => e.Szpsn).HasColumnName("SZPSN");
//            entity.Property(e => e.Szpstm).HasColumnName("SZPSTM");
//            entity.Property(e => e.Szptc)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZPTC");
//            entity.Property(e => e.Szqrlv).HasColumnName("SZQRLV");
//            entity.Property(e => e.Szqtyt).HasColumnName("SZQTYT");
//            entity.Property(e => e.Szratt)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZRATT");
//            entity.Property(e => e.Szrcd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZRCD");
//            entity.Property(e => e.Szrcto)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZRCTO");
//            entity.Property(e => e.Szresl)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZRESL");
//            entity.Property(e => e.Szrfrv)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZRFRV");
//            entity.Property(e => e.Szrkco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SZRKCO");
//            entity.Property(e => e.Szrkit).HasColumnName("SZRKIT");
//            entity.Property(e => e.Szrldj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZRLDJ");
//            entity.Property(e => e.Szrlit)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZRLIT");
//            entity.Property(e => e.Szrlln).HasColumnName("SZRLLN");
//            entity.Property(e => e.Szrlnu)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZRLNU");
//            entity.Property(e => e.Szrltm).HasColumnName("SZRLTM");
//            entity.Property(e => e.Szrorn)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZRORN");
//            entity.Property(e => e.Szrout)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZROUT");
//            entity.Property(e => e.Szrprc)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZRPRC");
//            entity.Property(e => e.Szrsdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZRSDJ");
//            entity.Property(e => e.Szryin)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZRYIN");
//            entity.Property(e => e.Szsbal)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSBAL");
//            entity.Property(e => e.Szsbl)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZSBL");
//            entity.Property(e => e.Szsblt)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSBLT");
//            entity.Property(e => e.Szsern)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("SZSERN");
//            entity.Property(e => e.Szsfxo)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSFXO");
//            entity.Property(e => e.Szshan).HasColumnName("SZSHAN");
//            entity.Property(e => e.Szshcm)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSHCM");
//            entity.Property(e => e.Szshcn)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSHCN");
//            entity.Property(e => e.Szshpn).HasColumnName("SZSHPN");
//            entity.Property(e => e.Szso01)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO01");
//            entity.Property(e => e.Szso02)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO02");
//            entity.Property(e => e.Szso03)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO03");
//            entity.Property(e => e.Szso04)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO04");
//            entity.Property(e => e.Szso05)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO05");
//            entity.Property(e => e.Szso06)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO06");
//            entity.Property(e => e.Szso07)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO07");
//            entity.Property(e => e.Szso08)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO08");
//            entity.Property(e => e.Szso09)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO09");
//            entity.Property(e => e.Szso10)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO10");
//            entity.Property(e => e.Szso11)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO11");
//            entity.Property(e => e.Szso12)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO12");
//            entity.Property(e => e.Szso13)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO13");
//            entity.Property(e => e.Szso14)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO14");
//            entity.Property(e => e.Szso15)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSO15");
//            entity.Property(e => e.Szsobk).HasColumnName("SZSOBK");
//            entity.Property(e => e.Szsocn).HasColumnName("SZSOCN");
//            entity.Property(e => e.Szsone).HasColumnName("SZSONE");
//            entity.Property(e => e.Szsoor)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZSOOR");
//            entity.Property(e => e.Szsoqs).HasColumnName("SZSOQS");
//            entity.Property(e => e.Szsqor).HasColumnName("SZSQOR");
//            entity.Property(e => e.Szsrp1)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSRP1");
//            entity.Property(e => e.Szsrp2)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSRP2");
//            entity.Property(e => e.Szsrp3)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSRP3");
//            entity.Property(e => e.Szsrp4)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSRP4");
//            entity.Property(e => e.Szsrp5)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSRP5");
//            entity.Property(e => e.Szsrqty).HasColumnName("SZSRQTY");
//            entity.Property(e => e.Szsruom)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZSRUOM");
//            entity.Property(e => e.Szstop)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZSTOP");
//            entity.Property(e => e.Szstts)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZSTTS");
//            entity.Property(e => e.Szsub)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("SZSUB");
//            entity.Property(e => e.Szswms)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZSWMS");
//            entity.Property(e => e.Sztax1)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZTAX1");
//            entity.Property(e => e.Sztcst).HasColumnName("SZTCST");
//            entity.Property(e => e.Sztday).HasColumnName("SZTDAY");
//            entity.Property(e => e.Szthgd)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZTHGD");
//            entity.Property(e => e.Szthrp).HasColumnName("SZTHRP");
//            entity.Property(e => e.Sztorg)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZTORG");
//            entity.Property(e => e.Sztpc)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZTPC");
//            entity.Property(e => e.Sztrdc).HasColumnName("SZTRDC");
//            entity.Property(e => e.Sztrdj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZTRDJ");
//            entity.Property(e => e.Sztxa1)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZTXA1");
//            entity.Property(e => e.Szuncd)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SZUNCD");
//            entity.Property(e => e.Szuncs).HasColumnName("SZUNCS");
//            entity.Property(e => e.Szuom)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUOM");
//            entity.Property(e => e.Szuom1)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUOM1");
//            entity.Property(e => e.Szuom2)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUOM2");
//            entity.Property(e => e.Szuom4)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUOM4");
//            entity.Property(e => e.Szuopn).HasColumnName("SZUOPN");
//            entity.Property(e => e.Szuorg).HasColumnName("SZUORG");
//            entity.Property(e => e.Szupc1)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUPC1");
//            entity.Property(e => e.Szupc2)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUPC2");
//            entity.Property(e => e.Szupc3)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZUPC3");
//            entity.Property(e => e.Szupmj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZUPMJ");
//            entity.Property(e => e.Szuprc).HasColumnName("SZUPRC");
//            entity.Property(e => e.Szurab).HasColumnName("SZURAB");
//            entity.Property(e => e.Szurat).HasColumnName("SZURAT");
//            entity.Property(e => e.Szurcd)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZURCD");
//            entity.Property(e => e.Szurdt)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SZURDT");
//            entity.Property(e => e.Szurrf)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("SZURRF");
//            entity.Property(e => e.Szuser)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SZUSER");
//            entity.Property(e => e.Szvend).HasColumnName("SZVEND");
//            entity.Property(e => e.Szvlum)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZVLUM");
//            entity.Property(e => e.Szvr01)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SZVR01");
//            entity.Property(e => e.Szvr02)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("SZVR02");
//            entity.Property(e => e.Szwtum)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SZWTUM");
//            entity.Property(e => e.Szzon)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("SZZON");
//        });

//        modelBuilder.Entity<F55sp002>(entity =>
//        {
//            entity.HasKey(e => new { e.Svekco, e.Svedoc, e.Svedct, e.Svedln }).HasName("F55SP002_PK");

//            entity.ToTable("F55SP002");

//            entity.Property(e => e.Svekco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SVEKCO");
//            entity.Property(e => e.Svedoc).HasColumnName("SVEDOC");
//            entity.Property(e => e.Svedct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SVEDCT");
//            entity.Property(e => e.Svedln).HasColumnName("SVEDLN");
//            entity.Property(e => e.Svdct)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("SVDCT");
//            entity.Property(e => e.Svdoco).HasColumnName("SVDOCO");
//            entity.Property(e => e.Svev01)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("SVEV01");
//            entity.Property(e => e.Svjobn)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SVJOBN");
//            entity.Property(e => e.Svkco)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("SVKCO");
//            entity.Property(e => e.Svlnid).HasColumnName("SVLNID");
//            entity.Property(e => e.Svotitmdsc)
//                .HasMaxLength(120)
//                .IsFixedLength()
//                .HasColumnName("SVOTITMDSC");
//            entity.Property(e => e.Svpid)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SVPID");
//            entity.Property(e => e.Svupmj)
//                .HasColumnType("numeric(18, 0)")
//                .HasColumnName("SVUPMJ");
//            entity.Property(e => e.Svupmt).HasColumnName("SVUPMT");
//            entity.Property(e => e.Svuser)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("SVUSER");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

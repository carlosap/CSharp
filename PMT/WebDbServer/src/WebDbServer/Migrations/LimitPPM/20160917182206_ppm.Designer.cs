using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDbServer.Model;

namespace WebDbServer.Migrations.LimitPPM
{
    [DbContext(typeof(LimitPPMContext))]
    [Migration("20160917182206_ppm")]
    partial class ppm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDbServer.Model.PPM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("Low");

                    b.Property<int>("Max");

                    b.Property<string>("Msg");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PPM");
                });
        }
    }
}

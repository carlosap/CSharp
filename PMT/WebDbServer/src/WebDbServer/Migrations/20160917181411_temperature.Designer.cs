using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDbServer.Model;

namespace WebDbServer.Migrations
{
    [DbContext(typeof(LimitTemperatureContext))]
    [Migration("20160917181411_temperature")]
    partial class temperature
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDbServer.Model.Temperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Max");

                    b.Property<string>("Msg");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Temperature");
                });
        }
    }
}

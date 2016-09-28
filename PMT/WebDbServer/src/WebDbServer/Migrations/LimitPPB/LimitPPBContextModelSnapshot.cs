using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDbServer.Model;

namespace WebDbServer.Migrations.LimitPPB
{
    [DbContext(typeof(LimitPPBContext))]
    partial class LimitPPBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDbServer.Model.PPB", b =>
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

                    b.ToTable("PPB");
                });
        }
    }
}

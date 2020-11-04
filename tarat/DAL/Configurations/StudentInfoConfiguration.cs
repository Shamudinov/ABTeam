using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class StudentInfoConfiguration : IEntityTypeConfiguration<StudentInfo>
    {
        public void Configure(EntityTypeBuilder<StudentInfo> builder)
        {
            builder.ToTable("studentInfos");
            builder.HasKey(c => c.INN);
        }
    }
}

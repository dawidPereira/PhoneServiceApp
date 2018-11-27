using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneService.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneService.Persistance
{

    //###################################
    //TODO
    //1. Set correct configuration
    //2. Test it
    //################################
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(e => e.CustomerId).HasColumnName("CustomerId");
            
        }
    }
}

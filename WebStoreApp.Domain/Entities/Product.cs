using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStoreApp.Domain.Entities.Base;
using WebStoreApp.Domain.Entities.Base.Interfaces;

namespace WebStoreApp.Domain.Entities
{
    public class Product : NamedEntity, IOrderEntity
    {



        public int Order { get; set; }

        public int SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}

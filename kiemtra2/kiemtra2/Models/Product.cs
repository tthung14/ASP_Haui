namespace kiemtra2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [RegularExpression(@"^[^a-zA-Z]*$", ErrorMessage = "Giá sản phẩm không hợp lệ")]
        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}

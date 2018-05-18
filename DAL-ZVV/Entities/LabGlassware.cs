using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAL_ZVV.Entities
{
    public class LabGlassware
    {
        [HiddenInput]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GW_ID { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Наименование обязательное поле!")]
        [Display(Name ="Наименование")]
        public string GW_Name { get; set; }

        [Display(Name = "Описание", Description ="Описание предмета")]
        public string GW_Description { get; set; }

        public string GW_Type { get; set; }

        [Required]
        [Range(typeof(decimal),"0","10000")]
        public decimal GW_Price { get; set; }

        public byte[] GW_Picture { get; set; }

        public string GW_MIMEType { get; set; }
    }
}
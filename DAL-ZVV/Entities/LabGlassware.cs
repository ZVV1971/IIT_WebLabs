using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAL_ZVV.Entities
{
    public class LabGlassware
    {
        [HiddenInput]
        [Key]
        public int GW_ID { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Наименование обязательное поле!")]
        [Display(Name ="Наименование", Description = "Наименование товара")]
        public string GW_Name { get; set; }

        [Display(Name = "Описание", Description ="Описание предмета")]
        public string GW_Description { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Указание типа обязательно!")]
        [Display(Name = "Тип", Description = "Тип товара")]
        public string GW_Type { get; set; }

        [Required(ErrorMessage ="Цена обязательное поле!")]
        [Range(typeof(decimal),"0","10000")]
        [Display(Name = "Цена", Description = "Цена за единицу товара")]
        public decimal GW_Price { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Upload)]
        public byte[] GW_Picture { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput]
        public string GW_MIMEType { get; set; }
    }
}
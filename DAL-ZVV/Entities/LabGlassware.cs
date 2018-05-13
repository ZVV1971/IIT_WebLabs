using System;

namespace DAL_ZVV.Entities
{
    public class LabGlassware
    {
        public int GW_ID { get; set; }
        public string GW_Name { get; set; }
        public string GW_Description { get; set; }
        public string GW_Type { get; set; }
        public decimal GW_Price { get; set; }
        public byte[] GW_Picture { get; set; }
        public string GW_MIMEType { get; set; }
    }
}
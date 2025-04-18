using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(OperationClassStock), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class OperationClassStock
    {
        [Display(Name = "作業類別")]
        public OperationClassEnum OperationClassNo { get; set; }

        public short StockNo { get; set; }

       

        [Display(Name = "允許出庫→")]
        public bool AllowFromThisStock { get; set; }


        [Display(Name = "→允許入庫")]
        public bool AllowToThisStock { get; set; }




        public short? OrderPriorityNo { get; set; }
     
        public bool IsDisabled { get; set; }








        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }







        [ForeignKey(nameof(StockNo))]
        public virtual Stock Stock { get; set; }









        [NotMapped]
        public bool DisallowFromStock_NewDefault { get; set; }

        [NotMapped]
        public bool DisallowToStock_NewDefault { get; set; }










        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedPerson = _userNo;
            this.CreatedDate = _createdDate ?? DateTime.Now;
        }


        public void SetStock(Stock _info)
        {
            this.StockNo = _info.StockNo;
            this.Stock = _info;
        }


        public string IsFromThisStock_GetDisplayName()
        {
            switch (OperationClassNo)
            {
                case OperationClassEnum.StockTransfer:
                    return "轉出";

                case OperationClassEnum.Sale:
                    return "銷貨";
            }

            return string.Empty;
        }

        public string IsToThisStock_GetDisplayName()
        {
            switch (OperationClassNo)
            {
                case OperationClassEnum.InboundStock:
                    return "入庫";

                case OperationClassEnum.StockTransfer:
                    return "轉入";              
            }

            return string.Empty;
        }




        public static string GetDisplayName<TProperty>(Expression<Func<OperationClassStock, TProperty>> expression)
        {
            return (new OperationClassStock()).GetDisplayName(expression);
        }
    }








    public class OperationClassStockFilter
    {
        public OperationClassStockFilter() { }

        public OperationClassStockFilter(OperationClassEnum _operationClassNo) 
        {
            OperationClassNo = _operationClassNo;
        }


        public OperationClassEnum? OperationClassNo { get; set; }

        public bool? IsDisabled_Filter { get; set; } = false;


        public OperationClassStock ToEntity()
        {
            return new OperationClassStock()
            {
                OperationClassNo = this.OperationClassNo ?? default(byte)
            };
        }
    }




}

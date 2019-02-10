using PermessInternational.Areas.Permess.StaticModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ProductionProcessC
    {
        [Key]
        public int ProcessCId { get; set; }
        public int OrderId { get; set; }
        public decimal OpeninBalance { get; set; }
        public decimal ReceivFromB { get; set; }
        public decimal GradeA { get; set; }
        public decimal GradeB { get; set; }
        public decimal GradeC { get; set; }
        public decimal GradeD { get; set; }
        public decimal Refected { get; set; }
        public decimal SenDFinal { get; set; }
        public int ThirdPartyStatus { get; set; }
        public int IsFinal { get; set; }
        public int Creator { get; set; }
        public int ConcernId { get; set; }
        public DateTime CreationDate { get; set; }
        [NotMapped]
        public IEnumerable<YesNoModel> YesNoModels { get; set; }
    }
}
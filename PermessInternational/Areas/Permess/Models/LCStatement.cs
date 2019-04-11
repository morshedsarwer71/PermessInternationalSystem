using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class LCStatement
    {
        [Key]
        public int LCStatementId { get; set; }
        public string SICode { get; set; }
        public string LCNumber { get; set; }
        public DateTime LCDate { get; set; }
        public DateTime ExpiraionDate { get; set; }
        public string RealiseValue { get; set; }
        public int LCStatus { get; set; }
        public string HSCode { get; set; }
        public string FileNo { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int Tenor { get; set; }
        public decimal Value { get; set; }
        public decimal Comission { get; set; }
        public string BankName { get; set; }
        public DateTime BankSubDate { get; set; }
        public DateTime DocumentSubDate { get; set; }
        public DateTime DocumentExpDate { get; set; }
        public string PartyName { get; set; }
        public int PaymentClause { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class ExportIssue
    {
        [Key]
        public int ExportIssueId { get; set; }
        public string FileNo { get; set; }
        public string SICode { get; set; }
        public string ExpoNumber { get; set; }
        public DateTime ExpoIssueDate { get; set; }
        public DateTime ExpoSentDate { get; set; }
        public DateTime ExpoReceivedDate { get; set; }
        public DateTime IPDate { get; set; }
        public DateTime UPDate { get; set; }
        public string PartyName { get; set; }
        public int RegionId { get; set; }
        public decimal Value { get; set; }
        public DateTime BankSubmitDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime RealizeDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public string Description { get; set; }
        public int ConcernId { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
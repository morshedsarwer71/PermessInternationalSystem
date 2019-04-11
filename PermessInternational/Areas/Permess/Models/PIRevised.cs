using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermessInternational.Areas.Permess.Models
{
    public class PIRevised
    {
        [Key]
        public int Id { get; set; }
        public string PICode { get; set; }
        public int UserId { get; set; }
        public int ConcernId { get; set; }
        public DateTime RevisedDate { get; set; }
        public string RevisedDocs { get; set; }
    }
}
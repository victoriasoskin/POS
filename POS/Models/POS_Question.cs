using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class POS_Question
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string AudioURL { get; set; }
        public int QuestionMust { get; set; }
        public int answer { get; set; }
    }
}
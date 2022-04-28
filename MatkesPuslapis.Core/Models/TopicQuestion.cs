using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core.Models
{
    public class TopicQuestion
    {
        public string TopicId { get; set; }
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
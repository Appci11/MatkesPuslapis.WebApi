using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core.Models
{
    public class Topic
    {
        public Topic()
        {
            Questions = new List<Question>();
        }

        public Topic(string title, string text, int index)
        {
            Title = title;
            Text = text;
            Index = index;
            Questions = new List<Question>();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Index {get; set;}
        public List<Question> Questions { get; set; }
}
}

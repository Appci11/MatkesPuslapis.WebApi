using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public class Question
    {
        public Question()
        {
            PossibleAnswers = new List<string>();
        }

        public Question(string topicId, string correctAnswer, string questionText)
        {
            TopicId = topicId;
            CorrectAnswer = correctAnswer;
            this.questionText = questionText;
            PossibleAnswers = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string TopicId { get; set; }
        public List<String> PossibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
        public string questionText { get; set; }
    }
}

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
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            PossibleAnswers = new List<string>();
        }

        public Question(string topicId, string id, string correctAnswer, string questionText)
        {
            Id = id;
            TopicId = topicId;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            PossibleAnswers = new List<string>();
        }

        //paprastas string, MongoDB automatiskai nekuria
        //[BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string TopicId { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<String> PossibleAnswers { get; set; }
    }
}

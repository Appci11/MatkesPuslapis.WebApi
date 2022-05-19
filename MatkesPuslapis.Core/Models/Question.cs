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

        public Question(string topicId, string correctAnswer, string questionText, string hint)
        {
            TopicId = topicId;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            PossibleAnswers = new List<string>();
        }

        public Question(string topicId, string id, string correctAnswer, string questionText, string hint)
        {
            Id = id;
            TopicId = topicId;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            PossibleAnswers = new List<string>();
            Hint = hint;
        }

        //paprastas string, MongoDB automatiskai nekuria
        //[BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string TopicId { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string Hint { get; set; }
        public List<String> PossibleAnswers { get; set; }
    }
}

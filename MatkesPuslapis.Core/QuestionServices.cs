using MatkesPuslapis.Core.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public class QuestionServices : IQuestionServices
    {
        private readonly IMongoCollection<Question> _questions;
        public QuestionServices(IDbClient dbClient)
        {
            _questions = dbClient.GetQuestionsCollection();
        }
        public Question AddQuestion(Question question)
        {
            _questions.InsertOne(question);
            return question;
        }

        public void DeleteQuestion(string id)
        {
            _questions.DeleteOne(question => question.Id == id);
        }

        public Question GetQuestion(string id) => _questions.Find(question => question.Id == id).First();

        public List<Question> GetQuestions() => _questions.Find(question => true).ToList();

        public Question UpdateQuestion(Question question)
        {
            GetQuestion(question.Id);
            _questions.ReplaceOne(q => q.Id == question.Id, question);
            return question;
        }

        public bool QuestionExists(string questionText)
        {
            bool exists = true;
            try
            {
                _questions.Find(question => question.QuestionText == questionText).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }
    }
}

using MatkesPuslapis.Core.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    internal class QuestionServices : IQuestionServices
    {
        private readonly IMongoCollection<Question> _questions;
        public QuestionServices(IDbClient dbClient)
        {
            _questions = dbClient.GetQuestionsCollection();
        }
        public Question AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(string id)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(string id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public Question UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
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

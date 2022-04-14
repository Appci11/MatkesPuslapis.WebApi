using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core.Interfaces
{
    public interface IQuestionServices
    {
        List<Question> GetQuestions();
        Question GetQuestion(string id);
        Question AddQuestion(Question question);
        void DeleteQuestion(string id);
        Question UpdateQuestion(Question question);
        bool NameExists(string name);
    }
}

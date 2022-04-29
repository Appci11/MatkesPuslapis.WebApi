using MatkesPuslapis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core.Interfaces
{
    public interface ITopicServices
    {
        List<Topic> GetTopics();
        Topic AddTopic(TopicCreation topicCreation);
        Topic GetTopic(string id);
        Topic GetTopicByIndex(int index);
        void DeleteTopic(string id);
        Topic UpdateTopic(TopicEdit topicEdit);
        bool TopicExists(string title);
        bool IndexExists(int index);
        Topic AddQuestion(TopicQuestion topicQuestion);
        Topic RemoveQuestion(TopicQuestionDelete topicQuestionDelete);
        Topic AddPossibleAnswerByText(PossibleAnswer possibleAnswer);
        string Bandymas(PossibleAnswer possibleAnswer);
    }
}

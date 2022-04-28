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
        Topic AddTopic(Topic topic);
        Topic GetTopic(string id);
        Topic GetTopicByIndex(int index);
        void DeleteTopic(string id);
        Topic UpdateTopic(Topic topic);
        bool TopicExists(string title);
    }
}

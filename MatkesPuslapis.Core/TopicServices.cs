using MatkesPuslapis.Core.Interfaces;
using MatkesPuslapis.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public class TopicServices : ITopicServices
    {
        private readonly IMongoCollection<Topic> _topics;
        public TopicServices(IDbClient dbClient)
        {
            _topics = dbClient.GetTopicsCollection();
        }

        public Topic AddTopic(TopicCreation topicCreation)
        {
            Topic topic = new Topic(topicCreation);
            _topics.InsertOne(topic);
            return topic;
        }

        public List<Topic> GetTopics() => _topics.Find(topic => true).ToList();

        public Topic GetTopic(string id) => _topics.Find(topic => topic.Id == id).First();

        public Topic GetTopicByIndex(int index) => _topics.Find(topic => topic.Index == index).First();

        public Topic UpdateTopic(TopicEdit topicEdit)
        {
            Topic topic = GetTopic(topicEdit.Id);
            topic.Title = topicEdit.Title;
            topic.Text = topicEdit.Text;
            topic.Index = topicEdit.Index;
            _topics.ReplaceOne(t => t.Id == topic.Id, topic);
            return topic;
        }

        public void DeleteTopic(string id)
        {
            _topics.DeleteOne(topic => topic.Id == id);
        }

        public bool TopicExists(string title)
        {
            bool exists = true;
            try
            {
                _topics.Find(topic => topic.Title == title).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public bool IndexExists(int index)
        {
            bool exists = true;
            try
            {
                _topics.Find(topic => topic.Index == index).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public Topic AddQuestion(TopicQuestion topicQuestion)
        {
            Topic topic = GetTopic(topicQuestion.TopicId);
            Question question = new Question(topicQuestion.TopicId, topicQuestion.QuestionId, topicQuestion.QuestionText, topicQuestion.CorrectAnswer);
            topic.Questions.Add(question);
            _topics.ReplaceOne(t => t.Id == topic.Id, topic);

            return topic;
        }

        //ties cia baigta
        public Topic RemoveQuestion(TopicQuestion topicQuestion)
        {
            throw new NotImplementedException();
        }
    }
}

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
        private readonly IMongoCollection<Topic> _stories;
        public TopicServices(IDbClient dbClient)
        {
            _stories = dbClient.GetStoriesCollection();
        }

        public Topic AddTopic(Topic story)
        {
            _stories.InsertOne(story);
            return story;
        }

        public void DeleteTopic(string id)
        {
            _stories.DeleteOne(story => story.Id == id);
        }

        public List<Topic> GetTopics() => _stories.Find(story => true).ToList();

        public Topic GetTopic(string id) => _stories.Find(story => story.Id == id).First();

        public Topic GetTopicByIndex(string name) => _stories.Find(story => story.Title == name).First();

        public bool TopicExists(string name)
        {
            bool exists = true;
            try
            {
                _stories.Find(story => story.Title == name).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public Topic UpdateTopic(Topic story)
        {
            GetTopic(story.Id);
            _stories.ReplaceOne(t => t.Id == story.Id, story);
            return story;
        }
    }
}

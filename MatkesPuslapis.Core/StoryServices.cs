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
    public class StoryServices : IStoryServices
    {
        private readonly IMongoCollection<Story> _stories;

        public StoryServices(IMongoCollection<Story> stories)
        {
            _stories = stories;
        }

        public Story AddStory(Story story)
        {
            _stories.InsertOne(story);
            return story;
        }

        public void DeleteStory(string id)
        {
            _stories.DeleteOne(story => story.Id == id);
        }

        public List<Story> GetStories() => _stories.Find(story => true).ToList();

        public Story GetStory(string id) => _stories.Find(story => story.Id == id).First();

        public bool NameExists(string name)
        {
            bool exists = true;
            try
            {
                _stories.Find(story => story.Name == name).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public Story UpdateStory(Story story)
        {
            GetStory(story.Id);
            _stories.ReplaceOne(t => t.Id == story.Id, story);
            return story;
        }
    }
}

using MatkesPuslapis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core.Interfaces
{
    public interface IStoryServices
    {
        List<Story> GetStories();
        Story AddStory(Story story);
        Story GetStory(string id);
        Story GetStoryByName(string id);
        void DeleteStory(string id);
        Story UpdateStory(Story story);
        bool NameExists(string name);
    }
}

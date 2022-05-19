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

        public Topic AddTopic(Topic topic)
        {
            //Topic topic = new Topic(topicCreation);   //nebereikia, topic turetu tiesiai keliaut be pakeitumu
            _topics.InsertOne(topic);
            return topic;
        }

        public List<Topic> GetTopics() => _topics.Find(topic => true).ToList();

        public Topic GetTopic(string id) => _topics.Find(topic => topic.Id == id).First();

        //public Topic GetTopicByIndex(int index) => _topics.Find(topic => topic.Index == index).First();

        public Topic UpdateTopic(Topic topic)
        {
            GetTopic(topic.Id);
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

        //public bool IndexExists(int index)
        //{
        //    bool exists = true;
        //    try
        //    {
        //        _topics.Find(topic => topic.Index == index).First();
        //    }
        //    catch (Exception ex)
        //    {
        //        exists = false;
        //    }
        //    return exists;
        //}

        //public Topic AddQuestion(TopicQuestion topicQuestion)
        //{
        //    Topic topic = GetTopic(topicQuestion.TopicId);
        //    int max = 0;
        //    string qId = "";        //question ID
        //    foreach (var element in topic.Questions)
        //    {
        //        try
        //        {
        //            int sk = Int32.Parse(element.Id);
        //            if (sk >= max)
        //                max = sk;
        //        }
        //        catch(Exception ex)
        //        {
        //            max = topic.Questions.Count;
        //        }
        //    }

        //    if (topic.Questions.Count > 0)
        //    {
        //        max++;
        //    }
        //    qId = max.ToString();
        //    Question question = new Question(topicQuestion.TopicId, qId, topicQuestion.CorrectAnswer, topicQuestion.QuestionText, topicQuestion.Hint);
        //    topic.Questions.Add(question);
        //    _topics.ReplaceOne(t => t.Id == topic.Id, topic);

        //    return topic;
        //}

        //public Topic RemoveQuestion(TopicQuestionDelete topicQuestionDelete)
        //{
        //    Topic topic = GetTopic(topicQuestionDelete.TopicId);
        //    bool exists = false;
        //    int i = -1;
        //    foreach (var element in topic.Questions)
        //    {
        //        i++;
        //        if (string.Compare(element.Id, topicQuestionDelete.QuestionId) == 0)
        //        {
        //            exists = true;
        //            break;
        //        }
        //    }
        //    //jei egzistuoja grazins Code 200, jei ne 204
        //    if (exists)
        //    {
        //        topic.Questions.RemoveAt(i);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //    _topics.ReplaceOne(t => t.Id == topic.Id, topic);
        //    return topic;
        //}

        //public Topic AddPossibleAnswerByText(PossibleAnswer possibleAnswer)
        //{
        //    Topic topic = GetTopic(possibleAnswer.TopicId);
        //    bool exists = false;
        //    foreach (var klausimas in topic.Questions)
        //    {
        //        if (string.Compare(klausimas.Id, possibleAnswer.QuestionId) == 0)
        //        {
        //            foreach (var elementas in klausimas.PossibleAnswers)
        //            {
        //                if (string.Compare(elementas, possibleAnswer.Text) == 0)
        //                {
        //                    exists = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (exists)
        //    {
        //        return null;
        //    }
        //    int questionId = int.Parse(possibleAnswer.QuestionId);
        //    topic.Questions[questionId].PossibleAnswers.Add(possibleAnswer.Text);
        //    _topics.ReplaceOne(t => t.Id == topic.Id, topic);

        //    return topic;
        //}

        //public Topic RemovePossibleAnswerByText(PossibleAnswer possibleAnswer)
        //{
        //    Topic topic = GetTopic(possibleAnswer.TopicId);
        //    bool exists = false;
        //    int i = -1;
        //    foreach (var klausimas in topic.Questions)
        //    {
        //        if (string.Compare(klausimas.Id, possibleAnswer.QuestionId) == 0)
        //        {
        //            foreach (var elementas in klausimas.PossibleAnswers)
        //            {
        //                i++;
        //                if (string.Compare(elementas, possibleAnswer.Text) == 0)
        //                {
        //                    exists = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (!exists)
        //    {
        //        return null;
        //    }
        //    int questionId = int.Parse(possibleAnswer.QuestionId);
        //    topic.Questions[questionId].PossibleAnswers.RemoveAt(i);
        //    _topics.ReplaceOne(t => t.Id == topic.Id, topic);
        //    return topic;
        //}

        //public string Bandymas(PossibleAnswer possibleAnswer)
        //{
        //    Topic topic = GetTopic(possibleAnswer.TopicId);
        //    bool exists = false;
        //    foreach (var klausimas in topic.Questions)
        //    {
        //        foreach (var elementas in klausimas.PossibleAnswers)
        //        {
        //            if (string.Compare(elementas, possibleAnswer.Text) == 0)
        //            {
        //                exists = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (exists)
        //    {
        //        return "Possible answers already exists";
        //    }
        //    int questionId = int.Parse(possibleAnswer.QuestionId);
        //    topic.Questions[questionId].PossibleAnswers.Add(possibleAnswer.Text);

        //    return "possible answer added";
        //}
    }
}

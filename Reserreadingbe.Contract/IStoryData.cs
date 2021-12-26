using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using reserreadingbe.Common;

namespace Reserreadingbe.Contract
{
    public interface IStoryData
    {
        Task<Story> InsertStories(Story story);
        Task<List<Story>> SelectAll();
        Task<Story> SelectStory(string storyId);
    }
}
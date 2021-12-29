using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using reserreadingbe.Common;
using Reserreadingbe.Contract;

namespace reserreadingbe.Logic
{
    public class StoryLogic
    {
        private IStoryData _sDal;

        public StoryLogic()
        {
        }
        public StoryLogic(IStoryData sData)
        {
            _sDal = sData;
        }
        
        
        public async Task<List<Story>> GetAll ()
        { 
            return await _sDal.SelectAll();;
        }
        
        public async Task<Story> NewStory(Story story)
        {
            if (story.Filepath != null)
            {
                await _sDal.InsertStory(story);
                return story;
            }
            else
            {
                return new Story();
            }
        }
        
        public async Task<Story> GetStory(string storyId)
        {
            return await _sDal.SelectStory(storyId);
        }
    }
}
using System;
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
        
        
    }
}
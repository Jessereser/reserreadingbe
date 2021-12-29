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
        
    }
}
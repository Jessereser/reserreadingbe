using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using reserreadingbe.Common;
using Reserreadingbe.Contract;

namespace reserreadingbe.Data
{
    public class StoryData : IStoryData
    {
        private readonly ReserreadingbeContext _context;
        public StoryData(ReserreadingbeContext context)
        {
            _context = context;
        }
        
        public async Task<Story> InsertStory(Story story)
        {
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<List<Story>> SelectAll()
        {
            List<Story> stories = await _context.Stories.ToListAsync();
            return stories;
        }
        
        public async Task<Story> SelectStory(string storyId)
        {
            Story account = await _context.Stories.FirstOrDefaultAsync(x => x.Id == storyId);
            return account;
        }
        
    }
}
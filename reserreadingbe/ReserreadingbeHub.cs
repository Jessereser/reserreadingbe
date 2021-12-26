using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using reserreadingbe.Common;
using reserreadingbe.Data;
using reserreadingbe.Logic;

namespace reserreadingbe
{
    public class ReserreadingbeHub
    {
        private StoryLogic _bookLogic;

        public ReserreadingbeHub(ReserreadingbeContext context)
        {
            _context = new StoryLogic(new StoryData(context));
        }

        public async Task<> CreateBook;
    }
}
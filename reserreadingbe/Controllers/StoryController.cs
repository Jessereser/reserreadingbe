using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reserreadingbe.Common;
using reserreadingbe.Data;
using reserreadingbe.Logic;

namespace reserreadingbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly StoryLogic _aLogic;

        public StoryController(ReserreadingbeContext context)
        {
            _aLogic = new StoryLogic(new StoryData(context));
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<Story>>> GetStories()
        {
            return await _aLogic.GetAll();
        }

      
        [HttpPost]
        public async Task<ActionResult<Story>> AddStory(Story story)
        {
            //story = await _aLogic.
            return BadRequest();
        }

        
    }
}

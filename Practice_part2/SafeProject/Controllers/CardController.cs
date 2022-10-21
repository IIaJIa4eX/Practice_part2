using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeProject.Models;
using SafeProject.Services.Interfaces;

namespace SafeProject.Controllers
{
    //for_review
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        
        private readonly ICardRepositoryService _cardRepositoryService;
        private readonly IConfiguration _config;

        public CardController(ICardRepositoryService cardRepositoryService, IConfiguration config)
        {
            _cardRepositoryService = cardRepositoryService;
            _config = config;
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var card = _cardRepositoryService.GetById(id);
            if (card != null)
            {
                return Ok(new CommonCardResponse()
                {
                    CardId = card.CardId,
                    Message = "Success",
                    ErrorCode = 201
                });
            }
            return NotFound(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 404
            });
        }

        [HttpPost("createcard")]
        public IActionResult Create(CreateCardRequest card)
        {
            int res = _cardRepositoryService.Create(card);
            if (res > 0)
            {
                return Ok(new CommonCardResponse()
                {
                    CardId = card.CardId,
                    Message = "Success",
                    ErrorCode = 201
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 401
            });
        }

        [HttpPost("updatecard")]
        public IActionResult Update(UpdateCardRequest card)
        {
            int res = _cardRepositoryService.Update(card);
            if (res > 0)
            {
                return Ok(new CommonCardResponse()
                {
                    CardId = card.CardId,
                    Message = "Success",
                    ErrorCode = 201
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 401
            });
        }

        [HttpPost("deletecard")]
        public IActionResult Delete(int id)
        {
            int res = _cardRepositoryService.Delete(id);
            if (res > 0)
            {
                return Ok(new CommonCardResponse()
                {
                    CardId = id,
                    Message = "Success",
                    ErrorCode = 201
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 401
            });
        }


    }
}

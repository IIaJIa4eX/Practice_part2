using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeProject.Models;
using SafeProject.Services.Interfaces;

namespace SafeProject.Controllers
{
    //for_review
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepositoryService _cardRepositoryService;

        public CardController(ILogger<CardController> logger, ICardRepositoryService cardRepositoryService)
        {
            _cardRepositoryService = cardRepositoryService;
            _logger = logger;
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
                    ErrorCode = 0
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 1
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
                    ErrorCode = 0
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 1
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
                    ErrorCode = 0
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 1
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
                    ErrorCode = 0
                });
            }
            return Ok(new CommonCardResponse()
            {
                CardId = -1,
                Message = "Error",
                ErrorCode = 1
            });
        }


    }
}

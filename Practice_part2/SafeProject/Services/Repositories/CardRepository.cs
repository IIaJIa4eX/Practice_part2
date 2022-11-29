using SafeProject.Models;
using SafeProject.Services.Interfaces;
using SafeProjectDBLib;
using SafeProjectDBLib.Entities;

namespace SafeProject.Services.Repositories
{
    //for_review
    public class CardRepository : ICardRepositoryService
    {

        private readonly CardStorageDbConnection _context;

        public CardRepository(CardStorageDbConnection context)
        {
            _context = context;
        }

        public int Create(CreateCardRequest data)
        {
            Card newCard = new() {
                ClientId = data.ClientId,
                CVV2 = data.CVV2,
                ExpDate = data.ExpDate,
                OwnerName = data.OwnerName,
                CardNumber = data.CardNumber          
            };

            _context.Cards.Add(newCard);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Card card = _context.Cards
                .Where(card => card.CardId == id)
                .FirstOrDefault();
            if (card == null)
            {
                return 0;
            }
            _context.Cards.Remove(card);
            return _context.SaveChanges();
        }

        public IList<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public Card GetById(int id)
        {
            Card card = _context.Cards
                .Where(card => card.CardId == id)
                .FirstOrDefault();
            if(card == null)
            {
                return null;
            }
            return card;
        }

        public int Update(UpdateCardRequest data)
        {
            if (data.CardId != -1)
            {
                var card = _context.Cards
                    .Where(card => card.CardId == data.CardId)
                    .FirstOrDefault();
                if (card != null)
                {
                    card.CardNumber = data.CardNumber;
                    card.CVV2 = data.CVV2;
                    card.ExpDate = data.ExpDate;
                }
                return _context.SaveChanges();
            }

            return 0;
        }
    }
}

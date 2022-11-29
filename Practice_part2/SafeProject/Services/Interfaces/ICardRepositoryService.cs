using SafeProject.Models;
using SafeProjectDBLib.Entities;
using System.Security.Cryptography;

namespace SafeProject.Services.Interfaces
{
    //for_review
    public interface ICardRepositoryService
    {

        Card GetById(int id);

        int Create(CreateCardRequest data);

        int Update(UpdateCardRequest data);

        int Delete(int id);
    }
}

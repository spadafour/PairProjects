using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICatCardDAO cardDAO;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CardsController(ICatCardDAO _cardDAO, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDAO = _cardDAO;
        }

        [HttpGet("random")]
        public ActionResult<CatCard> GetRandomCard()
        {
            CatFact catFact = new CatFact();
            CatPic catPic = new CatPic();

            try
            {
                catFact = catFactService.GetFact();
                catPic = catPicService.GetPic();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            CatCard currentCard = new CatCard(catFact, catPic);

            return currentCard;
        }

        [HttpPost]
        public ActionResult<CatCard> SaveCard(CatCard currentCard)
        {
            try
            {
                CatCard savedCard = new CatCard();
                savedCard = cardDAO.SaveCard(currentCard);
                if (savedCard == null)
                {
                    return StatusCode(500);
                }
                else
                {
                    return savedCard;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<List<CatCard>> GetCards()
        {
            try
            {
                return cardDAO.GetAllCards();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CatCard> GetCardByID(int id)
        {
            try
            {
                return cardDAO.GetCard(id);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateCard(int id, CatCard cardToUpdate)
        {
            try
            {
                if (id == cardToUpdate.CatCardId && cardDAO.GetCard(id) != null)
                {
                    if (cardDAO.UpdateCard(cardToUpdate))
                    {
                        return cardToUpdate;
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCardById(int id)
        {
            try
            {
                if (cardDAO.GetCard(id) != null)
                {
                    bool isDeleted = cardDAO.RemoveCard(id);
                    if (isDeleted)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public ActionResult DeleteCard(CatCard cardToDelete)
        {
            try
            {
                if (cardDAO.GetCard(cardToDelete.CatCardId) != null)
                {
                    bool isDeleted = cardDAO.RemoveCard(cardToDelete.CatCardId);
                    if (isDeleted)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

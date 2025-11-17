using Business.Interfaces;
using DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace DnDCharacterSheet.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CharacterController : ControllerBase
    {
        private ICharacterProvider _characterProvider { get; set; }

        public CharacterController(ICharacterProvider characterProvider)
        {
            _characterProvider = characterProvider;
        }

        [HttpGet]
        public ActionResult<Character> GetCharacter(int id)
        {
            return _characterProvider.GetCharacter(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DnDCharacterSheet.Controllers
{
    [ApiController]
    [Route("heart-beat")]
    public class AmIAliveController : ControllerBase
    {
        private static readonly string HeartBeat =
        "Whether you're a brother or whether you're a mother\r\nYou're stayin' alive, stayin' alive\r\nFeel the city breakin' and everybody shakin'\r\nAnd we're stayin' alive, stayin' alive\r\nAh, ha, ha, ha, stayin' alive, stayin' alive\r\nAh, ha, ha, ha, stayin' alive";

        [HttpGet]
        public string GetHeartBeat()
        {
            return HeartBeat;
        }
    }
}

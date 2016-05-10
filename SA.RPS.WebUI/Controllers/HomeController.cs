using System.Collections.Generic;
using System.Web.Mvc;
using SA.RPS.Library.Extensions;
using SA.RPS.Service.Enums;
using SA.RPS.Service.Interface;
using SA.RPS.Service.Service;
using SA.RPS.WebUI.ViewModels;

namespace SA.RPS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        private static int _numberOfTurns = 0;
        private static int _playerScore = 0;
        private static int _opponentScore = 0;

        public HomeController()
        {
            _gameService = new GameService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Play(string game)
        {
            var model = new GamePlayViewModel();
            if (Session["Computer"] == null)
            {
                Session["Computer"] = _gameService.Play();
            }

            model.OpponentGame = GetGameValueForPlayer("Computer", _numberOfTurns);
            model.PlayerGame = game;

            Setup(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Simulate()
        {
            var model = new GamePlayViewModel();

            if (Session["Computer1"] == null & Session["Computer2"] == null)
            {
                Session["Computer1"] = _gameService.Play();
                Session["Computer2"] = _gameService.Play();
            }

            model.OpponentGame = GetGameValueForPlayer("Computer2", _numberOfTurns);
            model.PlayerGame = GetGameValueForPlayer("Computer1", _numberOfTurns);

            Setup(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Ran out of time would have separated these helper methods into separate classes to follow the solid principles
        #region Helper Methods

        private void Setup(GamePlayViewModel model)
        {
            if (_numberOfTurns <= 3)
            {
                CalculateScore(model.PlayerGame, model.OpponentGame);
                model.OpponentScore = _opponentScore;
                model.PlayerScore = _playerScore;
                model.Result = GetResult(model.PlayerGame, model.OpponentGame);
                _numberOfTurns++;
            }
            else
            {
                _numberOfTurns = 0;
                _playerScore = 0;
                _opponentScore = 0;
                Session.Clear();
                model.CanPlayAgain = true;
            }
        }

        private string GetGameValueForPlayer(string key, int rounds = 0)
        {
            var gamelist = (List<string>)Session[key];

            if (rounds >= 3) return gamelist[2];

            return gamelist[rounds];
        }

        private string GetResult(string playerGame, string opponentGame)
        {
            if (_gameService.IsWinner(EnumConverter<GameCodeEnum>.StringToEnum(playerGame),
               EnumConverter<GameCodeEnum>.StringToEnum(opponentGame)))
            {
                return string.Format("Winner is Player {0}", 1);
            }

            if (_gameService.IsWinner(EnumConverter<GameCodeEnum>.StringToEnum(opponentGame),
                EnumConverter<GameCodeEnum>.StringToEnum(playerGame)))
            {
                return string.Format("Winner is Player {0}", 2);
            }
            return string.Empty;
        }

        private void CalculateScore(string playerGame, string opponentGame)
        {
            if (_gameService.IsWinner(EnumConverter<GameCodeEnum>.StringToEnum(playerGame),
                EnumConverter<GameCodeEnum>.StringToEnum(opponentGame)))
            {
                _playerScore++;
            }

            if (_gameService.IsWinner(EnumConverter<GameCodeEnum>.StringToEnum(opponentGame),
                EnumConverter<GameCodeEnum>.StringToEnum(playerGame)))
            {
                _opponentScore++;
            }
        }
        #endregion
    }
}
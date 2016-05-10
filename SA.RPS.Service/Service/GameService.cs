using System;
using System.Collections.Generic;
using System.Linq;
using SA.RPS.Library.Extensions;
using SA.RPS.Service.Enums;
using SA.RPS.Service.Interface;

namespace SA.RPS.Service.Service
{
    public class GameService : IGameService
    {
        public List<string> Play()
        {
            var game = GetGame();
            game.Random(5);
            return game;
        }

        public bool IsWinner(GameCodeEnum player, GameCodeEnum opponent)
        {

            switch (player)
            {
                case GameCodeEnum.Paper:
                    return opponent == GameCodeEnum.Rock;
                case GameCodeEnum.Rock:
                    return opponent == GameCodeEnum.Sissors;
                case GameCodeEnum.Sissors:
                    return opponent == GameCodeEnum.Paper;
            }
            return false;
        }

        private List<string> GetGame()
        {
            return (from object game in Enum.GetValues(typeof(GameCodeEnum)) select (string)game.ToString()).ToList();
        }
    }
}

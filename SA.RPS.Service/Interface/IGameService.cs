using System.Collections.Generic;
using SA.RPS.Service.Enums;

namespace SA.RPS.Service.Interface
{
    public interface IGameService
    {
        List<string> Play();
        bool IsWinner(GameCodeEnum player, GameCodeEnum opponent);
    }
}

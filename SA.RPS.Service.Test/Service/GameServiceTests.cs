using NUnit.Framework;
using SA.RPS.Service.Enums;
using SA.RPS.Service.Service;

namespace SA.RPS.Service.Test.Service
{
    public class GameServiceTests
    {
        private GameService _gameService;

        [SetUp]
        public void Arrange()
        {
            _gameService = new GameService();
        }

        [Test]
        public void When_I_Call_Play_Should_Return_Game_Play_For_A_Player()
        {
            var result = _gameService.Play();

            Assert.NotNull(result);
            Assert.True(result.Count == 3);
        }

        [Test]
        public void When_I_Call_Play_Should_Return_Mix_Game_Result_For_A_Player()
        {
            var player1 = _gameService.Play();
            var player2 = _gameService.Play();

            CollectionAssert.AreNotEqual(player1, player2);
        }

        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Sissors_And_Opponent_As_Paper_Should_Return_True()
        {
            var player = GameCodeEnum.Sissors;
            var opponent = GameCodeEnum.Paper;
            var result = _gameService.IsWinner(player, opponent);

            Assert.True(result);
        }

        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Paper_And_Opponent_As_Rock_Should_Return_True()
        {
            var player = GameCodeEnum.Paper;
            var opponent = GameCodeEnum.Rock;
            var result = _gameService.IsWinner(player, opponent);

            Assert.True(result);
        }


        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Rock_And_Opponent_As_Sissors_Should_Return_True()
        {
            var player = GameCodeEnum.Rock;
            var opponent = GameCodeEnum.Sissors;
            var result = _gameService.IsWinner(player, opponent);

            Assert.True(result);
        }

        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Paper_And_Opponent_As_Sissors_Should_Return_False()
        {
            var player = GameCodeEnum.Paper;
            var opponent = GameCodeEnum.Sissors;
            var result = _gameService.IsWinner(player, opponent);

            Assert.False(result);
        }

        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Rock_And_Opponent_As_Papar_Should_Return_False()
        {
            var player = GameCodeEnum.Rock;
            var opponent = GameCodeEnum.Paper;
            var result = _gameService.IsWinner(player, opponent);

            Assert.False(result);
        }

        [Test]
        public void When_I_Call_IsWinner_Should_With_Player_As_Paper_And_Opponent_As_Sissor_Should_Return_True()
        {
            var player = GameCodeEnum.Paper;
            var opponent = GameCodeEnum.Sissors;
            var result = _gameService.IsWinner(player, opponent);

            Assert.False(result);
        }
    }
}

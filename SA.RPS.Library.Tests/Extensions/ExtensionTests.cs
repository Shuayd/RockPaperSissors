using System.Collections.Generic;
using NUnit.Framework;
using SA.RPS.Library.Extensions;

namespace SA.RPS.Library.Tests.Extensions
{
    public class ExtensionTests
    {
        [Test]
        public void When_I_Call_Random_Should_Ramdom_A_Game_With_Mixed_Values()
        {
            var game = GetGame();

            game.Random();

            CollectionAssert.AreNotEqual(GetGame(), game);
        }

        public List<string> GetGame()
        {
            return new List<string>()
            {
                "Rock",
                "Paper",
                "Sissors"
            };
        }
    }
}


using System;

namespace WordleClone
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var game = new GameLoop("abba");
            game.Start();
            game.Play();

        }
    }
}
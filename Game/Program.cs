using System;

namespace Game
{
    internal class Program
    {
        private const int ScreenWidth = 100;
        private const int ScreenHeight = 50;

        private static readonly char[] Screen = new char[ScreenWidth * ScreenHeight];

        static void Main(string[] args)
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);
            Console.CursorVisible = false;


            while (true)
            {

                Console.SetCursorPosition(0, 0);
                Console.Write(Screen);
            }

        }
    }
}
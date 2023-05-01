using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame 
{
    public static class TimeManager
    {
        static int fps = 0;
        static Clock fpsClock;
        static Time fpsTime;
        static Text fpsTxt;
        static Clock deltaClock = new Clock();
        public static float deltaTime { get; private set; } = 0;

        public static void Awake()
        {
            fpsClock = new Clock();
            fpsTime = fpsClock.Restart();
        }

        public static void Update(RenderWindow window)
        {
            deltaTime = deltaClock.Restart().AsSeconds();

            fps++;

            if (fpsClock.ElapsedTime.AsSeconds() > 1)
            {
                fpsTime = fpsClock.Restart();
                window.SetTitle("SFML Window FPS : " + fps);
                fps = 0;
            }
        }
    }
}

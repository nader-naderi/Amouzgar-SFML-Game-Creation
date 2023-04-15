﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System;

namespace MyFirstSFMLGame
{
    public class Game
    {
        // Modular
        // Manage

        RenderWindow window;
        int fps = 0;
        Clock fpsClock;
        Time fpsTime;
        Text fpsTxt;
        Font font;

        public static Game Instance;

        public List<GameObejct> gameObjects = new List<GameObejct>();

        public Game()
        {
            // C++ Bind to C# 
            
            window = new RenderWindow(new VideoMode(800, 600), "Our Great Game");
            ResourceManager.Window = window;

            window.SetVerticalSyncEnabled(true);
            ResourceManager.LoadAssets();
            
            fpsClock = new Clock();
            fpsTime = fpsClock.Restart();

            font = new Font(Directory.GetCurrentDirectory() +
                "/Assets/Textures/SpaceShooterRedux/Bonus/kenvector_future.ttf");
            gameObjects.Add(new GameObejct(ResourceManager.BackGroundTexture));
            
            gameObjects.Add(new Player(ResourceManager.PlayerTexture));
            gameObjects.Add(new Enemy(ResourceManager.EnemyTexture));

            foreach (GameObejct gameObejct in gameObjects)
            {
                gameObejct.Awake();
                gameObejct.Start();
            }
        }
        public void Run()
        {
            // GameLoop
            while (window.IsOpen)
            {
                // Handle Events
                window.DispatchEvents();

                // Update.
                Update();

                // Collision Detection
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    for (int j = 0; j < gameObjects.Count; j++)
                    {
                        if (gameObjects[i].CheckCollision(gameObjects[j]))
                            gameObjects[i].OnCollisionEnter(gameObjects[j]);
                        else
                            gameObjects[i].OnCollisionExit(gameObjects[j]);
                    }
                }

                window.Clear();

                // Draw
                Draw();

                window.Display();
            }
        }

        private void Draw()
        {
            foreach (GameObejct gameObejct in gameObjects)
                window.Draw(gameObejct);
        }

        private void Update()
        {
            fps++;

            if (fpsClock.ElapsedTime.AsSeconds() > 1)
            {
                fpsTime = fpsClock.Restart();
                window.SetTitle("SFML Window FPS : " + fps);
                fps = 0;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                window.Close();

            foreach (GameObejct gameObject in gameObjects)
                gameObject.Update();
        }

        public void AddGameObejct(GameObejct target)
        {
            gameObjects.Add(target);
        }

        public void RemoveGameObejct(GameObejct target)
        {
            gameObjects.Remove(target);
        }

    }
}
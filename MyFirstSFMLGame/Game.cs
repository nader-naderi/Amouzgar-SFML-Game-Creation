using SFML.Graphics;
using SFML.Window;

using System;

namespace MyFirstSFMLGame
{
    public class Game
    {
        // Component 
        RenderWindow window;
        Font font;

        public static Game Instance;
        
        /// <summary>
        /// Engine Constructor
        /// </summary>
        public Game()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Our Great Game");
            ResourceManager.Window = window;
            window.SetVerticalSyncEnabled(true);

            ResourceManager.LoadAssets();

            TimeManager.Awake();

            font = new Font(Directory.GetCurrentDirectory() +
                "/Assets/Textures/SpaceShooterRedux/Bonus/kenvector_future.ttf");

            Scene scene = new Scene("New Scene");
            SceneManager.AddScene(scene);


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

                PhysicsManager.Update();

                window.Clear();

                // Draw
                Draw();

                window.Display();
                //Console.Clear();
            }
        }

        private void Draw()
        {
            window.Draw(SceneManager.CurrentScene);
        }

        private void Update()
        {
            TimeManager.Update(window);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                window.Close();

            SceneManager.CurrentScene.Update();
        }
    }

    // Componenets: DataType
        // Rigidbody
        // AudioPlayer
        // SpriteRenderer
        // Collider

    // Generics
        

    public abstract class Component
    {
        public GameObejct gameObejct { get; set; }
        public abstract void Update(float deltaTime);
    }



    public class SpriteRenderer : Component
    {
        public override void Update(float deltaTime)
        {
        }
    }

    public class AudioPlayer : Component
    {
        public override void Update(float deltaTime)
        {

        }
    }
}

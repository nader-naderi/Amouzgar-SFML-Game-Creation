using SFML.Graphics;
using SFML.System;
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
            // C++ Bind to C# 
            
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
                Console.Clear();
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

    public static class PhysicsManager
    {
        private static List<GameObejct> gameObejcts = new List<GameObejct>();   

        public static void AddGameObject()
        {

        }

        public static void RemoveGameObject()
        {

        }

        public static void Update()
        {
            CollisionDetection();
        }

        private static void CollisionDetection()
        {
            for (int i = 0; i < gameObejcts.Count; i++)
            {
                for (int j = 0; j < gameObejcts.Count; j++)
                {
                    GameObejct objectA = gameObejcts[i];
                    GameObejct objectB = gameObejcts[j];

                    if (objectA.CheckCollision(objectB))
                    {
                        objectA.OnCollisionEnter(objectB);
                        objectB.OnCollisionEnter(objectA);
                    }
                    else
                    {
                        objectA.OnCollisionExit(objectB);
                        objectB.OnCollisionExit(objectA);
                    }
                }
            }
        }

        public static void ApplyPhysics(List<Rigidbody> rigidbodies, float deltaTime)
        {
            foreach (Rigidbody body in rigidbodies)
            {
                // Apply Gravity
                body.ApplyForce(new Vector2f(0, body.Gravity) * deltaTime);

                // Apply Velocity
                body.gameObejct.Position += body.Velocity * deltaTime;

                // Apply Firiction
                float firiction = body.Friction * deltaTime;

                if (body.Velocity.X > 0)
                    body.Velocity -= new Vector2f(Math.Min(body.Velocity.X, firiction), 0);
                else if (body.Velocity.X < 0)
                    body.Velocity += new Vector2f(Math.Min(-body.Velocity.X, firiction), 0);
            }
        }
    }

    public interface IPhysical
    {
        /// <summary>
        /// جاذبه
        /// </summary>
        float Gravity { get; set; } 
        /// <summary>
        /// اصطکاک
        /// </summary>
        float Friction { get; set; }
        /// <summary>
        /// تکانه
        /// </summary>
        Vector2f Velocity { get; set; } 
    }

    public class Rigidbody : IPhysical
    {
        public GameObejct gameObejct;
        public float Gravity { get; set; }
        public float Friction { get; set; }
        public Vector2f Velocity { get; set; }

        public void ApplyForce(Vector2f force)
        {
            Velocity += force;
        }
    }
}

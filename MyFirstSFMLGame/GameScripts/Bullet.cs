using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class Bullet : GameObejct
    {
        float bulletSpeed = 10;

        public Bullet(Texture texture) : base(texture)
        {
            Tag = "Bullet";
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            HandleMovement();
            HandleDeath();
        }

        private void HandleDeath()
        {
            if (Position.X < 0 || Position.X > ResourceManager.Window.Size.X ||
                            Position.Y < 0 || Position.Y > ResourceManager.Window.Size.Y)
            {
                // RemoveAt(i);
                // Remove the bullet.
                OnDestroy();
            }
        }

        private void HandleMovement()
        {
            Position -= new Vector2f(0, bulletSpeed);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}

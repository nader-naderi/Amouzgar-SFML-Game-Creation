
using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class Bullet : GameObejct
    {
        float bulletSpeed = 10;
        Rigidbody rb = new Rigidbody();

        public SpriteRenderer SpriteRenderer { get; private set; }

        public Bullet(Texture texture) : base()
        {
            Tag = "Bullet";

            SpriteRenderer = new SpriteRenderer(texture);

            AddComponent(rb, new AudioPlayer(), SpriteRenderer);
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

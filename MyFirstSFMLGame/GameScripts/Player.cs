using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System.Numerics;

namespace MyFirstSFMLGame
{
    public class Player : GameObejct
    {
        float speed = 2;

        public Player(Texture texture) : base(texture)
        {
            Tag = "Player";

        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            Position = new Vector2f(800 / 2, 600 / 2);
            Sprite.Origin = new Vector2f(Sprite.TextureRect.Width / 2, Sprite.TextureRect.Height / 2);
        }

        public override void Update()
        {
            base.Update();
            MovementHandler();
            HandleShooting();
        }

        private void HandleShooting()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                Fire();
        }

        private void MovementHandler()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                Position += new Vector2f(-speed, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                Position += new Vector2f(speed, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                Position += new Vector2f(0, -speed);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                Position += new Vector2f(0, speed);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void Fire()
        {
            Bullet newBullet = new Bullet(ResourceManager.BulletTexture);
            newBullet.Sprite.Origin = new Vector2f(Sprite.TextureRect.Width / 2, Sprite.TextureRect.Height / 2);
            newBullet.Position = Position;
            newBullet.Rotation = Rotation;

            SceneManager.CurrentScene.AddGameObejct(newBullet);
            Console.WriteLine("Bullet = " + newBullet.Tag);
        }

        public override void OnCollisionEnter(GameObejct target)
        {
            base.OnCollisionEnter(target);
            if (target.Tag == "Enemy")
            {
                Sprite.Color = Color.Blue;
                Console.WriteLine("Player entered the enemy");
            }
        }

        public override void OnCollisionExit(GameObejct target)
        {
            if (target.Tag == "Enemy")
            {
                Sprite.Color = Color.White;
                Console.WriteLine("Player exited from the enemy");
            }
        }
    }
}

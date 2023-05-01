
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyFirstSFMLGame
{
    public class Player : GameObejct
    {
        float speed = 2;

        SpriteRenderer spriteRenderer;

        public Player(Texture texture) : base()
        {
            Tag = "Player";

            Rigidbody rigidbody = new Rigidbody();

            spriteRenderer = new SpriteRenderer(texture);

            AddComponent(rigidbody, new AudioPlayer(), spriteRenderer);

            PhysicsManager.AddRigidBody(rigidbody);
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            Position = new Vector2f(800 / 2, 600 / 2);
            spriteRenderer.Sprite.Origin = new Vector2f(spriteRenderer.Sprite.TextureRect.Width / 2, spriteRenderer.Sprite.TextureRect.Height / 2);
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

            newBullet.SpriteRenderer.Sprite.Origin =
                new Vector2f(spriteRenderer.Sprite.TextureRect.Width / 2,
                spriteRenderer.Sprite.TextureRect.Height / 2);

            newBullet.Position = Position;
            newBullet.Rotation = Rotation;

            SceneManager.CurrentScene.AddGameObejct(newBullet);
            Console.WriteLine("Bullet = " + newBullet.Tag);
        }

        public override void OnCollisionEnter(GameObejct target)
        {
            base.OnCollisionEnter(target);

            if (target.Tag == "Enemy")
                spriteRenderer.Sprite.Color = Color.Blue;
        }

        public override void OnCollisionExit(GameObejct target)
        {
            if (target.Tag == "Enemy")
            {
                spriteRenderer.Sprite.Color = Color.White;
            }
        }
    }
}

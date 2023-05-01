
using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class Enemy : GameObejct
    {
        SpriteRenderer spriteRenderer;

        public Enemy(Texture texture) : base()
        {
            Tag = "Enemy";

            spriteRenderer = new SpriteRenderer(texture);

            Rigidbody rigidbody = new Rigidbody();
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
            Position = new Vector2f(20, 20);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}

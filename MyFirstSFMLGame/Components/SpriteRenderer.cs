using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class SpriteRenderer : Component
    {
        private Sprite sprite;
        private Transform transform;
        public Sprite Sprite { get => sprite; }

        public virtual Texture Texture
        {
            get { return sprite.Texture; }
            set { sprite.Texture = value; }
        }

        public virtual Color Color
        {
            get { return sprite.Color; }
            set { sprite.Color = value; }
        }

        public virtual Vector2f Size
        {
            get { return sprite.Scale; }
            set { sprite.Scale = value; }
        }

        public virtual FloatRect GlobalBounds
        {
            get { return sprite.GetGlobalBounds(); }
        }

        public SpriteRenderer(Texture texture)
        {
            sprite = new Sprite(texture);
           
        }

        public SpriteRenderer(Sprite sprite)
        {
            this.sprite = sprite;
            transform = gameObject.GetComponent<Transform>();
        }
        public override void Start()
        {
            transform = gameObject.GetComponent<Transform>();
            if (transform == null)
            {
                Console.WriteLine("transform is null at start");
                return;
            }
        }
        public override void Awake()
        {
            base.Awake();

            sprite.Position = gameObject.Position;
            sprite.Rotation = gameObject.Rotation;
            sprite.Scale = gameObject.Size;
        }

        public override void Update(float deltaTime)
        {
            if (transform == null)
            {
                Console.WriteLine("transform is null");
                return;
            }

            sprite.Position = transform.Position;
            sprite.Rotation = transform.Rotation;
            sprite.Scale = transform.Scale;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            target.Draw(sprite, states);
        }

        public override void Load()
        {
            base.Load();
            sprite = new Sprite(sprite);
        }

        public override void Unload()
        {
            base.Unload();
            sprite.Dispose();
        }
    }
}

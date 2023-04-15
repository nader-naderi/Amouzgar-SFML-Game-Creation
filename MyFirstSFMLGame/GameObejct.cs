using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class GameObejct : Drawable, IDisposable
    {
        protected Sprite sprite;
        protected float rotation;
        protected Vector2f position;
        public string Tag { get; protected set; } = "untagged";

        public bool IsCollided { get; set; } = false;

        public GameObejct(Texture texture)
        {
            sprite = new Sprite(texture);
        }

        public Sprite Sprite { get => sprite; }
        public float Rotation { get => rotation; set { rotation = value; sprite.Rotation = rotation; } }
        public Vector2f Position { get => position; set { position = value; sprite.Position = position; } }
        public Vector2f Size => new Vector2f(sprite.TextureRect.Width, sprite.TextureRect.Height);
        public FloatRect GlobalBounds => sprite.GetGlobalBounds();

        /// <summary>
        /// Executed one frame
        /// </summary>
        public virtual void Awake()
        {

        }

        public void Dispose()
        {
            sprite.Dispose();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
        }

        /// <summary>
        /// Executed one frame after awake
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Execute every frame
        /// </summary>
        public virtual void Update()
        {

        }

        public virtual void OnDestroy()
        {
            Game.Instance.RemoveGameObejct(this);
            Dispose();
        }

        public bool CheckCollision(GameObejct targetObject) => GlobalBounds.Intersects(targetObject.GlobalBounds);

        public virtual void OnCollisionEnter(GameObejct target)
        {
            if (!IsCollided)
                return;

            Console.WriteLine("AA");

            IsCollided = false;
        }

        public virtual void OnCollisionExit(GameObejct target)
        {
            if (IsCollided)
                return;

            Console.WriteLine("BB");

            IsCollided = true;
        }
    }
}


using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyFirstSFMLGame
{
    public class Background : GameObejct
    {
        Window window;
        SpriteRenderer spriteRenderer;

        public Background(Texture texture) : base()
        {
            Tag = "Background";
            spriteRenderer = new SpriteRenderer(texture);
            AddComponent(spriteRenderer);
        }

        public override void Awake()
        {
            base.Awake();

            // Singleton.
            window = ResourceManager.Window;
        }

        public override void Start()
        {
            base.Start();

            spriteRenderer.Sprite.Scale = new Vector2f((float)window.Size.X / spriteRenderer.Sprite.TextureRect.Width,
                (float)window.Size.Y / spriteRenderer.Sprite.TextureRect.Height);
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

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstSFMLGame
{
    public class Background : GameObejct
    {
        Window window;
        public Background(Texture texture) : base(texture)
        {
            Tag = "Background";
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

            Sprite.Scale = new Vector2f((float)window.Size.X / Sprite.TextureRect.Width,
                (float)window.Size.Y / Sprite.TextureRect.Height);
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

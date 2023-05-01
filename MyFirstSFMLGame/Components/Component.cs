using MyFirstSFMLGame;

using SFML.Graphics;

namespace MyFirstSFMLGame
{
    public abstract class Component : IInitializable, ILoadable, Drawable
    {
        public GameObejct gameObject { get; set; }
        
        private bool isActive = true;

        public bool IsActive
        {
            get => isActive;
            set
            {
                if (value != isActive)
                {
                    isActive = value;
                    SetActive(value);
                }
            }
        }

        public void SetActive(bool value) { }

        public abstract void Update(float deltaTime);

        public virtual void Draw(RenderTarget target, RenderStates states)
        {

        }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {

        }

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void OnDestroy()
        {

        }
    }
}

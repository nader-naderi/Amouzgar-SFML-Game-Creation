using SFML.Graphics;
using SFML.System;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyFirstSFMLGame
{
    public class GameObejct : Drawable, IDisposable, IInitializable, IUpdatable, ILoadable
    {
        protected Sprite sprite;
        protected float rotation;
        protected Vector2f position;
        public string Tag { get; protected set; } = "untagged";

        private List<Component> components = new List<Component>(); 

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
            foreach (var component in components)
                component.Update(1f);
        }

        public virtual void OnDestroy()
        {
            SceneManager.CurrentScene.RemoveGameObejct(this);
            Dispose();
        }

        public bool CheckCollision(GameObejct targetObject) => GlobalBounds.Intersects(targetObject.GlobalBounds);

        public virtual void OnCollisionEnter(GameObejct target)
        {

        }

        public virtual void OnCollisionExit(GameObejct target)
        {

        }

        public void Load()
        {
            sprite.Texture.Smooth = true;
        }

        public void Unload()
        {
            sprite.Texture.Smooth = false;
        }

        #region Component Related Methods

        public void AddComponent(params Component[] newComponents)
        {
            for (int i = 0; i < newComponents.Length; i++)
                for (int j = 0; j < components.Count; j++)
                    if (newComponents[i] == components[j])
                        return;

            for (int i = 0; i < newComponents.Length; i++)
            {
                components.Add(newComponents[i]);
                newComponents[i].gameObejct = this;
            }
        }

        public void RemoveComponent(Component component) => components.Remove(component);


        public T GetComponent<T>() where T : Component 
        {
            // LINQ
            return components.Find(theComponent => theComponent is T) as T;
        }

        // Lambda Expression
        public List<Component> GetComponents() => components;
            

        #endregion
    }
}

using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class GameObejct : Drawable, IDisposable, IInitializable, IUpdatable, ILoadable
    {
        protected float rotation;
        public string Tag { get; protected set; } = "untagged";

        private List<Component> components = new List<Component>();
       

        public bool IsCollided { get; set; } = false;

        

        public Transform Transform { get; protected set; }
        public float Rotation { get => Transform.Rotation; set => Transform.Rotation = value; }
        public virtual Vector2f Size => new Vector2f(1, 1);
        public Collider Collider { get; protected set; }

        public virtual FloatRect GlobalBounds => new FloatRect(1, 1, 1, 1);
        public string Name { get; protected set; }

        public Vector2f Position
        {
            get => Transform.Position;
            set { Transform.Position = value; Transform.Position = Transform.Position; }
        }
        public GameObejct()
        {
            Transform = new Transform();
            AddComponent(Transform);
            Name = "New GameObejct";
        }

        public GameObejct(string name)
        {
            Transform = new Transform();
            AddComponent(Transform);

            if (Tag == "Bullet")
                Console.WriteLine(Transform);

            Name = name;
        }

        /// <summary>
        /// Executed one frame
        /// </summary>
        public virtual void Awake()
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                component.Awake();
            }
        }

        public void Dispose()
        {
            //sprite.Dispose();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                component.Draw(target, states);
            }
        }

        /// <summary>
        /// Executed one frame after awake
        /// </summary>
        public virtual void Start()
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                component.Start();
            }
        }

        /// <summary>
        /// Execute every frame
        /// </summary>
        public virtual void Update()
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component? component = components[i];
                component.Update(TimeManager.deltaTime);
            }
        }

        public virtual void OnDestroy()
        {
            SceneManager.CurrentScene.RemoveGameObejct(this);
            Dispose();
        }

        public bool CheckCollision(GameObejct targetObject) => GlobalBounds.Intersects(targetObject.GlobalBounds);

        public virtual void OnCollisionEnter(GameObejct target)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();

            if (rigidbody == null)
                return;

            if (targetRigidbody == null)
                return;

            float impactForce = 0.5f * rigidbody.Mass * targetRigidbody.Mass *
                ((rigidbody.Velocity - targetRigidbody.Velocity).Length() / TimeManager.deltaTime);
            // Calculate direction of impact
            Vector2f direction = target.Position - Position;
            
            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Apply a force in the opposite direction of the impact
            rigidbody.ApplyForce(-direction * impactForce);
        }

        public virtual void OnCollisionExit(GameObejct target)
        {

        }

        public void Load()
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                component.Load();
            }
        }

        public void Unload()
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component component = components[i];
                component.Unload();
            }
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
                newComponents[i].gameObject = this;
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

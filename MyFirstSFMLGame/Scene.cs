using SFML.Graphics;

namespace MyFirstSFMLGame
{
    public class Scene : IInitializable, IUpdatable, IDisposable, Drawable, ILoadable
    {

        private List<GameObejct> gameObjects = new List<GameObejct>();

        private string name;

        public Scene(string name)
        {
            gameObjects.Add(new GameObejct(ResourceManager.BackGroundTexture));

            gameObjects.Add(new Player(ResourceManager.PlayerTexture));
            gameObjects.Add(new Enemy(ResourceManager.EnemyTexture));

            foreach (GameObejct gameObejct in gameObjects)
            {
                gameObejct.Awake();
                gameObejct.Start();
            }

            this.name = name;
        }

        public void Awake()
        {

        }

        public void Start()
        {

        }

        public void Dispose()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (GameObejct gameObejct in gameObjects)
                target.Draw(gameObejct);
        }

        
        public void Update()
        {
            foreach (GameObejct gameObject in gameObjects)
                gameObject.Update();
        }

        public void AddGameObejct(GameObejct target)
        {
            // Editor

            gameObjects.Add(target);

            if (target.GetComponent<Rigidbody>() != null)
            {
                PhysicsManager.AddRigidBody(target.GetComponent<Rigidbody>());
            }
        }

        public void RemoveGameObejct(GameObejct target)
        {
            gameObjects.Remove(target);
        }

        public void Load()
        {
            foreach (GameObejct gameObject in gameObjects)
                gameObject.Load();
        }

        public void Unload()
        {
            foreach (GameObejct gameObject in gameObjects)
                gameObject.Unload();
        }
    }
}

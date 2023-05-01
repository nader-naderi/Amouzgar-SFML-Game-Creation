using MyFirstSFMLGame;
using SFML.Graphics;

namespace MyFirstSFMLGame 
{
    public class Scene : IInitializable, IUpdatable, IDisposable, Drawable, ILoadable
    {

        private List<GameObejct> gameObjects = new List<GameObejct>();

        private string name;

        public Scene(string name)
        {
            gameObjects.Add(new Background(ResourceManager.BackGroundTexture));

            gameObjects.Add(new Player(ResourceManager.PlayerTexture));
            gameObjects.Add(new Enemy(ResourceManager.EnemyTexture));

            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObejct gameObejct = gameObjects[i];
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
            // Iteration
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObejct gameObejct = gameObjects[i];
                target.Draw(gameObejct);
            }
        }


        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObejct gameObject = gameObjects[i];
                gameObject.Update();
            }
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
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObejct gameObject = gameObjects[i];
                gameObject.Load();
            }
        }

        public void Unload()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObejct gameObject = gameObjects[i];
                gameObject.Unload();
            }
        }
    }
}

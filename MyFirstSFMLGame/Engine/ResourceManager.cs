using SFML.Graphics;

namespace MyFirstSFMLGame 
{
    public static class ResourceManager
    {
        public static Texture BackGroundTexture { get; private set; }
        public static Texture PlayerTexture { get; private set; }
        public static Texture EnemyTexture { get; private set; }
        public static Texture BulletTexture { get; private set; }
        public static Font Font { get; private set; }
        public static RenderWindow Window { get; set; }
        public static void LoadAssets()
        {
            PlayerTexture = new Texture(new Texture(Directory.GetCurrentDirectory() + "/Assets/Textures/player.png"));

            EnemyTexture = new Texture(new Texture(Directory.GetCurrentDirectory() + "/Assets/Textures/enemy.png"));

            Font = new Font(Directory.GetCurrentDirectory() + "/Assets/Textures/SpaceShooterRedux/Bonus/kenvector_future.ttf");

            BackGroundTexture = new Texture(new Texture(Directory.GetCurrentDirectory() +
                "/Assets/Textures/SpaceShooterRedux/Backgrounds/blue.png"));

            BulletTexture = new Texture(new Texture(Directory.GetCurrentDirectory() +
                "/Assets/Textures/SpaceShooterRedux/PNG/Effects/fire06.png"));

        }

    }
}

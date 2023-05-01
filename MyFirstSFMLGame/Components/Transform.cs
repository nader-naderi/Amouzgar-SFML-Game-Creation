using SFML.System;
namespace MyFirstSFMLGame
{
    public class Transform : Component
    {
        public Vector2f Position { get; set; }
        public Vector2f Scale { get; set; } = new Vector2f(1, 1);
        public float Rotation { get; set; }

        public Transform()
        {
            
        }

        public Transform(Vector2f position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public override void Update(float deltaTime)
        {

        }

        public void Translate(Vector2f translate) =>
            Position += translate;
    }
}

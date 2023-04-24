using SFML.System;

namespace MyFirstSFMLGame
{
    /// <summary>
    /// جسم صلب
    /// </summary>
    public class Rigidbody : Component, IPhysical
    {
        public float Gravity { get; set; } = 0.001f;
        public float Friction { get; set; } = 10.5f;
        public Vector2f Velocity { get; set; }

        public void ApplyForce(Vector2f force)
        {
            Velocity += force;
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}

using SFML.Graphics;
using SFML.System;

namespace MyFirstSFMLGame
{
    public class Collider : Component
    {

        public FloatRect Bounds { get; set; } = new FloatRect(0, 0, 1, 1);

        private Vector2f Size { get; set; } = new Vector2f(1, 1);
        private bool isTrigger;

        public override void Awake()
        {
            Transform transform = gameObject.GetComponent<Transform>();
            Size = transform.Scale;
            this.Bounds = new FloatRect(transform.Position.X, transform.Position.Y, Size.X, Size.Y);
        }

        public override void Update(float deltaTime)
        {
            // Update the size and bounds based on the transform
            Transform transform = gameObject.GetComponent<Transform>();
            Size = transform.Scale;
            Bounds = new FloatRect(transform.Position.X, transform.Position.Y, Size.X, Size.Y);
        }

        public bool CheckCollision(Collider other)
        {
            if (isTrigger || other.isTrigger)
                return Bounds.Intersects(other.Bounds);

            return false;
        }

        public void OnCollisionEnter(Collider other)
        {
        }

        public void OnCollisionStay(Collider other)
        {
        }

        public void OnCollisionExit(Collider other)
        {
        }

        public void OnTriggerEnter(Collider other)
        {
        }

        public void OnTriggerStay(Collider other)
        {
        }

        public void OnTriggerExit(Collider other)
        {
        }
    }
}

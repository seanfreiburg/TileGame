
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Lib
{
    public interface IFocusable
    {
        Vector2 Position { get; }
    }

    public interface ICamera2D
    {
        /// <summary>
        /// Gets or sets the position of the camera
        /// </summary>
        /// <value>The position.</value>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the move speed of the camera.
        /// The camera will tween to its destination.
        /// </summary>
        /// <value>The move speed.</value>
        float MoveSpeed { get; set; }

        /// <summary>
        /// Gets or sets the rotation of the camera.
        /// </summary>
        /// <value>The rotation.</value>
        float Rotation { get; set; }

        /// <summary>
        /// Gets the origin of the viewport (accounts for Scale)
        /// </summary>        
        /// <value>The origin.</value>
        Vector2 ViewportOrigin { get; }

        /// <summary>
        /// Gets the origin of the camera (accounts for Scale)
        /// </summary>        
        /// <value>The origin.</value>
        Vector2 CameraOrigin { get; }

        /// <summary>
        /// Gets or sets the scale of the Camera
        /// </summary>
        /// <value>The scale.</value>
        float Scale { get; set; }

        /// <summary>
        /// Gets the screen center (does not account for Scale)
        /// </summary>
        /// <value>The screen center.</value>
        Vector2 ScreenCenter { get; }

        /// <summary>
        /// Gets the transform that can be applied to 
        /// the SpriteBatch Class.
        /// </summary>
        /// <see cref="SpriteBatch"/>
        /// <value>The transform.</value>
        Matrix Transform { get; }

        /// <summary>
        /// Gets or sets the focus of the Camera.
        /// </summary>
        /// <seealso cref="IFocusable"/>
        /// <value>The focus.</value>
        IFocusable Focus { get; set; }

        /// <summary>
        /// Determines whether the target is in view given the specified position.
        /// This can be used to increase performance by not drawing objects
        /// directly in the viewport
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="texture">The texture.</param>
        /// <returns>
        ///     <c>true</c> if the target is in view at the specified position; otherwise, <c>false</c>.
        /// </returns>
        bool IsInView(Vector2 position, Texture2D texture);
    }

    public class Camera2D : GameComponent, ICamera2D
    {
        private Vector2 _position;
        protected float _viewportHeight;
        protected float _viewportWidth;

        public Camera2D(Game game)
            : base(game)
        {
            Rotation = 0;
            ViewportOrigin = new Vector2(0, 0);
            CameraOrigin = new Vector2(0, 0);
        }

        #region Properties

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public float Rotation { get; set; }
        public Vector2 ViewportOrigin { get; set; }
        public Vector2 CameraOrigin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public IFocusable Focus { get; set; }
        public float MoveSpeed { get; set; }

        #endregion

        /// <summary>
        /// Called when the GameComponent needs to be initialized. 
        /// </summary>
        public void Initialize(IFocusable target)
        {
            _viewportWidth = Game.GraphicsDevice.Viewport.Width;
            _viewportHeight = Game.GraphicsDevice.Viewport.Height;

            ScreenCenter = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
            Scale = 1;
            MoveSpeed = 1.25f;

            Focus = target;
            Position = target.Position;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // Create the Transform used by any
            // spritebatch process
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(ViewportOrigin.X, ViewportOrigin.Y, 0) *
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            ViewportOrigin = ScreenCenter / Scale;

            // Move the Camera to the position that it needs to go
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.X += (Focus.Position.X - Position.X) * MoveSpeed * delta;
            _position.Y += (Focus.Position.Y - Position.Y) * MoveSpeed * delta;

            var cameraOriginX = _position.X - ViewportOrigin.X;
            var cameraOriginY = _position.Y - ViewportOrigin.Y;
            CameraOrigin = new Vector2(cameraOriginX, cameraOriginY);

            base.Update(gameTime);
        }

        /// <summary>
        /// Determines whether the target is in view given the specified position.
        /// This can be used to increase performance by not drawing objects
        /// directly in the viewport
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="texture">The texture.</param>
        /// <returns>
        ///     <c>true</c> if [is in view] [the specified position]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInView(Vector2 position, Texture2D texture)
        {
            // If the object is not within the horizontal bounds of the screen

            if ((position.X + texture.Width) < (Position.X - ViewportOrigin.X) || (position.X) > (Position.X + ViewportOrigin.X))
                return false;

            // If the object is not within the vertical bounds of the screen
            if ((position.Y + texture.Height) < (Position.Y - ViewportOrigin.Y) || (position.Y) > (Position.Y + ViewportOrigin.Y))
                return false;

            // In View
            return true;
        }
    }
}

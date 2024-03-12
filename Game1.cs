using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Bread_Crumbs
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D tex;
        Rectangle[] rektlist;

        int velX;
        int velY;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {   rektlist = new Rectangle[10];
            for (int i = 0; i < rektlist.Length; i++)
            {
                rektlist[i] = new Rectangle(175 - i * 5, 80 - i * 5, 50 - i * 5, 50 - i * 5); 
            }
            velX = 20;
            velY = 20;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tex = Content.Load<Texture2D>("rekt");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (rektlist[0].X < 0 || rektlist[0].X + rektlist[0].Width > 800)velX *= -1;
            if (rektlist[0].Y < 0 || rektlist[0].Y + rektlist[0].Height > 480)velY *= -1;

            int bX = rektlist[0].X;
            int bY = rektlist[0].Y;

            rektlist[0].X += velX;
            rektlist[0].Y += velY;

            int tX = 5;
            int tY = 5;

            if (velX > 0) tX = -5;
            else tX = 5;
            if (velY > 0) tY = -5;
            else tY = 5;

            for (int i = rektlist.Length-1; i > 0; i--)
            {   rektlist[i].X = rektlist[i-1].X + tX;
                rektlist[i].Y = rektlist[i-1].Y + tY;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            for (int i = 1; i < rektlist.Length; i++)
            {
                spriteBatch.Draw(tex, rektlist[i], Color.White);
            }
            spriteBatch.Draw(tex, rektlist[0], Color.Gray);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
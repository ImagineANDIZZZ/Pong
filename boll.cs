using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class boll
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle  = new Rectangle(390,230,20,20);
        private float velocityX = 1;
        private float velocityY = 1;
        public Rectangle Rectangle{
            get{return rectangle;}
        }

        public boll(Texture2D t){
            texture = t;
            position = new Vector2();
            position.X = rectangle.X;
            position.Y= rectangle.Y;
        }
        public void Reset(){
            rectangle.X = 390;
            rectangle.Y = 230;
            velocityX = 2;
            velocityY = 2;
        }
        public void Bounce(){
            velocityX *= -1.1f;
        }
        public void Update(){
        position.X += velocityX;
        position.Y += velocityY;

        rectangle.X += (int)velocityX;
        rectangle.Y += (int)velocityY;

        if(rectangle.Y <= 0 || rectangle.Y + rectangle.Height >= 460){
            velocityY *= -1;
        }

        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.LightYellow);
        }

    }
}
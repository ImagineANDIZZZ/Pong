using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Paddle
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 1;
        private Keys up;
        private Keys down;
        public Rectangle Rectangle{
            get{return rectangle;}
        }

        public Paddle(Texture2D t, Rectangle r, Keys u,Keys d){
            texture = t;
            rectangle = r;
            up = u;
            down = d;
        }
        public void Update(){
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(up) && rectangle.Y >= 0){
                rectangle.Y -=speed;
            }
            if(kState.IsKeyDown(down) && rectangle.Y <= 380){
                rectangle.Y += speed;
            }


        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.Green);
        }
    }
}
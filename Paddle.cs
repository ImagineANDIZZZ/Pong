using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class paddle
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 1;
        private Keys up;
        private Keys down;

        public paddle(Texture2D t){
            texture = t;
        }
        public void Update(){
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown()){
                rectangle.Y -=speed;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.Green);
        }
    }
}
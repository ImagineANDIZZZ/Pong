
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont fontScore;

    Paddle paddleLeft;
    Paddle paddleRight;

    boll boll;

    float velocityX = 1;
    float velocityY = 1;

    int scoreLeftplayer = 0;
    int scoreRightplayer = 0;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>(assetName: "Bolll_pong");
        fontScore = Content.Load<SpriteFont>("Score");

        boll = new boll(pixel);
        paddleLeft = new Paddle(pixel, new Rectangle(10,200,20,100),Keys.W, Keys.S);
        paddleRight = new Paddle(pixel, new Rectangle(770,200,20,100),Keys.Up,Keys.Down);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit(); 
        
        paddleLeft.Update();
        paddleRight.Update();

        boll.Update();
        if(paddleLeft.Rectangle.Intersects(boll.Rectangle) ||
        paddleRight.Rectangle.Intersects(boll.Rectangle)){
            boll.Bounce();
        }
        
        if(boll.Rectangle.X <= 0){
            boll.Reset();
            scoreRightplayer++;
        }
        else if(boll.Rectangle.X + boll.Rectangle.Width >= 800){
           boll.Reset();
            scoreLeftplayer++;
        }

        

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore,scoreLeftplayer.ToString(),new Vector2(10,10),Color.Orange);
        _spriteBatch.DrawString(fontScore,scoreRightplayer.ToString(),new Vector2(730,10),Color.Orange);
        paddleLeft.Draw(_spriteBatch);
        paddleRight.Draw(_spriteBatch);
        boll.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

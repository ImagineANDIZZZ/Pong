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

    Rectangle paddleLeft = new Rectangle(10,200,20,100);
    Rectangle paddleRight = new Rectangle(770,200,20,100);
    Rectangle Ball = new Rectangle(390,230,20,20);

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
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
            paddleLeft.Y-= 8;
        }
        if(kState.IsKeyDown(Keys.S) && paddleLeft.Y + paddleLeft.Height < 480){
            paddleLeft.Y+= 8;
        }
        if(kState.IsKeyDown(Keys.Up) && paddleRight.Y > 0){
            paddleRight.Y-= 8;
        }
        if(kState.IsKeyDown(Keys.Down) && paddleRight.Y + paddleLeft.Height < 480){
            paddleRight.Y+= 8;
        }

        Ball.X += (int)velocityX;
        Ball.Y += (int)velocityY;
        if(Ball.Intersects(paddleRight) ||
           Ball.Intersects(paddleLeft)){
           velocityX *= -1.1f;
           velocityY *= -1.1f;
        }

        if(Ball.Y <= 0 || Ball.Y + Ball.Height >= 460){
            velocityY *= -1;
        }
        
        if(Ball.X <= 0 || Ball.X + Ball.Width >= 800){
            Ball.X = 390;
            Ball.Y = 230;
            velocityX = 2;
            velocityY = 2;
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

        _spriteBatch.Draw(pixel,paddleLeft,Color.Red);
        _spriteBatch.Draw(pixel,paddleRight,Color.LimeGreen);
        _spriteBatch.Draw(pixel,Ball,Color.LightYellow);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

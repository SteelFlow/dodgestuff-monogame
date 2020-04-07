namespace App

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Game1 () as this =
    inherit Game()
 
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<_>
    let mutable font:SpriteFont = null

    do
        this.Content.RootDirectory <- "Content"
        this.IsMouseVisible <- true
    

    override this.Initialize() =
        // TODO: Add your initialization logic here
        
        base.Initialize()

    override this.LoadContent() =
        spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        font <- Content.Fonts.Xolonium this.Content

        // TODO: use this.Content to load your game content here
 
    override this.Update (gameTime) =
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        then this.Exit();

        // TODO: Add your update logic here
    
        base.Update(gameTime)
 
    override this.Draw (gameTime) =
        this.GraphicsDevice.Clear Color.CornflowerBlue

        spriteBatch.Begin()
        spriteBatch.DrawString(font, "Hello World", Vector2(float32 32, float32 32), Color.White)
        spriteBatch.End()
        // TODO: Add your drawing code here

        base.Draw(gameTime)

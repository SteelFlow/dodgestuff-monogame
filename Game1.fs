namespace App

open Assets
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Player
open System

type Game1() as this =
    inherit Game()

    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<_>
    let font = lazy (Fonts.Xolonium this.Content)

    let mutable player =
        lazy
            (Player.frames this.Content
             |> Player.initAnimation
             |> Player.create)

    do
        this.Content.RootDirectory <- "Content"
        this.IsMouseVisible <- true

    override this.Initialize() =
        // TODO: Add your initialization logic here

        base.Initialize()

    override this.LoadContent() =
        spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        do font.Force() |> ignore

        do player.Force() |> ignore
    // TODO: use this.Content to load your game content here

    override this.Update(gameTime) =
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)) then this.Exit()

        let animation = player.Value.Animation
        // TODO: Add your update logic here
        player <- lazy (Player.create (Animation.update animation gameTime.ElapsedGameTime))
        player.Force() |> ignore
        base.Update(gameTime)

    override this.Draw(gameTime) =
        this.GraphicsDevice.Clear Color.CornflowerBlue

        let frame = player.Value.Animation.CurrentFrame.Source
        spriteBatch.Begin()
        spriteBatch.Draw(frame, Vector2(float32 100, float32 100), Color.White)
        spriteBatch.DrawString(font.Value, "Hello World", Vector2(float32 32, float32 32), Color.White)
        spriteBatch.End()
        // TODO: Add your drawing code here

        base.Draw(gameTime)

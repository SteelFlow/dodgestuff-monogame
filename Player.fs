module Player

open Animation
open Assets
open System

let frameDuration = TimeSpan.FromMilliseconds 500.0

let frames contentManager =
    [ { Source = Sprites.Player.up1 contentManager
        FrameDuration = (TimeSpan.FromSeconds 2.0) }
      { Source = Sprites.Player.up2 contentManager
        FrameDuration = frameDuration } ]

let initAnimation frames =
    { Frames = frames
      TimeToNextFrame = frameDuration }

type Player =
    { Animation: Animation }

let create animation = { Animation = animation }

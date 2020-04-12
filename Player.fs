module Player

open Animation
open Assets
open System

let frameDuration = TimeSpan.FromMilliseconds 500.0

let frames contentManager =
    [ { Source = Sprites.Player.up1 contentManager
        FrameDuration = frameDuration }
      { Source = Sprites.Player.up2 contentManager
        FrameDuration = frameDuration } ]

let animation frames = { Frames = frames }

let initialState animation =
    { Animation = animation
      TimeToNextFrame = frameDuration }

type Player =
    { State: AnimationState }

let create state = { State = state }

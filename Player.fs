module Player

open Animation
open Content
open System

let frames contentManager =
    [ { Source = Sprites.Player.up1 contentManager }
      { Source = Sprites.Player.up2 contentManager } ]

let animation frames duration =
    { Frames = frames
      FrameDuration = TimeSpan.FromMilliseconds(duration) }

let initialState animation =
    { Animation = animation
      TimeToNextFrame = animation.FrameDuration }

type Player =
    { State: AnimationState }

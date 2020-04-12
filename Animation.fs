module Animation

open System
open Microsoft.Xna.Framework.Graphics


type AnimationFrame =
    { Source: Texture2D
      FrameDuration: TimeSpan }

type Animation =
    { Frames: AnimationFrame list }

type AnimationState =
    { Animation: Animation
      TimeToNextFrame: TimeSpan }

let private listShift (frames) =
    match frames with
    | []
    | [ _ ] -> frames
    | head :: tail -> List.append tail [ head ]

let private nextFrame state =
    let shiftedFrames = state.Animation.Frames |> listShift
    { state with
          Animation = { state.Animation with Frames = shiftedFrames }
          TimeToNextFrame = shiftedFrames.Head.FrameDuration }

let update (state: AnimationState) (delta: TimeSpan) =
    let time = state.TimeToNextFrame - delta
    if time > TimeSpan.Zero then { state with TimeToNextFrame = time } else nextFrame state

let frameToDraw (state: AnimationState) = state.Animation.Frames.Head

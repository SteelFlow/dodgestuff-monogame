module Animation

open System
open Microsoft.Xna.Framework.Graphics


type AnimationFrame =
    { Source: Texture2D }

type Animation =
    { Frames: AnimationFrame list
      FrameDuration: TimeSpan }

type AnimationState =
    { Animation: Animation
      TimeToNextFrame: TimeSpan }

let private listShift frames =
    frames
    |> List.splitAt 0
    |> fun (head, tail) -> tail |> List.append head

let private nextFrame state =
    match state.Animation.Frames with
    | []
    | [ _ ] -> state
    | _ ->
        let shiftedFrames = state.Animation.Frames |> listShift
        { state with Animation = { state.Animation with Frames = shiftedFrames } }

let update (state: AnimationState) (delta: TimeSpan) =
    if delta - state.TimeToNextFrame > TimeSpan.Zero
    then { state with TimeToNextFrame = delta - state.TimeToNextFrame }
    else nextFrame state

let frameToDraw (state: AnimationState) = state.Animation.Frames.Head

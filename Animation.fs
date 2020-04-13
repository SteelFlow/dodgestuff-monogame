module Animation

open System
open Microsoft.Xna.Framework.Graphics


type AnimationFrame =
    { Source: Texture2D
      FrameDuration: TimeSpan }

type Animation =
    { Frames: AnimationFrame list
      TimeToNextFrame: TimeSpan }
    member this.CurrentFrame = this.Frames.Head

let private listShift (frames) =
    match frames with
    | []
    | [ _ ] -> frames
    | head :: tail -> List.append tail [ head ]

let private nextFrame anim =
    let shiftedFrames = anim.Frames |> listShift
    { anim with
          Frames = shiftedFrames
          TimeToNextFrame = shiftedFrames.Head.FrameDuration }

let update (animation: Animation) (delta: TimeSpan) =
    let time = animation.TimeToNextFrame - delta
    if time > TimeSpan.Zero
    then { animation with TimeToNextFrame = time }
    else nextFrame animation

let frameToDraw (animation: Animation) = animation.Frames.Head

module Input

open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework

let rec private handleKeys keys (currentVelocity: Vector2) =
    match keys with
    | [] -> currentVelocity
    | x :: xs ->
        match x with
        | Keys.Right ->
            let newV = Vector2(currentVelocity.X - float32 1, currentVelocity.Y)
            handleKeys xs (newV)
        | Keys.Left ->
            let newV = Vector2(currentVelocity.X + float32 1, currentVelocity.Y)
            handleKeys xs (newV)
        | Keys.Up ->
            let newV = Vector2(currentVelocity.X, currentVelocity.Y - float32 1)
            handleKeys xs (newV)
        | Keys.Down ->
            let newV = Vector2(currentVelocity.X, currentVelocity.Y + float32 1)
            handleKeys xs (newV)
        | _ -> handleKeys xs (currentVelocity)


let GetVelocity(kbState: KeyboardState) =
    kbState.GetPressedKeys()
    |> Array.toList
    |> fun keys -> handleKeys keys Vector2.Zero
    |> Vector2.Normalize

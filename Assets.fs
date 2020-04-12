module Assets

open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

let loadAsset<'a> (contentManager: ContentManager) (path) = contentManager.Load<'a>(path)

module Fonts =
    let Xolonium contentManager = loadAsset<SpriteFont> contentManager "Fonts/Xolonium"

module Sprites =
    let loadSprite contentManager = loadAsset<Texture2D> contentManager
    let private sprites = "Sprites/"

    module Enemy =
        let flying1 ct = loadSprite ct (sprintf "%senemyFlyingAlt_1" sprites)
        let flying2 ct = loadSprite ct (sprintf "%senemyFlyingAlt_2" sprites)

        let swimming1 ct = loadSprite ct (sprintf "%senemySwimming_1" sprites)
        let swimming2 ct = loadSprite ct (sprintf "%senemySwimming_2" sprites)

        let walking1 ct = loadSprite ct (sprintf "%senemyWalking_1" sprites)
        let walking2 ct = loadSprite ct (sprintf "%senemyWalking_1" sprites)

    module Player =
        let up1 ct = loadSprite ct (sprintf "%splayerGrey_up1" sprites)
        let up2 ct = loadSprite ct (sprintf "%splayerGrey_up2" sprites)

        let walk1 ct = loadSprite ct (sprintf "%splayerGrey_walk1" sprites)
        let walk2 ct = loadSprite ct (sprintf "%splayerGrey_walk2" sprites)

module Audio =
    let gameover = "Audio/gameover"
    let music = "Audio/House In a Forest Loop"

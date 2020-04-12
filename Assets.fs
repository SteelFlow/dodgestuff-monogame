module Assets

open System
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

type AssetType =
    | Font of SpriteFont
    | Sprite of Texture2D

let loadAsset<'a> (contentManager: ContentManager) (path) = contentManager.Load<'a>(path)

module Fonts =
    let Xolonium contentManager = loadAsset<SpriteFont> contentManager "Fonts/Xolonium"

module Sprites =
    let private sprites = "Sprites/"

    module Enemy =
        let flying1 = sprintf "%senemyFlyingAlt_1" sprites
        let flying2 = sprintf "%senemyFlyingAlt_2" sprites

        let swimming1 = sprintf "%senemySwimming_1" sprites
        let swimming2 = sprintf "%senemySwimming_2" sprites

        let walking1 = sprintf "%senemyWalking_1" sprites
        let walking2 = sprintf "%senemyWalking_1" sprites

    module Player =
        let up1 (contentManager: ContentManager) = contentManager.Load<Texture2D>(sprintf "%splayerGrey_up1" sprites)
        let up2 (contentManager: ContentManager) = contentManager.Load<Texture2D>(sprintf "%splayerGrey_up2" sprites)

        let walk1 = sprintf "%splayerGrey_walk1" sprites
        let walk2 = sprintf "%splayerGrey_walk2" sprites

module Audio =
    let gameover = "Audio/gameover"
    let music = "Audio/House In a Forest Loop"

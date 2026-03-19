This is the README for the Game Programming Midterm

## Group Members:
- Dominic Arrezola
- Bailey Caldera
- Broedy Crowell
- Kevin Evans
- Michael Reyes
- Josh Swineford

## Game Name


## Description 
A top down shooter where you play as a pig surviving against waves of ducks. Throw apples to survive by left clicking
and throw big apples by right clicking.

## Goal:

    The goal of this project is to create a 3d unity game for our midterm

## Third Parties Asset:
Tiny Texture Pack 2 by Screaming Brain Studios
https://screamingbrainstudios.itch.io/tiny-texture-pack-2?download#google_vignette

## Design:

    This is an overhead view 3D Binding of Isac-like game

## Implemented Files / Features:

    -PlayerMovement.cs - basic player movement (WASD)
    -PlayerShooting.cs - basic player shooting -> clicking fires a projectile in that direction
    -PlayerHealth.cs - basic player health system 
        **CURRENTLY THE PLAYER OBJECT IS DESTROYED WHEN THIS HAPPENS WHICH
            BREAKS THE CAMERA (which is childed to the player object)
    -CameraFollow.cs - basic camera follow script
    -Projectile.cs - player projectile logic

    -Enemy.cs - basic enemy health tracking (Simply destroys game object upon death)
    -EnemyAI.cs - basic enemy AI (movement and shooting)
    -EnemyProjectile.cs - enemy projectile logic -> controls the projectile once the enemy has shot it

    -LevelController.cs - spawns waves of enemies randomly from a list of provided transforms
        ** should probably be made to manage ending the game / restarting the game upon player victory



## Notes:

    - I made a prefab folder that contains the bullet prefabs as well as the enemy prefab
    - The materials for everything are in the ArtAssets folder
    - I downloaded a basic free artpack from:
            https://screamingbrainstudios.itch.io/tiny-texture-pack-2?download#google_vignette
        and i used it for ground and wall textures
    - The downloaded textures are in ArtAssets -> "SBS - Tiny - Texture Pack 2 "
    - projectiles have collider & rigidbody; the player and enemies have only collider (no rigidbody)
    - right now clicking shoots a projectile with no cooldown,
        maybe we should make it so that holding the mouse down
        automatically rapid-fires projectiles with some sort of 
        predetermined fire rate / cooldown
    - if we want to make different powerups that simply effect fire rate then we can maybe leave code as is
        otherwise, we might want to make a state machine for which powerup/projectile we're using
        at any given time
    - if we want more than 1 enemy then we might consider making the Enemy script actually be a base script
        and have specific enemies inherit from Enemy (just for health and death values which are all that
        the Enemy script actually tracks). otherwise we could just manually set helath values on the prefabs???
    
    

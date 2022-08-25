# Neon Fighter Demo Game

I made this simple project to demonstrate my C# coding style, Unity project organisation and practises I usually use. 
Even my large projects basically have the same structure (folders, GameObjects hierarchy etc.)

The project might be updated with new features in the future. 

![Gameplay Screenshot](https://i.postimg.cc/Y9DCDXT9/Screen-Shot-2022-08-25-at-15-45-08.png)

[WebGL demo is playable on browsers.](https://geekart.club/Games/Neon-Fighter/) 

## Features
### Basic
 - Player and Enemies are moving using Physics Engine (by changing velocity, rather than moving Transofms).
 - Player is controlled with WASD buttons and mouse.
 - Player and Enemies can shoot simple Bullets and get damage.
 - There are predefined map layouts with obstacles and spawn points. `MapController` fills each Quarter with randomly selected layout. 
 
### Fancy Stuff
 - Object Pooling.
 
 I followed the official Unity tutorial, but enhanced the `Pooler.cs` script for my needs. Both [Neon Hero](https://play.google.com/store/apps/details?id=games.birb.neonhero&hl=en) and [Beat Hit](https://play.google.com/store/apps/details?id=com.MaenasThalion.BeatHit) games use Object Pooling. 
 - DOTween for UI animations (StartPanel, PausePanel).
 - Neon Post-processing effect.
 
 In my [blog post](https://geekart.club/gamedev/how-we-made-tron-like-glow-in-our-neon-hero-game/) I explained how we created this effect in Neon Hero game. 

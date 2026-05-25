# Unity Game Development Tasks

**Author:** Harsh Kashyap  
**Framework:** Unity 2022 (2D)

## Overview
This repository contains my submissions for the Game Development tasks, built entirely from scratch in Unity using C#. The project is split into two primary scenes demonstrating core gameplay programming and AI logic.

# Task 1: 2D Platformer Mechanics & Bug Fixing

## 📌 Overall Task Structure
This project focused on refining a 2D platformer controller by debugging existing movement issues and implementing advanced input mechanics. The primary objective was to drastically improve the "game feel" and responsiveness of the player character.

## 🎮 Controls & Testing Instructions
**Controls:**
* **Move Left/Right:** `A` / `D`
* **Jump:** `Spacebar` 

**Testing Instructions:**
1. Open the project in Unity and load the main test Scene.
2. Press the **Play** button.
3. **Test Coyote Time:** Walk the player off the edge of a platform and press Jump shortly *after* leaving the edge. The character should still jump.
4. **Test Jump Buffering:** While falling toward a platform, press Jump shortly *before* hitting the ground. The character should immediately jump the exact frame they touch the floor.

## ⚙️ Core Systems & Features
* **Debugging & Refinement:** Fixed core physics and movement bugs in the initial setup to ensure a stable foundation.
* **Coyote Jump Implementation:** Added a timer system that allows players a brief grace period (a few frames) to execute a jump after falling off a ledge, preventing frustrating "eaten" inputs.
* **Jump Buffering:** Implemented an input memory system that saves a jump command made slightly before landing, ensuring the player jumps the exact moment they touch the ground.

## 📜 Credits & Resources
* **Code & Development:** Core debugging and fixing coyote time timers was given a genuine attempt by me. Also a lot of help from Gemini AI was used as a programming tool to help troubleshoot bugs and optimize the timer logic for the advanced jump mechanics.
* **Visual Assets:** Utilized standard Unity Default 2D Sprites.
* **Audio:** No external audio used.

# Task 2: Stealth & Enemy AI System

## 📌 Overall Task Structure
This project is a functional prototype of a stealth-action game loop. The focus is on clean backend architecture, featuring an object-oriented Artificial Intelligence system with distinct enemy types, dynamic threat detection, and lethal trigger states.

## 🎮 Controls & Testing Instructions
**Controls:**
* **Move Left/Right:** `A` / `D`
* **Jump:** `Spacebar` 
* **Objective:** Evade enemy line-of-sight and physical attacks.

**Testing Instructions:**
1. Open the project in Unity and press **Play**.
2. **Test Melee (Red Circle):** Let the red circle patrol enemy touch the player. The scene will instantly restart.
3. **Test Ranged (Blue Square):** Walk into the line of sight of the blue square sniper. It will track the player and fire a kinetic projectile. If the projectile hits the player, the scene restarts. If it hits a wall, it gets destroyed.
4. **Test Vision/Alarm (Yellow Triangle):** Walk into the yellow triangle camera's sweeping vision. It will trigger a global alarm, alerting all enemies to chase the player.

## ⚙️ Core Systems & Features
* **Polymorphic AI Architecture:** Implemented a base `Task2_EnemyManager` class with inherited subclasses for specific behaviors (Melee, Ranged, Scout), avoiding repetitive spaghetti code.
* **Vector Math & Projectiles:** Enemies dynamically calculate the distance and direction to the player using `Vector2` math to aim and move.
* **Raycast Line-of-Sight:** The Camera uses trigonometric sweeping (`Mathf.Sin`) and Layer-Masked Raycasting to detect the player, ensuring solid walls correctly block vision.
* **Scene Management:** Seamless game loop utilizing `UnityEngine.SceneManagement` to reset the active scene upon a fail state.

## 📜 Credits & Resources
* **Code & Development:** the project was given my best attempt but still heavy help from Gemini AI was required.
* **Visual Assets:** Exclusively uses Unity Default 2D Primitives (Circles, Squares, Triangles) colored specifically to identify enemy archetypes, highlighting the backend AI engineering over art.
* **Audio:** No external audio used.
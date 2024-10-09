<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/TropicalTacToe-repository-open-graph.png" /> </p>

# Tropical Tac Toe
## Summary
*Tropical Tac Toe* is a small video game project made in the span of around 4 days.
I developed this project to hone my Unity development skills and demonstrate my learning progress to others.

This project covers numerous aspects of video game development such as artificial intelligence (AI), settings & audio management, controller support, and local co-operative play.

You can download the game from the [Releases](https://github.com/Dunnatello/TropicalTacToe/releases) section or [itch.io](https://dunnatello.itch.io/tropicaltactoe).

## Game Menus
<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Main%20Menu.png" width="750"></img></p>
<p align="center"><b>Figure 1:</b> The main menu features a tic tac toe board with buttons that integrate into the design.</p>

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Settings.png" width="750"></img></p>
<p align="center"><b>Figure 2:</b> Players can adjust display and audio settings.</p>

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Game%20Modes.png" width="750"></img></p>
<p align="center"><b>Figure 3:</b> Multiple game modes are included with easily readable buttons.</p>

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Quit%20Game%20Prompt.png" width="750"></img></p>
<p align="center"><b>Figure 4:</b> A quit prompt is used to prevent accidental game closes with controllers.</p>



https://github.com/user-attachments/assets/fa7c2fea-9abc-41b8-82a1-17dbe50d627b
<p align="center"><b>Video 1:</b> Players can adjust display and audio settings trivially.</p>


## Features
### Co-Op Play
Players can play against other friends by using the local cooperative game mode. This mode swaps turns between players and allows two players to play on the same computer.

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Local%20Co-op.png" width="750"></img></p>
<p align="center"><b>Figure 5:</b> Text elements are used to indicate the current player's turn.</p>

https://github.com/user-attachments/assets/b0191915-d232-4a00-8bbf-6bb927789a93
<p align="center"><b>Video 2:</b> Players can alternate turns in the local co-op game mode.</p>

### Player vs. Bot
Players can select between several bot personalities that have different skillsets.
The bots are progressively more challenging since their performance is dictated by several factors:
- <b>Mistake Chance</b> - Chance for a bot to make a mistake and choose the wrong move.
- <b>Randomness Chance</b> - Chance for the bot to randomly select a move instead.
- <b>Lookahead Depth</b> - Determines how far the bot will plan into the future.
- <b>Reaction Time</b> - Bots will react with a delay similar to their skill level. 
Easier bots are simulated to take longer to "think" while challenging bots will make their decisions almost instantly.

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Bot%20Information.png" width="750"></img></p>
<p align="center"><b>Figure 6:</b> Bot information is shown to ensure that players understand the difficulty changes between bot profiles.</p>


Players of all skill levels will be able to enjoy the experience by having bots with different traits.

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Player%20vs%20Bot.png" width="750"></img></p>
<p align="center"><b>Figure 7:</b> Bot profile appearances are designed to be different than player profiles.</p>

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Bot%20Wins.png" width="750"></img></p>
<p align="center"><b>Figure 8:</b> Bot names are displayed on the game over screen if the player loses.</p>

https://github.com/user-attachments/assets/cf1d0c85-75c2-4bda-8b86-52e78e270409
<p align="center"><b>Video 3:</b> Multiple bots are included to suit all skill levels.</p>



https://github.com/user-attachments/assets/b6892d3e-98da-4c28-b6f9-88e918f1dd01
<p align="center"><b>Video 4:</b> The highest level bot still has a chance of making mistakes, but it is more likely to win or scratch the game.</p>

### Special Effects
<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Win%20Line.png" width="750"></img></p>
<p align="center"><b>Figure 9:</b> A transition effect is used to display win lines so that players know when the game ends.</p>

<p align="center"><img src="https://github.com/Dunnatello/TicTacToe/blob/main/GitHub%20Readme%20Data/Images/Win%20Special%20Effects.png" width="750"></img></p>
<p align="center"><b>Figure 10:</b> A confetti explosion effect is used when the player wins.</p>

## Lessons Learned
### Minimax Algorithm
In this project, I learned how to implement the Minimax algorithm to find the best moves for the AI bots. 

Initially, the algorithm was too perfect and would have been almost impossible for players to compete against.
This would not have been an fun experience since players should have the opportunity to win even against challenging opponents. 


Therefore, after implementing strategies to add variation to the AI's decisions, such as the max depth and mistake chance gameplay elements, the game became more engaging as a result.
### Text Effects
I also learned how to implement a wavy text effect on TextMeshPro text elements by modifying the vertices of each character and mapping the characters to the sine wave.
The effect complements the tropical theme of the project, so it resulted in a nice visual effect.

### User Interface Design
This project also gave me the opportunity to polish my user interface design skills. I continously iterated over numerous designs until I achieved the final version.
## Future Considerations
### Peer-to-Peer Multiplayer
I did consider adding an additional game mode so that players could play online with other players. However, after researching the various multiplayer frameworks such as Unity Relay and Mirror, I decided against implementing multiplayer.

I did not want to incur any server costs while developing this small project, so I decided not to pursue this path at this time.

However, in the future, I could add multiplayer support since the data that needs to be synched between both clients is:

- Current Player's Turn (`integer` value)
- Current Player's Move (`integer` value (`0` to `8`))
- Player Names (two `string` values)

This would result in minimal server bandwidth since the data only needs to be shared once a turn ends, so a traditional server structure could be useful.

I was considering using Unity Relay or Mirror for peer-to-peer networking, but Unity Relay relies on both players connecting to Unity's servers and I did not want to use their server resources for a small demo application.

<i>(Additionally, I am not planning on monetizing this project, so incurring server costs would not be very wise!)</I>

I will be interested in learning more about Unity Relay in the future, but hopefully with a more relevant project that can take advantage of the service fully.

### Customizable Bots
Another idea that I could implement in the future is customizable bot profiles. Currently, there are 5 bot profiles, but I could add additional user interface sliders to allow players to customize the bot traits directly.

### Additional Game Modes
I could also introduce new game modes such as larger tic tac toe boards and powerup skills. However, this would require developing a system to dynamically generate tic tac toe boards.

## Conclusion
Developing *Tropical Tac Toe* has taught me a few new skills and allowed me to design, develop, and complete a project in a short time frame.

This project has helped me slightly overcome my struggles with overambition and allowed me to develop a fully featured project that I hope others will enjoy/find informative.
## Credits
### Game Design & Development
Dunnatello
### Third Party
#### Music
"Verano Sensual" Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 4.0 License
http://creativecommons.org/licenses/by/4.0/

"Arroz con Pollo" Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 4.0 License
http://creativecommons.org/licenses/by/4.0/

"Beachfront Celebration" Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 4.0 License
http://creativecommons.org/licenses/by/4.0/

More music by this artist can be found [here](https://incompetech.com/).

#### Sounds
<b>rocketpancake</b> - [Mission Successful](https://freesound.org/people/rocketpancake/sounds/582970/)  
<b>Leszek_Szary</b> - [Game Over](https://freesound.org/people/Leszek_Szary/sounds/133283/)  
<b>eqylizer</b> - [Button Hover Click](https://freesound.org/people/eqylizer/sounds/623990/)  
<b>Christopherderp</b> - [Video Game Menu Button Click](https://freesound.org/people/Christopherderp/sounds/342200/)  
<b>BeezleFM</b> - [Item Sound](https://freesound.org/people/BeezleFM/sounds/512138/)  

#### Game Assets
##### Free
<b>mob-sakai</b> - [mob-sakai/ParticleEffectForUGUI](https://github.com/mob-sakai/ParticleEffectForUGUI)  
<b>Catlands Games</b> - [9 Free Backgrounds](https://assetstore.unity.com/packages/2d/environments/9-free-backgrounds-285183)  
##### Paid
<b>Archanor VFX</b> - [Super Confetti FX](https://assetstore.unity.com/packages/2d/environments/9-free-backgrounds-285183)  

#### Font
[Montserrat](https://fonts.google.com/specimen/Montserrat)

# Tropical Tac Toe
## Summary
*Tropical Tac Toe* is a small video game project made in the span of around 4 days.
I developed this project to hone my Unity development skills and demonstrate my learning progress to others.

This project covers numerous aspects of video game development such as artificial intelligence (AI), settings & audio management, controller support, and local co-operative play.
## Features
### Co-Op Play
Players can play against other friends by using the local cooperative game mode. This mode swaps turns between players and allows two players to play on the same computer.

### Player vs. Bot
Players can select between several bot personalities that have different skillsets.
The bots are progressively more challenging since their performance is dictated by several factors:
- <b>Mistake Chance</b> - Chance for a bot to make a mistake and choose the wrong move.
- <b>Randomness Chance</b> - Chance for the bot to randomly select a move instead.
- <b>Lookahead Depth</b> - Determines how far the bot will plan into the future.
- <b>Reaction Time</b> - Bots will react with a delay similar to their skill level. 
Easier bots are simulated to take longer to "think" while challenging bots will make their decisions almost instantly.

Players of all skill levels will be able to enjoy the experience by having bots with different traits.

## Lessons Learned
### Minimax Algorithm
In this project, I learned how to implement the Minimax algorithm to find the best moves for the AI bots. 

Initially, the algorithm was too perfect and would have been almost impossible for players to compete against.
This would not have been an fun experience since players should have the opportunity to win even against challenging opponents. 


Therefore, after implementing strategies to add variation to the AI's decisions, such as the max depth and mistake chance gameplay elements, the game became more engaging as a result.
### Text Effects
I also learned how to implement a wavy text effect on TextMeshPro text elements by modifying the vertices of each character and mapping the characters to the sine wave.
The effect complements the tropical theme of the project, so it resulted in a nice visual effect.

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

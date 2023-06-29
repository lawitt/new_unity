# Clever Paws: Defence for the vixen - Unity_project_2023

## Game structure
We have coded a jump game with 3 levels. Initially the player can decide for a color of his player. The player in the shape of a fox then has 3 lives to master each of the levels. The fox's goal is to find its way through the forest (later on a field) by jumping from platform to platform. Some of these platfroms move from side to side, so that the fox has to decide for the right moment to jump on them. 

The player has to reach the next level before the time runs up. On his way he encounters different enemies. In the first level he comes across eagles which he has to dodge from or fight against by shooting bullets at them. During the second level he additionally has to watch out for the tractors not to running him over. In the third level there are rifles pointed at him, so he has to watch out for the flying bullets. When the player anyway collides with one of the enemies he loses one of his lives. If the lives are at 0 or the time is up the game is over. 

There is also the option to collect a protective shield which prevents the player from losing lives when colliding with enimies. The time until the protection expires is visible by the health bar. Furthermore the fox can catch his prey - a bird - which increases his lives by one. To reach the next level a chest must be collected which is located on the highest platform of each level. The final reward for the fox is to be reunited with his vixen.

## How to play
Initially a color for the fox can be selected by pressing the repsective button. Pressing 'Start' then lets the game begin. The fox can be moved to the left and right by pressing the respective arrows. Furthermore bullets can be fired pressing the key 'X'. 

## Functionalities
* menu
  * option to change the color of the player
  * screens before, between and after scenes to explain the new functionalities and manage the navigation through the levels

* player
  * moving from left to right
  * jumping
  * shooting bullets

* levels
  * the game is seperated in 3 levels with different features
  * the background and the speed of the animals changes to match the current level

* time
  * to add some time pressure to the game we included a timer restricting the player in the time he is allowed to take per level

* platforms
  * stable platforms
  * platforms moving from side to side
  * arrangement of platforms becomes more difficult to mangage with increasing levels

* enemies
  * level 1-3: eagles falling from the sky 
  * level 2: tractors driving on platforms
  * level 3: riffles shooting bullets inbetween the platforms (with increasing speed further up)

* items
  * protective shield which prevents player from loosing lives until the health bar ran out
  * birds as prey to increase lives by one

## Issues
* general
  * problems with making the Unity Editor compatible with Unity Hub -> we ended up doing the coding on only of our computers because we couldn't resolve the issue on the other
  * problems with pushing our code to github: first pushing wasn't working at all, that is why we don't have versions of the first prototypes in our repository, then we were able to push it for a couple of days and for the last 3 days we were able to commit the repository but not to push it

* coding 
  * tractors stopping when jumping on them
  * initially the idea was to have the moving platforms stop as soon as the player landed on them, but after the stopping they weren't considered as objects the player could jump on
  * finding a way to pass over the chosen color of the fox to the next level
  * sudden change of position of life bar whenever starting the game in full mode

# Clever Paws: Defence for the vixen - Unity_project_2023

## Game structure
We have coded a jump game with 3 levels. The player is a fox who initially has 3 lives. As the fox finds its way through the forest (later on the field) by jumping from platform to platform. Some of these platfroms move from side to side, so he has to decide for the right moment to jump on them. He has to reach the next level before the time runs up. On his way he encounters different enemies. The enemies are eagles, tractors and rifles which he has to dodge from or fight against by shooting his bullets at them. When the player anyway collides with one of the enimies he looses one of his lives. If the lives are at 0 or the time is up the game is over. There is also the option to collect a protective shield which prevents the player from loosing lives when colliding with enimies. The time until the protection expires is visible by the health. Furthermore the fox can catch his prey - a bird - which increases his lives by one. To reach the next level a chest must be collected which is located on the highest platform of each level. The final reward for the fox is to be reunited with his vixen.

## How to play
The fox can be moved to the left and right by pressing the respective arrows. Furthermore bullets can be fired pressing the key 'X'. 

## Functionalities
* player
  * moving from left to right
  * jumping
  * shooting bullets
* levels
  * the game is seperated in 3 levels with different features
  * from one level to the other there appears a screen explaining the new features
  * the background and the speed of the animals changes to match the current level
* time
  * to add some time pressure to the game we included a hourglass restricting the player in the time he is allowed to take per level
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
* problems with pushing our code to github
* tractors stopping when jumping on them
* initially the idea was to have the moving platforms stop as soon as the player landed on them, but after the stopping they weren't considered as objects the player could jump on
* not being able to add some of the assets since they were 3D in contrast to the others being 2D

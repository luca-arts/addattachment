# Shooting System

>In shooting system we take a closer look at the shooting mechanism. 
>We want to child to be seated, yet have the feeling to be participating in a real competition
>We want to be able to influence the performance of the child when needed

-   Necessary to be seated and not to move too much 
	-   EEG readings otherwise compromised

## Overview

I have one main concepts in mind: 

- the slingshot

### Slingshot

The player is seated in some sort of chair, in front of you there's a large slingshot.

When it's your turn to shoot, a ball appears next to you. You grab it and attach it to the slingshot. 

Once this is done, you can pull the slingshot and shoot it. The harder you pull, the harder the ball flies.
? Bart Simpson Slingshot ?
![slingshot](./imgs/slingshot.jpg)

On the other side of the room, there are either pipes or trash nets which serve as [[targets]] for the balls. #TBD

![pipes](./imgs/pipes.jpeg) ![buckets](./imgs/blikvanger.jpg)

<<<<<<< HEAD:docs/architecture/game_elements/shooting system.md
#### shooting
- assistance: 
=======
#### Shooting

- assistance: difficulty level?
>>>>>>> 0026cae5192f3e64703937b6dedad855577db1ea:docs/architecture/game_elements/shooting_system.md
	- how will the NPC be assisted
		- if the assistance is allowed for the real player in config file, then we make sure the NPC scores less/badly
	- how can the player be assisted?
		- If the ball is in reach of goal AND assistance is allowed (in config file), then we aid the trajectory of the ball.
- Have an assisting lineray showing were the ball would approx fly?

#### Scoring

Having the ball in the correct target gives 1 point.

Depending on how fast you can score, you get an extra point?

## Assets

### Slingshot

we need a slingshot with which we can interact

### Balls

colored balls, perhaps taking their color only slowly?

Or changing color after time? 

! We want to be able to steer the performance of the child. I suggest we have some assistive trajectory change when we want to help the child.

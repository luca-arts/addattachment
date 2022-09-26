# Score Board

>We're constantly showing a score board in the VR environment.

![scoreboard](scoreboard.jpg)

After a trial round (5 consecutive throws for NPC & player) we update the screen. First a particle is launched drawing the attention to the board and we see our own position and that of other (visible and non-visible) NPCs switch places in the ranking.

## Assets

1x score board, non-interactable

### Scripts

1. update scoreboard script
	1. launches a particle firstly drawing the attention
	2. name positions swap place when needed
	3. a script capturing the scores of the visible players + generating random scores for other players on the board.

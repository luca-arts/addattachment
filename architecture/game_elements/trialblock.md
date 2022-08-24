# trialblock

A trialblock consists of x trials and optionally a [[test-trial]]

The block starts with:
- resetting the scores+[[score_board]]
- deciding the name of the trialblock:
	- block\_<date:DDMMYYYY>\_<starthour:HHMM>\_name
	- this name is used to set up the [[websocket]]
- if the last trial is running, show a "congrats" message when finishing instead restarting the [[trial]], also have the [[score_board]] more in view



## Start of a block

Perhaps to start a block, we have a short "arrival" moment, in which the child 'awakens' in the room. Before the lights go on, we already have some sounds. This is a transistion between the real, physical world and the new gameworld.

## assets

### gameplay manager

have a gameplay manager prefab, which has a *fixed* list of trials, fixed order and the contingency level per trial

### wake-up controller

This controller is launched as an event at the start of a block. Some sounds are played to get the mood on, the lights are down and are gradually launched. The player is welcomed with a screen, showing his opponent for the game and to wish him/her good luck.

### welcome screen
- Shows an image/gif of the other contestant
- wishes the player good luck
- has a button to start the game: `start`
# advice

>We get different responses based on the contingency level given to the current player. The quality (good or bad) of the advice is based on the contingency level. 
>We show the advice via 2 possible channels: visually & auditive.

## contingency level

We need to know the contingency level in the game, as the response is depending on the performance of the player.

We'll need 4 text files with possible answers:
1. Good performance, cheering (good) response
2. Good performance, take down (bad) response
3. Bad/mediocre performance, supportive (good) response
4. Bad/mediocre performance, dissappointed (bad) response

#TBD [[to discuss#contingency]]

## visualising the responses
- 2D vs 3D?
	- 2D:
		- a console showing on your HUD, showing the text response with the face of your mother next to it? [[caregiver#HUD instead of in-game conversation]]
	- 3D:
		- a text balloon appearing over the caregivers location, with some particles/bloom drawing attention

## auditive responses
optional?
Have someone record some responses?

## assets

### Response loader asset

This reads the `string` (response) from the current [[trial]] and loads it.
Once the mother is activated, we launch the visual response event.

### Visual response event
the response, loaded already, gets instantiated at the playing field, either near the mother (with some particles to draw attention), or via the HUD.

We let the response **dissappear** once the child has looked at the mother and x #TBD amount of seconds have passed.

We need a confirmation button!


### Auditive Response event

We have an audio player at the location of the mother. This way, it seams as if the audio is coming from her (if the child turns his/her head)
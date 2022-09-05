# caregiver
## overview
The caregiver is the mother of the child.
She gives good or bad [[advice]] based on the [[advice#contingency level]].
The caregiver should always be in peripheral sight of the child.


## looking at the caregiver
When the game is running, we note down the [[metrics#EOG]] of looking at the caregiver.

### game mechanic

**important** decide how direct we should look at the caregiver. #TBD
- explanation: we need to decide a boundary box where to look at. We can keep this close to her face, or her entire body, or a bit wider in case of not directly having contact? This could also give false positives on the other hand.

Do we want some other metric instead looking more/less at the mother? #TBD 

Do we want to give the player feedback that (s)he did look at the caregiver? #TBD 
- we could illuminate the caregiver ("standing in the spotlight")
- we could have a HUD appear and have the conversation there.

## score the caregiver
The player must indicate how much (s)he trusts the caregivers advice. 

A scoring is given on a scale of 0-10? #TBD

### game mechanic
We visualise a circle being formed by spreading the hands of the child. The bigger the circle, the more (s)he trusts the caregiver. In the middle of the circle we see the number change, number as well as color.
Think: you close your body when you don't trust a person, you open your arms when you trust this person more.
Pulling one of the triggers confirms the choice. 

## assets

#### rating bar
 see [[caregiver#game mechanic]]

### caregiver body
Female body, slightly to be adapted to the mothers figure?
Needs to be rigged for animation.
#TBD

### caregiver face
#### HUD instead of in-game conversation
perhaps interesting to have a 2D sprite showing the conversation? ![](MGS1_Codec_2.webp) 
Combination of the 3D world environment with a HUD (AR within VR) gives perhaps more emotional depth? ![HUD](hud.jpg)

#### styling the mother
the look of the mother: in-game vs out of the game #TBD:
	- out of unity:
		- Can we use volumetric scanning to capture the mothers face realistically enough?
		- Can we let the child firstly create his/her mothers face?
			- this could be done outside of VR, lowering the bar to enter the VR environment **YET** This means we have to recompile each time, raising the bar for errors?
	- in-game:
		- a selection mechanism in which the child can choose hairstyles and such. Could work in a non-realistic style.
		- Attention: this could take more time in-game?

## animation
I think a lot of focus can be put in the animation of different emotions of the face. 

How can we create attention to a certain emotional view?
- only facial expressions?
- body language?
	- recordings via mocap?

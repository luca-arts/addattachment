# overview of all prefabs

## imports

Make sure you import the Tobii.XR and PicoXR SDK packages

## list


### gameSetupPrefab

a prefab which is partly directed by the child, partly by the researchers. (do we want this to be decided upfront?)

Also the caregiver can be shaped via this prefab? (if the child gets to form the caregiver)

### stateManagerPrefab

1. keeps track where we are in a trial:
   1. `preTrial`:
   2. `Trial`
   3. `endTrial` 

### trialListPrefab:
1. a list of all upcoming trials
    1. each trial is calculated according to `public int contingencyLevel` to have a distribution of good and bad trials.
       1. the `trialListPrefab` dictates the [caregiver](#caregiverprefab) out of which lists she should be giving a response if activated.
       2. the `trialListPrefab` decides if the upcoming trial will be 
          1. easy/difficult for competition (and level of NPCs)
          2. exclusion/normal game for ostracity
2. keeps track of current trial via `private int currentTrial`
   1. if a `nextTrial` signal is given, `currentTrial` goes up if not last trial
      1. we store the important values in 'playerprefs': [playerprefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) or via a singleton: [singleton](https://stackoverflow.com/questions/67067412/unity-reset-score-to-0-on-replay)
   2. otherwise we show an endImage

### caregiverPrefab:
1. a model with animation rigging
2. public bool `canBeActivated`: makes it possible to activate the caregiver
   1. if `practicalSetup` & `preTrial`: [caregivers](#caregiverprefab) `canBeActivated` is set to True until `startTrial` is activated OR `hasBeenActivated` is set to true
   2. if `emotionalSetup` & `postTrial`: [caregivers](#caregiverprefab) `canBeActivated` is set to True until `nextTrial` is activated OR `hasBeenActivated` is set to true
4. public bool `isActivated`: 
   1. when activated the caregiver reads a random line of one of both [responseLists](#responselistprefab) according to the `contingencyMode`
   2. also private bool `hasBeenActivated` gets set to true UNTIL `nextTrial` signal is given.
5. two versions: practical & emotional:
   1. four differing lists of possible responses.
   
### responseListPrefab
1. we need four lists:
   1. emotional responses:
      1. supportive
      2. non-supportive
   2. practical responses:
      1. good advice
      2. bad advice
2. these lists can be csv format, so they can be maintained outside of unity
3. we have a function returnResponse(supportType, goodOrBadResponse) which returns a random string from the corresponding list.

### scoreBoardPrefab

1. only necessary in [competition](#competition)
2. has three variables: one for each player
3. if `endTrial` signal is given the score is updated for each player 
   1. An animation is shown indicating the ranking of the child.

### caregiverScoringPrefab

1. a 2D image being presented in which the child must indicate on a line how much (s)he trusts the caregiver.
2. the score is saved via the [saveMetricsPrefab](#saveMetricsPrefab)
3. 

### saveMetricsPrefab

a prefab which has one/multiple files open to write to them

### text balloon

1. a 3D balloon, oriented towards the player
2. should show text very clearly
3. show some particles to draw attention?

## ball

the ball has a state machine:
1. being grabbed
	1. the ball is interactable by a player
	2. the ball changes to this state when in a certain radius of the player and a raycast hits 
2. being attached
	1. the ball is parented to a player's hand
	2. the ball changes to this state when collided with the players hand
	3. the player does not look anymore to the ball itself. (if the ball's parent is itself or a child of itselves, don't look)
3. being thrown
	1. by an NPC: via slerp
		1. after x time, at y speed
	2. by the player: via XR rig
		1. with assistance if needed (boolean or floating range of support)
		2. 
4. being idle
	1. can be attracted if close enough?
	2. should be destroyed and respawn in **a** players hand after x time
	3. a ball gets in the idle state if the child did throw the ball and it's not close enough for the other players to attract the ball.



### Login screen prefab
When the child enters the game for the first time, we need to show a text block in which all steps are explained.

### chooseTeamPrefab
child gets to see in-game menu to choose team from, this is a screen that is fixed in position, the child can look away from it towards the caregiver.
if this is shown, no players should be on the field.

**Sound from [Zapsplat.com](https://www.zapsplat.com)**




## Issues

when parenting a ball, strange things happen. I think it's primarily because the ball was moving before and I've parented it with keeping the location. Yet this does probably NOT stop the movement due to the mass of the object? therefore the ball can be at large distances instead of attached to the hand (as intended)


Project settings ==> Player ==> Scripting Define Symbols ==> DEFINE_NAME ==> #if DEFINE_NAME #endif possible!

set all environment things to a layer and lock it

[System.Serializable] boven een class maakt dat je niet monobehavior component kan scripten

[colliders overview!](https://docs.unity3d.com/Manual/CollidersOverview.html)

preferences ==> general ==> Script changes while playing

[tooltip attributes](https://docs.unity3d.com/ScriptReference/TooltipAttribute.html)


[Slerp](https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html)



### questions

data bijhouden: 1 grote file of liever per topic aparte file, in 1 folder per kind?




TODO: UI scherm aan de zijkant waarop je van scene kunt switchen?

## TODO contingentie aanpassen

statemanager: nu emotional vs practical , maar ook al competition vs ostracity?


contingentie: wat mama zegt en of het goed of fout is

isGoodTrial mag random zijn
maar isGoodResponse is gelinkt aan het advies hier op


tekst: zwevend in ruimte bij zorgfiguurn + pijltje naar de mond

licht laten uitgaan bij eindigen?





sporthall: achtergrond extra spelers + geluiden

supporters aan de zijkant?


**status**: checken of alle prefabs goed staan in beide scenes, kunnen we switchen?
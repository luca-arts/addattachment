# overview of all prefabs

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

### text balloon

1. a 3D balloon, oriented towards the player
2. should show text very clearly
3. show some particles to draw attention?


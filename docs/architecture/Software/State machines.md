# State Machines

```plantuml
[*] --> Start
EndOfGame --> [*]
state Start

Start --> TrialState.TrialIntro
Start --> BallState.BallInit
Start --> TrophyState.TrophyInit
Start --> CaregiverState.Idle

state TrialState {
	state TrialIntro : start countdown \r\n set position of targets \r\n hold targets
	state PreTrial : Reset players score \r\n set BallState to init \r\n set movement targets
	state Trial : trialIsRunning
	state PostTrial : Hold Targets \r\n if trophy given, caregiver must give feedback \r\n gets skipped if tutorial scene \r\n on exit: trialnr++
	TrialIntro --> PreTrial 
	PreTrial --> Trial : startTrial signal

	Trial --> PostTrial : endTrial signal
	PostTrial --> PreTrial : restart

	PostTrial --> EndOfGame 
}

state BallState {
	state BallInit : ""
	state BallPrep : Set scoring chances
	state BallCalcImpact : Check if we did hit the right thing
	state BallWaiting 
	state BallLaunch 
	BallInit --> BallWaiting : ""
	BallWaiting --> BallPrep : if trial is running
	BallPrep --> BallLaunch : ball = grabbed
	BallLaunch --> BallCalcImpact : ballDidHit
	BallCalcImpact --> BallInit : end of trial
	BallCalcImpact --> BallWaiting : not all balls have been shot
}

state TrophyState {
	TrophyInit --> TrophyAppear : pretrial signal
	TrophyAppear --> TrophyWaiting : trophy did appear

	TrophyWaiting --> Giving : !trialIsRunning
	Giving --> Cooldown : once trophy given to winner
	Cooldown --> TrophyAppear : if not the end of triallist
	Cooldown --> EndOfGame : no more trials
}

state CaregiverState {
	Idle --> Feedback : mustGiveFeedback
	Feedback --> FeedbackConfirm : if feedback spoken
	FeedbackConfirm --> Scoring : confirmed
	Scoring --> Idle : scored + confirmed
}
PreTrial -[#blue]-> BallInit
PreTrial -[#blue]-> TrophyInit
TrophyWaiting -[#blue]-> Trial : start Trial
Giving -[#red]-> Feedback : trophy is given
PostTrial -[#red]-> Giving 
Scoring -[#red]-> PostTrial : restart
BallCalcImpact -[#green]-> PostTrial : End of trial



```
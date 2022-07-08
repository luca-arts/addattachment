# Add Attachment
## project intro

<elevator pitch>

## table of contents

```toc 
style: 
	number 
	min_depth: 1 
	max_depth: 6 
```


## Game Flow

### high level flow

![game overview](./imgs/game_overview.png)

We want to induce competitive stress for a child and monitor his/her response.  

A [[trial]] is run a couple of times in a row, forming a [[trialblock]]

During a trial, we measure different [[metrics]]

- [[shooting system]]: In a trial, a child is seated in which he can shoot a ball with a giant slingshot towards three pipes. 

- [[targets]]: These pipes try to suck the ball towards them. 

- [[reward_system]]: When we shoot the ball in the correct hole, we get some points.  

Alternating with us, another [[NPC_player]] shoots as well, and we see how (s)he performs.  

After 5 shots for both players, the trial is finished, and the results are shown on the [[score_board]]. 

The [[caregiver]] gives feedback.  

After this, you can [[caregiver#score the caregiver]]. 

A [[trial#count-down timer]] indicates that a new trial will start, or, if we are at the end, a closing screen will be shown.

## timeline

## sound design

## visual style

## architecture

Unity app running on android device

on a separate computer:
- have a python websocket to capture the data coming from unity & store it
	- also use this websocket to set the name of the player?
- the EEG data export
- the GSR data export 
- monitor what the player sees? [link](https://sdk.picovr.com/docs/FAQ/chapter_twentyseven.html)
- 

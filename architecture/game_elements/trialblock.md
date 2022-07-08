# trialblock

A trialblock consists of x trials.

The block starts with:
- resetting the scores+[[score_board]]
- deciding the name of the trialblock:
	- block\_<date:DDMMYYYY>\_<starthour:HHMM>\_name
	- this name is used to set up the [[websocket]]
- if the last trial is running, show a "congrats" message when finishing instead restarting the [[trial]]

## assets
have a gameplay manager prefab, which has a *fixed* list of trials, fixed order and the contingency level per trial
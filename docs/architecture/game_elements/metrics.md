# metrics

>in this project, we'll get to record differing parameters.

In order to get an overview, we'll list them in this file as they get decided throughout the research project.

|metric|type|how to calculate/record|sensor|in-game or data processing|
|---|---|---|---|---|
|engagement ball|flag|if a child always shoots the ball immediately away, or is showing no interest at all in the ball|VR|in-game|
|brain activity| EEG| EEG headset|EEG|in-game start and stop the recording|
| response read time| VR||||
| start of new trial| VR|||
| eye tracking of response?| EOG||


## metrics transfer
the VR application will be running on the android device. Either we try to send all data wirelessly/via usb cable to the attached computer (Need to open port?)
Or we try to save the data on the VR headset and later transfer it to the server.
I prefer transmitting it via a websocket/MQTT.
#POC

## metrics folder

structure:
- per child we have a folder
- in the folder we have:
	- two folders for each block
	- in each block:
		- a metric file for the EOG data
		- a metric file for the EEG data
		- a metric file for the GSR data
		- a response file for the caregiver scorings
		- a setup file for each trial
		- a file from KUL with their questionnaires.

The unity application should be the master, the EEG (python script with LSLMarker stream) and GSR (openframeworks+ LSLMarker stream) are masons.


# decisions

## EOG
We put some objects on the [[Unity_layers#eye]]. These metrics we store per trial in the metrics file.

### metrics of EOG
Per trial:
- per contact:
	- when did the child look at the caregiver?
	- for how long?
- given a minimum time between two consecutive 'looks', how often did the child look at the caregiver?
Per block of trials:
- do we need some metric? These can be deducted I believe out of the trials

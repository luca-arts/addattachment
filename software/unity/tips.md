# tips

[animation rigging to get more interactive players](https://www.youtube.com/watch?v=T7AdzwW7n2I)

[animation rigging medium](https://medium.com/nerd-for-tech/tip-of-the-day-ik-101-in-unity-3f79c42ae0ce)

[create a text sign (2D)](https://www.youtube.com/watch?v=ZVh4nH8Mayg)

[create a text sign (3D)](https://www.youtube.com/watch?v=GuWEXBeHEy8)

[state machine in unity](https://www.youtube.com/watch?v=Vt8aZDPzRjI)

[writing unit tests](https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing)



## unity and ubuntu and picoVR

1. Installing unity on Ubuntu 22.04 gave some issues, you need to download the hub via flatpack, not the way they advice! [link to download archive](https://unity3d.com/get-unity/download/archive)
2. to get the Pico VR device recognized on ubuntu 22.04, I had to install adb (`sudo apt install -y adb` ) and then restart the server:
	```bash
	sudo adb kill-server
	sudo adb start-server
	```
	After this, I could find the device in Unity.
3. Make sure to follow the instructions on the player settings to :
	1. enable PicoXR
	2. have a high enough version of android
	3. use IL2CPP instead of mono
	4. build for ARM64

 

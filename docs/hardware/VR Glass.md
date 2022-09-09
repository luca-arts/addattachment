# Pico Neo Eye 3 Pro

[product link](https://www.picoxr.com/us/neo3.html)

# eye tracking

Tobii tracking is added to the device

## connecting to second screen

Via displayport cable

## Unity development for Picon Neo Eye 3 Pro

### prerequisites

In unity you need to add next packages manually, via "window -> package manager -> add from disk":
- [Pico Unity Integration SDK ](https://developer-global.pico-interactive.com/sdk)
- [Tobii SDK](https://vr.tobii.com/sdk/downloads/)

Next adapt following settings:

1. enable PicoXR
2. have a high enough version of android
3. use IL2CPP instead of mono
4. build for ARM64
5. Make sure input system is "Both" (old and new)
6. install package "unity inputsystem"
7. install package XR Interaction toolkit: [link](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.1/manual/installation.html)
	1. Import the Starter Assets!
8. In "player settings", make sure underneath "XR plugin mgmt" PicoXR is enabled

> Tip: visit [this link](https://vr.tobii.com/sdk/develop/unity/getting-started/pico-neo-3-pro-eye/) to get started

### Set up VR space

Check [this link](https://developer-global.pico-interactive.com/document/unity)


### VR Grabbable

**Releasing an object**
Use the "Selected Exited" event to release an object. (create a function and attach it)

**showing trajectory**


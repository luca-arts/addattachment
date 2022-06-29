# emotibit

[github]()



## installation
### streaming software openframeworks
https://github.com/EmotiBit/EmotiBit_Docs/blob/master/Getting_Started.md

1. install openframeworks 0.11.0 (NOT 0.11.2)
2. clone all addons to the correct folder
3. install QT creator to make debugging easier
	1. I needed to install `libgtk-3-dev` 
4. the LSL library for linux is not available in the [ofxLSL](https://github.com/EmotiBit/ofxLSL). compile it from [here](https://github.com/sccn/liblsl)
	1. via cloning and running `standalone_compilation_linux.sh`
	2. copy `liblsl.so` it over to `<ofx dir>/addons/ofxLSL/libs/labstreaminglayer/lib/linux64`


## usage of oscilloscope

It captures the data from the EmotiBit in multiple channels and allows us to stream it via among others OSC.
As explained in [this page](https://github.com/EmotiBit/EmotiBit_Docs/blob/master/Working_with_emotibit_data.md#EmotiBit-DataParser)  we can stream the data to a computer via the oscilloscope tool. When clicking recording, we save the information to the SD card.
With the dataparser, this csv file can then be parsed into the different variables.

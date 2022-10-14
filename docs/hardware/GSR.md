# Emotibit

## Installation

<https://github.com/EmotiBit/EmotiBit_Docs>

## Approach

sends data via WiFi (credentials on SD card) ==> need for accessible network (no eduroam!)

three approaches: we capture the data via the emotibit oscilloscope. 

1. in the oscilloscope push record, so the data is saved on the SD card ==> highest resolution
2. We can transmit the data over OSC towards a python capture script. This can be tied to markers given from Unity?
3. We create an LSL marker stream from unity to annotate a stream.

	update:
	from [link](https://www.reddit.com/r/EmotiBit/comments/xlxmzs/timestamping_osc_data/) it came to my attention that there's **no** timestamp present in the OSC stream, which I was planning to capture. Timestamping is insecure. 
	**Conclusion** It is best to use the SD card to save the data!

### Example Data

example data can be found in folder [emotibit](./emotibit/)

### LSL Approach

to test you can generate an LSL stream via [ofxLSL](https://github.com/EmotiBit/ofxLSL#example-for-generating-marker-stream)


### starting via python?

check [link](https://github.com/EmotiBit/EmotiBit_Docs/blob/master/Working_with_emotibit_data.md#emotibit-data-types) to see if we can use serial commands?

also adapt the oscilloscope parameters: <https://github.com/EmotiBit/EmotiBit_Docs/blob/master/Working_with_emotibit_data.md/#EmotiBit-Oscilloscope> 

LSL converted markers can be found, after parsing the data in the** **\_LM** file, with their timings.

### Unity

add package via package mgr ==> add from git url: [LSL4Unity](https://github.com/labstreaminglayer/LSL4Unity)

Import their samples to see how to create a stream.

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class SimpleOutletTriggerEvent : MonoBehaviour
    {
        /*
         * This is a simple example of an LSL Outlet to stream out irregular events occurring in Unity.
         * This uses only LSL.cs and is intentionally simple. For a more robust version, see another sample.
         * 
         * We stream out the trigger event during OnTriggerEnter which is, in our opinion, the closest
         * time to when the trigger actually occurs (i.e., independent of its rendering).
         * A simple way to print the events is with pylsl: `python -m pylsl.examples.ReceiveStringMarkers`
         *
         * If you are instead trying to log a stimulus event then there are better options. Please see the 
         * LSL4Unity SimpleStimulusEvent Sample for such a design.
         */
        [SerializeField] private string StreamName = "DataSyncMarker";//LSL4Unity.Samples.SimpleCollisionEvent";
        [SerializeField] private string StreamType = "Markers";
        [SerializeField] private string StreamId = "12345";

        private StreamOutlet outlet;
        private string[] sample = {""};

        void Start()
        {
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 1, LSL.LSL.IRREGULAR_RATE,
                channel_format_t.cf_string, StreamId);// hash.ToString());
            outlet = new StreamOutlet(streamInfo);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (outlet != null)
            {
                sample[0] = "TriggerEnter " + gameObject.GetInstanceID();
                outlet.push_sample(sample);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (outlet != null)
            {
                sample[0] = "TriggerExit " + gameObject.GetInstanceID();
                outlet.push_sample(sample);
            }
        }
    }
}
```

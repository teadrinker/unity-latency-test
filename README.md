# unity-latency-test

I managed to sync visuals to audio well in a Unity build (based on AudioSource.time), I recorded the screen with a camera (and then manually counted the frames of the footage).

The delay on my machine is about 5 frames (at 60 fps), I guess ~1.5 frames of that is the Unity internal audio buffer (dspBufferSize / sampleRate from AudioSettings.GetConfiguration())
And I assume the remaining latency (~3.5 frames) is misc unity audio backend and/or windows OS/driver latency.

(Note that the actual audio latency is a bit larger, as I am comparing to the visual pipeline with vblank, which also has a delay. For audio vs visuals sync though, it is only the difference that matters)

If you know of a proper way to estimate the audio latency for good sync, please let me know (this is basically just hard-coded for my machine)

**If you want to play around with this, make sure to build it since the editor don't seem to care about vblank**

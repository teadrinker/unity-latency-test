# unity-latency-test

I managed to get proper sync based on AudioSource.time by recording the screen with a camera.
The delay on my machine is about 5 frames (at 60 fps), 1.5 frames of that I assume is the Unity internal audio buffer (dspBufferSize / sampleRate from AudioSettings.GetConfiguration())

The remaining I assume is misc unity audio backend and/or windows driver stack latency.

**If you want to play around with this, make sure to build it since the editor don't seem to care about vblank**

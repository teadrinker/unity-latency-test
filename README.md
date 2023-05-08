# unity-latency-test

I managed to get proper sync based on AudioSource.time by recording the screen with a camera.
The delay on my machine is about 5 frames (at 60 fps), 1.5 frames of that I assume is the Unity internal audio buffer (dspBufferSize / sampleRate from AudioSettings.GetConfiguration())

The remaining I assume is misc unity audio backend and/or windows driver stack latency.
Note that the actual delay is be a bit larger, as we are comparing to the visual pipeline with vblank, which also has a delay. (but for audio vs video sync, it is the difference that matters)

If you know of a proper way to estimate the latency for sync, please let me know (this is basically just hard coded for what I experience on my machine)

**If you want to play around with this, make sure to build it since the editor don't seem to care about vblank**

import os
import math
from aubio import source, pitch

# Convert frequency (Hz) to musical note
def freq_to_note(freq):
    if freq <= 0:
        return "N/A"
    A4 = 440.0
    notes = ['C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#', 'A', 'A#', 'B']
    # MIDI note number (A4 = 69)
    n = round(12 * math.log2(freq / A4)) + 69
    octave = n // 12 - 1
    note_name = notes[n % 12]
    return f"{note_name}{octave}"

def get_pitch(filename, win_s=4096, hop_s=512):
    # Open the audio file
    s = source(filename, 0, hop_s)
    pitch_o = pitch("default", win_s, hop_s, s.samplerate)
    pitch_o.set_unit("Hz")
    pitch_o.set_silence(-40)

    pitches = []
    total_frames = 0
    while True:
        samples, read = s()
        pitch_estimate = pitch_o(samples)[0]
        if pitch_estimate > 0:
            pitches.append(pitch_estimate)
        total_frames += read
        if read < hop_s:
            break
    if pitches:
        # Return median pitch to reduce noise
        pitches.sort()
        return pitches[len(pitches) // 2]
    return 0

def main():
    files = [f for f in os.listdir('.') if f.endswith('.ogg')]
    if not files:
        print("No .ogg files found in the current directory.")
        return
    for f in files:
        pitch_hz = get_pitch(f)
        note = freq_to_note(pitch_hz)
        print(f"{f}: {pitch_hz:.2f} Hz, Note: {note}")

if __name__ == "__main__":
    main()

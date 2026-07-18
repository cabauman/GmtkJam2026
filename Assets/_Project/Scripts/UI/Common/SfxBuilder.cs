using UnityEngine;
using UnityEngine.Assertions;

namespace GmtkJam2026
{
    public sealed class SfxBuilder
    {
        private AudioSource _source;
        private float _volume;
        private float _pitch;
        private Vector3? _position;

        public void Init(AudioSource source)
        {
            _source = source;
            Reset();
        }

        public SfxBuilder Reset()
        {
            _volume = 1f;
            _pitch = 1f;
            _position = null;
            return this;
        }

        public SfxBuilder WithVolume(float volume)
        {
            _volume = Mathf.Clamp01(volume);
            return this;
        }

        public SfxBuilder WithRandomPitch(float min = 0.9f, float max = 1.1f)
        {
            _pitch = Random.Range(min, max);
            return this;
        }

        public SfxBuilder AtPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public void Play(AudioClip clip)
        {
            Assert.IsNotNull(clip);

            _source.pitch = _pitch;

            if (_position.HasValue)
            {
                _source.spatialBlend = 1f; // 3D
                _source.transform.position = _position.Value;
            }
            else
            {
                _source.spatialBlend = 0f; // 2D
            }

            _source.PlayOneShot(clip, _volume);
        }
    }
}

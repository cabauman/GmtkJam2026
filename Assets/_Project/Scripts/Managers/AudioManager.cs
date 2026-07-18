using PrimeTween;
using UnityEngine;

namespace GmtkJam2026
{
    [DefaultExecutionOrder(-2000)]
    public sealed class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private int _sfxPoolSize = 8;

        private SfxBuilder[] _sfxBuilders;
        private int _sfxIndex;

        private void Awake()
        {
            _sfxBuilders = new SfxBuilder[_sfxPoolSize];

            for (int i = 0; i < _sfxPoolSize; i++)
            {
                var sourceObject = new GameObject($"SfxSource_{i}");
                sourceObject.transform.SetParent(transform);

                var source = sourceObject.AddComponent<AudioSource>();
                source.playOnAwake = false;

                _sfxBuilders[i] = new SfxBuilder();
                _sfxBuilders[i].Init(source);
            }
        }

        public SfxBuilder Sfx
        {
            get
            {
                SfxBuilder builder = _sfxBuilders[_sfxIndex];
                _sfxIndex = (_sfxIndex + 1) % _sfxBuilders.Length;
                return builder.Reset();
            }
        }

        public void PlaySfx(AudioClip clip)
        {
            Sfx.Play(clip);
        }

        public void PlayMusic(AudioClip clip, float duration = 1f)
        {
            if (_musicSource.clip == clip)
            {
                return;
            }

            Tween.StopAll(_musicSource);

            float halfDuration = duration * 0.5f;

            if (_musicSource.clip == null || !_musicSource.isPlaying)
            {
                _musicSource.clip = clip;
                _musicSource.volume = 0f;
                _musicSource.Play();
                Tween.AudioVolume(_musicSource, 1f, halfDuration);
                return;
            }

            Sequence.Create()
                .Chain(Tween.AudioVolume(_musicSource, 0f, halfDuration))
                .ChainCallback(() =>
                {
                    _musicSource.clip = clip;
                    _musicSource.Play();
                })
                .Chain(Tween.AudioVolume(_musicSource, 1f, halfDuration));
        }
    }
}

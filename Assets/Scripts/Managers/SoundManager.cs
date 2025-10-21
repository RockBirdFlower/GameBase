using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager
{
    private Transform _root;
    private AudioSource _bgm;
    private Queue<AudioSource> _sfxs = new();
    private int _sfxCount = 0;
    private const int _maxSfxCount = 40;
    private CancellationTokenSource _cts;

    public void PlayBgm(string bgmName)
    {
        if (_bgm == null)
        {
            _bgm = GameManager.Game.GetOrAddComponent<AudioSource>();
        }

        AudioClip clip = null;
        clip = GameManager.Resource.GetClip(bgmName);

        if (clip == null) return;

        _bgm.PlayOneShot(clip);
    }

    public void PlaySfx(string sfxName)
    {
        if (_root == null)
        {
            _sfxCount = 0;
            _root = new GameObject($"{Defines.ManagerType.SoundManager}").transform;
            _cts = new();
        }

        AudioClip clip = null;

        clip = GameManager.Resource.GetClip(sfxName);

        if (clip == null) return;

        AudioSource audio = null;

        if (_sfxs.Count > 0)
        {
            audio = _sfxs.Dequeue();
        }
        else
        {
            if (_maxSfxCount <= _sfxCount) return;

            GameObject clone = new GameObject($"{Defines.SoundType.Sfx}");
            clone.transform.SetParent(_root);
            audio = clone.AddComponent<AudioSource>();
            _sfxCount++;
        }


        if (audio == null) return;

        audio.PlayOneShot(clip);
        PlayDuration(audio, clip.length);
    }

    private async void PlayDuration(AudioSource sorce, float duration)
    {
        await Task.Delay(TimeSpan.FromSeconds(duration), _cts.Token);
        _sfxs.Enqueue(sorce);
    }

    public void Dispos()
    {
        _cts.Cancel();
        _cts = null;
        GameManager.Object.Destroy(_root.gameObject);
        _root = null;
        _sfxs.Clear();
    }
    
    
}

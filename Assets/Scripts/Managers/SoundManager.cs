using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager
{
    private Transform _root;
    private AudioSource _bgm;
    private Queue<AudioSource> _sfxs = new();
    private int _sfxCount = 0;
    private CancellationTokenSource _cts;
    private List<AudioClip> _bgmList = new();
    private float _sfxVolume = 1f;
    private float _bgmVolume = 1f;

    public void Init()
    {
        _sfxVolume = PlayerPrefs.GetFloat(Consts.SFX_VOLUME, 1f);
        _bgmVolume = PlayerPrefs.GetFloat(Consts.BGM_VOLUME, 1f);
        _bgm = Managers.Manager.AddComponent<AudioSource>();
    }

    public void SetSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat(Consts.SFX_VOLUME, volume);
        _sfxVolume = volume;
    }
    
    public void SetBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat(Consts.BGM_VOLUME, volume);
        _bgmVolume = volume;
        _bgm.volume = volume;
    }

    public void PlayBgmList(List<string> clipNames)
    {
        _bgmList.Clear();
        for (int i = 0; i < clipNames.Count; i++)
        {
            AudioClip clip = Managers.Resource.GetClip(clipNames[i]);
            if (clip == null) continue;
            _bgmList.Add(clip);
        }

        if (_bgmList.Count == 0) return;
        Managers.Coroutine.StartCoroutine(CoBgmListPlay(), true);
    }
    
    private IEnumerator CoBgmListPlay()
    {
        int idx = 0;
        while (_bgmList.Count > 0)
        {
            AudioClip clip = _bgmList[idx];
            _bgm.volume = _bgmVolume;
            _bgm.PlayOneShot(clip);
            idx = (idx + 1) % _bgmList.Count;
            yield return Managers.Coroutine.GetWfs(clip.length);
        }
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

        clip = Managers.Resource.GetClip(sfxName);

        if (clip == null) return;

        AudioSource audio = null;

        if (_sfxs.Count > 0)
        {
            audio = _sfxs.Dequeue();
        }
        else
        {
            if (Consts.MAX_SFX_COUNT <= _sfxCount) return;

            GameObject clone = new GameObject($"{Defines.SoundType.Sfx}");
            clone.transform.SetParent(_root);
            audio = clone.AddComponent<AudioSource>();
            audio.volume = _sfxVolume;
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
        Managers.Object.Destroy(_root.gameObject);
        _root = null;
        _sfxs.Clear();
    }
    
    
}

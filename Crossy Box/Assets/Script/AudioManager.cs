using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource duckSfxInstance;
    static AudioSource carSfxInstance;
    static AudioSource treeSfxInstance;
    static AudioSource tieSfxInstance;
    static AudioSource coinSfxInstance;
    static AudioSource gameOverSfxInstance;

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource duckSfx;
    [SerializeField] AudioSource carSfx;
    [SerializeField] AudioSource treeSfx;
    [SerializeField] AudioSource tieSfx;
    [SerializeField] AudioSource coinSfx;
    [SerializeField] AudioSource gameOverSfx;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => duckSfx.volume; }

    void Start()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        if (duckSfxInstance != null)
        {
            Destroy(duckSfx.gameObject);
            duckSfx = duckSfxInstance;
        }
        else
        {
            duckSfxInstance = duckSfx;
            duckSfx.transform.SetParent(null);
            DontDestroyOnLoad(duckSfx.gameObject);
        }

        if (carSfxInstance != null)
        {
            Destroy(carSfx.gameObject);
            carSfx = carSfxInstance;
        }
        else
        {
            carSfxInstance = carSfx;
            carSfx.transform.SetParent(null);
            DontDestroyOnLoad(carSfx.gameObject);
        }

        if (treeSfxInstance != null)
        {
            Destroy(treeSfx.gameObject);
            treeSfx = treeSfxInstance;
        }
        else
        {
            treeSfxInstance = treeSfx;
            treeSfx.transform.SetParent(null);
            DontDestroyOnLoad(treeSfx.gameObject);
        }

        if (tieSfxInstance != null)
        {
            Destroy(tieSfx.gameObject);
            tieSfx = tieSfxInstance;
        }
        else
        {
            tieSfxInstance = tieSfx;
            tieSfx.transform.SetParent(null);
            DontDestroyOnLoad(tieSfx.gameObject);
        }

        if (coinSfxInstance != null)
        {
            Destroy(coinSfx.gameObject);
            coinSfx = coinSfxInstance;
        }
        else
        {
            coinSfxInstance = coinSfx;
            coinSfx.transform.SetParent(null);
            DontDestroyOnLoad(coinSfx.gameObject);
        }

        if (gameOverSfxInstance != null)
        {
            Destroy(gameOverSfx.gameObject);
            gameOverSfx = gameOverSfxInstance;
        }
        else
        {
            gameOverSfxInstance = gameOverSfx;
            gameOverSfx.transform.SetParent(null);
            DontDestroyOnLoad(gameOverSfx.gameObject);
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying == true)
            bgm.clip = clip;

        bgm.loop = loop;
        bgm.Play();
    }

    public void PlayDuckSfx(AudioClip clip)
    {
        if (duckSfx.isPlaying == true)
            duckSfx.Stop();

        duckSfx.clip = clip;
        duckSfx.Play();
    }

    public void PlayCarSfx(AudioClip clip)
    {
        if (carSfx.isPlaying == true)
            carSfx.Stop();

        carSfx.clip = clip;
        carSfx.Play();
    }

    public void PlayTreeSfx(AudioClip clip)
    {
        if (treeSfx.isPlaying == true)
            treeSfx.Stop();

        treeSfx.clip = clip;
        treeSfx.Play();
    }

    public void PlayTieSfx(AudioClip clip)
    {
        if (tieSfx.isPlaying == true)
            tieSfx.Stop();

        tieSfx.clip = clip;
        tieSfx.Play();
    }

    public void PlayCoinSfx(AudioClip clip)
    {
        if (coinSfx.isPlaying == true)
            coinSfx.Stop();

        coinSfx.clip = clip;
        coinSfx.Play();
    }

    public void PlayGameOverSfx(AudioClip clip)
    {
        if (gameOverSfx.isPlaying == true)
            gameOverSfx.Stop();

        gameOverSfx.clip = clip;
        gameOverSfx.Play();
    }

    public void SetMute(bool v)
    {
        bgm.mute = v;
        duckSfx.mute = v;
        carSfx.mute = v;
        treeSfx.mute = v;
        tieSfx.mute = v;
        coinSfx.mute = v;
        gameOverSfx.mute = v;
    }

    public void SetVolumeBGM(float v)
    {
        bgm.volume = v;
    }

    public void SetVolumeSFX(float v)
    {
        duckSfx.volume = v;
        carSfx.volume = v;
        treeSfx.volume = v;
        tieSfx.volume = v;
        coinSfx.volume = v;
        gameOverSfx.volume = v;
    }
}

using UnityEngine;

public class RadioCaatingaScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicas;
    [SerializeField] private bool repetirPlaylist = true;

    private AudioSource audioSource;
    private int indiceAtual = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource não encontrado.");
            return;
        }

        if (musicas == null || musicas.Length == 0)
        {
            Debug.LogError("Nenhuma música foi adicionada na playlist.");
            return;
        }

        audioSource.playOnAwake = false;
        audioSource.loop = false;

        TocarMusicaAtual();
    }

    void Update()
    {
        if (!audioSource.isPlaying && audioSource.clip != null)
        {
            ProximaMusica();
        }
    }

    private void TocarMusicaAtual()
    {
        audioSource.clip = musicas[indiceAtual];
        audioSource.Play();
    }

    private void ProximaMusica()
    {
        indiceAtual++;

        if (indiceAtual >= musicas.Length)
        {
            if (repetirPlaylist)
            {
                indiceAtual = 0;
            }
            else
            {
                return;
            }
        }

        TocarMusicaAtual();
    }
}
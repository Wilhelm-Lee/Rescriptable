namespace Rescriptable.src;

public class Player : IPlayable
{
    private Playlist playlist;

    // Default Attribute
    private PlayMode mode = PlayMode.STOP_AFTER_THIS;
    private PlayingState playingState = PlayingState.STOPPED;
    private int index = 0;
    private int secondsPlayed = 0;

    public Player(Playlist playlist)
    {
        this.playlist = playlist;
    }

    public void Play(Song? song)
    {
        if (song is null)
        {
            Console.WriteLine("no song in songPlayer");
            return;
        }


        
        playingState = PlayingState.PLAYING;


        if ( secondsPlayed != 0 )
        {
            Console.WriteLine($"~~resume the song {song.GetIdentifier()} ~~");


            // 3min actually music player time
            Thread.Sleep(300 - secondsPlayed);

            // record secondsPlayed 


            Console.WriteLine($"~~End of the song {song.GetIdentifier()} ~~");
            return;
        }


        Console.WriteLine($"~~Listening the song {song.GetIdentifier()} ~~");


        // 3min actually music player time
        Thread.Sleep(300);

        // record secondsPlayed 

        Console.WriteLine($"~~End of the song {song.GetIdentifier()} ~~");
        return;

    }

    // Todo Pause Song
    public void Pause()
    {
        playingState = PlayingState.PAUSING;
    }


    // mode influence index, no handle index 
    //; and reset offset = 0;
    public void Next()
    {
        var loopIndex = index++ % playlist.GetSongList().Count;
        secondsPlayed = 0;
        this.Play(playlist.GetIndexSong(loopIndex));
    }


    // mode influence outside index
    //; and reset offset = 0;
    public void Prev()
    {
        int loopIndex = index++ % playlist.GetSongList().Count;
        secondsPlayed = 0;
        this.Play(playlist.GetIndexSong(index));
    }

    public void WindForward(int seconds)
    {
        // need song time
        secondsPlayed += seconds;
    }

    public void WindBackward(int seconds)
    {
        _ = seconds > secondsPlayed ? 0 : secondsPlayed -= seconds;
    }


    // +DeepCopy.
    public Playlist GetPlaylist()
    {
        return new Playlist(this.playlist.GetSongList().ToArray());
    }

    // +DeepCopy;
    public void SetPlaylist(Playlist playlist)
    {
        this.playlist = new Playlist(playlist.GetSongList().ToArray());
    }





}

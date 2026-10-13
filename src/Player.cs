namespace Rescriptable.src;

public class Player : IPlayable
{
    private Playlist playlist;

    // Default Attribute
    private PlayMode mode = PlayMode.STOP_AFTER_THIS;
    private PlayingState playingState = PlayingState.STOPPED;
    private int index = 0;              // [0, max-1];
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

            // record secondsPlayed time


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


    public void Next()
    {
        // remove elem of list index will be not invalid for song
        int maxSongNum = playlist.GetSongList().Count;
        index++;
        secondsPlayed = 0;
        playingState = PlayingState.STOPPED;


        // index still invariant but stop
        if ( mode == PlayMode.STOP_AFTER_THIS )
        {   
            index--;
            return;
        }

        // index == Max stop
        if ( mode == PlayMode.STOP_AFTER_LIST )
            if (index > maxSongNum - 1)
            {
                index = maxSongNum - 1;
                return;
            }

        // index invariant
        if ( mode == PlayMode.LOOP_ON_THIS )
            index--;

        if ( mode == PlayMode.LOOP_ON_LIST )
            index = index % maxSongNum;


        this.Play(playlist.GetIndexSong(index));
        return;
    }


    public void Prev()
    {
        // remove elem of list index will be not invalid for song
        int maxSongNum = playlist.GetSongList().Count;
        index--;
        secondsPlayed = 0;
        playingState = PlayingState.STOPPED;



        // index still invariant but stop
        if ( mode == PlayMode.STOP_AFTER_THIS )
        {
            index++;
            return;
        }
            
        // index == Max stop
        if ( mode == PlayMode.STOP_AFTER_LIST )
            if (index < 0)
            {
                index = 0;
                return;
            }

        // index invariant
        if ( mode == PlayMode.LOOP_ON_THIS )
            index--;

        if ( mode == PlayMode.LOOP_ON_LIST )
            index = index % maxSongNum;


        this.Play(playlist.GetIndexSong(index));
        return;
    }


    public void WindForward(int seconds)
    {
        // need obtainer song time
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

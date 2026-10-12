namespace Rescriptable;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Hello");
    }
}


/*
    Local media player.


    IPlayable:
        virtual Play, Pause, Next, Prev, FastForward, FastBackward

    Player : IPlayable
        PlayMode mode,  // the mode of playing during runtime.
        LoadPlayList(Playlist)
        implementations of Play, Pause, Next, Prev, FastForward, FastBackward

    PlayList <Song>:
        Song...

    Playlist -> backsongs <Song>

    Song:
        string filePath,  // to load the file onto memory from the disc.
        string identifier,  // purely identifying the song itself.

 */

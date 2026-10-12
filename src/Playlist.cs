namespace Rescriptable.src;

using System;
using System.Runtime.Serialization;


/*
 *
 *  Field
 *  private List<Song> songList
 *
 *  Constructor
 *  public Playlist(Song[] songs);
 *  public Playlist(Playlist playlist);
 * 
 *  Function 
 *
 *  public bool Add(Song song);
 *  public bool Add(Song[] songs);
 *  public bool Remove(Song song);
 *  public bool Remove(Song[] songs);
 *  public Song GetIndexSong(int index);
 *
 */


[Serializable]
public class Playlist : ISerializable
{
    private List<Song> songList = new();


    // Constructor
    public Playlist(Song[] songs)
    {
        this.Add(songs);
    }
    /* Copy the songs from another @Playlist. */
    public Playlist(Playlist playlist) : this(songs: playlist.GetSongList().ToArray())
    {
        // this.Add(playlist.GetSongList());
    }



    // +DeepCopy Song
    public List<Song> GetSongList()
    {
        return DeepCopy(this.songList);  
    }

    // DeepCopy
    private List<Song> DeepCopy(List<Song> songList)
    {
        List<Song> copyList = new();
        foreach( var song in songList )
        {
            copyList.Add(
                new Song (
                    song.GetIdentifier(),
                    song.GetAbsolutePath()
                )
            );
        }
        return copyList;
    }

 

    // public bool Add(Song song);
    // public bool Add(Song[] songs);
    // public bool Remove(Song song);
    // public bool Remove(Song[] songs);
    // public void show();  
    // public Song GetIndexSong(int index)

    // ---------------------- Method Implement

    /* Returns true on successful operations; false otherwise. */
    // repeat problem --> allow
    public bool Add(Song song)
    {
        if (song is null)
        {
            return false;
        }

        songList.Add(song);
        return true;
    }

    /* Returns true on successful operations; false otherwise. */
    // repeat problem --> allow
    public bool Add(Song[] songs)
    {
        if (songs is null)
        {
            return false;
        }

        foreach (var song in songs)
        {
            if (!this.Add(song))
            {
                Console.WriteLine($"Insert Failed after {song.GetIdentifier()}");
                return false;
            }
        }
        return true;
    }

    /* Returns true on successful operations; false otherwise. */
    // repeat probelm --> allow; remove one of them in forth
    public bool Remove(Song song)
    {
        if (song is null)
        {
            return false;
        }

        return songList.Remove(song);
    }

    /* Returns true on successful operations; false otherwise. */
    // repeat probelm --> allow; remove one of them in forth
    public bool Remove(Song[] songs)
    {
        if (songs is null)
        {
            return false;
        }

        foreach (var song in songs)
        {
            // class method
            if (!this.Remove(song))
            {
                Console.WriteLine($"Remove Failed after {song.GetIdentifier()}");
                return false;
            }
        }
        return true;
    }


    public Song GetIndexSong(int index)
    {
        return songList[index];
    }





    // Test
    public void show()
    {
        foreach (var song in songList)
        {
            Console.WriteLine(song.GetIdentifier());
        }
    }

    // https://www.google.com/search?client=firefox-b-d&q=C%23+ISerializable+GetObjectData
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(songList), songList);
    }
}


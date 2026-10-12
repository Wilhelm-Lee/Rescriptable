namespace Rescriptable.src;

public class Song
{
    private readonly string identifier;
    private readonly string path;

    /* Write a constructor for all of these three members. */
    public Song(string identifier, string absolutePath)
    {
        /* Song.identifier is made up by the file name. */
        this.identifier = identifier;
        this.path = absolutePath;
    }

    // Getter
    public string GetIdentifier()
    {
        return (string)this.identifier.Clone();
    }
    public string GetAbsolutePath()
    {
        return (string)this.path.Clone();
    }
}

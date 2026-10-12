namespace Rescriptable.src;

public interface IPlayable
{
    void Play(Song? song);
    void Pause();
    void Next();
    void Prev();
    void WindForward(int seconds);
    void WindBackward(int seconds);
}

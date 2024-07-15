namespace BananaAPI
{
  public class Group
  {
    public required int Id { get; set; }
    public List<string> Members { get; set; } = [];
    private readonly int MAX_COUNT = 3;
    public int Count = 0;

    public bool IsFull()
    {
      return Members.Count == MAX_COUNT;
    }

    public bool AddMember(string newMenber)
    {
      if (IsFull())
      {
        return false;
      }

      Members.Add(newMenber);
      return true;
    }

    public int Increment()
    {
      Count += 1;
      return Count;
    }
  }
}

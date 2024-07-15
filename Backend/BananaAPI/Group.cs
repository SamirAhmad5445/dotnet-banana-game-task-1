namespace BananaAPI
{
  public class Group
  {
    public required int Id { get; set; }
    public List<string> Members { get; set; } = [];
    private readonly int MAX_COUNT = 3;
    public int Count = 0;

    public bool AddMember(string newMenber)
    {
      if (Members.Count == MAX_COUNT)
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

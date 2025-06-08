public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TodoItem(int id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void MarkAsIncomplete()
    {
        IsCompleted = false;
    }
}
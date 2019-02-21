using System;

// Computer is an implementation of RoomItem
class Computer : RoomItem
{
    public Computer(string name, double x, double y, double width, double height, string type)
        : base(name, x, y, width, height)
    {
        Type = type;
    }

    public string Type { get; private set; }

    public override void Draw()
    {
        Console.WriteLine($"Draw Computer: {Name} {X} {Y} {Width} {Height}");
    }

    public override UndoMemento changeProperty(object state)
    {
        UndoMemento memento = new UndoMemento() { State = new Computer(this.Name, this.X, this.Y, this.Width, this.Height, this.Type) };
        X = x;
        Y = y;
        return memento;
    }

    public override void saveState(object state)
    {
        UndoMemento memento = new UndoMemento() { State = new Computer(this.Name, this.X, this.Y, this.Width, this.Height, this.Type) };
    }
}

// Table is an implementation of RoomItem 
class Table : RoomItem
{
    private string colour { get; set; }
    public Table(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Table: {Name} {X} {Y} {Width} {Height}");
    }
    public override UndoMemento changeProperty(object state)
    {
        return state as UndoMemento;
    }

}

// Chair is an implementation of RoomItem
class Chair : RoomItem
{
    public Chair(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override UndoMemento changeProperty(object state)
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Chair: {Name} {X} {Y} {Width} {Height}");
    }
}
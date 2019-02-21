abstract class Item
{
    public string Name { get; private set; }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Item(string name, double x, double y, double width, double height)
    {
        Name = name;
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public abstract UndoMemento changeProperty(object state);

    public void UndoChangeProperty()
    {

    }
    public abstract void saveState(object state);
    //{
    //    UndoMemento memento = new UndoMemento() { State = new Computer(this.Name, this.X, this.Y, this.Width, this.Height, this.Type) };

    //}
    public abstract void Draw();
}

abstract class HallItem : Item
{
    public HallItem(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }
}

abstract class RoomItem : Item
{
    public RoomItem(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }
}
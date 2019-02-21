using System;
using System.Collections.Generic;

class Room : HallItem
{
    public Room(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    // Can contain objects of difference implementations of RoomItem
    private List<RoomItem> roomItems = new List<RoomItem>();

    public void Add(RoomItem roomItem)
    {
        roomItems.Add(roomItem);
    }

    public void Delete(RoomItem roomItem)
    {
        roomItems.Remove(roomItem);
    }

    // Draw the room with all the items contained in it
    public override void Draw()
    {
        Console.WriteLine($"Draw Room: {Name} {X} {Y} {Width} {Height}");

        foreach (RoomItem roomItem in roomItems)
            roomItem.Draw();
    }

    public override UndoMemento changeProperty(object state)
    {
        throw new NotImplementedException();
    }
}

// MetalDetector is an implementation of HallItem 
class MetalDetector : HallItem
{
    public MetalDetector(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override UndoMemento changeProperty(object state)
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Metal Detector: {Name} {X} {Y} {Width} {Height}");
    }
}
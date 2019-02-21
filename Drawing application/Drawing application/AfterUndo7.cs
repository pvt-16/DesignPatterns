using System;
using System.Collections.Generic;
class UndoMemento
{
    public object State { get; set; }
    public Action<object> Command { get; set; }
}

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

    // Nested Class
    private class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    // The method to restore the object to previous state as well as perform operation
    private void UndoChangePosition(object state)
    {
        Position position = state as Position;
        X = position.X;
        Y = position.Y;
    }

    // The method to change the object state and perform operation but also externalize the previous state
    public UndoMemento ChangePosition(double x, double y)
    {
        UndoMemento memento = new UndoMemento() { State = new Position() { X = this.X, Y = this.Y }, Command = new Action<object>(UndoChangePosition) };
        X = x;
        Y = y;
        return memento;
    }

    // Nested Class
    private class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    private void UndoChangeSize(object state)
    {
        Size size = state as Size;
        Width = size.Width;
        Height = size.Height;
    }

    public UndoMemento ChangeSize(double width, double height)
    {
        UndoMemento memento = new UndoMemento() { State = new Size() { Width = this.Width, Height = this.Height }, Command = new Action<object>(UndoChangeSize) };
        Width = width;
        Height = height;
        return memento;
    }

    // To be overridden by each implementation to perform specific drawing
    public abstract void Draw();
}

abstract class HallItem : Item
{
    public HallItem(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }
}

class Hall
{
    // Can contain objects of different implementations of HallItem
    private List<HallItem> hallItems = new List<HallItem>();

    public void Add(HallItem hallItem)
    {
        hallItems.Add(hallItem);
    }

    public void Delete(HallItem hallItem)
    {
        hallItems.Remove(hallItem);
    }

    // Draw the hall with all the items contained in it
    public void Draw()
    {
        Console.WriteLine("Draw Hall");

        foreach (HallItem hallItem in hallItems)
            hallItem.Draw();
    }
}

// Each item to be added to the room must implement this class
abstract class RoomItem : Item
{
    public RoomItem(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }
}
// Room is an implementation of HallItem 
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
}

// MetalDetector is an implementation of HallItem 
class MetalDetector : HallItem
{
    public MetalDetector(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Metal Detector: {Name} {X} {Y} {Width} {Height}");
    }
}

// Computer is an implementation of RoomItem
class Computer : RoomItem
{
    public Computer(string name, double x, double y, double width, double height, string type)
        : base(name, x, y, width, height)
    {
        Type = type;
    }

    public string Type { get; private set; }

    //public void ChangeType(string type)
    //{
    //    Type = type;
    //}

    private class TypeClass
    {
        public string type { get; set; }
    }
    public void UndoChangeType(object state)
    {
        TypeClass type = state as TypeClass;
        Type = type.type;
    }

    public UndoMemento ChangeType(string type)
    {
        UndoMemento memento = new UndoMemento() { State = new TypeClass() { type= this.Type }, Command = new Action<object>(UndoChangeType) };
        Type = type;
        return memento;
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Computer: {Name} {X} {Y} {Width} {Height}");
    }
}

// Table is an implementation of RoomItem 
class Table : RoomItem
{
    public Table(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Table: {Name} {X} {Y} {Width} {Height}");
    }
}

// Chair is an implementation of RoomItem
class Chair : RoomItem
{
    public Chair(string name, double x, double y, double width, double height)
        : base(name, x, y, width, height)
    {
    }

    public override void Draw()
    {
        Console.WriteLine($"Draw Chair: {Name} {X} {Y} {Width} {Height}");
    }
}
class ConsoleUI
{
    public static void Main()
    {

        Stack<UndoMemento> undoList = new Stack<UndoMemento>();

        Console.WriteLine("------------ Initial Condition -------------");

        Hall hall = new Hall();

        Room room1 = new Room("room1", 10, 10, 100, 100);
        hall.Add(room1);

        Room room2 = new Room("room2", 150, 150, 200, 200);
        hall.Add(room2);

        Computer computer1 = new Computer("computer1", 1, 1, 5, 5, "Desktop");
        room1.Add(computer1);

        Table table1 = new Table("table1", 10, 10, 7, 7);
        room1.Add(table1);

        hall.Draw();

        Console.WriteLine("\n-------- 1. Hit enter to change Computer Position ---------");
        Console.ReadLine();

        undoList.Push(computer1.ChangePosition(20, 20));

        hall.Draw();

        Console.WriteLine("\n-------- 2. Hit enter to change Computer Size ---------");
        Console.ReadLine();

        undoList.Push(computer1.ChangeSize(8, 8));

        hall.Draw();

        Console.WriteLine("\n-------- 3. Hit enter to change Table Size ---------");
        Console.ReadLine();

        undoList.Push(table1.ChangeSize(50, 50));

        hall.Draw();

        computer1.ChangeType("Laptop");

        //Console.WriteLine("\n------- 1. Hit enter to undo list change ----------");
        //Console.ReadLine();

        //memento.Command(memento.State);
        //hall.Draw();

        //Console.WriteLine("\n------- 2. Hit enter to undo list change ----------");
        //Console.ReadLine();

        //memento = undoList.Pop();
        //memento.Command(memento.State);
        //hall.Draw();

        Console.WriteLine("\n------- Hit enter to undo list change ----------");

        while (undoList.Count > 0)
        {
            Console.ReadLine();
            var memento = undoList.Pop();
            memento.Command(memento.State);
            hall.Draw();
            Console.WriteLine("\n------- Hit enter to undo list change ----------");
        }

        Console.ReadLine();
        Console.WriteLine("No items left to be undone");
        Console.ReadLine();
    }
}
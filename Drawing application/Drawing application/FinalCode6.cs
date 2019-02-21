//using System;
//using System.Collections.Generic;


//class UndoMemento
//{
//    public object State { get; set; }
//    public Action<object> Command { get; set; }
//}


//abstract class Item
//{
//    For Display Purpose Only
//    public string Name { get; private set; }

//    For Position
//    public double X { get; private set; }
//    public double Y { get; private set; }

//    For Size
//    public double Width { get; private set; }
//    public double Height { get; private set; }

//    public Item(string name, double x, double y, double width, double height)
//    {
//        Name = name;
//        X = x;
//        Y = y;
//        Width = width;
//        Height = height;
//    }

//    public void ChangePosition(double x, double y)
//    {
//        X = x;
//        Y = y;
//    }

//    public void ChangeSize(double width, double height)
//    {
//        Width = width;
//        Height = height;
//    }

//    To be overridden by each implementation to perform specific drawing
//    public abstract void Draw();


//    The object of this class will be used to store the previous state
//    Nested class
//    private class Position
//    {
//        public double X { get; set; }
//        public double Y { get; set; }
//    }

//    The method to restore the object to previous state as weel perform operation
//    private void UndoChangePosition(object state)
//    {
//        Position position = state as Position;
//        X = position.X;
//        Y = position.Y;
//    }

//    The method to change the object state and perform operation but also externalize the previous state
//    public UndoMemento ChangePosition(double x, double y)
//    {
//        UndoMemento memento = new UndoMemento() { State = new Position() { X = this.X, Y = this.Y }, Command = new Action<object>(UndoChangePosition) };
//        X = x;
//        Y = y;
//        return memento;
//    }

//    The object of this class will be used to store the previous state
//    class Size
//    {
//        public double Width { get; set; }
//        public double Height { get; set; }
//    }

//    The method to restore the object to previous state as weel perform operation
//    private void UndoChangeSize(object state)
//    {
//        Size size = state as Size;
//        Width = size.Width;
//        Height = size.Height;
//    }

//    The method to change the object state and perform operation but also externalize the previous state
//    public UndoMemento ChangeSize(double width, double height)
//    {
//        UndoMemento memento = new UndoMemento() { State = new Size() { Width = this.Width, Height = this.Height }, Command = new Action<object>(UndoChangeSize) };
//        Width = width;
//        Height = height;
//        return memento;
//    }


//}

//Each item to be added to the hall must implement this class
//abstract class HallItem : Item
//{
//    public HallItem(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }
//}


//class Hall
//{
//    Can contain objects of different implementations of HallItem
//    private List<HallItem> hallItems = new List<HallItem>();

//    public void Add(HallItem hallItem)
//    {
//        hallItems.Add(hallItem);
//    }

//    public void Delete(HallItem hallItem)
//    {
//        hallItems.Remove(hallItem);
//    }

//    Draw the hall with all the items contained in it
//    public void Draw()
//    {
//        Console.WriteLine("Draw Hall");

//        foreach (HallItem hallItem in hallItems)
//            hallItem.Draw();
//    }
//}


//Each item to be added to the room must implement this class
//abstract class RoomItem : Item
//{
//    public RoomItem(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }
//}


//Room is an implementation of HallItem
//class Room : HallItem
//{
//    public Room(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }

//    Can contain objects of difference implementations of RoomItem
//    private List<RoomItem> roomItems = new List<RoomItem>();

//    public void Add(RoomItem roomItem)
//    {
//        roomItems.Add(roomItem);
//    }

//    public void Delete(RoomItem roomItem)
//    {
//        roomItems.Remove(roomItem);
//    }

//    Draw the room with all the items contained in it
//    public override void Draw()
//    {
//        Console.WriteLine($"Draw Room: {Name} {X} {Y} {Width} {Height}");

//        foreach (RoomItem roomItem in roomItems)
//            roomItem.Draw();
//    }
//}


//MetalDetector is an implementation of HallItem
//class MetalDetector : HallItem
//{
//    public MetalDetector(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine($"Draw Metal Detector: {Name} {X} {Y} {Width} {Height}");
//    }
//}


//Computer is an implementation of RoomItem
//class Computer : RoomItem
//{
//    public Computer(string name, double x, double y, double width, double height, string type)
//        : base(name, x, y, width, height)
//    {
//        Type = type;
//    }

//    public string Type { get; private set; }

//    Only Type of computer can be changed.Hence, new method here and not from the RoomItem class.
//    public void ChangeType(string type)
//    {
//        Type = type;
//    }

//    public override void Draw()
//    {
//        Console.WriteLine($"Draw Computer: {Name} {X} {Y} {Width} {Height}");
//    }
//}


//Table is an implementation of RoomItem
//class Table : RoomItem
//{
//    public Table(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine($"Draw Table: {Name} {X} {Y} {Width} {Height}");
//    }
//}


//Chair is an implementation of RoomItem
//class Chair : RoomItem
//{
//    public Chair(string name, double x, double y, double width, double height)
//        : base(name, x, y, width, height)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine($"Draw Chair: {Name} {X} {Y} {Width} {Height}");
//    }
//}


//class ConsoleUI
//{
//    public static void Main()
//    {
//        Hall hall = new Hall();

//        Room room1 = new Room("room1", 10, 10, 100, 100);
//        hall.Add(room1);

//        Room room2 = new Room("room2", 150, 150, 200, 200);
//        hall.Add(room2);

//        Computer computer1 = new Computer("computer1", 1, 1, 5, 5, "Desktop");
//        room1.Add(computer1);

//        Table table1 = new Table("table1", 10, 10, 7, 7);
//        room1.Add(table1);

//        computer1.ChangePosition(20, 20);

//        computer1.ChangeSize(8, 8);

//        table1.ChangeSize(50, 50);

//        computer1.ChangeType("Laptop");

//        hall.Draw();

//        Console.ReadLine();

//    }
//}

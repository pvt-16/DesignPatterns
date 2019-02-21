using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoApplication
{
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

    class Program
    {
        public static void Main()
        {

            Stack<UndoMemento> undoList = new Stack<UndoMemento>();

            Console.WriteLine("------------ Initial Condition -------------");

            Hall hall = new Hall();
            Room room1 = new Room("room1", 10, 10, 100, 100);            hall.Add(room1);
            Room room2 = new Room("room2", 150, 150, 200, 200);            hall.Add(room2);
            Computer computer1 = new Computer("computer1", 1, 1, 5, 5, "Desktop");            room1.Add(computer1);
            Table table1 = new Table("table1", 10, 10, 7, 7);            room1.Add(table1);
            hall.Draw();

            Console.WriteLine("\n-------- 1. Hit enter to change Computer Position ---------");
            Console.ReadLine();
            
            undoList.Push(computer1.changePosition(20, 20));

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

            Console.WriteLine("\n------- Hit enter to undo list change ----------");

            while (undoList.Count > 0)
            {
                Console.ReadLine();
                var memento = undoList.Pop();
                //memento.Command(memento.State);
                hall.Draw();
                Console.WriteLine("\n------- Hit enter to undo list change ----------");
            }

            Console.ReadLine();
            Console.WriteLine("No items left to be undone");
            Console.ReadLine();
        }
    }
}

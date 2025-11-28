using System;
using System.Collections.Generic;

namespace HotelManagementSystem
{
    class Program
    {
        public class Room
        {
            public int Number { get; set; }
            public bool IsBooked { get; set; }
            public string GuestName { get; set; }

            public Room(int number)
            {
                Number = number;
                IsBooked = false;
                GuestName = "";
            }
        }

        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>()
            {
                new Room(101),
                new Room(102),
                new Room(103),
                new Room(104),
                new Room(105)
            };

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== HOTEL MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. View Rooms");
                Console.WriteLine("2. Book Room");
                Console.WriteLine("3. Check Out");
                Console.WriteLine("4. View All Bookings");
                Console.WriteLine("5. Exit");
                Console.Write("Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewRooms(rooms);
                        break;
                    case "2":
                        BookRoom(rooms);
                        break;
                    case "3":
                        CheckOut(rooms);
                        break;
                    case "4":
                        ViewBookings(rooms);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ViewRooms(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("=== ROOMS ===");
            foreach (Room room in rooms)
            {
                string status = room.IsBooked ? $"Booked by {room.GuestName}" : "Available";
                Console.WriteLine($"Room {room.Number}: {status}");
            }
            Console.ReadLine();
        }

        static void BookRoom(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("=== BOOK ROOM ===");
            Console.Write("Enter room number: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Room room = rooms.Find(r => r.Number == number);
                if (room != null)
                {
                    if (!room.IsBooked)
                    {
                        Console.Write("Enter guest name: ");
                        room.GuestName = Console.ReadLine();
                        room.IsBooked = true;
                        Console.WriteLine("Room booked successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Room already booked.");
                    }
                }
                else
                {
                    Console.WriteLine("Room does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        static void CheckOut(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("=== CHECK OUT ===");
            Console.Write("Enter room number: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Room room = rooms.Find(r => r.Number == number);
                if (room != null)
                {
                    if (room.IsBooked)
                    {
                        room.IsBooked = false;
                        room.GuestName = "";
                        Console.WriteLine("Checked out successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Room is not booked.");
                    }
                }
                else
                {
                    Console.WriteLine("Room does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.ReadLine();
        }

        static void ViewBookings(List<Room> rooms)
        {
            Console.Clear();
            Console.WriteLine("=== CURRENT BOOKINGS ===");
            bool any = false;

            foreach (Room room in rooms)
            {
                if (room.IsBooked)
                {
                    Console.WriteLine($"Room {room.Number}: {room.GuestName}");
                    any = true;
                }
            }

            if (!any) Console.WriteLine("No active bookings.");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace FlightMS
{
    class Customer
    {
        private int cust_id;
        private String cust_name;
        public List<Ticket> cust_tikckets = new List<Ticket>();

        public Customer(int cust_id, String cust_name)
        {
            this.cust_id = cust_id;
            this.cust_name = cust_name;
        }
        public int get_cust_id() 
        {
            return cust_id;
        }

        public string get_cust_Name()
        {
            return cust_name;
        }

    }

    class Ticket
    {
        private int tikect_number;
        public List<Coupon> coupon_ticket = new List<Coupon>(4);
        public Ticket(int tikect_number)
        {
            this.tikect_number = tikect_number;
        }
        public int get_tikect_number()
        {
            return tikect_number;
        }

    }

    class Coupon
    {
        private int Coupon_id;
        public List<PiceOfLuaggege> PiceOfNumber = new List<PiceOfLuaggege>();

        public Coupon(int Coupon_id)
        {
            this.Coupon_id = Coupon_id;
        }
        public int get_Coupon_Id()
        {
            return Coupon_id;
        }
    }

    class PiceOfLuaggege
    {
        private int number;
        private double Weight;

        public PiceOfLuaggege(int number,double weight)
        {
            this.number = number;
            this.Weight = weight;
        }
        public int get_pol_number()
        {
            return number;
        }
        public double get_pol_weight()
        {
            return Weight;
        }

    }

    class Flight
    {
        private int Flight_Id;
        public List<Coupon> coupon_flight = new List<Coupon>();
        public Flight(int Flight_Id)
        {
            this.Flight_Id = Flight_Id;
       
        }
        public int get_Flight_Id()
        {
            return Flight_Id;
        }
    

    }
    
    class FlightNumber
    {
        private String Departure;
        private String Description;
        private String Airline;
        public List<Flight> Flights = new List<Flight>();

        public FlightNumber(string Departure, string Description,string Airline)
        {
            this.Departure = Departure;
            this.Description = Description;
            this.Airline = Airline;

        }
        public string get_Departure()
        {
            return Departure;
        }
        public string get_Description()
        {
            return Description;
        }
        public string get_Airline()
        {
            return Airline;
        }
     
    }
    class Airport
    {
        private String Name;
        private int Airport_Id;
        public List<FlightNumber> FlightNumber = new List<FlightNumber>();
        public Airport(String Name, int Airpot_Id) 
        {
            this.Name = Name;
            this.Airport_Id = Airpot_Id;
        }

        public string get_Airport_Name()
        {
            return Name;
        }

        public int get_Airport_Id()
        {
            return Airport_Id;
        }
    }
    

    class Program
    {
       static Tuple<List<Customer>, List<Airport>> Add_Data()
        {
            List <Customer> cust_list = new List<Customer>();
            List <Airport> Airport_list = new List<Airport>();
            Random r = new Random();
            for(int i =0; i< 5; i++)
            {
                Customer c1 = new Customer(r.Next(50),"Omar");
                Airport A1 = new Airport("USA", r.Next(50));

                /*Create Flight numbers To The Airport*/
                A1.FlightNumber.Add(new FlightNumber("At 12:00 Am", "Goes To USA", "USA"));
                FlightNumber last_FlightNumber = A1.FlightNumber[A1.FlightNumber.Count - 1];

                /*Create Flight to the flight number  */
                last_FlightNumber.Flights.Add(new Flight(r.Next(50)));


                c1.cust_tikckets.Add(new Ticket(r.Next(50)));
                Ticket last_tickt = c1.cust_tikckets[c1.cust_tikckets.Count - 1];
             
                last_tickt.coupon_ticket.Add(new Coupon(r.Next(50)));
                last_tickt.coupon_ticket[last_tickt.coupon_ticket.Count - 1].PiceOfNumber.Add(new PiceOfLuaggege(r.Next(50), r.Next(50)));
               

                /*Add coupone*/
                last_FlightNumber.Flights[last_FlightNumber.Flights.Count - 1].coupon_flight.Add(last_tickt.coupon_ticket[last_tickt.coupon_ticket.Count - 1]);

                c1.cust_tikckets.Add(new Ticket(r.Next(50)));
                last_tickt = c1.cust_tikckets[c1.cust_tikckets.Count - 1];
                last_tickt.coupon_ticket.Add(new Coupon(r.Next(50)));
                last_tickt.coupon_ticket[last_tickt.coupon_ticket.Count - 1].PiceOfNumber.Add(new PiceOfLuaggege(r.Next(50), r.Next(50)));

                cust_list.Add(c1);

                Airport_list.Add(A1);

            }

            return Tuple.Create(cust_list, Airport_list);
        }


        public static Tuple<int, int> GetMultipleValue()
        {
            return Tuple.Create(1, 2);
        }
        static void Main(string[] args)
        { 
            String choices = "0";
            Tuple<List<Customer>, List<Airport>> Data_list = Add_Data();


            while (choices != "4")
            {
                Console.WriteLine("1. Retrieve customers ");
                Console.WriteLine("2. Retrieve list of tickets by customer ID and Coupons it contains ");
                Console.WriteLine("3. Retrieve Coupon details and Flights under it if exist and Flight number details and Airport information ");
                Console.WriteLine("4. Exit ");

                Console.Write("your Number :  ");
                choices = Console.ReadLine();

                switch (choices)
                {
                    case "1":
                        Console.WriteLine("Customer_ID \t Customer_Name\n");
                        foreach (Customer cust in Data_list.Item1)
                        {
                            Console.WriteLine("\t"+cust.get_cust_id()+"\t\t"+ cust.get_cust_Name());
                        }
                       break;
                    case "2":
                        Console.Write("Enter Customer ID :  ");
                        String res = Console.ReadLine();
                        int cust_id = Convert.ToInt32(res);
                        Console.WriteLine("\n");


                        
                        foreach (Customer cust in Data_list.Item1)
                        {
                            if (cust_id == cust.get_cust_id())
                            {
                                foreach(Ticket tik in cust.cust_tikckets)
                                {

                                    foreach (Coupon cop in tik.coupon_ticket)
                                    {
                                        Console.WriteLine("Tiket " + tik.get_tikect_number() + " \tcoupon "+ cop.get_Coupon_Id());

                                    }

                                }
                              
                            }
                            
                        }
                        break;

                    case "3":
                        Console.Write("Enter Coupon ID :  ");
                        String Coupon = Console.ReadLine();
                        int cop_id = Convert.ToInt32(Coupon);
                        Console.WriteLine("\n");

                        foreach (Airport air in Data_list.Item2)
                        {
                            foreach (FlightNumber fn in air.FlightNumber)
                            {
                                foreach (Flight fcop in fn.Flights)
                                {
                                    foreach (Coupon cop in fcop.coupon_flight)
                                    {
                                        foreach(PiceOfLuaggege pol in cop.PiceOfNumber)
                                        {

                                            if (cop.get_Coupon_Id() == cop_id)
                                            {
                                                Console.WriteLine("Flight_ID : " + fcop.get_Flight_Id()+ " Airline : " + fn.get_Airline() + "  Departure :" + fn.get_Departure() + "  Description :" + fn.get_Description());
                                            }
                                        }

                                    }
                                }


                            }

                        }

                        foreach (Customer cust in Data_list.Item1)
                        {
                            foreach (Ticket tik in cust.cust_tikckets)
                                {
                                foreach (Coupon cop in tik.coupon_ticket)
                               {
                                   foreach(PiceOfLuaggege pol in cop.PiceOfNumber)
                                    {
                                        if (cop.get_Coupon_Id() == cop_id) 
                                        { 
                                            Console.WriteLine("PiceOfLuaggege Number " + pol.get_pol_number() + " \tweight " + pol.get_pol_weight());
                                        }
                                    }

                               }

                                }
                            

                        }
                        break;
                }

            }
        }
    }
}

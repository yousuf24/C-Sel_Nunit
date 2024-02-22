using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KarthikProj
{
    class Program
    {
        delegate void PV(String toP);
        static void Main(string[] args)
        {
            #region history
            // http://executeautomation.com/blog/
            Console.WriteLine("Hello Md Yousuf from tcs. Your empID: 2573662 and m.yousuf@tcs.com will be your official Email");
            //NewMethod();
            Program obj2 = new Program();
            // obj2.Method99(10, 20);

            //int[] tcs = { 101, 102, 103 };
            //Console.WriteLine(tcs.Length);
            //foreach(int each in tcs)
            //{
            //    Console.WriteLine(each);
            //}
            //obj2.Method98();

            //obj2.GcW();

            //obj2.iter();

            //Printer p = Program2.printV;
            //p("Hello yousuf, welcome to TCS!, improve your automation experience and upskill yourself before 29");


            //Using lamda expressions
            //Printer p = msg => { Console.WriteLine(msg); }; // very consize , dont need any implementer method
            //p("Work it up and enjoy learning!");

            //Object ob = null;
            //Console.WriteLine(ob);
            #endregion

            //implementation of delegate
            //PV p = (msg) => { Console.WriteLine(msg); };
            //p("perform delgate implementation");

            //obj2.method88("lockie ferguson",10,out String result);
            //Console.WriteLine(result);

            //User object0 = new User() { Id=7932,Age=26,PhoneNo=8332811095,Name="yousuf Md"};
            //object0.getStudName();

            //This is a copy of master branch
            //String.Concat("Master", "feature add on");

            //try
            //{
            //    String FN = "2480";
            //    int Rank = int.Parse(FN);
            //    int RankDup = Convert.ToInt32(FN);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Can't convert into integer");
            //}

            //var numbers = new List<int>() { 1, 0, 5, 63, 89, 7, 10 };
            //var smallest = GetNumbers(numbers, 3);
            //foreach (var e in smallest) Console.WriteLine(e);

            //var P = new Person();
            //P.parse("Joey");
            //P.Introduce("Blue shields");

            obj2.Add(1, 2, 4, 56, 23);

            List<int> lst = new List<int>() { 1, 4, 3, 44, 5, 56, 18 };
            List<int> lst2 = new List<int>() { };
            var fst = lst.FirstOrDefault();
            var second = lst2.FirstOrDefault();
            Console.WriteLine("First:Second " + fst + " : " + second);

            //Distinct
            var uniq = lst.Distinct().ToList();
            //Filter 
            var lstEven = lst.Where(x => x % 2 == 0).ToList();
            //Order by ASC
            var lstAsc = lst.OrderBy(x => x).ToList();
            //Order by DESC
            var lstDesc = lst.OrderByDescending(x => x).ToList();
            //CheckEven [ any one]
            var checkEven = lst.Any(x => x % 2 == 0);
            //CheckEvn
            var checkAllForEven = lst.All(x => x % 2 == 0);
            //Random 10digit string
            string str = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            string randomStr = new String(Enumerable.Repeat(str, 10).Select(x => x[rand.Next(0, str.Length)]).ToArray());
            Console.WriteLine(randomStr);
            //skip .skip(), limit 3 use .Take(3)

            //Zip
            var numbers = new List<int>() { 101,102,103,104};
            var names = new List<string>() { "sai", "priya", "prabhavathi", "yousuf" };
            var result=numbers.Zip(names, (num, nm) => $"{num}->{nm}");

            //Aggregate
            numbers.Aggregate((accum, num) => accum + num);

            //SelectMany
            var lstOfOrders = new List<Order>()
            {
                new Order(){ Id=1,Products=new List<string>{ "representation","Subscription"} },
                new Order(){ Id=1,Products=new List<string>{ "ARMS","ANR"} }
            };
            var lstOfproducts=lstOfOrders.SelectMany(orderObj => orderObj.Products);

            Console.Read();
        }

        #region methods
        void Dict()
        {
            Dictionary<String, int> dic = new Dictionary<string, int>();
            dic.Add("Yousuf MD", 24);
            Console.WriteLine(  dic["Yousuf MD"]); //they are also associative array
            dic.ContainsKey("Priya");
            dic.ContainsValue(12);

        }
        void MyStack()
        {
            Stack<String> MyS = new Stack<String>();
            MyS.Push("SixtyThree");
            Console.WriteLine(  MyS.Count);
            foreach (var e in MyS) Console.WriteLine(   e);
            MyS.Peek();
            MyS.Pop();
        }
        void Method100()
        {
            String[] songs = { "Billy_ellish", "JB", "DJSnake", "Khalid", "Halsey" };
            LinkedList<String> col = new LinkedList<string>(songs);
            col.AddFirst("VidyaVox");
            col.AddLast("Conor mayor");

            Console.WriteLine(col.Contains("joey"));
            col.Find("arul");
            String Fv=col.First.Value;
            String Lv=col.Last.Value;

        }
        void Method99(int a, int b)
        {
            Console.WriteLine("two params"+(a+b));  
        }

        private static void NewMethod()
        {
            // Console.Read();
            double salary = 605480.23d;

            Console.WriteLine((int)salary);//cw double tab will write the print statement
        }
    
        public void Method98()
        {
            Hashtable ht = new Hashtable();
            ht.Add(200, "YousufMD");
            ht.Add(201, "JanaChaitanyaColony Turkyamjal");
            ht.Add(203, "2573662");
            //Console.WriteLine(ht[203]);
            foreach(var key in ht.Keys)
            {
                Console.WriteLine("key: "+key+" value: "+ht[key]);
            }
        }
        
        void GcW()
        {
            // not so recommended method
            //List<User> info = new List<User>();
            //info.Add(new User { Id = 25, Name = "Yousuf MD", Age = 26, PhoneNo = 8332811095 });
            //info.Add(new User { Id = 26, Name = "Meera Bhai", Age = 27, PhoneNo = 9897654332 });

            //Recommended method
            List<User> info = new List<User>()
            {
                new User
                {
                    Id=25,
                    Name="Yousuf",
                    Age=26,
                    PhoneNo=8332811095
                },
                new User
                {
                    Id=26,
                    Name="Sai",
                    Age=25,
                    PhoneNo=9182376549
                }
            };

            //iterate through collection
            foreach(var each in info)
            {
                Console.WriteLine(String.Format("User with id {0} and name {1} of age {2} has phoneNo {3}",each.Id,each.Name,each.Age,each.PhoneNo));
            }
        }
        
        void iter()
        {
            List<User> users = new List<User>();
            users.Add(new User { Id = 1, Name = "Yousuf", Age = 26, PhoneNo = 8332811095, 
                addresses = new List<Address>() { 
                                new Address { Flat = 221, country = "UK", Street = "Baker St" },
                                new Address { Flat = 17-25-280, country = "India", Street = "Islam peta" }  } });
            users.Add(new User { Id = 2, Name = "kutti", Age = 23, PhoneNo = 9182736543,
                addresses = new List<Address>() {
                                new Address { Flat = 22, country = "US", Street = "Baker St" },
                                new Address { Flat = 18-25-280, country = "India", Street = "BNR" }  }
            });
            users.Add(new User { Id = 3, Name = "keenu", Age = 46, PhoneNo = 8332821095,
                addresses = new List<Address>() {
                                new Address { Flat = 21, country = "Europe", Street = "Vlademov" },
                                new Address { Flat = 19-25-280, country = "India", Street = "Yamjal" }  }
            });
            users.Add(new User { Id = 4, Name = "monica", Age = 57, PhoneNo = 8332812095,
                addresses = new List<Address>() {
                                new Address { Flat = 20, country = "NewZeaLand", Street = "SunDay st" },
                                new Address { Flat = 20-25-280, country = "India", Street = "stanley st" }  }
            });

            //var user_collection = from user in users
            //                      select user.Name;

            //var user_collection = users.Select(x => x.Name);

            //var user_collection = from user in users
            //                      where user.Age > 10
            //                      select user.Name;

            //var user_collection = users.Where(x=>x.Age>10).Select(x => x.Name);

            //foreach (var e in user_collection) Console.WriteLine(e);

            //var user_projection = from user in users
            //                      where user.Name == "Yousuf"
            //                      select new { FullName = user.Name, CellularNumber = user.PhoneNo };

            //foreach(var user in user_projection)
            //Console.WriteLine(user.CellularNumber+" "+user.FullName); 

            //var userMany = from user in users
            //               from address in user.addresses
            //               where user.Age >= 10
            //               select new { FN = user.Name, Age=user.Age, No = user.PhoneNo, street = address.Street };

            var userMany = users.Where(x => x.Age >= 10).SelectMany(x =>x.addresses);
            foreach(var e in userMany)
            {
                //Console.WriteLine(String.Format(" Candidate name: {0} with age {1} has no. {2} in country  {3}",e.Street));
                Console.WriteLine(e.Street);
            }

        }
        #endregion

        #region Feb42023
        public void method88(String input,in int a,out string b)
        {
            b = String.Concat("append", input,$"{a}");
            Console.WriteLine($"output of method88: {b}"); 
        }
        public String ValidateEmail(String email)
        {
            String domain = email.Split("@")[1];

            //without pattern matching
            switch (domain)
            {
                case "gmail.com": return "valid email";
                case "hotmail.com": return "valid email";
                default: return "invalid email";
            }

            //with pattern matching - C# version should be 9 or above
            //return domain switch
            //{
            //    "gmail.com" or "hotmail.com" => "valid email";
            //    "xxx.com" => "invalid useremail";
            //    _=>"invalid user";

            //};

        }
        
        
        
        #endregion
        
        public static List<int> GetNumbers(List<int> li,int count)
        {
            List<int> temp = new List<int>();
            li.Sort();
            for (int i = 0; i < count; i++)
            {
                temp.Add(li.ElementAt(i));
            }
            return temp;
        }
        public int Add(params int[] Arr)// using params works similar to spread operator in JS/java
        {
            return Arr.Length;
        }
        public T Max<T>(T a,T b) where T:IComparable //Here i defined generic method that has generic which extends IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        List<String> names = new List<String>() { "Joey", "chandler", "Rachel", "monica", "ross", "phoebe" };
        
  
    }
    public class User
    {
        public User()
        {

        }
        
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public Int64 PhoneNo { get; set; }
        public List<Address> addresses { get; set; }
        public String getStudName()
        {
            return Name?? throw new Exception("Name property has to be defined");
        }
        public User(int id, String name)
        {
            Id = id;
            Name = name;
        }
}
}
public class Address
{
    public int Flat { get; set; }
    public String Street { get; set; }
    public String country { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public List<string> Products { get; set; }
}
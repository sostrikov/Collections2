using System;
using System.Collections;//Не обобщенные коллекции
using System.Collections.Generic;//Обобщенные коллекции
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using FigureCollections;

namespace Collections
{
    class Program
    {
		
		static void Main(string[] args)
        {
			
			

			PrintMessage("Примеры к лекции №3", 12);

			#region List_and_ArrayList
			//Списки
			PrintMessage("Списки", 10);

			//Работа с обобщенным списком
			PrintMessage("Обобщенный список", 14);

			List<int> li = new List<int>();
			li.Add(1);
			li.Add(2);
			li.Add(3);
			li.Add(30);
			li.Add(300);
			foreach (int i in li)
			{
				Console.WriteLine($"{i}");
			}

			int item2 = li[1];
			int count = li.Count;
			bool is3 = li.Contains(3);
			Console.WriteLine($"count = {count}");
			li.Remove(2);

			//Работа с необобщенным списком
			PrintMessage("Необобщенный список", 14);

			ArrayList al = new ArrayList();
			al.Add(333);
			al.Add(123.123);
			al.Add("строка-1");

			foreach (object o in al)
			{
				//Для определения типа используется механизм рефлексии
				string type = o.GetType().Name;
				if (type == "Int32")
				{
					Console.WriteLine("Целое число: " + o.ToString());
				}
				else if (type == "String")
				{
					Console.WriteLine("Строка: " + o.ToString());
				}
				else
				{
					Console.WriteLine("Другой тип: " + o.ToString());
				}
			}
			#endregion

			#region Stack
			PrintMessage("Стек", 10);
			//Работа со стеком (Последним пришел - первым вышел)

			Stack<int> st = new Stack<int>();
			st.Push(1);
			st.Push(2);
			st.Push(3);

			PrintMessage("Перебор элементов стека с помощью foreach:", 14);
			
			foreach (int i in st)
			{
				Console.WriteLine(i);
			}
			PrintMessage("Получение верхнего элемента без удаления:", 14);
			
			int i2 = st.Peek();
			Console.WriteLine(i2);

			PrintMessage("Чтение с удалением элементов из стека:", 14);
			
			while (st.Count > 0)
			{
				int i = st.Pop();
				Console.WriteLine(i);
			}
			#endregion

			#region Queue
			PrintMessage("Очередь", 10);

			//Работа с очередью (Первым пришел - первым вышел)

			Queue<int> q = new Queue<int>();
			q.Enqueue(11);
			q.Enqueue(22);
			q.Enqueue(33);

			PrintMessage("Перебор элементов очереди с помощью foreach:", 14);
			foreach (int i in q)
			{
				Console.WriteLine(i);
			}

			PrintMessage("Получение первого элемента без удаления:", 14);
			
			int i3 = q.Peek();
			Console.WriteLine(i3);

			PrintMessage("Чтение с удалением элементов из очереди:", 14);
			
			while (q.Count > 0)
			{
				int i = q.Dequeue();
				Console.WriteLine(i);
			}
			#endregion

			#region Dictionary

			//Работа с обобщенным словарем
			PrintMessage("Обобщенный (generic) словарь (ассоциативный массив): ", 10);
			
			Dictionary<int, string> d = new Dictionary<int, string>();

			d.Add(1, "строка 1");
			d.Add(2, "строка 2");
			d.Add(4, "строка 4");
			d.Add(3, "строка 3");
			d.Remove(4);

			//Перебор элементов словаря
			foreach (KeyValuePair<int, string> v in d)
			{
				Console.WriteLine(v.Key.ToString() + "-" + v.Value);
			}

			//Перебор ключей
			Console.Write("\nКлючи: ");
			foreach (int i in d.Keys)
			{
				Console.Write(i.ToString() + " ");
			}

			//Перебор значений
			Console.Write("\nЗначения: ");
			foreach (string str in d.Values)
			{
				Console.Write(str + " ");
			}

			//Получение значения по ключу
			int key = 3;
			string val = d[key];//перегруженный индексатор
			Console.WriteLine("\nДля ключа '" + key.ToString() + "' значение '" + val + "'");

			//Проверка на наличие элемента с заданным индексом в словаре
			string val2 = "";
			bool res = d.TryGetValue(key, out val2);
			if (res)
			{
				Console.WriteLine("\nДля ключа '" + key.ToString() + "' значение '" + val2 + "'");
			}
			
			
			//Новый синтаксис инициализации словаря
			Dictionary<int, string> d1 = new Dictionary<int, string>
			{
				[1] = "строка 11",
				[2] = "строка 22",
				[3] = "строка 33"
			};
			#endregion


			#region Tuple
			PrintMessage("Кортеж", 10);
			Tuple<int, string, string> group = new Tuple<int, string, string>(1, "ИУ", "ИУ-5");
			Console.WriteLine(group.ToString());

			//Класс позволяет определять до 8 параметров,
			//если нужно большее количество используется следующее объявление
			Tuple<int, int, int, int, int, int, int, Tuple<string, string, string>> tuple = new Tuple<int, int, int, int, int, int, int, Tuple<string, string, string>>(1, 2, 3, 4, 5, 6, 7, new Tuple<string, string, string>("str1", "str2", "str3"));
			Console.WriteLine(tuple.ToString());

			//Объявление списка, элементом которого является кортеж
			List<Tuple<int, int, int>> tupleList = new List<Tuple<int, int, int>>();
			tupleList.Add(new Tuple<int, int, int>(1, 1, 1));
			tupleList.Add(new Tuple<int, int, int>(2, 2, 2));
			tupleList.Add(new Tuple<int, int, int>(3, 3, 3));

			foreach (var x in tupleList) Console.WriteLine(x);

			//Новый синтаксис инициализации кортежа
			//В консоли диспетчера пакетов NuGet выполнить Install-Package "System.ValueTuple"

			PrintMessage("Новый синтаксис инициализации кортежа вариант 1", 14);
			(string group, int number) tuple1 = ("ИУ5-", 32);
			Console.WriteLine($"Имя поля кортежа: {tuple1.group}");
			Console.WriteLine($"Значение поля кортежа: {tuple1.number}");

			//Указываем параметры в правой части
			PrintMessage("Новый синтаксис инициализации кортежа вариант 2", 14);
			var tuple2 = (group: "РТ5-", number: 31);
			Console.Write(tuple2.group);
			Console.WriteLine(tuple2.number);

			//Использование кортежа в качестве входного параметра метода
			InputTuple(tuple2);

			//Использование кортежа в качестве выходного параметра метода
			var tuple3 = OutputTuple();

			//Разименовывание кортежа
			(string str1, int int1) = OutputTuple();
			#endregion

			#region Sort
			PrintMessage("Сортировка списка", 10);
			
			List<int> sl = new List<int>();
			sl.Add(5);
			sl.Add(3);
			sl.Add(2);
			sl.Add(1);
			sl.Add(4);
			Console.WriteLine("\nПеред сортировкой:");
			foreach (int i in sl) Console.Write(i.ToString() + " ");

			//Сортировка
			sl.Sort();

			Console.WriteLine("\nПосле сортировки:");
			foreach (int i in sl) Console.Write(i.ToString() + " ");
			#endregion

			#region Figures
			/*
			PrintMessage("Сортировка ссылочных типов", 10);
			//Создание объектов классов фигур:
			Rectangle rect = new Rectangle(5, 4);
			Square square = new Square(5);
			Circle circle = new Circle(5);

			//Добавление в список:
			List<Figure> fl = new List<Figure>();
			fl.Add(circle);
			fl.Add(rect);
			fl.Add(square);

			PrintMessage("До сортировки:", 14);
			

			foreach (var x in fl) Console.WriteLine(x);
			//сортировка
			fl.Sort();

			PrintMessage("После сортировки:", 14);
			foreach (var x in fl) Console.WriteLine(x);
			*/
			#endregion

			Console.ReadLine();
        }
		//================================================================================

		
		/// <summary>
		/// Метод с входным параметром кортеж
		/// </summary>
		/// <param name="tupleParam"></param>
		/// 
		public static void InputTuple((string strP, int intP) tupleParam)
		{
			Console.WriteLine($"Method whis Tuple parametr: {tupleParam}");
		}

		/// <summary>
		/// Метод с выходным параметром кортеж
		/// </summary>
		/// <returns>Tuple</returns>
		
		public static (string strParam, int intParam) OutputTuple()
		{
			return ("строка", 333);
		}

		/// <summary>
		/// Пучать строки заданным цветом
		/// </summary>
		/// <param name="mes"></param>
		/// <param name="col"></param>
		public static void PrintMessage(string mes, int col)
		{
			ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
			Console.ForegroundColor = colors[col]; //10-Green 12-Red 14-Yellow

			if (col == 10) Console.WriteLine($"\n{ mes}");
			else if (col == 14) Console.WriteLine($"\n\t{ mes}");
			else Console.WriteLine($"{ mes}");
			Console.ResetColor();
		}
	}
}

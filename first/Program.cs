using System;

namespace first
{
    class MyStack<T>

    {

        public T[] Items;
        int top;
        int max;

        public MyStack(int i)
        {
            Items = new T[i];

        }

        public void InitStack()
        {
            top = 0;
        }

        public void ClearStack()
        {
            for(int i=0;i<top;i++)
            {
                pop();
            }
        }

        public bool push(T item)
        {
            if (top > Items.Length)
            {
                Console.WriteLine("栈已满");
                return false;
            }
            Items[top] = item;
            top++;
            return true;


        }

        public T pop()
        {
            if (top <= 0)
            {
                Console.WriteLine("栈为空");
            }
            T value = Items[top- 1];
            top--;
            return value;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 2, c = 3;
            MyStack<int> stack = new MyStack<int>(10);
            stack.InitStack();
            stack.push(a);
            stack.push(b);
            stack.push(c);
            Console.WriteLine(stack.pop());
            stack.ClearStack();
            Console.WriteLine(stack.pop());
        }
    }
}
